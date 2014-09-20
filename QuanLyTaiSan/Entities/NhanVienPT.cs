using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Entities
{
    [Table("NHANVIENPTS")]
    public class NhanVienPT : _EntityAbstract2<NhanVienPT>
    {
        public NhanVienPT():base()
        {
            
        }
        #region Dinh nghia
        /// <summary>
        /// true: Nam,
        /// false: Nữ
        /// </summary>
        public Boolean gioitinh { get; set; }
        [Required]
        public String hoten { get; set; }
        public String sodienthoai { get; set; }
        
        /*
         * FK 
         */
        public virtual ICollection<Phong> phongs { get; set; }
        #endregion
        #region Nghiệp vụ
        /// <summary>
        /// Lấy URL hình ảnh đại diện (hình thứ 0 nếu có)
        /// </summary>
        /// <returns>Luôn là một URL có nghĩa</returns>
        public String getAvatar()
        {
            if (hinhanhs == null || hinhanhs.Count == 0)
            {
                return HinhAnh.DEFAULT_IMAGE_URL;
            }
            return hinhanhs.FirstOrDefault().getImageURL();
        }
        #endregion
        #region Override method
        public override string niceName()
        {
            String tmp = "Nhân viên PT: ";
            tmp += hoten;
            if (subId != null && !subId.Equals(""))
            {
                tmp += "(" + subId + ")";
            }
            return tmp;
        }
        protected override void init()
        {
            base.init();
            phongs = new List<Phong>();
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
