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
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ucQuanLyPhong _ucQuanLyPhong = new ucQuanLyPhong();
        ucQuanLyCoSo _ucQuanLyCoSo = new ucQuanLyCoSo();
        ucQuanLyNhanVien _ucQuanLyNhanVien = new ucQuanLyNhanVien();
        ucTreePhong _ucTreePhong;
        ucQuanLyLoaiTB _ucQuanLyLoaiTB = new ucQuanLyLoaiTB();
        public frmMain()
        {
            InitializeComponent();
            List<CoSo> list = new CoSo().getAll();
            _ucTreePhong = new ucTreePhong(list);
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            _ucQuanLyPhong.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucQuanLyPhong);
            _ucTreePhong.Dock = DockStyle.Fill;
            _ucTreePhong.Parent = navBarGroupPhong.ControlContainer;
            //_ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
            
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            visibleAllRibbbonPage();
            if (navBarControl1.ActiveGroup.Name.Equals("navBarGroupViTri"))
            {
                rbnPageViTri_Home.Visible = true;
                ribbon.SelectedPage = rbnPageViTri_Home;
                _ucQuanLyCoSo.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyCoSo);
            }
            else if (navBarControl1.ActiveGroup.Name.Equals("navBarGroupNhanVien"))
            {
                rbnPageNhanVien_Home.Visible = true;
                ribbon.SelectedPage = rbnPageNhanVien_Home;
                _ucQuanLyNhanVien.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyNhanVien);
                _ucTreePhong.treeListPhong.CollapseAll();
                _ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
            }
            else if (navBarControl1.ActiveGroup.Name.Equals("navBarGroupLoaiTB"))
            {
                rbnPageLoaiTB_Home.Visible = true;
                ribbon.SelectedPage = rbnPageLoaiTB_Home;
                _ucQuanLyLoaiTB.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyLoaiTB);
                _ucTreePhong.treeListPhong.CollapseAll();
                _ucTreePhong.Parent = navBarGroupNhanVien.ControlContainer;
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
            }
        }

        private void visibleAllRibbbonPage()
        {
            rbnPagePhong_Home.Visible = false;
            rbnPageViTri_Home.Visible = false;
            rbnPageNhanVien_Home.Visible = false;
            rbnPageLoaiTB_Home.Visible = false;
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
                case "coso":
                    rbnGroupViTri_Tang.Enabled = false;
                    barBtnSuaDay.Enabled = false;
                    barBtnXoaDay.Enabled = false;
                    barBtnSuaCoSo.Enabled = true;
                    barBtnXoaCoSo.Enabled = true;
                    break;
                case "day":
                    rbnGroupViTri_Tang.Enabled = true;
                    barBtnSuaDay.Enabled = true;
                    barBtnXoaDay.Enabled = true;
                    barBtnSuaTang.Enabled = false;
                    barBtnXoaTang.Enabled = false;
                    barBtnSuaCoSo.Enabled = false;
                    barBtnXoaCoSo.Enabled = false;
                    break;
                case "tang":
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
            _ucQuanLyCoSo.enableEdit(true, "coso", "edit");
            _ucQuanLyCoSo.beforeEdit("coso");
            _ucQuanLyCoSo.SetTextGroupControl("Sửa cơ sở");
        }

        private void barBtnSuaDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "day", "edit");
            _ucQuanLyCoSo.beforeEdit("day");
            _ucQuanLyCoSo.SetTextGroupControl("Sửa dãy");
        }

        private void barBtnSuaTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "tang", "edit");
            _ucQuanLyCoSo.beforeEdit("tang");
            _ucQuanLyCoSo.SetTextGroupControl("Sửa tầng");
        }

        private void barBtnXoaCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj("coso");
        }

        private void barBtnXoaDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj("day");
        }

        private void barBtnXoaTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.deleteObj("tang");
        }

        private void barBtnThemCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "coso", "add");
            _ucQuanLyCoSo.beforeAdd("coso");
            _ucQuanLyCoSo.SetTextGroupControl("Thêm cơ sở");
        }

        private void barBtnThemDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "day", "add");
            _ucQuanLyCoSo.beforeAdd("day");
            _ucQuanLyCoSo.SetTextGroupControl("Thêm dãy");
        }

        private void barBtnThemTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "tang", "add");
            _ucQuanLyCoSo.beforeAdd("tang");
            _ucQuanLyCoSo.SetTextGroupControl("Thêm tầng");
        }
        #endregion

        #region QuanLyPhong
        public void treePhongFocusedNodeChanged(int phongid, int cosoid, int dayid, int tangid)
        {
            if (navBarControl1.ActiveGroup.Name.Equals("navBarGroupPhong"))
            {
                _ucQuanLyPhong.loadData(phongid, cosoid, dayid, tangid);
            }
        }

        public void enableGroupPhong(String _type)
        {
            try
            {
                switch (_type)
                {
                    case "phong":
                        rbnGroupPhong_Phong.Enabled = true;
                        rbnGroupPhong_Chuyen.Enabled = false;
                        rbnGroupPhong_ThietBi.Enabled = true;
                        barBtnSuaPhong.Enabled = true;
                        barBtnXoaPhong.Enabled = true;
                        barBtnSuaThietBi.Enabled = false;
                        barBtnXoaThietBi.Enabled = false;
                        break;
                    case "thietbi":
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
            obj = _ucTreePhong.getVitri(obj.DB);
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
    }
}