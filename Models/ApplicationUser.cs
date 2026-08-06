using Microsoft.AspNetCore.Identity;

namespace RuralBankWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}