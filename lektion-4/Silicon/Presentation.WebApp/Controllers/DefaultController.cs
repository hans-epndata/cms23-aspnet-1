using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class DefaultController : Controller
{
    public IActionResult Home()
    {
        return View();
    }
}
