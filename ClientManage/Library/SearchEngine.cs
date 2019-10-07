using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ClientManage.BL;
using ClientManage.Interfaces;
using System.Collections;
using System.Windows.Forms;

namespace ClientManage.Library
{
    public class SearchEngine
    {
        public SearchEngine() { }
        public SearchEngine(SearchType type)
        {
            _type = type;
        }

        public enum SearchType { QuickSearch, FullSearch };
        
        private SearchType _type = SearchType.QuickSearch;
        public SearchType TypeOfSearch
        {
            get { return _type; }
            set { _type = value; }
        }
        
        public SearchItemCollection FilterClientTable(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return GetAllItems();
            else pattern = pattern.Replace("'", "''");

            var col = new SearchItemCollection();
            var sortItems = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("CLIENT_FILTER_BY"));
            var likeString = string.Empty;
            DataRow[] rows;
            var ClientsTable = ClientHelper.CachedClientsTable;

            foreach (var item in sortItems)
            {
                likeString = item + " LIKE '";
                if (item == "ClientPhones") likeString += "%" + Utils.DistilPhone(pattern);
                else likeString += pattern;
                likeString += "%'";
                if (item == "ClientName")
                {
                    likeString += " OR LastName + ' ' + FirstName LIKE '" + pattern + "%'";
                }

                try
                {
                    rows = ClientsTable.Select(likeString, "ClientName");
                }
                catch { rows = new DataRow[0]; }
                foreach (var row in rows)
                {
                    if (!col.IsItemExist((int)row["id"])) col.Add(CreateSearchItem(row));
                }
            }

            return col;
        }

        public SearchItemCollection GetLastCallClients()
        {
            var ClientsTable = ClientHelper.GetLastCalledClients().Tables[0];
            var col = new SearchItemCollection();
            for (var i = 0; i < ClientsTable.Rows.Count; i++)
            {
                col.Add(CreateSearchItem(ClientsTable.Rows[i]));
            }
            return col;
        }

        public SearchItemCollection GetWorkersForPick()
        {
            var workersTable = WorkersHelper.GetWorkersForPick();
            var col = new SearchItemCollection();
            for (var i = 0; i < workersTable.Rows.Count; i++)
            {
                col.Add(CreateSearchItem(workersTable.Rows[i]));
            }
            return col;
        }

        private SearchItem CreateSearchItem(DataRow row)
        {
            var item = new SearchItem();
            item.Id = Utils.GetDBValue<int>(row ,"id");
            item.Picture = Utils.GetDBValue<string>(row, "picture");
            item.FullName = Utils.GetDBValue<string>(row, "ClientName");

            if (_type == SearchType.FullSearch)
            {
                item.AllPhones = Utils.GetDBValue<string>(row, "Phone");
                item.Address = Utils.GetDBValue<string>(row, "client_address");
                item.DateCreated = Utils.GetDBValue<DateTime>(row, "create_date");
            }        

            return item;
        }

        private SearchItemCollection GetAllItems()
        {
            var rows = ClientHelper.CachedClientsTable.Select(string.Empty, "ClientName");
            var col = new SearchItemCollection();
            for (var i = 0; i < rows.Length; i++)
            {
                col.Add(CreateSearchItem(rows[i]));
            }
            return col;
        }
    }

    public class SearchItemComparer : IComparer
    {
        #region IComparer Members

        private readonly int _sortModifier = 0;
        private readonly string _field = string.Empty;

        public SearchItemComparer(string field, SortOrder sortOrder)
        {
            _field = field;
            _sortModifier = sortOrder == SortOrder.Ascending ? 1 : -1;
        }

        public int Compare(object x, object y)
        {
            var itemX = (SearchItem)x;
            var itemY = (SearchItem)y;
            int result;

            switch (_field)
            {
                case "Id":
                    if (itemX.Id > itemY.Id) result = 1;
                    else if (itemX.Id < itemY.Id) result = -1;
                    else result = 0;
                    break;

                case "Picture":
                    result = string.Compare(itemX.Picture, itemY.Picture);
                    break;

                case "FullName":
                    result = string.Compare(itemX.FullName, itemY.FullName);
                    break;

                case "Address":
                    result = string.Compare(itemX.Address, itemY.Address);
                    break;

                case "DateCreated":
                    result = DateTime.Compare(itemX.DateCreated, itemY.DateCreated);
                    break;

                default:
                    result = 0;
                    break;
            }

            return result * _sortModifier;
        }

        #endregion
    }

    public class SearchItem
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        public string FullName { get; set; }

        public string AllPhones { get; set; }

        public string Address { get; set; }

        public DateTime DateCreated { get; set; }
    }

    public class SearchItemCollection : CollectionBase
    {
        public SearchItem this[int index]
        {
            get { return (SearchItem)List[index]; }
            set { List[index] = value; }
        }

        public void Add(SearchItem item)
        {
            List.Add(item);
        }

        public bool IsItemExist(int id)
        {
            for (var i = 0; i < List.Count; i++)
            {
                if (((SearchItem)List[i]).Id == id) return true;
            }
            return false;
        }
    }
}
