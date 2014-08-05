﻿using QuanLyTaiSan.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public abstract class _EntityAbstract3<T>: _EntityAbstract1<T> /* ,_CRUDInterface<T>*/ where T : _EntityAbstract3<T>
    {
        #region Định nghĩa thuộc tính
        [Required]
        public String hoten { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        [Required]
        public String username { get; set; }

        /// <summary>
        /// Luôn luôn ở dạng Hashed
        /// </summary>
        [Required]
        public String password { get; set; }
        
        #endregion

        #region Nghiep vu
        [NotMapped]
        protected Boolean hashed = false;
        /// <summary>
        /// id, password hashed phải đưa vào trước </summary>
        public Boolean checkLoginById()
        {
            //select doi tuong len
            T obj = getById(id);
            //validate
            if (obj == null)
            {
                return false;
            }
            //hash password
            if (hashed)
            {
                if (password.ToUpper().Equals(obj.password.ToUpper()))
                {
                    this.id = obj.id;
                    return true;
                }
            }
            else
            {
                String hash = StringHelper.SHA1_Salt(password);
                if (hash.ToUpper().Equals(obj.password.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// username phải đưa vào trước, password đưa vào qua hàm hashPassword </summary>
        public Boolean checkLoginByUserName()
        {
            //select doi tuong len
            T obj = getByUserName(username);
            //validate
            if (obj == null)
            {
                return false;
            }
            //hash password
            if (hashed)
            {
                if (password.ToUpper().Equals(obj.password.ToUpper()))
                {
                    this.id = obj.id;
                    return true;
                }
            }
            else
            {
                String hash = StringHelper.SHA1_Salt(password);
                if (hash.ToUpper().Equals(obj.password.ToUpper()))
                {
                    return true;
                }
            }
            return false;
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
            finally
            {

            }
        }
        /// <summary>
        /// Obj phải được load lên trước (có id)
        /// update sẽ được gọi tự động
        /// return
        /// -4: update fail
        /// -3: dữ liệu không hợp lệ,
        /// -1: passConfirm fail,
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

            //đổi pass
            hashPassword(newPass);
            //update
            if (update() < 0)
            {
                return -4;
            }
            return 1;
        }
        /// <summary>
        /// Hash password và SET vào this.password
        /// 
        /// </summary>
        /// <param name="raw_pass">Mật khẩu thô</param>
        public void hashPassword(String raw_pass)
        {
            password = StringHelper.SHA1_Salt(raw_pass);
            hashed = true;
        }
        
        #endregion
    }
}