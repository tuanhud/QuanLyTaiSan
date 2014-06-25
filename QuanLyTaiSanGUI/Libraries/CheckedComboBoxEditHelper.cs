using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanGUI.Libraries
{
    class CheckedComboBoxEditHelper
    {
        public static List<int> getCheckedValueArray(CheckedComboBoxEdit control)
        {
            List<int> re = new List<int>();
            if (control == null)
            {
                return re;
            }

            for (int i = 0; i < control.Properties.Items.Count; i++)
            {
                if (control.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    re.Add(Convert.ToInt32(control.Properties.Items[i].Value));
                }
            }

            return re;
        }
    }
}
