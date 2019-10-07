using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;

namespace ClientManage.Forms
{
    public partial class FormCarePick : Form
    {
        private readonly string _doSelectCares = string.Empty;
        private bool _isCancel = false;
        private static string _selectedCares = string.Empty;

        public event EventHandler SetAppointmentCares;

        public FormCarePick() : this(string.Empty) { }
        public FormCarePick(string selectCares)
        {
            InitializeComponent();
            _doSelectCares = selectCares;
        }

        public static string SelectedCares
        {
            get { return _selectedCares; }
        }

        public bool ShowToolBar
        {
            get { return carePicker1.ShowToolBar; }
            set { carePicker1.ShowToolBar = value; }
        }

        public void SelectCares(string cares)
        {
            carePicker1.SelectItems(cares);
        }

        public void ClearSelected()
        {
            carePicker1.ClearSelectedCares();
        }

        private void frmCarePick_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);
        }

        private void frmCarePick_Deactivate(object sender, EventArgs e)
        {
            if (!_isCancel)
            {
                this.Hide();
                _selectedCares = carePicker1.GetSelectedItems();
                if (SetAppointmentCares != null) SetAppointmentCares(this, new EventArgs());
            }
            this.Close();
        }

        private void frmCarePick_Load(object sender, EventArgs e)
        {
            carePicker1.SetData(LookupHelper.GetLookupTable("tblCares", "score"));
        }

        private void carePicker1_BindingComplete(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_doSelectCares))
            {
                carePicker1.SelectItems(_doSelectCares);
            }
        }

        private void carePicker1_CancelClicked(object sender, EventArgs e)
        {
            _isCancel = true;
            this.Close();
        }

        private void carePicker1_OkClicked(object sender, EventArgs e)
        {
            _selectedCares = carePicker1.GetSelectedItems();
            _isCancel = true;
            this.Hide();
            if (SetAppointmentCares != null) SetAppointmentCares(this, new EventArgs());
            try { this.Close(); } catch { }
        }

        private void carePicker1_ClearClicked(object sender, EventArgs e)
        {
            _selectedCares = "-1";
            _isCancel = true;
            this.Hide();
            if (SetAppointmentCares != null) SetAppointmentCares(this, new EventArgs());
            try { this.Close(); } catch { }
        }
    }
}