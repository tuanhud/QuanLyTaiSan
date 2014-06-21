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
    [Table("GROUPS")]
    public class Group : _EntityAbstract1<Group>
    {
        public Group():base()
        {
            
        }
        //public Group(MyDB db)
        //    : base(db)
        //{
            
        //}
        #region Dinh nghia

        [StringLength(100)]
        public String key { get; set; } //vd: quantri1

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String ten { get; set; } //vd: Quản trị 1
        public String mota { get; set; }
        /*
         * FK
         */
        public virtual ICollection<Permission> permissions { get; set; }
        public virtual ICollection<QuanTriVien> nhanviens { get; set; }
        #endregion
        #region Nghiệp vụ
        public Boolean isHasPermission(Permission obj)
        {
            return obj.isInGroup(this);
        }
        #endregion
        #region Override method
        protected override void init()
        {
            base.init();
            this.permissions = new List<Permission>();
            this.nhanviens = new List<QuanTriVien>();
        }
        #endregion
    }
}
