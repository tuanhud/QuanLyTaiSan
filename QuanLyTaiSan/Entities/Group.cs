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
        private bool requestPermission<T>(T __obj, Boolean require_baoham = false, String permission = "view")
        {
            Boolean re = false;
            if (__obj == null)
            {
                goto done;
            }
            //Xét quyền từ cao đến thấp (từ ưu tiên cao hơn xuống ưu tiên thấp hơn)
            //Quyền ROOT
            if (permissions.Where(c => c.key.ToUpper().Equals("ROOT")).Count() > 0)
            {
                goto done;
            }
            //Quyền trên Object hoặc Fixed
            if (__obj is CoSo)
            {
                var obj = __obj as CoSo;

                //Quyền Edit trên mọi Cơ sở hoặc trên CS này
                re = permissions.Where(
                    c =>
                        c.allow_or_deny == true
                        &&
                        !require_baoham || (require_baoham && c.recursive_to_child)
                        &&
                        c.key.ToUpper().Equals(CoSo.USNAME)
                        &&
                        (
                            permission.Equals("edit") && c.can_edit == true
                            || permission.Equals("view") && c.can_view == true
                            || permission.Equals("add") && c.can_add == true
                            || permission.Equals("delete") && c.can_delete == true
                        )
                        &&
                            (
                                c.cosos.Count == 0
                                ||
                                c.cosos.Select(t => t.id).Contains(obj.id)
                            )
                        ).Count() > 0;
            }
            else if (__obj is Dayy)
            {
                var obj = __obj as Dayy;

                //Quyền edit CS chứa dãy này
                re = requestPermission<CoSo>((__obj as Dayy).coso,require_baoham, permission);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Dayy.USNAME)
                        &&
                        !require_baoham || (require_baoham && c.recursive_to_child)
                        &&
                        (
                            permission.Equals("edit") && c.can_edit == true
                            || permission.Equals("view") && c.can_view == true
                            || permission.Equals("add") && c.can_add == true
                            || permission.Equals("delete") && c.can_delete == true
                        )
                        &&
                            (
                                c.days.Count == 0
                                ||
                                c.days.Select(t => t.id).Contains(obj.id)
                            )
                        ).Count() > 0;
            }
            else if (__obj is Tang)
            {
                var obj = __obj as Tang;
                //Quyền ROOT

                //Quyền edit CS chứa dãy chứa tầng này
                re = requestPermission<CoSo>((__obj as Tang).day.coso, require_baoham, permission);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy chưa tầng này
                re = requestPermission<Dayy>((__obj as Tang).day, require_baoham, permission);
                if (re)
                {
                    goto done;
                }
                //Quyền edit tầng này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Tang.USNAME)
                        &&
                        !require_baoham || (require_baoham && c.recursive_to_child)
                        &&
                        (
                            permission.Equals("edit") && c.can_edit == true
                            || permission.Equals("view") && c.can_view == true
                            || permission.Equals("add") && c.can_add == true
                            || permission.Equals("delete") && c.can_delete == true
                        )
                        &&
                            (
                                c.tangs.Count == 0
                                ||
                                c.tangs.Select(t => t.id).Contains(obj.id)
                            )
                        ).Count() > 0;
            }
            else if (__obj is Phong)
            {
                var obj = __obj as Phong;
                //Quyền ROOT

                //Quyền edit CS chứa phòng này
                re = requestPermission<CoSo>((__obj as Phong).vitri.coso, require_baoham, permission);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy chứa phòng này

                re = requestPermission<Dayy>((__obj as Phong).vitri.day, require_baoham, permission);
                if (re)
                {
                    goto done;
                }

                //Quyền edit tầng chứa phòng này
                re = requestPermission<Tang>((__obj as Phong).vitri.tang, require_baoham, permission);
                if (re)
                {
                    goto done;
                }

                //Quyền edit phòng này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Phong.USNAME)
                        &&
                        !require_baoham || (require_baoham && c.recursive_to_child)
                        &&
                        (
                            permission.Equals("edit") && c.can_edit == true
                            || permission.Equals("view") && c.can_view == true
                            || permission.Equals("add") && c.can_add == true
                            || permission.Equals("delete") && c.can_delete == true
                        )
                        &&
                            (
                                c.phongs.Count == 0
                                ||
                                c.phongs.Select(t => t.id).Contains(obj.id)
                            )
                        ).Count() > 0;
            }
        //final 
        done:
            return re;
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="__obj"></param>
        /// <param name="require_baoham">Bắt buộc recursive_to_child == true</param>
        /// <returns></returns>
        public bool canEdit<T>(T __obj, Boolean require_baoham = false) where T:_EntityAbstract1<T>
        {
            return requestPermission<T>(__obj, require_baoham, "edit");
        }

        public bool canView<T>(T __obj, Boolean require_baoham = false) where T : _EntityAbstract1<T>
        {
            return requestPermission<T>(__obj, require_baoham, "view");
        }
        public bool canDelete<T>(T __obj, Boolean require_baoham = false) where T : _EntityAbstract1<T>
        {
            return requestPermission<T>(__obj, require_baoham, "delete");
        }
        public bool canAdd<T>() where T : _EntityAbstract1<T>
        {
            Type t = typeof(T).GetType();
            Boolean re = false;
            if (t==typeof(CoSo).GetType())
            {
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(CoSo.USNAME)
                        &&
                        c.can_add == true
                    ).Count() > 0;
            }
            else if (t == typeof(Dayy).GetType())
            {
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Dayy.USNAME)
                        &&
                        c.can_add == true
                    ).Count() > 0;
            }
            else if (t == typeof(Tang).GetType())
            {
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Tang.USNAME)
                        &&
                        c.can_add == true
                    ).Count() > 0;
            }
            else if (t == typeof(Phong).GetType())
            {
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(Phong.USNAME)
                        &&
                        c.can_add == true
                    ).Count() > 0;
            }
            return re;
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
