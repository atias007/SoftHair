using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ClientManage.Forms;

namespace ClientManage.Library
{
    public class MyMessageBox
    {
        public MyMessageBox() { }

        public MyMessageBox(string message, string caption)
        {
            _caption = caption;
            _text = message;
        }

        public MyMessageBox(string message, string caption, MyMessageType type, MyMessageButton buttons)
        {
            _text = message;
            _caption = caption;
            _messageType = type;
            _messageButtons = buttons;
        }

        public MyMessageBox(string message, string caption, MyMessageType type, MyMessageButton buttons, MyMessageBox.MyMessageDefaultButton defaultButton)
        {
            _caption = caption;
            _text = message;
            _messageType = type;
            _messageButtons = buttons;
            _messageDefaultButton = defaultButton;
        }

        private FormMessage fMessage = null;

        public enum MyMessageType { Error, Confirm, Stop, Question, Information, Warning };
        public enum MyMessageButton { None, Ok, YesNo, YesNoCancel };
        public enum MyMessageDefaultButton { Button1, Button2, Button3 };

        private MyMessageType _messageType = MyMessageType.Confirm;
        private MyMessageButton _messageButtons = MyMessageButton.None;
        private MyMessageDefaultButton _messageDefaultButton = MyMessageDefaultButton.Button1;
        private Font _messageFont = new Font("Arial", 12f);
        private int _closeInterval = 2000;
        private string _text = string.Empty;
        private string _caption = string.Empty;

        public Font MessageFont
        {
            get { return _messageFont; }
            set { _messageFont = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        public MyMessageType MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }
        public MyMessageButton MessageButtons
        {
            get { return _messageButtons; }
            set { _messageButtons = value; }
        }
        public int CloseInterval
        {
            get { return _closeInterval; }
            set { _closeInterval = value; }
        }
        public MyMessageDefaultButton MessageDefaultButton
        {
            get { return _messageDefaultButton; }
            set { _messageDefaultButton = value; }
        }

        public Size ExtraSize { get; set; }

        public DialogResult Show()
        {
            fMessage = new FormMessage(this);
            return fMessage.ShowDialog();
        }

        public DialogResult Show(IWin32Window owner)
        {
            fMessage = new FormMessage(this);
            return fMessage.ShowDialog(owner);
        }
    }
}
