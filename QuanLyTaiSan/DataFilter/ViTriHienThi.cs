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
                     id_c = typeof(CoSo).Name + c.id,
                     id_p = ""
                 }).OrderBy(c => c.ten).ToList();
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
                     id_c = typeof(Dayy).Name + c.id,
                     id_p = typeof(CoSo).Name + c.coso.id
                 }).ToList();
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
                     id_c = typeof(Tang).Name + c.id,
                     id_p = typeof(Dayy).Name + c.day.id
                 }).ToList();
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
                     id_c = typeof(Phong).Name + c.id,
                     id_p = (c.vitri.tang != null ? typeof(Tang).Name+c.vitri.tang.id : (c.vitri.day != null ? typeof(Dayy).Name+c.vitri.day.id :(c.vitri.coso != null ? typeof(CoSo).Name+c.vitri.coso.id : ""))) 
                 }).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhongNotNhanVien(int _idnhanvien)
        {
            //OurDBContext db = new OurDBContext();
            List<ViTriHienThi> re =
                (from c in db.PHONGS
                 where (c.nhanvienpt == null || c.nhanvienpt.id == _idnhanvien)
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     id_c = typeof(Phong).Name + c.id,
                     id_p = (c.vitri.tang != null ? typeof(Tang).Name + c.vitri.tang.id : (c.vitri.day != null ? typeof(Dayy).Name + c.vitri.day.id : (c.vitri.coso != null ? typeof(CoSo).Name + c.vitri.coso.id : "")))
                 }).ToList();
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
            return getAllCoSo().Concat(getAllDay()).ToList();
        }

        public static List<ViTriHienThi> getAllHavePhongNotNhanVien(int _idnhanvien)
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhongNotNhanVien(_idnhanvien)).ToList();
        }
        #endregion
    }
}
