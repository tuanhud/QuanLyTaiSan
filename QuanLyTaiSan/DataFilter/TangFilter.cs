using PTB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.DataFilter
{
    public class TangFilter : _FilterAbstract<TangFilter>
    {
        public Guid id { get; set; }
        public String ten { get; set; }
        public String ten_coso { get; set; }
        public String ten_day { get; set; }
        public Tang tang { get; set; }

        public static List<TangFilter> getAll()
        {
            return db.TANGS.Select(c => new TangFilter { id = c.id, ten = c.ten, ten_coso = c.day.coso.ten, ten_day = c.day.ten, tang = c }).ToList();
        }
    }
}
