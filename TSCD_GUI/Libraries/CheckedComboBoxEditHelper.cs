using DevExpress.XtraEditors;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSCD_GUI.Libraries
{
    class CheckedComboBoxEditHelper
    {
        public static List<Guid> getCheckedValueArray(CheckedComboBoxEdit control)
        {
            List<Guid> re = new List<Guid>();
            if (control == null)
            {
                return re;
            }

            for (int i = 0; i < control.Properties.Items.Count; i++)
            {
                if (control.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    re.Add(GUID.From(control.Properties.Items[i].Value));
                }
            }

            return re;
        }
    }
}
