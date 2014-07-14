using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Libraries;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen : UserControl
    {
        List<QuanTriVienFilter> listobjQuanTriVienFilter = new List<QuanTriVienFilter>();
        QuanTriVienFilter objQuanTriVienFilter = new QuanTriVienFilter();
        ucPhanQuyen_Control _ucPhanQuyen_Control = new ucPhanQuyen_Control();
        ucPhanQuyen_Group _ucPhanQuyen_Group = new ucPhanQuyen_Group();
        String function = "";

        public ucPhanQuyen()
        {
            InitializeComponent();
            ribbonPhanQuyen.Parent = null;
            _ucPhanQuyen_Control.Parent = this;
            reLoad();
        }

        private void gridViewPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewPhanQuyen.GetFocusedRow() != null)
            {
                //enableEdit(false, "");
                groupControl1.Text = "Thông tin";
                objQuanTriVienFilter = (QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow();
                //Truyen qua cho View Thong Tin
                setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
                lookUpEdit_group.EditValue = objQuanTriVienFilter.group.id;
            }
        }
        /// <summary>
        /// Goi hien thi len Panel Thong tin chi tiet
        /// </summary>
        /// <param name="objQuanTriVienFilter"></param>
        private void setThongTinChiTiet(QuanTriVien obj)
        {
            txtMaQuanTriVien.Text = obj.subId;
            txtTaiKhoanQuanTriVien.Text = obj.username;
            txtTenQuanTriVien.Text = obj.hoten;
            txtMatKhauQuanTriVien.Text = "";
            txtXacNhanMK.Text = "";
            dateCreated.DateTime = (DateTime)(obj.date_create==null?ServerTimeHelper.getNow():obj.date_create);
            
        }

        public void enableEdit(bool _enable, String _function)
        {
            function = _function;
            if (_enable)
            {
                btnOK.Visible = true;
                btnHuy.Visible = true;
                txtMaQuanTriVien.Properties.ReadOnly = false;
                txtTenQuanTriVien.Properties.ReadOnly = false;
                txtTaiKhoanQuanTriVien.Properties.ReadOnly = false;
                txtMatKhauQuanTriVien.Properties.ReadOnly = false;
                txtXacNhanMK.Properties.ReadOnly = false;
                dateCreated.Properties.ReadOnly = false;
                lookUpEdit_group.Properties.ReadOnly = false;
            }
            else
            {
                btnOK.Visible = false;
                btnHuy.Visible = false;
                txtMaQuanTriVien.Properties.ReadOnly = true;
                txtTenQuanTriVien.Properties.ReadOnly = true;
                txtTaiKhoanQuanTriVien.Properties.ReadOnly = true;
                txtMatKhauQuanTriVien.Properties.ReadOnly = true;
                txtXacNhanMK.Properties.ReadOnly = true;
                dateCreated.Properties.ReadOnly = true;
                lookUpEdit_group.Properties.ReadOnly = true;
            }
        }

        public void reLoad()
        {
            listobjQuanTriVienFilter = QuanTriVienFilter.getAll();
            gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter;
            loadGroup();
        }

        private void dateCreated_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Load DS group cho combobox group
        /// </summary>
        private void loadGroup()
        {
            List<Group> list = Group.getAll();
            lookUpEdit_group.Properties.DataSource = list;
            //lookUpEdit_group.EditValue = list.First().id;
        }

        public RibbonControl getRibbon()
        {
            return ribbonPhanQuyen;
        }

        public PanelControl getControl()
        {
            return _ucPhanQuyen_Control.getControl();
        }

        public void showGroup(bool b)
        {
            splitContainerControl1.Panel1.Controls.Clear();
            splitContainerControl1.Panel2.Controls.Clear();
            if (b)
            {
                splitContainerControl1.Panel1.Controls.Add(_ucPhanQuyen_Group.getLeftControl());
                splitContainerControl1.Panel2.Controls.Add(_ucPhanQuyen_Group.getRightControl());
            }
            else
            {
                splitContainerControl1.Panel1.Controls.Add(gridControlPhanQuyen);
                splitContainerControl1.Panel2.Controls.Add(groupControl1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (function.Equals("edit"))
            {
                objQuanTriVienFilter.quantrivien.username = txtTaiKhoanQuanTriVien.Text;
                objQuanTriVienFilter.quantrivien.date_create = (DateTime)dateCreated.EditValue;
                objQuanTriVienFilter.quantrivien.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                objQuanTriVienFilter.quantrivien.hoten = txtTenQuanTriVien.Text;

                if (!txtMatKhauQuanTriVien.Text.Equals("") && !txtXacNhanMK.Text.Equals(""))
                {
                    int re2 = objQuanTriVienFilter.quantrivien.changePassword(txtMatKhauQuanTriVien.Text, txtXacNhanMK.Text);
                    if (re2 > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không khớp!");
                        return;
                    }
                }

                //call update
                int re = objQuanTriVienFilter.quantrivien.update();
                if (re > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa KHÔNG thành công!");
                    objQuanTriVienFilter.quantrivien = objQuanTriVienFilter.quantrivien.reload();
                }

                

                enableEdit(false, "");
                reLoad();
            }
            else if (function.Equals("add"))
            {
                QuanTriVien obj = new QuanTriVien();
                obj.date_create = (DateTime)dateCreated.EditValue;
                obj.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                obj.hoten = txtTenQuanTriVien.Text;
                obj.mota = "";
                obj.subId = txtMaQuanTriVien.Text;
                obj.username = txtTaiKhoanQuanTriVien.Text;
                if (!txtMatKhauQuanTriVien.Text.Equals(txtXacNhanMK.Text))
                {
                    MessageBox.Show("Mật khẩu KHÔNG khớp!");
                    return;
                }
                obj.hashPassword(txtMatKhauQuanTriVien.Text);
                int re = obj.add();
                if (re > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                }

                //reload
                reLoad();
            }
        }

        private void barButtonSuaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "edit");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enableEdit(false, "");
            setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
        }

        private void barButtonThemQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEdit(true, "add");
            setThongTinChiTiet(new QuanTriVien());
        }

        private void barButtonXoaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int re = objQuanTriVienFilter.quantrivien.delete();
            if (re > 0)
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Xóa KHÔNG thành công");
            }

            //reload
            reLoad();
        }
    }
}
