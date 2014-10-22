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

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();

        public frmReport()
        {
            InitializeComponent();

            comboBoxEdit_LoaiBaoCao.SelectedIndex = 0;

            dateEdit_TuNgay.EditValue = DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = DateTime.Today.Date;
            dateEdit_TuNgay.Enabled = false;
            dateEdit_DenNgay.Enabled = false;

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
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    break;
                case 1:
                    checkedComboBoxEdit_ChonCoSo.Enabled = true;
                    ucComboBoxDonVi_ChonDonVi.Enabled = false;
                    break;
                case 2:
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
                    break;
                case 3:
                    checkedComboBoxEdit_ChonCoSo.Enabled = false;
                    ucComboBoxDonVi_ChonDonVi.Enabled = true;
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
                    XtraMessageBox.Show("Không có dữ liệu để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    XtraMessageBox.Show("Không có dữ liệu để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        splashScreenManager_Report.ShowWaitForm();
                        splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                        splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                        TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(TaiSanHienThi.Convert(CTTaiSan.getAll()), ucComboBoxDonVi_ChonDonVi.DonVi);
                        ReportPrintTool printTool = new ReportPrintTool(_XtraReport_SoChiTietTaiSanCoDinh);

                        splashScreenManager_Report.CloseWaitForm();
                        printTool.ShowPreviewDialog();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        splashScreenManager_Report.ShowWaitForm();
                        splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                        splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                        TSCD_GUI.ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh _XtraReport_SoChiTietTaiSanCoDinh = new ReportTSCD.XtraReport_SoChiTietTaiSanCoDinh(TaiSanHienThi.Convert(CTTaiSan.getAll()), ucComboBoxDonVi_ChonDonVi.DonVi);
                        ReportDesignTool designTool = new ReportDesignTool(_XtraReport_SoChiTietTaiSanCoDinh);

                        splashScreenManager_Report.CloseWaitForm();
                        designTool.ShowDesignerDialog();

                        ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                        printTool.ShowPreviewDialog();
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
                        splashScreenManager_Report.ShowWaitForm();
                        splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                        splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                        TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, ucComboBoxDonVi_ChonDonVi.DonVi), ucComboBoxDonVi_ChonDonVi.DonVi);
                        ReportPrintTool printTool = new ReportPrintTool(_XtraReport_PhongBan);

                        splashScreenManager_Report.CloseWaitForm();
                        printTool.ShowPreviewDialog();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        splashScreenManager_Report.ShowWaitForm();
                        splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                        splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                        TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, ucComboBoxDonVi_ChonDonVi.DonVi), ucComboBoxDonVi_ChonDonVi.DonVi);
                        ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);

                        splashScreenManager_Report.CloseWaitForm();
                        designTool.ShowDesignerDialog();

                        ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                        printTool.ShowPreviewDialog();
                    }
                    break;
                case 4:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
    }
}