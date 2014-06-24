using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class TKSLThietBiFilter: FilterAbstract<TKSLThietBiFilter>
    {
        public int idcttb { get; set; }
        public String tenltb { get; set; }
        public String tentinhtrang { get; set; }
        public String tenphong { get; set; }
        public String tenday { get; set; }
        public String tencoso { get; set; }
        public int soluong { get; set; }
        public String tentang { get; set; }
        public List<TKSLThietBiFilter> getAll()
        {
            List<TinhTrang> tinhtrangs = new TinhTrang().getAll();
            List<LoaiThietBi> ltbs = new List<LoaiThietBi>();
            ltbs.Add(new LoaiThietBi().getById(12));//máy chiếu
            List<TKSLThietBiFilter> result = (
                from cttb in db.CTTHIETBIS
                join phong in db.PHONGS on cttb.phong.id equals phong.id
                join vitri in db.VITRIS on phong.vitri.id equals vitri.id into view_1
                from coso_ in view_1.DefaultIfEmpty()
                join coso in db.COSOS on coso_.id equals coso.id into view_2
                from day_ in view_2.DefaultIfEmpty()
                join day in db.DAYYS on day_.id equals day.id into view_3
                from tang_ in view_3.DefaultIfEmpty()
                join tang in db.TANGS on tang_.id equals tang.id
                join tb in db.THIETBIS on cttb.thietbi.id equals tb.id
                join ltb in db.LOAITHIETBIS on tb.loaithietbi.id equals ltb.id
                join tinhtrang in db.TINHTRANGS on cttb.tinhtrang.id equals tinhtrang.id
                select new TKSLThietBiFilter
                {
                    idcttb = cttb.id,
                    tenltb = ltb.ten,
                    soluong = cttb.soluong,
                    tentinhtrang = tinhtrang.value,
                    tenphong = phong.ten,
                    tentang = phong.vitri.tang.ten,
                    tenday = phong.vitri.day.ten,
                    tencoso = phong.vitri.coso.ten
                }

                ).ToList();

            return result;
        }
    }
}
