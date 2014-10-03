using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class TaiSan_ThongKe : _FilterAbstract<TaiSan_ThongKe>
    {
        public Guid id { get; set; }
        public DateTime? ngay { get; set; }
        public String sohieu_ct { get; set; }
        public DateTime? ngay_ct { get; set; }
        public String ten { get; set; }
        public String loaits { get; set; }
        public String donvitinh { get; set; }
        public int? soluong_tang { get; set; }
        public long? dongia_tang { get; set; }
        public long? thanhtien_tang { get; set; }
        public int? soluong_giam { get; set; }
        public long? dongia_giam { get; set; }
        public long? thanhtien_giam { get; set; }
        public String nuocsx { get; set; }
        public String nguongoc { get; set; }
        public String tinhtrang { get; set; }
        public String ghichu { get; set; }
        public String phong { get; set; }
        public String vitri { get; set; }
        public String dvquanly { get; set; }
        public String dvsudung { get; set; }
        public ICollection<CTTaiSan> childs { get; set; }


        public static List<TaiSan_ThongKe> getAll(List<Guid> list_coso = null, List<Guid> list_loaitaisan = null)
        {
            IQueryable<CTTaiSan> query = CTTaiSan.getQuery();
            //LTB
            if (list_loaitaisan != null && list_loaitaisan.Count > 0)
            {
                query = query.Where(x => x.taisan.loaitaisan == null || list_loaitaisan.Contains(x.taisan.loaitaisan.id));
            }
            //COSO
            if (list_coso != null && list_coso.Count > 0)
            {
                query = query.Where(x => x.vitri.coso == null || list_coso.Contains(x.vitri.coso.id));
            }

            //FINAL SELECT
            List<TaiSan_ThongKe> re = query.Select(x => new TaiSan_ThongKe
            {
                id = x.id,
                ngay = x.ngay,
                sohieu_ct = x.chungtu_sohieu,
                ngay_ct = x.chungtu_ngay,
                ten = x.taisan.ten,
                loaits = x.taisan.loaitaisan.ten,
                donvitinh = x.taisan.loaitaisan.donvitinh != null ? x.taisan.loaitaisan.donvitinh.ten : "",
                soluong_tang = !x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                dongia_tang = !x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                thanhtien_tang = !x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                soluong_giam = x.tinhtrang.giam_taisan ? (int?)x.soluong : null,
                dongia_giam = x.tinhtrang.giam_taisan ? (long?)x.taisan.dongia : null,
                thanhtien_giam = x.tinhtrang.giam_taisan ? (long?)x.soluong * x.taisan.dongia : null,
                nuocsx = x.taisan.nuocsx,
                nguongoc = x.nguongoc,
                tinhtrang = x.tinhtrang.value,
                ghichu = x.mota,
                childs = x.childs,
                phong = x.phong != null ? x.phong.ten : "",
                vitri = x.vitri != null ? (x.vitri.coso != null ? x.vitri.coso.ten + (x.vitri.day != null ? " - " +
                x.vitri.day.ten + (x.vitri.tang != null ? " - " + x.vitri.tang.ten : "") : "") : "") : "",
                dvquanly = x.donviquanly != null ? x.donviquanly.ten : "",
                dvsudung = x.donvisudung != null ? x.donvisudung.ten : "",
            }
            ).ToList();

            return re;
        }
    }
}
