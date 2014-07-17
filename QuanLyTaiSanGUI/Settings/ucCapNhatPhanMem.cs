using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.Settings
{
    public partial class ucCapNhatPhanMem : UserControl
    {
        public ucCapNhatPhanMem()
        {
            InitializeComponent();
            panelControlCapNhatPhanMem.Visible = false;
        }

        private void btnCapNhatPhanMem_Click(object sender, EventArgs e)
        {
            panelControlCapNhatPhanMem.Visible = true;
        }
    }
}
