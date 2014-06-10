using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public interface _CRUDInterface<T>
    {
        int add();
        Boolean update();
        Boolean delete();
    }
}
