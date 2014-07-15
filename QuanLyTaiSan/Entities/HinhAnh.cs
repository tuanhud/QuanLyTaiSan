using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyTaiSan.Entities;
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
        #region Dinh nghia
        /*
         * Relative path "FILENAME ONLY"
         */
        [StringLength(255)]
        [Required]
        public String path { get; set; }
        /*
         * FK
         */
        public int? tang_id { get; set; }
        [ForeignKey("tang_id")]
        public virtual Tang tang { get; set; }

        public int? coso_id { get; set; }
        [ForeignKey("coso_id")]
        public virtual CoSo coso { get; set; }

        public int? day_id { get; set; }
        [ForeignKey("day_id")]
        public virtual Dayy day { get; set; }

        public int? nhanvienpt_id { get; set; }
        [ForeignKey("nhanvienpt_id")]
        public virtual NhanVienPT nhanvienpt { get; set; }

        public int? phong_id { get; set; }
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public int? thietbi_id { get; set; }
        [ForeignKey("thietbi_id")]
        public virtual ThietBi thietbi { get; set; }
        #endregion

        #region Nghiệp vụ
        public static String DEFAULT_IMAGE_URL
        {
            get
            {
                return "https://www.google.com.vn/images/srpr/logo11w.png";
            }
        }
        /// <summary>
        /// Lay tat ca cac hinh cua tat ca CoSo
        /// </summary>
        /// <returns></returns>
        public List<HinhAnh> getAllCoSo()
        {
            List<HinhAnh> list = db.HINHANHS.Where(c => c.coso != null).ToList();
            return list;
        }
        /// <summary>
        /// Kiem tra hinh da co tren may Local hay chua
        /// </summary>
        /// <returns></returns>
        private Boolean isCacheExist()
        {
            //TU dong tao Folder cached neu chua co
            FileHelper.createFolderIfNotExist(
                Path.Combine(FileHelper.localPath(),CACHE_PATH)
                );
            return FileHelper.isExist(getCachedPath());
        }
        /// <summary>
        /// Lay Local Path cached cua mot hinh neu co
        /// </summary>
        /// <returns></returns>
        private String getCachedPath()
        {
            return Path.Combine(FileHelper.localPath(), HinhAnh.CACHE_PATH, path);
        }
        [NotMapped]
        protected Bitmap image=null;
        /// <summary>
        /// Trả về URL tuyệt đối của Hình ảnh
        /// </summary>
        /// <returns></returns>
        public String getImageURL()
        {
            return Global.remote_setting.http_host.getCombinedPath(path);
        }
        [NotMapped]
        public Bitmap IMAGE
        {
            get
            {
                //CACHE
                //check inner cached first
                if (image != null)
                {
                    return image;
                }
                //check global RAM repository
                image = ImageCache.get(path);
                if(image!=null)
                {
                    return image;
                }
                //check folder cache
                if (isCacheExist())
                {
                    //load to RAM
                    image = ImageHelper.fromFile(getCachedPath());
                    //register to Global repository
                    ImageCache.register(path,image);

                    return image;
                }
                //get http info from Global
                if (!Global.remote_setting.http_host.IS_READY)
                {
                    return null;
                }
                //build abs path
                String abs_path =
                    Global.remote_setting.http_host.getCombinedPath(this.path);

                //stream image from host via HTTP
                Bitmap re = HTTPHelper.getImage(abs_path);
                this.image = re;

                //Write cached
                if (image != null)
                {
                    this.image.Save(
                        Path.Combine(FileHelper.localPath(), CACHE_PATH, this.path)
                        );
                }
                //finish
                return re;
            }
            set
            {
                image = value;
            }
        }
        [NotMapped]
        protected String file_name = null;
        [NotMapped]
        public String FILE_NAME {
            get
            {
                return file_name;
            }
            set
            {
                file_name = value;
            }
            
        }

        [NotMapped]
        protected int max_size = -1;
        [NotMapped]
        public int MAX_SIZE {
            get
            {
                return this.max_size;
            }
            set
            {
                this.max_size = value;
            }
        }
        [NotMapped]
        protected static String cache_path = "ImageCache";
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
            return IMAGE;
        }

        /// <summary>
        /// Lay tat ca nhung hinh dang su dung, dung getall binh thuong thi se co anh ma tat ca khoa ngoai NULL
        /// </summary>
        public static List<HinhAnh> getAllHinhAnhDangDung()
        {
            return db.HINHANHS.Where(c=>c.path!=null).GroupBy(h => h.path).Select(s => s.FirstOrDefault()).ToList();
        }
        /// <summary>
        /// Kiểm tra this.path (sau khi chạy qua hàm lọc tên) đã có trong CSDL hay chưa

        /// <summary>
        /// Set IMAGE (Bitmap), MAX_SIZE (pixel), FILE_NAME (Tên File nguyên thủy), FK Object(COSO hay PHONG hay ...) truoc
        /// </summary>
        /// <returns>-5: IMAGE, FILE_NAME FAIL, </returns>
        public int upload(Boolean ghide=false)
        {
            if (image == null || file_name.Equals(""))
            {
                return -5;
            }
            //resize hinh neu co
            if (max_size > 0)
            {
                image = ImageHelper.ScaleBySize(image,max_size);
            }
            
            String relative_path = StringHelper.CoDauThanhKhongDau(file_name) + ".JPEG";
            this.path = relative_path;
            //Kiểm tra trùng tên hình, không cho upload nữa nếu CHƯA BẬT GHI ĐÈ
            if (!ghide && db.HINHANHS.Where(c=>c.path.ToUpper().Equals(this.path.ToUpper()))!=null)
            {
                return 1;
            }
            
            //prepare upload
            String abs_path =
                Global.remote_setting.ftp_host.getCombinedPath(this.path);

            //upload hinh va insert vao CSDL
            return FTPHelper.uploadImage(
                image,
                abs_path,
                Global.remote_setting.ftp_host.USER_NAME,
                Global.remote_setting.ftp_host.PASS_WORD
            );
        }
        #endregion

        #region Override method
        public override int update()
        {
            //have to load all [Required] FK object first
            if (tang != null)
            {
                tang.trigger();
            }
            if (coso != null)
            {
                coso.trigger();
            }
            if (day != null)
            {
                day.trigger();
            }
            if (thietbi != null)
            {
                thietbi.trigger();
            }
            if (nhanvienpt != null)
            {
                nhanvienpt.trigger();
            }
            if (phong != null)
            {
                phong.trigger();
            }
            
            //...
            return base.update();
        }
        #endregion
    }
}
