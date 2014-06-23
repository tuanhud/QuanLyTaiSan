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
        //public HinhAnh(MyDB db)
        //    : base(db)
        //{
            
        //}
        #region Dinh nghia
        /*
         * Relative path
         */
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
        #endregion

        #region Nghiệp vụ
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
        [NotMapped]
        public Bitmap IMAGE
        {
            get
            {
                //CACHE
                //check RAM cached first
                if (image != null)
                {
                    return image;
                }
                //check folder cache
                if (isCacheExist())
                {
                    //load to RAM
                    image = ImageHelper.fromFile(getCachedPath());
                    return image;
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
                this.image = re;
                //Write cached
                this.image.Save(
                    Path.Combine(FileHelper.localPath(),CACHE_PATH,this.path)
                    );
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
        protected static String cache_path = "cached_image";
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

        public List<HinhAnh> getAllBy6Id(int id1, int id2, int id3, int id4, int id5, int id6)
        {
            //MyDB db = new MyDB();
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
        /// <summary>
        /// Tự động tìm trên Table HinhAnh và xóa những hình không hợp lệ,
        /// Tự động xóa các hình không cần thiết trên Server FTP,
        /// vd: (tất cả mọi trường khóa ngoại đều null, hoặc tên hình bị rỗng,...)
        /// </summary>
        public void validate()
        {
            //Xoa hinh tren FTP Server neu ton tai
            //String abs_path =
            //    Global.remote_setting.ftp_host.HOST_NAME +
            //    Global.remote_setting.ftp_host.PRE_PATH +
            //    this.path;
            //FTPHelper.deleteFile(abs_path, Global.remote_setting.ftp_host.USER_NAME, Global.remote_setting.ftp_host.PASS_WORD);
            
            List<HinhAnh> re = db.HINHANHS.Where(
                c =>
                    (c.phong.id == null
                    && c.tang.id == null
                    && c.nhanvienpt.id == null
                    && c.thietbi.id == null
                    && c.coso.id == null
                    && c.day.id == null
                    )
                    || c.path==""
                    ).ToList();
            foreach (HinhAnh item in re)
            {
                item.delete();
            }
        }

        /// <summary>
        /// Lay tat ca nhung hinh dang su dung, dung getall binh thuong thi se co anh ma tat ca khoa ngoai NULL
        /// </summary>
        public List<HinhAnh> getAllHinhAnhDangDung()
        {
            //MyDB db = new MyDB();
            List<HinhAnh> re = db.HINHANHS.Where(c => (c.coso.id != null) || (c.day.id != null) || (c.tang.id != null)
                 || (c.phong.id != null) || (c.thietbi.id != null) || (c.nhanvienpt.id != null)).ToList().GroupBy(h => h.path).Select(s => s.FirstOrDefault()).ToList();
            return re;
        }
        /// <summary>
        /// Kiểm tra this.path (sau khi chạy qua hàm lọc tên) đã có trong CSDL hay chưa
        /// </summary>
        /// <param name="ghide"></param>
        /// <returns></returns>
        private Boolean canBeSaved(Boolean ghide=false)
        {
            //Kiem tra trong CSDL co hinh trung ten
            HinhAnh tmp2 = db.HINHANHS.FirstOrDefault(c => c.path == path);
            if (tmp2 == null)
            {

            }
            else if (ghide)
            {

            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Set IMAGE (Bitmap), MAX_SIZE (pixel), FILE_NAME (Tên File nguyên thủy), FK Object(COSO hay PHONG hay ...) truoc
        /// </summary>
        /// <returns></returns>
        public int upload(Boolean ghide=false)
        {
            Bitmap tmp = image;
            //resize hinh neu co
            if (max_size > 0)
            {
                tmp = ImageHelper.ScaleBySize(image,max_size);
                image = tmp;//for sure
            }
            //tao duong dan upload len FTP
            //String relative_path = ServerTimeHelper.getNow().ToString("yyyy-MM-dd_HH-mm-ss")+"_"+
            //StringHelper.CoDauThanhKhongDau(file_name) +".JPEG";//Always JPEG
            String relative_path = StringHelper.CoDauThanhKhongDau(file_name) + ".JPEG";
            this.path = relative_path;
            //Kiểm tra trùng tên hình, không cho upload
            if (!canBeSaved())
            {
                return -5;
            }
            
            //prepare upload
            String abs_path
                =
                Global.remote_setting.ftp_host.HOST_NAME +
                Global.remote_setting.ftp_host.PRE_PATH +
                relative_path;
            //upload hinh va insert vao CSDL
            FTPHelper.uploadImage(
                tmp,
                abs_path,
                Global.remote_setting.ftp_host.USER_NAME,
                Global.remote_setting.ftp_host.PASS_WORD
                );
            
            //return this.add();
            //finish
            image = tmp;
            return 1;
        }
        #endregion

        #region Override method
        protected override void init()
        {
            base.init();
            cache_path = "ImageCache";
        }
        
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

        public HinhAnh getByName(String _name)
        {
            try
            {
                //initDb();
                HinhAnh obj = db.Set<HinhAnh>().Where(c => c.file_name == _name).FirstOrDefault();
                //if (obj != null)
                //{
                //    obj.DB = db;
                //}
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        #endregion
    }
}
