using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;


[Authorize]
public class DefaultController : Controller
{
    public IActionResult Home()
    {
        var user = User;
        
        return View();
    }

    public IActionResult Test()
    {

        return View();
    }

}
