using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Entities;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;


    [Route("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> Register(RegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == form.Email))
            {
                if ((await _userManager.CreateAsync(form, form.Password)).Succeeded)
                {
                    if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                        return RedirectToAction("Home", "Default");
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User already exists";
            }
        }

        return View(form);
    }





    [Route("/login")]
    public IActionResult Login(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }

    [HttpPost]
    [Route("/login")] 
    public async Task<IActionResult> Login(LoginForm form, string returnUrl)
    {
        if (ModelState.IsValid)
            if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                return LocalRedirect(returnUrl);

        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(form);
    }




    [Route("/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }
}
