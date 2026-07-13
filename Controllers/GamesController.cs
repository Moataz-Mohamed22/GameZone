

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoriesServices _categoriesServices;

        public GamesController(AppDbContext context, ICategoriesServices categoriesServices)
        {
            _context = context;
            _categoriesServices = categoriesServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormVM vm = new()
            {
                Categories = _categoriesServices.GetSelectListItems(),
                Devices = _context.Devices.Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                }).OrderBy(d => d.Text)
                .ToList(),

            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectListItems();
                model.Devices = _context.Devices.Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                }).OrderBy(d => d.Text)
                 .ToList();
                return View(model); 
            }
            return Redirect(nameof(Index));
        }
    }
}
