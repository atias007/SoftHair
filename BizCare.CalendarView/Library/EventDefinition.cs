using System;
using System.Collections.Generic;
using System.Text;

namespace BizCare.Calendar.Library
{
    public class EventDefinition
    {
        internal delegate void EditCubeDoneHandler(object sender, EditCubeDoneEventArgs e);
        public delegate void GeneralCubeEventHandler(object sender, GeneralCubeEventArgs e);
    }

    internal class EditCubeDoneEventArgs : EventArgs
    {
        private readonly string _text = string.Empty;
        private readonly bool _isCancel = false;
        private readonly int _ownerId = 0;
        private readonly bool _isAllDayEvent = false;
        readonly DateTime[] _scope = null;

        internal EditCubeDoneEventArgs(bool isAllDayEvent)
        {
            _text = string.Empty;
            _isCancel = true;
            _isAllDayEvent = isAllDayEvent;
        }

        internal EditCubeDoneEventArgs(string text, DateTime[] scope, int ownerId, bool isAllDayEvent)
        {
            _text = text;
            _isCancel = false;
            _scope = scope;
            _ownerId = ownerId;
            _isAllDayEvent = isAllDayEvent;
        }

        internal bool IsAllDayEvent
        {
            get { return _isAllDayEvent; }
        }

        internal int OwnerId
        {
            get { return _ownerId; }
        }

        internal string Text
        {
            get
            {
                return _text;
            }
        }
        internal bool IsCancel
        {
            get
            {
                return _isCancel;
            }
        }
        internal DateTime[] Scope
        {
            get
            {
                return _scope;
            }
        }

        internal bool IsLostFocus { get; set; }
    }

    public class GeneralCubeEventArgs : EventArgs
    {
        public enum EditModeMember { None, Text, WorkerId, Time, Remainder, Category, UpdateForm };
        
        private readonly Appointment _app;
        private readonly EditModeMember _editMode = EditModeMember.None;

        public GeneralCubeEventArgs(Appointment appointment)
        {
            _app = appointment;
        }

        public GeneralCubeEventArgs(Appointment appointment, EditModeMember editMode)
        {
            _app = appointment;
            _editMode = editMode;
        }

        public Appointment Appointment
        {
            get { return _app; }
        }

        public EditModeMember EditMode
        {
            get { return _editMode; }
        }

    }

    public class DragOverCubeEventArgs : EventArgs
    {
        private readonly string _dragText = string.Empty;

        public DragOverCubeEventArgs(string dragText)
        {
            _dragText = dragText;
        }

        public string DragText
        {
            get { return _dragText; }
        }
    }
}