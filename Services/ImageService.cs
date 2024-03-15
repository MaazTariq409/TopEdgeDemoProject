using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace TopEdgeDemoProject.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly HttpClient _webClient;

        public ImageService(IWebHostEnvironment environment, HttpClient webClient)
        {
            _environment = environment;
            _webClient = webClient;
        }

        //public async Task<string> DownloadFile(string filePath)
        //{
        //    using (var webClient = new HttpClient())
        //    {
        //        var response = await webClient.GetAsync(filePath);
        //        byte[] content = await response.Content.ReadAsByteArrayAsync();

        //        UploadImage(File(content));
        //    }

        //    return string.Empty;
        //}

        //private String UploadImage(IFormFile? file)
        //{
        //    string wwwrootpath = _environment.WebRootPath;
        //    if (file != null)
        //    {
        //        string filename = Guid.NewGuid().ToString();
        //        var Uploadpath = Path.Combine(wwwrootpath, @"images\");
        //        var extension = Path.GetExtension(file.FileName);

        //        using (var fileStream = new FileStream(Path.Combine(Uploadpath, filename + extension), FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }
        //        var imageUrl = @"\images\" + filename + extension;
        //        return imageUrl;
        //    }
        //    else
        //    {
        //        return "Failed to save Image";
        //    }
        //}

        public async Task<string> DownloadFile(string filePath)
        {
            using (var webClient = new HttpClient())
            {
                var response = await webClient.GetAsync(filePath);
                if (response.IsSuccessStatusCode)
                {
                    byte[] content = await response.Content.ReadAsByteArrayAsync();
                    string imageUrl = UploadImage(content);
                    return imageUrl;
                }
                else
                {
                    return "Failed to download image";
                }
            }
        }

        private string UploadImage(byte[] content)
        {
            string wwwrootpath = _environment.WebRootPath;
            string filename = Guid.NewGuid().ToString();
            var uploadPath = Path.Combine(wwwrootpath, "images");
            var imageUrl = Path.Combine(uploadPath, filename + ".jpg");

            try
            {
                using (var fileStream = new FileStream(imageUrl, FileMode.Create))
                {
                    fileStream.Write(content, 0, content.Length);
                }
                return "/images/" + filename + ".jpg"; // Assuming the images are served from the "images" directory
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save image: " + ex.Message);
                return "Failed to save image";
            }
        }

    }
}
