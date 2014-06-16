using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.QLNhanVien
{
    public partial class ucQuanLyNhanVien : UserControl
    {
        public ucQuanLyNhanVien()
        {
            InitializeComponent();
            this.nHANVIENPTSTableAdapter.Fill(this.dataSet1.NHANVIENPTS);
            this.pHONGSTableAdapter.Fill(this.dataSet1.PHONGS);
        }
    }
}
