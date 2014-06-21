using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class test
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String id_c { get; set; }
        public String id_p { get; set; }

        #region Nghiệp vụ
        public List<test> getAllCoSo()
        {
            OurDBContext db = new OurDBContext();
            List<test> re =
                (from c in db.COSOS
                 select new test
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = "coso",
                     id_c = "C"+c.id,
                     id_p = ""
                 }).ToList();
            return re;
        }
        public List<test> getAllDay()
        {
            OurDBContext db = new OurDBContext();
            List<test> re =
                (from c in db.DAYYS
                 select new test
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = "day",
                     id_c = "D" + c.id,
                     id_p = "C" + c.coso.id
                 }).ToList();
            return re;
        }
        public List<test> getAllTang()
        {
            OurDBContext db = new OurDBContext();
            List<test> re =
                (from c in db.TANGS
                 select new test
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = "tang",
                     id_c = "T" + c.id,
                     id_p = "D" + c.day.id
                 }).ToList();
            return re;
        }

        public List<test> getAll()
        {
            return getAllCoSo().Concat(getAllDay()).Concat(getAllTang()).ToList();
        }
        #endregion
    }
}
