using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
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
        public List<TKSLThietBiFilter> getAll(List<int> list_coso = null, List<int> list_ltb= null, List<int> list_tinhtrang=null, DateTime? date_from=null, DateTime? date_to=null)
        {
            list_coso = list_coso == null ? new List<int>() : list_coso;
            list_tinhtrang = list_tinhtrang == null ? new List<int>() : list_tinhtrang;
            list_ltb = list_ltb == null ? new List<int>() : list_ltb;

            Boolean xetNgay = date_from!=null && date_to!=null;
            date_from = date_from == null ? ServerTimeHelper.getNow() : date_from;
            date_to = date_to == null ? ServerTimeHelper.getNow() : date_to;

            Boolean xetCoSo = list_coso.Count>0;
            Boolean xetTinhTrang = list_tinhtrang.Count>0;
            Boolean xetLTB = list_ltb.Count>0;
            List<TKSLThietBiFilter> result = (
                from cttb in db.CTTHIETBIS
                join phong in db.PHONGS on cttb.phong.id equals phong.id
                //WHERE CoSo
                join vitri in db.VITRIS.DefaultIfEmpty().Where(x=>x==null || !xetCoSo || list_coso.Contains(x.coso.id)) on phong.vitri.id equals vitri.id into view_1
                
                from coso_ in view_1.DefaultIfEmpty()
                join coso in db.COSOS on coso_.id equals coso.id into view_2
                from day_ in view_2.DefaultIfEmpty()
                join day in db.DAYYS on day_.id equals day.id into view_3
                from tang_ in view_3.DefaultIfEmpty()
                join tang in db.TANGS on tang_.id equals tang.id
                join tb in db.THIETBIS on cttb.thietbi.id equals tb.id
                //WHERE LTB
                join ltb in db.LOAITHIETBIS.DefaultIfEmpty().Where(x => x==null || !xetLTB || list_ltb.Contains(x.id)) on tb.loaithietbi.id equals ltb.id
                join tinhtrang in db.TINHTRANGS.DefaultIfEmpty().Where(x =>x==null || !xetTinhTrang || list_tinhtrang.Contains(x.id)) on cttb.tinhtrang.id equals tinhtrang.id

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
