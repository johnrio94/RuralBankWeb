namespace RuralBankWeb.Services
{
    public interface IEmailService
    {
        Task SendContactFormEmailAsync(string fullName, string phone, string email, string message);
    }
}