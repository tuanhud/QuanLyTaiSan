using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;
using TSCD.DataFilter.SearchFilter;
using TSCD_GUI.Libraries;
using DevExpress.LookAndFeel;

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();
        int HeightNormal = 270, HeightHaveProgress = 320;

        public delegate void SendMessage();
        public SendMessage _SendMessage;
        System.Threading.Thread _ThreadReport;

        public frmReport()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(this.Size.Width, HeightNormal);

            comboBoxEdit_LoaiBaoCao.SelectedIndex = 0;

            dateEdit_TuNgay.EditValue = DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = DateTime.Today.Date;

            ucComboBoxLoaiTS_LoaiTaiSan.showCheck();
            ucComboBoxLoaiTS_LoaiTaiSan.DataSource = LoaiTSHienThi.Convert(LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten));

            DonVi objNULL = new DonVi();
            ListDonVi = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            objNULL.id = Guid.Empty;
            objNULL.ten = "[Không có đơn vị]";
            objNULL.parent = null;
            ListDonVi.Insert(0, objNULL);
            ucComboBoxDonVi_ChonDonVi.DataSource = ListDonVi;
            ucComboBoxDonVi_ChonDonVi.DonVi = objNULL;

            checkedComboBoxEdit_ChonCoSo.Properties.DataSource = CoSo.getQuery().OrderBy(c => c.order).ToList();
        }

        private void comboBoxEdit_LoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEdit_LoaiBaoCao.SelectedIndex)
            {
                case 0:
                    dateEdit_TuNgay.Enabled = true;
                    dateEdit_DenNgay.Enabled = true;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 1:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    break;
                case 2:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
                case 3:
                    dateEdit_TuNgay.Enabled = false;
                    dateEdit_DenNgay.Enabled = false;
                    ucComboBoxLoaiTS_LoaiTaiSan.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    break;
            }
        }

        private void simpleButton_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Xuat_Click(object sender, EventArgs e)
        {
            switch (comboBoxEdit_LoaiBaoCao.SelectedIndex)
            {
                case 0:
                    if (((DateTime)dateEdit_TuNgay.EditValue).Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (((DateTime)dateEdit_DenNgay.EditValue).Date > DateTime.Today.Date)
                    {
                        XtraMessageBox.Show("Ngày đến không được lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_DenNgay.Focus();
                        return;
                    }
                    if (((DateTime)dateEdit_TuNgay.EditValue).Date > ((DateTime)dateEdit_DenNgay.EditValue).Date)
                    {
                        XtraMessageBox.Show("Ngày từ không được lớn hơn ngày đến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateEdit_TuNgay.Focus();
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_BaoCaoTangGiamTSCD _XtraReport_BaoCaoTangGiamTSCD = new ReportTSCD.XtraReport_BaoCaoTangGiamTSCD(TK_TangGiam_TheoLoaiTS.getAll(((DateTime)dateEdit_TuNgay.EditValue).Date, ((DateTime)dateEdit_DenNgay.EditValue).Date), ((DateTime)dateEdit_TuNgay.EditValue).Date, ((DateTime)dateEdit_DenNgay.EditValue).Date);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_BaoCaoTangGiamTSCD);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_BaoCaoTangGiamTSCD _XtraReport_BaoCaoTangGiamTSCD = new ReportTSCD.XtraReport_BaoCaoTangGiamTSCD(TK_TangGiam_TheoLoaiTS.getAll(((DateTime)dateEdit_TuNgay.EditValue).Date, ((DateTime)dateEdit_DenNgay.EditValue).Date), ((DateTime)dateEdit_TuNgay.EditValue).Date, ((DateTime)dateEdit_DenNgay.EditValue).Date);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_BaoCaoTangGiamTSCD);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    break;
                case 1:
                    List<Guid> ListLoaiTS = ucComboBoxLoaiTS_LoaiTaiSan.list_loaitaisan;
                    if (Object.Equals(ListLoaiTS, null))
                    {
                        XtraMessageBox.Show("Chưa chọn loại tài sản cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!(ListLoaiTS.Count > 0))
                    {
                        XtraMessageBox.Show("Chưa chọn loại tài sản cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<Guid> ListCoSo = CheckedComboBoxEditHelper.getCheckedValueArray(checkedComboBoxEdit_ChonCoSo);
                    if (Object.Equals(ListCoSo, null))
                    {
                        XtraMessageBox.Show("Chưa chọn cơ sở cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!(ListCoSo.Count > 0))
                    {
                        XtraMessageBox.Show("Chưa chọn cơ sở cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(TaiSan_ThongKe.getAll(ListCoSo, ListLoaiTS, null));
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_SoTaiSanCoDinh _XtraReport_SoTaiSanCoDinh = new ReportTSCD.XtraReport_SoTaiSanCoDinh(TaiSan_ThongKe.getAll(ListCoSo, ListLoaiTS, null));
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    break;
                case 2:
                    if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi, null))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi.id, Guid.Empty))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(TaiSanHienThi.Convert(DonViSelected.cttaisans), DonViSelected);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoChiTietTaiSanCoDinh);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            var DonViSelected = ucComboBoxDonVi_ChonDonVi.DonVi;
                            TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(TaiSanHienThi.Convert(DonViSelected.cttaisans), DonViSelected);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoChiTietTaiSanCoDinh);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    break;
                case 3:
                    if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi, null))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (Object.Equals(ucComboBoxDonVi_ChonDonVi.DonVi.id, Guid.Empty))
                    {
                        XtraMessageBox.Show("Chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (checkEdit_XuatBaoCao.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, ucComboBoxDonVi_ChonDonVi.DonVi), ucComboBoxDonVi_ChonDonVi.DonVi);
                            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_PhongBan);

                            ReportCompeleted();

                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        ShowAndHide(false);
                        labelControl_Status.Text = "Đang tạo report, vui lòng chờ trong giây lát...";

                        _ThreadReport = new System.Threading.Thread(() =>
                        {
                            DevExpress.UserSkins.BonusSkins.Register();
                            Application.EnableVisualStyles();
                            UserLookAndFeel.Default.SetSkinStyle(TSCD.Global.local_setting.ApplicationSkinName);
                            DevExpress.Skins.SkinManager.EnableFormSkins();

                            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, ucComboBoxDonVi_ChonDonVi.DonVi), ucComboBoxDonVi_ChonDonVi.DonVi);
                            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);

                            ReportCompeleted();

                            designTool.ShowDesignerDialog();

                            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                            printTool.ShowPreviewDialog();

                            ShowAndHide(true);
                        });
                        _ThreadReport.Start();
                    }
                    break;
                case 4:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }

        private void ShowAndHide(Boolean _Enable)
        {
            if (_Enable)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, HeightNormal);
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Size = new System.Drawing.Size(this.Size.Width, HeightHaveProgress);
                });
            }
            simpleButton_Xuat.Invoke((MethodInvoker)delegate
            {
                simpleButton_Xuat.Enabled = _Enable;
            });

            labelControl_Status.Invoke((MethodInvoker)delegate
            {
                labelControl_Status.Visible = !_Enable;
            });
            marqueeProgressBarControl_Status.Invoke((MethodInvoker)delegate
            {
                marqueeProgressBarControl_Status.Enabled = !_Enable;
                marqueeProgressBarControl_Status.Visible = !_Enable;
            });
            simpleButton_Stop.Invoke((MethodInvoker)delegate
            {
                simpleButton_Stop.Enabled = !_Enable;
                simpleButton_Stop.Visible = !_Enable;
            });
        }

        private void ReportCompeleted()
        {
            labelControl_Status.Invoke((MethodInvoker)delegate
            {
                labelControl_Status.Text = "Đã tạo xong report";
            });
            marqueeProgressBarControl_Status.Invoke((MethodInvoker)delegate
            {
                marqueeProgressBarControl_Status.Enabled = false;
            });
            simpleButton_Stop.Invoke((MethodInvoker)delegate
            {
                simpleButton_Stop.Enabled = false;
            });
        }

        private void KillThread()
        {
            if (!Object.Equals(_ThreadReport, null))
            {
                if (_ThreadReport.IsAlive)
                {
                    _ThreadReport.Abort();
                    _ThreadReport = null;
                }
            }
        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SendMessage();
        }

        private void simpleButton_Stop_Click(object sender, EventArgs e)
        {
            KillThread();
            ShowAndHide(true);
        }

        private void frmReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Object.Equals(_ThreadReport, null))
            {
                KillThread();
            }
        }
    }
}