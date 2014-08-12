using QuanLyTaiSan.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Libraries
{
    public class MailHelper
    {

        public static bool sendMail_UseLocal(string strFrom, string strTo, string strSubject, string strBody)
        {
            MailMessage ms = new MailMessage(strFrom, strTo, strSubject, strBody);
            ms.BodyEncoding = System.Text.Encoding.UTF8;
            ms.SubjectEncoding = System.Text.Encoding.UTF8;
            ms.IsBodyHtml = true;
            ms.ReplyTo = new MailAddress(strFrom);
            ms.Sender = new MailAddress(strFrom);

            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Host = "localhost";

            try
            {
                SmtpMail.Send(ms);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool sendMail_UseGmail(string strFrom, string strPass, string strTo, string strSubject, string strBody)
        {
            MailMessage ms = new MailMessage(strFrom, strTo, strSubject, strBody);

            ms.BodyEncoding = System.Text.Encoding.UTF8;
            ms.SubjectEncoding = System.Text.Encoding.UTF8;
            ms.IsBodyHtml = true;

            ms.ReplyTo = new MailAddress(strFrom);
            ms.Sender = new MailAddress(strFrom);

            SmtpClient SmtpMail = new SmtpClient("smtp.gmail.com", 587);
            SmtpMail.Credentials = new NetworkCredential(strFrom, strPass);
            SmtpMail.EnableSsl = true;

            try
            {
                SmtpMail.Send(ms);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
