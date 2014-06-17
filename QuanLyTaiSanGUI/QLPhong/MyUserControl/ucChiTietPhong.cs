using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTaiSanGUI.MyUC;

namespace QuanLyTaiSanGUI.MyUserControl
{
    public partial class ucChiTietPhong : UserControl
    {
        ucTreeViTri _ucTreeViTri = new ucTreeViTri(true, true);
        public ucChiTietPhong()
        {
            InitializeComponent();
            panelControl1.Controls.Add(_ucTreeViTri);
        }
        public void LoadData(String _ten)
        {

        }
    }
}
