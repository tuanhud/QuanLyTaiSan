using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucDisplaySetting : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDisplaySetting()
        {
            InitializeComponent();
        }
        public int save()
        {
            //Properties.Settings.Default... = textEdit_skinCode.Text;
            Properties.Settings.Default.Save();
            return 1;
        }

        private void ucDisplaySetting_Load(object sender, EventArgs e)
        {
            //textEdit_skinCode.Text =
            //    Properties.Settings.Default...;
        }
    }
}
