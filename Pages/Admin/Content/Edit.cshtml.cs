using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuralBankWeb.Models;
using RuralBankWeb.Services;

namespace RuralBankWeb.Pages.Admin.Content
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IPageContentService _contentService;
        public EditModel(IPageContentService contentService) => _contentService = contentService;

        [BindProperty]
        public PageSection Section { get; set; } = new();

        public void OnGet(int id = 0, string? pageKey = null)
        {
            if (id != 0)
            {
                var existing = _contentService.GetSection("", "");
                var all = _contentService.GetByPage(""); // placeholder, replaced below
            }

            if (id != 0)
            {
                var found = _contentService.GetByPage(pageKey ?? "").FirstOrDefault(s => s.Id == id);
                // fallback: search across all pages if pageKey wasn't passed
                if (found == null)
                {
                    found = _contentService.GetAllPageKeys()
                        .SelectMany(p => _contentService.GetByPage(p))
                        .FirstOrDefault(s => s.Id == id);
                }
                if (found != null) Section = found;
            }
            else if (!string.IsNullOrEmpty(pageKey))
            {
                Section.PageKey = pageKey;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _contentService.Save(Section);
            return RedirectToPage("Index");
        }
    }
}