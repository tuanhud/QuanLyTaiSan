using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class PhongFilter:FilterAbstract
    {
        public PhongFilter():base()
        {

        }
        public PhongFilter(MyDB db)
            : base(db)
        {

        }

        public int id { get; set; }
        public String ten { get; set; }
        public String ten_coso { get; set; }
        public String ten_day { get; set; }
        public String ten_tang { get; set; }
        /*
         * FK Object
         */
        public Phong phong { get; set; }
        public CoSo coso { get; set; }
        public Tang tang { get; set; }
        #region Nghiệp vụ
        public List<PhongFilter> search()
        {
            InitDb();
            List<PhongFilter> re =
                (from p in db.PHONGS
                 join vt in db.VITRIS on p.vitri equals vt
                 join cs in db.COSOS on vt.coso equals cs
                 join da in db.DAYYS on vt.day equals da
                 join ta in db.TANGS on vt.tang equals ta
                 select new PhongFilter
                 {
                     ten = p.ten,
                     ten_coso = cs.ten,
                     ten_day = da.ten,
                     ten_tang = ta.ten,
                     tang = ta,
                     phong = p,
                     coso = cs,
                 }).ToList();
            return re;
        }
        #endregion
    }
}
