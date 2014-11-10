using TSCD.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD.DataFilter.SearchFilter
{
    public class PhongSF : _SearchFilterAbstract<Phong>
    {
        public PhongSF(Boolean enable_filter_input = true)
        {
            this.enable_filter_input = enable_filter_input;
        }
        private String _ten = "";
        public String ten { get { return _ten; } set { _ten = input_filter(value, enable_filter_input); } }
        public static List<PhongSF> search(String key_work)
        {
            var re = new List<PhongSF>();
            IEnumerable<PhongSF> query;
            Boolean search_codau = StringHelper.isCoDau(key_work);
            //Đang search có dấu
            key_work = input_filter(key_work, !search_codau);
            if (key_work.Length == 0)
            {
                return new List<PhongSF>();
            }
            query = Phong.getAll().Select(c => new PhongSF(!search_codau) { obj = c, ten = c.ten });
            

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
