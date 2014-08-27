using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("PHIEUMUONPHONGS")]
    public class PhieuMuonPhong:_EntityAbstract1<PhieuMuonPhong>
    {
        #region Dinh nghia
        /// <summary>
        /// Đơn vị mượn: vd Khoa, Phòng, Ban, ....,
        /// Có thể khác với ĐƠn vị mà quản trị viên trực thuộc
        /// </summary>
        [Required]
        public String donvi { get; set; }
        /// <summary>
        /// Ngày bắt đầu mượn
        /// </summary>
        [Required]
        public DateTime ngaymuon { get; set; }
        /// <summary>
        /// Ngày trả
        /// </summary>
        [Required]
        public DateTime ngaytra { get; set; }
        public String lydomuon { get; set; }

        /// <summary>
        /// Khi duyệt phòng, Quản trị viên cần ghi chú lý do duyệt (hủy, cấp, ...)
        /// </summary>
        public String ghichu { get; set; }
        /// <summary>
        /// 0: Chưa xử lý/Mới,
        /// 1: Đã được chấp nhận,
        /// -1: Đã bị từ chối
        /// </summary>
        public int trangthai { get; set; }
        /// <summary>
        /// Mượn cho lớp nào (nếu có)
        /// </summary>
        public String lop { get; set; }
        [Required]
        public int sophong { get; set; }
        /*
         * FK
         */
        public Guid nguoimuon_id { get; set; }       
        /// <summary>
        /// Người tạo phiếu
        /// </summary>
        [Required]
        [ForeignKey("nguoimuon_id")]
        public virtual QuanTriVien nguoimuon { get; set; }
        /// <summary>
        /// Người xử lý (duyệt) phiếu
        /// </summary>
        public Guid? nguoiduyet_id { get; set; }
        [ForeignKey("nguoiduyet_id")]
        public virtual QuanTriVien nguoiduyet { get; set; }
        [Required]
        public int soluongsv { get; set; }
        #endregion
        #region Override
        protected override void init()
        {
            base.init();
            trangthai = 0;
        }
        public override int update()
        {
            if (nguoimuon != null)
            {
                nguoimuon.trigger();
            }
            if (nguoiduyet != null)
            {
                nguoiduyet.trigger();
            }

            return base.update();
        }
        #endregion
    }
}
