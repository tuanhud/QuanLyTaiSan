using QuanLyTaiSan.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public class PhongSF : _SearchFilterAbstract<Phong>
    {
        public static List<Phong> search(String key_work)
        {
            key_work = input_filter(key_work);

            var re = Phong.getAll().Select(c => new PhongSF { obj = c, master_key = c.ten}).Where(c => c.master_key.Contains(key_work)).Select(c => c.obj).ToList();
            return re;
        }
    }
}
