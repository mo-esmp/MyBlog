using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.Queries;
using MyBlog.Web.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _mediator.Send(new PostGetsQuery());
            var tags = await _mediator.Send(new TagGetsQuery());
            var homeViewModel = new HomeViewModel { Posts = posts, Tags = tags };

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}