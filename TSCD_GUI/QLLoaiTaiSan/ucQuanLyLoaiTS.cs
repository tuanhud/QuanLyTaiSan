using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TSCD_GUI.QLLoaiTaiSan
{
    public partial class ucQuanLyLoaiTS : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyLoaiTS()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlLoaiTS.Parent = null;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlLoaiTS;
        }
    }
}
