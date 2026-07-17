namespace GameZone.Services
{
    public interface IGamesServices
    {
        public IEnumerable<Game> GetAll();
        public Game? GetById(int id);
        public Task  Create (CreateGameFormVM Game);
        public Task<Game?>  Update (EditGameFormVm Game);
        public bool Delete (int id);
    }
}
