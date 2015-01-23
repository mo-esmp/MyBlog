using Mvc.Mailer;
using MyBlog.Service.Contracts;
using System.Configuration;

namespace MyBlog.Service.Implementation
{
    public class MailService : MailerBase, IMailService
    {
        public MailService()
        {
            MasterName = "_Layout";
        }

        #region IMailService Members

        public MvcMailMessage ContactMail(string name, string email, string message)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Message = message;

            var toMail = ConfigurationManager.AppSettings["ForwardMail"];

            return Populate(x =>
            {
                x.Subject = string.Format("پیام ارسالی از بلاگ من - {0}", name);
                x.To.Add(toMail);
                x.ViewName = "Contact";
            });
        }

        #endregion IMailService Members
    }
}