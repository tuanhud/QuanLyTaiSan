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

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmChuyenTinhTrang : DevExpress.XtraEditors.XtraForm
    {
        CTTaiSan objCTTaiSan = null;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;

        public frmChuyenTinhTrang()
        {
            InitializeComponent();
        }

        public frmChuyenTinhTrang(CTTaiSan obj)
        {
            InitializeComponent();
            objCTTaiSan = obj;
            loadData();
            setData();
        }

        private void loadData()
        {
            lookUpTinhTrang.Properties.DataSource = TinhTrang.getQuery().OrderBy(c => c.order).ToList();
        }

        private void setData()
        {
            dateNgayGhi.EditValue = objCTTaiSan.ngay;
            dateNgay_CT.EditValue = objCTTaiSan.chungtu_ngay;
            lookUpTinhTrang.EditValue = objCTTaiSan.tinhtrang_id;
            txtSoHieu_CT.Text = objCTTaiSan.chungtu_sohieu;
            txtSoLuong.Properties.MinValue = 0;
            txtSoLuong.Properties.MaxValue = objCTTaiSan.soluong;
            txtSoLuong.EditValue = objCTTaiSan.soluong;
            lbltxtDonViTinh.Text = objCTTaiSan.taisan.loaitaisan.donvitinh != null ? objCTTaiSan.taisan.loaitaisan.donvitinh.ten : "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayGhi = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
                String soHieu_CT = txtSoHieu_CT.Text;
                DateTime ngay_CT = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                int soLuong = Convert.ToInt32(txtSoLuong.EditValue);
                TinhTrang tinhTrang = TinhTrang.getById(lookUpTinhTrang.EditValue);
                String ghiChu = txtGhiChu.Text;
                int re = objCTTaiSan.chuyenTinhTrang(ngay_CT, soHieu_CT, tinhTrang);
                if (re > 0 && DBInstance.commit() > 0)
                {
                    XtraMessageBox.Show("Chuyển tình trạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Guid id = CTTaiSan.getQuery().Where(c => c.taisan_id == objCTTaiSan.taisan_id && c.tinhtrang_id == tinhTrang.id && c.soluong == soLuong).FirstOrDefault().id;
                    if (reloadAndFocused != null)
                        reloadAndFocused(id);
                    this.Close();
                }
                else
                    XtraMessageBox.Show("Chuyển tình trạng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(this.Name + "->btnOK_Click: " + ex.Message);
            }
        }

        private void btnTinhTrang_Click(object sender, EventArgs e)
        {
            frmQuanLyTinhTrang frm = new frmQuanLyTinhTrang();
            frm.ShowDialog();
            loadData();
        }
    }
}