using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("VITRIS")]
    public class ViTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public ViTri()
        {
            
        }
        /*
         * FK
         */
        [Index("nothing", 1, IsUnique = true)]
        public virtual CoSo coso { get; set; }

        [Index("nothing", 2, IsUnique = true)]
        public virtual Day day { get; set; }

        [Index("nothing", 3, IsUnique = true)]
        public virtual Tang tang { get; set; }

        public virtual ICollection<Phong> phongs { get; set; }
    }
}
