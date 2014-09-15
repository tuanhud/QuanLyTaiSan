using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    [Table("PHONGS")]
    public class Phong:_EntityAbstract1<Phong>
    {
        public Phong():base()
        {
            
        }
        
        #region Dinh nghia
        [Index("nothing", IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }
        /*
         * FK
         */
        public Guid loaiphong_id { get; set; }
        [Required]
        [ForeignKey("loaiphong_id")]
        public virtual LoaiPhong loaiphong { get; set; }

        public Guid vitri_id { get; set; }
        [Required]
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }

        #endregion
        #region Nghiep vu
        public static List<Phong> getPhongByViTri(Guid _cosoid, Guid _dayid, Guid _tangid)
        {
            List<Phong> re =
                (from c in db.PHONGS
                 where ((_cosoid == Guid.Empty || c.vitri.coso.id == _cosoid) && (_dayid == Guid.Empty || c.vitri.day.id == _dayid) && (_tangid == Guid.Empty || c.vitri.tang.id == _tangid))
                 select c).OrderBy(p=>p.ten).ToList();
            return re;
        }

        public List<Phong> getPhongByViTri(ViTri obj)
        {
            List<Phong> re =
                (from c in db.PHONGS
                 where (c.vitri == obj)
                 select c).OrderBy(p => p.ten).ToList();
            return re;
        }

        #endregion
        #region Override
        public static new String VNNAME
        {
            get
            {
                return "PHÒNG";
            }
        }
        public override string niceName()
        {
            return VNNAME + ": " + ten + ", " + vitri.niceName();
        }
        public override int update()
        {
            //if (vitri != null)
            //{
            //    vitri.trigger();
            //}
            return base.update();
        }
        #endregion
    }
}
