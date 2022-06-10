using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.Application.Emails
{
    public interface IEmailSender
    {
        void SendEmail(MailMessage mail);
    }
}
