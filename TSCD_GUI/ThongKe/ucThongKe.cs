using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;

namespace TSCD_GUI.ThongKe
{
    public partial class ucThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        ucTKPhong _ucTKPhong = new ucTKPhong();
        ucTKTaiSan _ucTKTaiSan = new ucTKTaiSan();
        Control current = null;

        public ucThongKe()
        {
            InitializeComponent();
            rbnControlThongKe.Parent = null;
            _ucTKPhong.Dock = DockStyle.Fill;
            _ucTKTaiSan.Dock = DockStyle.Fill;
        }

        public RibbonControl getRibbonControl()
        {
            return rbnControlThongKe;
        }

        public void loadData()
        {
            barBtnTKTaiSan.PerformClick();
        }

        private void barBtnTKPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKPhong.Down)
                barBtnTKPhong.Down = true;
            else
            {
                barBtnTKTaiSan.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKPhong);
                current = _ucTKPhong;
                _ucTKPhong.loadData();
            }
        }

        private void barBtnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                _ucTKPhong.ExpandAllGroups();
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                _ucTKTaiSan.ExpandAllGroups();
            }
        }

        private void barBtnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                _ucTKPhong.CollapseAllGroups();
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                _ucTKTaiSan.CollapseAllGroups();
            }
        }

        private void barBtnTKTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKTaiSan.Down)
                barBtnTKTaiSan.Down = true;
            else
            {
                barBtnTKPhong.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKTaiSan);
                current = _ucTKTaiSan;
                _ucTKTaiSan.loadData();
            }
        }

        private void barBtnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKTaiSan))
                _ucTKTaiSan.loadLayout(true);
            else if (current.Equals(_ucTKPhong))
                _ucTKPhong.loadLayout(true);
        }

        private void barBtnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                XtraMessageBox.Show("Thống kê phòng chưa có báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");
                TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung((List<TaiSan_ThongKe>)_ucTKTaiSan.gridControlTaiSan.DataSource);

                ReportPrintTool printTool = new ReportPrintTool(_XtraReport_PhongBan);
                splashScreenManager_Report.CloseWaitForm();
                printTool.ShowPreviewDialog();
            }
        }

        private void barBtnThietKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (current.Equals(_ucTKPhong))
            {
                XtraMessageBox.Show("Thống kê phòng chưa có báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (current.Equals(_ucTKTaiSan))
            {
                splashScreenManager_Report.ShowWaitForm();
                splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");
                TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung((List<TaiSan_ThongKe>)_ucTKTaiSan.gridControlTaiSan.DataSource);
                
                ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);
                splashScreenManager_Report.CloseWaitForm();
                designTool.ShowDesignerDialog();
                

                ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
                printTool.ShowPreviewDialog();
            }
        }
    }
}
