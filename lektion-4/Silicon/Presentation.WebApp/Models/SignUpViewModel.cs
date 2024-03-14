using Presentation.WebApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Models;

public class SignUpViewModel
{

    [Required(ErrorMessage = "You must enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "You must enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email address")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;



    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must enter a password")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    public string Password { get; set; } = null!;



    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    public string ConfirmPassword { get; set; } = null!;


    [CheckboxRequired(ErrorMessage = "You must accept the Terms and Conditions")]
    public bool TermsAndConditions { get; set; }
}