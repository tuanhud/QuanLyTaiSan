using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("PHONGS")]
    public class Phong:_EntityAbstract2<Phong>
    {
        public Phong():base()
        {
            
        }
        //public Phong(MyDB db)
        //    : base(db)
        //{
            
        //}
        
        #region Dinh nghia
        /*
         * FK
         */
        public int vitri_id { get; set; }
        [Required]
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }
        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }

        public int? nhanvienpt_id { get; set; }
        [ForeignKey("nhanvienpt_id")]
        public virtual NhanVienPT nhanvienpt { get; set; }
        #endregion
        #region Nghiep vu
        public int countThietBi()
        {
            IQueryable<CTThietBi> v = (from cttb in db.CTTHIETBIS
                                       join ph in db.PHONGS on cttb.phong equals ph
                                       where ph.id == this.id
                                       select cttb);
            int count = v.Select(x => x.thietbi).Distinct().Count();
            return count;
            //OLD
            //List<ThietBi> list = new List<ThietBi>();
            //foreach (CTThietBi item in ctthietbis)
            //{
            //    if (!list.Contains(item.thietbi))
            //    {
            //        list.Add(item.thietbi);
            //    }
            //}
            //return list.Count;
        }
        public List<Phong> getPhongByViTri(int _cosoid, int _dayid, int _tangid)
        {
            List<Phong> re =
                (from c in db.PHONGS
                 where ((_cosoid == -1 || c.vitri.coso.id == _cosoid) && (_dayid == -1 || c.vitri.day.id == _dayid) && (_tangid == -1 || c.vitri.tang.id == _tangid))
                 select c).ToList();
            return re;
        }

        public List<Phong> getPhongByViTri(ViTri obj)
        {
            List<Phong> re =
                (from c in db.PHONGS
                 where (c.vitri == obj)
                 select c).ToList();
            return re;
        }

        #endregion
        #region Override
        protected override void init()
        {
            base.init();
            this.ctthietbis = new List<CTThietBi>();
            this.logthietbis = new List<LogThietBi>();
        }
        public override int update()
        {
            if (vitri != null)
            {
                vitri.trigger();
            }
            if (nhanvienpt != null)
            {
                nhanvienpt.trigger();
            }
            return base.update();
        }
        #endregion
    }
}
