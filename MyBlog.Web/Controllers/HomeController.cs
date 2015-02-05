using MyBlog.Domain;
using MyBlog.Service.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<IContactMessageService> _contactMessageService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IPostService> _postService;

        public HomeController(Lazy<IContactMessageService> contactMessageService, Lazy<IMailService> mailService,
            Lazy<IPostService> postService)
        {
            _contactMessageService = contactMessageService;
            _mailService = mailService;
            _postService = postService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var posts = _postService.Value.GetPostsSummary(p => p.IsEnabled).OrderByDescending(p => p.CreateDate);
            return View(posts);
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactMessageEntity contactMessage)
        {
            if (!ModelState.IsValid)
                return View(contactMessage);

            _contactMessageService.Value.AddMessage(contactMessage);
            if (_contactMessageService.Value.Commit() == false)
            {
                ModelState.AddModelError("Create", "هنگام ثبت پیام خطایی رخ داده است. لطفا بعدا سعی نمایید.");
                return View(contactMessage);
            }

            await _mailService.Value.ContactMail(contactMessage.Name, contactMessage.Email, contactMessage.Message).SendAsync();
            TempData["Successful"] = true;
            ModelState.Clear();

            return View();
        }
    }
}