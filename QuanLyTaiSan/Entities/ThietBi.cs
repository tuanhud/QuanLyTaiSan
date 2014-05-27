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
    [Table("THIETBIS")]
    public class ThietBi:_EntityAbstract<ThietBi>
    {
        public ThietBi():base()
        {
            this.ctthietbis = new List<CTThietBi>();
        }
        public DateTime ngaymua { get; set; }
        public DateTime ngaylap { get; set; }
        /*
         * Donvi: Thang
         */
        public virtual int baohanh { get; set; }
        public virtual GiaTri giatri { get; set; }
        /*
         * FK
         */
        public virtual Phong phong { get; set; }
        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
    }
}
