using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SHARED
{
    public static class Global
    {
        public static class sync
        {
            public static String scope_name
            {
                get
                {
                    return "QLTSScope";
                }
            }
        }

        //private static bool web_mode = false;
        public static bool WEB_MODE
        {
            get
            {
                return HttpContext.Current != null;
            }
        }
        //private static bool web_mode = false;
        private static Boolean use_app_config = false;
        public static bool USE_APP_CONFIG
        {
            get
            {
                return use_app_config;
            }
            set
            {
                use_app_config = value;
            }
        }
    }
}
