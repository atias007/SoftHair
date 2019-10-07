using System;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Library;


namespace ClientManage.Forms
{
    public partial class BaseMdiChild : Form
    {
        private bool _closeFormByEsc;
        private bool _returnToReportForm;
        private PermissionMember _logOnPermision = PermissionMember.StandardUser;
        private ToolTip _tooltip;

        public event EventHandler RequestForClose;

        protected enum PermissionMember { StandardUser, Admin, SuperUser }
        
        protected MyMessageBox MsgBox;

        public BaseMdiChild()
        {
            InitializeComponent();
            //CustomInitialize();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (General.ScreenResolutionFactorWidth != 1)
            {
                this.SetElementsResolutionFactor();
            }
            base.OnLoad(e);
        }

        public virtual void SetElementsResolutionFactor()
        {
            
        }

        public bool ReturnToReportForm
        {
            get { return _returnToReportForm; }
            set { _returnToReportForm = value; }
        }

        public bool CloseFormByEsc
        {
            get { return _closeFormByEsc; }
            set
            {
                _closeFormByEsc = value;
                this.KeyPreview = value;

                if (_closeFormByEsc)
                {
                    this.KeyDown += BaseMdiChild_KeyDown;
                }
                else
                {
                    this.KeyDown -= BaseMdiChild_KeyDown;
                }
            }
        }

        void BaseMdiChild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (RequestForClose != null) RequestForClose(this, new EventArgs());
            }
        }

        protected PermissionMember LogOnPermission
        {
            get { return _logOnPermision; }
            set { _logOnPermision = value; }
        }

        protected void TextBoxEnter(TextBox sender)
        {
            if (sender.ReadOnly) return;
            sender.BackColor = Color.LemonChiffon;
        }

        protected void TextBoxLeave(TextBox sender)
        {
            if (sender.ReadOnly) return;
            sender.BackColor = Color.White;
        }

        protected void ControlClearBgColor(Control control)
        {
            control.BackColor = Color.White;
        }

        protected void ShowOnConstructMessage()
        {
            const string msg3 = "פעולה זו אינה זמינה ונמצאת בשלבי פיתוח";
            MsgBox = new MyMessageBox(msg3, "SoftHair - מערכת ניהול לקוחות ועובדים", MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
            MsgBox.Show(this);
        }

        protected override void OnLeave(EventArgs e)
        {
            _returnToReportForm = false;
            base.OnLeave(e);
        }
        
        protected ToolTip Tooltip
        {
            get { return _tooltip ?? (_tooltip = new ToolTip()); }
        }
    }
}