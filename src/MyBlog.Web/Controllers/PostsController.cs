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
        [Route("post/{id}/{slug}")]
        public async Task<ActionResult> PostDetail(int id, string slug)
        {
            var post = await _mediator.Send(new PostGetActiveQuery(id, slug));
            if (post == null)
                return NotFound();

            return View(post);
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