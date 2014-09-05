using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class ViTriHienThi : FilterAbstract<ViTriHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String loaiphong { get; set; }
        public Guid parent_id { get; set; }
        public Phong phong { get; set; }
        public long? order { get; set; }

        #region Nghiệp vụ
        public static List<ViTriHienThi> getAllCoSo()
        {
            List<ViTriHienThi> re =
                (from c in db.COSOS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(CoSo).Name,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }
        public static List<ViTriHienThi> getAllDay()
        {
            List<ViTriHienThi> re =
                (from c in db.DAYYS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Dayy).Name,
                     parent_id = c.coso.id,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }
        public static List<ViTriHienThi> getAllTang()
        {
            List<ViTriHienThi> re =
                (from c in db.TANGS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Tang).Name,
                     parent_id = c.day.id,
                     order = c.order
                 }).OrderBy(c => c.order).ToList();
            return re;
        }

        public static List<ViTriHienThi> getAllPhong()
        {
            List<ViTriHienThi> re =
                (from c in db.PHONGS
                 select new ViTriHienThi
                 {
                     id = c.id,
                     ten = c.ten,
                     loai = typeof(Phong).Name,
                     parent_id = (c.vitri.tang != null ? c.vitri.tang.id : (c.vitri.day != null ? c.vitri.day.id : (c.vitri.coso != null ? c.vitri.coso.id : Guid.Empty))),
                     loaiphong = c.loaiphong.ten,
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
        #endregion
    }
}
