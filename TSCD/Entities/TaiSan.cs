using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("TAISANS")]
    public class TaiSan : _EntityAbstract1<TaiSan>
    {
        public TaiSan():base()
        {

        }
        #region Định nghĩa
        /// <summary>
        /// Tên gọi
        /// </summary>
        [Required]
        public String ten { get; set; }
        /// <summary>
        /// Đơn giá (VNĐ)
        /// </summary>
        [Required]
        public long dongia { get; set; }

        /*
         * FK
         */

        public Guid loaitaisan_id { get; set; }
        [Required]
        [ForeignKey("loaitaisan_id")]
        public virtual LoaiTaiSan loaitaisan { get; set; }

        public virtual ICollection<CTTaiSan> cttaisans { get; set; }
        public virtual ICollection<LogTaiSan> logtaisans { get; set; }

        #endregion

        #region Nghiệp vụ
        /// <summary>
        /// Sửa đơn giá của tài sản
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public int suaDonGia(long newValue)
        {
            dongia = newValue;
            return 1;
        }
        /// <summary>
        /// Sủa tên tài sản
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public int suaTen(String newValue)
        {
            ten = newValue;
            return 1;
        }
        #endregion

        #region Override
        public static new String VNNAME
        {
            get
            {
                return "TÀI SẢN";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten;
        }
        protected override void init()
        {
            base.init();
            //Không nhất thiết phải init tất cả các thuộc tính dạng List
        }
        public override void doTrigger()
        {
            if (loaitaisan != null)
            {
                loaitaisan.trigger();
            }
            base.doTrigger();
        }
        #endregion
    }
}
