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
        public double? phantramhaomon_351 { get; set; }
        public double? phantramhaomon_32 { get; set; }
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
                    phantramhaomon_351 = ct.phantramhaomon_351,
                    phantramhaomon_32 = ct.phantramhaomon_32,
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
                    phantramhaomon_351 = ct.phantramhaomon_351,
                    phantramhaomon_32 = ct.phantramhaomon_32,
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
