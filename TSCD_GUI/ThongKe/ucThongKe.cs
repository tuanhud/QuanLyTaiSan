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
using TSCD_GUI.ReportTSCD;

namespace TSCD_GUI.ThongKe
{
    public partial class ucThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        ucTKPhong _ucTKPhong = new ucTKPhong();
        ucTKTaiSan _ucTKTaiSan = new ucTKTaiSan();
        ucTKHaoMon _ucTKHaoMon = new ucTKHaoMon();
        ucTKTHPhong _ucTKTHPhong = new ucTKTHPhong();
        ucTKTHTaiSan _ucTKTHTaiSan = new ucTKTHTaiSan();
        Control current = null;

        public ucThongKe()
        {
            InitializeComponent();
            rbnControlThongKe.Parent = null;
            _ucTKPhong.Dock = DockStyle.Fill;
            _ucTKTaiSan.Dock = DockStyle.Fill;
            _ucTKHaoMon.Dock = DockStyle.Fill;
            _ucTKTHPhong.Dock = DockStyle.Fill;
            _ucTKTHTaiSan.Dock = DockStyle.Fill;
        }

        public RibbonControl getRibbonControl()
        {
            return rbnControlThongKe;
        }

        public void loadData()
        {
            barBtnTKPhong.PerformClick();
            barBtnTKTaiSan.PerformClick();
        }

        private void barBtnTKPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKPhong.Down)
                barBtnTKPhong.Down = true;
            else
            {
                barBtnTKTaiSan.Down = false;
                barBtnTKHaoMon.Down = false;
                barBtnTKTHTaiSan.Down = false;
                barBtnTKTHTaiSan.Down = false;
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
                barBtnTKHaoMon.Down = false;
                barBtnTKTHTaiSan.Down = false;
                barBtnTKTHTaiSan.Down = false;
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
            ReportTSCD.frmReport _frmReport = new ReportTSCD.frmReport();
            _frmReport.ShowDialog();
        }

        private void barButtonItemXuatThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (current.Equals(_ucTKPhong))
                {
                    if (Object.Equals(_ucTKPhong.gridControlPhong.DataSource, null))
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (((List<Phong_ThongKe>)_ucTKPhong.gridControlPhong.DataSource).Count > 0)
                    {
                        try
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.WaitFormLoad), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                            splashScreenManager_Report.ShowWaitForm();
                            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKPhong.gridControlPhong);
                            _XtraReportTSCD_Grid.SetTextTitle("Thống Kê Phòng");
                            _XtraReportTSCD_Grid.SetTextTitle_TopRight("");

                            ReportPrintTool printTool = new ReportPrintTool(_XtraReportTSCD_Grid);
                            splashScreenManager_Report.CloseWaitForm();
                            printTool.ShowPreviewDialog();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Đã xảy ra lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (current.Equals(_ucTKTaiSan))
                {
                    if (Object.Equals(_ucTKTaiSan.gridControlTaiSan.DataSource, null))
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (((List<TaiSan_ThongKe>)_ucTKTaiSan.gridControlTaiSan.DataSource).Count > 0)
                    {
                        try
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.WaitFormLoad), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                            splashScreenManager_Report.ShowWaitForm();
                            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKTaiSan.gridControlTaiSan);
                            _XtraReportTSCD_Grid.SetTextTitle("Thống Kê Tài Sản");
                            _XtraReportTSCD_Grid.SetTextTitle_TopRight("");

                            ReportPrintTool printTool = new ReportPrintTool(_XtraReportTSCD_Grid);
                            splashScreenManager_Report.CloseWaitForm();
                            printTool.ShowPreviewDialog();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Đã xảy ra lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Đã xảy ra lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barBtnTKHaoMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKHaoMon.Down)
                barBtnTKHaoMon.Down = true;
            else
            {
                barBtnTKPhong.Down = false;
                barBtnTKTaiSan.Down = false;
                barBtnTKTHTaiSan.Down = false;
                barBtnTKTHTaiSan.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKHaoMon);
                current = _ucTKHaoMon;
                _ucTKHaoMon.loadData();
            }
        }

        private void barBtnTKTHPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKTHPhong.Down)
                barBtnTKTHPhong.Down = true;
            else
            {
                barBtnTKPhong.Down = false;
                barBtnTKTaiSan.Down = false;
                barBtnTKTHTaiSan.Down = false;
                barBtnTKHaoMon.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKTHPhong);
                current = _ucTKTHPhong;
                //_ucTKTHPhong.loadData();
            }
        }

        private void barBtnTKTHTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKTHTaiSan.Down)
                barBtnTKTHTaiSan.Down = true;
            else
            {
                barBtnTKPhong.Down = false;
                barBtnTKTaiSan.Down = false;
                barBtnTKTHPhong.Down = false;
                barBtnTKHaoMon.Down = false;
                panelControlMain.Controls.Clear();
                panelControlMain.Controls.Add(_ucTKTHTaiSan);
                current = _ucTKTHTaiSan;
                _ucTKTHTaiSan.loadData();
            }
        }
    }
}
