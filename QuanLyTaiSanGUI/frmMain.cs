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
using QuanLyTaiSanGUI.MyForm;
using QuanLyTaiSanGUI.QLViTri.MyUserControl;
using QuanLyTaiSanGUI.QLNhanVien;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSanGUI.QLLoaiThietBi;
using QuanLyTaiSanGUI.ThongKe;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSanGUI.HeThong;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.LookAndFeel;
using QuanLyTaiSanGUI.ThongKe;
using QuanLyTaiSanGUI.ThongKe.ChiTiet;
using DevExpress.Skins;
using QuanLyTaiSanGUI.QLThietBi;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : RibbonForm
    {
        ucThongKeChiTiet _ucThongKeChiTiet = new ucThongKeChiTiet();
        ucThongKeTongQuat _ucThongKeTongQuat = new ucThongKeTongQuat();
        ucPhanQuyen _ucPhanQuyen = new ucPhanQuyen();
        ucQuanLyPhong _ucQuanLyPhong = new ucQuanLyPhong();
        ucQuanLyPhongThietBi _ucQuanLyPhongThietBi = new ucQuanLyPhongThietBi();
        ucQuanLyViTri _ucQuanLyViTri = new ucQuanLyViTri();
        ucQuanLyNhanVien _ucQuanLyNhanVien = new ucQuanLyNhanVien();
        ucQuanLyThietBi _ucQuanLyThietBi = new ucQuanLyThietBi();
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
        ucTK_SLTB_TheoTinhTrang _ucTK_SLTB_TheoTinhTrang = new ThongKe.ucTK_SLTB_TheoTinhTrang();
        public frmMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.skin);
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
            addRibbonPage(_ucPhanQuyen.getRibbon());
            addRibbonPage(_ucQuanLyPhong.getRibbon());
            addRibbonPage(_ucQuanLyViTri.getRibbon());
            addRibbonPage(_ucQuanLyNhanVien.getRibbon());
            addRibbonPage(_ucQuanLyThietBi.getRibbon());
            addRibbonPage(_ucQuanLyPhongThietBi.getRibbon());
            //addRibbonPage(_ucTK_SLTB_TheoTinhTrang.getRibbon());
            addRibbonPage(_ucQuanLyLoaiTB.getRibbon());
            //Add Control to NavBar
            //_ucQuanLyThietBi.getTreeList().Parent = navBarGroupThietBi.ControlContainer;
            _ucPhanQuyen.getControl().Parent = navBarGroupPhanQuyen.ControlContainer;
            _ucQuanLyPhong.getTreeList().Parent = navBarGroupPhong.ControlContainer;
            _ucQuanLyPhongThietBi.getTreeList().Parent = navBarGroupPhongThietBi.ControlContainer;
            _ucQuanLyThietBi.getControl().Parent = navBarGroupThietBi.ControlContainer;
            //
            navBarGroupViTri.Expanded = true;
            //navBarGroupLoaiTB.Expanded = true;
            //navBarGroupPhong.Expanded = true;
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            try
            {
                hideAllRibbbonPage();
                if (navBarControl1.ActiveGroup.Equals(navBarGroupViTri))
                {
                    _ucQuanLyViTri.loadData();
                    ribbonMain.Pages.GetPageByName("rbnPageViTri_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageViTri_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyViTri);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupNhanVien))
                {
                    _ucQuanLyNhanVien.loadData();
                    ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyNhanVien);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupLoaiTB))
                {
                    _ucQuanLyLoaiTB.reLoad();
                    ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyLoaiTB);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupThietBi))
                {
                    _ucQuanLyThietBi.loadData(true);
                    ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyThietBi);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupPhongThietBi))
                {
                    _ucQuanLyPhongThietBi.loadData();
                    ribbonMain.Pages.GetPageByName("rbnPagePhongThietbi_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPagePhongThietbi_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyPhongThietBi);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupPhanQuyen))
                {
                    //_ucPhanQuyen.loadData();
                    ribbonMain.Pages.GetPageByName("rbnPagePhanQuyen_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPagePhanQuyen_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucPhanQuyen);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupThongKe))
                {
                    //_ucTK_SLTB_TheoTinhTrang.loadData();
                    rbnPageThongKe_Home.Visible = true;
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucTK_SLTB_TheoTinhTrang);
                }
                else
                {
                    //_ucQuanLyPhong.loadData();
                    ribbonMain.Pages.GetPageByName("rbnPagePhong_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPagePhong_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyPhong);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(this.Name + ": navBarControl1_ActiveGroupChanged :" + ex.Message);
            }
            finally
            { }
        }

        private void hideAllRibbbonPage()
        {
            foreach (RibbonPage page in ribbonMain.Pages)
            {
                page.Visible = false;
            }
        }

        #region Thongke

        public void treeThongKeFocusedNodeChanged(string type)
        {
            switch (type)
            {
                case "Thống kê tổng quát":
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucThongKeTongQuat);
                    break;
                case "Thống kê chi tiết":
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucThongKeChiTiet);
                    break;
                case "Thống kê động":
                    panelControl1.Controls.Clear();
                    //panelControl1.Controls.Add(_ucThongKeTongQuat);
                    break;
            }
        }

        #endregion

        private void addRibbonPage(RibbonControl ribbon)
        {
            for (int i = 0; i < ribbon.Pages.Count; i++)
            {
                ribbonMain.Pages.Add(ribbon.Pages[i]);
            }
        }

        private void navBarControl1_GroupCollapsing(object sender, DevExpress.XtraNavBar.NavBarGroupCancelEventArgs e)
        {
            if (e.Group.Equals(navBarGroupViTri))
            {
                if (_ucQuanLyViTri.working)
                {
                    if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn chuyển sang chức năng khác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (e.Group.Equals(navBarGroupNhanVien))
            {
                if (_ucQuanLyNhanVien.working)
                {
                    if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn chuyển sang chức năng khác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}