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
    [Table("COSOS")]
    public class CoSo:_EntityAbstract2<CoSo>
    {
        public CoSo():base()
        {
            this.dayys = new List<Dayy>();
        }
        public virtual ICollection<Dayy> dayys { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
        public override int update()
        {
            return base.update();
        }
    }
}
