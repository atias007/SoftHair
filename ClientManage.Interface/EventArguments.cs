using System;
using System.ComponentModel;
using System.Data;

namespace ClientManage.Interfaces
{
    public delegate void OpenFormEventHandler(object sender, OpenFormEventArgs e);

    public delegate void DlgShowClientCardEventHandler(object sender, ShowClientCardEventArgs e);

    public delegate void CreateNewClientEventHandler(object sender, NewClientEventArgs e);

    public delegate void ContactUpdateEventHandler(object sender, ContactUpdateEventArgs e);

    public delegate void RemainderEventHandler(object sender, RemainderEventArgs e);

    public delegate void CalendarEventHandler(object sender, CalendarEventArgs e);

    public delegate void CalendarSetAppointmentEventHandler(object sender, SetAppointmentEventArgs e);

    public delegate void WorkerUpdateEventHandler(object sender, WorkerUpdateEventArgs e);

    public delegate void ClientOperationEventHandler(object sender, ClientOperationEventArgs e);

    public delegate void ModemEventHandler(object sender, ModemEventArgs e);

    public delegate void DialRequestEventHandler(object sender, DialRequestEventArgs e);

    public delegate void OnlineBackupEventHandler(object sender, OnlineBackupEventArgs e);

    public class ShowClientCardEventArgs : EventArgs
    {
        private readonly int _userId;
        private readonly bool _isPopup;
        private bool _enableCalendar = true;
        private bool _enableNavigate = true;
        private int _currentIndex = -1;

        public ShowClientCardEventArgs(int userId)
            : this(userId, false)
        {
        }

        public ShowClientCardEventArgs(int userId, bool isPopup)
        {
            _userId = userId;
            _isPopup = isPopup;
        }

        public int UserId
        {
            get { return _userId; }
        }

        public bool IsPopup
        {
            get { return _isPopup; }
        }

        public bool EnableCalendar
        {
            get { return _enableCalendar; }
            set { _enableCalendar = value; }
        }

        public DataTable DataSource { get; set; }

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        public bool EnableNavigate
        {
            get { return _enableNavigate; }
            set { _enableNavigate = value; }
        }
    }

    public class OpenFormEventArgs : EventArgs
    {
        private readonly string _formName = string.Empty;
        private readonly DataTable _dataSource;
        private readonly object _param;

        public OpenFormEventArgs(string formName)
        {
            _formName = formName;
        }

        public OpenFormEventArgs(string formName, object param)
        {
            _param = param;
            _formName = formName;
        }

        public OpenFormEventArgs(string formName, int id)
        {
            _formName = formName;
            Id = id;
        }

        public OpenFormEventArgs(string formName, int id, object param)
        {
            _formName = formName;
            Id = id;
            _param = param;
        }

        public OpenFormEventArgs(string formName, DataTable dataSource)
        {
            _formName = formName;
            _dataSource = dataSource;
        }

        public string FormName
        {
            get { return _formName; }
        }

        public int Id { get; set; }

        public object Param
        {
            get { return _param; }
        }

        public bool ReturnToReportForm { get; set; }

        public object DataSource
        {
            get { return _dataSource; }
        }

        public int ReturnStatus { get; set; }
    }

    public class ContactUpdateEventArgs : EventArgs
    {
        public enum ContactState { NewContact, UpdatedContact, DeleteContact }

        private readonly PhoneBookContact _contact;
        private readonly ContactState _state = ContactState.UpdatedContact;

        public ContactUpdateEventArgs(PhoneBookContact contact, ContactState state)
        {
            _contact = contact;
            _state = state;
        }

        public PhoneBookContact Contact
        {
            get { return _contact; }
        }

        public ContactState State
        {
            get { return _state; }
        }
    }

    public class RemainderEventArgs : EventArgs
    {
        private readonly string _id;

        public RemainderEventArgs(string id)
        {
            _id = id;
        }

        public string Id
        {
            get { return _id; }
        }
    }

    public class CalendarEventArgs : EventArgs
    {
        private readonly string _appointmentId;
        private readonly int _clientId;

        public CalendarEventArgs(string appointmentId, int clientId)
        {
            _appointmentId = appointmentId;
            _clientId = clientId;
        }

        public string AppointmentId
        {
            get { return _appointmentId; }
        }

        public int ClientId
        {
            get { return _clientId; }
        }
    }

    public class SetAppointmentEventArgs : EventArgs
    {
        private SetAppointmentEventArgs()
        {
            _dateCreated = DateTime.Now;
        }

        public SetAppointmentEventArgs(int clientId)
            : this()
        {
            this.ClientId = clientId;
        }

        public new static SetAppointmentEventArgs Empty
        {
            get { return new SetAppointmentEventArgs(); }
        }

        public int ClientId { get; private set; }

        public string PhoneNumber { get; set; }

        private readonly DateTime _dateCreated;

        public DateTime DateCreated
        {
            get { return _dateCreated; }
        }
    }

    public class WorkerUpdateEventArgs : EventArgs
    {
        public enum WorkerState { NewWorker, UpdatedWorker, DeleteWorker }

        private readonly Worker _worker;
        private readonly WorkerState _state = WorkerState.UpdatedWorker;

        public WorkerUpdateEventArgs(Worker worker, WorkerState state)
        {
            _worker = worker;
            _state = state;
        }

        public Worker Worker
        {
            get { return _worker; }
        }

        public WorkerState State
        {
            get { return _state; }
        }
    }

    public class NewClientEventArgs : EventArgs
    {
        private string _phoneNumber = string.Empty;

        public NewClientEventArgs(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
    }

    public class ClientOperationEventArgs : EventArgs
    {
        private readonly string _operation = string.Empty;
        private readonly int _clientId;

        public ClientOperationEventArgs(string operation, int clientId)
        {
            _operation = operation;
            _clientId = clientId;
        }

        public string Operation
        {
            get { return _operation; }
        }

        public int ClientId
        {
            get { return _clientId; }
        }

        public bool Cancel { get; set; }
    }

    public class ModemEventArgs : EventArgs
    {
        private readonly string _outputCommand = string.Empty;

        public ModemEventArgs(string outputCommand)
        {
            _outputCommand = outputCommand;
        }

        public string OutputCommand
        {
            get { return _outputCommand; }
        }
    }

    public class DialRequestEventArgs : EventArgs
    {
        private readonly string _phoneNo = string.Empty;
        private readonly string _name = string.Empty;
        private readonly int _id;

        public DialRequestEventArgs(string phoneNo, string name, int id)
        {
            _phoneNo = phoneNo;
            _name = name;
            _id = id;
        }

        public string PhoneNo
        {
            get { return _phoneNo; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Id
        {
            get { return _id; }
        }

        public int Entity { get; set; }
    }

    public class OnlineBackupEventArgs : EventArgs
    {
        private readonly bool _isSuccess;

        public OnlineBackupEventArgs(bool isSuccess)
        {
            _isSuccess = isSuccess;
        }

        public bool IsSuccess
        {
            get { return _isSuccess; }
        }
    }

    public class ShowReportEventArgs : EventArgs
    {
        private readonly int _reportId;
        private readonly string _group = string.Empty;
        private readonly object[] _paramaters;

        public ShowReportEventArgs(string group, int reportId, object[] parameters)
        {
            _group = group;
            _reportId = reportId;
            _paramaters = parameters;
        }

        public int ReportId
        {
            get { return _reportId; }
        }

        public string Group
        {
            get { return _group; }
        }

        public object[] Paramaters
        {
            get { return _paramaters; }
        }
    }

    public class ContactSelectedMoveEventArgs : EventArgs
    {
        public enum DirectionType { Up, Down, Left, Right };

        private readonly DirectionType _direction = DirectionType.Left;

        public ContactSelectedMoveEventArgs(DirectionType direction)
        {
            _direction = direction;
        }

        public DirectionType Direction
        {
            get { return _direction; }
        }
    }

    public class PhotoAlbumEventArgs : EventArgs
    {
        private readonly ClientPhoto _photo;

        public PhotoAlbumEventArgs(ClientPhoto photo)
        {
            _photo = photo;
        }

        public ClientPhoto Photo
        {
            get { return _photo; }
        }
    }

    public class PhotoListChangedEventArgs : EventArgs
    {
        private readonly ClientPhoto _photo;
        private readonly ListChangedType _listChangeType;

        public PhotoListChangedEventArgs(ListChangedType listChangeType, ClientPhoto photo)
        {
            _listChangeType = listChangeType;
            _photo = photo;
        }

        public ListChangedType ListChangeType
        {
            get { return _listChangeType; }
        }

        public ClientPhoto Photo
        {
            get { return _photo; }
        }
    }
}