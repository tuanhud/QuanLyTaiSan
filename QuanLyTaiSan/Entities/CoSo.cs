using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class CoSo:_EntityAbstract<Phong>
    {
        public CoSo():base()
        {
            this.phongs = new List<Phong>();
        }
        public String diachi { get; set; }
        public String lienhe { get; set; }
        public virtual ICollection<Phong> phongs { get; set; }
    }
}
