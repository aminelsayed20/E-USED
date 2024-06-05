using E_USED.Models.Entity.Product;
using E_USED.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SellingUsedThings.Enum;
using SellingUsedThings.Models.Entity;

namespace E_USED.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Product> _productRepository;
        public ProductsController(UserManager<AppUser> userManager, IRepository<Product> productRepository)
        {
            this._userManager = userManager;
            this._productRepository = productRepository;
        }
        public IActionResult Index()
        {
           var cities= Enum.GetValues(typeof(Citeis)).Cast<Citeis>().ToList();
            var city =  Citeis.Giza; 
            ViewBag.City = cities;
            return View("Create");
        }
    }
}
