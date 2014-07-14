using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSanGUI.MyUC
{
    public class MyGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {
            if (id == DevExpress.XtraGrid.Localization.GridStringId.FindControlFindButton)
                return "Tìm kiếm";
            if (id == DevExpress.XtraGrid.Localization.GridStringId.GridGroupPanelText)
                return "Kéo thả một cột vào đây để nhóm theo cột đó";
            return base.GetLocalizedString(id);
        }
    }
}
