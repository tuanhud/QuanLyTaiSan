using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public abstract class _EntityAbstract<T> : _CRUDInterface<T> where T : _EntityAbstract<T>
    {
        private MyDB db = null;
        public _EntityAbstract()
        {
            //init common
            init();
        }
        private void init()
        {
            //sql server time
            this.date_create = this.date_modified = ServerDateTime.getNow();            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String subId { get; set; }
        public String ten { get; set; }
        public String mota { get; set; }
        /*
         * Ngay record insert vao he thong 
         */
        public DateTime date_create { get; set; }
        /*
         * Ngay update gan day nhat
         */
        public DateTime date_modified { get; set; }
        /*
         * FK
         */
        public virtual HinhAnh hinhanh { get; set; }

        /*
         * Method of interface
         */
        public int add()
        {
            //update datetime
            date_create = date_modified = ServerDateTime.getNow();
            //add
            try
            {
                db = new MyDB();
                db.Set(typeof(T)).Add(this);
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

        public bool update()
        {
            //update datetime
            date_modified = ServerDateTime.getNow();
            //update
            try
            {
                db = new MyDB();
                db.Set(typeof(T)).Attach(this);
                db.Entry(this).State = EntityState.Modified;//importance
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool delete()
        {
            try
            {
                db = new MyDB();
                db.Set(typeof(T)).Remove(this);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /*
         * STATIC method
         */
        public static T getById(int id)
        {
            MyDB db = new MyDB();
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
    }
}
