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
        private String _hoten = "";
        public String hoten { get { return _hoten;  } set { _hoten = input_filter(value); } }

        private String _sodienthoai = "";
        public String sodienthoai { get { return _sodienthoai; } set { _sodienthoai = input_filter(value); } }

        private String _subId = "";
        public String subId { get { return _subId; } set { _subId = input_filter(value); } }
        public static List<NhanVienPTSF> search(String key_work)
        {
            key_work = input_filter(key_work);
            var re = new List<NhanVienPTSF>();

            var query = NhanVienPT.getAll().Select(c => new NhanVienPTSF { obj = c, hoten = c.hoten, sodienthoai = c.sodienthoai, subId = c.subId });
            Boolean once_match = false;
            foreach (var item in query)
            {
                if (item.hoten.Contains(key_work))
                {
                    item.match_field.Add("hoten");
                    once_match = true;
                }
                if (item.sodienthoai.Contains(key_work))
                {
                    item.match_field.Add("sodienthoai");
                    once_match = true;
                }
                if (item.subId.Contains(key_work))
                {
                    item.match_field.Add("subId");
                    once_match = true;
                }
                if (once_match)
                {
                    re.Add(item);
                    once_match = false;
                }
            }
            return re;
        }
    }
}
