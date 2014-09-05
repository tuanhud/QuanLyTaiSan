using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("LOAIDONVIS")]
    public class LoaiDonVi : _EntityAbstract1<LoaiDonVi>
    {
        public LoaiDonVi()
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
        /// Danh sách đơn vị thuộc loại này
        /// </summary>
        public virtual ICollection<DonVi> donvis { get; set; }
        #endregion

        #region Nghiệp vụ

        #endregion

        #region Override
        public override string niceName()
        {
            return "Loại đơn vị: " + ten;
        }
        #endregion
    }
}
