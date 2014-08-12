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
    [Table("LOGHETHONGS")]
    public class LogHeThong : _EntityAbstract1<LogHeThong>
    {
        public LogHeThong():base()
        {

        }
        #region Dinh nghia
        //PARENT DIFINITION
        //vd: { "USER":quocdunginfo, "ACTION":DELETE_USER, "PARAM": nguoibixoa }
        //public String mota { get; set; }
        #endregion

        #region Nghiep vu
        public static List<LogHeThong> getAllByDK(DateTime? tuNgay, DateTime? denNgay, int gioiHan)
        {
            List<LogHeThong> re =
                (from c in db.LOGHETHONGS
                 where ((tuNgay == null || c.date_create >= tuNgay) && (denNgay == null || c.date_create <= denNgay))
                 select c).OrderByDescending(c => c.date_create).Take(gioiHan).ToList();
            return re;
        }
        #endregion

        #region Override
        /// <summary>
        /// Log hệ thống không có update
        /// </summary>
        /// <returns></returns>
        public override int update()
        {
            return -1;
        }
        #endregion

    }
}
