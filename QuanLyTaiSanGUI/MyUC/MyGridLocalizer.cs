using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Localization;

namespace QuanLyTaiSanGUI.MyUC
{
    public class MyGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            if (id == GridStringId.FindControlFindButton)
                return "Tìm kiếm";
            if (id == GridStringId.FindControlClearButton)
                return "Làm mới";
            if (id == GridStringId.GridGroupPanelText)
                return "Kéo thả một cột vào đây để nhóm theo cột đó";
            return base.GetLocalizedString(id);
        }
    }
}
