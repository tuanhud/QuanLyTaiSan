using QuanLyTaiSan.Entities;
using SHARED.Interface;
using SHARED.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

    }
}
