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
        public QuanTriVienFilter(MyDB db)
            : base(db)
        {

        }

        public int id { get; set; }
        public String username { get; set; }
        public String hoten { get; set; }
        public String ten_group { get; set; }
        /*
         * FK Object
         */
        public QuanTriVien quantrivien { get; set; }
        public Group group { get; set; }

        #region Nghiệp vụ
        public List<QuanTriVienFilter> getAll()
        {
            InitDb();
            List<QuanTriVienFilter> re =
                (from e in db.QUANTRIVIENS
                join t in db.GROUPS on e.@group equals t
                select new QuanTriVienFilter
                {
                    id = e.id,
                    hoten = e.hoten,
                    username = e.username,
                    ten_group = t==null?"":t.ten,
                    @group = t,
                    quantrivien = e
                }).ToList();
            return re;
        }
        #endregion
    }
}
