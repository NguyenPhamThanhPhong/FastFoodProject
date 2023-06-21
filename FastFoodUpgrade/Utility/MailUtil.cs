using System;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace FastFoodUpgrade.Utility
{
    public class MailUtil
    {
        public static string Generate6Digits()
        {
            Random r = new Random();
            int code = r.Next(100000, 999999);
            return code.ToString();
        }
        public static void SendEmail(string recipientEmail, string subject, string body)
        {
            // Thay đổi thông tin tài khoản Gmail của bạn tại đây
            string senderEmail = "21522458@gm.uit.edu.vn";
            string password = "xgkwgffeasppvkso\r\n";

            // Cấu hình thông tin kết nối SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, password);

            // Tạo đối tượng MailMessage để cấu hình email
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
            mailMessage.IsBodyHtml = true;

            try
            {
                // Gửi email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
