

namespace GameZone.Services
{
    public class GamesServices : IGamesServices
    {
        private readonly AppDbContext _context;
        private readonly string _imagePath;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GamesServices(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(gd => gd.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }
        public Game? GetById(int id)
        {
            return _context.Games
                            .Include(g => g.Category)
                            .Include(gd => gd.Devices)
                            .ThenInclude(d => d.Device)
                            .AsNoTracking()
                            .SingleOrDefault(g => g.Id == id);
        }

        public async Task Create(CreateGameFormVM model)
        {
            var coverName = await SaveCover(model.Cover);
            Game game = new()
            {
                Name = model.Name,
                Cover = coverName,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Devices = model.SelectedDevices.
                Select(d => new GameDevice { DeviceID = d })
                .ToList(),
            };
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public async Task<Game?> Update(EditGameFormVm model)
        {
            var game = _context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.Id == model.Id);
            if (game == null)
                return null;

            var hasNotCover = model.Cover != null;
            var oldCover = game.Cover;
            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceID = d }).ToList();


            if (hasNotCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }
            var effectedRow = _context.SaveChanges();
            if (effectedRow > 0)
            {
                if (hasNotCover)
                {
                    var cover = Path.Combine(_imagePath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
                return null;
            }

        }

        public bool Delete(int id)
        {
            var game = _context.Games.Find(id);

            if (game == null)
                return false;

            _context.Games.Remove(game);

            var effectedRow = _context.SaveChanges();

            if (effectedRow > 0)
            {
                var cover = Path.Combine(_imagePath, game.Cover);

                if (File.Exists(cover))
                    File.Delete(cover);

                return true;
            }

            return false;
        }
        private async Task<string> SaveCover(IFormFile Cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName);
            using var stream = File.OpenWrite(path);
            await Cover.CopyToAsync(stream);
            return coverName;
        }


    }

}
