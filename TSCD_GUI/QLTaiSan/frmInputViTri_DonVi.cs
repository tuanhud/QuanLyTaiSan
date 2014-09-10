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

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmInputViTri_DonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmInputViTri_DonVi()
        {
            InitializeComponent();
        }

        public void setData(DonVi obj, int soLuong)
        {
            ucComboBoxDonVi1.DonVi = obj;
            ucComboBoxDonVi2.DonVi = obj;
            txtSoLuong.Properties.MinValue = 1;
            txtSoLuong.Properties.MaxValue = soLuong;
        }

        public void loadData()
        {
            List<DonVi> list = DonVi.getQuery().OrderBy(c => c.parent_id).ThenBy(c => c.ten).ToList();
            ucComboBoxDonVi1.DataSource = list;
            ucComboBoxDonVi2.DataSource = list;
            ucComboBoxViTri1.init(false, true);
            ucComboBoxViTri1.DataSource = ViTriHienThi.getAllHavePhong();
            ucComboBoxViTri2.DataSource = ViTriHienThi.getAll();
        }

        public delegate void Add(DateTime ngayGhi, String soHieu_CT, DateTime ngay_CT, int soLuong, Phong phong, ViTri viTri, DonVi donViQL, DonVi donViSD, String ghiChu);
        public Add add = null;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                if (add != null)
                {
                    DateTime ngayGhi = dateNgayGhi.EditValue != null ? dateNgayGhi.DateTime : DateTime.Now;
                    String soHieu_CT = txtSoHieu_CT.Text;
                    DateTime ngay_CT = dateNgay_CT.EditValue != null ? dateNgay_CT.DateTime : DateTime.Now;
                    int soLuong = Convert.ToInt32(txtSoLuong.EditValue);
                    Phong phong = ucComboBoxViTri1.Phong;
                    ViTri viTri = ucComboBoxViTri2.ViTri;
                    DonVi donViQL = ucComboBoxDonVi1.DonVi;
                    DonVi donViSD = ucComboBoxDonVi2.DonVi;
                    String ghiChu = txtGhiChu.Text;
                    add(ngayGhi, soHieu_CT, ngay_CT, soLuong, phong, viTri, donViQL, donViSD, ghiChu);
                }
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