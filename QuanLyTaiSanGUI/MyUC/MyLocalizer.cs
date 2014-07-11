using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;

namespace QuanLyTaiSanGUI.MyUC
{
    class MyLocalizer : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            if (id == StringId.XtraMessageBoxYesButtonText)
                return "Có";
            if (id == StringId.XtraMessageBoxNoButtonText)
                return "Không";
            return base.GetLocalizedString(id);
        }
    }
}
