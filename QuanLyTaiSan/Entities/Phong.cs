using PTB.Libraries;
using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Entities
{
    [Table("PHONGS")]
    public class Phong:_EntityAbstract2<Phong>
    {
        public Phong():base()
        {
            
        }
        
        #region Dinh nghia
        public String ten { get; set; }
        /*
         * FK
         */
        public Guid vitri_id { get; set; }
        [Required]
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }

        public virtual ICollection<CTThietBi> ctthietbis { get; set; }
        public virtual ICollection<LogThietBi> logthietbis { get; set; }
        public virtual ICollection<SuCoPhong> sucophongs { get; set; }

        public virtual ICollection<Permission> permissions { get; set; }

        public Guid? nhanvienpt_id { get; set; }
        [ForeignKey("nhanvienpt_id")]
        public virtual NhanVienPT nhanvienpt { get; set; }

        public Guid? quantrivien_id { get; set; }
        [ForeignKey("quantrivien_id")]
        public virtual QuanTriVien quantrivien { get; set; }
        #endregion
        #region Nghiep vu

        #endregion
        #region Override
        public static new string VNNAME
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
        
        protected override void init()
        {
            base.init();
            this.ctthietbis = new List<CTThietBi>();
            this.logthietbis = new List<LogThietBi>();
            this.sucophongs = new List<SuCoPhong>();
        }
        public override void doTrigger()
        {
            if (vitri != null)
            {
                vitri.trigger();
            }
            if (nhanvienpt != null)
            {
                nhanvienpt.trigger();
            }
            if (quantrivien != null)
            {
                quantrivien.trigger();
            }
            base.doTrigger();
        }
        /// <summary>
        /// -2: TB, -3: Sự cố, 
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            try
            {
                //Nếu trong phòng vẫn còn ít nhất 1 TB với SL >0 thì không thể xóa
                if (ctthietbis.Where(c => c.soluong > 0).Count() > 0)
                {
                    return -2;
                }
                //Nếu trong phòng còn sự cố
                if (sucophongs.Count > 0)
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
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }
        #endregion
    }
}
