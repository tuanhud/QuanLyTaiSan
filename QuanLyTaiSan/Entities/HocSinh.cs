using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class HocSinh
    {
        public HocSinh(String name)
        {
            this.name = name;
        }
        [Key]
        public int HocSinhId {get;set;}
        public String name {get;set;}
        public virtual Lop lop {get;set;}
    }
}
