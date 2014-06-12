using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public interface _CRUDInterface<T>
    {
        List<T> getAll();
        T getById(int id);
        int add();
        int update();
        int delete();
        void dispose();
        T reload();
        void trigger();
    }
}
