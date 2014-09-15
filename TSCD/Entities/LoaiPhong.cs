using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("LOAIPHONGS")]
    public class LoaiPhong : _EntityAbstract1<LoaiPhong>
    {
        public LoaiPhong()
            : base()
        {

        }
        #region Định nghĩa

        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }
        /*
         * FK
         */

        /// <summary>
        /// Danh sách phòng
        /// </summary>
        public virtual ICollection<Phong> phongs { get; set; }
        #endregion

        #region Nghiệp vụ

        #endregion

        #region Override
        public static new String VNNAME
        {
            get
            {
                return "LOẠI PHÒNG";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten;
        }
        protected override void init()
        {
            base.init();
        }
        #endregion
    }
}
