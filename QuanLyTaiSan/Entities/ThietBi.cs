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
    [Table("THIETBIS")]
    public class ThietBi:_EntityAbstract2<ThietBi>
    {
        public ThietBi():base()
        {
           
        }
        
		#region Dinh nghia
        /*
         * Ngày mua
         */
        public DateTime? ngaymua { get; set; }
        /*
         * Ngày đưa vào sử dụng, ngày lắp
         */
        public DateTime? ngaylap { get; set; }
        /*
         * FK
         */
        public int loaithietbi_id { get; set; }
        [Required]
        [ForeignKey("loaithietbi_id")]
        public virtual LoaiThietBi loaithietbi { get; set; }

        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
		#endregion

        #region Nghiep vu
        public int add_auto(LoaiThietBi ltb, Phong ph, TinhTrang ttr, int sl=1, String mota="")
        {
            Boolean trans = true;
            using (var dbTransac = db.Database.BeginTransaction())
            {
                if (ltb.loaichung)
                {
                    loaithietbi = ltb;

                    //new
                    CTThietBi cttb = new CTThietBi().request(this, ph, ttr);
                    cttb.soluong = sl;
                    //call add
                    trans = trans && cttb.add() > 0;

                    //assign
                    ctthietbis.Add(cttb);

                    //save
                    trans = trans && this.add() > 0;
                }
                else
                {
                    
                }
            }

            return -1;
        }
        #endregion

        #region Override method
        public override int delete()
        {
            return base.delete();
        }
        public override int update()
        {
            //have to load all [Required] FK object first
            if (loaithietbi != null)
            {
                loaithietbi.trigger();
            }
            
            //...
            return base.update();
        }
        protected override void init()
        {
            base.init();
            this.ctthietbis = new List<CTThietBi>();
            this.logthietbis = new List<LogThietBi>();
        }
        public override int add()
        {
            //time
            ngaymua = ngaymua == null ? ServerTimeHelper.getNow() : ngaymua;
            ngaylap = ngaylap == null ? ServerTimeHelper.getNow() : ngaylap;

            return base.add();
        }
        #endregion
    }
}
