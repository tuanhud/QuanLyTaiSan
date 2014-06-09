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
    public class NhanVienPT
    {
        public NhanVienPT()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String subId { get; set; }
        [Required]
        public String hoten { get; set; }
        [Index(IsUnique = true)]
        [StringLength(100)]
        public HinhAnh hinh { get; set; }
        public String sodienthoai { get; set; }
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
        public virtual ICollection<Phong> phongs { get; set; }
    }
}
