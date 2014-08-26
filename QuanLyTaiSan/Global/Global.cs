using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyTaiSan.Entities
{
    public static class Global
    {
        public static class debug
        {
            public static int remove_file()
            {
                return FileHelper.delete(FILENAME);
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
                get
                {
                    return OurDBContext.tracking_tables;
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
                        10
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns>-1: Not exist, -2: model backing changed, >0: OK</returns>
            public static int isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                if (!DatabaseHelper.isExist(
                    Global.server_database.get_connection_string()
                ))
                {
                    return -1;
                }
                //Check model backing
                using (OurDBContext tmp = new OurDBContext(Global.server_database.get_connection_string(),false))
                {
                    return tmp.isValidModel() ? 1 : -2;
                }
            }
            /// <summary>
            /// Kiểm tra CSDL đã có SYNC SCOPE
            /// </summary>
            /// <returns></returns>
            public static int isHasScope()
            {
                int tmp = 0;
                //kiểm tra CSDL sẵn sàng để sync
                return tmp = DatabaseHelper.isHasScope(Global.server_database.get_connection_string(),Global.sync.scope_name,Global.sync.tracking_tables);
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
            public static int isHasScope()
            {
                //kiểm tra CSDL sẵn sàng để sync
                return DatabaseHelper.isHasScope(Global.client_database.get_connection_string(),Global.sync.scope_name,Global.sync.tracking_tables);
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
                //DatabaseHelper.dropDB(Global.client_database.get_connection_string());
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
                //Kiểm tra nếu sử dụng internal config thì bỏ qua
                if (Global.working_database.use_internal_config)
                {
                    return 1;
                }
                //Kiểm tra có sử dụng DBCache
                if (!Global.local_setting.use_db_cache)
                {
                    return 1;
                }
                //Kiểm tra kết nối cho cả client và Server
                if (Global.client_database.isReady()<0 || Global.server_database.isReady()<0)
                {
                    return -1;
                }

                return DatabaseHelper.start_sync(
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
                        10
                );
            }
            /// <summary>
            /// Kiểm tra kết nối tới Database
            /// </summary>
            /// <returns>-1: Not exist, -2: model backing changed, >0: OK</returns>
            public static int isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                if (!DatabaseHelper.isExist(
                    Global.client_database.get_connection_string()
                ))
                {
                    return -1;
                }
                //Check model backing
                using (OurDBContext tmp = new OurDBContext(Global.client_database.get_connection_string(), false))
                {
                    return tmp.isValidModel() ? 1 : -2;
                }
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
            /// <returns>-1: Not exist, -2: model backing changed, >0: OK</returns>
            public static int isReady(int TimeOut = -1)
            {
                //Check if target database is ready
                if (!DatabaseHelper.isExist(
                    Global.working_database.get_connection_string()
                ))
                {
                    return -1;
                }
                //Check model backing
                //Check model backing
                using (OurDBContext tmp = new OurDBContext(Global.working_database.get_connection_string(), false))
                {
                    return tmp.isValidModel() ? 1 : -2;
                }
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
        
        private static QuanTriVien _current_quantrivien_login = null;
        /// <summary>
        /// Dành cho Winform (Quản trị viên sử dụng pâần mềm quản lý)
        /// </summary>
        public static QuanTriVien current_quantrivien_login {
            get
            {
                if (Global.working_database.use_internal_config)
                {
                    QuanTriVien tmp = HttpContext.Current.Items["current_quantrivien_login"] as QuanTriVien;
                    if (tmp == null)
                    {
                        return null;
                    }
                    tmp = tmp.reload();
                    HttpContext.Current.Items["current_quantrivien_login"] = tmp;
                    return tmp;
                }
                else
                {
                    //very importance because of OLD DBCONTEXT
                    return _current_quantrivien_login = _current_quantrivien_login == null ? null : _current_quantrivien_login.reload();
                }
            }
            set
            {
                if (Global.working_database.use_internal_config)
                {
                    HttpContext.Current.Items["current_quantrivien_login"] = value;
                }
                else
                {
                    _current_quantrivien_login = value;
                }
            }
        }
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
            public static class smtp_config
            {
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = Setting.getByKey("smtp_host");
                    obj.value = smtp_host;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("smtp_username");
                    obj.value = smtp_username;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("smtp_password");
                    obj.value = smtp_password;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("smtp_port");
                    obj.value = smtp_port==null?"0":smtp_port.ToString();
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("smtp_usessl");
                    obj.value = smtp_usessl == null || smtp_usessl == false ? "0" : "1";
                    re = re && obj.addOrUpdate() > 0;

                    re = re && DBInstance.commit() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re ? 1 : -1;
                }

                private static void reload()
                {
                    smtp_host = smtp_password = smtp_username = null;
                    smtp_port = null;
                    smtp_usessl = true;
                }

                private static String smtp_host = null;
                public static String SMTP_HOST
                {
                    get
                    {
                        if (smtp_host == null)
                        {
                            smtp_host = Setting.getValue("smtp_host");
                        }
                        return smtp_host;
                    }
                    set
                    {
                        smtp_host = value;
                    }
                }

                private static String smtp_username = null;
                public static String SMTP_USERNAME
                {
                    get
                    {
                        if (smtp_username == null)
                        {
                            smtp_username = Setting.getValue("smtp_username");
                        }
                        return smtp_username;
                    }
                    set
                    {
                        smtp_username = value;
                    }
                }

                private static String smtp_password = null;
                public static String SMTP_PASSWORD
                {
                    get
                    {
                        if (smtp_password == null)
                        {
                            smtp_password = Setting.getValue("smtp_password");
                        }
                        return smtp_password;
                    }
                    set
                    {
                        smtp_password = value;
                    }
                }

                private static int? smtp_port = null;
                public static int SMTP_PORT
                {
                    get
                    {
                        if (smtp_port == null)
                        {
                            smtp_port = StringHelper.toInt(Setting.getValue("smtp_port"));
                        }
                        return (int)smtp_port;
                    }
                    set
                    {
                        smtp_port = value;
                    }
                }

                private static Boolean? smtp_usessl = null;
                public static Boolean SMTP_USESSL
                {
                    get
                    {
                        if (smtp_usessl == null)
                        {
                            smtp_usessl = Setting.getValue("smtp_usessl").Equals("1");
                        }
                        return (Boolean)smtp_usessl;
                    }
                    set
                    {
                        smtp_usessl = value;
                    }
                }
            }
            public static class ftp_host
            {
                /// <summary>
                /// Generate duong dan ftp dang FULL ung voi relative path
                /// </summary>
                /// <param name="relativePath"></param>
                /// <returns></returns>
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

                    re = re && DBInstance.commit() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re?1:-1;
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

                    re = re && DBInstance.commit() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re ? 1 : -1;
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
