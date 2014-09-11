using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class ViTriHienThi : _FilterAbstract<ViTriHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String mota { get; set; }
        public Guid parent_id { get; set; }
        public Phong phong { get; set; }
        public long? order { get; set; }

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
                     mota = c.mota,
                     parent_id = c.coso.id,
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
                     mota = c.mota,
                     parent_id = c.day.id,
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
                     mota = c.mota,
                     parent_id = (c.vitri.tang != null ? c.vitri.tang.id : (c.vitri.day != null ? c.vitri.day.id : (c.vitri.coso != null ? c.vitri.coso.id : Guid.Empty))),
                     phong = c
                 }).OrderBy(c => c.ten).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhongNotNhanVien(Guid _idnhanvien)
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
                     mota = c.mota,
                     parent_id = (c.vitri.tang != null ? c.vitri.tang.id : (c.vitri.day != null ? c.vitri.day.id : (c.vitri.coso != null ? c.vitri.coso.id : Guid.Empty))),
                     phong = c
                 }).OrderBy(c => c.ten).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhongNotQuanTriVien(Guid _idquantrivien)
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
                     mota = c.mota,
                     parent_id = (c.vitri.tang != null ? c.vitri.tang.id : (c.vitri.day != null ? c.vitri.day.id : (c.vitri.coso != null ? c.vitri.coso.id : Guid.Empty))),
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

        public static List<ViTriHienThi> getAllHavePhongNotNhanVien(Guid _idnhanvien)
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhongNotNhanVien(_idnhanvien)).ToList();
        }

        public static List<ViTriHienThi> getAllHavePhongNotQuanTriVien(Guid _idquantrivien)
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhongNotQuanTriVien(_idquantrivien)).ToList();
        }
        #endregion
    }
}
