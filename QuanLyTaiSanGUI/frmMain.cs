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
        ucQuanLyPhong uc = new ucQuanLyPhong();
        ucQuanLyCoSo ucCoSo = new ucQuanLyCoSo();
        ucQuanLyNhanVien _ucQuanLyNhanVien = new ucQuanLyNhanVien();
        ucKhac uck = new ucKhac();
        public frmMain()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.PHONGS' table. You can move, or remove it, as needed.
            this.pHONGSTableAdapter.FillBy(this.dataSet1.PHONGS);
            uc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uc);
            uc.LoadDataSet(-1, -1, -1,-1);
            //uc2.Dock = DockStyle.Fill;
            //uc.AddControl(uc2);
            
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int _objid = -1;
            int _obj2id = -1;
            int _obj3id = -1;
            int row = gridViewPhong.FocusedRowHandle;
            if (row < 0 && row > -9999)
            {
                object obj = gridViewPhong.GetGroupRowValue(row);

                int row2 = gridViewPhong.GetParentRowHandle(row);
                if (row2 < 0 && row2 > -9999)
                {
                    object obj2 = gridViewPhong.GetGroupRowValue(row2);
                    int row3 = gridViewPhong.GetParentRowHandle(row2);
                    if (row3 < 0 && row3 > -9999)
                    {
                        object obj3 = gridViewPhong.GetGroupRowValue(row3);
                        _objid = Convert.ToInt32(this.cososTableAdapter1.ScalarQuery(obj3.ToString()));
                        _obj2id = Convert.ToInt32(this.daysTableAdapter1.ScalarQuery(obj2.ToString(), _objid));
                        _obj3id = Convert.ToInt32(this.tangsTableAdapter1.ScalarQuery(obj.ToString(), _obj2id));
                        uc.LoadDataSet(_objid, _obj2id, _obj3id, -1);
                    }
                    else
                    {
                        _objid = Convert.ToInt32(this.cososTableAdapter1.ScalarQuery(obj2.ToString()));
                        _obj2id = Convert.ToInt32(this.daysTableAdapter1.ScalarQuery(obj.ToString(), _objid));
                        uc.LoadDataSet(_objid, _obj2id, -1, -1);
                    }
                }
                else
                {
                    _objid = Convert.ToInt32(this.cososTableAdapter1.ScalarQuery(obj.ToString()));
                    uc.LoadDataSet(_objid, -1, -1, -1);
                }
            }
            else
            {
                int _id = Convert.ToInt32(gridViewPhong.GetFocusedRowCellValue(colid));
                uc.LoadDataSet(-1, -1, -1, _id);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewPhong frm = new frmNewPhong();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewThietBi frm = new frmNewThietBi();
            frm.ShowDialog();
            frmNewThongTinThietBi frm2 = new frmNewThongTinThietBi();
            frm2.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewPhong frm = new frmNewPhong();
            frm.Text = "Sửa phòng";
            frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewThongTinThietBi frm = new frmNewThongTinThietBi();
            frm.Text = "Sửa thiết bị";
            frm.comboBox1.Enabled = true;
            frm.ShowDialog();
        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            visibleAllRibbbonPage();
            if (navBarControl1.ActiveGroup.Name.Equals("navBarGroupViTri"))
            {
                rbnPageViTri_Home.Visible = true;
                ribbon.SelectedPage = rbnPageViTri_Home;
                ucCoSo.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(ucCoSo);
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
                uc.Dock = DockStyle.Fill;
                panelControl1.Controls.Clear();
                panelControl1.Controls.Add(uc);
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
    }
}