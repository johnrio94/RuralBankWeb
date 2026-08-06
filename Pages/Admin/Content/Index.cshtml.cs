using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Content
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPageContentService _contentService;
        public IndexModel(IPageContentService contentService) => _contentService = contentService;

        public List<PageSection> Sections { get; set; } = new();

        // Known pages in your site — add more as needed
        public List<string> KnownPages { get; set; } = new()
        {
            "Career", "About", "News", "AccountOpen", "AgriculturalLoans",
            "AgriRes", "AnnualReport", "AvailableProperties", "TimeDeposit"
        };

        public void OnGet()
        {
            Sections = _contentService.GetAllPageKeys()
                .SelectMany(p => _contentService.GetByPage(p))
                .ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            _contentService.Delete(id);
            return RedirectToPage();
        }
    }
}