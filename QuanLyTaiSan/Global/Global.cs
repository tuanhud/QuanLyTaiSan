using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public static class Global
    {
        public static class debug
        {
            public static void remove_file()
            {
                try
                {
                    // Try to delete the file.
                    File.Delete(FILENAME);
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    // We could not delete the file.
                    return;
                }
            }
            /// <summary>
            /// Lưu mode vào local setting
            /// </summary>
            /// <returns></returns>
            public static int save()
            {
                Global.local_setting.Save();
                return 1;
            }
            public static String FILENAME
            {
                get
                {
                    return "debug.txt";
                }
            }
            /// <summary>
            /// 
            /// </summary>
            private static int mode = 0;
            /// <summary>
            /// 0: Ghi ra Console,
            /// 1: Ghi ra File "debug.txt",
            /// 2: Silient
            /// </summary>
            public static int MODE
            {
                get
                {
                    if (mode != -1)
                    {
                        return mode;
                    }
                    mode = Global.local_setting.debug_mode;
                    return mode;
                }
                set
                {
                    mode = Global.local_setting.debug_mode = value;
                }
            }
        }
        public static class sync
        {
            public static String scope_name
            {
                get
                {
                    return "QLTSScope";
                }
            }
            public static String[] tracking_tables
            {
                //UNDEPENDENT (bản thân không có chưa bất kỳ FK nào)
                //TABLES HAVE TO BE IN RIGHT ORDER FOR FK CONSTRAIN
                get
                {
                    return new String[] {
                        "__MigrationHistory",//UNDEPENDENT

                        "COSOS",//UNDEPENDENT
                        "DAYS",
                        "TANGS",
                        "VITRIS",
                        "NHANVIENPTS",//UNDEPENDENT
                        "PHONGS",
                    
                        "LOAITHIETBIS",
                        "TINHTRANGS",//UNDEPENDENT
                        "THIETBIS",
                        "CTTHIETBIS",
                    
                        "GROUPS",//UNDEPENDENT
                        "PERMISSIONS",//UNDEPENDENT
                        "GROUP_PERMISSION",
                        "QUANTRIVIENS",

                        "LOGTHIETBIS",

                        "SUCOPHONGS",//UNDEPENDENT
                        "LOGSUCOPHONGS",
                        "HINHANHS",
                        "SETTINGS",//UNDEPENDENT
                        "LOGHETHONGS",//UNDEPENDENT
                    };
                }
            }
        }
        
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
                DatabaseHelper.setup_sync_scope(
                    Global.server_database.get_connection_string(),
                    Global.sync.scope_name,
                    Global.sync.tracking_tables
                );

                Global.server_database.prepare_db_structure();

                return 1;
            }
            /// <summary>
            /// Có hỗ trợ tự động tạo cấu trúc CSDL nếu chưa có
            /// </summary>
            public static void prepare_db_structure()
            {
                try
                {
                    OurDBContext tmp = new OurDBContext(Global.server_database.get_connection_string(),true);
                    if (tmp != null)
                    {
                        tmp.COSOS.Find(1);
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
                        Global.local_setting.db_server_host,
                        Global.local_setting.db_server_dbname,
                        Global.local_setting.db_server_WA,
                        Global.local_setting.db_server_username,
                        Global.local_setting.db_server_password,
                        Global.local_setting.db_server_port,
                        3
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns></returns>
            public static Boolean isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                return DatabaseHelper.isReady(
                    Global.server_database.get_connection_string()
                );
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
                return DatabaseHelper.drop_sync_scope(Global.server_database.get_connection_string(), Global.sync.scope_name);
            }
        }
        /// <summary>
        /// Client DB or CACHED DB
        /// </summary>

        /// <summary>
        /// Có hỗ trợ tự động tạo CSDL nếu chưa có,
        /// Hỗ trợ tự động tạo SYNC SCOPE nếu chưa có
        /// </summary>
        public static class client_database
        {
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
                //DatabaseHelper.dropDB(Global.client_database.get_connection_string());
                DatabaseHelper.drop_sync_scope(Global.client_database.get_connection_string(), Global.sync.scope_name);
                DatabaseHelper.fetch_sync_scope(
                    Global.client_database.get_connection_string(),
                    Global.server_database.get_connection_string(),
                    Global.sync.scope_name
                );

                Global.client_database.prepare_db_structure();

                return 1;
            }
            /// <summary>
            /// SYNC Client Server to MAIN Server
            /// </summary>
            public static int start_sync()
            {
                //Kiểm tra có sử dụng DBCache
                if (!Global.local_setting.use_db_cache)
                {
                    return -1;
                }
                //Kiểm tra kết nối cho cả client và Server
                if (!Global.client_database.isReady() || !Global.server_database.isReady())
                {
                    return -1;
                }

                return DatabaseHelper.start_sync_process(
                    Global.client_database.get_connection_string(),
                    Global.server_database.get_connection_string(),
                    Global.sync.scope_name
                );

            }
            /// <summary>
            /// Tự động tạo cấu trúc CSDL nếu chưa có
            /// </summary>
            public static void prepare_db_structure()
            {
                //Kiểm tra có sử dụng DBCache
                if (!Global.local_setting.use_db_cache)
                {
                    return ;
                }
                try
                {
                    OurDBContext tmp = new OurDBContext(Global.client_database.get_connection_string(),false);
                    if (tmp != null)
                    {
                        tmp.COSOS.Find(1);
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
                        Global.local_setting.db_cache_host,
                        Global.local_setting.db_cache_dbname,
                        Global.local_setting.db_cache_WA,
                        Global.local_setting.db_cache_username,
                        Global.local_setting.db_cache_password,
                        Global.local_setting.db_cache_port,
                        3
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns></returns>
            public static Boolean isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                return DatabaseHelper.isReady(
                    Global.client_database.get_connection_string()
                );
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

            
        }
        /// <summary>
        /// Thông tin về CSDL mà ứng dụng sẽ truy xuất tới,
        /// Không quan tâm nó là Cached hay Main Server,
        /// Việc kiểm tra sẽ tự động dựa vào setting của ứng dụng,
        /// READ ONLY
        /// </summary>
        public static class working_database
        {
            private static Boolean useinternalconfig = false;
            /// <summary>
            /// Chỉ định sử dụng file Config trong Project hay là trong Global.local_setting,
            /// WEB phải set = true trước khi gọi Entity, Winfor KHÔNG cần,
            /// phải chỉ định connectionString tên Default trong Web.config
            /// </summary>
            public static Boolean use_internal_config
            {
                get
                {
                    return useinternalconfig;
                }
                set
                {
                    useinternalconfig = value;
                }
            }

            public static String get_connection_string()
            {
                return StringHelper.generateConnectionString(
                        Global.working_database.db_host,
                        Global.working_database.db_name,
                        Global.working_database.db_WA,
                        Global.working_database.db_username,
                        Global.working_database.db_password,
                        Global.working_database.db_port,
                        3
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns></returns>
            public static Boolean isReady(int TimeOut=-1)
            {
                //Check if target database is ready
                return DatabaseHelper.isReady(
                    Global.working_database.get_connection_string()
                );
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

        }
        public static QuanTriVien current_login { get; set; }
        public static Properties.Settings local_setting
        {
            get
            {
                return Properties.Settings.Default;
            }
        }
        /// <summary>
        /// Những cài đặt được lưu ở phía DB
        /// </summary>
        public static class remote_setting
        {
            
            public static class ftp_host
            {
                public static String getCombinedPath(String relativePath = "")
                {
                    String tmp = "";
                    tmp +=
                        Global.remote_setting.ftp_host.HOST_NAME +
                        Global.remote_setting.ftp_host.PRE_PATH +
                        relativePath;
                    return tmp;
                }
                public static void reload()
                {
                    host_name = null;
                    user_name = null;
                    pass_word = null;
                    pre_path = null;
                    port = null;
                }
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = Setting.getByKey("ftp_image_host");
                    obj.value = host_name;
                    re = re && obj.addOrUpdate()>0;

                    obj = Setting.getByKey("ftp_image_username");
                    obj.value = user_name;
                    re = re && obj.addOrUpdate()>0;

                    obj = Setting.getByKey("ftp_image_password");
                    obj.value = pass_word;
                    re = re && obj.addOrUpdate()>0;

                    obj = Setting.getByKey("ftp_image_prepath");
                    obj.value = pre_path;
                    re = re && obj.addOrUpdate()>0;

                    obj = Setting.getByKey("ftp_image_port");
                    obj.value = port;
                    re = re && obj.addOrUpdate() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re?1:0;
                }
                private static String port = null;
                /// <summary>
                /// vd: 21
                /// </summary>
                public static String PORT
                {
                    get
                    {
                        if (port == null)
                        {
                            //load from DB
                            port = Setting.getValue("ftp_image_port");
                        }
                        return port;
                    }
                    set
                    {
                        port = value;
                    }
                }

                private static String host_name=null;
                /// <summary>
                /// vd: ftp://example.com
                /// </summary>
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            host_name = Setting.getValue("ftp_image_host");
                        }
                        return host_name;
                    }
                    set
                    {
                        host_name = value;
                    }
                }

                private static String user_name = null;
                public static String USER_NAME
                {
                    get
                    {
                        if (user_name == null)
                        {
                            //load from DB
                            user_name = Setting.getValue("ftp_image_username");
                        }
                        return user_name;
                    }
                    set
                    {
                        user_name = value;
                    }
                }

                private static String pass_word = null;
                public static String PASS_WORD
                {
                    get
                    {
                        if (pass_word == null)
                        {
                            //load from DB
                            pass_word = Setting.getValue("ftp_image_password");
                        }
                        return pass_word;
                    }
                    set
                    {
                        pass_word = value;
                    }
                }

                private static String pre_path = null;
                /// <summary>
                /// Đường dẫn đến thư mục hình trên HOST,
                /// (Đường dẫn tuyệt đối), vd: /abspath/path2/
                /// </summary>
                public static String PRE_PATH
                {
                    get
                    {
                        if (pre_path == null)
                        {
                            //load from DB
                            pre_path = Setting.getValue("ftp_image_prepath");
                        }
                        return pre_path;
                    }
                    set
                    {
                        pre_path = value;
                    }
                }
                /// <summary>
                /// Kiểm tra thông tin FTP đã được load đầy đủ
                /// </summary>
                public static Boolean IS_READY {
                    get
                    {
                        //force to get all
                        return true;
                    }
                }

            }
            public static class http_host
            {
                public static String getCombinedPath(String relativePath="")
                {
                    String tmp = "";
                    tmp += Global.remote_setting.http_host.HOST_NAME;
                    tmp += !Global.remote_setting.http_host.PORT.Equals("") ? ":" + Global.remote_setting.http_host.PORT : "";
                    tmp += Global.remote_setting.http_host.PRE_PATH + relativePath;
                    return tmp;
                }
                public static void reload()
                {
                    host_name = null;
                    port = null;
                    pre_path = null;
                }
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = Setting.getByKey("http_image_host");
                    obj.value = host_name;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("http_image_prepath");
                    obj.value = pre_path;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("http_image_port");
                    obj.value = port;
                    re = re && obj.addOrUpdate() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re ? 1 : 0;
                }

                private static String port = null;
                /// <summary>
                /// vd: 80
                /// </summary>
                public static String PORT
                {
                    get
                    {
                        if (port == null)
                        {
                            //load from DB
                            port = Setting.getValue("http_image_port");
                        }
                        return port;
                    }
                    set
                    {
                        port = value;
                    }
                }

                private static String host_name = null;
                /// <summary>
                /// vd: http://example.com
                /// </summary>
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            host_name = Setting.getValue("http_image_host");
                        }
                        return host_name;
                    }
                    set
                    {
                        host_name = value;
                    }
                }

                private static String pre_path = null;
                /// <summary>
                /// Đường dẫn đến thư mục hình trên HOST,
                /// (Đường dẫn tuyệt đối),
                /// vd: /path1/path2/
                /// </summary>
                public static String PRE_PATH
                {
                    get
                    {
                        if (pre_path == null)
                        {
                            //load from DB
                            pre_path = Setting.getValue("http_image_prepath");
                        }
                        return pre_path;
                    }
                    set
                    {
                        pre_path = value;
                    }
                }
                /// <summary>
                /// Kiểm tra thông tin HTTP đã được load đầy đủ
                /// </summary>
                public static Boolean IS_READY
                {
                    get
                    {
                        //force to get all
                        return true;
                    }
                }

            }
        }
    }
}
