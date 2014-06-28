using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public interface _EFEventRegisterInterface
    {
        void onBeforeUpdated();
        void onBeforeAdded();
    }
}
