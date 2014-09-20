using PTB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB
{
    public static partial class Global
    {
        public static class sync
        {
            public static String scope_name
            {
                get
                {
                    return SHARED.Global.sync.scope_name;
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

    }
}
