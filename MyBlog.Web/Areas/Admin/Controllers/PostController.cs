using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Domain;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private MyBlogWebContext db = new MyBlogWebContext();

        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(db.PostEntities.ToList());
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostEntity postEntity = db.PostEntities.Find(id);
            if (postEntity == null)
            {
                return HttpNotFound();
            }
            return View(postEntity);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsEnabled,Slug,Title,Content,CreateDate,UpdateDte")] PostEntity postEntity)
        {
            if (ModelState.IsValid)
            {
                db.PostEntities.Add(postEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postEntity);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostEntity postEntity = db.PostEntities.Find(id);
            if (postEntity == null)
            {
                return HttpNotFound();
            }
            return View(postEntity);
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
                db.Entry(postEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postEntity);
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostEntity postEntity = db.PostEntities.Find(id);
            if (postEntity == null)
            {
                return HttpNotFound();
            }
            return View(postEntity);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostEntity postEntity = db.PostEntities.Find(id);
            db.PostEntities.Remove(postEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
