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
     * Không thể đặt tên là Day vì trùng class Day của Winform
     */
    [Table("DAYYS")]
    public class Dayy:_EntityAbstract2<Dayy>
    {
        public Dayy():base()
        {
            
        }
        public Dayy(MyDB db)
            : base(db)
        {
            
        }
        protected override void init()
        {
            base.init();
            vitris = new List<ViTri>();
            tangs = new List<Tang>();
        }
        /*
         * FK
         */
        [Required]
        public virtual CoSo coso { get; set; }
        public virtual ICollection<Tang> tangs { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
    }
}
