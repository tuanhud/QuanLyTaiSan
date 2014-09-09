using QuanLyTaiSan.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public class NhanVienPTSF : _SearchFilterAbstract<NhanVienPT>
    {
        public static List<NhanVienPT> search(String key_work)
        {
            key_work = input_filter(key_work);

            var re =  NhanVienPT.getAll().Select(c => new NhanVienPTSF { obj = c, master_key = c.hoten + " " + c.sodienthoai + " " + c.subId }).Where(c => c.master_key.Contains(key_work)).Select(c => c.obj).ToList();
            return re;
        }
    }
}
