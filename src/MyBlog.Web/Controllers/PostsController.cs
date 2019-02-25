using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<ActionResult> PostDetail(int id, string slug)
        {
            var date = await _mediator.Send(new PostGetDateQuery(slug));
            if (date == null)
                return NotFound();

            return RedirectPermanent(
                Url.Action("PostDetail", new {date.Value.Year, date.Value.Month, date.Value.Day, slug}));
        }

        // GET: Post/PostsByTag
        [Route("tag/{slug}")]
        public async Task<ActionResult> PostsByTag(string slug, int page = 1)
        {
            if (string.IsNullOrEmpty(slug))
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);

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