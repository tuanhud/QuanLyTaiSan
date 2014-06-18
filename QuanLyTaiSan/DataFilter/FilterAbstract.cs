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
        public FilterAbstract(MyDB db)
        {
            this.db = db;
        }
        protected MyDB db = null;
        public MyDB DB
        {
            get
            {
                InitDb();
                return db;
            }
            set
            {
                db = value;
            }
        }

        protected void InitDb()
        {
            if (db == null)
            {
                db = new MyDB();
            }
        }
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
