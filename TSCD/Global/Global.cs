using TSCD.Entities;
using SHARED;
using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TSCD
{
    public static partial class Global
    {
        private static QuanTriVien _current_quantrivien_login = null;
        /// <summary>
        /// Dành cho Winform (Quản trị viên sử dụng pâần mềm quản lý)
        /// </summary>
        public static QuanTriVien current_quantrivien_login
        {
            get
            {
                //if (SHARED.Global.WEB_MODE)
                //{
                //    QuanTriVien tmp = HttpContext.Current.Items["current_quantrivien_login"] as QuanTriVien;
                //    if (tmp == null)
                //    {
                //        return null;
                //    }
                //    tmp = tmp.reload();
                //    HttpContext.Current.Items["current_quantrivien_login"] = tmp;
                //    return tmp;
                //}
                //else
                //{
                    //very importance because of OLD DBCONTEXT
                    return _current_quantrivien_login = _current_quantrivien_login == null ? null : _current_quantrivien_login.reload();
                //}
            }
            set
            {
                if (SHARED.Global.WEB_MODE)
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
        
    }
}
