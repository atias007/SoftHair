using System;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class UpdateEventArgs : EventArgs
    {
        public LogEntry Log { get; private set; }

        public UpdateEventArgs(LogEntry log)
        {
            Log = log;
        }
    }
}
