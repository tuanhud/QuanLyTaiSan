using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.Libraries
{
    public class EmailHelper
    {
        /// <summary>
        /// Hàm gửi email đơn lẻ
        /// </summary>
        /// <param name="smtp_host"></param>
        /// <param name="smtp_port">Cổng</param>
        /// <param name="smtp_usessl">Sử dụng SSL</param>
        /// <param name="sender_email">Cũng chính là tên đăng nhập SMTP</param>
        /// <param name="sender_password">Mật khẩu dạng thô</param>
        /// <param name="receive_email">Email người nhận</param>
        /// <param name="receive_title">Tiêu đề email</param>
        /// <param name="receive_html">Nội dung mail djang HTML</param>
        /// <returns></returns>
        public static int sendMail(String receive_email, String receive_title, String receive_html, String smtp_host, int smtp_port, Boolean smtp_usessl, String sender_email, String sender_password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(receive_email);

                mail.Subject = receive_title;
                mail.IsBodyHtml = true;
                mail.Body = receive_html;
                mail.From = new MailAddress(sender_email);
            
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = smtp_usessl;
                client.Host = smtp_host;
                client.Port = smtp_port;
                // setup Smtp authentication
                NetworkCredential credentials = new NetworkCredential(sender_email, sender_password);
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;
                client.Send(mail);
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
