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
    [Table("PERMISSIONS")]
    public class Permission : _EntityAbstract1<Permission>
    {
        public Permission():base()
        {
            
        }
        #region Dinh nghia
        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String key { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Group> groups { get; set; }
        #endregion
        #region Nghiep vu
        /*
         * Manual method
         */
        public Boolean isInGroup(Group obj)
        {
            if(obj==null || obj.permissions==null)
            {
                return false;
            }
            return obj.permissions.Where(c => c.key.ToUpper().Equals(this.key.ToUpper())).FirstOrDefault() != null;
        }
        #endregion

        #region Override
        protected override void init()
        {
            base.init();
            this.groups = new List<Group>();
        }
        #endregion
    }
}
