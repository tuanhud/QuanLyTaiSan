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
    public class CTThietBi
    {
        public CTThietBi()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int soluong { get; set; }
        /*
         * FK
         */
        [Index("nothing",1,IsUnique=true)]
        public virtual ThietBi thietbi { get; set; }
        [Index("nothing", 2, IsUnique = true)]
        public virtual TinhTrang tinhtrang { get; set; }
    }
}
