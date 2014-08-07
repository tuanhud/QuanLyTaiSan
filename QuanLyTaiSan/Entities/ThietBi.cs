using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTaiSan.Entities;

namespace QuanLyTaiSan.Entities
{
    [Table("THIETBIS")]
    public class ThietBi:_EntityAbstract2<ThietBi>
    {
        public ThietBi():base()
        {
           
        }
        
		#region Dinh nghia
        [Required]
        public String ten { get; set; }
        /*
         * Ngày mua
         */
        public DateTime? ngaymua { get; set; }
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
        /// <summary>
        /// dựa trên loaichung hay riêng của loại tb mà trả về object ThietBi phù hợp để CTTB gán khi add
        /// </summary>
        /// <param name="loai"></param>
        /// <returns></returns>
        public static ThietBi request(LoaiThietBi loai)
        {
            if (loai == null)
            {
                return new ThietBi();
            }

            ThietBi tmp = null;
            if (loai.loaichung)
            {
                //select thietbi đã có sẵn để tái sử dụng
                tmp = db.THIETBIS.Where(c=>c.loaithietbi_id==loai.id).FirstOrDefault();
                if (tmp != null)
                {
                    return tmp;
                }
            }

            tmp=new ThietBi();
            tmp.loaithietbi = loai;
            
            return tmp;
        }

        public static List<ThietBi> getAllByTypeLoai(bool _loaichung)
        {
            try
            {
                return db.Set<ThietBi>().Where(c => c.loaithietbi.loaichung == _loaichung).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<ThietBi>();
            }
            finally
            {

            }
        }

        public static List<ThietBi> getAllByTypeLoaiNoPhong(bool _loaichung)
        {
            try
            {
                return db.Set<ThietBi>().Where(c => c.loaithietbi.loaichung == _loaichung && c.ctthietbis.Where(e=>e.soluong>0).Count() == 0).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<ThietBi>();
            }
            finally
            {

            }
        }
        
        #endregion

        #region Override method
        /// <summary>
        /// -2: Gỡ TB ra khỏi phòng trước
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            //Nếu thiết bị đó có nằm trong phòng nào đó với SL >0 thì chặn xóa
            if (ctthietbis.Where(c => c.soluong > 0).FirstOrDefault() != null)
            {
                return -2;
            }

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
        public override void onBeforeAdded()
        {
            ngaymua = ngaymua == null ? ServerTimeHelper.getNow() : ngaymua;

            base.onBeforeAdded();
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
        /// <summary>
        /// Tự động add nếu chưa có trong CSDL
        /// </summary>
        /// <returns></returns>
        public override int add()
        {
            //check ràng buộc nghiệp vụ, hạn chế thêm mới nếu là loại chung
            ThietBi tmp = db.THIETBIS.Where(c => c.loaithietbi_id == loaithietbi.id && c.loaithietbi.loaichung == true).FirstOrDefault();
            if (tmp != null)
            {
                this.id = tmp.id;
                return 1;
            }
            return base.add();
        }
        #endregion
    }
}
