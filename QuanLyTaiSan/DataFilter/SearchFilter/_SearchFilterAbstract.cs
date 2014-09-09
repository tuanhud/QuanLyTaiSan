using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.DataFilter.SearchFilter
{
    public abstract class _SearchFilterAbstract<T>:FilterAbstract<T>
    {
        public T obj { get; set; }
        private List<String> _match_field = new List<String> { };
        public List<String> match_field
        {
            get
            {
                return _match_field;
            }
        }

        private String _master_key = "";
        public String master_key
        {
            get
            {
                return _master_key;
            }
            set
            {
                _master_key = input_filter(value);
            }
        }

        protected static String input_filter(String key_word="")
        {
            return StringHelper.CoDauThanhKhongDau(key_word == null?"":key_word.ToLower());
        }
    }
}
