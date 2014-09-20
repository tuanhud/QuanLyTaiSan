using PTB.Entities;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PTB
{
    public static partial class Global
    {
        /// <summary>
        /// Client DB or CACHED DB
        /// </summary>

        /// <summary>
        /// Có hỗ trợ tự động tạo CSDL nếu chưa có,
        /// Hỗ trợ tự động tạo SYNC SCOPE nếu chưa có
        /// </summary>
        public static class client_database
        {
            public static int create_default_user()
            {
                SqlConnection m = new SqlConnection(get_connection_string());
                m.Open();
                SqlCommand c = m.CreateCommand();
                c.CommandText = @"
                    USE [master];
                    CREATE LOGIN [test] WITH PASSWORD=N'test', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;
                    EXEC master..sp_addsrvrolemember @loginame = N'test', @rolename = N'sysadmin';
                    CREATE USER [test] FROM LOGIN [test] WITH DEFAULT_SCHEMA = dbo;
                    ALTER LOGIN [quocdunginfo-PC\quocdunginfo] DISABLE;
                    DECLARE @hostName NVARCHAR(255);
                    SET @hostName = (SELECT HOST_NAME());
                    DECLARE @currentUser NVARCHAR(255);
                    SET @currentUser = (SUSER_NAME());
                    DECLARE @statement NVARCHAR(255);
                    SET @statement = 'ALTER LOGIN [' + @hostName + '\' + @currentUser + '] DISABLE';
                    EXEC sp_executesql @statement;
                ";
                c.CommandType = System.Data.CommandType.Text;
                c.ExecuteNonQuery();
                return 1;
            }
            public static int isHasScope()
            {
                //kiểm tra CSDL sẵn sàng để sync
                return DatabaseHelper.isHasScope(Global.client_database.get_connection_string(), Global.sync.scope_name, Global.sync.tracking_tables);
            }
            public static int drop_scope()
            {
                return DatabaseHelper.drop_sync_scope(Global.client_database.get_connection_string(), Global.sync.scope_name);
            }
            /// <summary>
            /// Xóa SCOPE hiện có (nếu có),
            /// đồng thời FETCH SCOPE từ Server về
            /// </summary>
            /// <returns></returns>
            public static int clean_up_scope()
            {
                if (!Global.local_setting.use_db_cache)
                {
                    return -1;
                }
                //DROP Database

                DatabaseHelper.drop_sync_scope(Global.client_database.get_connection_string(), Global.sync.scope_name);
                DatabaseHelper.fetch_sync_scope(
                    Global.client_database.get_connection_string(),
                    Global.server_database.get_connection_string(),
                    Global.sync.scope_name
                );

                return 1;
            }
            /// <summary>
            /// SYNC Client Server to MAIN Server
            /// </summary>
            public static int start_sync()
            {
                try
                {
                    //Kiểm tra có sử dụng DBCache
                    if (!Global.working_database.use_db_cache)
                    {
                        return 1;
                    }
                    int re = DatabaseHelper.start_sync(
                        Global.client_database.get_connection_string(),
                        Global.server_database.get_connection_string(),
                        Global.sync.scope_name
                    );
                    return re;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return -1;
                }
                

            }
            /// <summary>
            /// Tự động tạo cấu trúc CSDL nếu chưa có
            /// </summary>
            public static void prepare_db_structure()
            {
                //Kiểm tra có sử dụng DBCache
                if (!Global.local_setting.use_db_cache)
                {
                    return;
                }

                try
                {
                    using (OurDBContext tmp = new OurDBContext(Global.client_database.get_connection_string(), true))
                    {
                        tmp.isValidModel();
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
                    Global.client_database.get_connection_string()
                ))
                {
                    try
                    {
                        //Check model backing
                        using (OurDBContext tmp = new OurDBContext(Global.client_database.get_connection_string(), false))
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
                    return Global.local_setting.db_cache_host;
                }
            }
            public static String db_port
            {
                get
                {
                    return Global.local_setting.db_cache_port;
                }
            }
            public static String db_name
            {
                get
                {
                    return Global.local_setting.db_cache_dbname;
                }
            }
            public static String db_username
            {
                get
                {
                    return Global.local_setting.db_cache_username;
                }
            }
            public static String db_password
            {
                get
                {
                    return Global.local_setting.db_cache_password;
                }
            }
            /// <summary>
            /// Windows Authentication
            /// </summary>
            public static Boolean db_WA
            {
                get
                {
                    return Global.local_setting.db_cache_WA;
                }
            }
            public static void dropDB()
            {
                DatabaseHelper.dropDB(get_connection_string());
            }
        }
        
    }
}
