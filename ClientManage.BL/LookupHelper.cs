using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Collections;
using System.Data;

namespace ClientManage.BL
{
    public class LookupHelper
    {
        private static readonly Hashtable Cache = new Hashtable();

        public static DataTable GetLookupTable(string tableName)
        {
            return GetLookupTable(tableName, null);
        }

        private static string GetTableCacheKey(string tableName, string orderBy)
        {
            var key = tableName;
            if (!string.IsNullOrEmpty(orderBy)) key += "_" + orderBy;
            return key;
        }

        public static DataTable GetLookupTable(string tableName, string orderBy)
        {
            var key = GetTableCacheKey(tableName, orderBy);

            if (Cache[key] == null)
            {
                var table = LookupData.GetLookupTable(tableName, orderBy).Tables[0];
                table.PrimaryKey = new[] { table.Columns["id"] };
                Cache.Add(key, table);
            }
            return (DataTable)Cache[key];
        }

        public static T GetLookupFieldValue<T>(DataTable lookupTable, int id, string fieldName)
        {
            var row = lookupTable.Rows.Find(id);
            if (row == null) throw new ArgumentException("id " + id + " not exist in lookup table");

            var value = Utils.GetDBValue<T>(row, fieldName);
            return value;
        }
    }
}