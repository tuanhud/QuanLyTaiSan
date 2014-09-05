using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public abstract class FilterAbstract<T>
    {
        public FilterAbstract()
        {

        }
        protected static OurDBContext db
        {
            get
            {
                return DBInstance.DB;
            }
        }
    }
}
