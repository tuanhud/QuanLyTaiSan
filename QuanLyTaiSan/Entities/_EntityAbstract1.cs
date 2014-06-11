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
            this.db = new MyDB();
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
        private MyDB db = null;

        public virtual int add()
        {
            //add
            try
            {
                db = new MyDB();
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
                db.Dispose();
            }
        }

        public virtual int update()
        {
            //update
            try
            {
                db = new MyDB();
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
                db.Dispose();
            }
        }

        public virtual int delete()
        {
            try
            {
                db = new MyDB();
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
                db.Dispose();
            }
        }
        public T getById(int id)
        {
            db = new MyDB();
            try
            {
                return db.Set<T>().Where(c => c.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<T> getAll()
        {
            db = new MyDB();
            try
            {
                return db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
