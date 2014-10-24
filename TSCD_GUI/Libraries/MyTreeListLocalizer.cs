using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD_GUI.Libraries
{
    public class MyTreeListLocalizer : DevExpress.XtraTreeList.Localization.TreeListLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id)
        {
            if (id == DevExpress.XtraTreeList.Localization.TreeListStringId.FindControlFindButton)
                return "Tìm kiếm";
            if (id == DevExpress.XtraTreeList.Localization.TreeListStringId.FindControlClearButton)
                return "Làm sạch";
            return base.GetLocalizedString(id);
        }
    }
}
