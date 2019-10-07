using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClientManage.Interfaces
{
    public class ClientPhoto
    {
        private int _id = 0;
        private int _clientId;
        private string _picture = string.Empty;
        private string _remark = string.Empty;
        private string _subject = string.Empty;
        private DateTime _dateCreated;
        private bool _hasChanges = false;
        internal bool _suspendEvents = false;
        private ClientPhotoCollection _parent = null;

        internal ClientPhotoCollection Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    SetChanges();
                }
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
        }

        public int ClientId
        {
            get { return _clientId; }
            set
            {
                if (_clientId != value)
                {
                    _clientId = value;
                    SetChanges();
                }
            }
        }

        public string Picture
        {
            get { return _picture; }
            set
            {
                if (_picture != value)
                {
                    _picture = value;
                    SetChanges();
                }
            }
        }

        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    SetChanges();
                }
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    SetChanges();
                }
            }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    SetChanges();
                }
            }
        }

        public string CalendarId { get; set; }

        private void SetChanges()
        {
            if (_parent != null) _parent.ClientPhotoChanged(this);
            _hasChanges = true;
        }

        public void AcceptChanges()
        {
            _hasChanges = false;
        }

        public string GetHtmlCode()
        {
            var html = "<tr><td style=\"width: 180px;\"><img src=\"" + _picture + "\" alt=\"\" width=\"160\" height=\"120\" /></td>" +
                "<td valign=\"top\"><table cellpadding=\"2\">" +
                "<tr><td style=\"width: 60px\"><strong>תאריך:</strong>&nbsp;</td><td>" + _dateCreated.ToString("dd/MM/yyyy בשעה HH:mm") + "</td></tr>" +
                "<tr><td style=\"width: 60px\"><strong>תיאור:</strong>&nbsp;</td><td>" + _subject + "</td></tr>" +
                "<tr><td style=\"width: 60px\" valign=\"top\"><strong>הערות:</strong>&nbsp;</td><td>" + _remark.Replace("\n", "<br />") + "</td></tr>" +
                "</table></td></tr><tr><td colspan=\"2\"><hr /></td></tr>";

            return html;
        }

        public void SuspendEvents()
        {
            _suspendEvents = true;
        }

        public void ReleaseEvents()
        {
            _suspendEvents = false;
        }

        public void OnPhotoChanged()
        {
            if (_parent != null)
            {
                _parent.ClientPhotoChanged(this);
            }
        }
    }
}