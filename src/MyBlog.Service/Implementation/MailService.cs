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
            var subject = string.Format("پیام ارسالی از بلاگ من - {0}", name);
            ViewBag.Title = subject;
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Message = message;
            var toMail = ConfigurationManager.AppSettings["ForwardMail"];

            return Populate(x =>
            {
                x.Subject = subject;
                x.To.Add(toMail);
                x.ViewName = "Contact";
            });
        }

        public MvcMailMessage AccountMail(string destination, string subject, string message)
        {
            ViewBag.Message = message;

            return Populate(x =>
            {
                x.Subject = subject;
                x.To.Add(destination);
                x.ViewName = "Account";
            });
        }

        #endregion IMailService Members
    }
}