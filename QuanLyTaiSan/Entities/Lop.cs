using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class Lop
    {
        public Lop(String name)
        {
            this.name = name;
            this.hocsinhs = new List<HocSinh>();
        }
        [Key]
        public int LopId {get;set;}
        public String name { get; set; }
        public virtual ICollection<HocSinh> hocsinhs {get; set;}
    }
}
