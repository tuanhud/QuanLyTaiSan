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
        List<CTTaiSan> listCTTaiSan = new List<CTTaiSan>();
        CTTaiSan objCTTaiSan = null;
        bool isEdit = false;

        public frmAddTaiSan(CTTaiSan _obj)
        {
            InitializeComponent();
            loadData();
            objCTTaiSan = _obj;
            isEdit = true;
            init();
            setData(_obj);
        }

        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;

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
            lookUpTinhTrang.Properties.DataSource = TinhTrang.getQuery().OrderBy(c => c.order).ToList();
            ucComboBoxLoaiTS1.DataSource = LoaiTaiSan.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
        }

        private void setData(CTTaiSan obj)
        {
            dateNgayGhi.EditValue = obj.ngay;
            txtSoHieu_CT.Text = obj.chungtu_sohieu;
            dateNgay_CT.EditValue = obj.chungtu_ngay;
            txtMa.Text = obj.taisan.subId;
            txtTen.Text = obj.taisan.ten;
            ucComboBoxLoaiTS1.LoaiTS = obj.taisan.loaitaisan;
            txtSoLuong.EditValue = obj.soluong;
            txtDonGia.EditValue = obj.taisan.dongia;
            lookUpTinhTrang.EditValue = obj.tinhtrang_id;
            txtNguonGoc.Text = obj.nguongoc;
            txtGhiChu.Text = obj.mota;
            listCTTaiSan = obj.childs.ToList();
            gridControlTaiSan.DataSource = TaiSanHienThi.Convert(listCTTaiSan);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInput())
                {
                    Guid id;
                    if (isEdit)
                        id = edit();
                    else
                        id = add();
                    if (id != Guid.Empty && reloadAndFocused != null)
                        reloadAndFocused(id);
                }
            }
            catch
            { }
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

        private Guid add()
        {
            TaiSan ts = new TaiSan();
            ts.ten = txtTen.Text;
            ts.dongia = txtDonGia.EditValue != null ? long.Parse(txtDonGia.EditValue.ToString()) : 0;
            ts.loaitaisan = ucComboBoxLoaiTS1.LoaiTS;
            ts.subId = txtMa.Text;


            CTTaiSan obj = new CTTaiSan();

            obj.taisan = ts;
            obj.chungtu_ngay = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
            obj.chungtu_sohieu = txtSoHieu_CT.Text;
            obj.ngay = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
            obj.nguongoc = txtNguonGoc.Text;
            obj.soluong = Convert.ToInt32(txtSoLuong.EditValue);
            obj.tinhtrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
            obj.mota = txtGhiChu.Text;
            obj.childs = listCTTaiSan;
            int re = obj.add();//ONly call add on CTTaiSan

            re = DBInstance.commit();
            if (re > 0)
            {
                XtraMessageBox.Show("Pass");
                return obj.id;
            }
            else
            {
                XtraMessageBox.Show("Fail");
                return Guid.Empty;
            }
        }

        private Guid edit()
        {
            objCTTaiSan.taisan.ten = txtTen.Text;
            objCTTaiSan.taisan.dongia = txtDonGia.EditValue != null ? long.Parse(txtDonGia.EditValue.ToString()) : 0;
            objCTTaiSan.taisan.loaitaisan = ucComboBoxLoaiTS1.LoaiTS;
            objCTTaiSan.taisan.subId = txtMa.Text;
            objCTTaiSan.chungtu_ngay = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
            objCTTaiSan.chungtu_sohieu = txtSoHieu_CT.Text;
            objCTTaiSan.ngay = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
            objCTTaiSan.nguongoc = txtNguonGoc.Text;
            objCTTaiSan.soluong = Convert.ToInt32(txtSoLuong.EditValue);
            objCTTaiSan.tinhtrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
            objCTTaiSan.mota = txtGhiChu.Text;
            objCTTaiSan.childs = listCTTaiSan;
            int re = objCTTaiSan.update();//ONly call add on CTTaiSan

            re = DBInstance.commit();
            if (re > 0)
            {
                XtraMessageBox.Show("Pass");
                return objCTTaiSan.id;
            }
            else
            {
                XtraMessageBox.Show("Fail");
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
            lbltxtDonViTinh.Text = ucComboBoxLoaiTS1.LoaiTS.donvitinh.ten;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddTaiSanKemTheo frm = new frmAddTaiSanKemTheo(listCTTaiSan);
            frm.reloadAndFocused = new frmAddTaiSanKemTheo.ReloadAndFocused(reload);
            frm.ShowDialog();
        }

        private void reload(Guid _id)
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

    }
}