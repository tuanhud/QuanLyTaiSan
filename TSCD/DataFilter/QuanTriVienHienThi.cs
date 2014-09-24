using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class QuanTriVienHienThi : _FilterAbstract<QuanTriVienHienThi>
    {
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

        #region Nghiệp vụ
        public static List<QuanTriVienHienThi> getAll()
        {
            List<QuanTriVienHienThi> re = QuanTriVien.getQuery().Select(
                c =>
                 new QuanTriVienHienThi
                 {
                     id = c.id,
                     hoten = c.hoten,
                     username = c.username,
                     date_create = c.date_create,
                     date_modified = c.date_modified,
                     ten_group = c.group == null ? "" : c.group.ten,
                     quantrivien = c
                 }
            ).ToList();
            return re;
        }
        #endregion
    }
}
