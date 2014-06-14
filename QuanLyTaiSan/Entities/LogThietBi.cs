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
    [Table("LOGTHIETBIS")]
    public class LogThietBi : _EntityAbstract1<LogThietBi>
    {
        public LogThietBi():base()
        {

        }
        public LogThietBi(MyDB db)
            : base(db)
        {
            
        }
        
        [Index("nothing", 1, IsUnique = true)]
        public DateTime ngay { get; set; }
        [Required]
        public int soluong { get; set; }
        public String mota { get; set; }
        /*
         * FK
         */
        [Index("nothing", 2,IsUnique=true)]
        public virtual ThietBi thietbi { get; set; }
        [Index("nothing", 3, IsUnique = true)]
        public virtual TinhTrang tinhtrang { get; set; }
        [Index("nothing", 4, IsUnique = true)]
        public virtual Phong phong { get; set; }
    }
}
