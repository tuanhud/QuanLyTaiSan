using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class Phong:_EntityAbstract<Phong>
    {
        /*
         * FK
         */
        public virtual CoSo coso { get; set; }
        public virtual GiaTri dientich { get; set; }
    }
}
