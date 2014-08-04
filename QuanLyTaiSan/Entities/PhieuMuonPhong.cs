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
        /// 0: Chưa xử lý/Mới,
        /// 1: Đã được chấp nhận,
        /// -1: Đã bị từ chối
        /// </summary>
        public int trangthai { get; set; }
        public String lydotuchoi { get; set; }
        /// <summary>
        /// Mượn cho lớp nào (nếu có)
        /// </summary>
        public String lop { get; set; }
        [Required]
        public String phong { get; set; }
        /*
         * FK
         */
       
        /// <summary>
        /// Người đệ trình phiếu
        /// </summary>
        [Required]
        public virtual GiangVien giangvien { get; set; }
        /// <summary>
        /// Người xử lý phiếu
        /// </summary>
        public int? quantrivien_id { get; set; }
        [ForeignKey("quantrivien_id")]
        public virtual QuanTriVien quantrivien { get; set; }
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
            if (giangvien != null)
            {
                giangvien.trigger();
            }
            if (quantrivien != null)
            {
                quantrivien.trigger();
            }

            return base.update();
        }
        #endregion
    }
}
