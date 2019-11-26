using ClientManage.Interfaces.Schemas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace ClientManage.Interfaces
{
    public class Utils
    {
        [DllImport("user32.dll")]
        private static extern int FlashWindow(IntPtr hwnd, bool revert);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32", EntryPoint = "GetClassLong")]
        private static extern int GetClassLongA(int hwnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetClassLong")]
        private static extern int SetClassLongA(int hwnd, int nIndex, int dwNewLong);

        [DllImport("user32", EntryPoint = "ShowWindow")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        [DllImport("user32", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hWnd, int wMsg, int wParam, int lParam);

        private const int GclStyle = -26;
        private const int CsDropshadow = 0x20000;
        private const int SwShownormal = 1;

        //private const int SW_SHOWMAXIMIZE = 3;
        //private const int SW_SHOWMINIMIZE = 6;
        private const int CbShowdropdown = 335;

        static Utils()
        {
        }

        //public const bool STRING_DEFAULT_EMPTY = true;
        public const string SmsParameterIdentifier = "{";

        public const string AddUsername = "{שם הלקוח}";
        public const string AddClientname = "{שם העסק}";
        public const int MaxAlldayEventsCount = 2;
        public const string DataFilename = "content.dat";
        public const int CalendarTakepicDuration = 120;
        public const int DefaultBdayYear = 1900;

        #region Data Convert

        public static T GetDBValue<T>(object value)
        {
            return GetDBValue(value, default(T));
        }

        public static T GetDBValue<T>(object value, T defaultValue)
        {
            //if (STRING_DEFAULT_EMPTY && defaultValue == null && typeof(T).Equals(typeof(string))) defaultValue = (T)Convert.ChangeType(string.Empty, typeof(T));
            var retValue = defaultValue;

            if (!DBNull.Value.Equals(value))
            {
                var type = typeof(T);
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) type = value.GetType();

                try { retValue = (T)Convert.ChangeType(value, type); }
                //catch (InvalidCastException ex) { throw ex; }
                catch { CatchException(); }
            }

            return retValue;
        }

        public static T GetDBValue<T>(DataRow row, string field)
        {
            var value = row[field];
            return GetDBValue(value, default(T));
        }

        public static T GetDBValue<T>(DataRow row, string field, T defaultValue)
        {
            var value = row[field];
            return GetDBValue(value, defaultValue);
        }

        #endregion Data Convert

        public static string StartupPath { get; set; }

        public static void OpenComboBox(IntPtr hWnd)
        {
            SendMessage(hWnd.ToInt32(), CbShowdropdown, 1, 0);
        }

        public static bool IsGoogleCalendar
        {
            get
            {
                return false;
            }
        }

        public static void AddFormDropShadow(IntPtr hWnd)
        {
            SetClassLongA(hWnd.ToInt32(), GclStyle, GetClassLongA(hWnd.ToInt32(), GclStyle) | CsDropshadow);
        }

        public static string GetDateTimeShortString(DateTime value)
        {
            var ret = value == DateTime.MinValue ? string.Empty : value.ToString("dd/MM/yyyy");

            return ret;
        }

        public static string GetDateTimeIdString()
        {
            return GetDateTimeIdString(false);
        }

        public static string GetDateTimeIdString(bool shortFormat)
        {
            var format = shortFormat ? "ddMMyyyyHHmm" : "ddMMyyyyHHmmfff";
            return DateTime.Now.ToString(format);
        }

        public static object GetDateTimeValueForDB(object value)
        {
            var dtValue = GetDBValue<DateTime>(value);
            return GetDateTimeValueForDB(dtValue);
        }

        public static object GetDateTimeValueForDB(DateTime value)
        {
            object ret;
            if (value.Equals(DateTime.MinValue)) ret = DBNull.Value;
            else ret = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);

            return ret;
        }

        public static DateTime? FixEntLibDateTime(DateTime? value)
        {
            DateTime? ret = null;
            if (value.HasValue)
            {
                var d = value.GetValueOrDefault();
                ret = new DateTime?(new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second));
            }
            return ret;
        }

        public static string DistilPhone(string phone)
        {
            return phone.Replace(" ", string.Empty).Replace("-", string.Empty);
        }

        // return the next free filename in pictures directory for creating new image file
        private static string GetImageFilename(bool isAlbum)
        {
            var cur = -1;
            string sTmp;
            var strDir = isAlbum ?
                System.Windows.Forms.Application.StartupPath + "\\AlbumImages" :
                System.Windows.Forms.Application.StartupPath + "\\ClientImages";

            var strBase = isAlbum ? "abim_{0}.jpg" : "usim_{0}.jpg";

            var files = Directory.GetFiles(strDir, String.Format(strBase, "*"));
            foreach (var t in files)
            {
                try
                {
                    sTmp = t.Substring(t.LastIndexOf("_") + 1);
                    sTmp = sTmp.Substring(0, sTmp.LastIndexOf("."));
                    var iTmp = Convert.ToInt32(sTmp);
                    if (iTmp > cur) cur = iTmp;
                }
                catch { CatchException(); }
            }
            cur++;

            //while (File.Exists(string.Format(strBase, cur.ToString())))
            //{
            //    cur++;
            //}

            return Path.Combine(strDir, string.Format(strBase, cur));
        }

        public static string SaveImageFile(Image image)
        {
            return SaveImageFile(image, false);
        }

        public static string SaveImageFile(Image image, bool isAlbum)
        {
            var filename = GetImageFilename(isAlbum);

            try
            {
                image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                var msg1 = "ארעה שגיאה בעת שמירת התמונה לקובץ.\n\nתיאור השגיאה:\n" + ex.Message;
                throw new Exception(msg1);
            }

            return filename;
        }

        public static Image GetThumbnailBigImage(Image image)
        {
            return ImageResizer.ResizeImage(image, 640, 480);
        }

        public static Image GetThumbnailImage(Image image)
        {
            return ImageResizer.ResizeImage(image, 340, 256);
        }

        public static void PlayWavFile(string filename)
        {
            var myPlayer = new System.Media.SoundPlayer("Media\\" + filename);
            try
            {
                myPlayer.Play();
            }
            catch { CatchException(); }
        }

        public enum FocusWindowState { Normal = 1, Maximized = 3, Minimized = 6 };

        public static void FocusWindow(IntPtr hwnd, bool flash)
        {
            ShowWindow(hwnd.ToInt32(), SwShownormal);
            SetForegroundWindow(hwnd);
            if (flash) FlashWindow(hwnd, false);
        }

        public static void FocusWindow(IntPtr hwnd, bool flash, FocusWindowState windowState)
        {
            ShowWindow(hwnd.ToInt32(), (int)windowState);
            SetForegroundWindow(hwnd);
            if (flash) FlashWindow(hwnd, false);
        }

        public static bool IsSuperUserPassword(string password, string template)
        {
            var rep = GetDigitsSum(DateTime.Now.Day).ToString();
            rep += GetDigitsSum(DateTime.Now.Month).ToString();
            rep += GetDigitsSum(DateTime.Now.Year).ToString();
            rep += GetDigitsSum(DateTime.Now.Hour).ToString();
            template = string.Format(template, rep);
            return password == template;
        }

        private static int GetDigitsSum(double value)
        {
            var total = value.ToString().Length;
            var sum = 0;

            for (var i = 0; i < total; i++)
            {
                sum += Convert.ToInt32(Math.Floor(value)) % 10;
                value /= 10;
            }
            if (sum >= 10) sum = GetDigitsSum(sum);
            return sum;
        }

        public static DateTime GetFirstDayOfWeekDate()
        {
            return GetFirstDayOfWeekDate(DateTime.Now.Date);
        }

        public static DateTime GetFirstDayOfWeekDate(DateTime someDate)
        {
            var info = System.Threading.Thread.CurrentThread.CurrentCulture;
            var firstDay = info.DateTimeFormat.FirstDayOfWeek;
            var someDay = someDate.DayOfWeek;

            var diff = someDay - firstDay;
            var fDate = someDate.Date.AddDays(-diff);
            return fDate;
        }

        public static string GetTempForderPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache), filename);
        }

        public static string GetDataSourceIds(DataTable table)
        {
            if (table == null) return "0";
            var ids = string.Empty;
            string cur;

            for (var i = 0; i < table.Rows.Count; i++)
            {
                cur = table.Rows[i]["id"].ToString();
                if (cur.Length > 0)
                {
                    ids += table.Rows[i]["id"] + ",";
                }
            }
            if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);
            return ids;
        }

        public static string GetDataSourceIds(DataTable table, string fieldName)
        {
            if (table == null) return "0";
            var ids = string.Empty;
            string cur;

            for (var i = 0; i < table.Rows.Count; i++)
            {
                cur = table.Rows[i][fieldName].ToString();
                if (cur.Length > 0)
                {
                    ids += table.Rows[i][fieldName] + ",";
                }
            }
            if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);
            return ids;
        }

        public static void SortArray(ref string[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }

        public static string GetIpAddress()
        {
            var ip = string.Empty;
            var strHost = Dns.GetHostName();
            var entry = Dns.GetHostEntry(strHost);
            var addr = entry.AddressList;

            if (addr.Length == 1)
            {
                ip = addr[0].ToString();
            }
            else if (addr.Length > 1)
            {
                ip = addr.Aggregate(ip, (current, a) => current + (a + " | "));
                ip = ip.Substring(0, ip.Length - 3);
            }
            return ip;
        }

        public static string GetFirstName(string fullname)
        {
            var first = fullname;
            var pos = fullname.IndexOf(" ");
            if (pos > 1) first = fullname.Substring(0, pos);

            return first;
        }

        public static int[] GetIntArray(string values)
        {
            if (values == null) return new int[] { };
            var s = values.Split(',');
            var ret = new int[s.Length];

            for (var i = 0; i < s.Length; i++)
            {
                try
                {
                    ret[i] = Convert.ToInt32(s[i]);
                }
                catch { CatchException(); }
            }

            return ret;
        }

        public static string[] GetStringArray(string values)
        {
            if (values == null) return new string[] { };
            var s = values.Split(',');
            return s;
        }

        public static bool[] GetBoolArray(string values)
        {
            if (values == null) return new bool[] { };
            var s = values.Split(',');
            var ret = new bool[s.Length];

            for (var i = 0; i < s.Length; i++)
            {
                try
                {
                    ret[i] = Convert.ToBoolean(s[i]);
                }
                catch { CatchException(); }
            }

            return ret;
        }

        public static string InnerSpaceTrim(string value)
        {
            while (value.Contains("  "))
            {
                value = value.Replace("  ", " ");
            }
            return value;
        }

        public static Image LightImage(Image image, int value)
        {
            var b = new Bitmap(image);
            for (var i = 0; i < b.Width; i++)
            {
                for (var j = 0; j < b.Height; j++)
                {
                    b.SetPixel(i, j, LightColor(b.GetPixel(i, j), value));
                }
            }

            return b;
        }

        private static Color LightColor(Color color, int value)
        {
            var g = color.G + value;
            var r = color.R + value;
            var b = color.B + value;

            if (g < 0) g = 0; else if (g > 255) g = 255;
            if (r < 0) r = 0; else if (r > 255) r = 255;
            if (b < 0) b = 0; else if (b > 255) b = 255;

            return Color.FromArgb(color.A, r, g, b);
        }

        public static string GetExceptionMessage(Exception ex)
        {
            var result = string.Empty;
            if (ex != null)
            {
                result = "Time Stamp:\r\n\t" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                    "\r\nMessage:\r\n\t" + ex.Message +
                    "\r\nStack Trace:\r\n\t" + ex.ToString() +
                    "\r\nTargetSite\r\n\t" + Convert.ToString(ex.TargetSite);
            }
            return result;
        }

        public static void CreateApplicationShortcut(string linkFilename, string appFilename)
        {
            using (var writer = new StreamWriter(linkFilename, false))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + appFilename);
                writer.WriteLine("IconIndex=0");
                var icon = appFilename.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
        }

        /// <summary>
        /// Catches the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void CatchException(Exception ex = null)
        {
            // Do Nothing //
        }
    }
}