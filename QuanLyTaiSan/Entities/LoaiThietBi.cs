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
    [Table("LOAITHIETBIS")]
    public class LoaiThietBi : _EntityAbstract1<LoaiThietBi>
    {
        public LoaiThietBi() : base()
        {
            
        }
        public LoaiThietBi(MyDB db)
            : base(db)
        {
            
        }
        protected override void init()
        {
            base.init();
            this.childs = new List<LoaiThietBi>();
            this.thietbis = new List<ThietBi>();
        }
        
        public String ten { get; set; }
        public String mota { get; set; }
        public Boolean loaichung { get; set; }
        /*
         * Ngay record insert vao he thong 
         */
        public DateTime date_create { get; set; }
        /*
         * Ngay update gan day nhat
         */
        public DateTime date_modified { get; set; }
        /*
         * FK
         */
        public virtual ICollection<ThietBi> thietbis { get; set; }

        public int? parent_id { get; set; }
        public virtual LoaiThietBi parent { get; set; }
        public virtual ICollection<LoaiThietBi> childs { get; set; }
    }
}
