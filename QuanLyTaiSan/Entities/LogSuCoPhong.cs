using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Entities
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

        public Guid tinhtrang_id { get; set; }
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public Guid sucophong_id { get; set; }
        [Required]
        [ForeignKey("sucophong_id")]
        public virtual SuCoPhong sucophong { get; set; }

        public Guid? quantrivien_id { get; set; }
        [ForeignKey("quantrivien_id")]
        public virtual QuanTriVien quantrivien { get; set; }

        /// <summary>
        /// Su dung khi sua chua coa phat sinh gia tien
        /// </summary>
        public long phisuachua { get; set; }
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
        public override void doTrigger()
        {
            if (tinhtrang != null)
            {
                tinhtrang.trigger();
            }
            if (sucophong != null)
            {
                sucophong.trigger();
            }
            if (quantrivien != null)
            {
                quantrivien.trigger();
            }
            base.doTrigger();
        }
        #endregion
    }
}
