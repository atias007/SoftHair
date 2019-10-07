using System;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class ActionBase
    {
        public event EventHandler<UpdateEventArgs> LogCreated;

        /// <summary>
        /// Called when [log created].
        /// </summary>
        /// <param name="log">The log.</param>
        public void OnLogCreated(LogEntry log)
        {
            if (LogCreated != null)
            {
                LogCreated(this, new UpdateEventArgs(log));
            }
        }
    }
}
