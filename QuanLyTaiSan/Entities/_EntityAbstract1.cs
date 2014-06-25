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
    /// Chỉ bao gồm định nghĩa về id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class _EntityAbstract1<T> : _CRUDInterface<T> where T : _EntityAbstract1<T>
    {
        public _EntityAbstract1()
        {
            init();//it will call TOP level first
        }
        public _EntityAbstract1(OurDBContext db)
        {
            //this.db = db;
            init();//it will call TOP level first
        }
        #region Định nghĩa
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        #endregion
        
        #region Nghiệp vụ
        protected virtual void init()
        {
            
        }
        /*
         * Method of interface
         */
        [NotMapped]
        protected OurDBContext db
        {
            get
            {
                return DBInstance.DB;
            }
        }
        //[NotMapped]
        //public MyDB DB
        //{
        //    get
        //    {
        //        //initDb();
        //        return db;
        //    }
        //    //set
        //    //{
        //    //    db = value;
        //    //}
        //}

        /// <summary>
        /// Trước khi gọi trực tiếp xuống this.db thì phải gọi
        /// hàm này
        /// </summary>
        //protected void initDb()
        //{
        //    //if (db == null)
        //    //{
        //    //    db = new MyDB();
        //    //}
        //}

        public virtual int add()
        {
            //add
            try
            {
                //initDb();
                db.Set<T>().Add((T)this);
                db.SaveChanges();
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                
            }
        }

        public virtual int update()
        {
            //update
            try
            {
                //initDb();
                db.Set<T>().Attach((T)this);
                //Sử dụng EntityState.Modified có thể gây lỗi Validation Error, khi update 1 object mà có [Required] FK object khác, mà FK Object  chưa được load ít nhất 1 lần => Bắt buộc phải load FK Object trước
                db.Entry(this).State = EntityState.Modified;//importance
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                
            }
        }

        public virtual int delete()
        {
            try
            {
                //initDb();
                db.Set<T>().Attach((T)this);
                db.Set<T>().Remove((T)this);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                
            }
        }
        public virtual T getById(int id)
        {
            try
            {
                //initDb();
                T obj = db.Set<T>().Where(c => c.id == id).FirstOrDefault();
                //if (obj != null)
                //{
                //    obj.DB = db;
                //}
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                
            }
        }

        public virtual List<T> getAll()
        {
            try
            {
                //initDb();
                List<T> objs = db.Set<T>().ToList();
                //foreach (T item in objs)
                //{
                //    item.DB = db;//importance
                //}
                return objs;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
            finally
            {
                
            }
        }
        /// <summary>
        /// Object and all references will no longer be supported by DbContext,
        /// Cached value will be used, but not connect to DB again
        /// </summary>
        public virtual void dispose()
        {
            //if (db != null)
            //{
            //    db.Dispose();
            //    db = null;
            //}
        }
        /// <summary>
        /// Load lại Object theo DBContext mới trong DBInstance (Vì có thể đã bị new mới bởi ai đó)
        /// Cần có id trước
        /// </summary>
        /// <returns></returns>
        public virtual T reload()
        {
            
            try
            {
                //initDb();
                T obj = db.Set<T>().Where(c => c.id == id).FirstOrDefault();
                //if (obj != null)
                //{
                //    obj.DB = db;
                //}
                return obj;
            }
            catch (Exception ex)
            {
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
        public List<T> parse(List<int> id_array)
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
    }
}
