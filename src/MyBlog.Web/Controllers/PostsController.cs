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
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        //private readonly IUnitOfWork _unitOfWork;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
            //_mapper = mapper;
            //_unitOfWork = unitOfWork;
        }

        // GET: Post/PostDetail
        [Route("post/{year}/{month}/{day}/{slug}")]
        public async Task<ActionResult> PostDetail(int year, int month, int day, string slug)
        {
            var result = DateTime.TryParse($"{month}/{day}/{year} 00:00:00", out var date);
            if (!result)
                return NotFound();

            var post = await _mediator.Send(new PostGetActiveQuery(date, slug));
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

        // POST: Post/Comment
        //[HttpPost("post/{postId}/comment")]
        //public async Task<IActionResult> PostComment(int postId, [FromBody]CommentViewModel viewModel)
        //{
        //    if (!User.Identity.IsAuthenticated && !ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var comment = _mapper.Map<CommentEntity>(viewModel);
        //    if (User.Identity.IsAuthenticated)
        //        comment.IsAdmin = true;

        //    await _mediator.Send(new CommentAddCommand(comment));
        //    await _unitOfWork.CommitAsync();

        //    return Json(new { });
        //}
    }
}