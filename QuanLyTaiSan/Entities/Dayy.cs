using QuanLyTaiSan.Libraries;
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
    [Table("DAYS")]
    public class Dayy:_EntityAbstract2<Dayy>
    {
        public Dayy():base()
        {
            
        }
        
        
		#region Dinh nghia

        [Required]
        public String ten { get; set; }
        /*
         * FK
         */
        public Guid coso_id { get; set; }
        [Required]
        [ForeignKey("coso_id")]
        public virtual CoSo coso { get; set; }
        public virtual ICollection<Tang> tangs { get; set; }
        public virtual ICollection<ViTri> vitris { get; set; }

        public virtual ICollection<Permission> permissions { get; set; }
		#endregion
		
		#region Override method
        public override string niceName()
        {
            return "Dãy: " + ten + ", " + coso.niceName();
        }

        /// <summary>
        /// -2: dính phòng, -3: dính tầng
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            //Nếu có ít nhất 1 phòng sử dụng vị trí chứa dãy này thì KHÔNG cho xóa
            if (vitris.Where(c => c.phongs.Count > 0).FirstOrDefault() != null)
            {
                return -2;
            }
            //Kiểm tra có tầng KHÔNG cho xóa
            if (tangs.Count>0)
            {
                return -3;
            }
            //======================================================
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
        protected override void init()
        {
            base.init();
            vitris = new List<ViTri>();
            tangs = new List<Tang>();
        }
        public override int update()
        {
            //have to load all [Required] FK object first
            if (coso != null)
            {
                coso.trigger();
            }
            
            //...
            return base.update();
        }
        public override Dayy prevObj()
        {
            Dayy prev = null;
            prev = db.DAYYS.Where(c => c.order < this.order && c.coso_id == coso_id).OrderByDescending(c => c.order).FirstOrDefault();
            if (prev == null)
            {
                prev = db.DAYYS.Where(c => c.date_create < this.date_create && c.coso_id == coso_id).OrderByDescending(c => c.date_create).FirstOrDefault();
            }
            return prev;
        }
        public override Dayy nextObj()
        {
            Dayy next = null;
            next = db.DAYYS.Where(c => c.order > this.order && c.coso_id == coso_id).OrderBy(c => c.order).FirstOrDefault();
            if (next == null)
            {
                next = db.DAYYS.Where(c => c.date_create > this.date_create && c.coso_id == coso_id).OrderBy(c => c.date_create).FirstOrDefault();
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
