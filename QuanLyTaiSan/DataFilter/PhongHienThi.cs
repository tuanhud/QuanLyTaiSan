using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class PhongHienThi:_FilterAbstract<PhongHienThi>
    {
        public PhongHienThi():base()
        {

        }
        public Guid id { get; set; }
        public String ten { get; set; }
        public String mota { get; set; }
        public String nhanvienpt { get; set; }
        public String vitri { get; set; }
        public Phong phong { get; set; }
        /*
         * FK Object
         */
        #region Nghiệp vụ
        public static List<PhongHienThi> getPhongByViTri(Guid _cosoid, Guid _dayid, Guid _tangid)
        {
            //InitDb();
            List<PhongHienThi> re =
                (from p in db.PHONGS
                 where (_cosoid == Guid.Empty || p.vitri.coso.id == _cosoid) && (_dayid == Guid.Empty || p.vitri.day.id == _dayid) && (_tangid == Guid.Empty || p.vitri.tang.id == _tangid)
                 select new PhongHienThi
                 {
                     id=p.id,
                     ten = p.ten,
                     mota = p.mota,
                     nhanvienpt = p.nhanvienpt.hoten,
                     vitri = p.vitri.coso != null ? p.vitri.coso.ten+(p.vitri.day != null ? " - "+p.vitri.day.ten+(p.vitri.tang!= null ? " - "+p.vitri.tang.ten : "") : "") : "",
                     phong = p
                 }).ToList();
            return re;
        }

        public List<ChiTietTBHienThi> ChiTietTBs()
        {
            return ChiTietTBHienThi.getAllByPhongId(this.id);
        }
        #endregion
    }
}
