using QuanLyTaiSan.Libraries;
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
        public virtual ICollection<LogSuCoPhong> logsucophongs { get; set; }

        public int? nhanvienpt_id { get; set; }
        [ForeignKey("nhanvienpt_id")]
        public virtual NhanVienPT nhanvienpt { get; set; }
        #endregion
        #region Nghiep vu
        public int chuyenTinhTrang(TinhTrang tinhtrang, String mota="", List<HinhAnh> hinhs=null)
        {
            ////check
            //if (tinhtrang != null && tinhtrang.id == this.tinhtrang_id)
            //{
            //    return -1;
            //}
            //if (tinhtrang == null && this.tinhtrang == null)
            //{
            //    return -1;
            //}
            //DateTime ngay = ServerTimeHelper.getNow();
            //Boolean transac = true;
            //using (var dbContextTransaction = db.Database.BeginTransaction())
            //{
            //    //update
            //    this.tinhtrang = tinhtrang;
            //    transac = transac && this.update()>0;
            //    //writelog
            //    transac = transac && this.writelog(ngay,mota,hinhs) > 0;
                
            //    //final transac controller
            //    if (transac)
            //    {
            //        dbContextTransaction.Commit();
            //    }
            //    else
            //    {
            //        dbContextTransaction.Rollback();
            //    }

            //    return transac ? 1 : -1;
            //}
            return 1;
        }
        private int writelog(DateTime ngay, String mota="", List<HinhAnh> hinhs=null)
        {
//            SuCoPhong obj = new SuCoPhong();
//            obj.phong = this;
//            obj.quantrivien = Global.current_login;
//            obj.tinhtrang = this.tinhtrang;
//            obj.mota = mota;
//            obj.date_create = obj.date_modified = ngay;
////            obj.hinhanhs = hinhs == null ? new List<HinhAnh>() : hinhs;
//            return obj.add();
            return 1;
        }
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
            this.logsucophongs = new List<LogSuCoPhong>();
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
        public override int delete()
        {
            //check constrain
            if (ctthietbis.Count > 0 || logthietbis.Count>0 || logsucophongs.Count>0 || sucophongs.Count>0)
            {
                return -1;
            }

            return base.delete();
        }
        #endregion
    }
}
