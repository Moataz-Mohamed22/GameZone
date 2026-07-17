using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class EditGameFormVm:BaseVM
    {
        public int Id { get; set; }
        public string? CurrentCover  { get; set; }
        [AllowedExtensions(FileSettings.AllowedExtension), MaxFileSize(FileSettings.MaxFileSaizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
