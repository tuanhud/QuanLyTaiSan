using QuanLyTaiSan.Libraries;
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
    [Table("SUCOPHONGS")]
    public class SuCoPhong : _EntityAbstract2<SuCoPhong>
    {
        public SuCoPhong()
            : base()
        {

        }
        #region Dinh Nghia
        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }

        public int tinhtrang_id { get; set; }
        [Index("nothing", 2, IsUnique = true)]
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public int phong_id { get; set; }
        [Index("nothing", 3, IsUnique = true)]
        [Required]
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }

		#endregion

        #region Nghiệp vụ


        #endregion

        #region Override method
        /// <summary>
        /// Set tên, tình trạng, phòng, mô tả trước khi gọi,
        /// Có hỗ trợ ghi log
        /// </summary>
        /// <param name="hinhs">Hình sự cố</param>
        /// <returns></returns>
        public int add(List<HinhAnh> hinhs=null)
        {
            Boolean transac = true;
            DateTime ngay = ServerTimeHelper.getNow();
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                //add
                transac = transac && base.add()>0;
                //write log
                transac = transac && writelog(ngay, this.mota, hinhs)>0;

                //final transac controller
                if (transac)
                {
                    dbContextTransaction.Commit();
                }
                else
                {
                    dbContextTransaction.Rollback();
                }

                return transac ? 1 : -1;
            }
        }
        protected int writelog(DateTime ngay, String mota="", List<HinhAnh> hinhs=null)
        {
            LogSuCoPhong obj = new LogSuCoPhong();
            obj.hinhanhs = hinhs==null?new List<HinhAnh>():hinhs;
            obj.mota = mota;
            obj.ngay = ngay;
            obj.sucophong = this;
            obj.quantrivien = Global.current_login;
            obj.tinhtrang = this.tinhtrang;
            
            return obj.add();
        }
        /// <summary>
        /// Có hỗ trợ ghi log
        /// </summary>
        /// <returns></returns>
        public int update(List<HinhAnh> hinhs=null)
        {
            //have to load all [Required] FK object first
            if (phong != null)
            {
                phong.trigger();
            }
            if (tinhtrang != null)
            {
                tinhtrang.trigger();
            }

            Boolean transac = true;
            DateTime ngay = ServerTimeHelper.getNow();
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                //add
                transac = transac && base.update() > 0;
                //write log
                transac = transac && writelog(ngay, this.mota, hinhs) > 0;

                //final transac controller
                if (transac)
                {
                    dbContextTransaction.Commit();
                }
                else
                {
                    dbContextTransaction.Rollback();
                }

                return transac ? 1 : -1;
            }
        }
        protected override void init()
        {
            base.init();
            logsucophongs = new List<LogSuCoPhong>();
        }
        public override int delete()
        {
            //auto delete log
            db.LOGSUCOPHONGS.RemoveRange(logsucophongs);
            return base.delete();
        }
        #endregion
    }
}
