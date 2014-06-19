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
    [Table("TANGS")]
    public class Tang:_EntityAbstract2<Tang>
    {
        public Tang():base()
        {
            
        }
        public Tang(MyDB db)
            : base(db)
        {

        }
        protected override void init()
        {
            base.init();
            this.vitris = new List<ViTri>();
        }
		#region Dinh nghia
        /*
         * FK
         */
        [Required]
        public virtual Dayy day { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }
		#endregion
		#region Override method
        public override int update()
        {
            //have to load all [Required] FK object first
            if (day != null)
            {
                day.trigger();
            }
            
            //...
            return base.update();
        }

        #endregion
    }
}
