using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            NhanVienPT obj = new NhanVienPT();
            List<NhanVienPT> list = obj.getAll().ToList();
            gridControlNhanVien.DataSource = list;
        }

        private void gridViewNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewNhanVien.GetFocusedRow() != null)
            {
                NhanVienPT obj = (NhanVienPT)gridViewNhanVien.GetFocusedRow();
                txtMa.Text = obj.subId;
                txtTen.Text = obj.hoten;
                txtSodt.Text = obj.sodienthoai;
            }
        }
    }
}
