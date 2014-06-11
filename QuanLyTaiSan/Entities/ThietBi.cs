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
            this.ctthietbis = new List<CTThietBi>();
        }
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
    }
}
