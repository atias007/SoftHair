using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManage.Interfaces.Calendar
{
    public class CaresDescriptionRequestEventArgs : EventArgs
    {
        public string Cares { get; set; }

        public string CaresDescription { get; set; }
    }
}