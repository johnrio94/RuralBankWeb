using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RuralBankWeb.Pages
{
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }

        public void OnGet()
        {
            RequestId = HttpContext.TraceIdentifier;
        }
    }
}
