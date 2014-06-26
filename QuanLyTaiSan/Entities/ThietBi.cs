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
        public int loaithietbi_id { get; set; }
        [Required]
        [ForeignKey("loaithietbi_id")]
        public virtual LoaiThietBi loaithietbi { get; set; }

        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
		#endregion
		#region Override method
        public override int delete(Boolean auto_remove_fk=false)
        {
            if (!auto_remove_fk)
            {
                //Kiểm tra khi xóa thì có dính CASCADE hay không, nếu có thì báo lỗi, không thì gọi base.delete
                
            }
            return base.delete();
        }
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
            this.logthietbis = new List<LogThietBi>();
        }
        #endregion
    }
}
