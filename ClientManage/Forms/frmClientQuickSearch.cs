using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using ClientManage.BL;
using ClientManage.Library;
using ClientManage.Interfaces;

namespace ClientManage.Forms
{
    public partial class FormClientQuickSearch : Form
    {
        #region Form Drop Shadow

        private const int CS_DROPSHADOW = 0x00020000;

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                var parameters = base.CreateParams;

                if (DropShadowSupported)
                {
                    parameters.ClassStyle = (parameters.ClassStyle | CS_DROPSHADOW);
                }

                return parameters;
            }
        }

        public static bool DropShadowSupported
        {
            get { return IsWindowsXPOrAbove; }
        }

        public static bool IsWindowsXPOrAbove
        {
            get
            {
                var system = Environment.OSVersion;
                var runningNT = system.Platform == PlatformID.Win32NT;

                return runningNT && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
            }
        }


        #endregion

        #region Private

            #region Members

        private static int _selectedClientId = 0;
        private readonly string strCount;
        private readonly bool _isWorkerPick = false;
        private int _visibleItems = 7;
        private readonly DgvLoadImages li = new DgvLoadImages();
        private ToolTip tip = null;
        private readonly SearchEngine se = new SearchEngine();

            #endregion

        #endregion

        #region Public

            #region Events

        public event EventHandler ClientSelected;

            #endregion

            #region Properties
                
        public static int SelectedClientId
        {
            get { return _selectedClientId; }
        }

        public int VisibleItems
        {
            get { return _visibleItems; }
            set
            {
                _visibleItems = value;
                var factor = 48 * _visibleItems;
                if (_visibleItems < 5) _visibleItems = 5;
                this.Height = 94 + factor;
            }
        }

        public bool ShowToolBar
        {
            get { return pnlToolbar.Visible; }
            set
            {
                pnlToolbar.Visible = value;
                if (value)
                {
                    var entity = _isWorkerPick ? "עובדים" : "לקוחות";
                    tip = new ToolTip();
                    tip.SetToolTip(lblAllUsers, "לחץ לבחירת כל ה" + entity + " במערכת");
                    tip.SetToolTip(lblNoUser, "לחץ לביטול בחירת " + entity);
                }
            }
        }

            #endregion

        #endregion

        #region Constructor

        public FormClientQuickSearch(bool isWorkerPick)
        {
            _isWorkerPick = isWorkerPick;
            InitializeComponent();
            strCount = lblCount.Text;
            if (_isWorkerPick)
            {
                strCount = strCount.Replace("לקוחות", "עובדים");
                tabPage2.Text = "עובדים בעסק";
                label1.Text = label1.Text.Replace("לקוח", "עובד");
                tabControl1.TabPages.Remove(tabPage1);
            }
        }

        public FormClientQuickSearch() : this(false) { }

        #endregion

        #region From & Controls Events

        private void TextBox_Focus(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.LemonChiffon;
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.White;
        }

        private void frmClientQuickSearch_Load(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdClients.Rows.Count == 0) return;
            var cur = 0;

            if (e.KeyCode == Keys.Down)
            {
                cur = grdClients.SelectedRows[0].Index;
                if (cur == grdClients.Rows.Count - 1) return;
                grdClients.Rows[cur + 1].Selected = true;
                grdClients.CurrentCell = grdClients.Rows[cur + 1].Cells[0];
            }

            if (e.KeyCode == Keys.Up)
            {
                cur = grdClients.SelectedRows[0].Index;
                if (cur == 0) return;
                grdClients.Rows[cur - 1].Selected = true;
                grdClients.CurrentCell = grdClients.Rows[cur - 1].Cells[0];
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                //this.Hide();
                if (ClientSelected != null) ClientSelected(this, new EventArgs());
                this.Close();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                ((TextBox)sender).SelectionStart = txtSearch.Text.Length + 1;
            }
        }

        private void grdClients_Enter(object sender, EventArgs e)
        {
            txtSearch.Select();
        }

        private void frmClientQuickSearch_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientQuickSearch_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var pattern = txtSearch.Text.Trim();

            var filterCol = se.FilterClientTable(pattern);
            BindDataGrid(filterCol);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (_isWorkerPick)
                    {
                        BindDataGrid(se.GetWorkersForPick());
                        tabPage2.Controls.Add(grdClients);
                        grdClients.BringToFront();
                    }
                    else
                    {
                        tabPage1.Controls.Add(grdClients);
                        grdClients.BringToFront();
                        txtSearch.Select();
                        txtSearch_TextChanged(null, null);
                    }
                    break;

                case 1:
                    tabPage2.Controls.Add(grdClients);
                    grdClients.BringToFront();
                    BindDataGrid(se.GetLastCallClients());
                    break;
            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Select();
        }

        private void grdClients_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            //this.Hide();
            if (ClientSelected != null) ClientSelected(this, new EventArgs());
            this.Close();
        }

        private void grdClients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            li.BeginLoadImages(grdClients);
        }

        private void grdClients_SelectionChanged(object sender, EventArgs e)
        {
            if(grdClients.SelectedRows.Count > 0)
            {
                _selectedClientId = Convert.ToInt32(grdClients.SelectedRows[0].Cells["clmId"].Value);
            }
        }

        #endregion

        private void BindDataGrid(SearchItemCollection col)
        {
            try
            {
                grdClients.DataSource = col;
            }
            catch
            {
                System.Threading.Thread.Sleep(200);
                try
                {
                    grdClients.DataSource = col;
                }
                catch 
                {
                    System.Threading.Thread.Sleep(200);
                    try
                    {
                        grdClients.DataSource = col;
                    }
                    catch { }
                }
            }

            lblCount.Text = string.Format(strCount, grdClients.Rows.Count);
            lblCount2.Text = string.Format(strCount, grdClients.Rows.Count);
        }

        private void grdClients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            grdClients.Rows[e.RowIndex].Selected = true;
            grdClients.CurrentCell = grdClients.Rows[e.RowIndex].Cells[0];
        }

        private void grdClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            li.BeginLoadImages(grdClients);
        }

        private void lblAllUsers_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedClientId = -1;
            //this.Hide();
            if (ClientSelected != null) ClientSelected(this, new EventArgs());
            this.Close();
        }

        private void lblNoUser_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedClientId = 0;
            //this.Hide();
            if (ClientSelected != null) ClientSelected(this, new EventArgs());
            this.Close();
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            e.Graphics.DrawRectangle(new Pen(c), 0, 0, label2.Width - 1, label2.Height - 1);
        }

        private void frmClientQuickSearch_Activated(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                if (grdClients.Rows.Count == 0)
                {
                    var col = se.FilterClientTable(string.Empty);
                    BindDataGrid(col);
                }
            }
        }

        private void grdClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }
    }
}