using RuralBankWeb.Data;
using RuralBankWeb.Models;

namespace RuralBankWeb.Services
{
    public class PageContentService : IPageContentService
    {
        private readonly AppDbContext _db;
        public PageContentService(AppDbContext db) => _db = db;

        public List<PageSection> GetByPage(string pageKey) =>
            _db.PageSections.Where(s => s.PageKey == pageKey)
                             .OrderBy(s => s.SortOrder).ToList();

        public PageSection? GetSection(string pageKey, string sectionKey) =>
            _db.PageSections.FirstOrDefault(s => s.PageKey == pageKey && s.SectionKey == sectionKey);

        public List<string> GetAllPageKeys() =>
            _db.PageSections.Select(s => s.PageKey).Distinct().OrderBy(p => p).ToList();

        public void Save(PageSection section)
        {
            if (section.Id == 0)
                _db.PageSections.Add(section);
            else
                _db.PageSections.Update(section);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var section = _db.PageSections.Find(id);
            if (section != null)
            {
                _db.PageSections.Remove(section);
                _db.SaveChanges();
            }
        }
    }
}