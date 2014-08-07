using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("GIANGVIENS")]
    public class GiangVien : _EntityAbstract3<GiangVien>
    {
        
        public GiangVien():base()
        {

        }
        
        #region Định nghĩa thuộc tính
        [Required]
        public String khoa { get; set; }
        [Required]
        public String email { get; set; }
        /*
         * FK
         */
        public virtual ICollection<PhieuMuonPhong> phieumuonphongs { get; set; }
        #endregion

        #region Hàm nghiệp vụ
        
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            phieumuonphongs = new List<PhieuMuonPhong>();
        }
        #endregion
    }
}
