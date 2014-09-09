using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public class TangSF : _SearchFilterAbstract<Tang>
    {
        public static List<Tang> search(String key_work)
        {
            key_work = input_filter(key_work);

            var re = Tang.getAll().Select(c => new TangSF { obj = c, master_key = c.ten }).Where(c => c.master_key.Contains(key_work)).Select(c => c.obj).ToList();
            return re;
        }
    }
}
