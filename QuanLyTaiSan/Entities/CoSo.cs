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
            this.days = new List<Day>();
        }
        public virtual ICollection<Day> days { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
    }
}
