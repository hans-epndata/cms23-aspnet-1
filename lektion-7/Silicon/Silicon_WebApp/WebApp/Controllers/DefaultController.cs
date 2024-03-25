using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
