using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class CareerModel : PageModel
    {
        private readonly IJobOpeningService _jobService;
        private readonly IPageContentService _contentService;

        public CareerModel(IJobOpeningService jobService, IPageContentService contentService)
        {
            _jobService = jobService;
            _contentService = contentService;
        }

        public List<JobOpening> OpenPositions { get; set; } = new();
        public PageSection? Hero { get; set; }

        public void OnGet()
        {
            OpenPositions = _jobService.GetActive();
            Hero = _contentService.GetSection("Career", "Hero");
        }
    }
}