using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class QuanTriVienFilter:FilterAbstract<QuanTriVienFilter>
    {
        public QuanTriVienFilter():base()
        {

        }
        //public QuanTriVienFilter(OurDBContext db)
        //    : base(db)
        //{

        //}

        public int id { get; set; }
        public String username { get; set; }
        public String hoten { get; set; }
        public String ten_group { get; set; }
        public DateTime date_create { get; set; }
        public DateTime date_modified { get; set; }
        /*
         * FK Object
         */
        public QuanTriVien quantrivien { get; set; }
        public Group group { get; set; }

        #region Nghiệp vụ
        public override List<QuanTriVienFilter> getAll()
        {
            //InitDb();
            List<QuanTriVienFilter> re =
                (from e in db.QUANTRIVIENS
                join t in db.GROUPS on e.@group equals t
                select new QuanTriVienFilter
                {
                    id = e.id,
                    hoten = e.hoten,
                    username = e.username,
                    date_create = (DateTime)e.date_create == null ? DateTime.Now : (DateTime)e.date_create,
                    date_modified = (DateTime)e.date_modified == null ? DateTime.Now : (DateTime)e.date_modified,
                    ten_group = t==null?"":t.ten,
                    @group = t,
                    quantrivien = e
                }).ToList();
            return re;
        }
        #endregion
    }
}
