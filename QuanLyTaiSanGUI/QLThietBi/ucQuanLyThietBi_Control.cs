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

        public PanelControl getControl()
        {
            return panelControl1;
        }

        public void enable_disableRiengChung(Boolean enable)
        {
            checkBtnTheoSL.Checked = enable;
            checkBtnTheoCT.Checked = !enable;
        }

        private void checkBtnTheoSL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnTheoSL.Checked && this.Parent != null)
            {
                ucQuanLyThietBi _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi;
                _ucQuanLyThietBi.loadData(true);
                checkBtnTheoSL.ForeColor = Color.Red;
                checkBtnTheoCT.ForeColor = Color.Empty;
                panelControl1.Focus();
            }
        }

        private void checkBtnTheoCT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnTheoCT.Checked && this.Parent != null)
            {
                ucQuanLyThietBi _ucQuanLyThietBi = this.Parent as ucQuanLyThietBi;
                _ucQuanLyThietBi.loadData(false);
                checkBtnTheoSL.ForeColor = Color.Empty;
                checkBtnTheoCT.ForeColor = Color.Red;
                panelControl1.Focus();
            }
        }
    }
}
