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
    [Table("PHONGS")]
    public class Phong:_EntityAbstract<Phong>
    {
        public Phong()
        {
            this.thietbis = new List<ThietBi>();
        }
        /*
         * FK
         */
        public virtual CoSo coso { get; set; }
        public virtual GiaTri dientich { get; set; }
        public virtual ICollection<ThietBi> thietbis { get; set; }
    }
}
