using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public static class Global
    {
        public static QuanTriVien current_login { get; set; }
        /// <summary>
        /// Những cài đặt được lưu ở phía ứng dụng
        /// </summary>
        internal static Properties.Settings local_setting
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
                }
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = new Setting().getByKey("ftp_image_host");
                    obj.value = host_name;
                    re = re && obj.addOrUpdate()>0;

                    obj = new Setting().getByKey("ftp_image_username");
                    obj.value = user_name;
                    re = re && obj.addOrUpdate()>0;

                    obj = new Setting().getByKey("ftp_image_password");
                    obj.value = pass_word;
                    re = re && obj.addOrUpdate()>0;

                    obj = new Setting().getByKey("ftp_image_prepath");
                    obj.value = pre_path;
                    re = re && obj.addOrUpdate()>0;

                    if (re)
                    {
                        reload();
                    }
                    return re?1:0;
                }
                private static String host_name=null;
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            //host_name = new Setting().getValue("ftp_image_host");
                            host_name = "ftp://hoangthanhit.com";
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
                            //user_name = new Setting().getValue("ftp_image_username");
                            user_name = "qlts@hoangthanhit.com";
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
                            //pass_word = new Setting().getValue("ftp_image_password");
                            pass_word = "quanlytaisan";
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
                            //pre_path = new Setting().getValue("ftp_image_prepath");
                            pre_path = "/";
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
                    pre_path = null;
                }
                public static int save()
                {
                    Boolean re = true;
                    Setting obj = new Setting().getByKey("http_image_host");
                    obj.value = host_name;
                    re = re && obj.addOrUpdate() > 0;

                    obj = new Setting().getByKey("http_image_prepath");
                    obj.value = pre_path;
                    re = re && obj.addOrUpdate() > 0;

                    if (re)
                    {
                        reload();
                    }
                    return re ? 1 : 0;
                }
                private static String host_name = null;
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            //host_name = new Setting().getValue("http_image_host");
                            host_name = "http://hoangthanhit.com";
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
                            //pre_path = new Setting().getValue("http_image_prepath");
                            pre_path = "/qlts/";
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
