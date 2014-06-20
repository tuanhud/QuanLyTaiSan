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
    [Table("CTTHIETBIS")]
    public class CTThietBi:_EntityAbstract1<CTThietBi>
    {
        public CTThietBi():base()
        {
            
        }
        public CTThietBi(MyDB db)
            : base(db)
        {
            
        }

        [Required]
        public int soluong { get; set; }
        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        public virtual Phong phong { get; set; }

        [Index("nothing", 2,IsUnique=true)]
        public virtual ThietBi thietbi { get; set; }

        [Index("nothing", 3, IsUnique = true)]
        public virtual TinhTrang tinhtrang { get; set; }
		
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
			if (thietbi != null)
            {
                thietbi.trigger();
            }
            
            //...
            return base.update();
        }

        #endregion
    }
}
