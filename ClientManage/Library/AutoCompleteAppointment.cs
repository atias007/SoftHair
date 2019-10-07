using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ClientManage.BL;
using ClientManage.Interfaces;
using BizCare.Calendar.Library;

namespace ClientManage.Library
{
    public class AutoCompleteAppointment
    {
        readonly DataTable table = ClientHelper.CachedClientsTable;

        public void Detect(Appointment app)
        {
            var text = app.Text;
            //bool hasChanges = false;

            var id = GetClientId(app.Text);
            if (id > 0)
            {
                //hasChanges = true;
                app.ClientId = id;
            }
            
        }

        private int GetClientId(string name)
        {
            var id = 0;
            var strSearch = string.Empty;

            foreach (DataRow row in table.Rows)
            {
                strSearch = Utils.GetDBValue<string>(row, "FirstName") + " " + Utils.GetDBValue<string>(row, "LastName");
                if (name.IndexOf(strSearch) >= 0)
                {
                    if (id > 0) { id = 0; break; }
                    else
                    {
                        id = Utils.GetDBValue<int>(row["id"]);
                    }
                }
                strSearch = Utils.GetDBValue<string>(row, "LastName") + " " + Utils.GetDBValue<string>(row, "FirstName");
                if (name.IndexOf(strSearch) >= 0)
                {
                    if (id > 0) { id = 0; break; }
                    else
                    {
                        id = Utils.GetDBValue<int>(row["id"]);
                    }
                }
            }

            return id;
        }
    }
}
