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
    [Table("NHANVIENPTS")]
    public class NhanVienPT : _EntityAbstract1<NhanVienPT>
    {
        public NhanVienPT():base()
        {
            
        }
        public NhanVienPT(MyDB db)
            : base(db)
        {
            
        }
        protected override void init()
        {
            base.init();
            phongs = new List<Phong>();
        }
        public String subId { get; set; }
        [Required]
        public String hoten { get; set; }
        public String sodienthoai { get; set; }
        /*
         * Ngay record insert vao he thong 
         */
        public DateTime? date_create { get; set; }
        /*
         * Ngay update gan day nhat
         */
        public DateTime? date_modified { get; set; }
        /*
         * FK 
         */
        public virtual ICollection<Phong> phongs { get; set; }
        public virtual ICollection<HinhAnh> hinhanhs { get; set; }
    }
}
