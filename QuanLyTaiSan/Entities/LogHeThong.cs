using PTB.Entities;
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

namespace PTB.Entities
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
        private static Dictionary<string, string> buildLog(String action_name = null, String message="")
        {
            Dictionary<string, string> re = new Dictionary<string, string>();
            try
            {
                if (Global.current_quantrivien_login != null)
                {
                    re.Add("actor", Global.current_quantrivien_login.niceName());
                }
                else
                {
                    re.Add("actor", "unknown");
                }

                if (action_name != null)
                {
                    re.Add("action", action_name);
                }
                else
                {
                    re.Add("action", "unknown");
                }
                re.Add("message", message);
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                re.Add("State: ", "ERROR");
                return re;
            }
        }
        /// <summary>
        /// Auto commit
        /// </summary>
        /// <param name="message"></param>
        public static void write(String message="")
        {
            try
            {
                LogHeThong tmp = new LogHeThong();
                tmp.onBeforeAdded();
                tmp.mota = StringHelper.toJSON(buildLog("execute", message));
                tmp.add();
                DBInstance.commit();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
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
        #endregion

    }
}
