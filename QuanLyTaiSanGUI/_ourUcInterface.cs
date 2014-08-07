using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSanGUI
{
    /// <summary>
    /// Mỗi UC của từng TAB đều phải có các hàm sau
    /// </summary>
    public interface _ourUcInterface
    {
        /// <summary>
        /// reload lại dữ liệu, bắt đầu phiên làm việc mới
        /// </summary>
        void reLoad();
    }
}
