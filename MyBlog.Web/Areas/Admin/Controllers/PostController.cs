using MyBlog.Domain;
using MyBlog.Service.Contracts;
using MyBlog.Web.Areas.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<ITagService> _tagService;

        public PostController(Lazy<IPostService> postService, Lazy<ITagService> tagService)
        {
            _postService = postService;
            _tagService = tagService;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            var posts = _postService.Value.GetPosts(null, p => p.Tags).OrderByDescending(p => p.CreateDate);
            return View(posts);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Post.Id,Post.UpdateDte")] PostViewModel potViewModel)
        {
            if (ModelState.IsValid)
            {
                _postService.Value.AddPost(potViewModel.Post, potViewModel.Tags);
                if (_tagService.Value.Commit())
                    return RedirectToAction("Index");

                ModelState.AddModelError("Save", "هنگام ثبت مقاله خطایی رخ داده است.");
            }

            return View(potViewModel);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PostEntity postEntity = db.PostEntities.Find(id);
            //if (postEntity == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsEnabled,Slug,Title,Content,CreateDate,UpdateDte")] PostEntity postEntity)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(postEntity).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PostEntity postEntity = db.PostEntities.Find(id);
            //db.PostEntities.Remove(postEntity);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string GetTags()
        {
            var tags = _tagService.Value.GetTags();
            var tagStr = JsonConvert.SerializeObject(tags.Select(t => new { value = t.Id, text = t.Name }));
            return tagStr;
        }
    }
}