using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace QuanLyTaiSan.Entities
{
    /// <summary>
    /// Lưu vết sự thay đổi trên 1 tài sản
    /// </summary>
    [Table("TSCD_LOGTAISAN")]
    public class LogTaiSan:_EntityAbstract1<LogTaiSan>
    {
        public LogTaiSan():base()
        {

        }
        #region Dinh nghia

        [Required]
        public int soluong { get; set; }

        public String chungtu_sohieu { get; set; }
        public DateTime? chungtu_ngay { get; set; }

        /*
         * FK
         */
        public Guid quantrivien_id { get; set; }
        /// <summary>
        /// Quản trị viên phát sinh log
        /// </summary>
        [ForeignKey("quantrivien_id")]
        [Required]
        public virtual QuanTriVien quantrivien { get; set; }

        public Guid taisan_id { get; set; }
        [ForeignKey("taisan_id")]
        [Required]
        public virtual TaiSan taisan { get; set; }

        public Guid? chuthequanly_id { get; set; }
        /// <summary>
        /// Đơn vị chịu trách nhiệm quản lý, nullable
        /// </summary>
        [ForeignKey("chuthequanly_id")]
        public virtual ChuThe chuthequanly { get; set; }

        public Guid? chuthesudung_id { get; set; }
        /// <summary>
        /// Cá nhân sử dụng, nullable
        /// </summary>
        [ForeignKey("chuthesudung_id")]
        public virtual ChuThe chuthesudung { get; set; }

        public Guid tinhtrang_id { get; set; }
        /// <summary>
        /// Tình trạng hiện tại, not null
        /// </summary>
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        #endregion

        #region Nghiep vu


        #endregion

        #region Override


        #endregion
    }
}
