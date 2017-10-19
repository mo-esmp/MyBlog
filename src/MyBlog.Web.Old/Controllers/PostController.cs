using MyBlog.Common.Helpers;
using MyBlog.Domain;
using MyBlog.Service;
using MyBlog.Service.Contracts;
using MyBlog.Web.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace MyBlog.Web.Controllers
{
    [OutputCache(VaryByParam = "*", Duration = 60, Location = OutputCacheLocation.Client)]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly Lazy<ITagService> _tagService;

        public PostController(IPostService postService, Lazy<ITagService> tagService)
        {
            _postService = postService;
            _tagService = tagService;
        }

        // GET: Post/PostDetail
        public ActionResult PostDetail(int id, string slug)
        {
            var post = CacheHelper.GetItem(ApplicationKey.Post + id) as PostEntity;
            if (post != null)
                return View(post);

            post = _postService.GetPost(p => p.IsEnabled && p.Id == id && p.Slug == slug);
            if (post == null)
                return HttpNotFound();

            CacheHelper.AddItem(ApplicationKey.Post + id, post, new TimeSpan(0, 12, 0, 0));
            return View(post);
        }

        // GET: Post/PostsByTag
        public async Task<ActionResult> PostsByTag(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var homeViewModel = new HomeViewModel
            {
                Posts = await _postService.GetPostsAsync(p => p.IsEnabled && p.Tags.Any(t => t.Slug == slug), p => p.CreateDate, SortOrder.Descending, p => p.Tags),
                Tags = await _tagService.Value.GetTagsAsync()
            };
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}