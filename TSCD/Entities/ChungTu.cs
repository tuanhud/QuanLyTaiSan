using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("CHUNGTUS")]
    public class ChungTu:_EntityAbstract1<ChungTu>
    {
        public ChungTu()
        {

        }
        public String sohieu { get; set; }
        public DateTime? ngay { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Attachment> attachments { get; set; }
    }
}
