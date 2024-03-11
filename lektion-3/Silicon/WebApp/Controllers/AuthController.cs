using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AuthController : Controller
{

    #region SignIn
    [Route("/login")]
    public IActionResult SignIn()
    {
        return View();
    }
    #endregion


    #region SignUp
    [Route("/register")]
    public IActionResult SignUp()
    {
        return View();
    }
    #endregion

}
