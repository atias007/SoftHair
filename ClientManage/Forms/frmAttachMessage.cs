using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Forms
{
    public partial class FormAttachMessage : BasePopupForm
    {
        private readonly int _clientId = 0;

        public FormAttachMessage(int clientId)
        {
            _clientId = clientId;
            InitializeComponent();
        }

        private void frmAttachMessage_Load(object sender, EventArgs e)
        {
            SetClientPicture();
        }

        private void SetClientPicture()
        {
            if (_clientId == 0)
            {
                picView.BackgroundImage = global::ClientManage.Properties.Resources.no_client_big;
                lblFirstName.Text = string.Empty;
                lblLastName.Text = string.Empty;
                this.Tooltip.SetToolTip(picView, string.Empty);
            }
            else
            {
                var param = CalendarHelper.GetClientPicture(_clientId);
                lblFirstName.Text = param[0];
                lblLastName.Text = param[1];
                this.Tooltip.SetToolTip(picView, "לחץ לחיצה כפולה על מנת להציג את כרטיס הלקוח");
                try
                {
                    picView.BackgroundImage = Image.FromFile(param[2]);
                }
                catch
                {
                    picView.BackgroundImage = global::ClientManage.Properties.Resources.no_image_medium;
                }
            }
            this.Select();
        }
    }
}