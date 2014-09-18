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
    public partial class frmTinhTrangVaSoLuong : QuanLyTaiSanGUI.MyForm.frmCustomXtraForm
    {

        public delegate void SetTinhTrangAndSoLuong(TinhTrang _obj, int _sl, String _str, bool _all);
        public SetTinhTrangAndSoLuong setTinhTrangAndSoLuong = null;

        public frmTinhTrangVaSoLuong()
        {
            InitializeComponent();
        }

        public frmTinhTrangVaSoLuong(bool _loaichung)
        {
            InitializeComponent();
            List<TinhTrang> list = TinhTrang.getAllForTHIETBI();
            lookUpEdit1.Properties.DataSource = list;
            spinEdit1.Properties.ReadOnly = !_loaichung;
            if (list.Count > 0)
                lookUpEdit1.EditValue = list.First().id;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (setTinhTrangAndSoLuong != null)
                setTinhTrangAndSoLuong(lookUpEdit1.GetSelectedDataRow() as TinhTrang, Convert.ToInt32(spinEdit1.EditValue), txtGhiChu.Text, false);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYesToAll_Click(object sender, EventArgs e)
        {
            if (setTinhTrangAndSoLuong != null)
                setTinhTrangAndSoLuong(lookUpEdit1.GetSelectedDataRow() as TinhTrang, Convert.ToInt32(spinEdit1.EditValue), txtGhiChu.Text, true);
            this.Close();
        }
    }
}