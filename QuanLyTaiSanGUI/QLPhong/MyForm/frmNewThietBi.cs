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
        ucComboBoxPhong _ucComboBoxPhong = null;
        public frmNewThietBi()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            List<LoaiThietBi> listTB = new LoaiThietBi().getAll();
            _ucTreeLoaiTB = new ucTreeLoaiTB(listTB);
            _ucTreeLoaiTB.Dock = DockStyle.Fill;
            panelLoaiTB.Controls.Add(_ucTreeLoaiTB);
            List<PhongFilter> listPhong = new PhongFilter().getAll();
            _ucComboBoxPhong = new ucComboBoxPhong(listPhong);
            _ucComboBoxPhong.Dock = DockStyle.Fill;
            panelPhong.Controls.Add(_ucComboBoxPhong);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = true;
        }
    }
}
