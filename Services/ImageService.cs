using Microsoft.AspNetCore.Hosting;

namespace TopEdgeDemoProject.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _environment;

        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        private String UploadImage(IFormFile? file)
        {
            string wwwrootpath = _environment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var Uploadpath = Path.Combine(wwwrootpath, @"images\");
                var extension = Path.GetExtension(file.FileName);

                using (var fileStream = new FileStream(Path.Combine(Uploadpath, filename + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var imageUrl = @"\images\" + filename + extension;
                return imageUrl;
            }
            else
            {
                return "Failed to save Image";
            }
        }
    }
}
