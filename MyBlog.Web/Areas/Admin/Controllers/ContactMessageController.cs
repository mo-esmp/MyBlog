using MyBlog.Service.Contracts;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ContactMessageController : BaseController
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactMessageController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        //
        // GET: Admin/ContactMessage/Index
        public ActionResult Index()
        {
            var messages = _contactMessageService.GetMessages().OrderByDescending(m => m.CreateDate);
            return View(messages);
        }

        //
        // GET: Admin/ContactMessage/MessageDetail

        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var message = _contactMessageService.GetMessage(id.Value);
            if (message == null)
                return HttpNotFound();

            return View(message);
        }

        //
        // POST: Admin/ContactMessage/UpdateMessage
        [HttpPost]
        public JsonResult UpdateMessage(int[] idList, bool isNew)
        {
            if (idList == null || !idList.Any())
            {
                Response.StatusCode = 400;
                return Json("Bad Request", JsonRequestBehavior.AllowGet);
            }

            _contactMessageService.EditMessage(idList, isNew);
            if (_contactMessageService.Commit() == false)
            {
                Response.StatusCode = 404;
                return Json("Not Found", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: Admin/ContactMessage/DeleteMessage
        [HttpPost]
        public JsonResult DeleteMessage(int[] idList)
        {
            if (idList == null || !idList.Any())
            {
                Response.StatusCode = 400;
                return Json("Bad Request", JsonRequestBehavior.AllowGet);
            }

            _contactMessageService.DeleteMessages(idList);
            if (_contactMessageService.Commit() == false)
            {
                Response.StatusCode = 404;
                return Json("Not Found", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}