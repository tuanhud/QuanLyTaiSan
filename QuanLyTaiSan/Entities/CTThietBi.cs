﻿using QuanLyTaiSan.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public CTThietBi(MyDB db)
        //    : base(db)
        //{
            
        //}

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
        /// Ham update se duoc tu dong goi trong day (co su dung Transaction Commit),
        /// Khi co bat ky 1 loi nao trong qua trinh thuc hien (Rollback se duoc goi),
        /// Co ho tro ghi LOG tu dong
        /// </summary>
        /// <param name="dich">Phong can di chuyen den (Can duy tri chung dbContext)</param>
        /// <param name="soluong">So luong can di chuyen (mac dinh la 1)</param>
        /// <returns></returns>
        public int dichuyen(Phong dich, int soluong=1, String mota="")
        {
            //kiem tra rang buoc
            if (this.soluong < soluong)
            {
                return -2;
            }
            //initDb();
            //BEGIN===================================
            using (var dbContextTransaction = db.Database.BeginTransaction()) 
            {
                CTThietBi cttb;
                DateTime ngay = ServerTimeHelper.getNow();
                Boolean transac = true;
                //tao hoac cap nhat mot CTTB moi cho PHONG moi (dich)
                    //kiem tra co record nao trung (dich, tinhtrang, thietbi) ?
                cttb = search(dich, thietbi, tinhtrang);
                    //YES
                        //SELECT CTTB do len => update
                if (cttb != null)
                {
                    cttb.soluong += soluong;
                    transac=transac && cttb.update()>0;//UPDATE
                    //ghi log thietbi ngay sau khi cap nhat ONLY soluong
                    transac = transac && cttb.writelog(ngay, mota) > 0;//cung 1 ngay se group de
                }
                    //NO
                    //TAO MOI CTTB => add
                else
                {
                    //cttb = new CTThietBi(db);
                    cttb = new CTThietBi();
                    cttb.phong = dich;
                    cttb.soluong = soluong;
                    cttb.thietbi = thietbi;
                    cttb.tinhtrang = tinhtrang;
                    transac=transac && cttb.add()>0;//ADD
                    //ghi log thietbi cho CTTB moi them
                    transac=transac&& cttb.writelog(ngay, mota)>0;//cung 1 ngay se group de
                }
                    
                //cap nhat lai so luong
                this.soluong -= soluong;
                //update
                transac=transac && update()>0;
                //ghi log thietbi ngay sau khi cap nhat ONLY soluong
                transac = transac && writelog(ngay, mota) > 0;//cung 1 ngay se group de
                if (transac)
                {
                    dbContextTransaction.Commit();
                    return 1;
                }
                else
                {
                    dbContextTransaction.Rollback();
                    return -1;
                }
            }
            //END===================================
        }
        /// <summary>
        /// Kich hoat ham ghi log vao LogThietBi
        /// </summary>
        protected int writelog(DateTime ngay, String mota="")
        {
            //ghi log thiet bi
            //LogThietBi logtb = new LogThietBi(db);
            LogThietBi logtb = new LogThietBi();
            logtb.mota = mota;
            logtb.ngay = ngay;
            logtb.phong = phong;
            logtb.soluong = soluong;
            logtb.thietbi = thietbi;
            logtb.tinhtrang = tinhtrang;
            return logtb.add();
        }
        /// <summary>
        /// Nen dam bao tat ca object co lien quan cung 1 Context
        /// </summary>
        /// <param name="ph"></param>
        /// <param name="tb"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public CTThietBi search(Phong ph, ThietBi tb, TinhTrang tr)
        {
            CTThietBi tmp = db.CTTHIETBIS.Where(c => c.phong.id == ph.id && c.thietbi.id == tb.id && c.tinhtrang.id == tr.id).FirstOrDefault();
            //if (tmp != null)
            //{
            //    tmp.DB = db;
            //}
            return tmp;
        }

        public List<ThietBi> listThietBiTheoTinhTrang(int idTinhTrang)
        {
            return db.CTTHIETBIS.Where(ct => ct.tinhtrang.id == idTinhTrang).Select(select => select.thietbi).ToList();
        }
        #endregion

        #region Override method
        public override int update()
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
            
            //...
            return base.update();
        }

        #endregion
    }
}
