using PTB.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB
{
    public static partial class Global
    {
        /// <summary>
        /// Thông tin về CSDL mà ứng dụng sẽ truy xuất tới,
        /// Không quan tâm nó là Cached hay Main Server,
        /// Việc kiểm tra sẽ tự động dựa vào setting của ứng dụng,
        /// READ ONLY
        /// </summary>
        public static class working_database
        {
            public static String get_connection_string()
            {
                return StringHelper.generateConnectionString(
                        db_host,
                        db_name,
                        db_WA,
                        db_username,
                        db_password,
                        db_port,
                        5
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns>-1: Not exist, -2: model backing changed, >0: OK</returns>
            public static int isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                if (DatabaseHelper.isExist(
                    Global.working_database.get_connection_string()
                ))
                {
                    try
                    {
                        //Check model backing
                        using (OurDBContext tmp = new OurDBContext(Global.working_database.get_connection_string(), false))
                        {
                            if (tmp.isValidModel())
                            {
                                return 1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        return -2;
                    }
                }
                return -2;
            }
            public static String db_host
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_host : Global.local_setting.db_server_host;
                }
            }
            public static String db_port
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_port : Global.local_setting.db_server_port;
                }
            }
            public static String db_name
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_dbname : Global.local_setting.db_server_dbname;
                }
            }
            public static String db_username
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_username : Global.local_setting.db_server_username;
                }
            }
            public static String db_password
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_password : Global.local_setting.db_server_password;
                }
            }
            /// <summary>
            /// Windows Authentication
            /// </summary>
            public static Boolean db_WA
            {
                get
                {
                    return Global.local_setting.use_db_cache ? Global.local_setting.db_cache_WA : Global.local_setting.db_server_WA;
                }
            }
            public static Boolean use_db_cache
            {
                get
                {
                    if (SHARED.Global.WEB_MODE)
                    {
                        return false;
                    }
                    return Global.local_setting.use_db_cache;
                }
            }
        }

    }
}
