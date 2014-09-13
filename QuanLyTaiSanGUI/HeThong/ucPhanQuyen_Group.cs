using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;
using SHARED.Libraries;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen_Group : UserControl
    {
        List<Group> listGroup = null;
        List<Permission> listPermission = new List<Permission>();
        Group objGroup = new Group();
        String function = "";
        bool working = false;

        public delegate void enableButton2(bool b);

        public enableButton2 EnableButton2;

        public ucPhanQuyen_Group()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            editGUI("view");
            listGroup = Group.getAll();
            gridControlGroup.DataSource = listGroup;
        }

        public void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm nhóm quyền", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa nhóm quyền", Color.Red);
                enableEdit(true);
                txtTen.Focus();
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
            btnPhanQuyen.Visible = _enable;
            txtKey.Properties.ReadOnly = !_enable;
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            working = _enable;
            if(EnableButton2!= null)
                EnableButton2(!_enable);
        }

        private void clearText()
        {
            txtKey.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
            listBoxQuyen.DataSource = null;
        }

        public GridControl getLeftControl()
        {
            return gridControlGroup;
        }
        public PanelControl getRightControl()
        {
            return panelControl1;
        }

        private void gridViewGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }

        private void setDataView()
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (gridViewGroup.RowCount > 0)
                {
                    if (gridViewGroup.FocusedRowHandle > -1 && gridViewGroup.GetFocusedRow() != null)
                    {
                        objGroup = gridViewGroup.GetFocusedRow() as Group;
                        txtKey.Text = objGroup.key;
                        txtTen.Text = objGroup.ten;
                        txtMoTa.Text = objGroup.mota;
                        listBoxQuyen.DataSource = objGroup.permissions.ToList();
                    }
                    else
                    {
                        clearText();
                        objGroup = new Group();
                    }
                }
                else
                {
                    //enableButton(false);
                    clearText();
                    objGroup = new Group();
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
                objGroup.key = txtKey.Text;
                objGroup.ten = txtTen.Text;
                objGroup.mota = txtMoTa.Text;
                objGroup.permissions = listPermission;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
        }

        public void deleteObj()
        {
            try
            {
                if (objGroup.quantriviens.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa nhóm quyền này!\r\nNguyên do: Có quản trị viên thuộc nhóm quyền này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa nhóm quyền này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objGroup.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa nhóm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa nhóm quyền không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
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
                            objGroup = new Group();
                            setDataObj();
                            if (objGroup.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm nhóm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objGroup.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm nhóm quyền không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objGroup.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa nhóm quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objGroup.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa nhóm quyền không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewGroup.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewGroup.FocusedRowHandle = rowHandle;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setDataView();
        }

        private Boolean checkInput()
        {
            return true;
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            frmSuaPermission frm = new frmSuaPermission(objGroup.permissions.ToList());
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                listPermission = frm.getResult();
                listBoxQuyen.DataSource = listPermission;
            }
        }

        public bool checkworking()
        {
            try
            {
                if (function.Equals("edit"))
                {
                    return
                        objGroup.key != txtKey.Text ||
                        objGroup.ten != txtTen.Text ||
                        objGroup.mota != txtMoTa.Text;
                }
                else if (function.Equals("add"))
                {
                    return
                        !txtKey.Text.Equals("") ||
                        !txtTen.Text.Equals("") ||
                        !txtMoTa.Text.Equals("");
                }
                else
                {
                    return working;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkworking: " + ex.Message);
                return true;
            }
        }

        private void gridViewGroup_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }
    }
}
