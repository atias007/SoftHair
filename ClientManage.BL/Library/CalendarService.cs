using GmailSoftHairSync;

namespace ClientManage.BL.Library
{
    public class CalendarService
    {
        private static GmailService _gservice;
        private static readonly object Locker = new object();

        public static bool IsInitialized { get; private set; }

        public static GmailService Instance
        {
            get
            {
                lock (Locker)
                {
                    if (_gservice == null)
                    {
                        _gservice = new GmailService();
                        _gservice.GetClientName += _gservice_GetClientName;
                        _gservice.GetCaresDescription += _gservice_GetCaresDescription;
                        IsInitialized = true;
                    }

                    return _gservice;
                }
            }
        }

        private static void _gservice_GetCaresDescription(object sender, Interfaces.Calendar.CaresDescriptionRequestEventArgs e)
        {
            e.CaresDescription = CalendarHelper.GetCaresDescription(e.Cares);
        }

        private static void _gservice_GetClientName(object sender, Interfaces.Calendar.ClientNameRequestEventArgs e)
        {
            e.ClientName = ClientHelper.GetFullName(e.ClientId);
        }
    }
}