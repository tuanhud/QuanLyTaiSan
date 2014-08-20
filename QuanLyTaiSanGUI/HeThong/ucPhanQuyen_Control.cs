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

        public PanelControl getControl()
        {
            checkBtnQTV.Checked = true;
            return panelPhanQuyen_Control;
        }

        private void checkBtnGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnGroup.Checked && this.Parent != null)
            {
                ucPhanQuyen _ucPhanQuyen = this.Parent as ucPhanQuyen;
                if (_ucPhanQuyen.showGroup(true))
                    checkBtnQTV.Checked = !checkBtnGroup.Checked;
                else
                    checkBtnGroup.Checked = false;
            }
        }

        private void checkBtnQTV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnQTV.Checked && this.Parent != null)
            {
                ucPhanQuyen _ucPhanQuyen = this.Parent as ucPhanQuyen;
                if (_ucPhanQuyen.showGroup(false))
                    checkBtnGroup.Checked = !checkBtnQTV.Checked;
                else
                    checkBtnQTV.Checked = false;
            }
        }
    }
}
