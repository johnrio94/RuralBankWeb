using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class ApplyModel : PageModel
    {
        private readonly IJobOpeningService _jobService;
        private readonly IJobApplicationService _applicationService;

        public ApplyModel(IJobOpeningService jobService, IJobApplicationService applicationService)
        {
            _jobService = jobService;
            _applicationService = applicationService;
        }

        [BindProperty]
        public JobApplication Application { get; set; } = new();

        [BindProperty]
        [Required(ErrorMessage = "Please attach your resume.")]
        public IFormFile? Resume { get; set; }

        public JobOpening? Job { get; set; }
        public bool Submitted { get; set; } = false;

        public IActionResult OnGet(int jobId)
        {
            Job = _jobService.GetById(jobId);
            if (Job == null) return RedirectToPage("/Career");

            Application.JobId = Job.Id;
            Application.JobTitle = Job.Title;
            return Page();
        }

        public IActionResult OnPost()
        {
            Job = _jobService.GetById(Application.JobId);
            if (Job == null) return RedirectToPage("/Career");

            // Basic resume validation: type + size (5MB max)
            if (Resume != null)
            {
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                var ext = Path.GetExtension(Resume.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(ext))
                    ModelState.AddModelError("Resume", "Only PDF, DOC, or DOCX files are allowed.");

                if (Resume.Length > 5 * 1024 * 1024)
                    ModelState.AddModelError("Resume", "File size must not exceed 5MB.");
            }

            if (!ModelState.IsValid) return Page();

            _applicationService.Save(Application, Resume!);
            Submitted = true;
            return Page();
        }
    }
}