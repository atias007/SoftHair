using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;

namespace ClientManage.Library
{
    public static class FileReader
    {
        /// <summary>
        /// Finds the MIME from data.
        /// </summary>
        /// <param name="pBC">The p BC.</param>
        /// <param name="pwzUrl">The PWZ URL.</param>
        /// <param name="pBuffer">The p buffer.</param>
        /// <param name="cbSize">Size of the cb.</param>
        /// <param name="pwzMimeProposed">The PWZ MIME proposed.</param>
        /// <param name="dwMimeFlags">The dw MIME flags.</param>
        /// <param name="ppwzMimeOut">The PPWZ MIME out.</param>
        /// <param name="dwReserverd">The dw reserverd.</param>
        /// <returns></returns>
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static UInt32 FindMimeFromData(
            UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] String pwzMimeProposed,
            UInt32 dwMimeFlags,
            out UInt32 ppwzMimeOut,
            UInt32 dwReserverd
        );

        /// <summary>
        /// Gets the MIME from file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        private static ContentType GetMimeFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename + " not found");

            var buffer = new byte[256];
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                if (fs.Length >= 256)
                    fs.Read(buffer, 0, 256);
                else
                    fs.Read(buffer, 0, (int)fs.Length);
            }
            try
            {
                UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                var mimeTypePtr = new IntPtr(mimetype);
                var mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
                return new ContentType(mime);
            }
            catch (Exception)
            {
                return new ContentType("unknown/unknown");
            }
        }

        /// <summary>
        /// Gets the attachment.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static Attachment GetAttachment(string filename)
        {
            var file = new FileInfo(filename);

            try
            {
                var result = new Attachment(filename);
                result.Name = file.Name;
                result.ContentType = GetMimeFromFile(file.FullName);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading file: " + file.FullName, ex);
            }
        }
    }

    public class AttachmentComboItem
    {
        public Attachment Attachment { get; set; }

        public override string ToString()
        {
            return Attachment.Name;
        }
    }
}