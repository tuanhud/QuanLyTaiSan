using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTB_WEB.Libraries
{
    public class DrawTreeHelper
    {
        public class TreeThietBi
        {
            public string id { get; set; }
            public string ten { get; set; }
            public string parent_id { get; set; }

            public TreeThietBi(string id, string ten, string parent_id)
            {
                this.id = id;
                this.ten = ten;
                this.parent_id = parent_id;
            }

            public TreeThietBi()
            {
                id = "";
                ten = "";
                parent_id = "";
            }
        }
    }
}