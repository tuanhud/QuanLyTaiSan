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

namespace PTB_GUI.QLTinhTrang
{
    public partial class ucQuanLyTinhTrang_Control : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyTinhTrang_Control()
        {
            InitializeComponent();
        }

        public PanelControl getControl()
        {
            checkBtnTinhTrang_TB.Checked = true;
            return panelTinhTrang_Control;
        }

        public delegate void LoadData(bool isThietBi);
        public LoadData loadData = null;

        private void checkBtnTinhTrang_P_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnTinhTrang_P.Checked && this.Parent != null)
            {
                if (loadData != null)
                {
                    loadData(false);
                    checkBtnTinhTrang_TB.Checked = !checkBtnTinhTrang_P.Checked;
                }
            }
        }

        private void checkBtnTinhTrang_TB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBtnTinhTrang_TB.Checked && this.Parent != null)
            {
                if (loadData != null)
                {
                    loadData(true);
                    checkBtnTinhTrang_P.Checked = !checkBtnTinhTrang_TB.Checked;
                }
            }
        }
    }
}
