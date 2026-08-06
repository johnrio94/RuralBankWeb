// using Microsoft.AspNetCore.Mvc.RazorPages;

// namespace RuralBankWeb.Pages
// {
//     public class AboutModel : PageModel
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
    public class AboutModel : PageModel
    {
        private readonly IPageContentService _contentService;
        public AboutModel(IPageContentService contentService) => _contentService = contentService;

        public PageSection? Intro { get; set; }

        public void OnGet()
        {
            Intro = _contentService.GetSection("About", "Intro");
        }
    }
}

