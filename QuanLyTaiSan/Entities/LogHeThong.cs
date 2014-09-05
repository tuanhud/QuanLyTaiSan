using QuanLyTaiSan.Entities;
using SHARED.Interface;
using SHARED.Libraries;
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
    [Table("LOGHETHONGS")]
    public class LogHeThong: _EFEventRegisterInterface
    {
        public LogHeThong():base()
        {

        }
        #region Dinh nghia
        [NotMapped]
        private static OurDBContext db
        {
            get
            {
                return DBInstance.DB;
            }
        }
        /// <summary>
        /// Optional
        /// </summary>
        [Key, Column(Order = 0)]
        [Required]
        public String mota { get; set; }
        /// <summary>
        /// Ngay record insert vao he thong
        /// Optional
        /// </summary>
        [Key, Column(Order = 1)]
        [Required]
        public DateTime date_create { get; set; }
        #endregion

        #region Nghiep vu
        public static List<LogHeThong> getAllByDK(DateTime? tuNgay, DateTime? denNgay, int gioiHan)
        {
            List<LogHeThong> re =
                (from c in db.LOGHETHONGS
                 where ((tuNgay == null || c.date_create >= tuNgay) && (denNgay == null || c.date_create <= denNgay))
                 select c).OrderByDescending(c => c.date_create).Take(gioiHan).ToList();
            return re;
        }
        #endregion

        #region Event
        public void onBeforeUpdated()
        {
            
        }

        public void onBeforeAdded()
        {
            date_create = ServerTimeHelper.getNow();
        }

        public void onBeforeDeleted()
        {
            
        }

        public void onAfterUpdated()
        {
            
        }

        public void onAfterAdded()
        {
            
        }
        #endregion

        #region Nghiep vu
        public int add()
        {
            try
            {
                //script
                db.Set<LogHeThong>().Add((LogHeThong)this);
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

        public int delete()
        {
            try
            {
                db.Set<LogHeThong>().Remove((LogHeThong)this);

                //END
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                //nếu bị lỗi thì Attach lại, để không bị mất khóa ngoại, cháu chắt
                db.Set<LogHeThong>().Attach((LogHeThong)this);
                return -1;
            }
        }

        public LogHeThong reload()
        {
            try
            {
                if (db.Entry(this).State == EntityState.Detached)
                {
                    db.Set<LogHeThong>().Attach((LogHeThong)this);
                    return (LogHeThong)this;
                }
                return (LogHeThong)this;
            }
            catch (Exception)
            {
                try
                {
                    db.Entry(this).Reload();
                    return (LogHeThong)this;
                }
                catch (Exception)
                {
                    try
                    {
                        //Case 1: Multi db context tracking
                        //Case 2: Object not loaded before
                        return db.Set<LogHeThong>().Find(mota, date_create);
                    }
                    catch (Exception exx)
                    {
                        //for any other error
                        Debug.WriteLine(exx.ToString());
                        return null;
                    }
                }
            }
        }

        public void trigger()
        {
            
        }

        public LogHeThong clone()
        {
            return null;
        }

        public void moveUp()
        {
            
        }

        public void moveDown()
        {
            
        }

        public string niceName()
        {
            return "";
        }

        public LogHeThong prevObj()
        {
            return null;
        }

        public LogHeThong nextObj()
        {
            return null;
        }


        /// <summary>
        /// Có thể query trên danh sách sau đó mới trả về List,
        /// Sẽ nhanh hơn nhiều so với getAll,
        /// Có thể quăng Exception do mất kết nối tới Database (Cần tìm phương án khắc phục)
        /// </summary>
        /// <returns></returns>
        public static IQueryable<LogHeThong> getQuery()
        {
            try
            {
                db.Set<LogHeThong>().AsQueryable().FirstOrDefault();
                return db.Set<LogHeThong>().AsQueryable<LogHeThong>();
            }
            catch (Exception)
            {
                return new List<LogHeThong>().AsQueryable<LogHeThong>();
            }
        }
        /// <summary>
        /// Sử dụng để đổ DataSource nhanh,
        /// Muốn query được thì nên sử dụng getQuery sẽ nhanh hơn
        /// </summary>
        /// <returns></returns>
        public static List<LogHeThong> getAll()
        {
            try
            {
                return db.Set<LogHeThong>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<LogHeThong>();
            }
        }
        #endregion

    }
}
