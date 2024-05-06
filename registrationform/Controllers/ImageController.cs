using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using registrationform.Models;
using System.Collections.Generic;
using System.IO;

namespace registrationform.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            string jsonFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "home", "db.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            var images = JsonConvert.DeserializeObject<List<ImageModel>>(jsonContent);

            return View(images);
        }
    }
}
