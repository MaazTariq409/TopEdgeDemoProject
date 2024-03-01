using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TopEdgeDemoProject.Models;
using TopEdgeDemoProject.Repository.Interfaces;
using TopEdgeDemoProject.Services;

namespace TopEdgeDemoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScrapperService _scrapperService;
        private readonly IScrapRepository _scrapperRepository;

        public HomeController(ILogger<HomeController> logger, IScrapperService scrapperService, IScrapRepository scrapperRepository)
        {
            _logger = logger;
            _scrapperService = scrapperService;
            _scrapperRepository = scrapperRepository;
        }

        public IActionResult Index()
        {
            var scrapdata = new List<ScrapData>();
            if (ModelState.IsValid)
            {
                scrapdata = _scrapperRepository.GetScrapData();
            }
            return View(scrapdata);
        }

        public IActionResult uploadURl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult uploadURl (ScrapImageUploadDto model)
        {
            if (ModelState.IsValid)
            {
                var scrapedData = _scrapperService.Scrapper(model.BaseUrl);
                if (scrapedData != null)
                {
                    scrapedData.baseUrl = model.BaseUrl;
                    _scrapperRepository.AddScrapData(scrapedData);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteEntry(int id)
        {
            var item = _scrapperRepository.GetScrapDataById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteEntry(ScrapData data)
        {
            _scrapperRepository.DeleteScrapData(data.Id);
            return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}