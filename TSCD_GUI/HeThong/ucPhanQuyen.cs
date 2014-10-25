using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SHARED.Libraries;
using TSCD.Entities;
using TSCD.DataFilter;
using DevExpress.XtraBars.Ribbon;
using TSCD;

namespace TSCD_GUI.HeThong
{
    public partial class ucPhanQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        //private List<QuanTriVienHienThi> listQuanTriVienFilter = null;
        private QuanTriVien objQTV = null;
        private String function = "";
        private bool working = false;
        bool canAdd = false;
        bool canEdit = false;
        bool canDelete = false;

        public ucPhanQuyen()
        {
            InitializeComponent();
            rbnPhanQuyen.Parent = null;
        }

        private void checkPermission()
        {
            try
            {
                canAdd = Permission.canAdd<QuanTriVien>();
                canEdit = Permission.canEdit<QuanTriVien>(null);
                canDelete = Permission.canDelete<QuanTriVien>(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkPermission: " + ex.Message);
            }
        }

        public void loadData()
        {
            try
            {
                checkPermission();
                editGUI("view");
                lookUpEdit_group.Properties.DataSource = Group.getAll();
                gridControlQTV.DataSource = QuanTriVienHienThi.getAll();
                if (gridViewQTV.RowCount == 0)
                    enableButton(false);
                else
                    gridViewQTV.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void gridViewQTV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
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
            groupControlInfo.Text = text;
            groupControlInfo.AppearanceCaption.ForeColor = color;
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
            //Không thể tự mình đổi group
            lookUpEdit_group.Properties.ReadOnly = !_enable;// || (Global.current_quantrivien_login != null && objQuanTriVien != null && objQuanTriVien != null && Global.current_quantrivien_login.id == objQuanTriVien.id && !function.Equals("add"));
            memoEdit_mota.Properties.ReadOnly = !_enable;
            barBtnThemQTV.Enabled = !_enable && canAdd;
            btnThem_r.Enabled = !_enable && canAdd;
            enableButton(!_enable);
            working = _enable;
        }

        private void enableButton(bool _enable)
        {
            barBtnSuaQTV.Enabled = _enable && canEdit;
            barBtnXoaQTV.Enabled = _enable && canDelete;
            btnSua_r.Enabled = _enable && canEdit;
            btnXoa_r.Enabled = _enable && canDelete;
        }

        private void clearText()
        {
            txtMaQuanTriVien.Text = "";
            txtTenQuanTriVien.Text = "";
            txtTaiKhoanQuanTriVien.Text = "";
            txtMatKhauQuanTriVien.Text = "";
            txtXacNhanMK.Text = "";
            dateCreated.DateTime = DateTime.Now;
            lookUpEdit_group.EditValue = null;
            memoEdit_mota.Text = "";
        }


        private void setDataView()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (gridViewQTV.RowCount > 0)
                {
                    if (gridViewQTV.GetFocusedRow() != null)
                    {
                        objQTV = (gridViewQTV.GetFocusedRow() as QuanTriVienHienThi).quantrivien;
                        txtMaQuanTriVien.Text = objQTV.subId;
                        txtTaiKhoanQuanTriVien.Text = objQTV.username;
                        txtTenQuanTriVien.Text = objQTV.hoten;
                        txtMatKhauQuanTriVien.Text = txtXacNhanMK.Text = "";
                        memoEdit_mota.Text = objQTV.mota;
                        dateCreated.DateTime = (DateTime)(objQTV.date_create == null ? ServerTimeHelper.getNow() : objQTV.date_create);
                        if (objQTV.group != null)
                        {
                            lookUpEdit_group.EditValue = objQTV.group.id;
                        }
                    }
                    else
                    {
                        clearText();
                        objQTV = new QuanTriVien();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objQTV = new QuanTriVien();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }

        private void setDataObj()
        {
            try
            {
                objQTV.subId = txtMaQuanTriVien.Text;
                objQTV.username = txtTaiKhoanQuanTriVien.Text;
                objQTV.date_create = (DateTime)dateCreated.EditValue;
                objQTV.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                objQTV.hoten = txtTenQuanTriVien.Text;
                objQTV.mota = memoEdit_mota.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewQTV.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewQTV.FocusedRowHandle = rowHandle;
        }

        public RibbonControl getRibbonControl()
        {
            return rbnPhanQuyen;
        }

        private Boolean checkInput()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                Boolean check = true;
                if (txtTaiKhoanQuanTriVien.Text.Equals(""))
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTaiKhoanQuanTriVien, "Tài khoản không được rỗng");
                }
                if (txtTenQuanTriVien.Text.Equals(""))
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTenQuanTriVien, "Họ tên không được rỗng");
                }
                if (lookUpEdit_group.EditValue == null || GUID.From(lookUpEdit_group.EditValue) == Guid.Empty)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(lookUpEdit_group, "Chưa chọn nhóm quyền!");
                }
                if (function.Equals("edit"))
                {
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
                        check = false;
                        dxErrorProviderInfo.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                        dxErrorProviderInfo.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                    }
                }
                else if (function.Equals("add"))
                {
                    //try to change pass first
                    if (txtMatKhauQuanTriVien.Text.Equals(""))
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtMatKhauQuanTriVien, "Mật khẩu không được rỗng!");
                    }
                    if (!txtMatKhauQuanTriVien.Text.Equals(txtXacNhanMK.Text))
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                        dxErrorProviderInfo.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                    }
                }
                return check;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    switch (function)
                    {
                        case "add":
                            objQTV = new QuanTriVien();
                            setDataObj();
                            objQTV.setPassword(txtMatKhauQuanTriVien.Text);
                            if (objQTV.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm quản trị viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objQTV.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm quản trị viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (!txtMatKhauQuanTriVien.Text.Equals("") && !txtXacNhanMK.Text.Equals(""))
                                objQTV.changePassword(txtMatKhauQuanTriVien.Text);
                            if (objQTV.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa quản trị viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objQTV.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa quản trị viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOk_Click: " + ex.Message);
            }
        }
        private void barBtnSuaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProviderInfo.ClearErrors();
            setDataView();
        }

        private void barBtnThemQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("add");
        }

        private void barBtnXoaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteObj();
        }

        private void deleteObj()
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc là muốn xóa quản trị viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Global.current_quantrivien_login == null)
                    {
                        return;
                    }
                    if (Global.current_quantrivien_login.id == objQTV.id)
                    {
                        MessageBox.Show("Không thể xóa bản thân!");
                        return;
                    }

                    int re = objQTV.delete();
                    if (re > 0)
                    {
                        if (DBInstance.commit() > 0)
                        {
                            MessageBox.Show("Xóa thành công!");
                            loadData();
                            return;
                        }
                    }
                    MessageBox.Show("Xóa KHÔNG thành công");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }

        public bool checkworking()
        {
            return false;
        //    try
        //    {
        //        if (!show)
        //        {
        //            if (function.Equals("edit"))
        //            {
        //                return
        //                    objQuanTriVien.subId != txtMaQuanTriVien.Text ||
        //                    objQuanTriVien.hoten != txtTenQuanTriVien.Text ||
        //                    objQuanTriVien.username != txtTaiKhoanQuanTriVien.Text ||
        //                    (!txtMatKhauQuanTriVien.Text.Equals("") && objQuanTriVien.password != txtMatKhauQuanTriVien.Text) ||
        //                    objQuanTriVien.mota != memoEdit_mota.Text;
        //            }
        //            else if (function.Equals("add"))
        //            {
        //                return
        //                    !txtMaQuanTriVien.Text.Equals("") ||
        //                    !txtTenQuanTriVien.Text.Equals("") ||
        //                    !txtTaiKhoanQuanTriVien.Text.Equals("") ||
        //                    !txtMatKhauQuanTriVien.Text.Equals("") ||
        //                    !txtXacNhanMK.Text.Equals("") ||
        //                    !memoEdit_mota.Text.Equals("");
        //            }
        //            else
        //            {
        //                return working;
        //            }
        //        }
        //        else
        //            return _ucPhanQuyen_Group.checkworking();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
        //        return true;
        //    }
        }

        private void gridViewQTV_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        private void btnThem_r_Click(object sender, EventArgs e)
        {
            editGUI("add");
        }

        private void btnSua_r_Click(object sender, EventArgs e)
        {
            editGUI("edit");
        }

        private void btnXoa_r_Click(object sender, EventArgs e)
        {
            deleteObj();
        }

        private void btnNhomQuyen_Click(object sender, EventArgs e)
        {
            frmQuanLyNhomQuyen frm = new frmQuanLyNhomQuyen();
            frm.ShowDialog();
            lookUpEdit_group.Properties.DataSource = Group.getAll();
        }

        private void barBtnNhomQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuanLyNhomQuyen frm = new frmQuanLyNhomQuyen();
            frm.ShowDialog();
            lookUpEdit_group.Properties.DataSource = Group.getAll();
        }
    }
}
