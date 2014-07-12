using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QuanLyTaiSanGUI.MyUserControl;
using DevExpress.XtraGrid.Columns;
using QuanLyTaiSanGUI.QLPhong;
using QuanLyTaiSanGUI.QLViTri.MyUserControl;
using QuanLyTaiSanGUI.QLNhanVien;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSanGUI.QLLoaiThietBi;
using QuanLyTaiSanGUI.ThongKe;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSanGUI.HeThong;
using DevExpress.XtraBars.Ribbon;
using QuanLyTaiSanGUI.ThongKe.ChiTiet;
using QuanLyTaiSanGUI.QLThietBi;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraEditors.Controls;
using QuanLyTaiSan.Libraries;

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : RibbonForm
    {
        ucThongKeChiTiet _ucThongKeChiTiet = null;
        ucThongKeTongQuat _ucThongKeTongQuat = null;
        ucPhanQuyen _ucPhanQuyen = null;
        ucQuanLyPhong _ucQuanLyPhong = null;
        ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = null;
        ucQuanLyViTri _ucQuanLyViTri = null;
        ucQuanLyNhanVien _ucQuanLyNhanVien = null;
        ucQuanLyThietBi _ucQuanLyThietBi = null;
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = null;
        ucTK_SLTB_TheoTinhTrang _ucTK_SLTB_TheoTinhTrang = null;
        bool drawEnd = false;
        bool open = false;
        public frmMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            

            //Việt hóa
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new MyGridLocalizer();
            DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new MyTreeListLocalizer();
            DevExpress.XtraEditors.Controls.Localizer.Active = new MyLocalizer();
            

            _ucThongKeChiTiet = new ucThongKeChiTiet();
            _ucThongKeTongQuat = new ucThongKeTongQuat();
            _ucPhanQuyen = new ucPhanQuyen();
            _ucQuanLyPhong = new ucQuanLyPhong();
            _ucQuanLyPhongThietBi = new ucQuanLyPhongThietBi();
            _ucQuanLyViTri = new ucQuanLyViTri();
            _ucQuanLyNhanVien = new ucQuanLyNhanVien();
            _ucQuanLyThietBi = new ucQuanLyThietBi();
            _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
            _ucTK_SLTB_TheoTinhTrang = new ThongKe.ucTK_SLTB_TheoTinhTrang();

            //UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.skin);
            //DockStyle
            _ucThongKeChiTiet.Dock = DockStyle.Fill;
            _ucThongKeTongQuat.Dock = DockStyle.Fill;
            _ucPhanQuyen.Dock = DockStyle.Fill;
            _ucQuanLyPhong.Dock = DockStyle.Fill;
            _ucQuanLyPhongThietBi.Dock = DockStyle.Fill;
            _ucQuanLyViTri.Dock = DockStyle.Fill;
            _ucQuanLyNhanVien.Dock = DockStyle.Fill;
            _ucQuanLyThietBi.Dock = DockStyle.Fill;
            _ucQuanLyLoaiTB.Dock = DockStyle.Fill;
            _ucTK_SLTB_TheoTinhTrang.Dock = DockStyle.Fill;
            //Add RibbonPage
            //addRibbonPage(_ucThongKeChiTiet.getRibbon());
            //addRibbonPage(_ucThongKeTongQuat.getRibbon());
            addRibbonPage(_ucQuanLyViTri.getRibbon());
            addRibbonPage(_ucQuanLyPhong.getRibbon());
            addRibbonPage(_ucQuanLyPhongThietBi.getRibbon());
            addRibbonPage(_ucQuanLyThietBi.getRibbon());
            addRibbonPage(_ucQuanLyLoaiTB.getRibbon());
            addRibbonPage(_ucQuanLyNhanVien.getRibbon());
            addRibbonPage(_ucPhanQuyen.getRibbon());
            addRibbonPage(_ucTK_SLTB_TheoTinhTrang.getRibbon());
            drawEnd = true;
            ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageThongKe_Home");
            ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageViTri_Home");
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
        }

        private void addRibbonPage(RibbonControl ribbon)
        {
            for (int i = 0; i < ribbon.Pages.Count; i++)
            {
                ribbonMain.Pages.Add(ribbon.Pages[i]);
            }
        }

        private void navBarControl1_GroupCollapsing(object sender, DevExpress.XtraNavBar.NavBarGroupCancelEventArgs e)
        {
        }

        private void ribbonMain_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (drawEnd)
                {
                    DBInstance.reNew();
                    if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageViTri_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyViTri.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyViTri);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyNhanVien.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyNhanVien);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyLoaiTB.reLoad();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyLoaiTB);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyThietBi.getControl().Parent = navBarGroupQLPhong.ControlContainer;
                        _ucQuanLyThietBi.loadData(true);
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyThietBi);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhongThietbi_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyPhongThietBi.getTreeList().Parent = navBarGroupQLPhong.ControlContainer;
                        if(!open)
                            _ucQuanLyPhongThietBi.setPhong(new Phong());
                        _ucQuanLyPhongThietBi.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyPhongThietBi);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhanQuyen_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucPhanQuyen.getControl().Parent = navBarGroupQLPhong.ControlContainer;
                        //_ucPhanQuyen.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucPhanQuyen);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhong_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        _ucQuanLyPhong.getTreeList().Parent = navBarGroupQLPhong.ControlContainer;
                        _ucQuanLyPhong.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucQuanLyPhong);
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageThongKe_Home")))
                    {
                        navBarGroupQLPhong.ControlContainer.Controls.Clear();
                        //_ucTK_SLTB_TheoTinhTrang.loadData();
                        panelControl1.Controls.Clear();
                        panelControl1.Controls.Add(_ucTK_SLTB_TheoTinhTrang);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": ribbonMain_SelectedPageChanged :" + ex.Message);
            }
            finally
            { }
        }

        public void loadDataByPhong(Phong obj)
        {
            open = true;
            _ucQuanLyPhongThietBi.setPhong(obj);
            ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPagePhongThietbi_Home");
            open = false;
        }

        private void backstageViewButtonItemCaiDat_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Setting frm = new Setting(false);
            DialogResult re = frm.ShowDialog();

            //Thoát frm Setting bắt buộc reNew
            DBInstance.reNew();
        }

        private void ribbonMain_SelectedPageChanging(object sender, RibbonPageChangingEventArgs e)
        {
            try
            {
                if (drawEnd)
                {
                    bool working = false;
                    if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageViTri_Home")))
                    {
                        working = _ucQuanLyViTri.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home")))
                    {
                        working = _ucQuanLyNhanVien.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home")))
                    {
                        working = _ucQuanLyLoaiTB.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home")))
                    {
                        working = _ucQuanLyThietBi.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhongThietbi_Home")))
                    {
                        working = _ucQuanLyPhongThietBi.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhanQuyen_Home")))
                    {

                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPagePhong_Home")))
                    {
                        working = _ucQuanLyPhong.working;
                    }
                    else if (ribbonMain.SelectedPage.Equals(ribbonMain.Pages.GetPageByName("rbnPageThongKe_Home")))
                    {

                    }
                    if (working)
                    {
                        if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn chuyển sang chức năng khác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": ribbonMain_SelectedPageChanging :" + ex.Message);
            }
            finally
            { }
        }
    }
}