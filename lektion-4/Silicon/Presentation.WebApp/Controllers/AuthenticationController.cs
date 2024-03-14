using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

public class AuthenticationController : Controller
{

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

        }

        return View(viewModel);
    }
}
