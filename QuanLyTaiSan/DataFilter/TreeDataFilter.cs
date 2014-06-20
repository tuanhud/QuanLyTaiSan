using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class TreeDataFilter
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String id_c { get; set; }
        public String id_p { get; set; }

        #region Nghiệp vụ
        public List<TreeDataFilter> getAllCoSo()
        {
            MyDB db = new MyDB();
            List<TreeDataFilter> re =
                (from c in db.COSOS
                 select new TreeDataFilter
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(CoSo).Name,
                     id_c = typeof(CoSo).Name + c.id,
                     id_p = ""
                 }).ToList();
            return re;
        }
        public List<TreeDataFilter> getAllDay()
        {
            MyDB db = new MyDB();
            List<TreeDataFilter> re =
                (from c in db.DAYYS
                 select new TreeDataFilter
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Dayy).Name,
                     id_c = typeof(Dayy).Name + c.id,
                     id_p = typeof(CoSo).Name + c.coso.id
                 }).ToList();
            return re;
        }
        public List<TreeDataFilter> getAllTang()
        {
            MyDB db = new MyDB();
            List<TreeDataFilter> re =
                (from c in db.TANGS
                 select new TreeDataFilter
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Tang).Name,
                     id_c = typeof(Tang).Name + c.id,
                     id_p = typeof(Dayy).Name + c.day.id
                 }).ToList();
            return re;
        }

        public List<TreeDataFilter> getAllPhong()
        {
            MyDB db = new MyDB();
            List<TreeDataFilter> re =
                (from c in db.PHONGS
                 select new TreeDataFilter
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     id_c = typeof(Phong).Name + c.id,
                     id_p = (c.vitri.tang != null ? typeof(Tang).Name+c.vitri.tang.id : (c.vitri.day != null ? typeof(Dayy).Name+c.vitri.day.id :(c.vitri.day != null ? typeof(CoSo).Name+c.vitri.coso.id : ""))) 
                 }).ToList();
            return re;
        }

        public List<TreeDataFilter> getAll()
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).ToList();
        }

        public List<TreeDataFilter> getAllHavePhong()
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).Concat(getAllPhong()).ToList();
        }

        public List<TreeDataFilter> getAllHaveDay()
        {
            return getAllCoSo().Concat(getAllDay()).ToList();
        }
        #endregion
    }
}
