using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SHARED.Libraries;
using TSCD.Entities;

namespace TSCD_GUI.QLDonVi
{
    public partial class frmQuanLyLoaiDV : DevExpress.XtraEditors.XtraForm
    {
        List<LoaiDonVi> listLoaiDonVi = new List<LoaiDonVi>();
        LoaiDonVi objLoaiDonVi = new LoaiDonVi();
        String function = "";
        bool working = false;

        public frmQuanLyLoaiDV()
        {
            InitializeComponent();
            loadData();
        }
        private void init()
        { }
        private void loadData()
        {
            try
            {
                editGUI("view");
                listLoaiDonVi = LoaiDonVi.getQuery().OrderBy(c => c.order).ToList();
                if (listLoaiDonVi.Count == 0)
                {
                    enableButton(false);
                }
                gridControlLoaiDV.DataSource = listLoaiDonVi;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }
        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewLoaiDV.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewLoaiDV.FocusedRowHandle = rowHandle;
        }
        private void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                clearText();
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm loại đơn vị", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa loại đơn vị", Color.Red);
                enableEdit(true);
                txtTen.Focus();
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
            txtTen.Properties.ReadOnly = !_enable;
            txtMoTa.Properties.ReadOnly = !_enable;
            enableButton(!_enable);
            btnThem_r.Enabled = !_enable;
            working = _enable;
        }
        private void enableButton(bool _enable)
        {
            btnSua_r.Enabled = _enable;
            btnXoa_r.Enabled = _enable;
        }
        private void clearText()
        {
            txtTen.Text = "";
            txtMoTa.Text = "";
        }
        private void setDataView()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                if (!function.Equals("view"))
                    editGUI("view");
                if (gridViewLoaiDV.RowCount > 0)
                {
                    if (gridViewLoaiDV.GetFocusedRow() != null)
                    {
                        objLoaiDonVi = gridViewLoaiDV.GetFocusedRow() as LoaiDonVi;
                        txtTen.Text = objLoaiDonVi.ten;
                        txtMoTa.Text = objLoaiDonVi.mota;
                    }
                    else
                    {
                        clearText();
                        objLoaiDonVi = new LoaiDonVi();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objLoaiDonVi = new LoaiDonVi();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }
        private void gridViewLoaiDV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }
        private void gridViewLoaiDV_DataSourceChanged(object sender, EventArgs e)
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
        private void deleteObj()
        {
            try
            {
                if (objLoaiDonVi.donvis != null && objLoaiDonVi.donvis.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa loại  đơn vị này!\r\nNguyên do: Có đơn vị thuộc loại này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa loại đơn vị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objLoaiDonVi.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa loại đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa loại đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            objLoaiDonVi = new LoaiDonVi();
                            setDataObj();
                            if (objLoaiDonVi.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm loại đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiDonVi.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm loại đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objLoaiDonVi.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa loại đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiDonVi.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa loại đơn vị không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProviderInfo.ClearErrors();
            setDataView();
        }
        private Boolean checkInput()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                Boolean check = true;
                if (function.Equals("add"))
                {
                    if (listLoaiDonVi.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper())).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên loại đơn vị này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (listLoaiDonVi.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper()) && i.id != objLoaiDonVi.id).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên loại đơn vị này đã tồn tại");
                    }
                }
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên loại đơn vị");
                }
                return check;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }
        private void setDataObj()
        {
            try
            {
                objLoaiDonVi.ten = txtTen.Text;
                objLoaiDonVi.mota = txtMoTa.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
        }
        private void btnR_Up_Click(object sender, EventArgs e)
        {
            try
            {
                if (objLoaiDonVi != null && objLoaiDonVi.id != Guid.Empty)
                {
                    objLoaiDonVi.moveUp();
                    DBInstance.commit();
                    reloadAndFocused(objLoaiDonVi.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnR_Up_Click: " + ex.Message);
            }
        }
        private void btnR_Down_Click(object sender, EventArgs e)
        {
            try
            {
                if (objLoaiDonVi != null && objLoaiDonVi.id != Guid.Empty)
                {
                    objLoaiDonVi.moveDown();
                    DBInstance.commit();
                    reloadAndFocused(objLoaiDonVi.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnR_Down_Click: " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (checkworking())
            {
                if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn đóng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private bool checkworking()
        {
            try
            {
                if (function.Equals("edit"))
                {
                    return
                        objLoaiDonVi.ten != txtTen.Text ||
                        (objLoaiDonVi.mota == null && !txtMoTa.Text.Equals("")) ||
                        (objLoaiDonVi.mota != null && objLoaiDonVi.mota != txtMoTa.Text);
                }
                else if (function.Equals("add"))
                {
                    return
                        !txtTen.Text.Equals("") ||
                        !txtMoTa.Text.Equals("");
                }
                else
                    return working;
            }
            catch
            {
                return true;
            }
        }
    }
}