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
    [Table("THIETBIS")]
    public class ThietBi:_EntityAbstract2<ThietBi>
    {
        public ThietBi():base()
        {
           
        }
        //public ThietBi(MyDB db)
        //    : base(db)
        //{
            
        //}
        
		#region Dinh nghia
        /*
         * Ngày mua
         */
        public DateTime? ngaymua { get; set; }
        /*
         * Ngày đưa vào sử dụng, ngày lắp
         */
        public DateTime? ngaylap { get; set; }
        /*
         * FK
         */
        public virtual LoaiThietBi loaithietbi { get; set; }
        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
		#endregion
		#region Override method
        public override int update()
        {
            //have to load all [Required] FK object first
            if (loaithietbi != null)
            {
                loaithietbi.trigger();
            }
            
            //...
            return base.update();
        }
        protected override void init()
        {
            base.init();
            this.ctthietbis = new List<CTThietBi>();
        }
        #endregion
    }
}
