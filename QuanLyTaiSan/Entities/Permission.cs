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
        /// <summary>
        /// COSO, DAY, TANG, PHONG => stand_alone = false,
        /// CONFIG => stand_alone => true
        /// </summary>
        public String key { get; set; }

        /// <summary>
        /// Quyền cố định,
        /// vd: CONFIG, ROOT
        /// </summary>
        public Boolean stand_alone { get; set; }
        /// <summary>
        /// Cấp quyền hay hạn chế quyền,
        /// true: allow,
        /// false: deny
        /// </summary>
        public Boolean allow_or_deny { get; set; }
        
        /// <summary>
        /// Quyền bao hàm cho mọi thứ thuộc obj_id_array
        /// </summary>
        public Boolean recursive_to_child { get; set; }

        /// <summary>
        /// Quyền xem
        /// </summary>
        public Boolean can_view { get; set; }
        /// <summary>
        /// Quyền thêm, sửa, xóa
        /// </summary>
        public Boolean can_edit { get; set; }
        /*
         * FK
         */
        public virtual ICollection<CoSo> cosos { get; set; }
        public virtual ICollection<Dayy> days { get; set; }
        public virtual ICollection<Tang> tangs { get; set; }
        public virtual ICollection<Phong> phongs { get; set; }

        /// <summary>
        /// Các group chứa quyền này
        /// </summary>
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

        public List<T> getObjList<T>()
        {
            return null;
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
