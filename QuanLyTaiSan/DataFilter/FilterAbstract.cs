using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.DataFilter
{
    public abstract class FilterAbstract<T>
    {
        public FilterAbstract()
        {

        }
        //public FilterAbstract(OurDBContext db)
        //{
        //    this.db = db;
        //}
        protected OurDBContext db
        {
            get
            {
                return DBInstance.DB;
            }
        }
        //public OurDBContext DB
        //{
            
        //}

        //protected void InitDb()
        //{
        //    if (db == null)
        //    {
        //        db = new OurDBContext();
        //    }
        //}
        /// <summary>
        /// Bắt buộc lớp con phải Override mới có dữ liệu
        /// </summary>
        /// <returns></returns>
        public virtual List<T> getAll()
        {
            return new List<T>();
        }
    }
}
