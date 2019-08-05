using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace PrismaWEB.Utils.Email
{
    class SendEmail
    {
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        private IList<MailAddress> toAddress { get; set; }

        public SendEmail()
        {
            toAddress = new List<MailAddress>();
        }

        public void To(string email, string nome)
        {
            toAddress.Add(new MailAddress(email, nome));
        }

        public void Sand()
        {
            var fromAddress = new MailAddress("WebPrismaMail@gmail.com", "WebPrismaMail");
            const string fromPassword = "prisma@123";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            foreach (var from in toAddress)
            {
                using (var message = new MailMessage(fromAddress, from)
                {
                    Subject = Titulo,
                    Body = Corpo
                })
                {
                    smtp.Send(message);
                }
            }

        }
    }
}
