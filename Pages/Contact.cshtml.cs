using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm Form { get; set; } = new();

        public bool Submitted { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: send email, save to database, or call a CRM API here.
            Submitted = true;
            ModelState.Clear();
            Form = new ContactForm();
            return Page();
        }

        public class ContactForm
        {
            [Required(ErrorMessage = "Please enter your full name.")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please enter a contact number or email.")]
            public string ContactInfo { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please choose a branch.")]
            public string Branch { get; set; } = string.Empty;

            [Required(ErrorMessage = "Please enter a message.")]
            public string Message { get; set; } = string.Empty;
        }
    }
}
