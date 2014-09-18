using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
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
            this.type = TYPE_THIETBI;
        }
        /// <summary>
        /// Xem TinhTrang.TYPE_XXX de biet cac type ho tro
        /// </summary>
        /// <param name="type"></param>
        public TinhTrang(int type)
            : base()
        {
            this.type = type;
        }

        #region Dinh nghia
        /// <summary>
        /// Xem TinhTrang.TYPE_xxxx để biết,
        /// TinhTrang.TYPE_THIETBI: Tinh trang cho THIETBI,
        /// TinhTrang.TYPE_SUCOPHONG: Tinh trang cho SUCOPHONG,
        /// TinhTrang.TYPE_TAISAN: Tinh trang cho TSCD
        /// </summary>
        public int? type { get; set; }
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
         * FK PTB
         */
        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<SuCoPhong> sucophongs { get; set; }
        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
        /*
         * FK for QLTSCD
         */
        #endregion

        #region Override
        public static List<TinhTrang> getAllForTHIETBI()
        {
            try
            {
                return db.TINHTRANGS.Where(c =>c.type ==null || c.type == TinhTrang.TYPE_THIETBI).OrderBy(c=>c.order).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<TinhTrang>();
            }
        }
        public static List<TinhTrang> getAllForSUCOPHONG()
        {
            try
            {
                return db.TINHTRANGS.Where(c => c.type == TinhTrang.TYPE_SUCOPHONG).OrderBy(c => c.order).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<TinhTrang>();
            }
        }
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
            //Mac dinh la danh cho ThietBi
            this.type = TinhTrang.TYPE_THIETBI;

            ctthietbis = new List<CTThietBi>();
            logthietbis = new List<LogThietBi>();
            sucophongs = new List<SuCoPhong>();
            logsucophongs = new List<LogSuCoPhong>();
        }
        public override int delete()
        {
            if (ctthietbis.Count > 0)
            {
                return -1;
            }
            return base.delete();
        }
        #endregion
        #region static member
        [NotMapped]
        public static int TYPE_THIETBI
        {
            get
            {
                return 0;
            }
        }
        [NotMapped]
        public static int TYPE_SUCOPHONG
        {
            get
            {
                return 1;
            }
        }
        #endregion
    }
}
