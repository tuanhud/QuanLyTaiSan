using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class Phong_ThongKe : _FilterAbstract<Phong_ThongKe>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String coso { get; set; }
        public String day { get; set; }
        public String tang { get; set; }
        public int sochongoi { get; set; }
        public long tonggiatritaisan { get; set; }

        //public Phong obj { get; set; }

        //public long tonggiatritaisan
        //{
        //    get
        //    {
        //        try
        //        {
        //            return obj.tonggiatritaisan;
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex);
        //            return 0;
        //        }
        //    }
        //}

        public static List<Phong_ThongKe> getAll(List<Guid> list_coso = null, List<Guid> list_loaiphong = null)
        {
            IQueryable<Phong> query = Phong.getQuery();

            //LTB
            if (list_loaiphong != null && list_loaiphong.Count > 0)
            {
                query = query.Where(x => x.loaiphong == null || list_loaiphong.Contains(x.loaiphong.id));
            }
            //COSO
            if (list_coso != null && list_coso.Count > 0)
            {
                query = query.Where(x => x.vitri.coso == null || list_coso.Contains(x.vitri.coso.id));
            }

            //FINAL SELECT
            List<Phong_ThongKe> re = query.ToList().Select(x => new Phong_ThongKe
            {
                id = x.id,
                ten = x.ten,
                loai = x.loaiphong == null ? "" : x.loaiphong.ten,
                sochongoi = x.sochongoi,
                //obj = x,
                tonggiatritaisan = x.tonggiatritaisan,
                coso = x.vitri.coso == null ? "" : x.vitri.coso.ten,
                day = x.vitri.day == null ? "" : x.vitri.day.ten,
                tang = x.vitri.tang == null ? "" : x.vitri.tang.ten
            }
            ).ToList();

            return re;
        }

        public static List<Phong_ThongKe> getAllForTH(List<Guid> list_loaiphong = null, ViTri vitri = null)
        {
            IQueryable<Phong> query = Phong.getQuery();

            //LTB
            if (list_loaiphong != null && list_loaiphong.Count > 0)
            {
                query = query.Where(x => x.loaiphong == null || list_loaiphong.Contains(x.loaiphong.id));
            }
            //VITRI
            if (vitri != null)
            {
                query = query.Where(x => (vitri.coso_id == null || x.vitri.coso.id == vitri.coso_id) && (vitri.day_id == null || x.vitri.day.id == vitri.day_id) && (vitri.tang_id == null || x.vitri.tang.id == vitri.tang_id));
            }

            //FINAL SELECT
            List<Phong_ThongKe> re = query.ToList().Select(x => new Phong_ThongKe
            {
                id = x.id,
                ten = x.ten,
                loai = x.loaiphong == null ? "" : x.loaiphong.ten,
                sochongoi = x.sochongoi,
                //obj = x,
                tonggiatritaisan = x.tonggiatritaisan,
                coso = x.vitri.coso == null ? "" : x.vitri.coso.ten,
                day = x.vitri.day == null ? "" : x.vitri.day.ten,
                tang = x.vitri.tang == null ? "" : x.vitri.tang.ten
            }
            ).ToList();

            return re;
        }
    }
}
