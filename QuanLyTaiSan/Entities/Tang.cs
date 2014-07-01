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

        [Required]
        public String ten { get; set; }
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
            //Nếu có ít nhất 1 phòng sử dụng vị trí chứa tầng này thì KHÔNG cho xóa
            if (vitris.Where(c => c.phongs.Count > 0).FirstOrDefault() != null)
            {
                return -2;
            }
            //Xóa tất cả vị trí liên quan
            if (vitris != null)
            {
                while (vitris.Count > 0)
                {
                    vitris.FirstOrDefault().delete();
                }
            }

            return base.delete();
        }
        #endregion
    }
}
