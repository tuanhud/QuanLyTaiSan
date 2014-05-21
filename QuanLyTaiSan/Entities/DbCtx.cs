using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class DbCtx:DbContext
    {
        public DbCtx()
            : base("Default")
        {
            
        }
        public DbSet<HocSinh> HOCSINHS { get; set; }
        public DbSet<Lop> LOPS { get; set; }
    }
}
