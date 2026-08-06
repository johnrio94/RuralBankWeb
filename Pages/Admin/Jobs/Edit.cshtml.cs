using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IJobOpeningService _jobService;
        public EditModel(IJobOpeningService jobService) => _jobService = jobService;

        [BindProperty]
        public JobOpening Job { get; set; } = new();

        public void OnGet(int id = 0)
        {
            if (id != 0)
            {
                var existing = _jobService.GetById(id);
                if (existing != null) Job = existing;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _jobService.Save(Job);
            TempData["Message"] = Job.Id == 0 ? "Job posted." : "Job updated.";
            return RedirectToPage("Index");
        }
    }
}