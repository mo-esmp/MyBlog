using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage([FromServices]IConfiguration configuration, [FromServices] IHostingEnvironment environment,
            IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload == null || upload.Length <= 0)
                return null;

            var uploadFolder = configuration["AppSettings:ImageUploadPath"];

            var path = Path.Combine(environment.WebRootPath, uploadFolder, upload.FileName);
            using (var outputFile = System.IO.File.OpenWrite(path))
            {
                await upload.OpenReadStream().CopyToAsync(outputFile);
                outputFile.Close();
            }

            var request = HttpContext.Request;
            var imageVirtualPath = Path.Combine(uploadFolder, upload.FileName);
            var uriBuilder = new UriBuilder
            {
                Host = request.Host.Host,
                Scheme = request.Scheme,
                Path = imageVirtualPath
            };

            if (request.Host.Port.HasValue)
                uriBuilder.Port = request.Host.Port.Value;

            var url = uriBuilder.ToString();

            const string message = "عکس با موفقیت آپلود شد.";

            var output = $"<html><body><script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum}, \"{url}\", \"{message}\");</script></body></html>";

            return Content(output, "text/html");
        }
    }
}