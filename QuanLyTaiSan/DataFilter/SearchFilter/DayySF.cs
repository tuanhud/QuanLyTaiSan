using QuanLyTaiSan.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public class DayySF : _SearchFilterAbstract<Dayy>
    {
        public static List<Dayy> search(String key_work)
        {
            key_work = input_filter(key_work);

            var re = Dayy.getAll().Select(c => new DayySF { obj = c, master_key = c.ten }).Where(c => c.master_key.Contains(key_work)).Select(c => c.obj).ToList();
            return re;
        }
    }
}
