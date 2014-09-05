using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TSCD_GUI.QLTaiSan
{
    public partial class ucQuanLyDonVi_TaiSan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyDonVi_TaiSan()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlDonVi_TaiSan.Parent = null;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi_TaiSan;
        }
    }
}
