using System.ComponentModel.DataAnnotations;
using WebApp.Filters;

namespace WebApp.Models;

public class SignUpViewModel
{
    [Required]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm Password", Prompt = "Confirm your password")]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [CheckboxRequired]
    [Display(Name = "Terms & Conditions", Prompt = "I accept the terms and conditions")]
    public bool TermsAndConditions { get; set; }
}
