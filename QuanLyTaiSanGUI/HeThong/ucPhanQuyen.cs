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
using System.Data.Entity.Validation;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen : UserControl
    {
        private List<QuanTriVienFilter> listobjQuanTriVienFilter = null;
        private QuanTriVienFilter objQuanTriVienFilter = null;
        private ucPhanQuyen_Control _ucPhanQuyen_Control = new ucPhanQuyen_Control();
        private ucPhanQuyen_Group _ucPhanQuyen_Group = new ucPhanQuyen_Group();
        private String function = "";

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
                groupControl1.Text = "Thông tin";
                objQuanTriVienFilter = (QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow();
                //Truyen qua cho View Thong Tin
                setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
            }
        }
        /// <summary>
        /// Goi hien thi len Panel Thong tin chi tiet
        /// </summary>
        /// <param name="objQuanTriVienFilter"></param>
        private void setThongTinChiTiet(QuanTriVien obj)
        {
            if (obj == null)
            {
                return;
            }
            txtMaQuanTriVien.Text = obj.subId;
            txtTaiKhoanQuanTriVien.Text = obj.username;
            txtTenQuanTriVien.Text = obj.hoten;
            txtMatKhauQuanTriVien.Text = txtXacNhanMK.Text = "";
            memoEdit_mota.Text = obj.mota;
            dateCreated.DateTime = (DateTime)(obj.date_create==null?ServerTimeHelper.getNow():obj.date_create);
            if (obj.group != null)
            {
                lookUpEdit_group.EditValue = obj.group.id;
            }
            enableEdit(false, "");
        }

        public void enableEdit(bool _enable, String _function)
        {
            this.function = _function;
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
                memoEdit_mota.Properties.ReadOnly = false;
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
                memoEdit_mota.Properties.ReadOnly = true;
            }
        }

        public void reLoad()
        {
            gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter = QuanTriVienFilter.getAll();
            reloadGroup();
            if (objQuanTriVienFilter != null)
            {
                setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
            }
            dxErrorProvider1.ClearErrors();
        }

        private void dateCreated_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Load DS group cho combobox group
        /// </summary>
        private void reloadGroup()
        {
            lookUpEdit_group.Properties.DataSource = Group.getAll();
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
                objQuanTriVienFilter.quantrivien.mota = memoEdit_mota.Text;
                //always try to change pass first
                int re2 = objQuanTriVienFilter.quantrivien.changePassword(txtMatKhauQuanTriVien.Text, txtXacNhanMK.Text);
                if (re2 > 0 || (txtMatKhauQuanTriVien.Text.Equals("") && txtXacNhanMK.Text.Equals("")))
                {

                }
                else
                {
                    dxErrorProvider1.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                    dxErrorProvider1.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                }

                //call update
                int re = objQuanTriVienFilter.quantrivien.update();
                if (re > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    reLoad();
                }
                else
                {
                    MessageBox.Show("Sửa KHÔNG thành công!");
                    //showValidationError();
                    //objQuanTriVienFilter.quantrivien = objQuanTriVienFilter.quantrivien.reload();
                    return;
                }                
            }
            else if (function.Equals("add"))
            {
                QuanTriVien obj = new QuanTriVien();
                obj.date_create = (DateTime)dateCreated.EditValue;
                obj.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                obj.hoten = txtTenQuanTriVien.Text;
                obj.mota = memoEdit_mota.Text;
                obj.subId = txtMaQuanTriVien.Text;
                obj.username = txtTaiKhoanQuanTriVien.Text;
                if (!txtMatKhauQuanTriVien.Text.Equals(txtXacNhanMK.Text))
                {
                    dxErrorProvider1.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                    dxErrorProvider1.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                    return;
                }
                obj.hashPassword(txtMatKhauQuanTriVien.Text);
                int re = obj.add();
                if (re > 0)
                {
                    MessageBox.Show("Thêm thành công!");

                    //reload
                    reLoad();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                    return;
                }

            }
        }
        //private void showValidationError()
        //{
        //    foreach (var tmp in DBInstance.DB.GetValidationErrors())
        //    {
        //        foreach (var item in tmp.ValidationErrors)
        //        {
        //            if (item.PropertyName.Equals("username"))
        //            {
        //                dxErrorProvider1.SetError(txtTaiKhoanQuanTriVien, item.ErrorMessage);
        //            }
        //        }
        //    }
        //}
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
        private void clearThongTinChiTiet()
        {
            memoEdit_mota.Text = txtXacNhanMK.Text =  txtTenQuanTriVien.Text = txtTaiKhoanQuanTriVien.Text = txtMatKhauQuanTriVien.Text = txtMaQuanTriVien.Text = "";
        }
    }
}
