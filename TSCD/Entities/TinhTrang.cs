using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    /*
     * Tinh trang thiet bi
     */
    [Table("TINHTRANGS")]
    public class TinhTrang : _EntityAbstract1<TinhTrang>
    {
        public TinhTrang()
            : base()
        {
            
        }

        #region Dinh nghia
        /// <summary>
        /// Tên dành riêng (không dấu, không khoảng cách)
        /// </summary>
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String key { get; set; } //vd:huhong
        /// <summary>
        /// Tên tiếng việt đầy đủ
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [StringLength(255)]
        public String value { get; set; } //vd: Hư hỏng
        /*
         * FK for QLTSCD
         */
        public virtual ICollection<CTTaiSan> cttaisans { get; set; }
        public virtual ICollection<LogTaiSan> logtaisans { get; set; }
        #endregion

        #region Override
        public override void onAfterAdded()
        {
            this.order = DateTimeHelper.toMilisec(date_create);
            base.onAfterAdded();
        }
        public static new String VNNAME
        {
            get
            {
                return "TÌNH TRẠNG";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + value;
        }
        protected override void init()
        {
            base.init();
        }
        public override int delete()
        {
            return base.delete();
        }
        #endregion
    }
}
