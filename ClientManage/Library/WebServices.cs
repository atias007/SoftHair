using System;
using ClientManage.BL;
using ClientManage.SmsFactoryCommon;

namespace ClientManage.Library
{
    public static class WebServices
    {
        public static string HostUrl
        {
            get { return AppSettingsHelper.GetParamValue("WEB_HOSTNAME"); }
        }

        // ------------------------------------------------------------------------------------------------------//

        private static CommonServicesClient _commonWs;

        public static CommonServicesClient CommonWs
        {
            get

            {
                if (_commonWs != null) return _commonWs;
                _commonWs = new CommonServicesClient("BasicHttpBinding_ICommonServices",AppSettingsHelper.GetParamValue("SMS_WS_COMMON_URL"));

#if DEBUG
                _commonWs = new CommonServicesClient("BasicHttpBinding_ICommonServices","http://localhost:61231/Services/CommonServices.svc");
#endif

                return _commonWs;
            }
        }



        public static CustomerLicense GetOnlineLicense()
        {
            CustomerLicense result;
            try
            {
                result = CommonWs.CheckCustomerLicense(General.UserCredentials, AppSettingsHelper.GetParamValue("SMS_UNIQUEID"));
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        // ------------------------------------------------------------------------------------------------------//

        public static string CommonWsUrl
        {
            get { return AppSettingsHelper.GetParamValue("SMS_WS_COMMON_URL"); }
        }

        // ------------------------------------------------------------------------------------------------------//

        public static string OnlineUpdateUrl
        {
            get { return AppSettingsHelper.GetParamValue("WEB_HOSTNAME") + "/WebServices/SoftHairOnlineUpdate.asmx"; }
        }

    }
}
