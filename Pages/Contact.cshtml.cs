using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailService _emailService;
        public ContactModel(IEmailService emailService) => _emailService = emailService;

        [BindProperty]
        public FormModel Form { get; set; } = new();

        public bool Submitted { get; set; } = false;
        public string? ErrorMessage { get; set; }

        public class FormModel
        {
            [Required(ErrorMessage = "Please enter your full name.")]
            public string FullName { get; set; } = "";

            [Required(ErrorMessage = "Please enter your phone number.")]
            [Phone(ErrorMessage = "Please enter a valid phone number.")]
            public string Phone { get; set; } = "";

            [Required(ErrorMessage = "Please enter your email address.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; } = "";

            [Required(ErrorMessage = "Please enter a message.")]
            public string Message { get; set; } = "";
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _emailService.SendContactFormEmailAsync(
                    Form.FullName, Form.Phone, Form.Email, Form.Message);

                Submitted = true;
                Form = new FormModel();
            }
            catch (Exception ex)
{
    Console.WriteLine("EMAIL SEND ERROR: " + ex.Message);
    Console.WriteLine(ex.ToString());
    ErrorMessage = "Sorry, something went wrong sending your message. Please try again or call us directly.";
}

            return Page();
        }
    }
}