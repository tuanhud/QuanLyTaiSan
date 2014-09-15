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
        private bool hasROOTAccess()
        {
            return isRoot() || permissions.Where(c => c.key.ToUpper().Equals(Permission._SUPER_ADMIN.ToUpper())).Count() > 0;
        }
        private bool requestPermission<T>(T __obj, Boolean require_baoham = false, String action = "view") where T: new()
        {
            //Xét quyền từ cao đến thấp (từ ưu tiên cao hơn xuống ưu tiên thấp hơn)
            //Quyền ROOT
            if (hasROOTAccess())
            {
                return true;
            }
            Boolean re = false;
            Boolean needed_release_memory = false;   
            IEnumerable<Permission> query = permissions;
            
            /*
             * Xét quyền deny
             */
            //...
            /*
             * Xét quyền allow
             */
            //root common criteria
            query = query.Where(
                    c => c.allow_or_deny
                    &&
                    (
                        (action.Equals("edit") && c.can_edit)
                        ||
                        (action.Equals("view") && c.can_view)
                        ||
                        (action.Equals("delete") && c.can_delete)
                    )
            );
            //đang xét quyền cat_wide
            if (__obj == null)
            {
                //Type type = typeof(T).GetType();
                ////common criteria
                query = query.Where(
                    c =>
                        c.stand_alone
                );

                //if (type == typeof(CoSo).GetType())
                //{
                //    query = query.Where(c=>c.key.ToUpper().Equals(CoSo.USNAME));
                //}
                //else if (type == typeof(Dayy).GetType())
                //{
                //    query = query.Where(c => c.key.ToUpper().Equals(Dayy.USNAME));
                //}
                //else if (type == typeof(Tang).GetType())
                //{
                //    query = query.Where(c => c.key.ToUpper().Equals(Tang.USNAME));
                //}
                //else if (type == typeof(Phong).GetType())
                //{
                //    query = query.Where(c => c.key.ToUpper().Equals(Phong.USNAME));
                //}
                ////for other object


                //re = query.Count() > 0;
                ////final
                //goto done;
                __obj = new T();
                needed_release_memory = true;
                //override require_baoham
                require_baoham = false;
            }
            //đang xét quyền object_combined
            //common criteria
            query = query.Where(
                c=>
                    (!require_baoham || (require_baoham && c.recursive_to_child))
            );

            //specific object type
            if (__obj is CoSo)
            {
                var obj = __obj as CoSo;
                //Quyền Edit trên mọi Cơ sở hoặc trên CS này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(CoSo.USNAME)
                        &&
                        (
                            c.stand_alone
                            ||
                            (!c.stand_alone && c.cosos.Count > 0 && c.cosos.Select(m=>m.id).Contains(obj.id))
                        )
                ).Count() > 0;
            }
            else if (__obj is Dayy)
            {
                var obj = __obj as Dayy;

                //Quyền edit CS chứa dãy này
                re = requestPermission<CoSo>(obj.coso, true, action);
                if (re)
                {
                    goto done;
                }
                //Quyền edit dãy này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(Dayy.USNAME)
                        &&
                        (
                            c.stand_alone
                            ||    
                            (!c.stand_alone && c.days.Count > 0 && c.days.Select(m => m.id).Contains(obj.id))
                        )
                ).Count() > 0;
            }
            else if (__obj is Tang)
            {
                var obj = __obj as Tang;
                //Quyền ROOT
                if (obj.day != null)
                {
                    //Quyền edit CS chứa dãy chứa tầng này
                    re = requestPermission<CoSo>(obj.day.coso, true, action);
                    if (re)
                    {
                        goto done;
                    }
                }
                
                //Quyền edit dãy chưa tầng này
                re = requestPermission<Dayy>(obj.day, true, action);
                if (re)
                {
                    goto done;
                }
                //Quyền edit tầng này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(Tang.USNAME)
                        &&
                        (
                            c.stand_alone
                            ||
                            (!c.stand_alone && c.tangs.Count > 0 && c.tangs.Select(m => m.id).Contains(obj.id))
                        )
                ).Count() > 0;
            }
            else if (__obj is Phong)
            {
                var obj = __obj as Phong;
                //Quyền ROOT
                if (obj.vitri != null)
                {
                    //Quyền edit CS chứa phòng này
                    re = requestPermission<CoSo>(obj.vitri.coso, true, action);
                    if (re)
                    {
                        goto done;
                    }
                    //Quyền edit dãy chứa phòng này

                    re = requestPermission<Dayy>(obj.vitri.day, true, action);
                    if (re)
                    {
                        goto done;
                    }
                    //Quyền edit tầng chứa phòng này
                    re = requestPermission<Tang>(obj.vitri.tang, true, action);
                    if (re)
                    {
                        goto done;
                    }
                }

                //Quyền edit phòng này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(Phong.USNAME)
                        &&
                        (
                            c.stand_alone
                            ||
                            (!c.stand_alone && c.phongs.Count > 0 && c.phongs.Select(m => m.id).Contains(obj.id))
                        )
                ).Count() > 0;
        }
        else if (__obj is LoaiThietBi)
        {
            //Quyền edit LTB này
            re = query.Where(
                c =>
                    c.key.ToUpper().Equals(LoaiThietBi.USNAME)
                    &&
                    (
                        c.stand_alone
                    )
            ).Count() > 0;
        }
            else if (__obj is NhanVienPT)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(NhanVienPT.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is SuCoPhong)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(SuCoPhong.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is ThietBi)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(ThietBi.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is Group)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(Group.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is QuanTriVien)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(QuanTriVien.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is PhieuMuonPhong)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(PhieuMuonPhong.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }
            else if (__obj is TinhTrang)
            {
                //Quyền edit LTB này
                re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(TinhTrang.USNAME)
                        &&
                        (
                            c.stand_alone
                        )
                ).Count() > 0;
            }

        //quocdunginfo, xu ly cac class khác: ThietBi,...
        //...
        //final 
        done:
            //release memory if needed
            if (needed_release_memory)
            {
                __obj = default(T);
            }
            return re;
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="__obj"></param>
        /// <param name="require_baoham">Bắt buộc recursive_to_child == true</param>
        /// <returns></returns>
        public bool canEdit<T>(T __obj) where T:_EntityAbstract1<T>,new()
        {
            return requestPermission<T>(__obj, false, "edit");
        }

        public bool canView<T>(T __obj) where T : _EntityAbstract1<T>, new()
        {
            return requestPermission<T>(__obj, false, "view");
        }
        public bool canDelete<T>(T __obj) where T : _EntityAbstract1<T>, new()
        {
            return requestPermission<T>(__obj, false, "delete");
        }
        public bool canAdd<T>(Boolean require_baoham=false) where T : _EntityAbstract1<T>, new()
        {
            //ROOT check
            if (hasROOTAccess())
            {
                return true;
            }
            Type t = typeof(T);
            Boolean re = false;
            
            //common
            IEnumerable<Permission> query = permissions;
            query = query.Where(
                c=>
                    c.stand_alone
                    &&
                    c.can_add
                    &&
                    (!require_baoham || (require_baoham && c.recursive_to_child))
            );
            //get USNAME
            String tmp = "";
            if (t==typeof(CoSo))
            {
                tmp = CoSo.USNAME;
            }
            else if (t == typeof(Dayy))
            {
                //re = canAdd<CoSo>(true);
                //if (re)
                //{
                //    goto done;
                //}
                tmp = Dayy.USNAME;
            }
            else if (t == typeof(Tang))
            {
                //re = canAdd<CoSo>(true);
                //if (re)
                //{
                //    goto done;
                //}
                //re = canAdd<Dayy>(true);
                //if (re)
                //{
                //    goto done;
                //}
                tmp = Tang.USNAME;
            }
            else if (t == typeof(Phong))
            {
                //re = canAdd<CoSo>(true);
                //if (re)
                //{
                //    goto done;
                //}
                //re = canAdd<Dayy>(true);
                //if (re)
                //{
                //    goto done;
                //}
                //re = canAdd<Tang>(true);
                //if (re)
                //{
                //    goto done;
                //}
                tmp = Phong.USNAME;
            }
            else if (t == typeof(LoaiThietBi))
            {
                tmp = LoaiThietBi.USNAME;
            }
            else if (t == typeof(NhanVienPT))
            {
                tmp = NhanVienPT.USNAME;
            }
            else if (t == typeof(SuCoPhong))
            {
                tmp = SuCoPhong.USNAME;
            }
            else if (t == typeof(ThietBi))
            {
                tmp = ThietBi.USNAME;
            }
            else if (t == typeof(Group))
            {
                tmp = Group.USNAME;
            }
            else if (t == typeof(QuanTriVien))
            {
                tmp = QuanTriVien.USNAME;
            }
            else if (t == typeof(PhieuMuonPhong))
            {
                tmp = PhieuMuonPhong.USNAME;
            }
            else if (t == typeof(TinhTrang))
            {
                tmp = TinhTrang.USNAME;
            }
            //check usname vs key
            re = query.Where(
                    c =>
                        c.key.ToUpper().Equals(tmp.ToUpper())
                    ).Count() > 0;
            //done:
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
            if (hasROOTAccess())
            {
                return true;
            }

            return permissions.Where(
                c=>
                    c.key.ToUpper().Equals(stand_alone_permission.ToUpper())
                    &&
                    c.allow_or_deny
                    &&
                    c.stand_alone
            ).Count() > 0;
        }
        
        #endregion
        #region Override method
        public override string niceName()
        {
            return "Group: " + ten;
        }
        public override void onBeforeDeleted()
        {
            //Group tmp = db.GROUPS.AsNoTracking().Where(c => c.id == this.id).FirstOrDefault();
            if(isRoot())
            {
                throw new Exception("Không thể xóa group \"root\"");
            }
            base.onBeforeDeleted();
        }
        public override int update()
        {
            if (isRoot())
            {
                return -1;
            }
            return base.update();
        }

        private bool isRoot()
        {
            return ten.ToLower().Equals("root");
        }
        public override int delete()
        {
            //Không thể xóa group root
            if (isRoot())
            {
                return -1;
            }
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
        public static new IQueryable<Group> getQuery()
        {
            try
            {
                db.GROUPS.AsQueryable().FirstOrDefault();
                //Ẩn ROOT
                return db.GROUPS.Where(c => !c.ten.ToLower().Equals("root")).AsQueryable();
            }
            catch (Exception)
            {
                return new List<Group>().AsQueryable();
            }
        }
        public static new List<Group> getAll()
        {
            return db.GROUPS.Where(c => !c.ten.ToLower().Equals("root")).ToList();
        }
        #endregion

        
    }
}
