using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly IJobOpeningService _jobService;
        public IndexModel(IJobOpeningService jobService) => _jobService = jobService;

        public List<JobOpening> Jobs { get; set; } = new();

        public void OnGet()
        {
            Jobs = _jobService.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _jobService.Delete(id);
            return RedirectToPage();
        }

        public IActionResult OnPostToggleActive(int id)
        {
            var job = _jobService.GetById(id);
            if (job != null)
            {
                job.IsActive = !job.IsActive;
                _jobService.Save(job);
            }
            return RedirectToPage();
        }
    }
}