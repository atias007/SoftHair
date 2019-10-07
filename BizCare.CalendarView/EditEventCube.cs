using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BizCare.Calendar.Library;

namespace BizCare.Calendar
{
    internal partial class EditEventCube : UserControl
    {
        internal enum CubeMode { New, Edit };

        private readonly Color colorCursorColor = Color.FromArgb(238, 147, 17);
        internal event EventDefinition.EditCubeDoneHandler EditCubeDone;
        private bool _ignoreLeaveEvent = false;
        private DateTime[] _scope = null;
        private readonly int _ownerId = 0;
        private CubeMode _mode = CubeMode.New;
        private EventCube _sourceCube = null;
        private bool _isAllDayEventCube = false;
        private string _eventText = string.Empty;

        internal EditEventCube(int ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
        }

        private void EditEventCube_Enter(object sender, EventArgs e)
        {
            txtCaption.Select();
            txtCaption.SelectionStart = txtCaption.Text.Trim().Length;
        }

        internal bool IsAllDayEventCube
        {
            get { return _isAllDayEventCube; }
            set
            {
                _isAllDayEventCube = value;
                this.Padding = _isAllDayEventCube ? new Padding(4) : new Padding(6);
            }
        }

        internal string EventText
        {
            get
            {
                return txtCaption.Text.Trim();
            }
            set
            {
                txtCaption.Text = value;
                _eventText = value;
            }
        }

        internal CubeMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        internal DateTime[] Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }

        internal EventCube SourceCube
        {
            get { return _sourceCube; }
            set { _sourceCube = value; }
        }

        internal void FocusTextBox()
        {
            txtCaption.Select();
        }

        private void EditEventCube_Paint(object sender, PaintEventArgs e)
        {
            var p = new Pen(colorCursorColor);
            Rectangle rec;

            if (_isAllDayEventCube)
            {
                p.Width = 2;
                rec = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            }
            else
            {
                p.Width = 4;
                rec = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
            }
            e.Graphics.DrawRectangle(p, rec);
        }

        private void txtCaption_KeyDown(object sender, KeyEventArgs e)        
        {
            var keyCode = e.KeyCode;
            var cancel = false;
            if (keyCode == Keys.Enter)
            {
                if (_sourceCube != null)
                {
                    if (_sourceCube.Appointment.ClientId == 0 && string.IsNullOrEmpty(_sourceCube.Appointment.Cares) && txtCaption.Text.Trim().Length == 0) cancel = true;
                }
                else
                {
                    cancel = txtCaption.Text.Trim().Length == 0;
                }
                if (cancel)
                {
                    keyCode = Keys.Escape;
                }
                else
                {
                    _ignoreLeaveEvent = true;
                    if (EditCubeDone != null)
                        EditCubeDone(this, new EditCubeDoneEventArgs(txtCaption.Text.Trim(), _scope, _ownerId, _isAllDayEventCube));
                }
            }
            if (keyCode == Keys.Escape)
            {
                _ignoreLeaveEvent = true;
                if (EditCubeDone != null)
                    EditCubeDone(this, new EditCubeDoneEventArgs(_isAllDayEventCube));
            }
        }

        private void txtCaption_Leave(object sender, EventArgs e)
        {
            if (_ignoreLeaveEvent) return;

            var cancel = false;
            if (EditCubeDone != null)
            {
                EditCubeDoneEventArgs arg;
                if (_sourceCube != null)
                {
                    if (_sourceCube.Appointment.ClientId == 0 && string.IsNullOrEmpty(_sourceCube.Appointment.Cares) && txtCaption.Text.Trim().Length == 0) cancel = true;
                }
                else
                {
                    cancel = txtCaption.Text.Trim().Length == 0;
                }
                if (cancel)
                {
                    arg = new EditCubeDoneEventArgs(_isAllDayEventCube);
                }
                else
                {
                    arg = new EditCubeDoneEventArgs(txtCaption.Text.Trim(), _scope, _ownerId, _isAllDayEventCube);
                }
                arg.IsLostFocus = true;
                EditCubeDone(this, arg);
            }
        }

        internal void AcceptChanges()
        {
            txtCaption_Leave(null, null);
        }
    }
}
