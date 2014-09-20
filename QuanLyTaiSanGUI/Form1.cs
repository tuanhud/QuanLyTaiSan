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

namespace PTB_GUI
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            PTB_GUI.QLTinhTrang.ucQuanLyTinhTrang uc = new PTB_GUI.QLTinhTrang.ucQuanLyTinhTrang();
            uc.Dock = DockStyle.Fill;
            uc.loadData();
            panelControl1.Controls.Add(uc);
        }
    }
}