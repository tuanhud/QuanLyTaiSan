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
        ChungTu objChungTu = null;
        bool isChuyen = false;

        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;

        public frmInputViTri_DonVi()
        {
            InitializeComponent();
            ucComboBoxViTri1.NullText = "";//"[Chưa chọn phòng]";
            ucComboBoxViTri2.NullText = "";//"[Chưa chọn vi trí]";
            ucComboBoxViTri1.editValueChanged = new MyUserControl.ucComboBoxViTri.EditValueChanged(phongEditValueChanged);
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
                objChungTu = objCTTaiSan.chungtu;
                dateNgayGhi.EditValue = objCTTaiSan.ngay;
                dateNgay_CT.EditValue = objCTTaiSan.chungtu != null ? objCTTaiSan.chungtu.ngay : null;
                txtSoHieu_CT.Text = objCTTaiSan.chungtu != null ? objCTTaiSan.chungtu.sohieu : "";
                ucComboBoxDonVi1.DonVi = _objDonVi;
                txtSoLuong.Properties.MinValue = 1;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
                lbltxtDonViTinh.Text = objCTTaiSan.taisan.loaitaisan.donvitinh != null ? objCTTaiSan.taisan.loaitaisan.donvitinh.ten : "";
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
                objChungTu = objCTTaiSan.chungtu;
                dateNgayGhi.EditValue = objCTTaiSan.ngay;
                dateNgay_CT.EditValue = objCTTaiSan.chungtu.ngay;
                txtSoHieu_CT.Text = objCTTaiSan.chungtu.sohieu;
                ucComboBoxViTri1.Phong = objCTTaiSan.phong;
                ucComboBoxViTri2.ViTri = objCTTaiSan.vitri;
                ucComboBoxDonVi1.DonVi = objCTTaiSan.donviquanly;
                txtSoLuong.Properties.MinValue = 0;
                txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
                txtSoLuong.EditValue = objCTTaiSan.soluong;
                lbltxtDonViTinh.Text = objCTTaiSan.taisan.loaitaisan.donvitinh != null ? objCTTaiSan.taisan.loaitaisan.donvitinh.ten : "";
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
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormLoad), true, true, false);
                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Đang xử lý...");
                    DateTime ngayGhi = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
                    objChungTu.sohieu = txtSoHieu_CT.Text;
                    objChungTu.ngay = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                    int soLuong = Convert.ToInt32(txtSoLuong.EditValue);
                    Phong phong = ucComboBoxViTri1.Phong;
                    ViTri viTri = ucComboBoxViTri2.ViTri;
                    DonVi donViQL = ucComboBoxDonVi1.DonVi;
                    String ghiChu = txtGhiChu.Text;
                    int re = objCTTaiSan.chuyenDonVi(donViQL, null, viTri, phong, objCTTaiSan.parent, objChungTu, soLuong, ghiChu, ngayGhi);
                    if (re > 0 && DBInstance.commit() > 0)
                    {
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
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
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                        if (isChuyen)
                            XtraMessageBox.Show("Chuyển tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Thêm tài sản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void phongEditValueChanged()
        {
            Phong obj = ucComboBoxViTri1.Phong;
            if (obj != null && obj.vitri != null)
                ucComboBoxViTri2.ViTri = obj.vitri;
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            if (objChungTu != null)
            {
                frmFileChungTu frm = new frmFileChungTu(objChungTu);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    objChungTu = frm.ct;
            }
        }
    }
}