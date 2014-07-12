using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLPhong.MyForm
{
    public partial class frmTinhTrangVaSoLuong : DevExpress.XtraEditors.XtraForm
    {
        public TinhTrang objTinhTrang = new TinhTrang();
        public int SoLuong = -1;
        public frmTinhTrangVaSoLuong()
        {
            InitializeComponent();
        }

        public frmTinhTrangVaSoLuong(bool _loaichung)
        {
            InitializeComponent();
            List<TinhTrang> list = TinhTrang.getAll();
            lookUpEdit1.Properties.DataSource = list;
            spinEdit1.Properties.ReadOnly = !_loaichung;
            if (list.Count > 0)
                lookUpEdit1.EditValue = list.First().id;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            objTinhTrang = lookUpEdit1.GetSelectedDataRow() as TinhTrang;
            SoLuong = Convert.ToInt32(spinEdit1.EditValue);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYesToAll_Click(object sender, EventArgs e)
        {
            objTinhTrang = lookUpEdit1.GetSelectedDataRow() as TinhTrang;
            SoLuong = Convert.ToInt32(spinEdit1.EditValue);
        }
    }
}