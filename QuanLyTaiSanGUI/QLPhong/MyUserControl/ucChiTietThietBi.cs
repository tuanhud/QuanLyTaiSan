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
    public partial class ucChiTietThietBi : UserControl
    {
        ucComboBoxPhong uc = new ucComboBoxPhong();
        public ucChiTietThietBi()
        {
            InitializeComponent();
            uc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uc);
        }
        public void LoadData(int _id)
        {

        }
    }
}
