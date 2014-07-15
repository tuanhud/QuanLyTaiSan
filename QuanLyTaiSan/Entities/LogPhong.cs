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
     * Log thiet bi, phuc vu thong ke
     */
    [Table("LOGPHONGS")]
    public class LogPhong : _EntityAbstract1<LogPhong>
    {
        public LogPhong()
            : base()
        {

        }
        #region Dinh nghia
        [Index("nothing", 1, IsUnique = true)]
        [Required]
        public DateTime ngay { get; set; }

        /*
         * FK
         */

        public int tinhtrang_id { get; set; }
        [Index("nothing", 3, IsUnique = true)]
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public int phong_id { get; set; }
        [Index("nothing", 4, IsUnique = true)]
        [Required]
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public int? quantrivien_id { get; set; }
        [Index("nothing", 2, IsUnique = true)]
        [ForeignKey("quantrivien_id")]
        public virtual QuanTriVien quantrivien { get; set; }

        public virtual ICollection<HinhAnh> hinhanhs { get; set; }
		#endregion

        #region Override method
        public override int update()
        {
            //have to load all [Required] FK object first
            if (tinhtrang != null)
            {
                tinhtrang.trigger();
            }
            if (phong != null)
            {
                phong.trigger();
            }
            if (quantrivien != null)
            {
                quantrivien.trigger();
            }
            
            //...
            return base.update();
        }
        protected override void init()
        {
            base.init();
            hinhanhs = new List<HinhAnh>();
        }
        #endregion
    }
}
