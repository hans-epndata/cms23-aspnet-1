using Infrastructure.Factories;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;


    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpForm form)
    {
        if (ModelState.IsValid)
        {
            string roleName = "User";

            if (!await _userManager.Users.AnyAsync())
                roleName = "Admin";


            if(!await _userManager.Users.AnyAsync(x => x.Email == form.Email))
            {
                var appUser = UserFactory.Create(form.FirstName, form.LastName, form.Email); 

                if((await _userManager.CreateAsync(appUser, form.Password)).Succeeded) 
                { 
                    await _userManager.AddToRoleAsync(appUser, roleName);

                    if ((await _signInManager.PasswordSignInAsync(appUser.Email!, form.Password, false, false)).Succeeded)
                        return LocalRedirect("/");

                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email address already exists";
            }
        }

        return View(form);
    }

    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }


    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInForm form, string returnUrl)
    {
        if(ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                return LocalRedirect("/");
        }

        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(form);
    }

    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }
}
