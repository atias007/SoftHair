using System;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class FormControlBox : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormControlBox"/> class.
        /// </summary>
        public FormControlBox()
        {
            InitializeComponent();

            this.ShowMaximize = true;
            this.ShowMinimize = true;
            this.ShowControlBox = true;
        }

        /// <summary>
        /// Customs the initialize.
        /// </summary>
        private void CustomInitialize()
        {
            if (this.ShowControlBox == false)
            {
                lblMaximize.Visible = false;
                lblMinimize.Visible = false;
                lblClose.Image = Properties.Resources.btn_close_dis;
            }
            else
            {
                if (this.ShowMinimize == false && this.ShowMaximize)
                {
                    lblMinimize.Image = Properties.Resources.btn_minimize_dis;
                }
                if (this.ShowMaximize == false && this.ShowMinimize)
                {
                    lblMaximize.Image = Properties.Resources.btn_maximize_dis;
                }
                if (this.ShowMaximize == false && this.ShowMinimize == false)
                {
                    lblMaximize.Visible = false;
                    lblMinimize.Visible = false;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            CustomInitialize();
            base.OnLoad(e);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show minimize].
        /// </summary>
        /// <value><c>true</c> if [show minimize]; otherwise, <c>false</c>.</value>
        public bool ShowMinimize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show maximize].
        /// </summary>
        /// <value><c>true</c> if [show maximize]; otherwise, <c>false</c>.</value>
        public bool ShowMaximize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show control box].
        /// </summary>
        /// <value><c>true</c> if [show control box]; otherwise, <c>false</c>.</value>
        public bool ShowControlBox { get; set; }
        
        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>The dialog result.</value>
        public DialogResult DialogResult { get; set; }

        /// <summary>
        /// Handles the Click event of the LblMinimize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblMinimize_Click(object sender, EventArgs e)
        {
            if (this.ShowMinimize)
            {
                var form = this.FindForm();
                if (form != null)
                {
                    form.WindowState = FormWindowState.Minimized;
                }
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the LblMinimize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblMinimize_MouseEnter(object sender, EventArgs e)
        {
            if (this.ShowMinimize)
                lblMinimize.Image = Properties.Resources.btn_minimize_light;
        }

        /// <summary>
        /// Handles the MouseLeave event of the LblMinimize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblMinimize_MouseLeave(object sender, EventArgs e)
        {
            if (this.ShowMinimize)
                lblMinimize.Image = Properties.Resources.btn_minimize;
        }

        /// <summary>
        /// Handles the Click event of the LlMaximize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LlMaximize_Click(object sender, EventArgs e)
        {
            if (this.ShowMaximize)
            {
                var form = this.FindForm();
                if (form != null)
                {
                    form.WindowState = form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                }
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the LblMaximize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblMaximize_MouseEnter(object sender, EventArgs e)
        {
            if (this.ShowMaximize)
                lblMaximize.Image = Properties.Resources.btn_maximize_light;
        }

        /// <summary>
        /// Handles the MouseLeave event of the lblMaximize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblMaximize_MouseLeave(object sender, EventArgs e)
        {
            if (this.ShowMaximize)
                lblMaximize.Image = Properties.Resources.btn_maximize;
        }

        /// <summary>
        /// Handles the Click event of the LblClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblClose_Click(object sender, EventArgs e)
        {
            if (this.ShowControlBox)
            {
                var form = this.FindForm();
                if (form != null)
                {
                    form.DialogResult = this.DialogResult;
                    form.Close();
                }
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the LblClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblClose_MouseEnter(object sender, EventArgs e)
        {
            if (this.ShowControlBox)
                lblClose.Image = Properties.Resources.btn_close_light;
        }

        /// <summary>
        /// Handles the MouseLeave event of the LblClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LblClose_MouseLeave(object sender, EventArgs e)
        {
            if(this.ShowControlBox)
                lblClose.Image = Properties.Resources.btn_close;
        }
    }
}
