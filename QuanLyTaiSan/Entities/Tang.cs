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
        public override void moveUp()
        {
            Tang prev = db.TANGS.Where(c => c.order < this.order && c.day_id == this.day_id).OrderByDescending(c => c.order).FirstOrDefault();
            if (prev == null)
            {
                return;
            }
            //SWAP order value
            int? order_1 = this.order == null ? this.id : this.order;
            int? order_2 = prev.order == null ? prev.id : prev.order;

            this.order = order_2;
            prev.order = order_1;

            this.update();
            prev.update();
        }
        public override void moveDown()
        {
            Tang next = db.TANGS.Where(c => c.order > this.order && c.day_id == this.day_id).OrderBy(c => c.order).FirstOrDefault();
            if (next == null)
            {
                return;
            }
            next.moveUp();
        }
        #endregion
    }
}
