using MyBlog.Domain;
using MyBlog.Service.Contracts;
using MyBlog.Web.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<IContactMessageService> _contactMessageService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<ITagService> _tagService;

        public HomeController()
        {
        }

        public HomeController(Lazy<IContactMessageService> contactMessageService, Lazy<IMailService> mailService,
            Lazy<IPostService> postService, Lazy<ITagService> tagService)
        {
            _contactMessageService = contactMessageService;
            _mailService = mailService;
            _postService = postService;
            _tagService = tagService;
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Posts = await _postService.Value.GetPostsAsync(p => p.IsEnabled, p => p.CreateDate, SortOrder.Descending, p => p.Tags),
                Tags = await _tagService.Value.GetTagsAsync()
            };

            return View(homeViewModel);
        }

        // GET: Home/About
        public ActionResult About()
        {
            ViewBag.Length = Request.UserAgent.Length;
            ViewBag.UserAgent = Request.UserAgent.IndexOf("Windows NT 6.3", StringComparison.InvariantCultureIgnoreCase);

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