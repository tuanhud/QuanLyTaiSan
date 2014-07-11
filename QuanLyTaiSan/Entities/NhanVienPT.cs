using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("NHANVIENPTS")]
    public class NhanVienPT : _EntityAbstract1<NhanVienPT>
    {
        public NhanVienPT():base()
        {
            
        }
        #region Dinh nghia
        [Required]
        public String hoten { get; set; }
        public String sodienthoai { get; set; }
        
        /*
         * FK 
         */
        public virtual ICollection<Phong> phongs { get; set; }
        public virtual ICollection<HinhAnh> hinhanhs { get; set; }
        #endregion
        #region Nghiệp vụ
        /// <summary>
        /// Lấy hình ảnh đại diện (hình thứ 0)
        /// </summary>
        /// <returns>Có thể null nếu chưa có hình</returns>
        public HinhAnh getAvatar()
        {
            if (hinhanhs == null || hinhanhs.Count == 0)
            {
                //or return default
                return null;
            }
            return hinhanhs.FirstOrDefault();
        }
        public static List<NhanVienPT> getAllByViTri(int _phongid, int _cosoid, int _dayid, int _tangid)
        {
            List<NhanVienPT> re =
                (from nv in db.NHANVIENPTS
                 join p in db.PHONGS on nv equals p.nhanvienpt
                 where ((_phongid == -1 || p.id == _phongid) && (_cosoid == -1 || p.vitri.coso.id == _cosoid) && (_dayid == -1 || p.vitri.day.id == _dayid) && (_tangid == -1 || p.vitri.tang.id == _tangid))
                 select nv).Distinct().ToList();
            return re;
        }
        /*public static List<NhanVienPT> getAllOneImage()
        {
           // xuất ra 1 hình ảnh của list nhân viên
        }*/
        #endregion
        #region Override method
        protected override void init()
        {
            base.init();
            phongs = new List<Phong>();
            hinhanhs = new List<HinhAnh>();
        }
        public override int delete()
        {
            if (phongs.Count > 0)
            {
                return -1;
            }
            return base.delete();
        }
        #endregion
    }
}
