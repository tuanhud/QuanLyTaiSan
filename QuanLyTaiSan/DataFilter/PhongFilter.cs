using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class PhongFilter
    {
        public int id { get; set; }
        public String ten { get; set; }
        public String tencoso { get; set; }
        public String tenday { get; set; }
        public String tentang { get; set; }

        #region Nghiệp vụ
        public List<PhongFilter> getAll()
        {
            MyDB db = new MyDB();
            List<PhongFilter> re =
                (from p in db.PHONGS
                 join v in db.VITRIS on p.vitri.id equals v.id
                 join c in db.COSOS on v.coso.id equals c.id
                 join d in db.DAYYS on v.day.id equals d.id
                 join t in db.TANGS on v.tang.id equals t.id
                 select new PhongFilter
                 {
                     id = p.id,
                     ten = p.ten,
                     tencoso = c.ten,
                     tenday = d.ten,
                     tentang = t.ten
                 }).ToList();
            return re;
        }
        #endregion
    }
}
