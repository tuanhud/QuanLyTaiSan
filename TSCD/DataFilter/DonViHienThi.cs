using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class DonViHienThi : _FilterAbstract<DonViHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public Guid? parent_id { get; set; }
        public String loaidonvi { get; set; }
        public DonVi obj { get; set; }

        public static List<DonViHienThi> Convert(IQueryable<DonVi> list)
        {
            try
            {
                if (list == null)
                    return null;
                List<DonViHienThi> re =
                list.Select(dv => new DonViHienThi
                {
                    id = dv.id,
                    ten = dv.ten,
                    parent_id = dv.parent_id,
                    loaidonvi = dv.loaidonvi != null ? dv.loaidonvi.ten : "",
                    obj = dv
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DonViHienThi->Convert:" + ex.Message);
                return null;
            }
        }
    }
}
