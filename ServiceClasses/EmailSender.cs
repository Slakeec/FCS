using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClasses
{
    class EmailSender
    {
        public void SendEmail(string email, int score)
        {
            MailAddress fromMailAddress = new MailAddress("FCSapi2017@gmail.com", "FCS Team");
            MailAddress ToAdress = new MailAddress(email, "Player");
            using (MailMessage mailMessage = new MailMessage(fromMailAddress, ToAdress))
            using (SmtpClient smtpclient = new SmtpClient())
            {
                mailMessage.Subject = "Поздравляем, вы прошли чемпионат!";
                mailMessage.Body = "Вы набрали " + score + "очков!";

                smtpclient.Host = "smtp.gmail.com";
                smtpclient.Port = 587;
                smtpclient.EnableSsl = true;
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new NetworkCredential(fromMailAddress.Address, "apifcs2017");

                smtpclient.Send(mailMessage);
            }
        }
    }
}
