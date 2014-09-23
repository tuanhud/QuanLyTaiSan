using SHARED.Libraries;
using SHARED;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSCD.Entities
{
    public abstract class _EntityAbstract3<T> : _EntityAbstract1<T> /* ,_CRUDInterface<T>*/ where T : _EntityAbstract3<T>
    {
        #region Định nghĩa thuộc tính
        public String hoten { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100, ErrorMessage = "Tên đăng nhập tối đa 100 ký tự")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Tên đăng nhập")]
        public String username { get; set; }

        /// <summary>
        /// Luôn luôn ở dạng Hashed
        /// </summary>
        [Required]
        public String password { get; set; }

        #endregion

        #region Nghiep vu

        protected Boolean hashed = true;
        /// <summary>
        /// id, password hashed phải đưa vào trước </summary>
        public static Boolean checkLoginById(Guid id, String hashed_pass)
        {
            //select doi tuong len
            T obj = getById(id);
            //validate
            if (obj == null || hashed_pass == null)
            {
                return false;
            }
            return hashed_pass.ToUpper().Equals(obj.password.ToUpper());
        }
        /// <summary>
        /// username phải đưa vào trước, password phải được hashed trước </summary>
        public static Boolean checkLoginByUserName(String username, String hashed_pass)
        {
            //select doi tuong len
            T obj = getByUserName(username);
            //validate
            if (obj == null || hashed_pass == null)
            {
                return false;
            }
            return hashed_pass.ToUpper().Equals(obj.password.ToUpper());
        }
        public static Boolean isUsernameExist(String username)
        {
            return getByUserName(username) == null ? false : true;
        }

        public static T getByUserName(String username)
        {
            try
            {
                T obj = db.Set<T>().Where(
                    c => c.username.ToUpper().Equals(username.ToUpper())
                    ).FirstOrDefault();

                return obj;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        /// <summary>
        /// Obj phải được load lên trước (có id),
        /// Cần phải gọi update
        /// return
        /// -1: fail,
        ///  > 0: thành công
        /// </summary>
        public int changePassword(String newPass)
        {
            if (newPass == null || newPass.Equals(""))
            {
                return -1;
            }

            //đổi pass
            newPass = hashPassword(newPass);
            return 1;
        }
        /// <summary>
        /// Hash password provider
        /// </summary>
        /// <param name="raw_pass">Mật khẩu thô</param>
        public static string hashPassword(String raw_pass)
        {
            return StringHelper.SHA1_Salt(raw_pass);
        }
        /// <summary>
        /// Hash pass và đưa vào this.password
        /// </summary>
        /// <param name="raw_pass"></param>
        /// <returns></returns>
        public void setPassword(string raw_pass)
        {
            this.password = hashPassword(raw_pass);
        }

        #endregion
        #region Override
        #endregion
    }
}
