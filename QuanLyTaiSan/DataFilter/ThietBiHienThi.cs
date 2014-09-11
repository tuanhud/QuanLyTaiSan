using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class ThietBiHienThi : _FilterAbstract<ThietBiHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public DateTime? ngaymua { get; set; }
        public DateTime? ngaylap { get; set; }

        #region Nghiệp vụ
        public static List<ThietBiHienThi> getAllByTypeLoai(bool loaichung)
        {
            //OurDBContext db = new OurDBContext();
            List<ThietBiHienThi> re =
                (from c in db.THIETBIS
                 where (c.loaithietbi.loaichung == loaichung)
                 select new ThietBiHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = c.loaithietbi.ten,
                     ngaymua = c.ngaymua
                     //ngaylap = c.ngaylap
                 }).ToList();
            return re;
        }
        #endregion

    }
}
