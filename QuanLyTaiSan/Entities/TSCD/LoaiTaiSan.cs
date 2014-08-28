using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Entities
{
    [Table("TSCD_LOAITAISAN")]
    public class LoaiTaiSan : _EntityAbstract1<LoaiTaiSan>
    {
        public LoaiTaiSan()
            : base()
        {

        }
        #region Định nghĩa
        /// <summary>
        /// Hữu hình (true) hay vô hình (false)
        /// </summary>
        public Boolean huuhinh { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }
        /*
         * FK
         */
        public Guid? donvitinh_id { get; set; }
        [ForeignKey("donvitinh_id")]
        public virtual DonViTinh donvitinh { get; set; }

        public Guid? parent_id { get; set; }
        [ForeignKey("parent_id")]
        public virtual LoaiTaiSan parent { get; set; }

        /// <summary>
        /// Danh sách loại con
        /// </summary>
        public virtual ICollection<LoaiTaiSan> childs { get; set; }
        public virtual ICollection<TaiSan> taisans { get; set; }
        #endregion

        #region Nghiệp vụ

        #endregion

        #region Override
        protected override void init()
        {
            base.init();

            huuhinh = true;
        }
        #endregion
    }
}
