using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class PhongHienThi:FilterAbstract<PhongHienThi>
    {
        public PhongHienThi():base()
        {

        }
        public Guid id { get; set; }
        public String ten { get; set; }
        public String mota { get; set; }
        public String tennvpt { get; set; }
        public int soluongtb { get; set; }
        /*
         * FK Object
         */
        #region Nghiệp vụ
        public static List<PhongHienThi> getAllByViTri(Guid _cosoid, Guid _dayid, Guid _tangid)
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
                     tennvpt = p.nhanvienpt.hoten,
                     soluongtb = p.ctthietbis.Count
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
