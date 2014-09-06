using QuanLyTaiSan.Libraries;
using SHARED.Libraries;
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
        public Guid day_id { get; set; }
        [Required]
        [ForeignKey("day_id")]
        public virtual Dayy day { get; set; }

        public virtual ICollection<ViTri> vitris { get; set; }

        public virtual ICollection<Permission> permissions { get; set; }
		#endregion
		#region Override method
        public override string niceName()
        {
            return "Tầng: " + ten + ", " + day.niceName();
        }
        protected override void init()
        {
            base.init();
            this.vitris = new List<ViTri>();
        }
        public override int update()
        {
            
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
        public override Tang prevObj()
        {
            Tang prev = null;
            prev = db.TANGS.Where(c => c.order < this.order && c.day_id == day_id).OrderByDescending(c => c.order).FirstOrDefault();
            if (prev == null)
            {
                prev = db.TANGS.Where(c => c.date_create < this.date_create && c.day_id == day_id).OrderByDescending(c => c.date_create).FirstOrDefault();
            }
            return prev;
        }
        public override Tang nextObj()
        {
            Tang next = null;
            next = db.TANGS.Where(c => c.order > this.order && c.day_id == day_id).OrderBy(c => c.order).FirstOrDefault();
            if (next == null)
            {
                next = db.TANGS.Where(c => c.date_create > this.date_create && c.day_id == day_id).OrderBy(c => c.date_create).FirstOrDefault();
            }
            return next;
        }
        public override void onAfterAdded()
        {
            this.order = DateTimeHelper.toMilisec(date_create);
            base.onAfterAdded();
        }
        #endregion
    }
}
