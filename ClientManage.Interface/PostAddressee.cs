using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ClientManage.Interfaces
{
    public class PostAddressee
    {
        public PostAddressee()
        {
            Enable = true;
        }

        public PostAddressee(DataRow row) : this()
        {
            FirstName = Utils.GetDBValue<string>(row, "first_name");
            LastName = Utils.GetDBValue<string>(row, "last_name");
            EntityId = Utils.GetDBValue<int>(row, "id");
            EntityType = Utils.GetDBValue<int>(row, "type");
            CellPhone = Utils.GetDBValue<string>(row, "cell_phone");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string _cellPhone = string.Empty;
        public string CellPhone 
        {
            get
            {
                return _cellPhone;
            }
            set
            {
                _cellPhone = Utils.DistilPhone(value);
            }
        }
        public int EntityType { get; set; }
        public int EntityId { get; set; }
        public string FullName
        {
            get
            {
                var fullname = FirstName + " " + LastName;
                return fullname.Trim();
            }
        }
        public bool Enable { get; set; }
    }
}
