using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.Entities;
using SHARED.Libraries;

namespace TSCD_GUI.QLLoaiTaiSan
{
    public partial class frmQuanLyDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        List<DonViTinh> listDonViTinh = new List<DonViTinh>();
        DonViTinh objDonViTinh = new DonViTinh();
        String function = "";
        bool working = false;
        public frmQuanLyDonViTinh()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            editGUI("view");
            listDonViTinh = DonViTinh.getQuery().OrderBy(c => c.ten).ToList();
            if (listDonViTinh.Count == 0)
            {
                enableButton(false);
            }
            gridControlDonViTinh.DataSource = listDonViTinh;
        }
        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewDonViTinh.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewDonViTinh.FocusedRowHandle = rowHandle;
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
                SetTextGroupControl("Thêm đơn vị tính", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa đơn vị tính", Color.Red);
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
            txtMa.Properties.ReadOnly = !_enable;
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
            txtMa.Text = "";
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
                if (gridViewDonViTinh.RowCount > 0)
                {
                    if (gridViewDonViTinh.GetFocusedRow() != null)
                    {
                        objDonViTinh = gridViewDonViTinh.GetFocusedRow() as DonViTinh;
                        txtMa.Text = objDonViTinh.subId;
                        txtTen.Text = objDonViTinh.ten;
                        txtMoTa.Text = objDonViTinh.mota;
                    }
                    else
                    {
                        clearText();
                        objDonViTinh = new DonViTinh();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objDonViTinh = new DonViTinh();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataView: " + ex.Message);
            }
        }
        private void deleteObj()
        {
            try
            {
                if (objDonViTinh.loaitaisans != null && objDonViTinh.loaitaisans.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa đơn vị tính này!\r\nNguyên do: Có loại tài sản chứa đơn vị tính này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa đơn vị tính này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objDonViTinh.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa đơn vị tính không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->deleteObj: " + ex.Message);
            }
        }
        private void gridViewDonViTinh_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }
        private void gridViewDonViTinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            setDataView();
        }
        private void btnSua_r_Click(object sender, EventArgs e)
        {
            editGUI("edit");
        }
        private void btnThem_r_Click(object sender, EventArgs e)
        {
            editGUI("add");
        }
        private void btnXoa_r_Click(object sender, EventArgs e)
        {
            deleteObj();
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
                    if (listDonViTinh.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper())).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên đơn vị tính này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (listDonViTinh.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper()) && i.id != objDonViTinh.id).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên đơn vị tính này đã tồn tại");
                    }
                }
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên đơn vị tính");
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
                objDonViTinh.subId = txtMa.Text;
                objDonViTinh.ten = txtTen.Text;
                objDonViTinh.mota = txtMoTa.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDataObj: " + ex.Message);
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
                            objDonViTinh = new DonViTinh();
                            setDataObj();
                            if (objDonViTinh.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm đơn vị tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objDonViTinh.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm đơn vị tính không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objDonViTinh.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa đơn vị tính thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objDonViTinh.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa đơn vị tính không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}