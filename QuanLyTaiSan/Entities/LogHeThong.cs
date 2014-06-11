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
    [Table("LOGHETHONGS")]
    public class LogHeThong : _EntityAbstract1<LogHeThong>
    {
        public LogHeThong():base()
        {

        }
        
        [Required]
        public DateTime ngay { get; set; }
        [Required]
        public String mota { get; set; } //vd: { "USER":quocdunginfo, "ACTION":DELETE_USER, "PARAM": nguoibixoa }
    }
}
