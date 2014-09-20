using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTB.Entities;
using PTB.DataFilter;
using PTB.Libraries;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Data.Entity.Validation;
using SHARED.Libraries;
using PTB;

namespace PTB_GUI.HeThong
{
    public partial class ucPhanQuyen : UserControl, _ourUcInterface
    {
        private List<QuanTriVienFilter> listobjQuanTriVienFilter = null;
        private QuanTriVien objQuanTriVien = null;
        private ucPhanQuyen_Control _ucPhanQuyen_Control = new ucPhanQuyen_Control();
        private ucPhanQuyen_Group _ucPhanQuyen_Group = new ucPhanQuyen_Group();
        private String function = "";
        private bool working = false;
        private bool show = false;
        bool canAdd = false;
        bool canEdit = false;
        bool canDelete = false;
        bool canAdd_Group = false;
        bool canEdit_Group = false;
        bool canDelete_Group = false;

        public ucPhanQuyen()
        {
            InitializeComponent();
            ribbonPhanQuyen.Parent = null;
            _ucPhanQuyen_Control.Parent = this;
            rbnGroupGroup.Visible = false;
            _ucPhanQuyen_Group.EnableButton2 = new ucPhanQuyen_Group.enableButton2(enableButton2);
            //reLoad();
        }

        private void checkPermission()
        {
            try
            {
                canAdd = Permission.canAdd<QuanTriVien>();
                canEdit = Permission.canEdit<QuanTriVien>(null);
                canDelete = Permission.canDelete<QuanTriVien>(null);
                canAdd_Group = Permission.canAdd<Group>();
                canEdit_Group = Permission.canEdit<Group>(null);
                canDelete_Group = Permission.canDelete<Group>(null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkPermission: " + ex.Message);
            }
        }

        private void gridViewPhanQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewPhanQuyen.GetFocusedRow() != null)
                {
                    groupControl1.Text = "Thông tin";
                    objQuanTriVien = ((QuanTriVienFilter)gridViewPhanQuyen.GetFocusedRow()).quantrivien;
                    //Truyen qua cho View Thong Tin
                    setThongTinChiTiet(objQuanTriVien);
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
            //Không thể tự mình đổi group
            lookUpEdit_group.Properties.ReadOnly = !_enable || (Global.current_quantrivien_login != null && objQuanTriVien!=null && objQuanTriVien!=null && Global.current_quantrivien_login.id == objQuanTriVien.id && !function.Equals("add"));
            memoEdit_mota.Properties.ReadOnly = !_enable;
            barButtonThemQTV.Enabled = !_enable && canAdd;
            enableButton(!_enable);
            working = _enable;
        }

        private void enableButton(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            barButtonSuaQTV.Enabled = _enable && canEdit;
            barButtonXoaQTV.Enabled = _enable && canDelete;
        }

        private void enableButton2(bool _enable)
        {
            //btnR_Them.Enabled = _enable;
            barBtnThemGroup.Enabled = _enable && canAdd_Group;
            barBtnSuaGroup.Enabled = _enable && canEdit_Group;
            barBtnXoaGroup.Enabled = _enable && canDelete_Group;
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
                checkPermission();
                gridControlPhanQuyen.DataSource = null;
                gridControlPhanQuyen.DataSource = listobjQuanTriVienFilter = QuanTriVienFilter.getAll();
                gridViewPhanQuyen.ExpandAllGroups();
                reloadGroup();
                if (objQuanTriVien != null)
                {
                    setThongTinChiTiet(objQuanTriVien);
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
                reLoad();
                gridViewPhanQuyen.ExpandAllGroups();
                editGUI("view");
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //lear previos error
                dxErrorProvider1.ClearErrors();
                //load to object
                if (function.Equals("add"))
                {
                    objQuanTriVien = new QuanTriVien();
                }
                objQuanTriVien.subId = txtMaQuanTriVien.Text;
                objQuanTriVien.username = txtTaiKhoanQuanTriVien.Text;
                if (objQuanTriVien.username.Equals(""))
                {
                    dxErrorProvider1.SetError(txtTaiKhoanQuanTriVien, "Tài khoản không được rỗng");
                    return;
                }
                objQuanTriVien.date_create = (DateTime)dateCreated.EditValue;
                objQuanTriVien.group = lookUpEdit_group.GetSelectedDataRow() as Group;
                objQuanTriVien.hoten = txtTenQuanTriVien.Text;
                if (objQuanTriVien.hoten.Equals(""))
                {
                    dxErrorProvider1.SetError(txtTenQuanTriVien, "Họ tên không được rỗng");
                    return;
                }
                objQuanTriVien.mota = memoEdit_mota.Text;
                
                //call function
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
                        dxErrorProvider1.SetError(txtMatKhauQuanTriVien, "Mật khẩu không khớp!");
                        dxErrorProvider1.SetError(txtXacNhanMK, "Mật khẩu không khớp!");
                        return;
                    }
                    else
                    {
                        objQuanTriVien.changePassword(txtMatKhauQuanTriVien.Text);
                    }

                    //call update
                    int re = objQuanTriVien.update();
                    if (re > 0)
                    {
                        if (DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Sửa thành công!");
                            dxErrorProvider1.ClearErrors();
                            reLoad();
                            return;
                        }
                    }
                    else if (re == -7)
                    {
                        dxErrorProvider1.SetError(txtTaiKhoanQuanTriVien,"Trùng tài khoản đã có");
                        return;
                    }
                    XtraMessageBox.Show("Sửa KHÔNG thành công!");
                    return;
                }
                else if (function.Equals("add"))
                {
                    objQuanTriVien.hashPassword(txtMatKhauQuanTriVien.Text);
                    int re = objQuanTriVien.add();
                    if (re > 0)
                    {
                        if (DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Thêm thành công!");
                            //reload
                            reLoad();
                            return;
                        }
                    }
                    else if (re == -7)
                    {
                        dxErrorProvider1.SetError(txtTaiKhoanQuanTriVien, "Trùng tài khoản đã có");
                        return;
                    }
                    XtraMessageBox.Show("Có lỗi xảy ra!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click: " + ex.Message);
            }
        }
        private void barButtonSuaQTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editGUI("edit");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //enableEdit(false, "");
            setThongTinChiTiet(objQuanTriVien);
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
            if (Global.current_quantrivien_login.id == objQuanTriVien.id)
            {
                MessageBox.Show("Không thể xóa bản thân!");
                return;
            }

            int re = objQuanTriVien.delete();
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
                            objQuanTriVien.subId != txtMaQuanTriVien.Text ||
                            objQuanTriVien.hoten != txtTenQuanTriVien.Text ||
                            objQuanTriVien.username != txtTaiKhoanQuanTriVien.Text ||
                            (!txtMatKhauQuanTriVien.Text.Equals("") && objQuanTriVien.password != txtMatKhauQuanTriVien.Text) ||
                            objQuanTriVien.mota != memoEdit_mota.Text;
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
