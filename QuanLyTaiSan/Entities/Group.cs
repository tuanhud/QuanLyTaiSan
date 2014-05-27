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
    public class Group
    {
        public Group()
        {
            this.permissions = new List<Permission>();
            this.nhanviens = new List<NhanVien>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String ten { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Permission> permissions { get; set; }
        public virtual ICollection<NhanVien> nhanviens { get; set; }
        /*
         * Manual method
         */
        public Boolean isHasPermission(Permission obj)
        {
            return obj.isInGroup(this);
        }
    }
}
