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
using SHARED.Libraries;
using QuanLyTaiSan;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen : UserControl, _ourUcInterface
    {
        private List<QuanTriVienFilter> listobjQuanTriVienFilter = null;
        private QuanTriVienFilter objQuanTriVienFilter = null;
        private ucPhanQuyen_Control _ucPhanQuyen_Control = new ucPhanQuyen_Control();
        private ucPhanQuyen_Group _ucPhanQuyen_Group = new ucPhanQuyen_Group();
        private String function = "";
        private bool working = false;
        private bool show = false;

        public ucPhanQuyen()
        {
            InitializeComponent();
            ribbonPhanQuyen.Parent = null;
            _ucPhanQuyen_Control.Parent = this;
            rbnGroupGroup.Visible = false;
            _ucPhanQuyen_Group.EnableButton2 = new ucPhanQuyen_Group.enableButton2(enableButton2);
            reLoad();
        }

        private void gridViewPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ////reload old object, discard changes
                //if (objQuanTriVienFilter != null && objQuanTriVienFilter.quantrivien != null)
                //{
                //    objQuanTriVienFilter.quantrivien = objQuanTriVienFilter.quantrivien.reload();
                //}

                if (gridViewPhanQuyen.GetFocusedRow() != null)
                {
                    groupControl1.Text = "Thông tin";
                    objQuanTriVienFilter = (QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow();
                    //Truyen qua cho View Thong Tin
                    setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->gridViewPhanQuyen_FocusedRowChanged: " + ex.Message);
            }
        }

        public void editGUI(String _type)
        {
            this.function = _type;
            if (_type.Equals("view"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm quản trị viên", Color.Red);
                enableEdit(true);
                clearText();
                txtMaQuanTriVien.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa quản trị viên", Color.Red);
                enableEdit(true);
                txtMaQuanTriVien.Focus();
            }
        }

        private void SetTextGroupControl(String text, Color color)
        {
            groupControl1.Text = text;
            groupControl1.AppearanceCaption.ForeColor = color;
        }

        private void enableEdit(bool _enable)
        {
            btnOK.Visible = _enable;
            btnHuy.Visible = _enable;
            txtMaQuanTriVien.Properties.ReadOnly = !_enable;
            txtTenQuanTriVien.Properties.ReadOnly = !_enable;
            txtTaiKhoanQuanTriVien.Properties.ReadOnly = !_enable;
            txtMatKhauQuanTriVien.Properties.ReadOnly = !_enable;
            txtXacNhanMK.Properties.ReadOnly = !_enable;
            dateCreated.Properties.ReadOnly = !_enable;
            lookUpEdit_group.Properties.ReadOnly = !_enable;
            memoEdit_mota.Properties.ReadOnly = !_enable;
            barButtonThemQTV.Enabled = !_enable;
            enableButton(!_enable);
            working = _enable;
        }

        private void enableButton(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            barButtonSuaQTV.Enabled = _enable;
            barButtonXoaQTV.Enabled = _enable;
        }

        private void enableButton2(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            barBtnThemGroup.Enabled = _enable;
            barBtnSuaGroup.Enabled = _enable;
            barBtnXoaGroup.Enabled = _enable;
        }

        private void clearText()
        {
            txtMaQuanTriVien.Text = "";
            txtTenQuanTriVien.Text = "";
            txtTaiKhoanQuanTriVien.Text = "";
            txtMatKhauQuanTriVien.Text = "";
            txtXacNhanMK.Text = "";
            dateCreated.DateTime = DateTime.Now;
            //lookUpEdit_group
            memoEdit_mota.Text = "";
        }


        /// <summary>
        /// Goi hien thi len Panel Thong tin chi tiet
        /// </summary>
        /// <param name="objQuanTriVienFilter"></param>
        private void setThongTinChiTiet(QuanTriVien obj)
        {
            try
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
                dateCreated.DateTime = (DateTime)(obj.date_create == null ? ServerTimeHelper.getNow() : obj.date_create);
                if (obj.group != null)
                {
                    lookUpEdit_group.EditValue = obj.group.id;
                }
                editGUI("view");
                dxErrorProvider1.ClearErrors();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setThongTinChiTiet: " + ex.Message);
            }
        }

        public void reLoad()
        {
            try
            {
                gridControlPhanQuyen.DataSource = null;
                gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter = QuanTriVienFilter.getAll();
                reloadGroup();
                if (objQuanTriVienFilter != null)
                {
                    setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reLoad: " + ex.Message);
            }
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

        public bool showGroup(bool b)
        {
            if (checkworking())
            {
                if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn chuyển sang chức năng khác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return false;
                }
            }
            show = b;
            rbnGroupGroup.Visible = b;
            rbnGroupQTV.Visible = !b;
            splitContainerControl1.Panel1.Controls.Clear();
            splitContainerControl1.Panel2.Controls.Clear();
            if (b)
            {
                splitContainerControl1.Panel1.Controls.Add(_ucPhanQuyen_Group.getLeftControl());
                splitContainerControl1.Panel2.Controls.Add(_ucPhanQuyen_Group.getRightControl());
                _ucPhanQuyen_Group.loadData();
            }
            else
            {
                splitContainerControl1.Panel1.Controls.Add(gridControlPhanQuyen);
                splitContainerControl1.Panel2.Controls.Add(groupControl1);
                editGUI("view");
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.Equals("edit"))
                {
                    //objQuanTriVienFilter.quantrivien = objQuanTriVienFilter.quantrivien.reload();

                    objQuanTriVienFilter.quantrivien.username = txtTaiKhoanQuanTriVien.Text;
                    objQuanTriVienFilter.quantrivien.date_create = (DateTime)dateCreated.EditValue;
                    objQuanTriVienFilter.quantrivien.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                    objQuanTriVienFilter.quantrivien.hoten = txtTenQuanTriVien.Text;
                    objQuanTriVienFilter.quantrivien.mota = memoEdit_mota.Text;
                    //try to change pass first
                    if (
                        txtMatKhauQuanTriVien.Text.Equals("")
                        &&
                        txtXacNhanMK.Text.Equals("")
                        )
                    {
                        //ignore
                    }
                    else if (!txtMatKhauQuanTriVien.Text.Equals(txtXacNhanMK.Text))
                    {
                        dxErrorProvider1.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                        dxErrorProvider1.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                        return;
                    }
                    else
                    {
                        objQuanTriVienFilter.quantrivien.changePassword(txtMatKhauQuanTriVien.Text);
                    }

                    //call update
                    int re = objQuanTriVienFilter.quantrivien.update();
                    if (re > 0)
                    {
                        if (DBInstance.commit() > 0)
                        {
                            MessageBox.Show("Sửa thành công!");
                            reLoad();
                            return;
                        }
                    }
                    MessageBox.Show("Sửa KHÔNG thành công!");
                    showValidationError();
                    return;
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
                        if (DBInstance.commit() > 0)
                        {
                            MessageBox.Show("Thêm thành công!");
                            //reload
                            reLoad();
                            return;
                        }
                    }
                    MessageBox.Show("Có lỗi xảy ra!");
                    showValidationError();
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click: " + ex.Message);
            }
        }
        /// <summary>
        /// hiển thị thông báo lỗi
        /// </summary>
        private void showValidationError()
        {
            foreach (var item in DBInstance.DB.ERRORs)
            {
                if (item.PropertyName.Equals("username"))
                {
                    dxErrorProvider1.SetError(txtTaiKhoanQuanTriVien,item.ErrorMessage);
                }
                if (item.PropertyName.Equals("hoten"))
                {
                    dxErrorProvider1.SetError(txtTenQuanTriVien, item.ErrorMessage);
                }
            }
        }
        private void barButtonSuaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //enableEdit(false, "");
            setThongTinChiTiet(objQuanTriVienFilter.quantrivien);
        }

        private void barButtonThemQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add");
        }

        private void barButtonXoaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Global.current_quantrivien_login == null)
            {
                return;
            }
            if (Global.current_quantrivien_login.id == objQuanTriVienFilter.quantrivien.id)
            {
                MessageBox.Show("Không thể xóa bản thân!");
                return;
            }

            int re = objQuanTriVienFilter.quantrivien.delete();
            if (re > 0)
            {
                if (DBInstance.commit() > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    //reload
                    reLoad();
                    return;
                }
            }
            MessageBox.Show("Xóa KHÔNG thành công");
        }

        private void barBtnThemGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ucPhanQuyen_Group.editGUI("add");
        }

        private void barBtnSuaGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ucPhanQuyen_Group.editGUI("edit");
        }

        private void barBtnXoaGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ucPhanQuyen_Group.deleteObj();
        }

        public bool checkworking()
        {
            try
            {
                if (!show)
                {
                    if (function.Equals("edit"))
                    {
                        return
                            objQuanTriVienFilter.quantrivien.subId != txtMaQuanTriVien.Text ||
                            objQuanTriVienFilter.quantrivien.hoten != txtTenQuanTriVien.Text ||
                            objQuanTriVienFilter.quantrivien.username != txtTaiKhoanQuanTriVien.Text ||
                            (!txtMatKhauQuanTriVien.Text.Equals("") && objQuanTriVienFilter.quantrivien.password != txtMatKhauQuanTriVien.Text) ||
                            objQuanTriVienFilter.quantrivien.mota != memoEdit_mota.Text;
                    }
                    else if (function.Equals("add"))
                    {
                        return
                            !txtMaQuanTriVien.Text.Equals("") ||
                            !txtTenQuanTriVien.Text.Equals("") ||
                            !txtTaiKhoanQuanTriVien.Text.Equals("") ||
                            !txtMatKhauQuanTriVien.Text.Equals("") ||
                            !txtXacNhanMK.Text.Equals("") ||
                            !memoEdit_mota.Text.Equals("");
                    }
                    else
                    {
                        return working;
                    }
                }
                else
                    return _ucPhanQuyen_Group.checkworking();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
                return true;
            }
        }
    }
}
