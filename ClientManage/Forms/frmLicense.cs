using System;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormLicense : BasePopupForm
    {
        #region Events

        #endregion

        #region Private Memebers
        
        // hold the security validation result
        private readonly Security.ValidationResult _status;
        
        // hold the days the license remain
        private static int _expireDays = -1;

        private DialogResult _result = DialogResult.OK;

        #endregion

        #region Constructor
        
        // initialize components and variables
        public FormLicense(Security.ValidationResult status)
        {
            InitializeComponent();
            _status = status;
        }
        
        #endregion

        #region Properties
        
        // property, hold the expire days that remain in license
        public static int ExpireDays
        {
            get { return _expireDays; }
            set { _expireDays = value; }
        } 


        #endregion

        #region Private Functions
        #endregion

        #region Controls Event
      
        // initialize form text according license validation result
        private void FrmLicence_Load(object sender, EventArgs e)
        {
            this.Height -= panel1.Height;
            base.CenterMe();
            var msg = string.Empty;

            switch (_status)
            {
                case Security.ValidationResult.LicenseNotFound:
                    msg = "���� ������ �� ������ ��� �� ����,\n�� ��� ������ ���� �� ���� ������ �������.";
                    button2.Enabled = false;
                    break;

                case Security.ValidationResult.DateTraceError:
                    msg = "����� ����� ������� ������ �� ������,  �� ��� ������ ���� �� ���� ������ �������.";
                    break;

                case Security.ValidationResult.NowAfterEnd:
                    msg = "����� ����� ������ ������� �� ���� ���� �����,  �� ��� ������ ���� �� ���� ������ �������.";
                    break;

                case Security.ValidationResult.NowBeforeStart:
                    msg = "����� ����� ������ ������� ���� �����,  �� ��� ������ ���� �� ���� ������ �������.";
                    break;

                case Security.ValidationResult.WrongCpuId:
                    msg = "����� ������ ���� ���� �� ����� ������� ���,  �� ��� ������ ���� �� ���� ������ �������";
                    break;

                case Security.ValidationResult.SoonExpire:
                    if (_expireDays > 1)
                    {
                        msg = "��� ��! ����� ����� ������ ������� ���� ����...   " + _expireDays + " ����";
                    }
                    else if (_expireDays == 1)
                    {
                        msg = "��� ��! ����� ����� ������ ������� ���� ����.   ���� �� ���� �������...   ";
                    }
                    break;
            }

            lblInfo.Text = msg;
            lblManager.Text = AppSettingsHelper.GetParamValue("APP_SYSTEM_MGR");
            txtCpuId.Text = Security.CpuId;
            licenseInfo1.ShowLicenseInfo(Utils.CurrentLicense);
        }

        // show message box with license details
        private void Button2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                this.Height -= panel1.Height;
                this.Refresh();
                button2.Text = "��� ���� �����...";
            }
            else
            {
                panel1.Visible = true;
                this.Height += panel1.Height;
                this.Refresh();
                button2.Text = "���� ���� �����";
            }

            base.CenterMe();
        }

        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _result;
        }

        private void FormLicense_Activated(object sender, EventArgs e)
        {
            switch (_status)
            {
                case Security.ValidationResult.SoonExpire:
                case Security.ValidationResult.Ok:
                    break;

                case Security.ValidationResult.WrongCpuId:
                    var result3 = LicenseManager.GetLicenseOnline();
                    if (result3.Item1 == null) return;
                    var cpuId = Security.CpuId;
                    if (!string.IsNullOrEmpty(result3.Item1.LicenseKey) && result3.Item1.LicenseKey == cpuId)
                    {
                        LicenseManager.UpdateLicense(result3.Item1.LicenseKey);
                        _result = DialogResult.Retry;
                        this.Close();
                    }
                    break;

                case Security.ValidationResult.NowBeforeStart:
                case Security.ValidationResult.NowAfterEnd:
                    var result1 = LicenseManager.CheckForEndLicenseOnline();
                    if (result1 == LicenseManager.OnlineLicenseStatus.Valid)
                    {
                        _result = DialogResult.Retry;
                        this.Close();
                    }
                    break;

                case Security.ValidationResult.DateTraceError:
                    var result2 = LicenseManager.GetLicenseOnline();
                    if (result2.Item1 == null) return;
                    if (result2.Item1.ServerDate.Date == DateTime.Now.Date)
                    {
                        if (result2.Item2 == LicenseManager.OnlineLicenseStatus.Valid)
                        {
                            _result = DialogResult.Retry;
                            this.Close();
                        }
                    }
                    break;
                case Security.ValidationResult.LicenseNotFound:
                    var result4 = LicenseManager.GetLicenseOnline();
                    if (result4.Item1 == null) return;

                    if (!string.IsNullOrEmpty(result4.Item1.LicenseKey))
                    {
                        LicenceHelper.ClearAllLicenses();
                        var licence = Security.GetNewLicense();
                        var row = licence.License[0];
                        row.cpu_id = result4.Item1.LicenseKey;
                        row.from_date = result4.Item1.FromDate.HasValue ? result4.Item1.FromDate.Value : result4.Item1.ServerDate.AddMonths(-1).AddDays(-result4.Item1.ServerDate.Day + 1);
                        row.to_date = result4.Item1.ToDate.HasValue ? result4.Item1.ToDate.Value : result4.Item1.ServerDate.AddMonths(3).AddDays(-result4.Item1.ServerDate.Day + 1);
                        row.last_used = result4.Item1.ServerDate.AddDays(-1);
                        row.type = "Standard";
                        row.key = "0000";
                        var xml = Security.SaveLicence(licence);
                        LicenceHelper.AddLicense(xml);
                    }
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}