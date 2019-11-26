using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class LicenceHelper
    {
        // add license row to license tables
        public static bool AddLicense(string key)
        {
            return (LicenceData.AddLicense(key) == 1);
        }

    }
}