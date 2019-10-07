using System;
using System.Data;
using ClientManage.Interfaces;

namespace ClientManage.SmsFactoryCommon
{
    public partial class ContactSyncDetails
    {
        public ContactSyncDetails(DataRow row)
        {
            BirthDate = Utils.GetDBValue<DateTime?>(row, "birth_date");
            Email = Utils.GetDBValue<string>(row, "email");
            FirstName = Utils.GetDBValue<string>(row, "first_name");
            Id = Utils.GetDBValue<int>(row, "id");
            LastName = Utils.GetDBValue<string>(row, "last_name");
            MarriedDate = Utils.GetDBValue<DateTime?>(row, "married_date");
            PhoneNo = Utils.GetDBValue<string>(row, "cell_phone_1");
            Remark = Utils.GetDBValue<string>(row, "remark");

            if (BirthDate.HasValue)
            {
                if (BirthDate.Value.Year < 1900) BirthDate = null;
            }

            if (MarriedDate.HasValue)
            {
                if (MarriedDate.Value.Year < 1900) MarriedDate = null;
            }
        }
    }
}
