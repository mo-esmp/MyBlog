using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.Queries;
using MyBlog.Web.Models;
using System;
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

        public async Task<IActionResult> Index(int page = 1)
        {
            var (posts, postCount) = await _mediator.Send(new PostGetsPagedQuery(page));
            var homeViewModel = new HomeViewModel
            {
                CurrentPage = page,
                Posts = posts,
                TotalPosts = postCount
            };

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(ContactMessageViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(viewModel);

        //    var message = Mapper.Map<ContactMessageEntity>(viewModel);
        //    await _mediator.Send(new MessageAddCommand(message));

        //    if (!await _unitOfWork.CommitAsync())
        //    {
        //        ModelState.AddModelError("Create", "هنگام ثبت پیام خطایی رخ داده است. لطفا بعدا سعی نمایید.");
        //        return View(viewModel);
        //    }

        //    await _mailService.Value.ContactMail(contactMessage.Name, contactMessage.Email, contactMessage.Message).SendAsync();
        //    TempData["Successful"] = true;
        //    ModelState.Clear();

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}