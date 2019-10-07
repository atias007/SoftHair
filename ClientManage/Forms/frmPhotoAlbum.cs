using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClientManage.UserControls;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using System.Collections;

namespace ClientManage.Forms
{
    public partial class FormPhotoAlbum : BasePopupForm
    {
        #region Public

            #region Events

        public event OpenFormEventHandler OpenForm;
        public event DialRequestEventHandler DialRequest;
        public event ClientOperationEventHandler RefreshClient;
        public event EventHandler RefreshClientBullets;

            #endregion

            #region Methods

        public void MoveNext()
        {
            if (photos.Count == 0) return;
            var found = false;

            switch (_currentView)
            {
                case 1:
                    PhotoPreview pp;
                    for (var i = 0; i < pnlPreview.Controls.Count; i++)
                    {
                        pp = (PhotoPreview)pnlPreview.Controls[i];
                        if (pp.Selected)
                        {
                            pp.Selected = false;
                            if (i == pnlPreview.Controls.Count - 1) i = -1;
                            pp = (PhotoPreview)pnlPreview.Controls[i + 1];
                            pnlPreview.ScrollControlIntoView(pp);
                            pp.Selected = true;
                            found = true;
                            break;
                        }
                    }
                    if (!found) ((PhotoPreview)pnlPreview.Controls[0]).Selected = true;
                    break;

                case 2:
                    FilmstripPreview fp;
                    for (var i = 0; i < pnlFilmStrip.Controls.Count; i++)
                    {
                        fp = (FilmstripPreview)pnlFilmStrip.Controls[i];
                        if (fp.Selected)
                        {
                            fp.Selected = false;
                            if (i == pnlFilmStrip.Controls.Count - 1) i = -1;
                            fp = (FilmstripPreview)pnlFilmStrip.Controls[i + 1];
                            fp.Selected = true;
                            pnlFilmStrip.ScrollControlIntoView(fp);
                            found = true;
                            break;
                        }
                    }
                    if (!found) ((FilmstripPreview)pnlFilmStrip.Controls[0]).Selected = true;
                    break;

                case 3:
                    if (grdPreview.Rows.Count == 0) return;
                    var index = -1;
                    if (grdPreview.SelectedRows.Count > 0) index = grdPreview.SelectedRows[0].Index;
                    if (index == grdPreview.Rows.Count - 1) index = -1;
                    index++;
                    grdPreview.Rows[index].Selected = true;
                    if (grdPreview.Rows[index].Displayed == false) grdPreview.FirstDisplayedScrollingRowIndex = index;
                    break;

                default:
                    break;
            }
        }

        public void MovePrevious()
        {
            if (photos.Count == 0) return;
            var found = false;

            switch(_currentView)
            {
                case 1:
                    PhotoPreview pp;
                    for (var i = 0; i < pnlPreview.Controls.Count; i++)
                    {
                        pp = (PhotoPreview)pnlPreview.Controls[i];
                        if (pp.Selected)
                        {
                            pp.Selected = false;
                            if (i == 0) i = pnlPreview.Controls.Count;
                            pp = (PhotoPreview)pnlPreview.Controls[i - 1];
                            pp.Selected = true;
                            pnlPreview.ScrollControlIntoView(pp);
                            found = true;
                            break;
                        }
                    }
                    if (!found) ((PhotoPreview)pnlPreview.Controls[0]).Selected = true;
                    break;

                case 2:
                    FilmstripPreview fp;
                    for (var i = 0; i < pnlFilmStrip.Controls.Count; i++)
                    {
                        fp = (FilmstripPreview)pnlFilmStrip.Controls[i];
                        if (fp.Selected)
                        {
                            fp.Selected = false;
                            if (i == 0) i = pnlFilmStrip.Controls.Count;
                            fp = (FilmstripPreview)pnlFilmStrip.Controls[i - 1];
                            fp.Selected = true;
                            pnlFilmStrip.ScrollControlIntoView(fp);
                            found = true;
                            break;
                        }
                    }
                    if (!found) ((FilmstripPreview)pnlFilmStrip.Controls[0]).Selected = true;
                    break;

                case 3:
                    if (grdPreview.Rows.Count == 0) return;
                    var index = 1;
                    if (grdPreview.SelectedRows.Count > 0) index = grdPreview.SelectedRows[0].Index;
                    if (index == 0) index = grdPreview.Rows.Count;
                    index--;
                    grdPreview.Rows[index].Selected = true;
                    if (grdPreview.Rows[index].Displayed == false) grdPreview.FirstDisplayedScrollingRowIndex = index;
                    break;

                default:
                    break;
            }
            
        }

        public void AddPhoto(ClientPhoto photo)
        {
            photos.Insert(0, photo);
            SetNoItemsLabel();
            if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());

            var mi = new MethodInvoker(LoadImages);
            mi.BeginInvoke(null, null);
        }

        public void DeletePhoto(ClientPhoto photo, Form source)
        {
            string msg1, msg2;
            msg2 = "מחיקת תמונה...";

            if (photo == null)
            {
                msg1 = "לא נבחרה תמונה למחיקה\nסמן תחילה את התמונה הרצויה ולחץ על ''מחק תמונה''";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(source);
                return;
            }

            msg1 = "האם אתה בטוח שברצונך למחוק את התמונה";
            MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MyMessageBox.Show(source);

            if (res == DialogResult.Yes)
            {
                source.Cursor = Cursors.WaitCursor;
                try
                {
                    PhotoAlbumHelper.DeletePhoto(photo.Id);
                    RemovePhoto(photo.Id);
                    if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
                    try { File.Delete(photo.Picture); }
                    catch { }
                    if (source is FormPhotoDetails) { source.Hide(); source.Close(); Application.DoEvents(); }
                }
                catch (Exception ex)
                {
                    var title = "שגיאה באלבום התמונות...";
                    var head = "מחיקת תמונה מאלבום התמונות";
                    var desc = "מחיקת התמונה מאלבום התמונות של " + ClientHelper.GetFullName(photo.ClientId) + " נכשלה\nשים לב כי התמונה נשארה באלבום הלקוח";
                    ClientManage.Library.General.ShowErrorMessageDialog(source, title, head, desc, ex, "frmPhotoAlbum");
                }

                source.Cursor = Cursors.Default;
            }
        }

        public void ShowPhotoDetails()
        {
            var photo = GetSelectedPhoto();
            if (photo != null) ShowPhotoDetails(photo);
        }

            #endregion

        #endregion

        #region Private

            #region Members

        private readonly int _clientId = 0;
        private int _currentView = -1;
        private ClientPhotoCollection photos = new ClientPhotoCollection();
        private delegate void LoadBigPictureHandler(string filename);
        private Client c = null;

        private FlowLayoutPanel pnlPreview;
        private PictureBox picFilmPicture;
        private DataGridView grdPreview;
        private DataGridViewTextBoxColumn clm_id;
        private DataGridViewTextBoxColumn clmPicture;
        private DataGridViewImageColumn clmImage;
        private DataGridViewTextBoxColumn clm_subject;
        private DataGridViewTextBoxColumn clm_remark;
        private DataGridViewTextBoxColumn clm_date_create;
        private FlowLayoutPanel pnlFilmStrip;
        private readonly DgvLoadImages imageLoader = new DgvLoadImages();

            #endregion

            #region Functions

        private void SetNoItemsLabel()
        {
            if (photos.Count == 0)
            {
                if (_currentView == 2)
                {
                    lblNoItems.Top = picFilmPicture.Top + ((picFilmPicture.Height - lblNoItems.Height) / 2);
                }
                else
                {
                    lblNoItems.Top = informationBar1.Top + ((this.Height - this.Padding.Top - this.Padding.Bottom - toolStrip.Height - lblNoItems.Height) / 2);
                }
                lblNoItems.Visible = true;
                lblNoItems.BringToFront();
            }
            else
            {
                lblNoItems.Visible = false;
            }
        }

        public void LoadBigPicture(string fileName)
        {
            try
            {
                picFilmPicture.BackgroundImage = Image.FromFile(fileName);
            }
            catch
            {
                picFilmPicture.BackgroundImage = null;
            }
        }

        private int GetFreeHeight()
        {
            return this.Height - this.Padding.Top - this.Padding.Bottom - pnlFilmStrip.Height - toolStrip.Height
                - informationBar1.Height;
        }

        private void SetGridRowData(int index, ClientPhoto photo)
        {
            grdPreview["clm_id", index].Value = photo.Id;
            grdPreview["clmPicture", index].Value = photo.Picture;
            grdPreview["clm_subject", index].Value = photo.Subject;
            grdPreview["clm_remark", index].Value = photo.Remark;
            grdPreview["clm_date_create", index].Value = photo.DateCreated;
            grdPreview.Rows[index].Tag = photo;
        }

        private void BindDataGrid()
        {
            if (grdPreview == null) return;

            grdPreview.SuspendLayout();
            grdPreview.Rows.Clear();
            var id = -1;

            foreach (ClientPhoto p in photos)
            {
                id = grdPreview.Rows.Add();
                SetGridRowData(id, p);
            }

            grdPreview.ResumeLayout(true);
        }

        private void LoadData()
        {
            photos = PhotoAlbumHelper.GetPhotosForClient(_clientId);
            photos.ListChanged += new EventHandler<PhotoListChangedEventArgs>(photos_ListChanged);

            SetNoItemsLabel();
            if (photos.Count == 0) return;

            switch (_currentView)
            {
                case 1:
                    pnlPreview.Controls.Clear();
                    PhotoPreview item;
                    for (var i = 0; i < photos.Count; i++)
                    {
                        item = new PhotoPreview(photos[i]);
                        item.Size = new Size(232, 220);
                        pnlPreview.Controls.Add(item);
                        item.MouseDown += new MouseEventHandler(item_MouseDown);
                        item.MouseDoubleClick += new MouseEventHandler(item_MouseDoubleClick);
                    }
                    break;

                case 2:
                    pnlFilmStrip.Controls.Clear();
                    FilmstripPreview fs;
                    for (var i = 0; i < photos.Count; i++)
                    {
                        fs = new FilmstripPreview(photos[i]);
                        pnlFilmStrip.Controls.Add(fs);
                        fs.MouseDoubleClick += new MouseEventHandler(fs_MouseDoubleClick);
                        fs.MouseDown += new MouseEventHandler(fs_MouseDown);
                        fs.SelectedChanged += new EventHandler(fs_SelectedChanged);
                    }
                    if (pnlFilmStrip.Controls.Count > 0) ((FilmstripPreview)pnlFilmStrip.Controls[0]).Selected = true;
                    break;

                case 3:
                    BindDataGrid();
                    break;

                default:
                    break;
            }
            
            var mi = new MethodInvoker(LoadImages);
            mi.BeginInvoke(null, null);
        }

        private void ClearForm()
        {
            this.Controls.Remove(grdPreview);
            this.Controls.Remove(pnlFilmStrip);
            this.Controls.Remove(pnlPreview);
            this.Controls.Remove(picFilmPicture);
            grdPreview = null;
            pnlFilmStrip = null;
            pnlPreview = null;
            picFilmPicture = null;
        }

        private void SetView(int id)
        {
            if (_currentView == id) return;
            _currentView = id;
            mnuViewDetails.Checked = false;
            mnuViewFilm.Checked = false;
            mnuViewIcons.Checked = false;
            ClearForm();
            switch (id)
            {
                case 1:
                    #region Icons

                    mnuViewIcons.Checked = true;
                    tbbView.Image = global::ClientManage.Properties.Resources.view_icons;
                    pnlPreview = new FlowLayoutPanel();
                    pnlPreview.AutoScroll = true;
                    pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
                    pnlPreview.Location = new System.Drawing.Point(8, 98);
                    pnlPreview.Name = "pnlPreview";
                    pnlPreview.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
                    pnlPreview.Size = new System.Drawing.Size(1008, 662);
                    pnlPreview.TabIndex = 49;
                    pnlPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPreview_MouseDown);
                    this.Controls.Add(pnlPreview);
                    this.Controls.SetChildIndex(pnlPreview, 0);
                    break;

                    #endregion

                case 2:
                    #region FilmStrip

                    mnuViewFilm.Checked = true;
                    tbbView.Image = global::ClientManage.Properties.Resources.view_film;
                    pnlFilmStrip = new FlowLayoutPanel();
                    picFilmPicture = new PictureBox();
                    pnlFilmStrip.AutoScroll = true;
                    pnlFilmStrip.FlowDirection = FlowDirection.TopDown;
                    pnlFilmStrip.Margin = new Padding(0);
                    pnlFilmStrip.Height = 170;
                    pnlFilmStrip.BackColor = Color.FromArgb(232, 237, 243);
                    pnlFilmStrip.Dock = DockStyle.Bottom;
                    pnlFilmStrip.Name = "pnlFilmStrip";
                    pnlFilmStrip.Padding = new Padding(0);
                    pnlFilmStrip.Paint += new PaintEventHandler(pnlFilmStrip_Paint);

                    picFilmPicture.BorderStyle = BorderStyle.FixedSingle;
                    picFilmPicture.BackgroundImageLayout = ImageLayout.Stretch;
                    picFilmPicture.Height = GetFreeHeight() - 10;
                    picFilmPicture.Width = picFilmPicture.Height * 4 / 3;
                    picFilmPicture.Left = (this.Width - picFilmPicture.Width) / 2;
                    picFilmPicture.Top = informationBar1.Height + informationBar1.Top + 4;

                    this.Controls.Add(picFilmPicture);
                    this.Controls.Add(pnlFilmStrip);
                    this.Controls.SetChildIndex(picFilmPicture, 0);
                    this.Controls.SetChildIndex(pnlFilmStrip, 0);
                    break;

                    #endregion

                case 3:
                    #region Details

                    mnuViewDetails.Checked = true;
                    tbbView.Image = global::ClientManage.Properties.Resources.view_list;
                    grdPreview = new DataGridView();
                    ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).BeginInit();
                    clm_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    clmPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    clmImage = new System.Windows.Forms.DataGridViewImageColumn();
                    clm_subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    clm_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    clm_date_create = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    var dataGridViewCellStyle1 = new DataGridViewCellStyle();
                    var dataGridViewCellStyle3 = new DataGridViewCellStyle();
                    var dataGridViewCellStyle2 = new DataGridViewCellStyle();

                    this.grdPreview.AllowUserToAddRows = false;
                    this.grdPreview.AllowUserToDeleteRows = false;
                    this.grdPreview.AllowUserToOrderColumns = true;
                    this.grdPreview.AllowUserToResizeRows = false;
                    this.grdPreview.BackgroundColor = System.Drawing.Color.White;
                    this.grdPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    this.grdPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                    dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                    dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(234)))));
                    dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                    dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    this.grdPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                    this.grdPreview.ColumnHeadersHeight = 30;
                    this.grdPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    this.grdPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                        this.clm_id, this.clmPicture, this.clmImage, this.clm_subject, this.clm_remark, this.clm_date_create});
                    dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                    dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
                    dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                    dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
                    dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                    dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                    dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                    this.grdPreview.DefaultCellStyle = dataGridViewCellStyle3;
                    this.grdPreview.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.grdPreview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
                    this.grdPreview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(206)))));
                    this.grdPreview.Location = new System.Drawing.Point(8, 98);
                    this.grdPreview.Margin = new System.Windows.Forms.Padding(0);
                    this.grdPreview.MultiSelect = false;
                    this.grdPreview.Name = "grdPreview";
                    this.grdPreview.ReadOnly = true;
                    this.grdPreview.RowHeadersVisible = false;
                    this.grdPreview.RowTemplate.Height = 128;
                    this.grdPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                    this.grdPreview.Size = new System.Drawing.Size(1008, 662);
                    this.grdPreview.TabIndex = 63;
                    this.grdPreview.Visible = true;
                    this.grdPreview.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdTest_CellMouseDoubleClick);

                    // 
                    // clm_id
                    // 
                    this.clm_id.DataPropertyName = "Id";
                    this.clm_id.HeaderText = "Id";
                    this.clm_id.Name = "clm_id";
                    this.clm_id.ReadOnly = true;
                    this.clm_id.Visible = false;
                    // 
                    // clmPicture
                    // 
                    this.clmPicture.DataPropertyName = "Picture";
                    this.clmPicture.HeaderText = "Picture";
                    this.clmPicture.Name = "clmPicture";
                    this.clmPicture.ReadOnly = true;
                    this.clmPicture.Visible = false;
                    // 
                    // clmImage
                    // 
                    this.clmImage.HeaderText = "תמונה";
                    this.clmImage.Image = global::ClientManage.Properties.Resources.hourglass_big;
                    this.clmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
                    this.clmImage.Name = "clmImage";
                    this.clmImage.ReadOnly = true;
                    this.clmImage.Width = 170;
                    // 
                    // clm_subject
                    // 
                    this.clm_subject.DataPropertyName = "Subject";
                    this.clm_subject.HeaderText = "תיאור";
                    this.clm_subject.Name = "clm_subject";
                    this.clm_subject.ReadOnly = true;
                    this.clm_subject.Width = 250;
                    // 
                    // clm_remark
                    // 
                    this.clm_remark.DataPropertyName = "Remark";
                    dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                    this.clm_remark.DefaultCellStyle = dataGridViewCellStyle2;
                    this.clm_remark.HeaderText = "הערות";
                    this.clm_remark.Name = "clm_remark";
                    this.clm_remark.ReadOnly = true;
                    this.clm_remark.Width = 390;
                    // 
                    // clm_date_create
                    // 
                    this.clm_date_create.DataPropertyName = "DateCreated";
                    this.clm_date_create.HeaderText = "תאריך";
                    this.clm_date_create.Name = "clm_date_create";
                    this.clm_date_create.ReadOnly = true;
                    this.clm_date_create.Width = 150;

                    grdPreview.DataError += new DataGridViewDataErrorEventHandler(grdPreview_DataError);

                    this.Controls.Add(this.grdPreview);
                    this.Controls.SetChildIndex(this.grdPreview, 0);
                    ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).EndInit();

                    

                    break;

                    #endregion

                default:
                    break;
            }

            LoadData();
        }

        void grdPreview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }

        private void SetDialItems()
        {
            c = ClientHelper.GetClient(_clientId);
            splitPhone.DropDownItems.Clear();
            if (c.CellPhone1.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.CellPhone1), null, splitPhoneItem_ButtonClick);
            if (c.CellPhone2.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.CellPhone2), null, splitPhoneItem_ButtonClick);
            if (c.HomePhone.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.HomePhone), null, splitPhoneItem_ButtonClick);
            if (c.WorkPhone.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.WorkPhone), null, splitPhoneItem_ButtonClick);
            splitPhone.Enabled = splitPhone.DropDownItems.Count > 0;
        }

        public void ClearSelected()
        {
            if (photos.Count == 0) return;
            switch (_currentView)
            {
                case 1:
                    foreach (PhotoPreview item in pnlPreview.Controls)
                    {
                        if (item.Selected) item.Selected = false;
                    }
                    break;

                case 2:
                    break;

                case 3:
                    break;

                default:
                    break;
            }
            
        }

        private ClientPhoto GetSelectedPhoto()
        {
            if (photos.Count == 0) return null;
            ClientPhoto photo = null;

            switch (_currentView)
            {
                case 1:
                    foreach (PhotoPreview item in pnlPreview.Controls)
                    {
                        if (item.Selected)
                        {
                            photo = item.Photo;
                            break;
                        }
                    } 
                    break;

                case 2:
                    foreach (FilmstripPreview item in pnlFilmStrip.Controls)
                    {
                        if (item.Selected)
                        {
                            photo = item.Photo;
                            break;
                        }
                    }
                    break;

                case 3:
                    if (grdPreview.SelectedRows.Count > 0)
                    {
                        photo = (ClientPhoto)grdPreview.SelectedRows[0].Tag;
                    }
                    break;

                default:
                    break;
            }
            

            return photo;
        }

        private void RemovePhoto(int id)
        {           
            for (var i = 0; i < photos.Count; i++)
            {
                if (((ClientPhoto)photos[i]).Id == id)
                {
                    photos.RemoveAt(i);
                    break;
                }
            }
            SetNoItemsLabel();
        }

        private void LoadImages()
        {
            if (photos.Count == 0) return;
            switch (_currentView)
            {
                case 1:
                    foreach (PhotoPreview pp in pnlPreview.Controls)
                    {
                        pp.LoadImage();
                    }
                    break;

                case 2:
                    foreach (FilmstripPreview pp in pnlFilmStrip.Controls)
                    {
                        pp.LoadImage();
                    }
                    break;

                case 3:
                    imageLoader.LoadImages(grdPreview);
                    break;

                default:
                    break;
            }
        }

        private string GetHtmlCode()
        {
            var html = "<table style=\"width: 100%;\">";
            foreach (ClientPhoto p in photos)
            {
                html += p.GetHtmlCode();
            }
            html += "<\table>";

            return html;
        }

        private void ShowNewPhotoDetails()
        {
            ClearSelected();
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmPhotoDetails", _clientId));
        }

            #endregion

        #endregion

        #region Constructor

        public FormPhotoAlbum(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            SetDialItems();
        }

        #endregion

        private void frmPhotoAlbum_Load(object sender, EventArgs e)
        {
            informationBar1.PanelText = "אלבום תמונות ללקוח: " + ClientHelper.GetFullName(_clientId);
            this.Text = informationBar1.PanelText;
            var view = AppSettingsHelper.GetParamValue<int>("PHOTO_ALBUM_LIST_MODE");
            if (view == 0) view = 1;
            imageLoader.LoadThumbnail = false;
            imageLoader.DefaultImage = ClientManage.Properties.Resources.no_client_big;
            SetView(view);
        }

        void pnlFilmStrip_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(212, 217, 223)), 0, 0, pnlFilmStrip.Width, 0);
        }

        void fs_MouseDown(object sender, MouseEventArgs e)
        {
            var item = (FilmstripPreview)sender;
            if (!item.Selected)
            {
                item.Selected = !item.Selected;
                foreach (FilmstripPreview prev in pnlFilmStrip.Controls)
                {
                    if (!item.Equals(prev)) prev.Selected = false;
                }
            }
        }

        void fs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowPhotoDetails();
        }

        void item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowPhotoDetails();
        }

        void item_MouseDown(object sender, MouseEventArgs e)
        {
            var item = (PhotoPreview)sender;
            if (!item.Selected)
            {
                item.Selected = !item.Selected;
                foreach (PhotoPreview prev in pnlPreview.Controls)
                {
                    if (!item.Equals(prev)) prev.Selected = false;
                }
            }
        }

        private void tbbView_ButtonClick(object sender, EventArgs e)
        {
            switch (_currentView)
            {
                case 1:
                    mnuViewFilm_Click(null, null);
                    break;

                case 2:
                    mnuViewDetails_Click(null, null);
                    break;

                case 3:
                    mnuViewIcons_Click(null, null);
                    break;

                default:
                    break;
            }
        }

        private void mnuViewIcons_Click(object sender, EventArgs e)
        {
            SetView(1);
            AppSettingsHelper.SetParamValue("PHOTO_ALBUM_LIST_MODE", "1");
        }

        private void mnuViewDetails_Click(object sender, EventArgs e)
        {
            SetView(3);
            AppSettingsHelper.SetParamValue("PHOTO_ALBUM_LIST_MODE", "3");
        }

        private void mnuViewFilm_Click(object sender, EventArgs e)
        {
            SetView(2);
            AppSettingsHelper.SetParamValue("PHOTO_ALBUM_LIST_MODE", "2");
        }

        private void tbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbbEmail_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetEmailEntity(_clientId, General.EntityType.Client);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void tbbSendSMS_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetSmsEntity(_clientId, General.EntityType.Client);
                var list = General.TableToPostAddresseeList(table);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
                this.Cursor = Cursors.Default;
            }
        }

        private void splitPhone_ButtonClick(object sender, EventArgs e)
        {
            splitPhone.ShowDropDown();
        }
        
        private void splitPhoneItem_ButtonClick(object sender, EventArgs e)
        {
            c = ClientHelper.GetClient(_clientId);
            var name = c.FullName;
            var phone = Utils.DistilPhone(((ToolStripDropDownItem)(sender)).Text);

            if (DialRequest != null)
            {
                var arg = new DialRequestEventArgs(phone, name, c.Id);
                arg.Entity = 0;
                DialRequest(this, arg);
            }
        }

        private void tbbUpdate_Click(object sender, EventArgs e)
        {
            var photo = GetSelectedPhoto();

            string msg1, msg2;
            msg2 = "עדכון תמונת לקוח...";

            if (photo == null)
            {
                msg1 = "לא נבחרה תמונה לעדכון\nסמן תחילה את התמונה הרצויה ולחץ על ''עדכן פרטים''";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return;
            }
            else
            {
                ShowPhotoDetails(photo);
            }
        }

        private void ShowPhotoDetails(ClientPhoto photo)
        {
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmPhotoDetails", photo));
        }

        private void pnlPreview_MouseDown(object sender, MouseEventArgs e)
        {
            ClearSelected();
        }

        private void tbbSetToCard_Click(object sender, EventArgs e)
        {
            var picture = ClientHelper.GetPicture(_clientId);
            string msg1, msg2;
            var photo = GetSelectedPhoto();

            msg2 = "עדכון תמונת לקוח...";

            if (photo == null)
            {
                msg1 = "לא נבחרה תמונה להעברה לכרטיס\nסמן תחילה את התמונה הרצויה ולחץ על ''העבר לכרטיס''";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return;
            }

            if (picture.Length > 0)
            {
                msg1 = "האם אתה בטוח שברצונך להחליף את התמונה\nבכרטיס הלקוח בתמונה המסומנת באלבום";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);
                if (res == DialogResult.No) return;
            }

            try
            {
                var image = Image.FromFile(photo.Picture);
                image = Utils.GetThumbnailImage(image);
                var clientPicture = Utils.SaveImageFile(image);
                image.Dispose();
                var client = ClientHelper.GetClient(_clientId);
                client.Picture = clientPicture;
                ClientHelper.UpdateClient(client);
                if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs(string.Empty, _clientId));
                msg1 = "התמונה עברה בהצלחה";
                MyMessageBox = new MyMessageBox(msg1, msg2);
                MyMessageBox.Show(this);
                ClearSelected();
            }
            catch (Exception ex)
            {
                var title = "שגיאה באלבום תמונות...";
                var head = "העברת תמונה אל כרטיס הלקוח";
                var desc = "העברת התמונה מאלבום התמונות אל כרטיס הלקוח נכשלה\nשים לב כי תמונת הלקוח בכרטיס נשארה כפי שהייתה";
                ClientManage.Library.General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmPhotoAlbum");
            }
        }

        private void tbbDelete_Click(object sender, EventArgs e)
        {
            var photo = GetSelectedPhoto();
            DeletePhoto(photo, this);
        }

        private void tbbPrev_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void tbbNext_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Tab:
                    case Keys.Left:
                        MoveNext();
                        return true;

                    case Keys.Shift | Keys.Tab:
                    case Keys.Right:
                        MovePrevious();
                        return true;

                    case Keys.Enter:
                        ShowPhotoDetails();
                        return true;       
              
                    case Keys.Delete:
                        var photo = GetSelectedPhoto();
                        if (photo != null) DeletePhoto(photo, this);
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmPhotoAlbum_RequestForClose(object sender, EventArgs e)
        {
            if (GetSelectedPhoto() == null || _currentView == 3)
            {
                tbbClose_Click(null, null);
            }
            else
            {
                ClearSelected();
            }
        }

        private void tbbNew_Click(object sender, EventArgs e)
        {
            ShowNewPhotoDetails();
        }

        private void tbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var html = GetHtmlCode();
            var printer = new HtmlPrinter(string.Empty, new string[] { html });
            if (AppSettingsHelper.GetParamValue<bool>("APP_SHOW_PRINTER_DIALOG"))
            {
                printer.ShowPrintDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {
                printer.Print();
                this.Cursor = Cursors.Default;
            }

            printer = null;
        }

        private void frmPhotoAlbum_SizeChanged(object sender, EventArgs e)
        {
            lblNoItems.Left = (this.Width - lblNoItems.Width) / 2;
        }

        private void grdTest_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowPhotoDetails();
        }

        void fs_SelectedChanged(object sender, EventArgs e)
        {
            var item = (FilmstripPreview)sender;
            if (item.Selected)
            {
                var mi = new LoadBigPictureHandler(LoadBigPicture);
                mi.BeginInvoke(item.Photo.Picture, null, null);
            }
        }

        void photos_ListChanged(object sender, PhotoListChangedEventArgs e)
        {
            FilmstripPreview fsItem;
            PhotoPreview ppItem;

            switch (e.ListChangeType)
            {
                case ListChangedType.ItemAdded:
                    switch (_currentView)
                    {
                        #region Icons
                        case 1:

                            ppItem = new PhotoPreview(e.Photo);
                            ppItem.Size = new Size(232, 220);
                            ppItem.MouseDown += new MouseEventHandler(item_MouseDown);
                            ppItem.MouseDoubleClick += new MouseEventHandler(item_MouseDoubleClick);

                            pnlPreview.Controls.Add(ppItem);
                            pnlPreview.Controls.SetChildIndex(ppItem, 0);
                            item_MouseDown(ppItem, null);
                            pnlPreview.ScrollControlIntoView(ppItem);
                            break;

                        #endregion

                        #region FilmSrip
                        case 2:
                            fsItem = new FilmstripPreview(e.Photo);
                            pnlFilmStrip.Controls.Add(fsItem);
                            fsItem.MouseDoubleClick += new MouseEventHandler(fs_MouseDoubleClick);
                            fsItem.MouseDown += new MouseEventHandler(fs_MouseDown);
                            fsItem.SelectedChanged += new EventHandler(fs_SelectedChanged);
                            pnlFilmStrip.Controls.SetChildIndex(fsItem, 0);
                            fs_MouseDown(fsItem, null);
                            pnlFilmStrip.ScrollControlIntoView(fsItem);
                            break;

                        #endregion

                        #region Details
                        case 3:
                            grdPreview.Rows.Insert(0, 1);
                            SetGridRowData(0, e.Photo);
                            imageLoader.LoadSingleImage(grdPreview, 0);
                            break;

                        #endregion
                    }
                    break;
                case ListChangedType.ItemChanged:
                    switch (_currentView)
                    {
                        #region Icons
                        case 1:
                            for (var i = 0; i < pnlPreview.Controls.Count; i++)
                            {
                                ppItem = (PhotoPreview)pnlPreview.Controls[i];
                                if (ppItem.Photo.Id == e.Photo.Id)
                                {
                                    ppItem.RefreshData(e.Photo);
                                    break;
                                }
                            }
                            break;

                        #endregion

                        #region FilmStrip
                        case 2:
                            for (var i = 0; i < pnlFilmStrip.Controls.Count; i++)
                            {
                                fsItem = (FilmstripPreview)pnlFilmStrip.Controls[i];
                                if (fsItem.Photo.Id == e.Photo.Id)
                                {
                                    fsItem.RefreshData(e.Photo);
                                    break;
                                }
                            }
                            break;

                        #endregion

                        #region Details
                        case 3:
                            DataGridViewRow row;
                            for (var i = 0; i < grdPreview.Rows.Count; i++)
                            {
                                row = (DataGridViewRow)grdPreview.Rows[i];
                                if (e.Photo.Id.Equals(row.Cells["clm_id"].Value))
                                {
                                    SetGridRowData(row.Index, e.Photo);
                                    imageLoader.LoadSingleImage(grdPreview, i);
                                    break;
                                }
                            }
                            break;

                        #endregion
                    }
                    break;
                case ListChangedType.ItemDeleted:
                    switch (_currentView)
                    {
                        #region Icons
                        case 1:
                            for (var i = 0; i < pnlPreview.Controls.Count; i++)
                            {
                                ppItem = (PhotoPreview)pnlPreview.Controls[i];
                                if (ppItem.Photo.Id == e.Photo.Id)
                                {
                                    pnlPreview.Controls.Remove(ppItem);
                                    ppItem = null;
                                    break;
                                }
                            }
                            break;

                        #endregion

                        #region FilmStrip
                        case 2:
                            for (var i = 0; i < pnlFilmStrip.Controls.Count; i++)
                            {
                                fsItem = (FilmstripPreview)pnlFilmStrip.Controls[i];
                                if (fsItem.Photo.Id == e.Photo.Id)
                                {
                                    pnlFilmStrip.Controls.Remove(fsItem);
                                    fsItem = null;
                                    break;
                                }
                            }
                            if (pnlFilmStrip.Controls.Count == 0) picFilmPicture.BackgroundImage = null;
                            else fs_MouseDown(pnlFilmStrip.Controls[0], null);
                            break;

                        #endregion

                        #region Details
                        case 3:
                            ClientPhoto p;
                            for (var i = 0; i < grdPreview.Rows.Count; i++)
                            {
                                p = (ClientPhoto)grdPreview.Rows[i].Tag;
                                if (p.Equals(e.Photo))
                                {
                                    grdPreview.Rows.RemoveAt(i);
                                    break;
                                }
                            }
                            break;

                        #endregion
                    }
                    break;
                case ListChangedType.Reset:
                    break;
                default:
                    break;
            }
        }
    }
}