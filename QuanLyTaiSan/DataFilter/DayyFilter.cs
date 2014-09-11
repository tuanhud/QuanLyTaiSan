using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public class DayyFilter:_FilterAbstract<DayyFilter>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String ten_coso { get; set; }
        public Dayy day { get; set; }

        public static List<DayyFilter> getAll()
        {
            return db.DAYYS.Select(c => new DayyFilter{id=c.id, ten = c.ten, ten_coso = c.coso.ten, day = c}).ToList();
        }
    }
}
