using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class Subscriber
    {
        public enum SubscribeType { Period = 1, Quantity = 2, QuantityAndPeriod };
        public enum SubscribeStatus { Active = 1, Future = 2, History = 3, Frozen = 4 };

        private bool _hasChanges = false;
        public bool HasChanges
        {
            get { return _hasChanges; }
        }
        public void ResetChanges()
        {
            _hasChanges = false;
        }
        public void SetHasChanges()
        {
            _hasChanges = true;
        }

        public Subscriber()
        {
            _dateCreate = DateTime.Now;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set 
            {
                if (_id != value)
                {
                    _id = value; 
                    _hasChanges = true;
                }
            }
        }
        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set 
            {
                if (_clientId != value)
                {
                    _clientId = value; 
                    _hasChanges = true;
                }
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    _hasChanges = true;
                }
            }
        }
        private SubscribeType _type;
        public SubscribeType Type
        {
            get { return _type; }
            set 
            {
                if (_type != value)
                {
                    _type = value;
                    _hasChanges = true;
                }
            }
        }
        private string _cares;
        public string Cares
        {
            get { return _cares; }
            set 
            {
                if (_cares != value)
                {
                    _cares = value;
                    _hasChanges = true;
                }
            }
        }
        private SubscribeStatus _status;
        public SubscribeStatus Status
        {
            get { return _status; }
            set 
            {
                if (_status != value)
                {
                    _status = value;
                    _hasChanges = true;
                }
            }
        }
        private string _statusTitle;
        public string StatusTitle
        {
            get { return _statusTitle; }
            set 
            {
                if (_statusTitle != value)
                {
                    _statusTitle = value;
                    _hasChanges = true;
                }
            }
        }
        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set 
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    _hasChanges = true;
                }
            }
        }
        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get { return _toDate; }
            set 
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    _hasChanges = true;
                }
            }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set 
            {
                if (_amount != value)
                {
                    _amount = value;
                    _hasChanges = true;
                }
            }
        }
        private decimal _discount;
        public decimal Discount
        {
            get { return _discount; }
            set 
            {
                if (_discount != value)
                {
                    _discount = value;
                    _hasChanges = true;
                }
            }
        }
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    _hasChanges = true;
                }
            }
        }
        private DateTime _dateCreate = DateTime.Now;
        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set 
            {
                if (_dateCreate != value)
                {
                    _dateCreate = value;
                    _hasChanges = true;
                }
            }
        }
        private DateTime? _dateUpdate;
        public DateTime? DateUpdate
        {
            get { return _dateUpdate; }
            set
            {
                if (_dateUpdate != value)
                {
                    _dateUpdate = value;
                    _hasChanges = true;
                }
            }
        }
        private DateTime? _dateFrozen;
        public DateTime? DateFrozen
        {
            get { return _dateFrozen; }
            set
            {
                if (_dateFrozen != value)
                {
                    _dateFrozen = value;
                    _hasChanges = true;
                }
            }
        }

        public SubscribeStatus CalcStatus(int useCount)
        {
            SubscribeStatus status;
            if (_dateFrozen.HasValue)
            {
                status = SubscribeStatus.Frozen;
            }
            else
            {
                if (_fromDate > DateTime.Now.Date)
                {
                    status = SubscribeStatus.Future;
                }
                else
                {
                    if ((_toDate.HasValue && _toDate < DateTime.Now.Date) || (_amount > 0 && (_amount - useCount) <= 0))
                    {
                        status = SubscribeStatus.History;
                    }
                    else
                    {
                        status = SubscribeStatus.Active;
                    }
                }
            }

            return status;
        }

        public SubscribeType CalcType()
        {
            if (_amount > 0 && _toDate.HasValue) return SubscribeType.QuantityAndPeriod;
            else if (_amount < 0 && _toDate.HasValue) return SubscribeType.Period;
            else if (_amount > 0 && _toDate.HasValue == false) return SubscribeType.Quantity;
            else if (_amount < 0 && _toDate.HasValue == false) return SubscribeType.Period;
            else return SubscribeType.QuantityAndPeriod;
        }
    }
}
