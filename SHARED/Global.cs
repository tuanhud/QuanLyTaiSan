using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static bool WEB_MODE { get; set; }
    }
}
