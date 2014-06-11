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
    public class ViTri : _EntityAbstract1<ViTri>
    {
        public ViTri():base()
        {
            
        }
        public String mota { get; set; }
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
