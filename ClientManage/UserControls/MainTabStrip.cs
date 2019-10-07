using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace ClientManage
{
    public partial class MainTabStrip : UserControl
    {
        private readonly ArrayList _list = new ArrayList();
        private int _selectedIndex = -1;

        public event EventHandler TabClick;

        public MainTabStrip()
        {
            InitializeComponent();
            SubInitialize();
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(121, 144, 176));
            e.Graphics.DrawLine(pen, 0, 0, label1.Width, 0);
        }

        private void MainTabStrip_Paint(object sender, PaintEventArgs e)
        {
            var fromColor = Color.FromArgb(176, 173, 156);
            var toColor = Color.White;
            var border = Color.FromArgb(101, 147, 207);
            var rec = new Rectangle(0, 0, this.Width, this.Height - 10);
            var brush = new LinearGradientBrush(rec, fromColor, toColor, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, rec);
            e.Graphics.DrawLine(new Pen(border), 0, 0, this.Width, 0);
        }

        private void SubInitialize()
        {
            // *** Do not change order of tabs here ***
            _list.Add(lblClient);
            _list.Add(lblReport);
            _list.Add(lblPhoneBook);
            _list.Add(lblCalendar);
            _list.Add(lblExit);
            _list.Add(lblWorkers);
            _list.Add(lblBO);
        }

        private void SetTabPicture(Label label, bool isDisabled)
        {
            switch (label.Name)
            {
                case "lblClient":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_client_dis : global::ClientManage.Properties.Resources.tab_client;
                    break;

                case "lblReport":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_reports_dis : global::ClientManage.Properties.Resources.tab_reports;
                    break;

                case "lblPhoneBook":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_phone_book_dis : global::ClientManage.Properties.Resources.tab_phone_book;
                    break;

                case "lblCalendar":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_calendar_dis : global::ClientManage.Properties.Resources.tab_calendar;
                    break;

                case "lblWorkers":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_workers_dis : global::ClientManage.Properties.Resources.tab_workers;
                    break;

                case "lblExit":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_exit_dis : global::ClientManage.Properties.Resources.tab_exit;
                    break;

                case "lblBO":
                    label.Image = isDisabled ? global::ClientManage.Properties.Resources.tab_opt_dis : global::ClientManage.Properties.Resources.tab_opt;
                    break;
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            Label lbl;

            if (_selectedIndex == _list.IndexOf(sender)) return;

            if (_selectedIndex >= 0)
            {
                lbl = ((Label)_list[_selectedIndex]);
                lbl.Top += 6;
                SetTabPicture(lbl, true);
                lbl.SendToBack();
            }

            lbl = (Label)sender;
            lbl.Top -= 6;
            _selectedIndex = _list.IndexOf(sender);
            SetTabPicture(lbl, false);
            lbl.BringToFront();

            Application.DoEvents();

            if (TabClick != null) TabClick(this, new EventArgs());

        }

        public void SelectTab(int index)
        {
            try
            {
                Tab_Click(_list[index], new EventArgs());
            }
            catch(Exception){}
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("QuickLaunch.exe", "-support");
            }
            catch (Exception ex)
            {
                MessageBox.Show("קובץ קריאת השירות לא נמצא\n" + ex.Message, "שגיאה...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
