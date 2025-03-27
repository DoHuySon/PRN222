namespace Assigment_PRN222_01.Service
{
    using System;
    using System.Net;
    using System.Net.Mail;

    public class EmailService
    {
        public void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dohuyson134@gmail.com");
                mail.To.Add("sondhhe170206@fpt.edu.vn");
                mail.Subject = "Thông báo: Đối tượng mới được tạo";
                mail.Body = "Một đối tượng mới đã được tạo trong hệ thống.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("dohuyson134@gmail.com", "uclz bsja tdhi iszg");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }

}
