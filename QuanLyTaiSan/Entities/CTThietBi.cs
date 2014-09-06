using QuanLyTaiSan.Libraries;
using SHARED;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using QuanLyTaiSan.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.Libraries;

namespace QuanLyTaiSan.Entities
{
    [Table("CTTHIETBIS")]
    public class CTThietBi:_EntityAbstract2<CTThietBi>
    {
        public CTThietBi():base()
        {
            
        }

        #region Dinh nghia
        public DateTime? ngay { get; set; }
        [Required]
        public int soluong { get; set; }
        /*
         * FK
         */
        public Guid phong_id { get; set; }
        [Required]
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public Guid thietbi_id { get; set; }        
        [Required]
        [ForeignKey("thietbi_id")]
        public virtual ThietBi thietbi { get; set; }

        public Guid tinhtrang_id { get; set; }
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }
        #endregion
        #region Nghiep vu
        /// <summary>
        /// Readonly
        /// </summary>
        [NotMapped]
        public ICollection<LogThietBi> logthietbis
        {
            get
            {
                return this.thietbi.logthietbis.ToList();//Where(c => c.phong_id == this.phong_id).ToList();
            }
        }
        /// <summary>
        /// Di chuyển, kết hợp đổi tình trạng,
        /// có hỗ trợ ghi LOG tự động,vd:
        /// CTThietBi obj = CTThietBi.getById(24552);
        /// Phong dich = null;// Phong.getById(1228);
        /// TinhTrang ttr = TinhTrang.getById(3);
        /// int re = obj.dichuyen(dich, ttr, -1, "đổi tình trạng toàn bộ luôn");
        /// </summary>
        /// <param name="dich">Phòng cần di chuyển đến (null nếu chỉ muốn đổi tình trạng)</param>
        /// <param name="ttmoi">Tình trạng cần chuyển sang (null nếu chỉ muốn đổi phòng)</param>
        /// <param name="soluong">Số lượng cần chuyển (mac dinh la -1 (chuyển tất cả))</param>
        /// /// <param name="mota">Mô tả cho quá trình di chuyển</param>
        /// <param name="hinhs">Hình mô tả cho quá trình di chuyển (Hình sạch)</param>
        /// <returns></returns>
        public int dichuyen(Phong dich=null, TinhTrang ttmoi=null, int soluong=-1, String mota="", List<HinhAnh> hinhs=null, DateTime? ngay=null)
        {
            //pre set data
            dich = dich == null ? this.phong : dich;
            //=> dich co the van se la null (do this.phong có thể là null)
            ttmoi = ttmoi == null ? this.tinhtrang : ttmoi;//tinh trang không thể null
            ngay = ngay == null ? ServerTimeHelper.getNow() : ngay;
            //XÉT ĐIỀU KIỆN
            if
            (
                //Nếu Không có bất kỳ sự thay đổi nào, phòng và tình trạng giống với this
                ((dich==null && this.phong==null) || (dich!=null && dich.id == this.phong.id))
                && ttmoi.id == this.tinhtrang.id
            )
            {
                return -2;
            }
            //kiem tra rang buoc không cho thực thi
            if
            (
                soluong == 0 || soluong > this.soluong
            )
            {
                return -2;
            }
            soluong = soluong < 0 ? this.soluong : soluong;
            
            //tao hoac cap nhat mot CTTB moi cho PHONG moi (dich)
            //kiem tra co record nao trung với record cần tạo mới (dich, tinhtrang, thietbi) ?
            CTThietBi tmp = search(dich, this.thietbi, ttmoi);

            //NO
            //TAO MOI CTTB => add
            if (tmp == null)
            {
                tmp = new CTThietBi();
                tmp.phong = dich;
                tmp.soluong = soluong;
                tmp.thietbi = this.thietbi;
                tmp.tinhtrang = ttmoi;
                tmp.mota = mota;
                tmp.hinhanhs = hinhs;
                tmp.ngay = ngay;
                tmp.add();
            }
            else
            {
                //Đã có CTTB sẵn giống với CTTB cần tạo mới
                //SELECT CTTB do len => update
                if (tmp.id != this.id)
                {
                    tmp.soluong += soluong;
                    tmp.mota = mota;
                    tmp.hinhanhs = hinhs;
                    tmp.ngay = ngay;
                    tmp.update();
                }
            }

            //cap nhat lai so luong cho cái hiện đã bị chuyển
            this.mota = mota;
            this.soluong -= soluong;
            this.soluong = this.soluong < 0 ? 0 : this.soluong;//for sure
            this.hinhanhs = hinhs;
            //ghi log thietbi ngay sau khi cap nhat ONLY soluong
            this.update();
            return 1;
        }
        /// <summary>
        /// Kich hoat ham ghi log vao LogThietBi
        /// </summary>
        private int writelog()
        {
            //ghi log thiet bi
            LogThietBi logtb = new LogThietBi();
            logtb.mota = this.mota;
            logtb.phong = this.phong;
            logtb.soluong = this.soluong;
            logtb.thietbi = this.thietbi;
            logtb.tinhtrang = this.tinhtrang;
            logtb.hinhanhs = hinhanhs;
            logtb.quantrivien = Global.current_quantrivien_login;
            return logtb.add();
        }
        /// <summary>
        /// Tìm kiếm thiết bị với 3 yếu tố
        /// </summary>
        /// <param name="ph"></param>
        /// <param name="tb"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public static CTThietBi search(Phong ph, ThietBi tb, TinhTrang tr)
        {
            IQueryable<CTThietBi> query = db.CTTHIETBIS.AsQueryable();
            if (ph == null)
            {
                query = query.Where(c => c.phong_id == null);
            }
            else
            {
                query = query.Where(c => c.phong_id == ph.id);
            }
            query = query.Where(c => c.thietbi_id == tb.id && c.tinhtrang_id == tr.id);
            
            return query.FirstOrDefault();
        }
        /// <summary>
        /// deprecated
        /// </summary>
        /// <param name="idTinhTrang"></param>
        /// <returns></returns>
        public static List<ThietBi> listThietBiTheoTinhTrang(Guid idTinhTrang)
        {
            return db.CTTHIETBIS.Where(ct => ct.tinhtrang.id == idTinhTrang).Select(select => select.thietbi).ToList();
        }
        
        #endregion

        #region Override method
        public override string niceName()
        {
            try
            {
                return soluong + " " + thietbi.niceName() + ", " + phong.niceName() + ", " + tinhtrang.niceName();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "ERROR";
            }
        }
        /// <summary>
        /// Có hỗ trợ ghi log, phát sinh tự động thietbi hay không ? dựa trên loaichung hay riêng của loaithietbi,
        /// Tự động có transaction
        /// A. Trường hợp thêm Thiết bị vào phòng mà chỉ chọn: Loại thiết bị
        /// 
        /// CTThietBi obj = new CTThietBi();
        /// obj.thietbi = ThietBi.request(loaithietbi);
        /// obj.phong = phong;
        /// obj.tinhtrang = tinhtrang;
        /// obj.soluong=soluong;
        /// obj.mota=mota;
        /// obj.hinhanhs = hinhs;
        /// obj.add();
        /// 
        /// B. Trường hợp thêm Thiết bị vào phòng chọn được: Thiết bị
        /// 
        /// CTThietBi obj = new CTThietBi();
        /// obj.thietbi = thietbi;
        /// obj.phong = phong;
        /// obj.tinhtrang = tinhtrang;
        /// obj.soluong=soluong;
        /// obj.mota=mota;
        /// obj.hinhanh = hinhs;//Hình sạch
        /// obj.add();
        /// </summary>
        /// <returns></returns>
        public override int add()
        {
            this.ngay = this.ngay==null?ServerTimeHelper.getNow():this.ngay;
            //SCRIPT
            CTThietBi tmp = search(phong, thietbi, tinhtrang);
            //Nếu có CTTB sẵn trùng Phòng, Thiết bị, Tình trạng thì cộng dồn SL vào và update
            if (tmp != null)
            {
                tmp.soluong += soluong;
                tmp.ngay = this.ngay;
                tmp.mota = this.mota;
                tmp.hinhanhs = hinhanhs;
                //call update on tmp
                tmp.update();
                //id = tmp.id;
            }
            else
            {
                base.add();
                writelog();
            }
            return 1;
        }
        /// <summary>
        /// Có hỗ trợ ghi log, có hỗ trợ transaction
        /// </summary>
        /// <param name="ngay"></param>
        /// <param name="in_transaction"></param>
        /// <returns></returns>
        public override int update()
        {
            
            base.update();
            writelog();
            return 1;
        }
        public override int delete()
        {
            //trước khi delete phải ghi log
            Phong backup = Phong.getById(phong.id);
            this.phong = null;
            
            writelog();
            
            this.phong = backup;

            return base.delete();
        }
        #endregion
    }
}
