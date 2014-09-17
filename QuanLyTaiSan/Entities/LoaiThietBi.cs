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
using SHARED;
using SHARED.Libraries;

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
        /// <summary>
        /// Lấy tất cả Loại thiết bị trực thuộc dưới ROOT (parent==null)
        /// </summary>
        /// <returns></returns>
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
        #endregion
        #region Override method
        public static new String VNNAME
        {
            get
            {
                return "LOẠI THIẾT BỊ";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten;
        }

        public override LoaiThietBi prevObj()
        {
            try
            {
                LoaiThietBi prev = null;
                prev = db.LOAITHIETBIS.Where(c => c.order < this.order && c.parent_id == parent_id).OrderByDescending(c => c.order).FirstOrDefault();
                if (prev == null)
                {
                    prev = db.LOAITHIETBIS.Where(c => c.date_create < this.date_create && c.parent_id == parent_id).OrderByDescending(c => c.date_create).FirstOrDefault();
                }
                return prev;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        public override LoaiThietBi nextObj()
        {
            try
            {
                LoaiThietBi next = null;
                next = db.LOAITHIETBIS.Where(c => c.order > this.order && c.parent_id == parent_id).OrderBy(c => c.order).FirstOrDefault();
                if (next == null)
                {
                    next = db.LOAITHIETBIS.Where(c => c.date_create > this.date_create && c.parent_id == parent_id).OrderBy(c => c.date_create).FirstOrDefault();
                }
                return next;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public override int delete()
        {
            if (thietbis.Count > 0 || childs.Count>0)
            {
                return -1;
            }
            return base.delete();
        }
        public override void onAfterAdded()
        {
            this.order = DateTimeHelper.toMilisec(date_create);
            base.onAfterAdded();
        }
        protected override void init()
        {
            base.init();
            this.childs = new List<LoaiThietBi>();
            this.thietbis = new List<ThietBi>();
        }
        public override int update()
        {
            
            return base.update();
        }
        #endregion
    }
}
