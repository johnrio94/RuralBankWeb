// using Microsoft.AspNetCore.Mvc.RazorPages;

// namespace RuralBankWeb.Pages
// {
//     public class IndexModel : PageModel
//     {
//         public void OnGet()
//         {
//         }
//     }
// }


using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IJobOpeningService _jobService;
        private readonly IPageContentService _contentService;

        public IndexModel(IJobOpeningService jobService, IPageContentService contentService)
        {
            _jobService = jobService;
            _contentService = contentService;
        }

        public PageSection? Hero { get; set; }
        public int OpenJobsCount { get; set; }

        public void OnGet()
        {
            Hero = _contentService.GetSection("Home", "Hero");
            OpenJobsCount = _jobService.GetActive().Count;
        }
    }
}