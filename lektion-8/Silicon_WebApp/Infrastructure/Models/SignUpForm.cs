using Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpForm
{
    [Required(ErrorMessage = "You must enter a first name")]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a last name")]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set;} = null!;

    [Required(ErrorMessage = "You must enter an e-mail address")]
    [Display(Name = "E-mail address", Prompt = "Enter your e-mail address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a password")]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "You must confirm your password")]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [CheckboxRequired(ErrorMessage = "You accept the terms and conditions")]
    [Display(Name = "I accept the Terms & Conditions")]
    public bool Terms { get; set; }

}
