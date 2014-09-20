using PTB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTB.Libraries
{
    public static class EmailHelper
    {
        /// <summary>
        /// Hàm rút gọn của sendMail nhiều tham số,
        /// lấy SMTP CONFIG từ Global ra cho gọn
        /// </summary>
        /// <param name="receive_email"></param>
        /// <param name="receive_title"></param>
        /// <param name="receive_html"></param>
        /// <returns></returns>
        public static int sendMail(String receive_email, String receive_title, String receive_html)
        {
            return SHARED.Libraries.EmailHelper.sendMail(receive_email, receive_title, receive_html, Global.remote_setting.smtp_config.SMTP_HOST, Global.remote_setting.smtp_config.SMTP_PORT, Global.remote_setting.smtp_config.SMTP_USESSL, Global.remote_setting.smtp_config.SMTP_USERNAME, Global.remote_setting.smtp_config.SMTP_PASSWORD);
        }
    }
}
