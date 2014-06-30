using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.DataFilter;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUC;

namespace QuanLyTaiSanGUI.QLPhong
{
    public partial class frmChuyen : Form
    {
        ucComboBoxViTri _ucComboBoxViTri = new ucComboBoxViTri(false, true);
        CTThietBi objCTThietBi = null;
        public frmChuyen()
        {
            InitializeComponent();
            init();
            loadData();
        }

        private void init()
        {
            _ucComboBoxViTri.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucComboBoxViTri);
        }

        public frmChuyen(CTThietBi obj)
        {
            InitializeComponent();
            init();
            loadData();
            setData(obj);
        }

        public void loadData()
        {
            List<ViTriHienThi> listViTriHienThi = ViTriHienThi.getAllHavePhong();
            _ucComboBoxViTri.loadData(listViTriHienThi);
            List<TinhTrang> listTinhTrang = TinhTrang.getAll();
            lookUpTinhTrang.Properties.DataSource = listTinhTrang;
        }

        public void setData(CTThietBi obj)
        {
            objCTThietBi = obj;
            lblMa.Text = obj.thietbi.subId;
            lblTen.Text = obj.thietbi.ten;
            lblLoai.Text = obj.thietbi.loaithietbi.ten;
            lblPhong.Text = obj.phong.ten;
            lblTinhTrang.Text = obj.tinhtrang.value;
            lblSoLuong.Text = obj.soluong.ToString();
            lookUpTinhTrang.EditValue = obj.tinhtrang_id;
            txtSoLuong.Properties.MaxValue = obj.soluong;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBtnChuyenPhong_CheckedChanged(object sender, EventArgs e)
        {
            _ucComboBoxViTri.setReadOnly(!radioBtnChuyenPhong.Checked);
        }

        private void radioBtnChuyenTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            _ucComboBoxViTri.setReadOnly(radioBtnChuyenTinhTrang.Checked);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioBtnChuyenPhong.Checked)
            {
                //objCTThietBi.dichuyen(_ucComboBoxViTri.getPhong(), 1, txtGhiChu.Text);
            }
        }
    }
}
