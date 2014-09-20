using PTB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.DataFilter
{
    public class QuanTriVienFilter:_FilterAbstract<QuanTriVienFilter>
    {
        public QuanTriVienFilter():base()
        {

        }

        public Guid id { get; set; }
        public String username { get; set; }
        public String hoten { get; set; }
        public String ten_group { get; set; }
        public DateTime? date_create { get; set; }
        public DateTime? date_modified { get; set; }
        /*
         * FK Object
         */
        public QuanTriVien quantrivien { get; set; }
        public Group group { get; set; }

        #region Nghiệp vụ
        public static List<QuanTriVienFilter> getAll()
        {
            List<QuanTriVienFilter> re = QuanTriVien.getQuery().Select(
                c =>
                 new QuanTriVienFilter
                 {
                     id = c.id,
                     hoten = c.hoten,
                     username = c.username,
                     date_create = c.date_create,
                     date_modified = c.date_modified,
                     ten_group = c.group==null?"":c.group.ten,
                     quantrivien = c
                 }
            ).ToList();
            return re;
        }
        #endregion
    }
}
