using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core;
using MyBlog.Core.Commands;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Web.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class TagsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public TagsController(IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Tags
        public async Task<ActionResult> Index()
        {
            var entities = await _mediator.Send(new TagGetsQuery());
            var viewModels = _mapper.Map<IEnumerable<TagViewModel>>(entities);

            return View(viewModels);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tags/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name")] TagViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var entity = _mapper.Map<TagEntity>(viewModel);
            await _mediator.Send(new TagAddCommand { Tag = entity });
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }

        // GET: Admin/طاگ/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var entity = await _mediator.Send(new TagGetQuery { TagId = id.Value });
            if (entity == null)
                return NotFound();

            var viewModel = _mapper.Map<TagViewModel>(entity);

            return View(viewModel);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id", "Name")]TagViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var entity = _mapper.Map<TagEntity>(viewModel);
            await _mediator.Send(new TagEditCommand { Tag = entity });
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }

        // POST: Admin/Tags/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            await _mediator.Send(new TagRemoveCommand { TagId = id.Value });
            await _unitOfWork.CommitAsync();

            return Json(new { });
        }
    }
}