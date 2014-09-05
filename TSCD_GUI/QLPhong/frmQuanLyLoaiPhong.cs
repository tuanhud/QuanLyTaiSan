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

namespace TSCD_GUI.QLPhong
{
    public partial class frmQuanLyLoaiPhong : DevExpress.XtraEditors.XtraForm
    {

        List<LoaiPhong> listLoaiPhong = new List<LoaiPhong>();
        LoaiPhong objLoaiPhong = new LoaiPhong();
        String function = "";
        bool working = false;

        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            try
            {
                editGUI("view");
                listLoaiPhong = LoaiPhong.getQuery().OrderBy(c => c.order).ToList();
                if (listLoaiPhong.Count == 0)
                {
                    enableButton(false);
                }
                gridControlLoaiPhong.DataSource = listLoaiPhong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadData: " + ex.Message);
            }
        }

        private void reloadAndFocused(Guid _id)
        {
            loadData();
            int rowHandle = gridViewLoaiPhong.LocateByValue(colid.FieldName, _id);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridViewLoaiPhong.FocusedRowHandle = rowHandle;
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
                SetTextGroupControl("Thêm loại phòng", Color.Red);
                enableEdit(true);
                clearText();
                txtTen.Focus();
            }
            else if (_type.Equals("edit"))
            {
                SetTextGroupControl("Sửa loại phòng", Color.Red);
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
                if (gridViewLoaiPhong.RowCount > 0)
                {
                    if (gridViewLoaiPhong.GetFocusedRow() != null)
                    {
                        objLoaiPhong = gridViewLoaiPhong.GetFocusedRow() as LoaiPhong;
                        txtTen.Text = objLoaiPhong.ten;
                        txtMoTa.Text = objLoaiPhong.mota;
                    }
                    else
                    {
                        clearText();
                        objLoaiPhong = new LoaiPhong();
                    }
                }
                else
                {
                    enableButton(false);
                    clearText();
                    objLoaiPhong = new LoaiPhong();
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
                objLoaiPhong.ten = txtTen.Text;
                objLoaiPhong.mota = txtMoTa.Text;
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
                if (objLoaiPhong.phongs != null && objLoaiPhong.phongs.Count > 0)
                {
                    XtraMessageBox.Show("Không thể xóa loại phòng này!\r\nNguyên do: Có phòng thuộc loại phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc là muốn xóa loại phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (objLoaiPhong.delete() > 0 && DBInstance.commit() > 0)
                        {
                            XtraMessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadData();
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa loại phòng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (listLoaiPhong.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper())).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên loại phòng này đã tồn tại");
                    }
                }
                else if (function.Equals("edit"))
                {
                    if (listLoaiPhong.Where(i => i.ten.ToUpper().Equals(txtTen.Text.ToUpper()) && i.id != objLoaiPhong.id).FirstOrDefault() != null)
                    {
                        check = false;
                        dxErrorProviderInfo.SetError(txtTen, "Tên loại phòng này đã tồn tại");
                    }
                }
                if (txtTen.Text.Length == 0)
                {
                    check = false;
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên loại phòng");
                }
                return check;
            }
            catch (Exception ex)
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
                            objLoaiPhong = new LoaiPhong();
                            setDataObj();
                            if (objLoaiPhong.add() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiPhong.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Thêm loại phòng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case "edit":
                            setDataObj();
                            if (objLoaiPhong.update() > 0 && DBInstance.commit() > 0)
                            {
                                XtraMessageBox.Show("Sửa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guid id = objLoaiPhong.id;
                                reloadAndFocused(id);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sửa loại phòng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridViewLoaiPhong_DataSourceChanged(object sender, EventArgs e)
        {
            setDataView();
        }

        private void gridViewLoaiPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}