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

namespace TSCD.Entities
{
    [Table("LOGHETHONGS")]
    public class LogHeThong: _EntityAbstract1<LogHeThong>
    {
        public LogHeThong():base()
        {

        }
        #region Dinh nghia
        
        #endregion
        public static List<LogHeThong> getAllByDK(DateTime? tuNgay, DateTime? denNgay, int gioiHan)
        {
            try
            {
                List<LogHeThong> re = db.LOGHETHONGS.Where(c => (tuNgay == null || c.date_create >= tuNgay) && (denNgay == null || c.date_create <= denNgay)).OrderByDescending(c => c.date_create).Take(gioiHan).ToList();
                //    (from c in db.LOGHETHONGS
                //     where ((tuNgay == null || c.date_create >= tuNgay) && (denNgay == null || c.date_create <= denNgay))
                //     select c).OrderByDescending(c => c.date_create).Take(gioiHan).ToList();
                return re;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new List<LogHeThong>();
            }
        }
    }
}
