using Mvc.Mailer;

namespace MyBlog.Service.Contracts
{
    public interface IMailService
    {
        MvcMailMessage ContactMail(string name, string email, string message);
    }
}