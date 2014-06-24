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
using QuanLyTaiSanGUI.QLCoSo.MyUserControl;
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

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : RibbonForm
    {
        ucThongKeChiTiet _ucThongKeChiTiet = null;
        ucThongKeTongQuat _ucThongKeTongQuat = null;
        ucPhanQuyen _ucPhanQuyen = null;
        ucQuanLyPhong _ucQuanLyPhong = null;
        ucQuanLyCoSo _ucQuanLyCoSo = null;
        ucQuanLyNhanVien _ucQuanLyNhanVien = null;
        ucQuanLyThietBi _ucQuanLyThietBi = null;
        //ucTreePhong _ucTreePhong = new ucTreePhong();
        ucTreeThongKe _ucTreeThongKe = new ucTreeThongKe();
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = null;
        public frmMain()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
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
                        _ucQuanLyCoSo = new ucQuanLyCoSo();
                        _ucQuanLyCoSo.Dock = DockStyle.Fill;
                        addRibbonPage(_ucQuanLyCoSo.getRibbon());
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
                    //rbnPageThongKe_Home.Visible = true;
                    //ribbon.SelectedPage = rbnPageThongKe_Home;
                    //_ucThongKe.Dock = DockStyle.Fill;
                    //panelControl1.Controls.Clear();
                    //panelControl1.Controls.Add(_ucThongKe);
                    //_ucTreeThongKe.Parent = navBarGroupThongKe.ControlContainer;
                    //_ucTreePhong.treeListPhong.CollapseAll();
                    //_ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
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
    }
}