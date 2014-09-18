using TSCD.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCD
{
    public static partial class Global
    {
        /// <summary>
        /// SERVER DB
        /// </summary>
        public static class server_database
        {
            /// <summary>
            /// Xóa SCOPE hiện có ra khỏi Server (nếu có),
            /// tự động tạo scope mới
            /// </summary>
            public static int clean_up_scope()
            {
                DatabaseHelper.drop_sync_scope(Global.server_database.get_connection_string(), Global.sync.scope_name);

                int re = DatabaseHelper.setup_sync_scope(
                    Global.server_database.get_connection_string(),
                    Global.sync.scope_name,
                    Global.sync.tracking_tables
                );
                if (re > 0)
                {
                    //LogHeThong.write("clean up server scope: " + get_connection_string());
                }

                return re;
            }
            /// <summary>
            /// Có hỗ trợ tự động tạo cấu trúc CSDL nếu chưa có
            /// </summary>
            public static void prepare_db_structure()
            {
                try
                {
                    using (OurDBContext tmp = new OurDBContext(Global.server_database.get_connection_string(), true))
                    {
                        tmp.isValidModel();
                        tmp.forceSeed();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
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
                    Global.server_database.get_connection_string()
                ))
                {
                    //Check model backing
                    using (OurDBContext tmp = new OurDBContext(Global.server_database.get_connection_string(), false))
                    {
                        if (tmp.isValidModel())
                        {
                            return 1;
                        }
                    }
                }
                return -2;
            }
            /// <summary>
            /// Kiểm tra CSDL đã có SYNC SCOPE
            /// </summary>
            /// <returns></returns>
            public static int isHasScope()
            {
                int tmp = 0;
                //kiểm tra CSDL sẵn sàng để sync
                return tmp = DatabaseHelper.isHasScope(Global.server_database.get_connection_string(), Global.sync.scope_name, Global.sync.tracking_tables);
            }
            public static String db_host
            {
                get
                {
                    return Global.local_setting.db_server_host;
                }
            }
            public static String db_port
            {
                get
                {
                    return Global.local_setting.db_server_port;
                }
            }
            public static String db_name
            {
                get
                {
                    return Global.local_setting.db_server_dbname;
                }
            }
            public static String db_username
            {
                get
                {
                    return Global.local_setting.db_server_username;
                }
            }
            public static String db_password
            {
                get
                {
                    return Global.local_setting.db_server_password;
                }
            }
            /// <summary>
            /// Windows Authentication
            /// </summary>
            public static Boolean db_WA
            {
                get
                {
                    return Global.local_setting.db_server_WA;
                }
            }

            public static int drop_scope()
            {
                int re = DatabaseHelper.drop_sync_scope(Global.server_database.get_connection_string(), Global.sync.scope_name);
                if (re > 0)
                {
                    //LogHeThong.write("remove server sync scope: " + get_connection_string());
                }

                return re;
            }
        }
    }
}
