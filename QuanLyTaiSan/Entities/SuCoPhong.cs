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
    public class SuCoPhong : _EntityAbstract1<SuCoPhong>
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

		#endregion

        #region Override method
        public override int update()
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
            //...
            return base.update();
        }
        protected override void init()
        {
            base.init();
        }
        #endregion
    }
}
