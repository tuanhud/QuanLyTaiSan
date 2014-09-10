using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TSCD.DataFilter;
using TSCD.Entities;

namespace TSCD_GUI.QLTaiSan
{
    public partial class frmAddTaiSan_DonVi : DevExpress.XtraEditors.XtraForm
    {
        DonVi objDonVi = null;
        public delegate void ReloadAndFocused(Guid id);
        public ReloadAndFocused reloadAndFocused = null;
        frmInputViTri_DonVi frm = new frmInputViTri_DonVi();

        public frmAddTaiSan_DonVi()
        {
            InitializeComponent();
            loadData();
            init();
        }

        public frmAddTaiSan_DonVi(DonVi obj)
        {
            InitializeComponent();
            loadData();
            objDonVi = obj;
            init();
        }

        private void init()
        {
            frm.add = new frmInputViTri_DonVi.Add(add);
        }

        private void loadData()
        {
            ucQuanLyTaiSan1.loadData();
            frm.loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CTTaiSan obj = ucQuanLyTaiSan1.CTTaiSan;
            if (obj != null)
            {
                frm .setData(objDonVi, obj.soluong);
                frm.ShowDialog();
            }
        }

        private void add(DateTime ngayGhi, String soHieu_CT, DateTime ngay_CT, int soLuong, Phong phong, ViTri viTri, DonVi donViQL, DonVi donViSD, String ghiChu)
        {
            try
            {
                Guid id = Add(ngayGhi, soHieu_CT, ngay_CT, soLuong, phong, viTri, donViQL, donViSD, ghiChu);
                if (id != Guid.Empty)
                {
                    if (reloadAndFocused != null)
                        reloadAndFocused(id);
                }
            }
            catch { }
        }

        private Guid Add(DateTime ngayGhi, String soHieu_CT, DateTime ngay_CT, int soLuong, Phong phong, ViTri viTri, DonVi donViQL, DonVi donViSD, String ghiChu)
        {
            CTTaiSan obj = ucQuanLyTaiSan1.CTTaiSan;
            int re = obj.chuyenDoi(donViQL, donViSD, obj.tinhtrang, viTri, phong, obj.parent, ngay_CT, soHieu_CT, soLuong, ghiChu, ngayGhi);
            if (re > 0 && DBInstance.commit() > 0)
            {
                XtraMessageBox.Show("Pass");
                return CTTaiSan.getQuery().Where(c=>c.taisan_id == obj.taisan_id && c.donviquanly_id == donViQL.id && c.soluong == soLuong).FirstOrDefault().id;
            }
            else
            {
                XtraMessageBox.Show("Fail");
                return Guid.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}