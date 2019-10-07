using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManage.Interfaces.Calendar
{
    public class ClientNameRequestEventArgs : EventArgs
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }
    }
}