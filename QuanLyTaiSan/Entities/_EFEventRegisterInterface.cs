using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public interface _EFEventRegisterInterface
    {
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onBeforeUpdated();
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onBeforeAdded();
    }
}
