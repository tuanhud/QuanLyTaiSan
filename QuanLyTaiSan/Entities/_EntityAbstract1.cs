using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public abstract class _EntityAbstract1<T> : _CRUDInterface<T> where T : _EntityAbstract1<T>
    {
        public _EntityAbstract1()
        {
            init();
        }
        public _EntityAbstract1(MyDB db)
        {
            this.db = db;
            init();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        protected virtual void init()
        {

        }
        /*
         * Method of interface
         */
        [NotMapped]
        protected MyDB db = null;
        [NotMapped]
        public MyDB DB
        {
            get
            {
                initDb();
                return db;
            }
            set
            {
                db = value;
            }
        }
        protected void initDb()
        {
            if (db == null)
            {
                db = new MyDB();
            }
        }

        public virtual int add()
        {
            initDb();
            //add
            try
            {
                //db = new MyDB();
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
                //db.Dispose();
            }
        }

        public virtual int update()
        {
            initDb();
            //update
            try
            {
                //db = new MyDB();
                db.Set<T>().Attach((T)this);
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
                //db.Dispose();
            }
        }

        public virtual int delete()
        {
            initDb();
            try
            {
                //db = new MyDB();
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
                //db.Dispose();
            }
        }
        public T getById(int id)
        {
            initDb();
            //db = new MyDB();
            try
            {
                T obj = db.Set<T>().Where(c => c.id == id).FirstOrDefault();
                if (obj != null)
                {
                    obj.DB = db;
                }
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //db.Dispose();
            }
        }

        public List<T> getAll()
        {
            initDb();
            //db = new MyDB();
            try
            {
                List<T> objs = db.Set<T>().ToList();
                foreach (T item in objs)
                {
                    item.DB = db;
                }
                return objs;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
            finally
            {
                //db.Dispose();
            }
        }
    }
}
