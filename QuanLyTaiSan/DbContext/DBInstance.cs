using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using SHARED;
using SHARED.Libraries;

namespace QuanLyTaiSan.Entities
{
    public static class DBInstance
    {
        #region Event 
        private static Boolean dbConnectionON = false;
        public delegate void DBConnectionChanged(EventArgs e);
        public static event DBConnectionChanged onDBConnectionDown;
        public static event DBConnectionChanged onDBConnectionUp;

        #endregion
        /// <summary>
        /// winform only
        /// </summary>
        private static OurDBContext db = null;
        internal static OurDBContext DB
        {
            get
            {
                try
                {
                    if (SHARED.Global.WEB_MODE)
                    {
                        OurDBContext tmp = HttpContext.Current.Items["db_context"] as OurDBContext;
                        if (tmp == null)
                        {
                            tmp = new OurDBContext();
                            HttpContext.Current.Items["db_context"] = tmp;
                        }
                        return tmp;
                    }
                    else
                    {
                        if (db == null)
                        {
                            if (SHARED.Global.USE_APP_CONFIG)
                            {
                                db = new OurDBContext();
                            }
                            else
                            {
                                db = new OurDBContext(Global.working_database.get_connection_string());
                            }
                        }

                        try
                        {
                            db.Set<CoSo>().AsQueryable().FirstOrDefault();
                            //Raise event
                            if (!dbConnectionON && onDBConnectionUp != null)
                            {
                                onDBConnectionUp(new EventArgs());
                            }
                            dbConnectionON = true;
                        }
                        catch (Exception)
                        {
                            //DB CONNECTION FAIL
                            Debug.WriteLine("=========DB CONNECTION FAIL==========");
                            //Raise event
                            if (dbConnectionON && onDBConnectionDown != null)
                            {
                                onDBConnectionDown(new EventArgs());
                            }
                            dbConnectionON = false;
                        }
                        return db;
                    }
                }catch(Exception t)
                {
                    Debug.WriteLine(t);
                    return new OurDBContext();
                }
            }
        }
        /// <summary>
        /// Bắt buộc phải gọi mới thấy được sự thay đổi CSDL do nơi khác chỉnh sửa,
        /// Tất cả Object get ra bởi DBInstace cũ sẽ phải reload mới có thể tiếp tục sử dụng lại được,
        /// Nếu không Object cũ sẽ vẫn phải chịu sự giám sát của DbContext cũ
        /// </summary>
        public static void reNew()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
            
            db = DB;
        }
        /// <summary>
        /// Đồng bộ CSDL lên Server
        /// </summary>
        private static void sync()
        {
            Debug.WriteLine("======Location: DBInstance======");
            Debug.WriteLine("======Start sync when insert, in new Thread======");
            Global.client_database.start_sync();
            Debug.WriteLine("======End sync when insert, in new Thread======");
        }
        /// <summary>
        /// > 0: OK,
        /// < 0: Fail
        /// </summary>
        /// <returns></returns>
        public static int commit()
        {
            try
            {
                if (DB != null)
                {
                    using (var dbTrans = DB.Database.BeginTransaction())
                    {
                        try
                        {
                            int re = DB.SaveChanges();
                            dbTrans.Commit();
                            //sync when data done
                            if (re > 0 && !SHARED.Global.WEB_MODE && Global.working_database.use_db_cache)
                            {
                                Thread thread = new Thread(new ThreadStart(sync));
                                thread.SetApartmentState(ApartmentState.STA);
                                thread.Start();
                            }
                            return 1;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            try
                            {
                                //rollback transaction
                                dbTrans.Rollback();
                                //discard all changed made fail
                                DB.reloadAllFail();
                            }
                            catch (Exception exx)
                            {
                                Debug.WriteLine(exx.ToString());
                            }
                            return -1;
                        }
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return -1;
            }
        }
    }
}
