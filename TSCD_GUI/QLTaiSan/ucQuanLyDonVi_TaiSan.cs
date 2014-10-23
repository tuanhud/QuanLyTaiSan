using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using TSCD.DataFilter;
using DevExpress.XtraGrid.Views.BandedGrid;
using SHARED.Libraries;
using DevExpress.XtraReports.UI;

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyDonVi_TaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        List<TaiSanHienThi> list = new List<TaiSanHienThi>();
        DonVi obj = new DonVi();

        public ucQuanLyDonVi_TaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlDonVi_TaiSan.Parent = null;
            ucTreeDonVi1.focusedNodeChanged = new MyUserControl.ucTreeDonVi.FocusedNodeChanged(reloadData);
            ucGridControlTaiSan1.fileName = this.Name;
            ucGridControlTaiSan1.AlwaysVisibleFindPanel = true;
            ucGridControlTaiSan1.GroupingPhong();
            ucGridControlTaiSan1.createLayout();
        }

        public void loadData(DonVi donvi = null, Phong phong = null)
        {
            try
            {
                ucTreeDonVi1.DataSource = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                if (donvi != null)
                    ucTreeDonVi1.DonVi = donvi;
                reloadData();
                if (phong != null)
                    ucGridControlTaiSan1.ExpandGroupRow(phong.ten);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            try
            {
                reloadData();
                ucGridControlTaiSan1.reloadAndFocused(_id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadAndFocused: " + ex.Message);
            }
        }

        public void reloadData()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang tải dữ liệu...");
            try
            {
                obj = ucTreeDonVi1.DonVi;
                //gridControlTaiSan.DataSource = TaiSanHienThi.getAllByDonVi(obj);
                if (obj != null)
                {
                    list = TaiSanHienThi.Convert(obj.getAllCTTaiSanRecursive());
                    ucGridControlTaiSan1.DataSource = list;

                    bool isEnabled = list.Count > 0;
                    barBtnThemTaiSan.Enabled = true;
                    barBtnSuaTaiSan.Enabled = barBtnXoaTaiSan.Enabled = barBtnChuyen.Enabled = barBtnChuyenTinhTrang.Enabled = isEnabled;
                }
                else
                {
                    ucGridControlTaiSan1.DataSource = null;
                    barBtnThemTaiSan.Enabled = barBtnSuaTaiSan.Enabled = barBtnXoaTaiSan.Enabled = barBtnChuyen.Enabled = barBtnChuyenTinhTrang.Enabled = false;
                }
                ucGridControlTaiSan1.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reloadData: " + ex.Message);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi_TaiSan;
        }

        private void barBtnThemTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DonVi obj = ucTreeDonVi1.DonVi;
            if (obj != null)
            {
                frmAddTaiSanExist frm = new frmAddTaiSanExist(obj);
                frm.reloadAndFocused = new frmAddTaiSanExist.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmInputViTri_DonVi frm = new frmInputViTri_DonVi(obj);
                frm.reloadAndFocused = new frmInputViTri_DonVi.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnSuaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan(obj, true);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        private void barBtnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmLogTaiSan frm = new frmLogTaiSan(obj);
                frm.ShowDialog();
            }
        }

        private void barBtnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
            open.Title = "Chọn tập tin để Import";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                //if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportPhong(open.FileName, "Phong"))
                //{
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    XtraMessageBox.Show("Import thành công!");
                //}
                //else
                //{
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    XtraMessageBox.Show("Import không thành công!");
                //}
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                //DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                //if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportDonVi(open.FileName, "DonVi", ""))
                //{
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    XtraMessageBox.Show("Import thành công!");
                //}
                //else
                //{
                //    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                //    XtraMessageBox.Show("Import không thành công!");
                //}
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitFormLoad), true, true, false);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang Import...");
                if (TSCD_GUI.Libraries.ExcelDataBaseHelper.ImportTaiSan(open.FileName, "TaiSan"))
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import thành công!");
                }
                else
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show("Import không thành công!");
                }
            }
        }

        private void barBtnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.loadLayout(true);
        }

        private void barBtnChuyenTinhTrang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmChuyenTinhTrang frm = new frmChuyenTinhTrang(obj);
                frm.reloadAndFocused = new frmChuyenTinhTrang.ReloadAndFocused(reloadAndFocused);
                frm.ShowDialog();
            }
        }

        /*private void barBtnThietKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager_Report.ShowWaitForm();
            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, obj), obj);
            ReportDesignTool designTool = new ReportDesignTool(_XtraReport_PhongBan);

            splashScreenManager_Report.CloseWaitForm();
            designTool.ShowDesignerDialog();
            
            ReportPrintTool printTool = new ReportPrintTool(designTool.Report);
            printTool.ShowPreviewDialog();
        }*/

        private void barBtnXuatBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTSCD.frmReport _frmReport = new ReportTSCD.frmReport();
            _frmReport.ShowDialog();
            /*splashScreenManager_Report.ShowWaitForm();
            splashScreenManager_Report.SetWaitFormCaption("Đang tạo report");
            splashScreenManager_Report.SetWaitFormDescription("Vui lòng chờ trong giây lát...");

            TSCD_GUI.ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung _XtraReport_PhongBan = new ReportTSCD.XtraReport_SoTheoDoiTSCDTaiNoiSuDung(TaiSan_ThongKe.getAll(null, null, obj), obj);
            ReportPrintTool printTool = new ReportPrintTool(_XtraReport_PhongBan);

            splashScreenManager_Report.CloseWaitForm();
            printTool.ShowPreviewDialog();*/
        }

        private void barBtnXoaTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void deleteObj()
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                if (XtraMessageBox.Show("Tài sản bị xóa sẽ mất log và không thể thống kê được nữa. \n Bạn có chắc là muốn xóa tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (obj.taisan.delete() > 0 && DBInstance.commit() > 0)
                    {
                        XtraMessageBox.Show("Xóa tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void barBtnAttachment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CTTaiSan obj = ucGridControlTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frmFileChungTu frm = new frmFileChungTu(obj.chungtu, true);
                frm.ShowDialog();
            }
        }

        private void barBtnExpandAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.ExpandAllGroups();
        }

        private void barBtnCollapseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGridControlTaiSan1.CollapseAllGroups();
        }
    }
}
