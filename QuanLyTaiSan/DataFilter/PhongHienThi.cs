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
        public int id { get; set; }
        public String ten { get; set; }
        public String mota { get; set; }
        public String tennvpt { get; set; }
        public int soluongtb { get; set; }
        /*
         * FK Object
         */
        #region Nghiệp vụ
        public List<PhongHienThi> getAllByViTri(int _cosoid, int _dayid, int _tangid)
        {
            //InitDb();
            List<PhongHienThi> re =
                (from p in db.PHONGS
                 where(_cosoid==-1||p.vitri.coso.id==_cosoid)&&(_dayid==-1||p.vitri.day.id ==_dayid)&&(_tangid==-1||p.vitri.tang.id==_tangid)
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
            return new ChiTietTBHienThi().getAllByPhongId(this.id);
        }
        #endregion
    }
}
