using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TSCD.Entities
{
    /// <summary>
    /// Lưu sự phân bổ hiện tại của tài sản
    /// </summary>
    [Table("CTTAISANS")]
    public class CTTaiSan : _EntityAbstract1<CTTaiSan>
    {
        public CTTaiSan()
            : base()
        {

        }
        #region Định nghĩa
        /// <summary>
        /// Ghi chú sự thay đổi (khi chuyển đơn vị, chuyển tình trạng, sửa mô tả ...)
        /// </summary>
        public String ghichu { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        [Required]
        public int soluong { get; set; }
        
        /// <summary>
        /// Mô tả về nguồn gốc của tài sản này
        /// </summary>
        public String nguongoc { get; set; }
        /// <summary>
        /// Ngày cấp, ngày có hiệu lực
        /// </summary>
        public DateTime? ngay { get; set; }
        /// <summary>
        /// Mã chứng từ
        /// </summary>
        public String chungtu_sohieu { get; set; }
        /// <summary>
        /// Ngày chứng từ
        /// </summary>
        public DateTime? chungtu_ngay { get; set; }

        /*
         * FK
         */
        public Guid? donviquanly_id { get; set; }
        /// <summary>
        /// Đơn vị chịu trách nhiệm quản lý, nullable
        /// </summary>
        [ForeignKey("donviquanly_id")]
        public virtual DonVi donviquanly { get; set; }

        public Guid? donvisudung_id { get; set; }
        /// <summary>
        /// Cá nhân sử dụng, nullable
        /// </summary>
        [ForeignKey("donvisudung_id")]
        public virtual DonVi donvisudung { get; set; }

        public Guid tinhtrang_id { get; set; }
        /// <summary>
        /// Tình trạng hiện tại, not null
        /// </summary>
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }

        public Guid? vitri_id { get; set; }
        /// <summary>
        /// Vị trí hiện tại của tài sản (CS, Dãy, Tầng), nullable
        /// </summary>
        [ForeignKey("vitri_id")]
        public virtual ViTri vitri { get; set; }

        public Guid? phong_id { get; set; }
        /// <summary>
        /// Phòng hiện tại (nếu có phòng thì khỏi chỉ định vi trí cũng được)
        /// </summary>
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public Guid taisan_id { get; set; }
        /// <summary>
        /// Thuộc tài sản
        /// </summary>
        [ForeignKey("taisan_id")]
        [Required]
        public virtual TaiSan taisan { get; set; }

        public Guid? parent_id { get; set; }
        /// <summary>
        /// Tài sản có thể chứa bên trong nhiều tài sản khác
        /// </summary>
        [ForeignKey("parent_id")]
        public virtual CTTaiSan parent { get; set; }

        /// <summary>
        /// Tài sản bên trong nó
        /// </summary>
        public virtual ICollection<CTTaiSan> childs { get; set; }
        #endregion

        #region Nghiệp vụ
        /// <summary>
        /// Chuyển tình trạng, vd báo giảm tài sản khi -> Thanh lý (Thanh lý.giam_taisan = true)
        /// </summary>
        /// <returns></returns>
        public int chuyenTinhTrang(
            DateTime chungtu_ngay_moi,
            String chungtu_sohieu_moi,
            TinhTrang tinhtrang_moi)
        {
            Boolean re = true;
            //xét ràng buộc
            if(tinhtrang_moi==null)
            {
                return -1;
            }
            //this đã bị báo là giảm tài sản rồi, không cho chuyển ngược lại
            if(this.tinhtrang.giam_taisan)
            {
                return -1;
            }
            //begin common business
            this.chungtu_ngay = chungtu_ngay_moi;
            this.chungtu_sohieu = chungtu_sohieu_moi;
            this.tinhtrang = tinhtrang_moi;
            re = re && this.update()>0;
            //nếu tình trạng hiểu là sự giảm => ghi log sự giảm
            if(tinhtrang_moi.giam_taisan)
            {
                LogTangGiamTaiSan log = this.generateLogTangGiamTaiSan();
                log.tang_giam = -1;
                log.tang_giam_donvi = -1;
                log.chuyenden_chuyendi = 0;//importance, do chỉ là đổi tình trạng trong cùng 1 đơn vị
                re = re && log.add()>0;
            }
            //end
            return re ? 1 : -1;
        }
        /// <summary>
        /// Chuyển đổi đơn vị quản lý, nhung KHÔNG cho phép kèm tình trạng,
        /// chuyển tình trạng dùng hàm riêng
        /// </summary>
        /// <param name="quanly_moi"></param>
        /// <param name="sudung_moi"></param>
        /// <param name="vitri_moi"></param>
        /// <param name="phong_moi"></param>
        /// <param name="chungtu_ngay_moi"></param>
        /// <param name="chungtu_sohieu_moi"></param>
        /// <param name="soluong_moi"></param>
        /// <param name="ghichu_moi"></param>
        /// <param name="ngay_moi"></param>
        /// <returns></returns>
        public int chuyenDonVi(
            DonVi donviquanly_moi,
            DonVi donvisudung_moi,
            ViTri vitri_moi,
            Phong phong_moi,
            CTTaiSan cttaisan_parent_moi,
            DateTime? chungtu_ngay_moi,
            String chungtu_sohieu_moi,
            int soluong_moi=-1,
            String ghichu_moi="",
            DateTime? ngay_moi=null)
        {
            Boolean re = true;
            
            //Kiem tra rang buoc
            //So luong chuyen phai hop le
            if (soluong_moi > this.soluong)
            {
                return -1;
            }
            //tự chuyển đổi
            if(soluong_moi<0)
            {
                soluong_moi = this.soluong;
            }
            //begin business
            Boolean cungdonviquanly = donviquanly != null && donviquanly_moi != null && donviquanly.id == donviquanly_moi.id;
            #region Chuyển toàn bộ
            //Chuyen toan bo
            if (soluong_moi <= 0 || soluong_moi == this.soluong)
            {
                //cung don vi quan ly
                if(cungdonviquanly)
                {
                    //chi update lai this
                    this.chungtu_ngay = chungtu_ngay_moi;
                    this.chungtu_sohieu = chungtu_sohieu_moi;
                    this.donvisudung = donvisudung_moi;
                    this.ghichu = ghichu_moi;
                    this.ngay = ngay_moi;
                    this.parent = cttaisan_parent_moi;
                    this.phong = phong_moi;
                    this.vitri = vitri_moi;
                    re = re && this.update() > 0;
                }
                //khac don vi quan ly
                else
                {
                    //Step 1: Tao CTTS moi -> add
                    CTTaiSan ctts = new CTTaiSan();
                    ctts.chungtu_ngay = chungtu_ngay_moi;
                    ctts.chungtu_sohieu = chungtu_sohieu_moi;
                    ctts.donviquanly = donviquanly_moi;
                    ctts.donvisudung = donvisudung_moi;
                    ctts.ghichu = ghichu_moi;
                    ctts.mota = this.mota;
                    ctts.ngay = ngay_moi;
                    ctts.nguongoc = "[Hệ thống tự động tạo: chuyển từ " + (this.donviquanly == null ? "(null)" : this.donviquanly.niceName()) + " sang " + (donviquanly_moi == null ? "(null)" : donviquanly_moi.niceName()) + "]";
                    ctts.parent = cttaisan_parent_moi;
                    ctts.phong = phong_moi;
                    ctts.soluong = this.soluong;
                    ctts.subId = this.subId;
                    ctts.taisan = this.taisan;
                    ctts.tinhtrang = this.tinhtrang;
                    ctts.vitri = vitri_moi;
                    re = re && ctts.add() > 0;
                    //Step 2: ghi log tang tai san cho ctts moi them
                    LogTangGiamTaiSan log = ctts.generateLogTangGiamTaiSan();
                    log.tang_giam = 0;
                    log.tang_giam_donvi = 1;
                    log.chuyenden_chuyendi = 1;
                    re = re && log.add()>0;
                    //Step 3: Update lai soluong cho this=0 -> update
                    this.chungtu_ngay = chungtu_ngay_moi;
                    this.chungtu_sohieu = chungtu_sohieu_moi;
                    this.ghichu = ghichu_moi;
                    this.soluong = 0;
                    this.nguongoc = ctts.nguongoc;
                    re = re && this.update()>0;
                    //Step 4: ghi nhan su giam cho this
                    LogTangGiamTaiSan log2 = this.generateLogTangGiamTaiSan();
                    log2.soluong = soluong_moi;//importance!!!không dùng this.soluong
                    log2.tang_giam = 0;
                    log2.tang_giam_donvi = -1;
                    log2.chuyenden_chuyendi = -1;
                    re = re && log2.add()>0;
                }
                //end
                return re ? 1 : -1;
            }
            #endregion
            #region Chuyển 1 phần số lượng
            else
            //Chuyen 1 phan so luong
            {
                //cung don vi quan ly
                if (cungdonviquanly)
                {
                    //Tao CTTS moi
                    CTTaiSan ctts = new CTTaiSan();
                    ctts.chungtu_ngay = chungtu_ngay_moi;
                    ctts.chungtu_sohieu = chungtu_sohieu_moi;
                    ctts.donvisudung = donvisudung_moi;
                    ctts.ghichu = ghichu_moi;
                    ctts.mota = this.mota;
                    ctts.ngay = ngay_moi;
                    ctts.nguongoc = "[Hệ thống tự động tạo: phân bổ nội " + (this.donviquanly == null ? "(null)" : this.donviquanly.niceName())+"]";
                    ctts.parent = cttaisan_parent_moi;
                    ctts.phong = phong_moi;
                    ctts.soluong = soluong_moi;//importance!!!
                    ctts.subId = this.subId;
                    ctts.taisan = this.taisan;
                    ctts.tinhtrang = this.tinhtrang;
                    ctts.vitri = vitri_moi;
                    ctts.add();
                    //cap nhat lai soluong cho this
                    this.chungtu_ngay = chungtu_ngay_moi;
                    this.chungtu_sohieu = chungtu_sohieu_moi;
                    this.ghichu = ghichu_moi;
                    this.soluong -= soluong_moi;//importance!!!
                    this.nguongoc = nguongoc;
                    this.update();
                    //KHONG ghi log tang giam
                }
                //khac don vi quan ly
                else
                {
                    //Step 1: Tao CTTS moi -> add
                    CTTaiSan ctts = new CTTaiSan();
                    ctts.chungtu_ngay = chungtu_ngay_moi;
                    ctts.chungtu_sohieu = chungtu_sohieu_moi;
                    ctts.donviquanly = donviquanly_moi;
                    ctts.donvisudung = donvisudung_moi;
                    ctts.ghichu = ghichu_moi;
                    ctts.mota = this.mota;
                    ctts.ngay = ngay_moi;
                    ctts.nguongoc = "[Hệ thống tự động tạo: chuyển từ \"" + (this.donviquanly == null ? "null" : this.donviquanly.niceName()) + "\" sang \"" + (donviquanly_moi == null ? "null" : donviquanly_moi.niceName()) + "\"]";
                    ctts.parent = cttaisan_parent_moi;
                    ctts.phong = phong_moi;
                    ctts.soluong = soluong_moi;//importance!!!
                    ctts.subId = this.subId;
                    ctts.taisan = this.taisan;
                    ctts.tinhtrang = this.tinhtrang;
                    ctts.vitri = vitri_moi;
                    ctts.add();
                    //Step 2: ghi log tang tai san cho ctts moi them
                    LogTangGiamTaiSan log = ctts.generateLogTangGiamTaiSan();
                    log.tang_giam = 0;
                    log.tang_giam_donvi = 1;
                    log.chuyenden_chuyendi = 1;
                    log.add();
                    //Step 3: Update lai soluong cho this -> update
                    this.chungtu_ngay = chungtu_ngay_moi;
                    this.chungtu_sohieu = chungtu_sohieu_moi;
                    this.soluong -= soluong_moi;//importance!!!
                    this.nguongoc = ctts.nguongoc;
                    this.ghichu = ghichu_moi;
                    this.update();
                    //Step 4: ghi nhan su giam cho this
                    LogTangGiamTaiSan log2 = this.generateLogTangGiamTaiSan();
                    log2.soluong = soluong_moi;//importance!!!Không dùng this.soluong
                    log2.tang_giam = 0;
                    log2.tang_giam_donvi = -1;
                    log2.chuyenden_chuyendi = -1;
                    log2.add();
                }
            }
            #endregion
            return re?1:-1;
        }
        /// <summary>
        /// Copy moi thuoc tinh,
        /// co set mac dinh quantrivien lay tu Global qua
        /// </summary>
        /// <returns></returns>
        private LogTangGiamTaiSan generateLogTangGiamTaiSan()
        {
            LogTangGiamTaiSan log = new LogTangGiamTaiSan();
            log.chungtu_ngay = this.chungtu_ngay;
            log.chungtu_sohieu = this.chungtu_sohieu;
            log.cttaisan_parent = this.parent;
            log.donviquanly = this.donviquanly;
            log.donvisudung = this.donvisudung;
            log.ghichu = this.ghichu;
            log.nguongoc = this.nguongoc;
            log.mota = this.mota;
            log.ngay = this.ngay;
            log.phong = this.phong;
            log.quantrivien = Global.current_quantrivien_login;
            log.soluong = this.soluong;
            log.subId = this.subId;
            log.taisan = this.taisan;
            log.tinhtrang = this.tinhtrang;
            log.vitri = this.vitri;
            return log;
        }

        /// <summary>
        /// Trường tự động tính (KHÔNG lưu trong CSDL, NotMapped),
        /// thanhtien=soluong*dongia
        /// </summary>
        [NotMapped]
        public long thanhtien
        {
            get
            {
                return taisan.dongia * soluong;
            }
        }
        /// <summary>
        /// gh log sua doi (khac voi log tang giam)
        /// </summary>
        /// <returns></returns>
        private int writelog()
        {
            //Ghi logsuataisan
            LogSuaTaiSan log = new LogSuaTaiSan();
            log.chungtu_ngay = chungtu_ngay;
            log.chungtu_sohieu = chungtu_sohieu;
            log.donviquanly = donviquanly;
            log.donvisudung = donvisudung;
            log.ghichu = ghichu;
            log.mota = mota;
            log.phong = phong;
            log.quantrivien = Global.current_quantrivien_login;
            log.soluong = soluong;
            log.subId = subId;
            log.taisan = taisan;
            log.tinhtrang = tinhtrang;
            log.vitri = vitri;
            log.cttaisan_parent = parent;
            return log.add();
        }
        #endregion

        #region Override
        /// <summary>
        ///    TaiSan ts = new TaiSan();
        ///    ts.ten = "Ten ts";
        ///    ts.dongia = 676542222;
        ///    ts.loaitaisan = LoaiTaiSan....;
        ///    ts.subId = "TREWWWSS$####";
        ///    
        ///
        ///    CTTaiSan obj = new CTTaiSan();
        ///    
        ///    obj.taisan = ts;
        ///    obj.chungtu_ngay = DateTime.Now;
        ///    obj.chungtu_sohieu = "RT45644";
        ///    obj.ngay = DateTime.Now;
        ///    obj.nguongoc = "UBND Tang";
        ///    obj.soluong = 40;
        ///    obj.tinhtrang = TinhTrang...;
        ///
        ///    int re = obj.add();//ONly call add on CTTaiSan
        ///
        ///    re = DBInstance.commit();
        /// </summary>
        /// <returns></returns>
        public override int add()
        {
            //kiem tra rang buoc
            //thêm mới không được phép chỉ định giảm
            if(tinhtrang.giam_taisan)
            {
                return -1;
            }
            base.add();
            //luon ghi log tang mac dinh khi them moi
            LogTangGiamTaiSan log = this.generateLogTangGiamTaiSan();
            log.chuyenden_chuyendi = 0;
            log.tang_giam = 1;
            log.tang_giam_donvi = 1;
            log.add();
            //ghi log sua doi
            return writelog();
            
        }
        /// <summary>
        /// chi nen dung truc tiep khi cap nhat cac thuoc tinh dang mota,
        /// Khong ghi log tang giam
        /// </summary>
        /// <returns></returns>
        public override int update()
        {
            base.update();
            //ghi log sua doi
            return writelog();
        }
        /// <summary>
        /// Tạm thời Không cho xóa
        /// </summary>
        /// <returns></returns>
        public override int delete()
        {
            return -1;
        }

        protected override void init()
        {
            base.init();

            //isTang = true;
            //isChuyen = false;
            soluong = 1;
        }
        #endregion
    }
}
