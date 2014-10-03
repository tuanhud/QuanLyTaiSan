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
using TSCD.DataFilter;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSan : DevExpress.XtraEditors.XtraForm
    {
        List<TinhTrang> listTinhTrang = null;
        List<LoaiTaiSan> listLoaiTaiSan = null;
        List<CTTaiSan> listCTTaiSan = new List<CTTaiSan>();
        CTTaiSan objCTTaiSan = null;
        List<CTTaiSan> listCTTaiSan2 = new List<CTTaiSan>();
        bool isEdit = false;
        bool isChild = false;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;
        public delegate void ReLoadAndSetValueTinhTrang(List<TinhTrang> list);
        public ReLoadAndSetValueTinhTrang reLoadAndSetValueTinhTrang = null;
        public delegate void ReLoadAndSetValueLoaiTS(List<LoaiTaiSan> list);
        public ReLoadAndSetValueLoaiTS reLoadAndSetValueLoaiTS = null;
        LoaiTaiSan objLoaiTS = null;
        object id = null;

        public frmAddTaiSan(CTTaiSan _obj, bool isDonVi = false)
        {
            InitializeComponent();
            loadData();
            objCTTaiSan = _obj;
            isEdit = true;
            init();
            setData(_obj);
            //if (isDonVi)
            //{
                txtSoLuong.Properties.ReadOnly = true;
                lookUpTinhTrang.Properties.ReadOnly = true;
            //}
        }

        public frmAddTaiSan(CTTaiSan _obj, List<TinhTrang> _listTinhTrang, List<LoaiTaiSan> _listLoaiTaiSan)
        {
            InitializeComponent();
            loadData(_listTinhTrang, _listLoaiTaiSan);
            objCTTaiSan = _obj;
            isEdit = true;
            isChild = true;
            init();
            setData(_obj);
            txtSoLuong.Properties.ReadOnly = true;
            lookUpTinhTrang.Properties.ReadOnly = true;
        }

        public frmAddTaiSan(List<CTTaiSan> _list, List<TinhTrang> _listTinhTrang, List<LoaiTaiSan> _listLoaiTaiSan)
        {
            InitializeComponent();
            loadData(_listTinhTrang, _listLoaiTaiSan);
            listCTTaiSan2 = _list;
            isChild = true;
        }

        private void init()
        {
            ucComboBoxLoaiTS1.editValueChanged = new MyUserControl.ucComboBoxLoaiTS.EditValueChanged(setDonViTinh);
        }

        public frmAddTaiSan()
        {
            InitializeComponent();
            loadData();
            init();
        }

        private void loadData()
        {
            loadDataTinhTrang();
            loadDataLoaiTS();
        }

        private void loadDataTinhTrang()
        {
            try
            {
                listTinhTrang = TinhTrang.getQuery().OrderBy(c => c.order).ToList();
                lookUpTinhTrang.Properties.DataSource = listTinhTrang;
                if (reLoadAndSetValueTinhTrang != null)
                    reLoadAndSetValueTinhTrang(listTinhTrang);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadDataTinhTrang:" + ex.Message);
            }
        }

        private void loadDataLoaiTS()
        {
            try
            {
                listLoaiTaiSan = LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(listLoaiTaiSan);
                if (reLoadAndSetValueLoaiTS != null)
                    reLoadAndSetValueLoaiTS(listLoaiTaiSan);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadDataLoaiTS:" + ex.Message);
            }
        }

        private void loadData(List<TinhTrang> _listTinhTrang, List<LoaiTaiSan> _listLoaiTaiSan)
        {
            loadDataTinhTrang(_listTinhTrang);
            loadDataLoaiTS(_listLoaiTaiSan);
        }

        private void loadDataTinhTrang(List<TinhTrang> _listTinhTrang, bool reload = false)
        {
            try
            {
                listTinhTrang = _listTinhTrang;
                lookUpTinhTrang.Properties.DataSource = listTinhTrang;
                if (reload && reLoadAndSetValueTinhTrang != null)
                    reLoadAndSetValueTinhTrang(listTinhTrang);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadDataTinhTrang:" + ex.Message);
            }
        }

        private void loadDataLoaiTS(List<LoaiTaiSan> _listLoaiTaiSan, bool reload = false)
        {
            try
            {
                listLoaiTaiSan = _listLoaiTaiSan;
                ucComboBoxLoaiTS1.DataSource = LoaiTSHienThi.Convert(listLoaiTaiSan);
                if (reload && reLoadAndSetValueLoaiTS != null)
                    reLoadAndSetValueLoaiTS(listLoaiTaiSan);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->loadDataLoaiTS:" + ex.Message);
            }
        }

        private void setData(CTTaiSan obj)
        {
            try
            {
                dateNgaySD.EditValue = obj.ngay;
                txtSoHieu_CT.Text = obj.chungtu_sohieu;
                dateNgay_CT.EditValue = obj.chungtu_ngay;
                txtMa.Text = obj.taisan.subId;
                txtTen.Text = obj.taisan.ten;
                ucComboBoxLoaiTS1.LoaiTS = obj.taisan.loaitaisan;
                txtSoLuong.EditValue = obj.soluong;
                txtDonGia.EditValue = obj.taisan.dongia;
                lookUpTinhTrang.EditValue = obj.tinhtrang_id;
                txtNSX.Text = obj.taisan.nuocsx;
                txtNguonGoc.Text = obj.nguongoc;
                txtGhiChu.Text = obj.mota;
                listCTTaiSan = obj.childs.ToList();
                gridControlTaiSan.DataSource = TaiSanHienThi.Convert(listCTTaiSan);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    Guid id;
                    if (isEdit)
                        id = editObj();
                    else
                        id = addObj();
                    if (reloadAndFocused != null)
                        reloadAndFocused(id);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click:" + ex.Message);
            }
        }

        private Boolean checkInput()
        {
            try
            {
                dxErrorProviderInfo.ClearErrors();
                Boolean check = true;
                if (txtTen.Text.Length == 0)
                {
                    dxErrorProviderInfo.SetError(txtTen, "Chưa điền tên TSCĐ");
                    check = false;
                }
                if (lookUpTinhTrang.EditValue == null || GUID.From(lookUpTinhTrang.EditValue) == Guid.Empty)
                {
                    dxErrorProviderInfo.SetError(lookUpTinhTrang, "Chưa chọn tình trạng");
                    check = false;
                }
                if (txtDonGia.EditValue == null)
                {
                    dxErrorProviderInfo.SetError(txtDonGia, "Chưa nhập đơn giá");
                    check = false;
                }
                if (txtSoLuong.EditValue == null)
                {
                    dxErrorProviderInfo.SetError(lookUpTinhTrang, "Chưa nhầp số lượng");
                    check = false;
                }
                LoaiTaiSan loai = ucComboBoxLoaiTS1.LoaiTS;
                if (loai == null || loai.id == Guid.Empty)
                {
                    XtraMessageBox.Show("Chưa chọn loại tài sản");
                    return false;
                }
                return check;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->checkInput: " + ex.Message);
                return false;
            }
        }

        private Guid addObj()
        {
            try
            {
                TaiSan ts = new TaiSan();
                ts.ten = txtTen.Text;
                ts.dongia = txtDonGia.EditValue != null ? long.Parse(txtDonGia.EditValue.ToString()) : 0;
                ts.loaitaisan = ucComboBoxLoaiTS1.LoaiTS;
                ts.subId = txtMa.Text;
                ts.nuocsx = txtNSX.Text;

                CTTaiSan obj = new CTTaiSan();

                obj.taisan = ts;
                obj.chungtu_ngay = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                obj.chungtu_sohieu = txtSoHieu_CT.Text;
                obj.ngay = dateNgaySD.EditValue != null ? dateNgaySD.DateTime : DateTime.Now;
                obj.nguongoc = txtNguonGoc.Text;
                obj.soluong = Convert.ToInt32(txtSoLuong.EditValue);
                obj.tinhtrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
                obj.mota = txtGhiChu.Text;
                obj.childs = listCTTaiSan;
                if (!isChild)
                {
                    int re = obj.add();//ONly call add on CTTaiSan
                    re = DBInstance.commit();
                    if (re > 0)
                    {
                        XtraMessageBox.Show("Thêm tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return obj.id;
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return Guid.Empty;
                    }
                }
                else
                {
                    listCTTaiSan2.Add(obj);
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->addObj:" + ex.Message);
                return Guid.Empty;
            }
        }

        private Guid editObj()
        {
            try
            {
                objCTTaiSan.taisan.ten = txtTen.Text;
                objCTTaiSan.taisan.dongia = txtDonGia.EditValue != null ? long.Parse(txtDonGia.EditValue.ToString()) : 0;
                objCTTaiSan.taisan.loaitaisan = ucComboBoxLoaiTS1.LoaiTS;
                objCTTaiSan.taisan.subId = txtMa.Text;
                objCTTaiSan.chungtu_ngay = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                objCTTaiSan.chungtu_sohieu = txtSoHieu_CT.Text;
                objCTTaiSan.ngay = dateNgaySD.EditValue != null ? dateNgaySD.DateTime : DateTime.Now;
                objCTTaiSan.taisan.nuocsx = txtNSX.Text;
                objCTTaiSan.nguongoc = txtNguonGoc.Text;
                objCTTaiSan.soluong = Convert.ToInt32(txtSoLuong.EditValue);
                objCTTaiSan.tinhtrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
                objCTTaiSan.mota = txtGhiChu.Text;
                objCTTaiSan.childs = listCTTaiSan;
                int re = objCTTaiSan.update();//ONly call add on CTTaiSan
                if (!isChild)
                    re = DBInstance.commit();
                if (re > 0)
                {
                    XtraMessageBox.Show("Sửa tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return objCTTaiSan.id;
                }
                else
                {
                    XtraMessageBox.Show("Sửa tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->editObj:" + ex.Message);
                return Guid.Empty;
            }
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            setThanhTien();
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            setThanhTien();
        }

        private void setThanhTien()
        {
            if (txtSoLuong.EditValue != null && txtDonGia.EditValue != null)
            {
                lbltxtThanhTien.Text = Convert.ToInt32(txtSoLuong.EditValue) * long.Parse(txtDonGia.EditValue.ToString()) +"";
            }
        }

        private void setDonViTinh()
        {
            try
            {
                LoaiTaiSan obj = ucComboBoxLoaiTS1.LoaiTS;
                if (obj == null || obj.donvitinh == null)
                    lbltxtDonViTinh.Text = "";
                else
                    lbltxtDonViTinh.Text = ucComboBoxLoaiTS1.LoaiTS.donvitinh.ten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setDonViTinh:" + ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            id = lookUpTinhTrang.EditValue;
            objLoaiTS = ucComboBoxLoaiTS1.LoaiTS;
            frmAddTaiSan frm = new frmAddTaiSan(listCTTaiSan, listTinhTrang, listLoaiTaiSan);
            frm.reloadAndFocused = new ReloadAndFocused(reload);
            frm.reLoadAndSetValueLoaiTS = new ReLoadAndSetValueLoaiTS(reloadLoaiTS);
            frm.reLoadAndSetValueTinhTrang = new ReLoadAndSetValueTinhTrang(reloadTinhTrang);
            frm.Text = "Thêm tài sản kèm theo";
            frm.ShowDialog();
        }

        private void reload(Guid _id)
        {
            try
            {
                gridControlTaiSan.DataSource = null;
                gridControlTaiSan.DataSource = TaiSanHienThi.Convert(listCTTaiSan);
                if (_id != Guid.Empty)
                {
                    int rowHandle = bandedGridViewTaiSan.LocateByValue(colid.FieldName, _id);
                    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        bandedGridViewTaiSan.FocusedRowHandle = rowHandle;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->reload:" + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (bandedGridViewTaiSan.GetFocusedRow() != null)
            {
                frmAddTaiSan frm = new frmAddTaiSan((bandedGridViewTaiSan.GetFocusedRow() as TaiSanHienThi).obj, listTinhTrang, listLoaiTaiSan);
                frm.reloadAndFocused = new frmAddTaiSan.ReloadAndFocused(reload);
                frm.Text = "Sửa tài sản kèm theo";
                frm.ShowDialog();
            }
        }

        private void btnAddExist_Click(object sender, EventArgs e)
        {
            frmAddTaiSanExist frm = new frmAddTaiSanExist(listCTTaiSan);
            frm.reloadAndFocused = new frmAddTaiSanExist.ReloadAndFocused(reload);
            frm.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoaiTS_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiTS frm = new frmQuanLyLoaiTS();
            frm.ShowDialog();
            loadDataLoaiTS();
        }

        private void btnTinhTrang_Click(object sender, EventArgs e)
        {
            frmQuanLyTinhTrang frm = new frmQuanLyTinhTrang();
            frm.ShowDialog();
            loadDataTinhTrang();
        }

        private void reloadTinhTrang(List<TinhTrang> list)
        {
            loadDataTinhTrang(list, true);
            lookUpTinhTrang.EditValue = id;
        }

        private void reloadLoaiTS(List<LoaiTaiSan> list)
        {
            loadDataLoaiTS(list, true);
            ucComboBoxLoaiTS1.LoaiTS = objLoaiTS;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bandedGridViewTaiSan.GetFocusedRow() != null)
            {
                CTTaiSan obj = (bandedGridViewTaiSan.GetFocusedRow() as TaiSanHienThi).obj;
                listCTTaiSan.Remove(obj);
                gridControlTaiSan.DataSource = listCTTaiSan;
            }
        }

    }
}