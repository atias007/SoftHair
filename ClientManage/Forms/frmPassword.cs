using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Forms
{
    public partial class FormPassword : BasePopupForm
    {
        private readonly string _password = string.Empty;
        private readonly bool _withAdminPassword = true;

        public FormPassword(string password, string caption) : this(password, caption, true) { }
        public FormPassword(string password, string caption, bool withAdminPassword)
        {
            InitializeComponent();
            this._password = password;
            lblCaption.Text = caption;
            _withAdminPassword = withAdminPassword;
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            txtPassword.Select();
            txtPassword_Enter(txtPassword, null);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.White;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.LemonChiffon;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var strPassword = txtPassword.Text;
            var isExstPass = strPassword.Length > 0;
            var isSrcPass = (strPassword.Equals(_password));
            var isAdminPass = _withAdminPassword && WorkersHelper.IsAdminPassword(strPassword);
            var isMasterPass = (strPassword.Equals(AppSettingsHelper.GetParamValue("APP_MASTER_PASSWORD")));
            var isSuperPass = Utils.IsSuperUserPassword(txtPassword.Text, AppSettingsHelper.GetParamValue("APP_SUPER_USER_PASS"));
            var ok = isExstPass && (isSrcPass || isAdminPass || isMasterPass || isSuperPass);

            if ( ok )
                
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtPassword.Text = string.Empty;
                lblError.Visible = true;
                txtPassword.Select();
                System.Media.SystemSounds.Beep.Play();
            }
        }
    }
}