﻿using QuanLyTaiSan.Libraries;
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
        
        #region Dinh nghia
        [Index("nothing", IsUnique = true)]
        [Required]
        [StringLength(255)]
        public String ten { get; set; }
        /*
         * FK
         */
        public int vitri_id { get; set; }
        [Required]
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }

        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
        public virtual ICollection<SuCoPhong> sucophongs { get; set; }

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
        }
        public static List<Phong> getPhongByViTri(int _cosoid, int _dayid, int _tangid)
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
            this.sucophongs = new List<SuCoPhong>();
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
        /// <summary>
        /// -2: TB, -3: Sự cố, 
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            //Nếu trong phòng vẫn còn ít nhất 1 TB với SL >0 thì không thể xóa
            if (ctthietbis.Where(c => c.soluong > 0).FirstOrDefault() != null)
            {
                return -2;
            }
            //Nếu trong phòng còn sự cố
            if (sucophongs.Count>0)
            {
                return -3;
            }
            //======================================================
            //được quyền xóa tất cả
            if (ctthietbis != null)
            {
                while (ctthietbis.Count > 0)
                {
                    ctthietbis.FirstOrDefault().delete();
                }
            }
            //xóa log luôn, do khi xóa CTTB thì KHÔNG xóa LOG, nên nhiệm vụ được giao cho xóa TB
            if (logthietbis != null)
            {
                while (logthietbis.Count > 0)
                {
                    logthietbis.FirstOrDefault().delete();
                }
            }

            return base.delete();
        }
        #endregion
    }
}
