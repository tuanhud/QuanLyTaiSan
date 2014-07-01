using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("CTTHIETBIS")]
    public class CTThietBi:_EntityAbstract1<CTThietBi>
    {
        public CTThietBi():base()
        {
            
        }

        #region Dinh nghia
        [Required]
        public int soluong { get; set; }
        /*
         * FK
         */
        public int phong_id { get; set; }
        [Index("nothing", 1, IsUnique = true)]
        [Required]
        [ForeignKey("phong_id")]
        public virtual Phong phong { get; set; }

        public int thietbi_id { get; set; }
        [Index("nothing", 2,IsUnique=true)]
        [Required]
        [ForeignKey("thietbi_id")]
        public virtual ThietBi thietbi { get; set; }

        public int tinhtrang_id { get; set; }
        [Index("nothing", 3, IsUnique = true)]
        [Required]
        [ForeignKey("tinhtrang_id")]
        public virtual TinhTrang tinhtrang { get; set; }
        #endregion
        #region Nghiep vu

        /// <summary>
        /// Di chuyển, kết hợp đổi tình trạng,
        /// có hỗ trợ ghi LOG tự động,vd:
        /// CTThietBi obj = CTThietBi.getById(24552);
        /// Phong dich = null;// Phong.getById(1228);
        /// TinhTrang ttr = null;//TinhTrang.getById(3);
        /// int re = obj.dichuyen(dich, ttr, -1, "đổi tình trạng toàn bộ luôn");
        /// </summary>
        /// <param name="dich">Phòng cần di chuyển đến (null nếu chỉ muốn đổi tình trạng)</param>
        /// <param name="moi">Tình trạng cần chuyển sang (null nếu chỉ muốn đổi phòng)</param>
        /// <param name="soluong">Sô lượng cần chuyển (mac dinh la -1 (chuyển tất cả))</param>
        /// <returns></returns>
        public int dichuyen(Phong dich=null, TinhTrang moi=null, int soluong=-1, String mota="")
        {
            //pre set data
            dich = dich == null ? this.phong : dich;
            //=> dich co the van se la null (do this.phong có thể là null)
            moi = moi == null ? this.tinhtrang : moi;//tinh trang không thể null

            //XÉT ĐIỀU KIỆN
            if
                (
                    //Nếu Không có bất kỳ sự thay đổi nào, phòng và tình trạng giống với this
                    ((dich!=null && dich.id == this.phong.id) || (dich==null && this.phong==null))
                    && moi.id == this.tinhtrang.id
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
            //BEGIN===================================
            Boolean transac = true;
            using (var dbContextTransaction = db.Database.BeginTransaction()) 
            {
                CTThietBi tmp=null;
                DateTime ngay = ServerTimeHelper.getNow();
                if (true)
                {
                    //tao hoac cap nhat mot CTTB moi cho PHONG moi (dich)
                    //kiem tra co record nao trung với record cần tạo mới (dich, tinhtrang, thietbi) ?
                    tmp = search(dich, this.thietbi, moi);

                    //NO
                    //TAO MOI CTTB => add
                    if (tmp == null)
                    {
                        tmp = new CTThietBi();
                        tmp.phong = dich;
                        tmp.soluong = soluong;
                        tmp.thietbi = this.thietbi;
                        tmp.tinhtrang = moi;
                        tmp.mota = mota;//mota.Equals("") ? this.mota : mota;

                        transac = transac && tmp.add(ngay, true) > 0;//ADD
                    }
                    else
                    {
                        //Đã có CTTB sẵn giống với CTTB cần tạo mới
                        //SELECT CTTB do len => update
                        if (tmp.id != this.id)
                        {
                            tmp.soluong += soluong;
                            tmp.mota = mota;//mota.Equals("")?tmp.mota:mota;
                            transac = transac && tmp.update(ngay, true) > 0;//UPDATE
                        }
                    }

                    //cap nhat lai so luong cho cái hiện đã bị chuyển
                    this.mota = mota;
                    this.soluong -= soluong;
                    this.soluong = this.soluong < 0 ? 0 : this.soluong;//for sure
                    //ghi log thietbi ngay sau khi cap nhat ONLY soluong
                    transac = transac && update(ngay, true) > 0;
                    
                }


                //final transac controller
                if (transac)
                {
                    dbContextTransaction.Commit();
                }
                else
                {
                    dbContextTransaction.Rollback();
                }

                return transac ? 1 : -1;
            }
            //END===================================
        }
        /// <summary>
        /// Kich hoat ham ghi log vao LogThietBi
        /// </summary>
        private int writelog(DateTime? ngay, String mota="")
        {
            //ghi log thiet bi
            LogThietBi logtb = new LogThietBi();
            logtb.mota = mota;
            logtb.ngay = ngay==null?ServerTimeHelper.getNow():(DateTime)ngay;
            logtb.phong = phong;
            logtb.soluong = soluong;
            logtb.thietbi = thietbi;
            logtb.tinhtrang = tinhtrang;
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
        public static List<ThietBi> listThietBiTheoTinhTrang(int idTinhTrang)
        {
            return db.CTTHIETBIS.Where(ct => ct.tinhtrang.id == idTinhTrang).Select(select => select.thietbi).ToList();
        }
        /// <summary>
        /// Có hỗ trợ ghi log, phát sinh tự động thietbi hay không ? dựa trên loaichung hay riêng của loaithietbi,
        /// Tự động có transaction
        /// 
        /// CTThietBi obj = new CTThietBi();
        /// obj.thietbi = ThietBi.request(loaithietbi);
        /// obj.phong = phong;
        /// obj.tinhtrang = tinhtrang;
        /// obj.soluong=soluong;
        /// obj.mota=mota;
        /// obj.add_auto();
        /// </summary>
        /// <returns></returns>
        public int add_auto()
        {
            DateTime ngay = ServerTimeHelper.getNow();
            Boolean trans = true;
            using (var dbTransac = db.Database.BeginTransaction())
            {
                try
                {
                    CTThietBi tmp = search(phong, thietbi, tinhtrang);
                    //Nếu có CTTB sẵn trùng Phòng, Thiết bị, Tình trạng thì cộng dồn SL vào và update
                    if (tmp != null)
                    {
                        tmp.soluong += soluong;
                        //call update on tmp
                        trans = trans && tmp.update(ngay, true) > 0;
                        id = tmp.id;
                    }
                    //Còn không thì gọi this.add()
                    else
                    {
                        trans = trans && add(ngay, true) > 0;
                    }

                    if (trans)
                    {
                        dbTransac.Commit();
                    }
                    else
                    {
                        dbTransac.Rollback();
                    }
                    return trans ? 1 : -1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    dbTransac.Rollback();
                    return -1;
                }
            }
        }
        #endregion

        #region Override method
        /// <summary>
        /// Hàm add có hỗ trợ transaction, chỉ hỗ trợ add raw và ghi log chứ không tự động nghiệp vụ cộng dồn số lượng
        /// </summary>
        /// <param name="ngay"></param>
        /// <param name="in_transaction">Có đang bị chạy trong 1 transaction khác</param>
        /// <returns></returns>
        private int add(DateTime? ngay=null, Boolean in_transaction=false)
        {
            DbContextTransaction dbTransac=null;
            Boolean transac = true;
            if (!in_transaction)
            {
                dbTransac = db.Database.BeginTransaction();
            }
            //SCRIPT

            transac = transac && base.add() > 0;
            transac = transac && writelog(ngay, mota) > 0;

            //END SCRIPT
            if (!in_transaction)
            {
                if (transac)
                {
                    dbTransac.Commit();
                }
                else
                {
                    dbTransac.Rollback();
                }
                dbTransac.Dispose();
            }
            return transac ? 1 : -1;            
        }
        /// <summary>
        /// Có hỗ trợ ghi log, có hỗ trợ transaction
        /// </summary>
        /// <param name="ngay"></param>
        /// <param name="in_transaction"></param>
        /// <returns></returns>
        private int update(DateTime? ngay=null, Boolean in_transaction=false)
        {
            //have to load all [Required] FK object first
            if (phong != null)
            {
                phong.trigger();
            }
            if (tinhtrang != null)
            {
                tinhtrang.trigger();
            }
            if (thietbi != null)
            {
                thietbi.trigger();
            }

            //UPDATE
            DbContextTransaction dbTransac = null;
            Boolean transac = true;
            if (!in_transaction)
            {
                dbTransac = db.Database.BeginTransaction();
            }
            //SCRIPT

            transac = transac && base.update() > 0;
            transac = transac && writelog(ngay, mota) > 0;

            //END SCRIPT
            if (!in_transaction)
            {
                if (transac)
                {
                    dbTransac.Commit();
                }
                else
                {
                    dbTransac.Rollback();
                }
                dbTransac.Dispose();
            }
            return transac ? 1 : -1; 
        }

        #endregion
    }
}
