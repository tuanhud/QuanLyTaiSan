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

namespace QuanLyTaiSanGUI.QLThietBi
{
    public partial class ucQuanLyThietBi_Control : UserControl
    {
        public ucQuanLyThietBi_Control()
        {
            InitializeComponent();
        }

        private void btnLoaiChung_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                ucQuanLyThietBi _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi;
                _ucQuanLyThietBi.loadData(true);
            }
        }

        private void btnLoaiRieng_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                ucQuanLyThietBi _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi;
                _ucQuanLyThietBi.loadData(false);
            }
        }

        public PanelControl getControl()
        {
            return panelControl1;
        }

        public void enable_disableRiengChung(Boolean enable)
        {
            btnLoaiChung.Enabled = !enable;
            btnLoaiRieng.Enabled = enable;
        }
    }
}
