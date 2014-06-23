﻿using System;
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

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : RibbonForm
    {
        ucThongKeChiTiet _ucThongKeChiTiet = new ucThongKeChiTiet();
        ucThongKeTongQuat _ucThongKeTongQuat = new ucThongKeTongQuat();
        ucPhanQuyen _ucPhanQuyen = new ucPhanQuyen();
        ucQuanLyPhong _ucQuanLyPhong = new ucQuanLyPhong();
        ucQuanLyCoSo _ucQuanLyCoSo = new ucQuanLyCoSo();
        ucQuanLyNhanVien _ucQuanLyNhanVien = new ucQuanLyNhanVien();
        ucTreePhong _ucTreePhong;
        ucTreeThongKe _ucTreeThongKe = new ucTreeThongKe();
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
        public frmMain()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Light");
            loadData();
        }

        private void loadData()
        {
            List<ViTriFilter> list = new ViTriFilter().getAllHavePhong();
            _ucTreePhong = new ucTreePhong(list);

            _ucQuanLyPhong.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucQuanLyPhong);
            _ucTreePhong.Dock = DockStyle.Fill;
            _ucTreePhong.Parent = navBarGroupPhong.ControlContainer;
            _ucTreePhong.type = "QLPhong";
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            visibleAllRibbbonPage();
            if (navBarControl1.ActiveGroup.Equals(navBarGroupViTri))
            {
                _ucQuanLyCoSo.loadData();
                rbnPageViTri_Home.Visible = true;
                ribbon.SelectedPage = rbnPageViTri_Home;
                _ucQuanLyCoSo.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyCoSo);
            }
            else if (navBarControl1.ActiveGroup.Equals(navBarGroupNhanVien))
            {
                rbnPageNhanVien_Home.Visible = true;
                ribbon.SelectedPage = rbnPageNhanVien_Home;
                _ucQuanLyNhanVien.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyNhanVien);
                _ucTreePhong.treeListPhong.CollapseAll();
                _ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
            }
            else if (navBarControl1.ActiveGroup.Equals(navBarGroupLoaiTB))
            {
                _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
                rbnPageLoaiTB_Home.Visible = true;
                ribbon.SelectedPage = rbnPageLoaiTB_Home;
                _ucQuanLyLoaiTB.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyLoaiTB);
                _ucTreePhong.treeListPhong.CollapseAll();
                _ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
                _ucQuanLyLoaiTB.reLoad();
            }
            else if (navBarControl1.ActiveGroup.Equals(navBarGroupPhanQuyen))
            {
                rbnPagePhanQuyen_Home.Visible = true;
                ribbon.SelectedPage = rbnPagePhanQuyen_Home;
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
                rbnPagePhong_Home.Visible = true;
                ribbon.SelectedPage = rbnPagePhong_Home;
                _ucQuanLyPhong.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyPhong);
                _ucTreePhong.treeListPhong.CollapseAll();
                _ucTreePhong.Parent = navBarGroupPhong.ControlContainer;
                _ucTreePhong.type = "QLPhong";
            }
        }

        private void visibleAllRibbbonPage()
        {
            rbnPagePhong_Home.Visible = false;
            rbnPageViTri_Home.Visible = false;
            rbnPageNhanVien_Home.Visible = false;
            rbnPageLoaiTB_Home.Visible = false;
            rbnPagePhanQuyen_Home.Visible = false;
            rbnPageThongKe_Home.Visible = false;
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyen frm = new frmChuyen();
            frm.ShowDialog();
        }

        #region QuanLyViTri
        public void enableGroupViTri(String _type)
        {
            switch (_type)
            {
                case "CoSo":
                    rbnGroupViTri_Tang.Enabled = false;
                    barBtnSuaDay.Enabled = false;
                    barBtnXoaDay.Enabled = false;
                    barBtnSuaCoSo.Enabled = true;
                    barBtnXoaCoSo.Enabled = true;
                    break;
                case "Dayy":
                    rbnGroupViTri_Tang.Enabled = true;
                    barBtnSuaDay.Enabled = true;
                    barBtnXoaDay.Enabled = true;
                    barBtnSuaTang.Enabled = false;
                    barBtnXoaTang.Enabled = false;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
                case "Tang":
                    rbnGroupViTri_Tang.Enabled = true;
                    barBtnSuaDay.Enabled = false;
                    barBtnXoaDay.Enabled = false;
                    barBtnSuaTang.Enabled = true;
                    barBtnXoaTang.Enabled = true;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
            }
        }

        private void barBtnSuaCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(CoSo).Name, "edit");
            _ucQuanLyCoSo.setData(typeof(CoSo).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Sửa cơ sở", true);
        }

        private void barBtnSuaDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(Dayy).Name, "edit");
            _ucQuanLyCoSo.setData(typeof(Dayy).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Sửa dãy", true);
        }

        private void barBtnSuaTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(Tang).Name, "edit");
            _ucQuanLyCoSo.setData(typeof(Tang).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Sửa tầng", true);
        }

        private void barBtnXoaCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj(typeof(CoSo).Name);
        }

        private void barBtnXoaDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj(typeof(Dayy).Name);
        }

        private void barBtnXoaTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj(typeof(Tang).Name);
        }

        private void barBtnThemCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(CoSo).Name, "add");
            _ucQuanLyCoSo.beforeAdd(typeof(CoSo).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Thêm cơ sở", true);
        }

        private void barBtnThemDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(Dayy).Name, "add");
            _ucQuanLyCoSo.beforeAdd(typeof(Dayy).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Thêm dãy", true);
        }

        private void barBtnThemTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, typeof(Tang).Name, "add");
            _ucQuanLyCoSo.beforeAdd(typeof(Tang).Name);
            _ucQuanLyCoSo.SetTextGroupControl("Thêm tầng", true);

        }

        private void barBtnThemNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyNhanVien.enableEdit(true, "them");
            _ucQuanLyNhanVien.SetTextGroupControl("Thêm nhân viên");
            _ucQuanLyNhanVien.beforeAdd();
        }

        private void barBtnSuaNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyNhanVien.enableEdit(true, "sua");
            _ucQuanLyNhanVien.SetTextGroupControl("Sửa nhân viên");
            _ucQuanLyNhanVien.beforeEdit();
        }

        private void barBtnXoaNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyNhanVien.deleteObj();

        }
        #endregion

        #region QuanLyPhong
        public void treePhongFocusedNodeChanged(int phongid, int cosoid, int dayid, int tangid)
        {
            if (navBarControl1.ActiveGroup.Equals(navBarGroupPhong))
            {
                _ucQuanLyPhong.setData(phongid, cosoid, dayid, tangid);
            }
        }

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

        public void enableGroupPhong(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "Phong":
                        rbnGroupPhong_Phong.Enabled = true;
                        rbnGroupPhong_Chuyen.Enabled = false;
                        rbnGroupPhong_ThietBi.Enabled = true;
                        barBtnSuaPhong.Enabled = true;
                        barBtnXoaPhong.Enabled = true;
                        barBtnSuaThietBi.Enabled = false;
                        barBtnXoaThietBi.Enabled = false;
                        break;
                    case "ThietBi":
                        rbnGroupPhong_Phong.Enabled = false;
                        rbnGroupPhong_Chuyen.Enabled = true;
                        rbnGroupPhong_ThietBi.Enabled = true;
                        barBtnSuaThietBi.Enabled = true;
                        barBtnXoaThietBi.Enabled = true;
                        break;
                    default:
                        rbnGroupPhong_Phong.Enabled = true;
                        rbnGroupPhong_Chuyen.Enabled = false;
                        rbnGroupPhong_ThietBi.Enabled = false;
                        barBtnSuaPhong.Enabled = false;
                        barBtnXoaPhong.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            { }
            finally
            {}
        }

        private void barBtnThemPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViTri obj = new ViTri();
            obj = _ucTreePhong.getVitri();
            MessageBox.Show(obj.coso.ten + (obj.tang != null ? obj.tang.ten : "") + (obj.day != null ? obj.day.ten : ""));
        }

        private void barBtnSuaPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Phong obj2 = new Phong();
            obj2 = _ucQuanLyPhong.getPhong();
            ViTri obj = obj2.vitri;
            MessageBox.Show(obj2.ten + " " + obj.coso.ten + (obj.day != null ? obj.day.ten : "") + (obj.tang != null ? obj.tang.ten : ""));
        }

        private void barBtnXoaPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Phong obj2 = new Phong();
            obj2 = _ucQuanLyPhong.getPhong();
            ViTri obj = obj2.vitri;
            MessageBox.Show(obj2.ten + " " + obj.coso.ten + (obj.day != null ? obj.day.ten : "") + (obj.tang != null ? obj.tang.ten : ""));
        }

        private void barBtnThemThietBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Phong obj2 = new Phong();
            obj2 = _ucQuanLyPhong.getPhong();
            ViTri obj = obj2.vitri;
            MessageBox.Show(obj2.ten + " " + obj.coso.ten + (obj.day != null ? obj.day.ten : "") + (obj.tang != null ? obj.tang.ten : ""));
            frmNewThietBi frm = new frmNewThietBi();
            frm.ShowDialog();
        }

        private void barBtnSuaThietBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            CTThietBi obj = new CTThietBi();
            obj = _ucQuanLyPhong.getCTThietBi();
            MessageBox.Show(obj.thietbi.ten);
        }

        private void barBtnXoaThietBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            CTThietBi obj = new CTThietBi();
            obj = _ucQuanLyPhong.getCTThietBi();
            MessageBox.Show(obj.thietbi.ten);
        }

        #endregion

        #region QuanLyLoaiThietBi
        public void enableSuaXoa(Boolean enable)
        {
            if (enable)
            {
                barBtnSuaLoaiTB.Enabled = true;
                barBtnXoaLoaiTB.Enabled = true;
            }
            else
            {
                barBtnSuaLoaiTB.Enabled = false;
                barBtnXoaLoaiTB.Enabled = false;
            }
        }

        private void barBtnThemLoaiTB_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyLoaiTB.enableEdit(true, "add");
            _ucQuanLyLoaiTB.SetTextGroupControl("Thêm loại thiết bị", Color.Red);
            _ucQuanLyLoaiTB.beforeAdd();
        }

        private void barBtnSuaLoaiTB_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyLoaiTB.enableEdit(true, "edit");
            _ucQuanLyLoaiTB.SetTextGroupControl("Sửa loại thiết bị", Color.Red);
            _ucQuanLyLoaiTB.addThietBiChaKhiEdit();
            _ucQuanLyLoaiTB.setData();
        }

        private void barBtnXoaLoaiTB_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyLoaiTB.deleteObj();
        }
        #endregion
    }
}