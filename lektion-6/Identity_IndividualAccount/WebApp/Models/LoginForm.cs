using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class LoginForm
{
    [Required]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
