using QuanLyTaiSan.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public class CoSoSF : _SearchFilterAbstract<CoSo>
    {
        public static List<CoSo> search(String key_work)
        {
            key_work = input_filter(key_work);

            var re = CoSo.getAll().Select(c => new CoSoSF { obj = c, master_key = c.ten }).Where(c => c.master_key.Contains(key_work)).Select(c => c.obj).ToList();
            return re;
        }
    }
}
