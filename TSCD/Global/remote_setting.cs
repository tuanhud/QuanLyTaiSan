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
        /// Những cài đặt được lưu ở phía DB
        /// </summary>
        public static class remote_setting
        {
            public static class email_template
            {
                private static String default_title_template = null;
                private static String default_content_template = null;

                public static String DEFAULT_TITLE_TEMPLATE
                {
                    get
                    {
                        if (default_title_template == null)
                        {
                            default_title_template = Setting.getValue("default_title_template");
                        }
                        return default_title_template;
                    }
                    set
                    {
                        default_title_template = value;
                    }
                }
                public static String DEFAULT_CONTENT_TEMPLATE
                {
                    get
                    {
                        if (default_content_template == null)
                        {
                            default_content_template = Setting.getValue("default_content_template");
                        }
                        return default_content_template;
                    }
                    set
                    {
                        default_content_template = value;
                    }
                }
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = Setting.getByKey("default_title_template");
                    obj.value = default_title_template;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("default_content_template");
                    obj.value = default_content_template;
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
                    default_content_template = null;
                }

            }
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
                    obj.value = smtp_port == null ? "0" : smtp_port.ToString();
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
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("ftp_image_username");
                    obj.value = user_name;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("ftp_image_password");
                    obj.value = pass_word;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("ftp_image_prepath");
                    obj.value = pre_path;
                    re = re && obj.addOrUpdate() > 0;

                    obj = Setting.getByKey("ftp_image_port");
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

                private static String host_name = null;
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
                public static Boolean IS_READY
                {
                    get
                    {
                        //force to get all
                        return true;
                    }
                }

            }
            public static class http_host
            {
                public static String getCombinedPath(String relativePath = "")
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
