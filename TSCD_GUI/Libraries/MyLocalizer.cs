using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD_GUI.Libraries
{
    class MyLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {
        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id)
        {
            if (id == DevExpress.XtraEditors.Controls.StringId.XtraMessageBoxYesButtonText)
                return "Có";
            if (id == DevExpress.XtraEditors.Controls.StringId.XtraMessageBoxNoButtonText)
                return "Không";
            return base.GetLocalizedString(id);
        }
    }
}
