using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public interface IPageContentService
    {
        List<PageSection> GetByPage(string pageKey);
        PageSection? GetSection(string pageKey, string sectionKey);
        List<string> GetAllPageKeys();
        void Save(PageSection section);
        void Delete(int id);
    }
}