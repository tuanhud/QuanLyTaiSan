using QuanLyTaiSan.Libraries;
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
    [Table("QUANTRIVIENS")]
    public class QuanTriVien : _EntityAbstract1<QuanTriVien>
    {
        
        public QuanTriVien():base()
        {

        }
        
        #region Định nghĩa thuộc tính
        public String subId { get; set; }
        [Required]
        public String hoten { get; set; }
        [Index(IsUnique = true)]
        [StringLength(100)]
        [Required]
        public String username { get; set; }
        [Required]
        public String password { get; set; }
        /*
         * Ngay record insert vao he thong 
         */
        public DateTime? date_create { get; set; }
        /*
         * Ngay update gan day nhat
         */
        public DateTime? date_modified { get; set; }
        /*
         * FK
         */
        [Required]
        public virtual Group group { get; set; }
        #endregion

        #region Hàm nghiệp vụ
        /// <summary>
        /// id, password thô phải đưa vào trước </summary>
        public Boolean checkLoginById()
        {
            //select doi tuong len
            QuanTriVien obj = getById(id);
            //validate
            if (obj == null)
            {
                return false;
            }
            //hash password
            String hash = StringHelper.SHA1_Salt(password);
            if (hash.ToUpper().Equals(obj.password.ToUpper())
                ||
                password.ToUpper().Equals(obj.password.ToUpper())
                )
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// username, password thô phải đưa vào trước </summary>
        public Boolean checkLoginByUserName()
        {
            //select doi tuong len
            QuanTriVien obj = getByUserName(username);
            //validate
            if (obj == null)
            {
                return false;
            }
            //hash password
            String hash = StringHelper.SHA1_Salt(password);
            if (hash.ToUpper().Equals(obj.password.ToUpper())
                ||
                password.ToUpper().Equals(obj.password.ToUpper())
                )
            {
                return true;
            }
            return false;
        }
        public QuanTriVien getByUserName(String username)
        {
            try
            {
                db = new MyDB();
                //select doi tuong len
                QuanTriVien obj = db.QUANTRIVIENS.Where(
                    c => c.username.ToUpper().Equals(username.ToUpper())
                    ).FirstOrDefault();
                
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //db.Dispose();
            }
        }
        /// <summary>
        /// Obj phải được load lên trước (có id, password rồi),
        /// return
        /// -3: dữ liệu không hợp lệ,
        /// -1: passConfirm fail,
        /// -2: user chưa được set password dạng Hash (không thể xác thực)
        ///  >0: thành công
        /// </summary>
        public int changePassword(String newPass, String newPassConfirm)
        {
            if (newPass == null || newPassConfirm == null)
            {
                return -3;
            }
            if (!newPass.ToUpper().Equals(newPassConfirm.ToUpper()))
            {
                return -1;
            }
            if (!checkLoginById())
            {
                return -2;
            }
            //đổi pass
            password = StringHelper.SHA1_Salt(newPass);
            //update
            return this.update();
        }
        #endregion
    }
}
