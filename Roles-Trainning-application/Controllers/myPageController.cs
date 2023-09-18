using Microsoft.AspNetCore.Mvc;

namespace Roles_Trainning_application.Controllers
{
    public class myPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
