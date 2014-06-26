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
        ucThongKeChiTiet _ucThongKeChiTiet = null;
        ucThongKeTongQuat _ucThongKeTongQuat = null;
        ucPhanQuyen _ucPhanQuyen = null;
        ucQuanLyPhong _ucQuanLyPhong = null;
        ucQuanLyViTri _ucQuanLyCoSo = null;
        ucQuanLyNhanVien _ucQuanLyNhanVien = null;
        ucQuanLyThietBi _ucQuanLyThietBi = null;
        //ucTreePhong _ucTreePhong = new ucTreePhong();
        ucTreeThongKe _ucTreeThongKe = new ucTreeThongKe();
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = null;
        ucTK_SLTB_TheoTinhTrang _ucTK_SLTB_TheoTinhTrang = null;
        public frmMain()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.skin);
            loadData();
        }

        private void loadData()
        {
            //List<ViTriFilter> list = new ViTriFilter().getAllHavePhong();
            //_ucTreePhong.loadData(list);
            //_ucQuanLyPhong.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(_ucQuanLyPhong);
            //_ucTreePhong.Dock = DockStyle.Fill;
            //_ucTreePhong.Parent = navBarGroupPhong.ControlContainer;
            //_ucTreePhong.type = "QLPhong";
            navBarGroupLoaiTB.Expanded = true;
            navBarGroupPhong.Expanded = true;
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            try
            {
                hideAllRibbbonPage();
                if (navBarControl1.ActiveGroup.Equals(navBarGroupViTri))
                {
                    if (_ucQuanLyCoSo == null)
                    {
                        _ucQuanLyCoSo = new ucQuanLyViTri();
                        _ucQuanLyCoSo.Dock = DockStyle.Fill;
                        addRibbonPage(_ucQuanLyCoSo.getRibbon());
                    }
                    else
                    {
                        _ucQuanLyCoSo.reLoad();
                    }
                    ribbonMain.Pages.GetPageByName("rbnPageViTri_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageViTri_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyCoSo);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupNhanVien))
                {
                    if (_ucQuanLyNhanVien == null)
                    {
                        _ucQuanLyNhanVien = new ucQuanLyNhanVien();
                        _ucQuanLyNhanVien.Dock = DockStyle.Fill;
                        addRibbonPage(_ucQuanLyNhanVien.getRibbon());
                    }
                    else
                    {
                        _ucQuanLyNhanVien.reLoad();
                    }
                    ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageNhanVien_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyNhanVien);
                    //cần xem lại
                    //_ucTreePhong.treeListPhong.CollapseAll();
                    //_ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
                    //_ucTreePhong.type = "QLNhanVienPT";
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupLoaiTB))
                {
                    if (_ucQuanLyLoaiTB == null)
                    {
                        _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
                        _ucQuanLyLoaiTB.Dock = DockStyle.Fill;
                        addRibbonPage(_ucQuanLyLoaiTB.getRibbon());
                    }
                    //else
                    //{
                    //    _ucQuanLyLoaiTB.reLoad();
                    //}
                    _ucQuanLyLoaiTB.reLoad();
                    ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageLoaiTB_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyLoaiTB);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupThietBi))
                {
                    if (_ucQuanLyThietBi == null)
                    {
                        _ucQuanLyThietBi = new ucQuanLyThietBi();
                        _ucQuanLyThietBi.Dock = DockStyle.Fill;
                        addRibbonPage(_ucQuanLyThietBi.getRibbon());
                        _ucQuanLyThietBi.getTreeList().Parent = navBarGroupThietBi.ControlContainer;
                    }
                    else
                    {
                        //_ucQuanLyLoaiTB.reLoad();
                    }
                    ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPageThietBi_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyThietBi);
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupPhanQuyen))
                {
                    if (_ucPhanQuyen == null)
                    {
                        _ucPhanQuyen = new ucPhanQuyen();
                    }
                    rbnPagePhanQuyen_Home.Visible = true;
                    ribbonMain.SelectedPage = rbnPagePhanQuyen_Home;
                    _ucPhanQuyen.Dock = DockStyle.Fill;
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucPhanQuyen);
                    //_ucTreePhong.treeListPhong.CollapseAll();
                    //_ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
                }
                else if (navBarControl1.ActiveGroup.Equals(navBarGroupThongKe))
                {
                    if (_ucTK_SLTB_TheoTinhTrang == null)
                    {
                        _ucTK_SLTB_TheoTinhTrang = new ThongKe.ucTK_SLTB_TheoTinhTrang();
                        _ucTK_SLTB_TheoTinhTrang.Dock = DockStyle.Fill;
                    }
                    rbnPageThongKe_Home.Visible = true;
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucTK_SLTB_TheoTinhTrang);
                }
                else
                {
                    if (_ucQuanLyPhong == null)
                    {
                        _ucQuanLyPhong = new ucQuanLyPhong();
                        _ucQuanLyPhong.Dock = DockStyle.Fill;
                        _ucQuanLyPhong.getTreeList().Parent = navBarGroupPhong.ControlContainer;
                        addRibbonPage(_ucQuanLyPhong.getRibbon());
                    }
                    else
                    {
                        _ucQuanLyPhong.reLoadAll();
                    }
                    ribbonMain.Pages.GetPageByName("rbnPagePhong_Home").Visible = true;
                    ribbonMain.SelectedPage = ribbonMain.Pages.GetPageByName("rbnPagePhong_Home");
                    panelControl1.Controls.Clear();
                    panelControl1.Controls.Add(_ucQuanLyPhong);

                    //_ucTreePhong.treeListPhong.CollapseAll();
                    //_ucTreePhong.Parent = navBarGroupPhong.ControlContainer;
                    //_ucTreePhong.type = "QLPhong";
                    //List<ViTriFilter> list = new ViTriFilter().getAllHavePhong();
                    //_ucTreePhong.loadData(list);
                }
            }
            catch (Exception ex)
            { }
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

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyen frm = new frmChuyen();
            frm.ShowDialog();
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
                if (_ucQuanLyCoSo.working)
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