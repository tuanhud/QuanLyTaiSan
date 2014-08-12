using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    [Table("SETTINGS")]
    public class Setting:_EntityAbstract1<Setting>
    {
        public Setting()
        {

        }
        #region Dinh nghia
        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public String key { get; set; }

        public String value { get; set; }
        #endregion

        #region Nghiep vu
        /// <summary>
        /// Cần set key và value trước (nếu key chưa có trong CSDL thì sẽ tạo mới record),
        /// Nếu key có rồi thì update value
        /// </summary>
        /// <returns></returns>
        public int addOrUpdate()
        {
            try
            {
                //may throw Exception
                Setting tmp = db.SETTINGS.FirstOrDefault(c => c.key.ToUpper().Equals(this.key.ToUpper()));
                if (tmp != null)
                {
                    return update();
                }
                else
                {
                    return add();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return -1;
            }
        }
        /// <summary>
        /// Lấy value theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>"" or value</returns>
        public static String getValue(String key)
        {
            Setting tmp = getByKey(key);
            return tmp.value == null ? "" : tmp.value;
        }
        /// <summary>
        /// Sau khi getByKey, goi addOrUpdate sẽ an toàn hơn,
        /// do có thể key chưa có trong DB (update sẽ lỗi),
        /// Không bao giờ return null
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Never null</returns>
        public static Setting getByKey(String key)
        {
            Setting tmp;
            try
            {
                tmp= db.SETTINGS.FirstOrDefault(c => c.key.ToUpper().Equals(key.ToUpper()));
                if (tmp == null)
                {
                    tmp = new Setting();
                    tmp.key = key;
                    tmp.value = "";
                }
                return tmp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                tmp = new Setting();
                tmp.key = key;
                tmp.value = "";
                return tmp;
            }
        }
        #endregion

    }
}
