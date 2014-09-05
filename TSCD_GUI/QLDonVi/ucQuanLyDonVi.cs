using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TSCD_GUI.QLDonVi
{
    public partial class ucQuanLyDonVi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyDonVi()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlDonVi.Parent = null;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlDonVi;
        }
    }
}
