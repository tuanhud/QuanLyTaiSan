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
        public DayySF(Boolean enable_filter_input = true)
        {
            this.enable_filter_input = enable_filter_input;
        }
        private String _ten = "";
        public String ten { get { return _ten; } set { _ten = input_filter(value); } }
        public static List<DayySF> search(String key_work)
        {
            var re = new List<DayySF>();
            IEnumerable<DayySF> query;
            if (!StringHelper.CoDauThanhKhongDau(key_work).Equals(key_work))
            {
                //Đang search có dấu
                key_work = input_filter(key_work, false);
                query = Dayy.getAll().Select(c => new DayySF(false) { obj = c, ten = c.ten });
            }
            else
            {
                //Đang search không dấu
                key_work = input_filter(key_work, true);
                query = Dayy.getAll().Select(c => new DayySF(true) { obj = c, ten = c.ten });
            }

            Boolean once_match = false;
            foreach (var item in query)
            {
                if (item.ten.Contains(key_work))
                {
                    item.match_field.Add("ten");
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
