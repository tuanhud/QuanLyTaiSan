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
        /// Đánh dấu tăng tài sản (có thể là tăng cho trường hoặc tăng cho đơn vị do chuyển từ đơn vị khác sang)
        /// </summary>
        public Boolean isTang { get; set; }
        /// <summary>
        /// Chuyển từ đơn vị khác sang
        /// </summary>
        public Boolean isChuyen { get; set; }
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
        /// 
        /// </summary>
        /// <param name="quanly_moi"></param>
        /// <param name="sudung_moi"></param>
        /// <param name="tinhtrang_moi"></param>
        /// <param name="vitri_moi"></param>
        /// <param name="phong_moi"></param>
        /// <param name="chungtu_ngay_moi"></param>
        /// <param name="chungtu_sohieu_moi"></param>
        /// <param name="soluong_moi"></param>
        /// <param name="ghichu_moi"></param>
        /// <param name="ngay_moi"></param>
        /// <returns></returns>
        public int chuyenDoi(DonVi quanly_moi, DonVi sudung_moi, TinhTrang tinhtrang_moi, ViTri vitri_moi, Phong phong_moi, DateTime chungtu_ngay_moi, String chungtu_sohieu_moi, int soluong_moi=-1, String ghichu_moi="", DateTime? ngay_moi=null)
        {
            Boolean re = true;
            
            //Kiem tra rang buoc ban dau
            //So luong chuyen phai hop le
            if (soluong_moi > this.soluong)
            {
                return -1;
            }

            //Chuyen toan bo
            if (soluong_moi <= 0 || soluong_moi == this.soluong)
            {
                //Chi cap nhat lai Object hien tai
                this.donviquanly = quanly_moi;
                this.donvisudung = sudung_moi;
                this.tinhtrang = tinhtrang_moi;
                this.vitri = vitri_moi;
                this.phong = phong_moi;
                this.chungtu_ngay = chungtu_ngay_moi;
                this.chungtu_sohieu = chungtu_sohieu_moi;
                this.ghichu = ghichu_moi;
                this.ngay = ngay_moi;

                re = re && this.update() > 0;
            }
            else
            //Chuyen 1 phan so luong
            {
                CTTaiSan ctts = new CTTaiSan();
                ctts.taisan = this.taisan;
                ctts.subId = this.subId;
                ctts.chungtu_ngay = chungtu_ngay_moi;
                ctts.chungtu_sohieu = chungtu_sohieu_moi;
                ctts.donviquanly = quanly_moi;
                ctts.donvisudung = sudung_moi;
                ctts.ghichu = ghichu_moi;
                ctts.isChuyen = true;
                ctts.isTang = true;
                ctts.mota = this.mota;
                ctts.ngay = ngay_moi;
                ctts.nguongoc = "";
                ctts.phong = phong_moi;
                ctts.vitri = vitri_moi;
                ctts.soluong = soluong_moi;
                ctts.tinhtrang = tinhtrang_moi;

                //add cai moi
                re = re && ctts.add()>0;

                //update cai hien tai
                //
                this.isTang = false;
                this.isChuyen = true;
                this.chungtu_ngay = chungtu_ngay_moi;
                this.chungtu_sohieu = chungtu_sohieu_moi;
                this.ghichu = ghichu_moi;
                this.ngay = ngay_moi;
                this.soluong -= soluong_moi;
                this.nguongoc = "";

                re = re && this.update()>0;
            }
            
            return re?1:-1;
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

        private int writelog()
        {
            //Ghi logtaisan
            LogTaiSan log = new LogTaiSan();

            log.chungtu_ngay = chungtu_ngay;
            log.chungtu_sohieu = chungtu_sohieu;
            log.donviquanly = donviquanly;
            log.donvisudung = donvisudung;
            log.ghichu = ghichu;
            log.isChuyen = isChuyen;
            log.isTang = isTang;
            log.mota = mota;
            log.phong = phong;
            log.quantrivien = Global.current_quantrivien_login;
            log.soluong = soluong;
            log.subId = subId;
            log.taisan = taisan;
            log.tinhtrang = tinhtrang;
            log.vitri = vitri;
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
            base.add();
            return writelog();
        }

        public override int update()
        {
            base.update();
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
        }
        #endregion
    }
}
