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

namespace QuanLyTaiSanGUI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ucQuanLyPhong _ucQuanLyPhong = new ucQuanLyPhong();
        ucQuanLyCoSo _ucQuanLyCoSo = new ucQuanLyCoSo();
        ucQuanLyNhanVien _ucQuanLyNhanVien = new ucQuanLyNhanVien();
        ucKhac uck = new ucKhac();
        public frmMain()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            _ucQuanLyPhong.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucQuanLyPhong);
            //uc2.Dock = DockStyle.Fill;
            //uc.AddControl(uc2);
            
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewThietBi frm = new frmNewThietBi();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
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
                ribbon.SelectedPage = rbnPagePhong_Home;
                _ucQuanLyNhanVien.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyNhanVien);
                gridControlPhong.Parent = navBarGroupNhanVien.ControlContainer;
            }
            else
            {
                rbnPagePhong_Home.Visible = true;
                ribbon.SelectedPage = rbnPagePhong_Home;
                _ucQuanLyPhong.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(_ucQuanLyPhong);
            }
        }

        private void visibleAllRibbbonPage()
        {
            rbnPagePhong_Home.Visible = false;
            rbnPageViTri_Home.Visible = false;
            rbnPageNhanVien_Home.Visible = false;
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyen frm = new frmChuyen();
            frm.ShowDialog();
        }

        private void barBtnSuaCoSo_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "coso");
        }

        private void barBtnSuaDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "day");
        }

        private void barBtnSuaTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ucQuanLyCoSo.enableEdit(true, "tang");
        }

        public void enableGroupViTri(bool _day, bool _tang)
        {
            if (_day)
                rbnGroupViTri_Day.Enabled = true;
            else rbnGroupViTri_Day.Enabled = false;
            if (_tang)
                rbnGroupViTri_Tang.Enabled = true;
            else rbnGroupViTri_Tang.Enabled = false;
        }
    }
}