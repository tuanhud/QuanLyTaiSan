using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter.SearchFilter
{
    public class DonViTaiSanFS: _SearchFilterAbstract<DonViTaiSanFS>
    {
        public DonViTaiSanFS(Boolean enable_filter_input = true)
        {
            this.enable_filter_input = enable_filter_input;
        }
        private String _ten = "";
        public String ten { get { return _ten; } set { _ten = input_filter(value, enable_filter_input); } }
        public static List<DonViTaiSanFS> search(String key_work)
        {
            var re = new List<DonViTaiSanFS>();
            IEnumerable<DonViTaiSanFS> query;
            Boolean search_codau = StringHelper.isCoDau(key_work);
            //Đang search có dấu
            key_work = input_filter(key_work, !search_codau);
            if (key_work.Length == 0)
            {
                return new List<DonViTaiSanFS>();
            }

            List<DonVi> listDonVi = Permission.getAll<DonVi>(Permission._VIEW).ToList();
            if (listDonVi != null && listDonVi.Count > 0)
            {
                foreach (DonVi _DonVi in listDonVi)
                {
                    List<TaiSanHienThi> listCTTaiSan = TaiSanHienThi.Convert(_DonVi.getAllCTTaiSanRecursive());
                    //query = listCTTaiSan.Select(ct => new DonViTaiSanFS(!search_codau) { obj = ct, ten = ct.ten });
                }
            }
            

            Boolean once_match = false;
            //foreach (var item in query)
            //{
            //    if (item.ten.Contains(key_work))
            //    {
            //        item.match_field.Add("ten");
            //        once_match = true;
            //    }
            //    if (once_match)
            //    {
            //        re.Add(item);
            //        once_match = false;
            //    }
            //}
            return re;
        }
    }
}
