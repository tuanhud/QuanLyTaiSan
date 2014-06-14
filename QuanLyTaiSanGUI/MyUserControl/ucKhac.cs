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
    public partial class ucKhac : UserControl
    {
        public ucKhac()
        {
            InitializeComponent();
        }

        private void ucKhac_Load(object sender, EventArgs e)
        {
            this.dAYSTableAdapter.Fill(this.dataSet1.DAYS);
            this.cOSOSTableAdapter.Fill(this.dataSet1.COSOS);
            this.lOAITHIETBISTableAdapter.Fill(this.dataSet1.LOAITHIETBIS);
        }
    }
}
