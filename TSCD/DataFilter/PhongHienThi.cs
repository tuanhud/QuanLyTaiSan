using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class PhongHienThi : FilterAbstract<PhongHienThi>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String loai { get; set; }
        public String vitri { get; set; }
        public virtual Phong phong { get; set; }

        public static List<PhongHienThi> getPhongByViTri(Guid _cosoid, Guid _dayid, Guid _tangid)
        {
            List<PhongHienThi> re =
                (from p in db.PHONGS
                 where (_cosoid == Guid.Empty || p.vitri.coso.id == _cosoid) && (_dayid == Guid.Empty || p.vitri.day.id == _dayid) && (_tangid == Guid.Empty || p.vitri.tang.id == _tangid)
                 select new PhongHienThi
                 {
                     id = p.id,
                     ten = p.ten,
                     loai = p.loaiphong.ten,
                     vitri = p.vitri.coso != null ? p.vitri.coso.ten + (p.vitri.day != null ? " - " + p.vitri.day.ten + (p.vitri.tang != null ? " - " + p.vitri.tang.ten : "") : "") : "",
                     phong = p
                 }).ToList();
            return re;
        }
    }
}
