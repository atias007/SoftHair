using BizCare.Calendar.Library;

namespace BizCare.Calendar
{
    internal class CalendarClipboard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarClipboard"/> class.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <param name="action">The action.</param>
        public CalendarClipboard(Appointment appointment, ClipboardAction action)
        {
            this.Appointment = appointment;
            this.Action = action;
        }

        internal enum ClipboardAction { Copy, Cut }
        internal Appointment Appointment { get; private set; }
        internal ClipboardAction Action { get; private set; }
        internal EventCube Cube { get; set; }
        internal WorkerPanel Panel { get; set; }
    }
}
