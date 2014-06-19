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
                private static String host_name=null;
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            host_name = "ftp://ftpts.hoangthanhit.com";
                        }
                        return host_name;
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
                            user_name = "hthanh-001";
                        }
                        return user_name;
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
                            pass_word = "quanlytaisan";
                        }
                        return pass_word;
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
                            pre_path = "/site1/_hinhanh/";
                        }
                        return pre_path;
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
                private static String host_name = null;
                public static String HOST_NAME
                {
                    get
                    {
                        if (host_name == null)
                        {
                            //load from DB
                            host_name = "http://ts.hoangthanhit.com";
                        }
                        return host_name;
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
                            pre_path = "/_hinhanh/";
                        }
                        return pre_path;
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
