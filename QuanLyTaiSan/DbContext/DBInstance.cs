using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public class DBInstance
    {
        private static OurDBContext db = null;
        public static OurDBContext DB
        {
            get
            {
                if (db == null)
                {
                    db = new OurDBContext();
                }
                return db;
            }
        }
        /// <summary>
        /// Bắt buộc phải gọi mới thấy được sự thay đổi CSDL do nơi khác chỉnh sửa,
        /// Tất cả Object get ra bởi DBInstace cũ sẽ phải reload mới có thể tiếp tục sử dụng lại được,
        /// Nếu không Object cũ sẽ vẫn phải chịu sự giám sát của DbContext cũ
        /// </summary>
        public static void reNew()
        {
            db = new OurDBContext();
        }
    }
}
