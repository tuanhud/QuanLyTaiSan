using QuanLyTaiSan.Entities;
using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public static class Global
    {
        /// <summary>
        /// SERVER DB
        /// </summary>
        public static class server_database
        {
            public static void prepare_db_structure()
            {
                try
                {
                    OurDBContext tmp = new OurDBContext(Global.server_database.get_connection_string());
                    tmp.COSOS.Find(1);
                    tmp.Dispose();
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
                        Global.local_setting.db_server_port
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
        }
        /// <summary>
        /// Client DB or CACHED DB
        /// </summary>
        public static class client_database
        {
            public static void prepare_db_structure()
            {
                try
                {
                    OurDBContext tmp = new OurDBContext(Global.client_database.get_connection_string());
                    tmp.COSOS.Find(1);
                    tmp.Dispose();
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
                        Global.local_setting.db_cache_port
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
            public static String get_connection_string()
            {
                return StringHelper.generateConnectionString(
                        Global.working_database.db_host,
                        Global.working_database.db_name,
                        Global.working_database.db_WA,
                        Global.working_database.db_username,
                        Global.working_database.db_password,
                        Global.working_database.db_port
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
                /// (Đường dẫn tuyệt đối)
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
                /// (Đường dẫn tuyệt đối)
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
