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

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmQuanLyTinhTrang : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyTinhTrang()
        {
            InitializeComponent();
            loadData();
        }

        List<TinhTrang> listTinhTrang = new List<TinhTrang>();
        TinhTrang objTinhTrang = new TinhTrang();
        String function = "";
        bool working = false;

        public void loadData()
        {
            try
            {
                editGUI("view");
                listTinhTrang = TinhTrang.getQuery().OrderBy(c=>c.order).ToList();
                if (listTinhTrang.Count == 0)
                {
                    enableButton(false);
                }
                gridControlTinhTrang.DataSource = listTinhTrang;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewTinhTrang.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewTinhTrang.FocusedRowHandle = rowHandle;
        }

        private void editGUI(String _type)
        {
            function = _type;
            if (_type.Equals("view"))
            {
                SetTextGroupControl("Chi tiết", Color.Empty);
                enableEdit(false);
            }
            else if (_type.Equals("add"))
            {
                SetTextGroupControl("Thêm tình trạng", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa tình trạng", Color.Red);
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
            btnUp_r.Enabled = _enable;
            btnDown_r.Enabled = _enable;
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
                if(!function.Equals("view")) 
                    editGUI("view");
                if (gridViewTinhTrang.RowCount > 0)
                {
                    if (gridViewTinhTrang.FocusedRowHandle > -1 && gridViewTinhTrang.GetFocusedRow() != null)
                    {
                        objTinhTrang = gridViewTinhTrang.GetFocusedRow() as TinhTrang;
                        txtTen.Text = objTinhTrang.value;
                        txtMoTa.Text = objTinhTrang.mota;
                    }
                    else
                    {
                        clearText();
                        objTinhTrang = new TinhTrang();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objTinhTrang = new TinhTrang();
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
                objTinhTrang.value = txtTen.Text;
                objTinhTrang.mota = txtMoTa.Text;
                objTinhTrang.key = StringHelper.CoDauThanhKhongDau(txtTen.Text).Replace(" ", String.Empty).ToUpper();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
            }
        }

        private void deleteObj()
        {
            try
            {
                if (objTinhTrang.cttaisans != null && objTinhTrang.cttaisans.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa tình trạng này!\r\nNguyên do: Có các tài sản thuộc tình trạng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa tình trạng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objTinhTrang.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa loại tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa loại tình trạng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }

        private Boolean checkInput()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                Boolean check = true;
                if (function.Equals("add"))
                {
                    if (listTinhTrang.Where(i => i.value == txtTen.Text).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên tình trạng này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (listTinhTrang.Where(i => i.value == txtTen.Text && i.id != objTinhTrang.id).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên tình trạng này đã tồn tại");
                    }
                }
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên tình trạng");
                }
                return check;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    switch (function)
                    {
                        case "add":
                            objTinhTrang = new TinhTrang();
                            setDataObj();
                            if (objTinhTrang.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objTinhTrang.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm tình trạng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objTinhTrang.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objTinhTrang.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa tình trạng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridViewTinhTrang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }

        private void gridViewTinhTrang_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkworking()
        {
            try
            {
                if (function.Equals("edit"))
                {
                    return
                        objTinhTrang.value != txtTen.Text ||
                        (objTinhTrang.mota == null && !txtMoTa.Text.Equals("")) ||
                        (objTinhTrang.mota != null && objTinhTrang.mota != txtMoTa.Text);
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

        private void frmQuanLyTinhTrang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkworking())
            {
                if (XtraMessageBox.Show("Dữ liệu chưa được lưu, bạn có chắc chắn muốn đóng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnUp_r_Click(object sender, EventArgs e)
        {
            try
            {
                if (objTinhTrang != null && objTinhTrang.id != Guid.Empty)
                {
                    objTinhTrang.moveUp();
                    DBInstance.commit();
                    reloadAndFocused(objTinhTrang.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnUp_r_Click: " + ex.Message);
            }
        }

        private void btnDown_r_Click(object sender, EventArgs e)
        {
            try
            {
                if (objTinhTrang != null && objTinhTrang.id != Guid.Empty)
                {
                    objTinhTrang.moveDown();
                    DBInstance.commit();
                    reloadAndFocused(objTinhTrang.id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnDown_r_Click: " + ex.Message);
            }
        }
    }
}