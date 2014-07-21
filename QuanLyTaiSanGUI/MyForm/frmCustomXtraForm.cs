using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.MyForm
{
    public partial class frmCustomXtraForm : XtraForm
    {
        public frmCustomXtraForm()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SkinName = Properties.Settings.Default["ApplicationSkinName"].ToString();
        }
    }
}
