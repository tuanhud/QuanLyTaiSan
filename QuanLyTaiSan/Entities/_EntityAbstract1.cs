using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using SHARED;
using SHARED.Interface;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    /// <summary>
    /// Định nghĩa cơ bản mà mọi Entity phải có
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class _EntityAbstract1<T> : _EFEventRegisterInterface, _CRUDInterface<T> where T : _EntityAbstract1<T>
    {
        public _EntityAbstract1()
        {
            //Need to find out another approach, reporting by code analysized
            //it will call TOP level first
            init();
        }
        #region Định nghĩa
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public String subId { get; set; }

        /// <summary>
        /// Dùng để sắp xếp, mặc định khi thêm mới thì sẽ bật trigger để tự lấy id qua
        /// </summary>
        public long? order { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public String mota { get; set; }
        /// <summary>
        /// Ngay record insert vao he thong
        /// Optional
        /// </summary>
        public DateTime? date_create { get; set; }
        /// <summary>
        /// Ngay record updated gan day nhat
        /// Optional
        /// </summary>
        public DateTime? date_modified { get; set; }
        #endregion
        
        #region Nghiệp vụ
        protected virtual void init()
        {
            
        }
        /*
         * Method of interface
         */
        [NotMapped]
        protected static OurDBContext db
        {
            get
            {
                return DBInstance.DB;
            }
        }
        /// <summary>
        /// Tự động add nếu chưa có trong CSDL
        /// </summary>
        /// <returns></returns>
        public virtual int add()
        {
            //Nếu đã có trong CSDL rồi
            if (id != Guid.Empty)
            {
                return 1;
            }

            try
            {
                //script
                db.Set<T>().Add((T)this);
                //db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                //db.Set<T>().Remove((T)this);//remove if fail
                return -1;
            }
        }

        public virtual int update()
        {
            //Nếu chưa có trong CSDL
            if (id == Guid.Empty)
            {
                return -1;
            }

            try
            {
                //have to use if autodetectchange off
                //db.Entry(this).State = EntityState.Modified;
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }

        public virtual int delete()
        {
            //Nếu chưa có trong CSDL
            if (id == Guid.Empty)
            {
                return -1;
            }

            try
            {
                db.Set<T>().Remove((T)this);
                
                //END
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                //nếu bị lỗi thì Attach lại, để không bị mất khóa ngoại, cháu chắt
                db.Set<T>().Attach((T)this);
                return -1;
            }
        }
        public static T getById(Guid id)
        {
            try
            {
                return db.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }
        /// <summary>
        /// Có thể query trên danh sách sau đó mới trả về List,
        /// Sẽ nhanh hơn nhiều so với getAll,
        /// Có thể quăng Exception do mất kết nối tới Database (Cần tìm phương án khắc phục)
        /// </summary>
        /// <returns></returns>
        public static IQueryable<T> getQuery()
        {
            //if (db.Database.Connection.State == ConnectionState.Broken ||
            //    db.Database.Connection.State == ConnectionState.Closed
            //    )
            //{
            //    return new List<T>().AsQueryable<T>();
            //}
            try
            {
                db.Set<T>().AsQueryable().FirstOrDefault();
                return db.Set<T>().AsQueryable<T>();
            }
            catch (Exception)
            {
                return new List<T>().AsQueryable<T>();
            }
        }
        /// <summary>
        /// Sử dụng để đổ DataSource nhanh,
        /// Muốn query được thì nên sử dụng getQuery sẽ nhanh hơn
        /// </summary>
        /// <returns></returns>
        public static List<T> getAll()
        {
            try
            {
                return db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<T>();
            }
        }
        /// <summary>
        /// Clone nguyên list ra list mới, giữ nguyên khóa ngoại
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> clone(List<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return new List<T>();
            }
            List<T> tmp = new List<T>();
            foreach (T item in list)
            {
                tmp.Add(item.clone());
            }
            return tmp;
        }
        /// <summary>
        /// Load lại Object theo DBContext mới trong DBInstance (Vì có thể đã bị new mới bởi ai đó)
        /// Cần có id trước
        /// </summary>
        /// <returns></returns>
        public virtual T reload()
        {
            //if (id != Guid.Empty)
            //{
            //    try
            //    {
            //       db.Entry(this).Reload();
            //       return (T)this;
            //    }
            //    catch (Exception)
            //    {
            //        return db.Set<T>().Find(id);
            //    }
            //}
            //return (T)this;

            if (id == Guid.Empty)
            {
                return (T)this;
            }

            try
            {
                //if (db.Entry(this).State == EntityState.Detached)
                //{
                    db.Set<T>().Attach((T)this);
                    //return (T)this;
                //}
                return (T)this;
            }
            catch (Exception)
            {
                try
                {
                    db.Entry(this).Reload();
                    return (T)this;
                }
                catch (Exception)
                {
                    try
                    {
                        //Case 1: Multi db context tracking
                        //Case 2: Object not loaded before
                        return db.Set<T>().Find(this.id);
                    }
                    catch (Exception exx)
                    {
                        //for any other error
                        Debug.WriteLine(exx.ToString());
                        return (T)this;
                    }
                }
            }
        }
        /// <summary>
        /// Force to load object because of Lazy Loading,
        /// Have to use when call update procedure or you
        /// got Validation Excaption
        /// 
        /// </summary>
        public void trigger()
        {
            //DO NOT THING, JUST ACTIVATE ENTITY FRAMEWORK TO LOAD
        }
        public static List<T> convert(Guid[] id_array)
        {
            return convert(id_array.ToList());
        }
        public static List<T> convert(List<Guid> id_array)
        {
            List<T> re = new List<T>();
            foreach (Guid item in id_array)
            {
                T tmp = getById(item);
                if (tmp != null)
                {
                    re.Add(tmp);
                }
            }
            return re;
        }
        /// <summary>
        /// Clone to new Object
        /// </summary>
        /// <returns></returns>
        public virtual T clone()
        {
            //T tmp = db.Set<T>().AsNoTracking<T>().Where(c => c.id == this.id).FirstOrDefault();
            //if (tmp == null)
            //{
            //    return null;
            //}
            //tmp.id = 0;
            //return tmp;
            return null;
        }
        public virtual T prevObj()
        {
            try
            {
                T prev = null;
                prev = db.Set<T>().Where(c => c.order < this.order).OrderByDescending(c => c.order).FirstOrDefault();
                if (prev == null)
                {
                    prev = db.Set<T>().Where(c => c.date_create < this.date_create).OrderByDescending(c => c.date_create).FirstOrDefault();
                }

                return prev;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual T nextObj()
        {
            try
            {
                T next = db.Set<T>().Where(c => c.order > this.order).OrderBy(c => c.order).FirstOrDefault();
                if (next == null)
                {
                    next = db.Set<T>().Where(c => c.date_create > this.date_create).OrderBy(c => c.date_create).FirstOrDefault();
                }

                return next;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Move object lên 1 nấc (sử dụng trường order),
        /// Tự động update
        /// </summary>
        public virtual void moveUp()
        {
            try
            {
                T prev = prevObj();
                if (prev == null)
                {
                    return;
                }
                //SWAP order value
                long? order_1 = this.order == null ? DateTimeHelper.toMilisec(date_create) : this.order;
                long? order_2 = prev.order == null ? DateTimeHelper.toMilisec(prev.date_create) : prev.order;

                this.order = order_2;
                prev.order = order_1;

                this.update();
                prev.update();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Move object xuống 1 nấc (sử dụng trường order),
        /// Tự động update
        /// </summary>
        public virtual void moveDown()
        {
            T next = nextObj();
            if (next == null)
            {
                return;
            }

            next.moveUp();
        }
        /// <summary>
        /// Build log hệ thống cho this
        /// </summary>
        /// <param name="action_name"></param>
        /// <returns></returns>
        private Dictionary<string, string> buildLog(String action_name=null)
        {
            Dictionary<string, string> re = new Dictionary<string, string>();
            try
            {
                if (Global.current_quantrivien_login != null)
                {
                    re.Add("actor", Global.current_quantrivien_login.niceName());
                }
                else
                {
                    re.Add("actor", "unknown");
                }

                if (action_name != null)
                {
                    re.Add("action", action_name);
                }
                else
                {
                    re.Add("action", "unknown");
                }
                //quocdunginfo fail .niceName()
                //Gay loi validation ERROR

                if (action_name.Equals("delete"))
                {
                    T tmp = db.Set<T>().AsNoTracking().Where(c => c.id == this.id).FirstOrDefault();
                    if (tmp != null)
                    {
                        re.Add("obj", tmp.niceName());
                        tmp = null;
                    }
                }
                else
                {
                    re.Add("obj", this.niceName());
                }

                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                re.Add("State: ", "ERROR");
                return re;
            }
        }
        #endregion
        
        #region Event register
        /// <summary>
        /// Kiểm tra Entity type hiện tại có cần phải ghi log ?
        /// </summary>
        /// <returns></returns>
        private Boolean needToWriteLogHeThong()
        {
            //DO NOT WRITE LOG FOR LOGHETHONG (LOOPBACK!)
            return (
                //PHONG~TB
                this is CoSo
                || this is Dayy
                || this is Tang
                || this is CTThietBi
                || this is PhieuMuonPhong
                || this is ThietBi
                || this is QuanTriVien
                || this is Group
                || this is LoaiThietBi
                || this is NhanVienPT
                || this is Phong
                || this is Setting
                || this is SuCoPhong
                || this is TinhTrang
                );
        }
        /// <summary>
        /// Chạy nghiệp vụ trước khi bị xóa
        /// </summary>
        public virtual void onBeforeDeleted()
        {
            //DO NOT WRITE LOG FOR LOGHETHONG (LOOPBACK!)
            if (needToWriteLogHeThong())
            {
                LogHeThong log = new LogHeThong();
                log.onBeforeAdded();
                //quocdunginfo fail (conflict with write log hethong)
                log.mota = StringHelper.toJSON(buildLog("delete"));
                log.add();
            }
        }
        /// <summary>
        /// Chạy nghiệp vụ trước khi được cập nhật vào CSDL
        /// </summary>
        public virtual void onBeforeUpdated()
        {
            date_modified = ServerTimeHelper.getNow();
        }
        /// <summary>
        /// Chạy nghiệp vụ trước khi được thêm vào CSDL
        /// </summary>
        public virtual void onBeforeAdded()
        {
            //time
            date_create = date_modified = (date_create == null) ? ServerTimeHelper.getNow() : date_create;
        }

        public virtual void onAfterUpdated()
        {
            //DO NOT WRITE LOG FOR LOGHETHONG (LOOPBACK!)
            if (needToWriteLogHeThong())
            {
                LogHeThong log = new LogHeThong();
                log.onBeforeAdded();//MANUAL MODE
                log.mota = StringHelper.toJSON(buildLog("edit"));
                log.add();
            }
        }

        public virtual void onAfterAdded()
        {
            //LOGHETHONG
            //DO NOT WRITE LOG FOR LOGHETHONG (LOOPBACK!)
            if (needToWriteLogHeThong())
            {
                LogHeThong log = new LogHeThong();
                log.onBeforeAdded();//MANUAL MODE
                log.mota = StringHelper.toJSON(buildLog("add"));
                log.add();
            }
        }
        #endregion

        /// <summary>
        /// Thông tin cơ bản về đối tượng
        /// </summary>
        /// <returns></returns>
        public virtual string niceName()
        {
            return typeof(T).Name + ": ID=" + this.id;
        }
    }
}
