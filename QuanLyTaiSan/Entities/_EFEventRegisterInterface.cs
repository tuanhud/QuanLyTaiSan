using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    /// <summary>
    /// Do not call SaveChanges in here, caller will do it later for consistency
    /// </summary>
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
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onBeforeDeleted();
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onAfterUpdated();
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onAfterAdded();
        /// <summary>
        /// Before db.Savechange()
        /// </summary>
        void onAfterDeleted();
    }
}
