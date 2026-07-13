
using GameZone.Models;

namespace GameZone.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly AppDbContext _context;

        public CategoriesServices(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).OrderBy(x => x.Text)
               .ToList();
            
        }
    }
}
