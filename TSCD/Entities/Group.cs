using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    [Table("GROUPS")]
    public class Group : _EntityAbstract1<Group>
    {
        public Group():base()
        {
            
        }
        #region Dinh nghia

        [StringLength(100)]
        public String key { get; set; } //vd: quantri1

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String ten { get; set; } //vd: Quản trị 1
        /*
         * FK
         */
        public virtual ICollection<Permission> permissions { get; set; }
        public virtual ICollection<QuanTriVien> quantriviens { get; set; }
        #endregion
        #region Nghiệp vụ
        public bool canEdit<T>(T __obj) where T:_EntityAbstract1<T>
        {
            Boolean re = false;
            if (__obj == null)
            {
                goto done;
            }
            String obj_type = "";
            //Xét quyền từ cao đến thấp (từ ưu tiên cao hơn xuống ưu tiên thấp hơn)
            //Quyền ROOT
            if (permissions.Where(c => c.key.ToUpper().Equals("ROOT")).FirstOrDefault() != null)
            {
                goto done;
            }
            //Quyền trên Object hoặc Fixed
            if (__obj is DonVi)
            {
                obj_type = "DONVI";
                var obj = __obj as DonVi;
                
                //Quyền Edit trên mọi 
                re = permissions.Where(
                    c =>
                        c.allow_or_deny==true
                        &&
                        c.key.ToUpper().Equals(obj_type)
                        &&
                        c.can_edit == true
                        &&
                            (
                                c.donvis.Count==0
                                ||
                                c.donvis.Select(t=>t.id).Contains(obj.id)
                            )
                        ).FirstOrDefault() != null;
            }
            
            //final 
            done:
                return re;
        }

        public bool canView<T>(T obj) where T : _EntityAbstract1<T>
        {
            return true;
            throw new NotImplementedException();
        }
        public bool canDelete<T>(T obj) where T : _EntityAbstract1<T>
        {
            return true;
            throw new NotImplementedException();
        }
        public bool canAdd<T>() where T : _EntityAbstract1<T>
        {
            return true;
            throw new NotImplementedException();
        }
        /// <summary>
        /// Kiểm tra quyền cố định,
        /// Xem Permission._XXXXXX để xem các quyền được định nghĩa
        /// </summary>
        /// <param name="stand_alone_permission"></param>
        /// <returns></returns>
        public bool canDo(string stand_alone_permission)
        {
            return true;
        }
        
        #endregion
        #region Override method
        public override string niceName()
        {
            return "Group: " + ten;
        }
        public override int delete()
        {
            if (quantriviens.Count > 0)
            {
                return -1;
            }
            return base.delete();
        }
        protected override void init()
        {
            base.init();
            this.permissions = new List<Permission>();
            this.quantriviens = new List<QuanTriVien>();
        }
        #endregion
    }
}
