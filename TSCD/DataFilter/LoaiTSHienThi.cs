using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class LoaiTSHienThi : _FilterAbstract<LoaiTSHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String donvitinh { get; set; }
        public bool huuhinh { get; set; }
        public Guid? parent_id { get; set; }
        public LoaiTaiSan obj { get; set; }

        public static List<LoaiTSHienThi> Convert(IQueryable<LoaiTaiSan> list)
        {
            try
            {
                if (list == null)
                    return null;
                List<LoaiTSHienThi> re =
                list.Select(ct => new LoaiTSHienThi
                {
                    id = ct.id,
                    ten = ct.ten,
                    donvitinh = ct.donvitinh != null ? ct.donvitinh.ten : "",
                    huuhinh = ct.huuhinh,
                    parent_id = ct.parent_id,
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LoaiSTHienThi->Convert:" + ex.Message);
                return null;
            }
        }

        public static List<LoaiTSHienThi> Convert(List<LoaiTaiSan> list)
        {
            try
            {
                if (list == null || list.Count == 0)
                    return null;
                List<LoaiTSHienThi> re =
                list.Select(ct => new LoaiTSHienThi
                {
                    id = ct.id,
                    ten = ct.ten,
                    donvitinh = ct.donvitinh != null ? ct.donvitinh.ten : "",
                    huuhinh = ct.huuhinh,
                    parent_id = ct.parent_id,
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LoaiSTHienThi->Convert:" + ex.Message);
                return null;
            }
        }
    }
}
