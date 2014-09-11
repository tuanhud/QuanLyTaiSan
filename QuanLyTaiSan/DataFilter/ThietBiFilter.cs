using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class ThietBiFilter:_FilterAbstract<ThietBiFilter>
    {
        public Guid id { get; set; }
        public Guid idTB { get; set; }
        public String ten { get; set; }
        public String tinhtrang { get; set; }
        public int soluong { get; set; }
        public String tenphong { get; set; }
        public String tencoso { get; set; }
        public String tenday { get; set; }
        public String tentang { get; set; }
        public String tenloaithietbi { get; set; }
        public Guid phong_id { get; set; }

        #region Nghiệp vụ
        public static List<ThietBiFilter> getAllBy4Id(Guid _phongid, Guid _cosoid, Guid _dayid, Guid _tangid)
        {
            //OurDBContext db = new OurDBContext();
            List<ThietBiFilter> re =
                (from c in db.CTTHIETBIS
                 where ((_phongid == Guid.Empty || c.phong.id == _phongid) && (_cosoid == Guid.Empty || c.phong.vitri.coso.id == _cosoid) && (_dayid == Guid.Empty || c.phong.vitri.day.id == _dayid) && (_tangid == Guid.Empty || c.phong.vitri.tang.id == _tangid))
                 select new ThietBiFilter
                 {
                     id = c.id,
                     idTB = c.thietbi.id,
                     ten = c.thietbi.ten,
                     tinhtrang = c.tinhtrang.value,
                     soluong = c.soluong,
                     tenphong = c.phong.ten,
                     phong_id = c.phong.id,
                     tencoso = c.phong.vitri.coso.ten,
                     tenday = c.phong.vitri.day.ten,
                     tentang = c.phong.vitri.tang.ten,
                     tenloaithietbi = c.thietbi.loaithietbi.ten
                 }).ToList();
            return re;
        }
        #endregion
    }
}
