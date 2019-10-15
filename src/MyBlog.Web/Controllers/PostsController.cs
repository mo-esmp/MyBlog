using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyBlog.Core.Queries;
using MyBlog.Web.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyBlog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;

        public PostsController(IMediator mediator, IOptions<AppSettings> settings)
        {
            _mediator = mediator;
            _appSettings = settings.Value;
        }

        // GET: Post/PostDetail
        [Route("post/{year}/{month}/{day}/{slug}")]
        public async Task<ActionResult> PostDetail(int year, int month, int day, string slug)
        {
            var result = DateTime.TryParse($"{month}/{day}/{year} 00:00:00", out var date);
            if (!result)
                return NotFound();

            var post = await _mediator.Send(new PostGetActiveBySlugAndDateQuery(date, slug));
            if (post == null)
                return NotFound();

            return View(post);
        }

        // GET: Post/PostDetail
        [Route("post/{id}/{slug}")]
        public async Task<ActionResult> PostDetail(string id, string slug)
        {
            if (_appSettings.Redirect.ContainsKey(id))
            {
                var parts = _appSettings.Redirect[id].Split('/');
                return RedirectPermanent(Url.Action("PostDetail", new { year = parts[0], month = parts[1], day = parts[2], slug = parts[3] }));
            }

            var post = await _mediator.Send(new PostGetOldBySlugQuery(slug));
            if (post == null)
                return NotFound();

            return RedirectPermanent(
                Url.Action("PostDetail", new { post.CreateDate.Year, post.CreateDate.Month, post.CreateDate.Day, post.Slug }));
        }

        // GET: Post/PostsByTag
        [Route("tag/{slug}")]
        public async Task<ActionResult> PostsByTag(string slug, int page = 1)
        {
            if (string.IsNullOrEmpty(slug))
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            var (posts, postCount) = await _mediator.Send(new PostGetsPagedQuery(page, slug));
            var homeViewModel = new HomeViewModel
            {
                CurrentPage = page,
                Posts = posts,
                TotalPosts = postCount
            };

            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}