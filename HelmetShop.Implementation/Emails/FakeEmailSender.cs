using HelmetShop.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Implementation.Emails
{
    public class FakeEmailSender : IEmailSender
    {
        public void SendEmail(MailMessage mail)
        {
            Console.WriteLine("Email sent to: " + mail.To);
            Console.WriteLine("Subject: " + mail.Subject);
            Console.WriteLine("Body: " + mail.Body);
        }
    }
}
