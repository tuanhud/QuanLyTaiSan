using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    [Table("ATTACHMENTS")]
    public class Attachment:_EntityAbstract1<Attachment>
    {
        public Attachment()
        {

        }
        /// <summary>
        /// relativepath
        /// </summary>
        public String path { get; set; }
        /// <summary>
        /// in KB
        /// </summary>
        public int size { get; set; }
        public virtual ICollection<ChungTu> chungtus { get; set; }
    }
}
