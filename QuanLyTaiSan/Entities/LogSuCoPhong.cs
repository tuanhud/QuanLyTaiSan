using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("LOGSUCOPHONGS")]
    public class LogSuCoPhong: _EntityAbstract2<LogSuCoPhong>
    {
        public LogSuCoPhong()
            : base()
        {

        }
        #region Dinh nghia
        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        [Required]
        public DateTime ngay { get; set; }

        public int tinhtrang_id { get; set; }
        [Index("nothing", 2, IsUnique = true)]
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public int sucophong_id { get; set; }
        [Index("nothing", 2, IsUnique = true)]
        [Required]
        [ForeignKey("sucophong_id")]
        public virtual SuCoPhong sucophong { get; set; }

        public int? quantrivien_id { get; set; }
        [Index("nothing", 4, IsUnique = true)]
        [ForeignKey("quantrivien_id")]
        public virtual QuanTriVien quantrivien { get; set; }

        #endregion

        #region Override
        protected override void init()
        {
            base.init();
        }
        /// <summary>
        /// Không có UPDATE cho LOG
        /// </summary>
        /// <returns></returns>
        public override int update()
        {
            return -1;
        }
        #endregion
    }
}
