using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Localization;

namespace QuanLyTaiSanGUI.MyUC
{
    public class MyTreeListLocalizer : TreeListLocalizer
    {
        public override string GetLocalizedString(TreeListStringId id)
        {
            if (id == TreeListStringId.FindControlFindButton)
                return "Tìm kiếm";
            if (id == TreeListStringId.FindControlClearButton)
                return "Làm mới";
            return base.GetLocalizedString(id);
        }
    }
}
