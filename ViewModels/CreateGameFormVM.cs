using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFormVM:BaseVM
    {
  
        
        [AllowedExtensions(FileSettings.AllowedExtension),MaxFileSize(FileSettings.MaxFileSaizeInBytes)]
        public IFormFile Cover { get; set; } =default!;

    }
}
