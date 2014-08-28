using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Entities
{
    [Table("TSCD_LOAICHUTHE")]
    public class LoaiChuThe : _EntityAbstract1<LoaiChuThe>
    {
        public LoaiChuThe()
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
        /// Danh sách chủ thể thuộc loại này
        /// </summary>
        public virtual ICollection<ChuThe> chuthes { get; set; }
        #endregion

        #region Nghiệp vụ

        #endregion

        #region Override
        protected override void init()
        {
            base.init();
        }
        #endregion
    }
}
