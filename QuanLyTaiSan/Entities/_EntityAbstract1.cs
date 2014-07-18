using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            init();//it will call TOP level first
        }
        #region Định nghĩa
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public String subId { get; set; }
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
            ////Nếu đã có trong CSDL rồi
            //if (id > 0)
            //{
            //    return id;
            //}

            try
            {
                //script
                db.Set<T>().Add((T)this);
                db.SaveChanges();
                return id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                //db.Set<T>().Remove((T)this);//remove if fail
                return -1;
            }
            finally
            {
                
            }
        }

        public virtual int update()
        {
            //Nếu chưa có trong CSDL
            if (id <= 0)
            {
                return -1;
            }

            try
            {
                //script
                //db.Set<T>().Attach((T)this);
                //Sử dụng EntityState.Modified có thể gây lỗi Validation Error, khi update 1 object mà có [Required] FK object khác, mà FK Object  chưa được load ít nhất 1 lần => Bắt buộc phải load FK Object trước
                //db.Entry(this).State = EntityState.Modified;//importance
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally
            {
                
            }
        }

        public virtual int delete()
        {
            //Nếu chưa có trong CSDL
            if (id <= 0)
            {
                return -1;
            }

            try
            {
                //db.Set<T>().Attach((T)this);//Có thể gây lỗi bị clear list khóa ngoại,...
                db.Set<T>().Remove((T)this);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                db.Set<T>().Attach((T)this);//nếu bị lỗi thì Attach lại, để không bị mất khóa ngoại, cháu chắt
                return -1;
            }
            finally
            {
                
            }
        }
        public static T getById(int id)
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
            finally
            {
                
            }
        }
        /// <summary>
        /// Có thể query trên danh sách sau đó mới trả về List,
        /// Sẽ nhanh hơn nhiều so với getAll
        /// </summary>
        /// <returns></returns>
        public static IQueryable<T> getQuery()
        {
            return db.Set<T>().AsQueryable<T>();
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
                return db.Set<T>().ToList();//.ToList();//return toList là dở vì phải load hết dữ liệu trước
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<T>();
            }
            finally
            {
                
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
            if (id <= 0)
            {
                return null;
            }

            try
            {
                db.Entry((T)this).State = EntityState.Detached;//destroy cached
                T tmp = db.Set<T>().Find(id);
                //very importance (nếu kh có sẽ bị INSERT lại OBJ, chưa hiểu rõ)
                db.Entry<T>(tmp).State = EntityState.Unchanged;
                return tmp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {

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
        public static List<T> convert(int[] id_array)
        {
            return convert(id_array.ToList());
        }
        public static List<T> convert(List<int> id_array)
        {
            List<T> re = new List<T>();
            foreach (int item in id_array)
            {
                T tmp = getById(item);
                if (tmp != null)
                {
                    re.Add(tmp);
                }
            }
            return re;
        }
        #endregion
        /// <summary>
        /// Chạy nghiệp vụ trước khi bị xóa
        /// </summary>
        public virtual void onBeforeDeleted()
        {
            
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
    }
}
