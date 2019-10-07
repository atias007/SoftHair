using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class CarePicker : UserControl
    {
        readonly Color _selectColor = Color.FromArgb(246, 195, 93);
        readonly Color _pointColor = Color.FromKnownColor(KnownColor.Highlight);
        bool _showBorder = true;
        ToolTip tip;

        public event EventHandler OkClicked;
        public event EventHandler CancelClicked;
        public event EventHandler BindingComplete;
        public event EventHandler ClearClicked;

        public CarePicker()
        {
            InitializeComponent();
        }

        public void SetData(DataTable table)
        {
            dataGridView1.DataSource = table;
        }

        public bool ShowBorder
        {
            get { return _showBorder; }
            set { _showBorder = value; }
        }

        public bool ShowToolBar
        {
            get { return lblAllCares.Visible; }
            set
            {
                lblAllCares.Visible = value;
                if (value)
                {
                    tip = new ToolTip();
                    tip.SetToolTip(lblAllCares, "לחץ לבחירת כל הטיפולים");
                }
            }
        }

        public bool ButtonsVisible
        {
            get { return btnOk.Visible; }
            set 
            {
                btnOk.Visible = value;
                btnCancel.Visible = value;
                if (value)
                {
                    btnClear.Width = 22;
                    btnClear.ImageAlign = ContentAlignment.MiddleCenter;
                    btnClear.Text = string.Empty;
                }
                else
                {
                    btnClear.Width = 160;
                    btnClear.ImageAlign = ContentAlignment.MiddleLeft;
                    btnClear.Text = @" נקה טיפולים מסומנים";
                }
            }
        }

        public void SelectItems(string items)
        {
            if (string.IsNullOrEmpty(items)) return;
            var iFirst = -1;
            var sel = items.Split(' ');
            for (var i = 0; i < sel.Length; i++ )
            {
                for (var j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (sel[i].Equals(dataGridView1["c_id", j].Value.ToString()))
                    {
                        if (iFirst == -1) iFirst = j;
                        dataGridView1["c_selected", j].Value = true;
                        dataGridView1["c_selected", j].Style.BackColor = _selectColor;
                        dataGridView1["c_selected", j].Style.SelectionBackColor = _selectColor;
                        dataGridView1["c_description", j].Style.BackColor = _selectColor;
                        dataGridView1["c_description", j].Style.SelectionBackColor = _selectColor;
                        dataGridView1["c_description", j].Style.SelectionForeColor = Color.Black;
                        break;
                    }
                }
            }
            if (iFirst > -1)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = iFirst;
            }
        }

        public void ClearPointCare()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        public void ClearSelectedCares()
        {
            ClearPointCare();
            for (var j = 0; j < dataGridView1.Rows.Count; j++)
            {  
                dataGridView1["c_selected", j].Value = false;
                dataGridView1["c_selected", j].Style.BackColor = Color.White;
                dataGridView1["c_selected", j].Style.SelectionBackColor = _pointColor;
                dataGridView1["c_description", j].Style.BackColor = Color.White;
                dataGridView1["c_description", j].Style.SelectionBackColor = _pointColor;
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = 0;
        }

        public string GetSelectedItems()
        {
            var ret = string.Empty;
            for (var j = 0; j < dataGridView1.Rows.Count; j++)
            {
                var selected = dataGridView1["c_selected", j].Value == null ? false : (bool)dataGridView1["c_selected", j].Value;
                if (selected)
                {
                    ret += ((int)(dataGridView1["c_id", j].Value)).ToString() + " ";
                }
            }
            return ret.Trim();
        }

        //public string GetAllCares()
        //{
        //    string ret = string.Empty;
        //    for (int j = 0; j < dataGridView1.Rows.Count; j++)
        //    {
        //        ret += ((int)(dataGridView1["c_id", j].Value)).ToString() + " ";
        //    }
        //    return ret.Trim();
        //}

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var cell1 = dataGridView1["c_selected", e.RowIndex];
            var cell2 = dataGridView1["c_description", e.RowIndex];
            FocusTextControl();
            if (cell1 == null) return;
            if (cell2 == null) return;
            var select = cell1.Value != null && (bool)cell1.Value;

            if (select)
            {
                cell1.Style.BackColor = Color.White;
                cell1.Style.SelectionBackColor = _pointColor;
                cell2.Style.BackColor = Color.White;
                cell2.Style.SelectionBackColor = _pointColor;
                cell2.Style.SelectionForeColor = Color.White;
            }
            else
            {
                cell1.Style.BackColor = _selectColor;
                cell1.Style.SelectionBackColor = _selectColor;
                cell2.Style.BackColor = _selectColor;
                cell2.Style.SelectionBackColor = _selectColor;
                cell2.Style.SelectionForeColor = Color.Black;
            }
            cell1.Value = !select;
            FocusTextControl();
        }

        private void FocusTextControl()
        {
            txtFind.Select();
            txtFind.Focus();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            FocusTextControl();
            if (e.RowIndex == -1) return;
            dataGridView1.Rows[e.RowIndex].Selected = true;
            FocusTextControl();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OkClicked != null) OkClicked(this, new EventArgs());
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (CancelClicked != null) CancelClicked(this, new EventArgs());
                e.Handled = true;
            }
            FocusTextControl();
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (OkClicked != null) OkClicked(this, new EventArgs());
            dataGridView1.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelClicked != null) CancelClicked(this, new EventArgs());
            dataGridView1.Select();
        }

        private void CarePicker_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns["c_description"].Width = dataGridView1.Width - dataGridView1.Columns["c_selected"].Width - SystemInformation.VerticalScrollBarWidth - 4;
        }

        private void CarePicker_Paint(object sender, PaintEventArgs e)
        {
            if (_showBorder)
            {
                var c = Color.FromArgb(192, 197, 203);
                e.Graphics.DrawRectangle(new Pen(c), 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (BindingComplete != null) BindingComplete(this, new EventArgs());
            FocusTextControl();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelectedCares();
            dataGridView1.Select();
        }

        private void lblAllCares_MouseDown(object sender, MouseEventArgs e)
        {
            ClearSelectedCares();
            if (ClearClicked != null) ClearClicked(this, new EventArgs());
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            FocusTextControl();
        }

        private void btnOk_MouseUp(object sender, MouseEventArgs e)
        {
            FocusTextControl();
        }

        private void btnCancel_MouseUp(object sender, MouseEventArgs e)
        {
            FocusTextControl();
        }

        private void btnClear_MouseUp(object sender, MouseEventArgs e)
        {
            FocusTextControl();
        }

        private void lblAllCares_MouseUp(object sender, MouseEventArgs e)
        {
            FocusTextControl();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var value = row.Cells["c_description"].Value;
                var find = txtFind.Text.Trim();
                row.Visible = (value != null && value.ToString().Contains(find));
            }
        }

    }
}
