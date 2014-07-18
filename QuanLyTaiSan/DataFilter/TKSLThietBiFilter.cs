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
        /// <summary>
        /// For back reference
        /// </summary>
        public CTThietBi cttb { get; set; }
        public String tenltb { get; set; }
        public String tentinhtrang { get; set; }
        public String tenphong { get; set; }
        public String tenday { get; set; }
        public String tencoso { get; set; }
        public int soluong { get; set; }
        public String tentang { get; set; }

        #region Ngiep vu
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list_coso"></param>
        /// <param name="list_ltb"></param>
        /// <param name="list_tinhtrang"></param>
        /// <param name="date_from"></param>
        /// <param name="date_to"></param>
        /// <param name="row_per_page">Default: -1 (get ALL)</param>
        /// <param name="page_index">Default: 1 (valid from 1->n)</param>
        /// <returns></returns>
        public static List<TKSLThietBiFilter> getAll(List<int> list_coso = null, List<int> list_ltb = null, List<int> list_tinhtrang = null, DateTime? date_from = null, DateTime? date_to = null, int row_per_page = -1, int page_index = 1, Boolean orderby_id_desc=true)
        {
            IQueryable<CTThietBi> query = db.CTTHIETBIS.AsQueryable();

            //DATETIME
            if (date_from != null)
            {
                query = query.Where(x => x.ngay >= date_from);
            }
            if (date_to != null)
            {
                //"date_to" have to be the last second of the day, 1 day additional           
                date_to = date_to.Value.AddDays(1);

                query = query.Where(x => x.ngay <= date_to);
            }
            //LTB
            if (list_ltb != null && list_ltb.Count > 0)
            {
                query = query.Where(x => x.thietbi.loaithietbi == null || list_ltb.Contains(x.thietbi.loaithietbi.id));
            }
            //TINHTRANG
            if (list_tinhtrang != null && list_tinhtrang.Count > 0)
            {
                query = query.Where(x => list_tinhtrang.Contains(x.tinhtrang.id));
            }
            //COSO
            if (list_coso != null && list_coso.Count > 0)
            {
                query = query.Where(x => x.phong.vitri.coso == null || list_coso.Contains(x.phong.vitri.coso.id));
            }
            //CTTB phai co SL lon hon 0
            query = query.Where(x => x.soluong > 0);

            //ORDER BY ID
            if (orderby_id_desc)
            {
                query = query.OrderByDescending(x => x.id);
            }
            else
            {
                query = query.OrderBy(x => x.id);
            }

            //PAGINATION
            if (row_per_page > -1)
            {
                page_index = page_index-- >= 0 ? page_index : 0;
                query = query.Skip(row_per_page * page_index).Take(row_per_page);
            }

            //FINAL SELECT
            List<TKSLThietBiFilter> re = query.Select(x => new TKSLThietBiFilter
            {
                cttb = x,
                idcttb = x.id,
                soluong = x.soluong,
                tencoso = x.phong.vitri.coso == null ? "" : x.phong.vitri.coso.ten,
                tenday = x.phong.vitri.day == null ? "" : x.phong.vitri.day.ten,
                tentang = x.phong.vitri.tang == null ? "" : x.phong.vitri.tang.ten,
                tenltb = x.thietbi.loaithietbi.ten,
                tentinhtrang = x.tinhtrang.value,
                tenphong = x.phong.ten
            }
            ).ToList();

            return re;
        }
        #endregion
        #region Trash
        /*
        public List<TKSLThietBiFilter> getAll_notuse(List<int> list_coso = null, List<int> list_ltb= null, List<int> list_tinhtrang=null, DateTime? date_from=null, DateTime? date_to=null)
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
                join vitri in db.VITRIS.DefaultIfEmpty().Where(x => x == null || !xetCoSo || list_coso.Contains(x.coso.id)) on phong.vitri.id equals vitri.id into view_1

                from coso_ in view_1.DefaultIfEmpty()
                join coso in db.COSOS on coso_.id equals coso.id into view_2
                from day_ in view_2.DefaultIfEmpty()
                join day in db.DAYYS on day_.id equals day.id into view_3
                from tang_ in view_3.DefaultIfEmpty()
                join tang in db.TANGS on tang_.id equals tang.id
                join tb in db.THIETBIS on cttb.thietbi.id equals tb.id
                //WHERE LTB
                join ltb in db.LOAITHIETBIS.DefaultIfEmpty().Where(x => x == null || !xetLTB || list_ltb.Contains(x.id)) on tb.loaithietbi.id equals ltb.id
                join tinhtrang in db.TINHTRANGS.DefaultIfEmpty().Where(x => x == null || !xetTinhTrang || list_tinhtrang.Contains(x.id)) on cttb.tinhtrang.id equals tinhtrang.id
                select cttb
                
                //select new TKSLThietBiFilter
                //{
                //    idcttb = cttb.id,
                //    tenltb = ltb.ten,
                //    soluong = cttb.soluong,
                //    tentinhtrang = tinhtrang.value,
                //    tenphong = phong.ten,
                //    tentang = phong.vitri.tang.ten,
                //    tenday = phong.vitri.day.ten,
                //    tencoso = phong.vitri.coso.ten
                //}
                

            ).Select(cttb => new TKSLThietBiFilter
            {
                idcttb = cttb.id,
                tenltb = cttb.thietbi.loaithietbi.ten,
                soluong = cttb.soluong,
                tentinhtrang = cttb.tinhtrang.value,
                tenphong = cttb.phong.ten,
                tentang = cttb.phong.vitri.tang.ten,
                tenday = cttb.phong.vitri.day.ten,
                tencoso = cttb.phong.vitri.coso.ten
            }).ToList();

            return result;
        }
        */
        //public List<CTThietBi> getAll2()
        //{
        //    List<CTThietBi> ree = db.CTTHIETBIS
        //        .Join(
        //            db.PHONGS,
        //            cttb => cttb.phong.id,
        //            phong => phong.id, (cttb, phong) => new { cttb, phong }
        //        )
        //        .Join(
        //            db.VITRIS,
        //            phong2 => phong2.phong.id,
        //            vitri => vitri.id,
        //            (phong2, vitri) => new { phong2, vitri }
        //        )
        //        .OrderBy(x => x.phong2.cttb.id).Skip(1500).Take(10)
        //        .Select(x => x.phong2.cttb).ToList();
                

        //    return ree;
        //    //return db.CTTHIETBIS.OrderByDescending(x=>x.id).Where(x => x.id > 0).Skip(9000).Take(10).ToList();
        //}
        #endregion
    }
}
