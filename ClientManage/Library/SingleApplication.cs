using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;

namespace ClientManage.Library
{
	/// <summary>
	/// Summary description for SingleApp.
	/// </summary>
	public class SingleApplication
	{
        private static Mutex _mutex;
        private const int SwRestore = 9;

		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int IsIconic(IntPtr hWnd);

		/// <summary>
		/// GetCurrentInstanceWindowHandle
		/// </summary>
		/// <returns></returns>
		private static IntPtr GetCurrentInstanceWindowHandle()
		{    
			var hWnd = IntPtr.Zero;
			var process = Process.GetCurrentProcess();
			var processes = Process.GetProcessesByName(process.ProcessName);

            if (process.MainModule == null) return IntPtr.Zero;

			foreach(var proc in processes)
			{
                if (proc == null || proc.MainModule == null) continue;

				// Get the first instance that is not this instance, has the
				// same process name and was started from the same file name
				// and location. Also check that the process has a valid
				// window handle in this session to filter out other user's
				// processes.
				if (proc.Id != process.Id &&
					proc.MainModule.FileName == process.MainModule.FileName &&
					proc.MainWindowHandle != IntPtr.Zero)    
				{
					hWnd = proc.MainWindowHandle;
					break;
				}
			}
			return hWnd;
		}
		/// <summary>
		/// SwitchToCurrentInstance
		/// </summary>
		private static void SwitchToCurrentInstance()
		{    
			var hWnd = GetCurrentInstanceWindowHandle();
			if (hWnd != IntPtr.Zero)    
			{    
				// Restore window if minimised. Do not restore if already in
				// normal or maximised window state, since we don't want to
				// change the current state of the window.
				if (IsIconic(hWnd) != 0)
				{
					ShowWindow(hWnd, SwRestore);
				}

				// Set foreground window.
				SetForegroundWindow(hWnd);
			}
		}

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns>true if no previous instance is running</returns>
		public static bool Run(Form form)
		{
			if(IsAlreadyRunning())
			{
				//set focus on previously running app
				SwitchToCurrentInstance();
				return false;
			}
			Application.Run(form);
			return true;
		}

		/// <summary>
		/// for console base application
		/// </summary>
		/// <returns></returns>
		public static bool Run()
		{
			if(IsAlreadyRunning()) 
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// check if given exe already running or not
		/// </summary>
		/// <returns>returns true if already running</returns>
		private static bool IsAlreadyRunning()
		{
			var strLoc = Assembly.GetExecutingAssembly().Location;
            if (strLoc == null) return false;

			FileSystemInfo fileInfo = new FileInfo(strLoc);
			var sExeName = fileInfo.Name;
			bool bCreatedNew;

			_mutex = new Mutex(true, "Global\\"+sExeName, out bCreatedNew);
			if (bCreatedNew)
				_mutex.ReleaseMutex();

			return !bCreatedNew;
		}
	}
}
