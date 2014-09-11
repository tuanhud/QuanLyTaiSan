using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public abstract class _FilterAbstract<T>
    {
        public _FilterAbstract()
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
