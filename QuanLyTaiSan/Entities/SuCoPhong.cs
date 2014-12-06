using PTB.Libraries;
using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Entities
{
    [Table("SUCOPHONGS")]
    public class SuCoPhong : _EntityAbstract2<SuCoPhong>
    {
        public SuCoPhong()
            : base()
        {

        }
        #region Dinh Nghia
        [Required]
        public DateTime ngay { get; set; }
        /*
         * FK
         */
        //[Index("nothing", 1, IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }

        public Guid tinhtrang_id { get; set; }
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public Guid phong_id { get; set; }
        //[Index("nothing", 2, IsUnique = true)]
        [Required]
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        /// <summary>
        /// Su dung khi sua chua, co luu lai gia tien
        /// </summary>
        //public long phisuachua { get; set; }
        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }

		#endregion

        #region Nghiệp vụ


        #endregion
        public static new String VNNAME
        {
            get
            {
                return "SỰ CỐ";
            }
        }

        public override string niceName()
        {
            return VNNAME + ": " + ten + ", " + phong.niceName();
        }
        #region Override method
        public override void doTrigger()
        {
            if (tinhtrang != null)
            {
                tinhtrang.trigger();
            }
            if (phong != null)
            {
                phong.trigger();
            }
            base.doTrigger();
        }
        /// <summary>
        /// Set tên, tình trạng, phòng, mô tả, ngày, hình ảnh trước khi gọi,
        /// Có hỗ trợ ghi log
        /// </summary>
        /// <param name="hinhs">Hình sự cố</param>
        /// <returns></returns>
        public override int add()
        {
            //add
            base.add();
            writelog();
            return 1;
        }
        protected int writelog()
        {
            try
            {
                LogSuCoPhong obj = new LogSuCoPhong();
                //obj.phisuachua = phisuachua;
                obj.hinhanhs = hinhanhs;
                obj.mota = this.mota;
                obj.sucophong = this;
                obj.quantrivien = Global.current_quantrivien_login;
                obj.tinhtrang = this.tinhtrang;

                return obj.add();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }
        /// <summary>
        /// Có hỗ trợ ghi log
        /// </summary>
        /// <returns></returns>
        public override int update()
        {
            //add
            base.update();
            //write log
            writelog();
            return 1;
        }
        protected override void init()
        {
            base.init();
            logsucophongs = new List<LogSuCoPhong>();
        }
        public override int delete()
        {
            try
            {
                if (logsucophongs != null)
                {
                    while (logsucophongs.Count > 0)
                    {
                        logsucophongs.FirstOrDefault().delete();
                    }
                }
                return base.delete();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }
        #endregion
    }
}
