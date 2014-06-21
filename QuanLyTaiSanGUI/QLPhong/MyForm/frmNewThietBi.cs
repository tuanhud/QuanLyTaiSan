using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUserControl;
using QuanLyTaiSan.DataFilter;

namespace QuanLyTaiSanGUI.MyForm
{
    public partial class frmNewThietBi : Form
    {
        ucTreeLoaiTB _ucTreeLoaiTB = null;
        ucTreeViTri _ucTreeViTri = null;
        public frmNewThietBi()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            List<LoaiThietBi> listTB = new LoaiThietBi().getAll();
            _ucTreeLoaiTB = new ucTreeLoaiTB(listTB);
            _ucTreeLoaiTB.type = "add";
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Add(_ucTreeLoaiTB);
            List<PhongFilter> listPhong = new PhongFilter().getAll();
            List<ViTriFilter> listVT = new ViTriFilter().getAllHavePhong();
            _ucTreeViTri = new ucTreeViTri(listVT, false, true);
            _ucTreeViTri.Dock = DockStyle.Fill;
            _ucTreeViTri.setReadOnly(false);
            panelPhong.Controls.Add(_ucTreeViTri);
            List<TinhTrang> listTR = new TinhTrang().getAll();
            lookUpTinhTrang.Properties.DataSource = listTR;
            if (listTR.Count > 0)
                lookUpTinhTrang.EditValue = listTR.First().id;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = true;
        }

        public void LoaiTB_FocusedChanged(bool _loaiChung)
        {
            groupControl1.Visible = !_loaiChung;
        }
    }
}
