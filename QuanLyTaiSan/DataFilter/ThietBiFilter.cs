using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class ThietBiFilter:FilterAbstract<ThietBiFilter>
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String tinhtrang { get; set; }
        public int soluong { get; set; }
        public String tenphong { get; set; }
        public String tencoso { get; set; }
        public String tenday { get; set; }
        public String tentang { get; set; }
        public int phong_id { get; set; }

        #region Nghiệp vụ
        public List<ThietBiFilter> getAllBy4Id(int _id1, int _id2, int _id3, int _id4)
        {
            //OurDBContext db = new OurDBContext();
            List<ThietBiFilter> re =
                (from c in db.CTTHIETBIS
                 where ((_id1 == -1 || c.phong.id == _id1)&&(_id2==-1||c.phong.vitri.coso.id==_id2)&&(_id3==-1||c.phong.vitri.day.id ==_id3)&&(_id4==-1||c.phong.vitri.tang.id==_id4))
                 select new ThietBiFilter
                 {
                     id = c.id,
                     ten = c.thietbi.ten,
                     tinhtrang = c.tinhtrang.value,
                     soluong = c.soluong,
                     tenphong = c.phong.ten,
                     phong_id = c.phong.id,
                     tencoso = c.phong.vitri.coso.ten,
                     tenday = c.phong.vitri.day.ten,
                     tentang = c.phong.vitri.tang.ten,
                 }).ToList();
            return re;
        }
        #endregion
    }
}
