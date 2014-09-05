using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    /// <summary>
    /// Lưu sự phân bổ hiện tại của tài sản
    /// </summary>
    [Table("CTTAISANS")]
    public class CTTaiSan : _EntityAbstract1<CTTaiSan>
    {
        public CTTaiSan()
            : base()
        {

        }
        #region Định nghĩa
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
        /// <summary>
        /// Số lượng
        /// </summary>
        [Required]
        public int soluong { get; set; }
        
        /// <summary>
        /// Mô tả về nguồn gốc của tài sản này
        /// </summary>
        public String nguongoc { get; set; }
        /// <summary>
        /// Ngày cấp, ngày có hiệu lực
        /// </summary>
        public DateTime? ngay { get; set; }
        /// <summary>
        /// Mã chứng từ
        /// </summary>
        public String chungtu_sohieu { get; set; }
        /// <summary>
        /// Ngày chứng từ
        /// </summary>
        public DateTime? chungtu_ngay { get; set; }

        /*
         * FK
         */
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

        public Guid taisan_id { get; set; }
        /// <summary>
        /// Thuộc tài sản
        /// </summary>
        [ForeignKey("taisan_id")]
        [Required]
        public virtual TaiSan taisan { get; set; }

        public Guid? parent_id { get; set; }
        /// <summary>
        /// Tài sản có thể chứa bên trong nhiều tài sản khác
        /// </summary>
        [ForeignKey("parent_id")]
        public virtual CTTaiSan parent { get; set; }

        /// <summary>
        /// Tài sản bên trong nó
        /// </summary>
        public virtual ICollection<CTTaiSan> childs { get; set; }
        #endregion

        #region Nghiệp vụ
        /// <summary>
        /// Trường tự động tính (KHÔNG lưu trong CSDL, NotMapped),
        /// thanhtien=soluong*dongia
        /// </summary>
        [NotMapped]
        public long thanhtien
        {
            get
            {
                return taisan.dongia * soluong;
            }
        }
        #endregion

        #region Override
        protected override void init()
        {
            base.init();
        }
        #endregion
    }
}
