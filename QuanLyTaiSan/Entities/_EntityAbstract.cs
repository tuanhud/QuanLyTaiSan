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
    public class _EntityAbstract<T>
    {
        public _EntityAbstract()
        {
            if (this.date_create == null)
            {
                this.date_create = DateTime.Now;
            }
            if (this.date_modified == null)
            {
                this.date_modified = DateTime.Now;
            }
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String subId { get; set; }
        [Required]
        public String ten { get; set; }
        public String mota { get; set; }
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
        public virtual HinhAnh hinhanh { get; set; }
    }
}
