using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public abstract class BaseController : Controller
    {
    }
}