using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyTaiSan.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("LOAITHIETBIS")]
    public class LoaiThietBi : _EntityAbstract1<LoaiThietBi>
    {
        public LoaiThietBi() : base()
        {
            
        }
        #region Dinh nghia
        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }

        public Boolean loaichung { get; set; }
        /*
         * FK
         */
        public virtual ICollection<ThietBi> thietbis { get; set; }

        public Guid? parent_id { get; set; }
        [ForeignKey("parent_id")]
        public virtual LoaiThietBi parent { get; set; }

        public virtual ICollection<LoaiThietBi> childs { get; set; }
        #endregion
        #region Nghiep vu
        public static List<LoaiThietBi> getAllParent()
        {
            try
            {
                List<LoaiThietBi> objs = db.Set<LoaiThietBi>().Where(c => c.parent_id == null).ToList();
                return objs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<LoaiThietBi>();
            }
            finally
            {

            }
        }

        public static List<LoaiThietBi> getTheoLoai(Boolean loai)
        {
            try
            {
                List<LoaiThietBi> objs = db.Set<LoaiThietBi>().Where(c => c.loaichung == loai).ToList();
                return objs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<LoaiThietBi>();
            }
            finally
            {

            }
        }
        #endregion
        #region Override method
        public override void moveUp()
        {
            LoaiThietBi prev = db.LOAITHIETBIS.Where(c => c.order < this.order && c.parent_id == this.parent_id).OrderByDescending(c => c.order).FirstOrDefault();
            if (prev == null)
            {
                return;
            }
            //SWAP order value
            //int? order_1 = this.order == null ? this.id : this.order;
            //int? order_2 = prev.order == null ? prev.id : prev.order;

            //this.order = order_2;
            //prev.order = order_1;

            this.update();
            prev.update();
        }
        public override void moveDown()
        {
            LoaiThietBi next = db.LOAITHIETBIS.Where(c => c.order > this.order && c.parent_id == this.parent_id).OrderBy(c => c.order).FirstOrDefault();
            if (next == null)
            {
                return;
            }
            next.moveUp();
        }
        public override int delete()
        {
            if (thietbis.Count > 0 || childs.Count>0)
            {
                return -1;
            }
            return base.delete();
        }
        protected override void init()
        {
            base.init();
            this.childs = new List<LoaiThietBi>();
            this.thietbis = new List<ThietBi>();
        }
        public override int update()
        {
            //have to load all [Required] FK object first
            if (parent != null)
            {
                parent.trigger();
            }
            //...

            return base.update();
        }
        #endregion
    }
}
