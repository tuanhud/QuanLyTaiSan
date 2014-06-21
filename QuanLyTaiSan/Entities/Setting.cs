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
        [Required]
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
            Setting tmp = getByKey(this.key);
            if (tmp != null)
            {
                tmp.value = this.value;
                return tmp.update();
            }
            else
            {
                return add();
            }
        }
        /// <summary>
        /// Lấy value theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>"" or value</returns>
        public String getValue(String key)
        {
            Setting tmp = getByKey(key);
            if (tmp != null)
            {
                return tmp.value;
            }
            return "";
        }
        public Setting getByKey(String key)
        {
            try
            {
                return db.SETTINGS.FirstOrDefault(c => c.key.ToUpper().Equals(key.ToUpper()));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
