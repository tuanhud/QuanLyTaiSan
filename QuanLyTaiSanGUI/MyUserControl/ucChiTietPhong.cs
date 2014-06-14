using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietPhong : UserControl
    {
        public ucChiTietPhong()
        {
            InitializeComponent();
        }
        public void LoadData(String _ten)
        {
            int _id = Convert.ToInt32(this.phongsTableAdapter.ScalarQuery(_ten));
            DataTable dt = this.phongsTableAdapter.GetDataBy1(_id);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                textEdit1.Text = r["ten"].ToString();
                textEdit2.Text = r["tencoso"].ToString();
                textEdit3.Text = r["tenday"].ToString();
                textEdit4.Text = r["tentang"].ToString();
                textEdit5.Text = r["mota"].ToString();
                lblMaNhanVien.Text = r["manhanvien"].ToString();
                lblTenNhanVien.Text = r["hoten"].ToString();
                lblSoDienThoai.Text = r["sodienthoai"].ToString();
            }
        }
    }
}
