using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.DataFilter
{
    public class PhongFilter:FilterAbstract<PhongFilter>
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
        /// <summary>
        /// Rỗng nếu không có Cơ sở
        /// </summary>
        public String ten_coso { get; set; }
        /// <summary>
        /// Rỗng nếu không có Dãy
        /// </summary>
        public String ten_day { get; set; }
        /// <summary>
        /// Rỗng nếu không có Tầng
        /// </summary>
        public String ten_tang { get; set; }
        /*
         * FK Object
         */
        public Phong phong { get; set; }
        public CoSo coso { get; set; }
        public Tang tang { get; set; }
        public Dayy day { get; set; }
        #region Nghiệp vụ
        public override List<PhongFilter> getAll()
        {
            InitDb();
            List<PhongFilter> re =
                (from p in db.PHONGS
                 join vt in db.VITRIS on p.vitri equals vt into p_vt_
                 from p_vt in p_vt_
                 select new PhongFilter
                 {
                     id=p.id,
                     ten = p.ten,
                     ten_coso = p_vt.coso==null?"":p_vt.coso.ten,
                     ten_day = p_vt.day==null?"":p_vt.day.ten,
                     ten_tang = p_vt.tang == null ? "" : p_vt.tang.ten,
                     tang = p_vt.tang,
                     day = p_vt.day,
                     coso = p_vt.coso
                 }).ToList();
            return re;
        }
        #endregion
    }
}
