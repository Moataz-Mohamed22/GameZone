

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGamesServices _gamesServices;

        public GamesController( ICategoriesServices categoriesServices,
                                IDevicesServices devicesServices,
                                IGamesServices gamesServices)
        {
            _categoriesServices = categoriesServices;
            _devicesServices = devicesServices;
            _gamesServices = gamesServices;
        }

        public IActionResult Index()
        {

            var games = _gamesServices.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game =_gamesServices.GetById(id);
            if(game == null)
            {
                return NotFound();
            }
            return View(game);

        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormVM vm = new()
            {
                Categories = _categoriesServices.GetSelectListItems(),
                Devices = _devicesServices.SelectListItem()

            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectListItems();
                model.Devices = _devicesServices.SelectListItem();
                return View(model); 
            }
            await _gamesServices.Create(model);
            return Redirect(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var game = _gamesServices.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            EditGameFormVm vm = new() 
            { 
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices=game.Devices.Select(e=>e.DeviceID).ToList(),
                Categories = _categoriesServices.GetSelectListItems(),
                Devices = _devicesServices.SelectListItem(),
                CurrentCover = game.Cover
            };
            return View(vm);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormVm model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectListItems();
                model.Devices = _devicesServices.SelectListItem();
                return View(model);
            }
           var game= await _gamesServices.Update(model);
            if(game is null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted =_gamesServices.Delete(id);
            return isDeleted? Ok():BadRequest();
        }
    }

}
