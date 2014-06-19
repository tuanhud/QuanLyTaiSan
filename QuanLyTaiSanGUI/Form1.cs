using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using QuanLyTaiSan.Entities;
using QuanLyTaiSanGUI.MyUC;
using QuanLyTaiSanGUI.QLLoaiThietBi;

namespace QuanLyTaiSanGUI
{
    public partial class Form1 : Form
    {
        ucFreeHaveCheckBox _ucFreeHaveCheckBox = new ucFreeHaveCheckBox();
        public Form1()
        {
            InitializeComponent();
            _ucFreeHaveCheckBox.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(_ucFreeHaveCheckBox);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int _idobject = 1;
            string _loaiobject = "COSOS";
            List<CoSo> listcoso = new List<CoSo>();
            CoSo _coso = new CoSo().getById(_idobject);
            List<HinhAnh> hinhanh = _coso.hinhanhs.ToList();
            frmHinhAnh frm = new frmHinhAnh(_idobject, hinhanh, _loaiobject);
            frm.Show();
        }
    }
}
