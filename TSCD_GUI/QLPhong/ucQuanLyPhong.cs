using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TSCD_GUI.QLPhong
{
    public partial class ucQuanLyPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyPhong()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            rbnControlPhong.Parent = null;
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl getRibbonControl()
        {
            return rbnControlPhong;
        }
    }
}
