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

namespace TSCD_GUI.ReportTSCD
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        List<DonVi> ListDonVi = new List<DonVi>();

        public frmReport()
        {
            InitializeComponent();

            dateEdit_TuNgay.EditValue = DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = DateTime.Today.Date;
            dateEdit_TuNgay.Properties.ReadOnly = true;
            dateEdit_DenNgay.Properties.ReadOnly = true;

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
            if (comboBoxEdit_LoaiBaoCao.SelectedIndex >= 2)
            {
                ucComboBoxDonVi_ChonDonVi.ReadOnly = false;
            }
            else
            {
                ucComboBoxDonVi_ChonDonVi.ReadOnly = true;
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
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    XtraMessageBox.Show("Chức năng này chưa có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        printTool.ShowPreviewDialog();
                        splashScreenManager_Report.CloseWaitForm();
                    }
                    else if (checkEdit_ThietKe.Checked)
                    {
                        splashScreenManager_Report.ShowWaitForm();
                        splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                        splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");
                        TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, ucComboBoxDonVi_ChonDonVi.DonVi), ucComboBoxDonVi_ChonDonVi.DonVi);
                        ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);
                        designTool.ShowDesignerDialog();
                        splashScreenManager_Report.CloseWaitForm();
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