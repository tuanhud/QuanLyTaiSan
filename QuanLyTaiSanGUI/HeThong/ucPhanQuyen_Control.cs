using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyTaiSanGUI.HeThong
{
    public partial class ucPhanQuyen_Control : UserControl
    {
        public ucPhanQuyen_Control()
        {
            InitializeComponent();
        }

        private void btnQTV_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                ucPhanQuyen _ucPhanQuyen = this.Parent as ucPhanQuyen;
                _ucPhanQuyen.showGroup(false);
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                ucPhanQuyen _ucPhanQuyen = this.Parent as ucPhanQuyen;
                _ucPhanQuyen.showGroup(true);
            }
        }

        public PanelControl getControl()
        {
            return panelPhanQuyen_Control;
        }
    }
}
