using SHARED.Libraries;
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
        private bool isRoot()
        {
            return ten != null && ten.ToLower().Equals("root");
        }
        private bool hasROOTAccess()
        {
            try
            {
                return isRoot() || permissions.Where(c => c.key.ToUpper().Equals(Permission._SUPER_ADMIN.ToUpper())).Count() > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
        private bool requestPermission<T>(T __obj, Boolean require_baoham = false, String action = "view") where T : new()
        {
            //đề phòng rớt mạng bị null object
            try
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
                    ////common criteria
                    query = query.Where(
                        c =>
                            c.stand_alone
                    );
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
                    c =>
                        (!require_baoham || (require_baoham && c.recursive_to_child))
                );

                //specific object type
                if (__obj is DonVi)
                {
                    var obj = __obj as DonVi;
                    //Quyền Edit trên mọi Don vi hoặc trên Don vi này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(DonVi.USNAME)
                            &&
                            (
                                c.stand_alone
                                ||
                                (!c.stand_alone && c.donvis.Count > 0 && c.donvis.Select(m => m.id).Contains(obj.id))
                            )
                    ).Count() > 0;

                    //Quyền edit Don vi chứa Don vi nay
                    if (!re && obj.parent != null)
                    {
                        re = requestPermission<DonVi>(obj.parent, true, action);
                        if (re)
                        {
                            goto done;
                        }
                    }
                }
                else if (__obj is CoSo)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(CoSo.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is Dayy)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(Dayy.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is Tang)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(Tang.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is Phong)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(Phong.USNAME)
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
                else if (__obj is DonViTinh)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(DonViTinh.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is LoaiDonVi)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(LoaiDonVi.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is LoaiPhong)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(LoaiPhong.USNAME)
                            &&
                            (
                                c.stand_alone
                            )
                    ).Count() > 0;
                }
                else if (__obj is LoaiTaiSan)
                {
                    //Quyền edit LTB này
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(LoaiTaiSan.USNAME)
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
                else if (__obj is LogHeThong)
                {
                    re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(LogHeThong.USNAME)
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
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="__obj"></param>
        /// <param name="require_baoham">Bắt buộc recursive_to_child == true</param>
        /// <returns></returns>
        public bool canEdit<T>(T __obj) where T : _EntityAbstract1<T>, new()
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
        public bool canAdd<T>(Boolean require_baoham = false) where T : _EntityAbstract1<T>, new()
        {
            try
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
                    c =>
                        c.stand_alone
                        &&
                        c.can_add
                        &&
                        (!require_baoham || (require_baoham && c.recursive_to_child))
                );
                //get USNAME
                String tmp = "";
                if (t == typeof(CoSo))
                {
                    tmp = CoSo.USNAME;
                }
                else if (t == typeof(Dayy))
                {
                    tmp = Dayy.USNAME;
                }
                else if (t == typeof(Tang))
                {
                    tmp = Tang.USNAME;
                }
                else if (t == typeof(Phong))
                {
                    tmp = Phong.USNAME;
                }
                else if (t == typeof(LoaiTaiSan))
                {
                    tmp = LoaiTaiSan.USNAME;
                }
                else if (t == typeof(LoaiDonVi))
                {
                    tmp = LoaiDonVi.USNAME;
                }
                else if (t == typeof(LoaiPhong))
                {
                    tmp = LoaiPhong.USNAME;
                }
                else if (t == typeof(TinhTrang))
                {
                    tmp = TinhTrang.USNAME;
                }
                else if (t == typeof(TaiSan))
                {
                    tmp = TaiSan.USNAME;
                }
                else if (t == typeof(Group))
                {
                    tmp = Group.USNAME;
                }
                else if (t == typeof(QuanTriVien))
                {
                    tmp = QuanTriVien.USNAME;
                }
                else if (t == typeof(DonViTinh))
                {
                    tmp = DonViTinh.USNAME;
                }
                else if (t == typeof(TinhTrang))
                {
                    tmp = TinhTrang.USNAME;
                }
                else if (t == typeof(LogHeThong))
                {
                    tmp = LogHeThong.USNAME;
                }
                //check usname vs key
                re = query.Where(
                        c =>
                            c.key.ToUpper().Equals(tmp.ToUpper())
                        ).Count() > 0;
                //done:
                return re;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
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
        public static new String VNNAME
        {
            get
            {
                return "GROUP";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten;
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
            try
            {
                return db.GROUPS.Where(c => !c.ten.ToLower().Equals("root")).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<Group>();
            }
        }
        #endregion

        public List<T> getAll<T>(string action) where T : _EntityAbstract1<T>, new()
        {
            var re = new List<T>();
            var source = db.Set<T>().ToList();
            
            if(action.Equals(Permission._VIEW))
            {
                foreach(var item in source)
                {
                    if(canView<T>(item))
                    {
                        re.Add(item);
                    }
                }
            }
            else if (action.Equals(Permission._EDIT))
            {
                foreach (var item in source)
                {
                    if (canEdit<T>(item))
                    {
                        re.Add(item);
                    }
                }
            }
            else if (action.Equals(Permission._DELETE))
            {
                foreach (var item in source)
                {
                    if (canDelete<T>(item))
                    {
                        re.Add(item);
                    }
                }
            }

            return re;
        }
    }
}
