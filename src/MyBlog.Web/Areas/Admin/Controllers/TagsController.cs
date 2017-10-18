using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.Queries;
using System.Threading.Tasks;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class TagsController : BaseController
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _mediator.Send(new TagGetsQuery());

            return Ok(entities);
        }
    }
}