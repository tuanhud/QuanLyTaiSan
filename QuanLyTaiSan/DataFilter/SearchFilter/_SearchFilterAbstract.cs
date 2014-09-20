using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB.DataFilter.SearchFilter
{
    public abstract class _SearchFilterAbstract<T>:_FilterAbstract<T>
    {
        public Boolean enable_filter_input = true;
        public T obj { get; set; }
        private List<String> _match_field = new List<String> { };
        public List<String> match_field
        {
            get
            {
                return _match_field;
            }
        }

        protected static String input_filter(String key_word="", Boolean enable_input_filter=true)
        {
            key_word = key_word == null ? "" : key_word.ToLower();
            key_word = StringHelper.thayDoiKyTuDacBiet(key_word, "");

            if (enable_input_filter)
            {
                return StringHelper.CoDauThanhKhongDau(key_word);
            }
            else
            {
                return key_word;
            }
        }
    }
}
