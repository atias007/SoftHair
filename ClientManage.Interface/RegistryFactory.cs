using System;
using Microsoft.Win32;

namespace ClientManage.Interfaces
{
    public class RegistryFactory
    {
        private static string _subKeyName = string.Empty;

        public static string SubKeyName
        {
            get { return _subKeyName; }
            set { _subKeyName = value; }
        }

        public static string Read(string keyName)
        {
            var result = string.Empty;

            try
            {
                // Opening the registry key
                var rk = Registry.LocalMachine;

                // Open a subKey as read-only
                var sk1 = rk.OpenSubKey(_subKeyName);

                // If the RegistrySubKey doesn't exist -> (null)
                if (sk1 != null)
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    result = Convert.ToString(sk1.GetValue(keyName.ToUpper()));
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        public static bool Write(string keyName, string value)
        {
            var result = true;
            try
            {
                var rk = Registry.LocalMachine;
                var sk1 = rk.CreateSubKey(_subKeyName);
                if (sk1 != null) sk1.SetValue(keyName.ToUpper(), value);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool DeleteKey(string KeyName)
        {
            var rk = Registry.LocalMachine;
            var sk1 = rk.CreateSubKey(_subKeyName);

            // If the RegistrySubKey doesn't exists -> (true)
            if (sk1 == null) return true;
            else sk1.DeleteValue(KeyName);
            return true;
        }

        public static bool DeleteSubKeyTree()
        {
            var rk = Registry.LocalMachine;
            var sk1 = rk.OpenSubKey(_subKeyName);
            // If the RegistryKey exists, I delete it
            if (sk1 != null)
                rk.DeleteSubKeyTree(_subKeyName);

            return true;
        }

        public int SubKeyCount()
        {
            // Setting
            var rk = Registry.LocalMachine;
            var sk1 = rk.OpenSubKey(_subKeyName);
            // If the RegistryKey exists...
            if (sk1 != null)
                return sk1.SubKeyCount;
            else
                return 0;
        }

        public int ValueCount()
        {
            // Setting
            var rk = Registry.LocalMachine;
            var sk1 = rk.OpenSubKey(_subKeyName);
            // If the RegistryKey exists...
            if (sk1 != null)
                return sk1.ValueCount;
            else
                return 0;
        }
    }
}
