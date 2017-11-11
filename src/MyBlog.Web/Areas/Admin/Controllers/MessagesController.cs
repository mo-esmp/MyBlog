using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core;
using MyBlog.Core.Commands;
using MyBlog.Core.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public MessagesController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/messages/index
        public async Task<ActionResult> Index()
        {
            var messages = await _mediator.Send(new MessageGetsQuery());

            return View(messages);
        }

        // GET: Admin/messages/detail
        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
                return BadRequest();

            var messages = await _mediator.Send(new MessageGetQuery { MessageId = id.Value });

            return View(messages);
        }

        // DELETE: Admin/message/delete
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int[] idList)
        {
            if (idList == null || !idList.Any())
                return BadRequest();

            await _mediator.Send(new MessagesRemoveCommand { MessageIds = idList });
            await _unitOfWork.CommitAsync();

            return Json(new { });
        }
    }
}