using MyBlog.Domain;
using MyBlog.Service.Contracts;
using System.Net;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Admin/Tag
        public ActionResult Index()
        {
            var tags = _tagService.GetTags();
            return View(tags);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id,Slug")] TagEntity tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.AddTag(tag);
                if (_tagService.Commit())
                    return RedirectToAction("Index");

                ModelState.AddModelError("Save", "هنگام ثبت تگ خطایی رخ داده است.");
            }

            return View(tag);
        }

        // GET: Admin/طاگ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tag = _tagService.GetTag(id.Value);
            if (tag == null)
                return HttpNotFound();

            return View(tag);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Slug")]TagEntity tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.EditTag(tag);
                if (_tagService.Commit())
                    return RedirectToAction("Index");

                ModelState.AddModelError("Save", "هنگام ویرایش تگ خطایی رخ داده است.");
            }

            return View(tag);
        }

        // POST: Admin/Tag/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 400;
                return Json("Bad Request", JsonRequestBehavior.AllowGet);
            }

            _tagService.DeleteTag(id.Value);
            if (_tagService.Commit() == false)
            {
                _tagService.Rollback();
                Response.StatusCode = 404;
                return Json("Not Found", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}