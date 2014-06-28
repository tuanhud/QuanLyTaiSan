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
        
		#region Dinh nghia
        /*
         * FK
         */
        public int day_id { get; set; }
        [Required]
        [ForeignKey("day_id")]
        public virtual Dayy day { get; set; }

        public virtual ICollection<ViTri> vitris { get; set; }
		#endregion
		#region Override method
        protected override void init()
        {
            base.init();
            this.vitris = new List<ViTri>();
        }
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
        public override int delete()
        {
            if (vitris.Count > 0)
            {
                return -1;
            }
            return base.delete();
        }
        #endregion
    }
}
