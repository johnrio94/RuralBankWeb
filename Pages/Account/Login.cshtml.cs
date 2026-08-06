using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using RuralBankWeb.Models;

namespace RuralBankWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginModel(SignInManager<ApplicationUser> signInManager) => _signInManager = signInManager;

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required, EmailAddress]
            public string Email { get; set; } = "";

            [Required, DataType(DataType.Password)]
            public string Password { get; set; } = "";
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var result = await _signInManager.PasswordSignInAsync(
                Input.Email, Input.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
                return RedirectToPage("/Admin/Content/Index");

            ErrorMessage = "Invalid email or password.";
            return Page();
        }
    }
}