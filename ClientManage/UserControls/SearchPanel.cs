using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class SearchPanel : UserControl
    {
        private Image _image = null;
        private string _text = "SearchPanel";
        private string _defaultSearchBoxText = string.Empty;
        private bool _isFilter = false;
        private bool _alwaysOnFocus = false;

        public event EventHandler SearchClicked;
        public event EventHandler ClearClicked;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(101, 147, 207));
            e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);
            e.Graphics.DrawLine(pen, this.Width - 1, 0, this.Width - 1, this.Height);
            e.Graphics.DrawLine(Pens.White, 1, 1, 1, this.Height - 2);

            if (_image != null)
            {
                e.Graphics.DrawImage(_image, 6, 6, 16, 16);
            }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; this.Refresh(); }
        }

        public int DelaySearchTextBox
        {
            get { return txtSearch.Delay; }
            set { txtSearch.Delay = value; }
        }

        [Browsable(false)]
        public bool IsFilter
        {
            get { return _isFilter; }
            set
            {
                _isFilter = value;
                lblClear.Visible = _isFilter;
                if (value)
                    lblText.Text = _text + " (תוצאות חיפוש)";
                else
                    lblText.Text = _text;
            }
        }

        public string PanelText
        {
            get
            {
                return _text;
            }
            set
            {
                lblText.Text = value;
                _text = value;
            }
        }

        [Browsable(false)]
        public string SearchString
        {
            get
            {
                var pattern = txtSearch.Text.Trim();
                if (pattern == _defaultSearchBoxText) pattern = string.Empty;
                return pattern;
            }
            set
            {
                txtSearch.Text = value;
                txtSearch.SelectionStart = txtSearch.Text.Length;
            }
        }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        public string DefaultSearchBoxText
        {
            get { return _defaultSearchBoxText; }
            set { _defaultSearchBoxText = value; if(!_alwaysOnFocus) txtSearch.Text = value; }
        }

        public bool AlwaysOnFocus
        {
            get
            {
                return _alwaysOnFocus;
            }
            set
            {
                _alwaysOnFocus = value;
            }
        }

        private void SearchPanel_Focus()
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.search_panel_bgorange;
        }

        private void SearchPanel_LostFocus()
        {
            if (!IsFilter && !_alwaysOnFocus)
            {
                this.BackgroundImage = global::ClientManage.Properties.Resources.search_panel_bgblue;
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            var pattern = txtSearch.Text.Trim();
            if (pattern == _defaultSearchBoxText || pattern.Length == 0) return;
            if (SearchClicked != null)
            {
                SearchClicked(this, new EventArgs());
                txtSearch.ResetDelayTimer();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        public void Clear()
        {
            if (_isFilter) lblClear_Click(null, null);
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            IsFilter = false;
            txtSearch.Text = string.Empty;
            if(!_alwaysOnFocus) txtSearch.Text = _defaultSearchBoxText;
            txtSearch.ForeColor = Color.DimGray;
            SearchPanel_LostFocus();
            if (ClearClicked != null) ClearClicked(this, new EventArgs());
        }

        public void ResetPanel()
        {
            IsFilter = false;
            txtSearch.Text = string.Empty;
            if(!_alwaysOnFocus) txtSearch.Text = _defaultSearchBoxText;
            txtSearch.ForeColor = Color.DimGray;
            SearchPanel_LostFocus();
        }

        private void lblClear_MouseEnter(object sender, EventArgs e)
        {
            lblClear.Image = global::ClientManage.Properties.Resources.btn_clear_orange;
        }

        private void lblClear_MouseLeave(object sender, EventArgs e)
        {
            lblClear.Image = global::ClientManage.Properties.Resources.btn_clear_blue;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;

            if (txtSearch.Text == string.Empty && !_alwaysOnFocus)
            {
                if (lblClear.Visible)
                {
                    lblClear_Click(null, null);
                }
                else
                {
                    txtSearch.Text = _defaultSearchBoxText;
                    txtSearch.ForeColor = Color.DimGray;
                }
            }
            SearchPanel_LostFocus();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == _defaultSearchBoxText) txtSearch.Text = string.Empty;
            txtSearch.ForeColor = Color.Black;
            SearchPanel_Focus();
        }

        protected override void OnEnter(EventArgs e)
        {
            txtSearch.Select();
            txtSearch.Focus();
            base.OnEnter(e);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblSearch_Click(null, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblClear_Click(null, null);
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                txtSearch.SelectionStart = txtSearch.Text.Length + 1;
            }
            this.OnKeyUp(e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Delay > 0)
            {
                var pattern = txtSearch.Text.Trim();
                if (pattern != _defaultSearchBoxText)
                {
                    if (pattern.Length > 0)
                    {
                        if (SearchClicked != null)
                        {
                            txtSearch.Select();
                            SearchClicked(this, new EventArgs());
                        }
                    }
                    else
                    {
                        if (lblClear.Visible)
                        {
                            txtSearch.Select();
                            lblClear_Click(null, null);
                        }
                    }
                }
            }
        }

        private void SearchPanel_Load(object sender, EventArgs e)
        {
            txtSearch.Text = _defaultSearchBoxText;
        }

        //public void FocusTextBox()
        //{
        //    this.Select();
        //    txtSearch.Select();
        //    txtSearch.Focus();
        //    this.ActiveControl = txtSearch;
        //}
    }
}
