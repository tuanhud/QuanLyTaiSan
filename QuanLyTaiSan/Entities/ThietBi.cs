using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class ThietBi:_EntityAbstract<ThietBi>
    {
        public DateTime ngaymua { get; set; }
        public DateTime ngaylap { get; set; }
        /*
         * Donvi: Thang
         */
        public virtual int baohanh { get; set; }
        public virtual GiaTri giatri { get; set; }
    }
}
