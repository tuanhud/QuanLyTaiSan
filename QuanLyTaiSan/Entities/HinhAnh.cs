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

        #region Nghiệp vụ
        protected static String cache_path;
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
            //...

            //get ftp info from Global
            if (!Global.remote_setting.ftp_host.IS_READY)
            {
                return null;
            }
            //build abs path
            String abs_path = Path.Combine(
                Global.remote_setting.ftp_host.PRE_PATH,
                this.path
                );

            //stream image from host via FTPHelper
            Bitmap re = FTPHelper.getImage(
                Global.remote_setting.ftp_host.HOST_NAME,
                Global.remote_setting.ftp_host.USER_NAME,
                Global.remote_setting.ftp_host.PASS_WORD,
                abs_path
                );
            //finish
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
