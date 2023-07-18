using Demo.DataAccessLayer.Entities;
using System.Net;
using System.Net.Mail;

namespace Demo.PeresentationLayer.Helpers
{
    public static class EmailSettings
    {
        public static void Send(Email email)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("ahmedamr34@yahoo.com", "ggmtxgtccjkqnlou");
            smtp.Send("ahmedamr34@yahoo.com", email.To, email.Subject, email.Body);

        }
    }
}
