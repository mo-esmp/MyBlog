using MyBlog.Service.Contracts;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "administrator")]
    public class BaseController : Controller
    {
        private readonly IContactMessageService _contactMessageService;

        public BaseController()
        {
        }

        public BaseController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        [ChildActionOnly]
        public ActionResult NewMessage()
        {
            var newMessages = _contactMessageService.GetMessages(m => m.IsNew);
            return PartialView("_NewMessage", newMessages);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload == null || upload.ContentLength <= 0)
                return null;

            // here logic to upload image
            // and get file path of the image

            const string uploadFolder = "images/upload";

            var fileName = Path.GetFileName(upload.FileName);
            var path = Path.Combine(Server.MapPath(string.Format("~/{0}", uploadFolder)), fileName);
            upload.SaveAs(path);

            var url = string.Format("{0}{1}/{2}/{3}", Request.Url.GetLeftPart(UriPartial.Authority),
                Request.ApplicationPath == "/" ? string.Empty : Request.ApplicationPath,
                uploadFolder, fileName);

            // passing message success/failure
            const string message = "عکس با موفقیت آپلود شد.";

            // since it is an ajax request it requires this string
            var output = string.Format(
                "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                CKEditorFuncNum, url, message);

            return Content(output);
        }
    }
}