using System.Collections.Generic;
using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ClientManage.BL.Library
{
    #region "FTP client class"
    /// <summary>
    /// A wrapper class for .NET 2.0 FTP
    /// </summary>
    /// <remarks>
    /// This class does not hold open an FTP connection but
    /// instead is stateless: for each FTP request it
    /// connects, performs the request and disconnects.
    /// </remarks>
    public class FtPclient
    {
        public delegate void FtpEventHandler(object sender, FtpEventArgs e);
        public event FtpEventHandler ProccessUpload;
        public event FtpEventHandler ProccessDownload;

        #region "CONSTRUCTORS"
        /// <summary>
        /// Blank constructor
        /// </summary>
        /// <remarks>Hostname, username and password must be set manually</remarks>
        public FtPclient()
        {
        }

        /// <summary>
        /// Constructor just taking the hostname
        /// </summary>
        /// <param name="hostname">in either ftp://ftp.host.com or ftp.host.com form</param>
        /// <remarks></remarks>
        public FtPclient(string hostname)
        {
            _hostname = hostname;
        }

        /// <summary>
        /// Constructor taking hostname, username and password
        /// </summary>
        /// <param name="hostname">in either ftp://ftp.host.com or ftp.host.com form</param>
        /// <param name="username">Leave blank to use 'anonymous' but set password to your email</param>
        /// <param name="password"></param>
        /// <remarks></remarks>
        public FtPclient(string hostname, string username, string password)
        {
            _hostname = hostname;
            _username = username;
            Password = password;
        }
        #endregion

        #region "Directory functions"
        /// <summary>
        /// Return a simple directory listing
        /// </summary>
        /// <param name="directory">Directory to list, e.g. /pub</param>
        /// <returns>A list of filenames and directories as a List(of String)</returns>
        /// <remarks>For a detailed directory listing, use ListDirectoryDetail</remarks>
        public List<string> ListDirectory(string directory)
        {
            //return a simple list of filenames in directory
            var ftp = GetRequest(GetDirectory(directory));
            //Set request to do simple list
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;

            var str = GetStringResponse(ftp);
            //replace CRLF to CR, remove last instance
            str = str.Replace("\r\n", "\r").TrimEnd('\r');
            //split the string into a list
            var result = new List<string>();
            result.AddRange(str.Split('\r'));
            return result;
        }

        /// <summary>
        /// Return a detailed directory listing
        /// </summary>
        /// <param name="directory">Directory to list, e.g. /pub/etc</param>
        /// <returns>An FTPDirectory object</returns>
        public FtpDirectory ListDirectoryDetail(string directory)
        {
            var ftp = GetRequest(GetDirectory(directory));
            //Set request to do simple list
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            var str = GetStringResponse(ftp);
            //replace CRLF to CR, remove last instance
            str = str.Replace("\r\n", "\r").TrimEnd('\r');
            //split the string into a list
            return new FtpDirectory(str, _lastDirectory);
        }

        #endregion

        #region "Upload: File transfer TO ftp server"
        /// <summary>
        /// Copy a local file to the FTP server
        /// </summary>
        /// <param name="localFilename">Full path of the local file</param>
        /// <param name="targetFilename">Target filename, if required</param>
        /// <returns></returns>
        /// <remarks>If the target filename is blank, the source filename is used
        /// (assumes current directory). Otherwise use a filename to specify a name
        /// or a full path and filename if required.</remarks>
        public bool Upload(string localFilename, string targetFilename)
        {
            //1. check source
            if (!File.Exists(localFilename))
            {
                throw (new ApplicationException("File " + localFilename + " not found"));
            }
            //copy to FI
            var fi = new FileInfo(localFilename);
            return Upload(fi, targetFilename);
        }

        /// <summary>
        /// Upload a local file to the FTP server
        /// </summary>
        /// <param name="fi">Source file</param>
        /// <param name="targetFilename">Target filename (optional)</param>
        /// <returns></returns>
        public bool Upload(FileInfo fi, string targetFilename)
        {
            //copy the file specified to target file: target file can be full path or just filename (uses current dir)

            var ret = true;

            //1. check target
            string target;
            if (targetFilename.Trim() == "")
            {
                //Blank target: use source filename & current dir
                target = this.CurrentDirectory + fi.Name;
            }
            else if (targetFilename.Contains("/"))
            {
                //If contains / treat as a full path
                target = AdjustDir(targetFilename);
            }
            else
            {
                //otherwise treat as filename only, use current directory
                target = CurrentDirectory + targetFilename;
            }

            var uri = Hostname + target;
            //perform copy
            var ftp = GetRequest(uri);

            //Set request to upload a file in binary
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            ftp.UseBinary = true;

            //Notify FTP of the expected size
            ftp.ContentLength = fi.Length;

            //create byte array to store: ensure at least 1 byte!
            const int bufferSize = 2048;
            var content = new byte[bufferSize - 1 + 1];
            long totalRead = 0;

            //open file for reading
            using (var fs = fi.OpenRead())
            {
                try
                {
                    //open request to send
                    using (var rs = ftp.GetRequestStream())
                    {
                        FtpEventArgs arg;
                        int dataRead;
                        do
                        {
                            dataRead = fs.Read(content, 0, bufferSize);
                            totalRead += dataRead;
                            rs.Write(content, 0, dataRead);
                            arg = new FtpEventArgs(totalRead);
                            if (ProccessUpload != null) ProccessUpload(this, arg);
                            if (arg.Cancel) { ret = false; break; }
                        } while (!(dataRead < bufferSize));
                        rs.Close();
                    }
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    //ensure file closed
                    fs.Close();
                }

            }

            return ret;
        }
        #endregion

        #region "Download: File transfer FROM ftp server"

        /// <summary>
        /// Copy a file from FTP server to local
        /// </summary>
        /// <param name="sourceFilename">Target filename, if required</param>
        /// <param name="localFilename">Full path of the local file</param>
        /// <param name="permitOverwrite"></param>
        /// <returns></returns>
        /// <remarks>Target can be blank (use same filename), or just a filename
        /// (assumes current directory) or a full path and filename</remarks>
        public bool Download(string sourceFilename, string localFilename, bool permitOverwrite)
        {
            //2. determine target file
            var fi = new FileInfo(localFilename);
            return this.Download(sourceFilename, fi, permitOverwrite);
        }

        //Version taking an FtpFileInfo
        public bool Download(FtPfileInfo file, string localFilename, bool permitOverwrite)
        {
            return this.Download(file.FullName, localFilename, permitOverwrite);
        }

        //Another version taking FtpFileInfo and FileInfo
        public bool Download(FtPfileInfo file, FileInfo localFi, bool permitOverwrite)
        {
            return this.Download(file.FullName, localFi, permitOverwrite);
        }

        //Version taking string/FileInfo
        public bool Download(string sourceFilename, FileInfo targetFi, bool permitOverwrite)
        {
            var ret = true;

            //1. check target
            if (targetFi.Exists && !(permitOverwrite))
            {
                throw (new ApplicationException("Target file already exists"));
            }

            //2. check source
            string target;
            if (sourceFilename.Trim() == "")
            {
                throw (new ApplicationException("File not specified"));
            }
            
            if (sourceFilename.Contains("/"))
            {
                //treat as a full path
                target = AdjustDir(sourceFilename);
            }
            else
            {
                //treat as filename only, use current directory
                target = CurrentDirectory + sourceFilename;
            }

            var uri = Hostname + target;

            //3. perform copy
            var ftp = GetRequest(uri);

            //Set request to download a file in binary mode
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp.UseBinary = true;

            //open request and get response stream
            using (var response = (FtpWebResponse)ftp.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    //loop to read & write to file
                    using (var fs = targetFi.OpenWrite())
                    {
                        try
                        {
                            var buffer = new byte[2048];
                            int read;
                            long totalRead = 0;
                            FtpEventArgs arg;

                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                totalRead += read;
                                fs.Write(buffer, 0, read);
                                arg = new FtpEventArgs(totalRead);
                                if (ProccessDownload != null) ProccessDownload(this, arg);
                                if (arg.Cancel) { ret = false; break; }
                            } while (read != 0);
                            responseStream.Close();
                            fs.Flush();
                            fs.Close();
                        }
                        catch (Exception)
                        {
                            //catch error and delete file only partially downloaded
                            fs.Close();
                            //delete target file as it's incomplete
                            targetFi.Delete();
                            throw;
                        }
                    }

                    responseStream.Close();
                }

                response.Close();
            }


            return ret;
        }
        #endregion

        #region "Other functions: Delete rename etc."
        /// <summary>
        /// Delete remote file
        /// </summary>
        /// <param name="filename">filename or full path</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool FtpDelete(string filename)
        {
            //Determine if file or full path
            var uri = this.Hostname + GetFullPath(filename);

            var ftp = GetRequest(uri);
            //Set request to delete
            ftp.Method = WebRequestMethods.Ftp.DeleteFile;
            try
            {
                //get response but ignore it
                GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Determine if file exists on remote FTP site
        /// </summary>
        /// <param name="filename">Filename (for current dir) or full path</param>
        /// <returns></returns>
        public bool FtpFileExists(string filename)
        {
            //Try to obtain filesize: if we get error msg containing "550"
            //the file does not exist
            try
            {
                GetFileSize(filename);
                return true;
            }
            catch (Exception ex)
            {
                //only handle expected not-found exception
                if (ex is WebException)
                {
                    //file does not exist/no rights error = 550
                    if (ex.Message.Contains("550"))
                    {
                        //clear
                        return false;
                    }
                    throw;
                }
                throw;
            }
        }

        /// <summary>
        /// Determine size of remote file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks>Throws an exception if file does not exist</remarks>
        public long GetFileSize(string filename)
        {
            string path;
            if (filename.Contains("/"))
            {
                path = AdjustDir(filename);
            }
            else
            {
                path = this.CurrentDirectory + filename;
            }
            var uri = this.Hostname + path;
            var ftp = GetRequest(uri);
            //Try to get info on file/dir?
            ftp.Method = WebRequestMethods.Ftp.GetFileSize;
            GetStringResponse(ftp);
            return GetSize(ftp);
        }

        public bool FtpRename(string sourceFilename, string newName)
        {
            //Does file exist?
            var source = GetFullPath(sourceFilename);
            if (!FtpFileExists(source))
            {
                throw (new FileNotFoundException("File " + source + " not found"));
            }

            //build target name, ensure it does not exist
            var target = GetFullPath(newName);
            if (target == source)
            {
                throw (new ApplicationException("Source and target are the same"));
            }
            if (FtpFileExists(target))
            {
                throw (new ApplicationException("Target file " + target + " already exists"));
            }

            //perform rename
            var uri = this.Hostname + source;

            var ftp = GetRequest(uri);
            //Set request to delete
            ftp.Method = WebRequestMethods.Ftp.Rename;
            ftp.RenameTo = target;
            try
            {
                //get response but ignore it
                GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool FtpCreateDirectory(string dirpath)
        {
            //perform create
            var uri = this.Hostname + AdjustDir(dirpath);
            var ftp = GetRequest(uri);
            //Set request to MkDir
            ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                //get response but ignore it
                GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool FtpDeleteDirectory(string dirpath)
        {
            //perform remove
            var uri = this.Hostname + AdjustDir(dirpath);
            var ftp = GetRequest(uri);
            //Set request to RmDir
            ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
            try
            {
                //get response but ignore it
                GetStringResponse(ftp);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region "private supporting fns"
        //Get the basic FtpWebRequest object with the
        //common settings and security
        private FtpWebRequest GetRequest(string uri)
        {
            //create request
            var result = (FtpWebRequest)WebRequest.Create(uri);
            //Set the login details
            result.Credentials = GetCredentials();
            //Do not keep alive (stateless mode)
            result.KeepAlive = false;
            return result;
        }


        /// <summary>
        /// Get the credentials from username/password
        /// </summary>
        private ICredentials GetCredentials()
        {
            return new NetworkCredential(Username, Password);
        }

        /// <summary>
        /// returns a full path using CurrentDirectory for a relative file reference
        /// </summary>
        private string GetFullPath(string file)
        {
            if (file.Contains("/"))
            {
                return AdjustDir(file);
            }
            
            return this.CurrentDirectory + file;
        }

        /// <summary>
        /// Amend an FTP path so that it always starts with /
        /// </summary>
        /// <param name="path">Path to adjust</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string AdjustDir(string path)
        {
            return ((path.StartsWith("/")) ? "" : "/") + path;
        }

        private string GetDirectory(string directory)
        {
            string uri;
            if (directory == "")
            {
                //build from current
                uri = Hostname + this.CurrentDirectory;
                _lastDirectory = this.CurrentDirectory;
            }
            else
            {
                if (!directory.StartsWith("/"))
                {
                    throw (new ApplicationException("Directory should start with /"));
                }
                uri = this.Hostname + directory;
                _lastDirectory = directory;
            }
            return uri;
        }

        //stores last retrieved/set directory
        private string _lastDirectory = "";

        /// <summary>
        /// Obtains a response stream as a string
        /// </summary>
        /// <param name="ftp">current FTP request</param>
        /// <returns>String containing response</returns>
        /// <remarks>FTP servers typically return strings with CR and
        /// not CRLF. Use respons.Replace(vbCR, vbCRLF) to convert
        /// to an MSDOS string</remarks>
        private static string GetStringResponse(FtpWebRequest ftp)
        {
            //Get the result, streaming to a string
            string result;
            using (var response = (FtpWebResponse)ftp.GetResponse())
            {
                using (var datastream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(datastream))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    datastream.Close();
                }

                response.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets the size of an FTP request
        /// </summary>
        /// <param name="ftp"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static long GetSize(FtpWebRequest ftp)
        {
            long size;
            using (var response = (FtpWebResponse)ftp.GetResponse())
            {
                size = response.ContentLength;
                response.Close();
            }

            return size;
        }
        #endregion

        #region "Properties"
        private string _hostname;
        /// <summary>
        /// Hostname
        /// </summary>
        /// <value></value>
        /// <remarks>Hostname can be in either the full URL format
        /// ftp://ftp.myhost.com or just ftp.myhost.com
        /// </remarks>
        public string Hostname
        {
            get
            {
                if (_hostname.StartsWith("ftp://"))
                {
                    return _hostname;
                }
                
                return "ftp://" + _hostname;
            }
            set
            {
                _hostname = value;
            }
        }
        private string _username;
        /// <summary>
        /// Username property
        /// </summary>
        /// <value></value>
        /// <remarks>Can be left blank, in which case 'anonymous' is returned</remarks>
        public string Username
        {
            get
            {
                return (_username == "" ? "anonymous" : _username);
            }
            set
            {
                _username = value;
            }
        }

        public string Password { get; set; }

        /// <summary>
        /// The CurrentDirectory value
        /// </summary>
        /// <remarks>Defaults to the root '/'</remarks>
        private string _currentDirectory = "/";
        public string CurrentDirectory
        {
            get
            {
                //return directory, ensure it ends with /
                return _currentDirectory + ((_currentDirectory.EndsWith("/")) ? "" : "/");
            }
            set
            {
                if (!value.StartsWith("/"))
                {
                    throw (new ApplicationException("Directory should start with /"));
                }
                _currentDirectory = value;
            }
        }


        #endregion
    }
    
    #endregion
	
	#region "FTP file info class"
	/// <summary>
	/// Represents a file or directory entry from an FTP listing
	/// </summary>
	/// <remarks>
	/// This class is used to parse the results from a detailed
	/// directory list from FTP. It supports most formats of
	/// </remarks>
	public class FtPfileInfo
	{
		
		//Stores extended info about FTP file
		
		#region "Properties"
		public string FullName
		{
			get
			{
				return Path + Filename;
			}
		}
		public string Filename
		{
			get
			{
				return _filename;
			}
		}
		public string Path
		{
			get
			{
				return _path;
			}
		}
		public DirectoryEntryTypes FileType
		{
			get
			{
				return _fileType;
			}
		}
		public long Size
		{
			get
			{
				return _size;
			}
		}
		public DateTime FileDateTime
		{
			get
			{
				return _fileDateTime;
			}
		}
		public string Permission
		{
			get
			{
				return _permission;
			}
		}
		public string Extension
		{
			get
			{
				var i = this.Filename.LastIndexOf(".");
				if (i >= 0 && i <(this.Filename.Length - 1))
				{
					return this.Filename.Substring(i + 1);
				}
			    return string.Empty;
			}
		}
		public string NameOnly
		{
			get
			{
				var i = this.Filename.LastIndexOf(".");
				return i > 0 ? this.Filename.Substring(0, i) : this.Filename;
			}
		}
		private readonly string _filename;
		private readonly string _path;
		private readonly DirectoryEntryTypes _fileType;
		private readonly long _size;
		private readonly DateTime _fileDateTime;
		private readonly string _permission;
		
		#endregion
		
		/// <summary>
		/// Identifies entry as either File or Directory
		/// </summary>
		public enum DirectoryEntryTypes
		{
			File,
			Directory
		}
		
		/// <summary>
		/// Constructor taking a directory listing line and path
		/// </summary>
		/// <param name="line">The line returned from the detailed directory list</param>
		/// <param name="path">Path of the directory</param>
		/// <remarks></remarks>
		public FtPfileInfo(string line, string path)
		{
			//parse line
			var m = GetMatchingRegex(line);
			if (m == null)
			{
				//failed
				throw (new ApplicationException("Unable to parse line: " + line));
			}
		    
            _filename = m.Groups["name"].Value;
		    _path = path;

		    Int64.TryParse(m.Groups["size"].Value, out _size);
		    //_size = System.Convert.ToInt32(m.Groups["size"].Value);

		    _permission = m.Groups["permission"].Value;
		    var dir = m.Groups["dir"].Value;
		    if (dir != "" && dir != "-")
		    {
		        _fileType = DirectoryEntryTypes.Directory;
		    }
		    else
		    {
		        _fileType = DirectoryEntryTypes.File;
		    }
				
		    try
		    {
		        _fileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
		    }
		    catch (Exception)
		    {
		        _fileDateTime = Convert.ToDateTime(null);
		    }
		}
		
		private static Match GetMatchingRegex(string line)
		{
			Regex rx;
			Match m;
			for (var i = 0; i <= ParseFormats.Length - 1; i++)
			{
				rx = new Regex(ParseFormats[i]);
				m = rx.Match(line);
				if (m.Success)
				{
					return m;
				}
			}
			return null;
		}
		
		#region "Regular expressions for parsing LIST results"
		/// <summary>
		/// List of REGEX formats for different FTP server listing formats
		/// </summary>
		/// <remarks>
		/// The first three are various UNIX/LINUX formats, fourth is for MS FTP
		/// in detailed mode and the last for MS FTP in 'DOS' mode.
		/// I wish VB.NET had support for Const arrays like C# but there you go
		/// </remarks>
		private static readonly string[] ParseFormats = new[] { 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{4})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\d+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})\\s+\\d+\\s+\\w+\\s+\\w+\\s+(?<size>\\d+)\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{1,2}:\\d{2})\\s+(?<name>.+)", 
            "(?<dir>[\\-d])(?<permission>([\\-r][\\-w][\\-xs]){3})(\\s+)(?<size>(\\d+))(\\s+)(?<ctbit>(\\w+\\s\\w+))(\\s+)(?<size2>(\\d+))\\s+(?<timestamp>\\w+\\s+\\d+\\s+\\d{2}:\\d{2})\\s+(?<name>.+)", 
            "(?<timestamp>\\d{2}\\-\\d{2}\\-\\d{2}\\s+\\d{2}:\\d{2}[Aa|Pp][mM])\\s+(?<dir>\\<\\w+\\>){0,1}(?<size>\\d+){0,1}\\s+(?<name>.+)" };
		#endregion
	}
	#endregion
	
	#region "FTP Directory class"
	/// <summary>
	/// Stores a list of files and directories from an FTP result
	/// </summary>
	/// <remarks></remarks>
	public class FtpDirectory : List<FtPfileInfo>
	{
		
		
		public FtpDirectory()
		{
			//creates a blank directory listing
		}
		
		/// <summary>
		/// Constructor: create list from a (detailed) directory string
		/// </summary>
		/// <param name="dir">directory listing string</param>
		/// <param name="path"></param>
		/// <remarks></remarks>
		public FtpDirectory(string dir, string path)
		{
			foreach (var line in dir.Replace("\n", "").Split(Convert.ToChar('\r')))
			{
				//parse
				if (line != "")
				{
					this.Add(new FtPfileInfo(line, path));
				}
			}
		}
		
		/// <summary>
		/// Filter out only files from directory listing
		/// </summary>
		/// <param name="ext">optional file extension filter</param>
		/// <returns>FTPdirectory listing</returns>
		public FtpDirectory GetFiles(string ext)
		{
			return this.GetFileOrDir(FtPfileInfo.DirectoryEntryTypes.File, ext);
		}
		
		/// <summary>
		/// Returns a list of only subdirectories
		/// </summary>
		/// <returns>FTPDirectory list</returns>
		/// <remarks></remarks>
		public FtpDirectory GetDirectories()
		{
			return this.GetFileOrDir(FtPfileInfo.DirectoryEntryTypes.Directory, "");
		}
		
		//internal: share use function for GetDirectories/Files
		private FtpDirectory GetFileOrDir(FtPfileInfo.DirectoryEntryTypes type, string ext)
		{
			var result = new FtpDirectory();
			foreach (var fi in this)
			{
				if (fi.FileType == type)
				{
					if (ext == "")
					{
						result.Add(fi);
					}
					else if (ext == fi.Extension)
					{
						result.Add(fi);
					}
				}
			}
			return result;
			
		}
		
		public bool FileExists(string filename)
		{
// ReSharper disable LoopCanBeConvertedToQuery
			foreach (var ftpfile in this)
// ReSharper restore LoopCanBeConvertedToQuery
			{
				if (ftpfile.Filename == filename)
				{
					return true;
				}
			}
			return false;
		}
		
		private const char Slash = '/';
		
		public static string GetParentDirectory(string dir)
		{
			var tmp = dir.TrimEnd(Slash);
			var i = tmp.LastIndexOf(Slash);
			if (i > 0)
			{
				return tmp.Substring(0, i - 1);
			}
		    
            throw (new ApplicationException("No parent for root"));
		}
	}
	#endregion

    #region FTPEventArgs

    public class FtpEventArgs
    {
        readonly long _totalBytes;

        public FtpEventArgs(long totalBytes)
        {
            _totalBytes = totalBytes;
        }

        public long TotalBytes
        {
            get { return _totalBytes; }
        }

        public bool Cancel { get; set; }
    }

    #endregion
}

