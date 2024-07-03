using E_USED.Models;
using E_USED.Models.Entity.Product;
using E_USED.Repository;
using Microsoft.AspNetCore.Mvc;
using SellingUsedThings.Enum;
using System.Diagnostics;

namespace E_USED.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<City> _cityRepository;


        public HomeController(ILogger<HomeController> logger, IRepository<Category> categoryRepository, IRepository<City> cityRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.Cities = _cityRepository.GetAll();
            return View();
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
