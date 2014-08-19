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
            if (__obj is CoSo)
            {
                obj_type = "COSO";
                var obj = __obj as CoSo;
                
                //Quyền Edit trên mọi Cơ sở hoặc trên CS này
                re = permissions.Where(
                    c =>
                        c.allow_or_deny==true
                        &&
                        c.key.ToUpper().Equals(obj_type)
                        &&
                        c.can_edit == true
                        &&
                            (
                                c.cosos.Count==0
                                ||
                                c.cosos.Select(t=>t.id).Contains(obj.id)
                            )
                        ).FirstOrDefault() != null;
            }
            else if(__obj is Dayy)
            {
                obj_type = "DAY";
                var obj = __obj as Dayy;
                
                //Quyền edit CS chứa dãy này
                re = canEdit<CoSo>(obj.coso);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(obj_type)
                        &&
                        c.can_edit == true
                        &&
                            (
                                c.days.Count == 0
                                ||
                                c.days.Select(t => t.id).Contains(obj.id)
                            )
                        ).FirstOrDefault()!=null;
            }
            else if (__obj is Tang)
            {
                obj_type = "TANG";
                var obj = __obj as Tang;
                //Quyền ROOT

                //Quyền edit CS chứa dãy chứa tầng này
                re = canEdit<CoSo>(obj.day.coso);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy chưa tầng này
                re = canEdit<Dayy>(obj.day);
                if (re)
                {
                    goto done;
                }
                //Quyền edit tầng này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(obj_type)
                        &&
                        c.can_edit == true
                        &&
                            (
                                c.tangs.Count == 0
                                ||
                                c.tangs.Select(t => t.id).Contains(obj.id)
                            )
                        ).FirstOrDefault() != null;
            }
            else if (__obj is Phong)
            {
                obj_type = "PHONG";
                var obj = __obj as Phong;
                //Quyền ROOT

                //Quyền edit CS chứa phòng này
                re = canEdit<CoSo>(obj.vitri.coso);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy chứa phòng này
                re = canEdit<Dayy>(obj.vitri.day);
                if (re)
                {
                    goto done;
                }
                //Quyền edit tầng chứa phòng này
                re = canEdit<Tang>(obj.vitri.tang);
                if (re)
                {
                    goto done;
                }

                //Quyền edit phòng này
                re = permissions.Where(
                    c =>
                        c.key.ToUpper().Equals(obj_type)
                        &&
                        c.can_edit == true
                        &&
                            (
                                c.phongs.Count == 0
                                ||
                                c.phongs.Select(t => t.id).Contains(obj.id)
                            )
                        ).FirstOrDefault() != null;
            }
            //final 
            done:
                return re;
        }

        public bool canView<T>(T obj) where T : _EntityAbstract1<T>
        {
            throw new NotImplementedException();
        }
        public bool canDelete<T>(T obj) where T : _EntityAbstract1<T>
        {
            throw new NotImplementedException();
        }
        public bool canAdd<T>() where T : _EntityAbstract1<T>
        {
            throw new NotImplementedException();
        }
        public bool canDo(string fixed_permission)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        #region Override method
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
