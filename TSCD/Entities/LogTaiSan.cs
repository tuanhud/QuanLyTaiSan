using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    /// <summary>
    /// Lưu vết sự thay đổi trên 1 tài sản
    /// </summary>
    [Table("LOGTAISANS")]
    public class LogTaiSan:_EntityAbstract1<LogTaiSan>
    {
        public LogTaiSan():base()
        {

        }
        #region Dinh nghia
        /// <summary>
        /// Ghi chú sự thay đổi (khi chuyển đơn vị, chuyển tình trạng, sửa mô tả ...)
        /// </summary>
        public String ghichu { get; set; }
        /// <summary>
        /// Đánh dấu tăng tài sản (có thể là tăng cho trường hoặc tăng cho đơn vị do chuyển từ đơn vị khác sang)
        /// </summary>
        public Boolean isTang { get; set; }
        /// <summary>
        /// Chuyển từ đơn vị khác sang
        /// </summary>
        public Boolean isChuyen { get; set; }

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

        public Guid? donviquanly_id { get; set; }
        /// <summary>
        /// Đơn vị chịu trách nhiệm quản lý, nullable
        /// </summary>
        [ForeignKey("donviquanly_id")]
        public virtual DonVi donviquanly { get; set; }

        public Guid? donvisudung_id { get; set; }
        /// <summary>
        /// Cá nhân sử dụng, nullable
        /// </summary>
        [ForeignKey("donvisudung_id")]
        public virtual DonVi donvisudung { get; set; }

        public Guid tinhtrang_id { get; set; }
        /// <summary>
        /// Tình trạng hiện tại, not null
        /// </summary>
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public Guid? vitri_id { get; set; }
        /// <summary>
        /// Vị trí hiện tại của tài sản (CS, Dãy, Tầng), nullable
        /// </summary>
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }

        public Guid? phong_id { get; set; }
        /// <summary>
        /// Phòng hiện tại (nếu có phòng thì khỏi chỉ định vi trí cũng được)
        /// </summary>
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        #endregion

        #region Nghiep vu


        #endregion

        #region Override


        #endregion
    }
}
