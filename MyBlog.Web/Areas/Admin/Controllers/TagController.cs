using MyBlog.Service.Contracts;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Admin/Tag
        public ActionResult Index()
        {
            var tags = _tagService.GetTags();
            return View(tags);
        }
    }
}