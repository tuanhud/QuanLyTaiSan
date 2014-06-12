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
    public class Phong:_EntityAbstract2<Phong>
    {
        public Phong():base()
        {
            
        }
        public Phong(MyDB db)
            : base(db)
        {
            
        }
        protected override void init()
        {
            base.init();
            this.ctthietbis = new List<CTThietBi>();
        }
        /*
         * FK
         */
        [Required]
        public virtual ViTri vitri { get; set; }
        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual NhanVienPT nhanvienpt { get; set; }
    }
}
