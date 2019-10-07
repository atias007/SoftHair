using System.Data;

namespace ClientManage.BL.Library
{
    public class ClientNavigator
    {
        private readonly DataTable _cachedClientsTable;

        public ClientNavigator()
        {
            _cachedClientsTable = ClientHelper.CachedClientsTable;
        }

        private DataTable _dataSource;
        public DataTable DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        private int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex > 0 ? _currentIndex : 0; }
            set { _currentIndex = value; }
        }


        //-------------------------------------------------------------------------------

        private int NextClientId
        {
            get
            {
                var id = 0;
                if (CurrentIndex < _dataSource.Rows.Count - 1)
                {
                    id = (int)_dataSource.Rows[CurrentIndex + 1]["id"];
                }
                return id;
            }
        }

        private int PrevClientId
        {
            get
            {
                var id = 0;
                if (CurrentIndex > 0 && CurrentIndex <= _dataSource.Rows.Count)
                {
                    id = (int)_dataSource.Rows[CurrentIndex - 1]["id"];
                }
                return id;
            }
        }
        public int CurrentClientId
        {
            get
            {
                int id;
                if (CurrentIndex > _cachedClientsTable.Rows.Count - 1) CurrentIndex = _cachedClientsTable.Rows.Count - 1;
                if (_dataSource == null)
                {
                    id = (int)_cachedClientsTable.Select(string.Empty, "ClientName")[CurrentIndex]["id"];
                }
                else
                {
                    id = (int)_dataSource.Rows[CurrentIndex]["id"];
                }
                return id;
            }
            set
            {
                CurrentIndex = GetClientIndex(value);
            }
        }

        private int GetClientIndex(int clientId)
        {
            var index = 0;
            var rows = _cachedClientsTable.Select(string.Empty, "ClientName");
            for (var i = 0; i < rows.Length; i++)
            {
                if (clientId.Equals((int)rows[i]["id"]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public int Key
        {
            get
            {
                var key = -1;
                if (_dataSource != null && CurrentIndex < _dataSource.Rows.Count)
                {
                    key = (int)_dataSource.Rows[CurrentIndex]["key"];
                }
                return key;
            }
        }

        public int[] GetNextAndPrevClientId()
        {
            var res = new int[2];

            if (_dataSource == null || _dataSource.Rows.Count == 0)
            {
                var rows = _cachedClientsTable.Select(string.Empty, "ClientName");
                var id = CurrentClientId;
                for (var i = 0; i < rows.Length; i++)
                {
                    if (id.Equals(rows[i]["id"]))
                    {
                        res[0] = i == 0 ? 0 : (int)rows[i - 1]["id"];
                        res[1] = i == rows.Length - 1 ? 0 : (int)rows[i + 1]["id"];
                        break;
                    }
                }
            }
            else
            {
                res[0] = PrevClientId;
                res[1] = NextClientId;
            }

            return res;
        }

        public void MoveNext()
        {
            _currentIndex++;
        }
        public void MovePrevious()
        {
            _currentIndex--;
        }

    }
}
