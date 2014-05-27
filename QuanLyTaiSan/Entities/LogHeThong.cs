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
    public class LogHeThong
    {
        public LogHeThong()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public DateTime datetime { get; set; }
        [Required]
        public String where { get; set; }
        [Required]
        public String action { get; set; }
        public String result { get; set; }
        public String other { get; set; }
    }
}
