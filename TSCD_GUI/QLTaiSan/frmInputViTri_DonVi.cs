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
using TSCD.DataFilter;
using SHARED.Libraries;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmInputViTri_DonVi : DevExpress.XtraEditors.XtraForm
    {
        CTTaiSan objCTTaiSan = null;
        bool isChuyen = false;

        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;

        public frmInputViTri_DonVi()
        {
            InitializeComponent();
            ucComboBoxViTri1.NullText = "";//"[Chưa chọn phòng]";
            ucComboBoxViTri2.NullText = "";//"[Chưa chọn vi trí]";
        }

        public frmInputViTri_DonVi(CTTaiSan _objCTTaiSan)
        {
            InitializeComponent();
            isChuyen = true;
            ucComboBoxViTri1.NullText = "";//"[Chưa chọn phòng]";
            ucComboBoxViTri2.NullText = "";//"[Chưa chọn vi trí]";
            objCTTaiSan = _objCTTaiSan;
            loadData();
            setData();
        }

        public void setData(CTTaiSan _objCTTaiSan, DonVi _objDonVi)
        {
            try
            {
                objCTTaiSan = _objCTTaiSan;
                lookUpTinhTrang.EditValue = objCTTaiSan.tinhtrang_id;
                ucComboBoxDonVi1.DonVi = _objDonVi;
                ucComboBoxDonVi2.DonVi = _objDonVi;
                txtSoLuong.Properties.MinValue = 1;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        private void setData()
        {
            try
            {
                dateNgayGhi.EditValue = objCTTaiSan.ngay;
                dateNgay_CT.EditValue = objCTTaiSan.chungtu_ngay;
                txtSoHieu_CT.Text = objCTTaiSan.chungtu_sohieu;
                lookUpTinhTrang.EditValue = objCTTaiSan.tinhtrang_id;
                ucComboBoxViTri1.Phong = objCTTaiSan.phong;
                ucComboBoxViTri2.ViTri = objCTTaiSan.vitri;
                ucComboBoxDonVi1.DonVi = objCTTaiSan.donviquanly;
                ucComboBoxDonVi2.DonVi = objCTTaiSan.donvisudung;
                txtSoLuong.Properties.MinValue = 0;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->setData:" + ex.Message);
            }
        }

        public void loadData()
        {
            try
            {
                List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
                DonVi objNULL = new DonVi();
                objNULL.id = Guid.Empty;
                objNULL.ten = "[Không có đơn vị]";
                objNULL.parent = null;
                list.Insert(0, objNULL);
                ucComboBoxDonVi1.DataSource = list;
                ucComboBoxDonVi2.DataSource = list;
                ucComboBoxViTri1.init(false, true);
                List<ViTriHienThi> listPhong = ViTriHienThi.getAllHavePhong();
                ViTriHienThi objPhongNULL = new ViTriHienThi();
                objPhongNULL.id = Guid.Empty;
                objPhongNULL.ten = "[Không có phòng]";
                objPhongNULL.loai = typeof(Phong).Name;
                objPhongNULL.parent_id = Guid.Empty;
                listPhong.Insert(0, objPhongNULL);
                ucComboBoxViTri1.DataSource = listPhong;
                List<ViTriHienThi> listViTri = ViTriHienThi.getAll();
                ViTriHienThi objViTriNULL = new ViTriHienThi();
                objViTriNULL.ten = "[Không có vị trí]";
                objViTriNULL.loai = typeof(CoSo).Name;
                objViTriNULL.parent_id = Guid.Empty;
                listViTri.Insert(0, objViTriNULL);
                ucComboBoxViTri2.DataSource = listViTri;
                lookUpTinhTrang.Properties.DataSource = TinhTrang.getQuery().OrderBy(c => c.order).ToList();
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
                    DateTime ngayGhi = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
                    String soHieu_CT = txtSoHieu_CT.Text;
                    DateTime ngay_CT = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                    int soLuong = Convert.ToInt32(txtSoLuong.EditValue);
                    TinhTrang tinhTrang = TinhTrang.getById(GUID.From(lookUpTinhTrang.EditValue));
                    Phong phong = ucComboBoxViTri1.Phong;
                    ViTri viTri = ucComboBoxViTri2.ViTri;
                    DonVi donViQL = ucComboBoxDonVi1.DonVi;
                    DonVi donViSD = ucComboBoxDonVi2.DonVi;
                    String ghiChu = txtGhiChu.Text;
                    int re = objCTTaiSan.chuyenDonVi(donViQL, donViSD, viTri, phong, objCTTaiSan.parent, ngay_CT, soHieu_CT, soLuong, ghiChu, ngayGhi);
                    if (re > 0 && DBInstance.commit() > 0)
                    {
                        if(isChuyen)
                            XtraMessageBox.Show("Chuyển tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Thêm tài sản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Guid id = CTTaiSan.getQuery().Where(c => c.taisan_id == objCTTaiSan.taisan_id && c.donviquanly_id == donViQL.id && c.soluong == soLuong).FirstOrDefault().id;
                        if (reloadAndFocused != null)
                            reloadAndFocused(id);
                        this.Close();
                    }
                    else
                    {
                        if (isChuyen)
                            XtraMessageBox.Show("Chuyển tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Chuyển tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click: " + ex.Message);
            }
        }

        private bool checkInput()
        {
            DonVi donViQL = ucComboBoxDonVi1.DonVi;
            if (donViQL == null && donViQL.id == Guid.Empty)
            {
                XtraMessageBox.Show("Chưa chọn đơn vị quản lý");
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}