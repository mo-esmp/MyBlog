using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.Queries;
using System.Threading.Tasks;

namespace MyBlog.Web.ViewComponents
{
    public class TagsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public TagsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tags = await _mediator.Send(new TagGetsQuery());

            return View(tags);
        }
    }
}