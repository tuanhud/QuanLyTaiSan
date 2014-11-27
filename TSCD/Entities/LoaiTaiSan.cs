using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("LOAITAISANS")]
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

        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        public int sonamsudung { get; set; }
        /// <summary>
        /// Số năm sử dụng (Theo quyet dinh moi T32)
        /// </summary>
        public int sonamsudung_2 { get; set; }
        /// <summary>
        /// Phần trăm hao mòn/năm
        /// </summary>
        public int phantramhaomon { get; set; }
        /// <summary>
        /// Phần trăm hao mòn/năm
        /// </summary>
        public int phantramhaomon_2 { get; set; }
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
        /// <summary>
        /// Lấy tất cả đám con cháu Đơn vị dưới root
        /// </summary>
        /// <param name="root"></param>
        /// <param name="included_root_in_result"></param>
        /// <returns></returns>
        public List<LoaiTaiSan> getAllChildsRecursive(Boolean included_root_in_result = true)
        {
            List<LoaiTaiSan> tmp = new List<LoaiTaiSan>();
            if (included_root_in_result)
            {
                tmp.Add(this);
            }
            if (childs != null)
            {
                foreach (LoaiTaiSan item in childs)
                {
                    tmp.AddRange(item.getAllChildsRecursive(included_root_in_result));
                }
            }
            return tmp;
        }

        #endregion

        #region Override
        public static new String VNNAME
        {
            get
            {
                return "LOẠI TÀI SẢN";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten;
        }
        protected override void init()
        {
            base.init();
            huuhinh = true;
        }
        public override void doTrigger()
        {
            if (parent != null)
            {
                parent.trigger();
            }
            if (donvitinh != null)
            {
                donvitinh.trigger();
            }
            base.doTrigger();
        }
        #endregion
    }
}
