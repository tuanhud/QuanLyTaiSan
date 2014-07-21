using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class LoaiTBHienThi : FilterAbstract<LoaiTBHienThi>
    {
        public int id { get; set; }
        public String ten { get; set; }
        public int? parent_id { get; set; }
        public bool loaichung { get; set; }
        public String kieu_ql { get; set; }
        public int? order { get; set; }

        public static List<LoaiTBHienThi> getAll()
        {
            List<LoaiTBHienThi> re =
                (from c in db.LOAITHIETBIS
                 select new LoaiTBHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     parent_id = c.parent_id,
                     loaichung = c.loaichung,
                     kieu_ql = c.loaichung ? "Theo số lượng" : "Theo cá thể",
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }
    }
}
