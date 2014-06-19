using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("HINHANHS")]
    public class HinhAnh : _EntityAbstract1<HinhAnh>
    {
        public HinhAnh():base()
        {

        }
        public HinhAnh(MyDB db)
            : base(db)
        {
            
        }
        /*
         * Relative path
         */
        [Required]
        [Index(IsUnique = true)]
        [StringLength(255)]
        public String path { get; set; }
        /*
         * FK
         */
        public virtual Tang tang { get; set; }
        public virtual CoSo coso { get; set; }
        public virtual Dayy day { get; set; }
        public virtual NhanVienPT nhanvienpt { get; set; }
        public virtual Phong phong { get; set; }
        public virtual ThietBi thietbi { get; set; }

        #region Nghiệp vụ
        [NotMapped]
        protected Bitmap cached_image=null;
        [NotMapped]
        protected static String cache_path;
        [NotMapped]
        public static String CACHE_PATH
        {
            get
            {
                return cache_path;
            }
        
        }
        /// <summary>
        /// Hàm đồng bộ (phải chờ để load hình),
        /// Tài khoản FTP được cấu hình trong
        /// Global.remote_setting.ftp_host
        /// </summary>
        /// <returns>null: Chưa load được tài khoản FTP, hình không tồn tại</returns>
        public Bitmap getImage() 
        {
            //check cached first
            if (cached_image != null)
            {
                return cached_image;
            }

            //get http info from Global
            if (!Global.remote_setting.http_host.IS_READY)
            {
                return null;
            }
            //build abs path
            String abs_path =
                Global.remote_setting.http_host.HOST_NAME +
                Global.remote_setting.http_host.PRE_PATH +
                this.path;

            //stream image from host via FTPHelper
            Bitmap re = HTTPHelper.getImage(abs_path);
            this.cached_image = re;
            //finish
            return re;
        }

        public List<HinhAnh> getAllBy6Id(int id1, int id2, int id3, int id4, int id5, int id6)
        {
            MyDB db = new MyDB();
            List<HinhAnh> re =
                (from c in db.HINHANHS
                 where ((id1 == -1 || c.coso.id == id1) && (id2 == -1 || c.day.id == id2) && (id3 == -1 || c.tang.id == id3) 
                 && (id4 == -1 || c.phong.id == id4) && (id5 == -1 || c.thietbi.id == id5) && (id6 == -1 || c.nhanvienpt.id == id6))
                 select new HinhAnh
                 {
                    id = c.id,
                    path = c.path
                 }).ToList();
            return re;
        }
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            cache_path = "ImageCache";
        }
        #endregion
    }
}
