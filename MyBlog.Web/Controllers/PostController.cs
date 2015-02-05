using MyBlog.Service.Contracts;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult PostDetail(int id, string slug)
        {
            var post = _postService.GetPost(p => p.IsEnabled && p.Id == id && p.Slug == slug);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        public ActionResult PostsByTag(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var posts = _postService.GetPostsSummary(p => p.Tags.Any(t => t.Slug == slug));
            return View("~/Views/Home/Index.cshtml", posts);
        }
    }
}