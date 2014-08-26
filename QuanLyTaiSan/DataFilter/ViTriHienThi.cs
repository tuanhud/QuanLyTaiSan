using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class ViTriHienThi : FilterAbstract<ViTriHienThi>
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String id_c { get; set; }
        public String id_p { get; set; }
        public String mota { get; set; }
        public int? order { get; set; }
        public Phong phong { get; set; }

        #region Nghiệp vụ
        public static List<ViTriHienThi> getAllCoSo()
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.COSOS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(CoSo).Name,
                     id_c = c.id + "-" + typeof(CoSo).Name,
                     id_p = "",
                     mota = c.mota,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }
        public static List<ViTriHienThi> getAllDay()
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.DAYYS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Dayy).Name,
                     id_c = c.id + "-" + typeof(Dayy).Name,
                     id_p = c.coso.id + "-" + typeof(CoSo).Name,
                     mota = c.mota,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }
        public static List<ViTriHienThi> getAllTang()
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.TANGS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Tang).Name,
                     id_c = c.id + "-" + typeof(Tang).Name,
                     id_p = c.day.id + "-" + typeof(Dayy).Name,
                     mota = c.mota,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhong()
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.PHONGS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     id_c = c.id + "-" + typeof(Phong).Name,
                     id_p = (c.vitri.tang != null ? c.vitri.tang.id + "-" + typeof(Tang).Name : (c.vitri.day != null ? c.vitri.day.id + "-" + typeof(Dayy).Name : (c.vitri.coso != null ? c.vitri.coso.id + "-" + typeof(CoSo).Name : ""))),
                     mota = c.mota,
                     phong = c
                 }).OrderBy(c => c.ten).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhongNotNhanVien(int _idnhanvien)
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.PHONGS
                 where (c.nhanvienpt == null || c.nhanvienpt_id == _idnhanvien)
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     id_c = typeof(Phong).Name + c.id,
                     id_p = (c.vitri.tang != null ? c.vitri.tang.id + "-" + typeof(Tang).Name : (c.vitri.day != null ? c.vitri.day.id + "-" + typeof(Dayy).Name : (c.vitri.coso != null ? c.vitri.coso.id + "-" + typeof(CoSo).Name : ""))),
                     mota = c.mota,
                     phong = c
                 }).OrderBy(c => c.ten).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhongNotQuanTriVien(int _idquantrivien)
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.PHONGS
                 where (c.quantrivien == null || c.quantrivien_id == _idquantrivien)
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     id_c = typeof(Phong).Name + c.id,
                     id_p = (c.vitri.tang != null ? c.vitri.tang.id + "-" + typeof(Tang).Name : (c.vitri.day != null ? c.vitri.day.id + "-" + typeof(Dayy).Name : (c.vitri.coso != null ? c.vitri.coso.id + "-" + typeof(CoSo).Name : ""))),
                     mota = c.mota,
                     phong = c
                 }).OrderBy(c => c.ten).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAll()
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).ToList();
        }

        public static List<ViTriHienThi> getAllHavePhong()
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhong()).ToList();
        }

        public static List<ViTriHienThi> getAllHaveDay()
        {
            return getAllCoSo().Concat(getAllDay()).OrderBy(c => c.order).ToList();
        }

        public static List<ViTriHienThi> getAllHavePhongNotNhanVien(int _idnhanvien)
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhongNotNhanVien(_idnhanvien)).ToList();
        }

        public static List<ViTriHienThi> getAllHavePhongNotQuanTriVien(int _idquantrivien)
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhongNotQuanTriVien(_idquantrivien)).ToList();
        }
        #endregion
    }
}
