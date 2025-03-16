using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;


namespace SarowaLibrary.ToolsLayer.FileManagement
{
    public static class SaveFile
    {
        public static async Task<string> SaveFileAsync(this IFormFile file, string SaveLocation)
        {
            if (file != null && file.Length > 2 && SaveLocation.Length > 4)
             {
                 string insavedlocation = SaveLocation;
                 if (!SaveLocation.Contains("wwwroot"))
                     SaveLocation = Path.Combine("wwwroot", SaveLocation);
                 if (!Directory.Exists(SaveLocation))
                     Directory.CreateDirectory(SaveLocation);
                 Guid guid = Guid.NewGuid();
                 while (Directory.Exists(Path.Combine(SaveLocation, guid.ToString())))
                 {
                     guid = Guid.NewGuid();
                 }
                 Directory.CreateDirectory(Path.Combine(SaveLocation, guid.ToString()));
                 string path = Path.Combine(SaveLocation, guid.ToString(), file.FileName);
                 if (file.ContentType.Contains("image"))
                 {
                     using var img = Image.Load(file.OpenReadStream());
                     img.Resize();  
                     img.Save(path);
                 }
                 else
                 {
                     using (var fs = new FileStream(path, FileMode.Create))
                     {
                         file.CopyTo(fs);
                     }
                 }
                 insavedlocation = Path.Combine(insavedlocation, guid.ToString(), file.FileName);
                 if (insavedlocation[0] != '\\' || insavedlocation[0] != '/')
                     insavedlocation = "\\" + insavedlocation;
                 insavedlocation = insavedlocation.Replace('\\', '/');
                 return insavedlocation;
             }
             return "";
        }
    }
}
