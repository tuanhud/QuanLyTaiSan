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
    public class DonViTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(20)]
        public String key { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String ten { get; set; }
        /*
         * FK
         */
        public virtual ICollection<GiaTri> giatris { get; set; }
    }
}
