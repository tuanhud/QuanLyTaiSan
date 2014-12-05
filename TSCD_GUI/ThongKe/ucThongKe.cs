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
        ucTKPhong _ucTKPhong = null;
        ucTKTaiSan _ucTKTaiSan = null;
        ucTKHaoMon _ucTKHaoMon = null;
        ucTKTHPhong _ucTKTHPhong = null;
        ucTKTHTaiSan _ucTKTHTaiSan = null;
        Control current = null;

        public ucThongKe()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            _ucTKPhong = new ucTKPhong();
            _ucTKTaiSan = new ucTKTaiSan();
            _ucTKHaoMon = new ucTKHaoMon();
            _ucTKTHPhong = new ucTKTHPhong();
            _ucTKTHTaiSan = new ucTKTHTaiSan();

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
            barBtnTKTHPhong.PerformClick();
            barBtnTKTHTaiSan.PerformClick();
        }

        private void barBtnTKPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!barBtnTKPhong.Down)
                barBtnTKPhong.Down = true;
            else
            {
                barBtnTKTaiSan.Down = false;
                barBtnTKHaoMon.Down = false;
                barBtnTKTHPhong.Down = false;
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
            else if (current.Equals(_ucTKHaoMon))
            {
                _ucTKHaoMon.ExpandAllGroups();
            }
            else if (current.Equals(_ucTKTHPhong))
            {
                _ucTKTHPhong.ExpandAllGroups();
            }
            else if (current.Equals(_ucTKTHTaiSan))
            {
                _ucTKTHTaiSan.ExpandAllGroups();
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
            else if (current.Equals(_ucTKHaoMon))
            {
                _ucTKHaoMon.CollapseAllGroups();
            }
            else if (current.Equals(_ucTKTHPhong))
            {
                _ucTKTHPhong.CollapseAllGroups();
            }
            else if (current.Equals(_ucTKTHTaiSan))
            {
                _ucTKTHTaiSan.CollapseAllGroups();
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
                barBtnTKTHPhong.Down = false;
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
            else if (current.Equals(_ucTKTHPhong))
                _ucTKTHPhong.loadLayout(true);
            else if (current.Equals(_ucTKTHTaiSan))
                _ucTKTHTaiSan.loadLayout(true);
            else if (current.Equals(_ucTKHaoMon))
                _ucTKHaoMon.loadLayout(true);
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

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKPhong.gridControlPhong, false);
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

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKTaiSan.gridControlTaiSan, false);
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
                else if (current.Equals(_ucTKHaoMon))
                {
                    if (Object.Equals(_ucTKHaoMon.gridControlHaoMon.DataSource, null))
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (((List<TaiSanHienThi>)_ucTKHaoMon.gridControlHaoMon.DataSource).Count > 0)
                    {
                        try
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.WaitFormLoad), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                            splashScreenManager_Report.ShowWaitForm();
                            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKHaoMon.gridControlHaoMon, false);
                            _XtraReportTSCD_Grid.SetTextTitle("Thống Kê Hao Mòn");
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
                else if (current.Equals(_ucTKTHPhong))
                {
                    if (Object.Equals(_ucTKTHPhong.gridControlPhong.DataSource, null))
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (((List<Phong_ThongKe>)_ucTKTHPhong.gridControlPhong.DataSource).Count > 0)
                    {
                        try
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.WaitFormLoad), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                            splashScreenManager_Report.ShowWaitForm();
                            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKTHPhong.gridControlPhong, false);
                            _XtraReportTSCD_Grid.SetTextTitle("Thống Kê Tổng Hợp Phòng");
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
                else if (current.Equals(_ucTKTHTaiSan))
                {
                    if (Object.Equals(_ucTKTHTaiSan.gridControlTaiSan.DataSource, null))
                    {
                        XtraMessageBox.Show("Chưa có dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (((List<TaiSanHienThi>)_ucTKTHTaiSan.gridControlTaiSan.DataSource).Count > 0)
                    {
                        try
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager_Report = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSCD_GUI.WaitFormLoad), true, true, DevExpress.XtraSplashScreen.ParentType.UserControl);
                            splashScreenManager_Report.ShowWaitForm();
                            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
                            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

                            XtraReportTSCD_Grid _XtraReportTSCD_Grid = new XtraReportTSCD_Grid(_ucTKTHTaiSan.gridControlTaiSan, false);
                            _XtraReportTSCD_Grid.SetTextTitle("Thống Kê Tổng Hợp Tài Sản");
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
                barBtnTKTHPhong.Down = false;
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
                _ucTKTHPhong.loadData();
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
