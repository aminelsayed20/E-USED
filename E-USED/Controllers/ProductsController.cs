using E_USED.Data;
using E_USED.Dtos;
using E_USED.Models.Entity.Product;
using E_USED.Repository;
using E_USED.Repository.Interfaces;
using E_USED.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SellingUsedThings.Enum;
using SellingUsedThings.Models.Entity;

namespace E_USED.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Product> _productRepository;
        private readonly ILogger<ProductsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IProductServices _services;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<City> _cityRepository;



        public ProductsController(UserManager<AppUser> userManager, IRepository<Product> productRepository,
            ApplicationDbContext context, ILogger<ProductsController> logger, IProductServices productServices,
            IRepository<Category> categoryRepository,IRepository<City> cityRepository)
        {
            _userManager = userManager;
            _productRepository = productRepository;
            _logger = logger;
            _context = context;
            _services = productServices;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.Cities =  _cityRepository.GetAll();

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProductViewModel productdto)
        {
            if (ModelState.IsValid)
            {
                var cuurentUser = _userManager.GetUserAsync(User).Result;
                var newproduct = new Product()
                {
                    Name = productdto.Name,
                    Description = productdto.Description,
                    Price = productdto.Price,
                    Location = productdto.Location,
                    CityId = productdto.CityId,
                    CategoryId = productdto.CategoryId,
                    UserId = cuurentUser.Id,
                    Images = _services.StoreImages(productdto.Images, productdto.Id)
                };
                _productRepository.Insert(newproduct);
                _productRepository.Save();
                return Redirect(nameof(Index));
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Cities = _context.Cities.ToList();
                return View(nameof(Create), productdto);
            }
            
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View("Index");
        }

        [HttpGet]
        public IActionResult Filtration(FilterProductModel filterProductModel)
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.Cities = _cityRepository.GetAll();

            var products = _productRepository.GetAll().AsQueryable();

            /*            products.ForEach(product => new ProductForListDto
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Location = product.Location,
                            City = _cityRepository.Get(c => c.Id == product.CityId).Name.ToString(),
                            Time = $"{DateTime.Now.DayOfYear - product.CreatedAt.DayOfYear} Day ago",
                            ImagePath = product.Images.First().ImagePath,
                            PhoneNumber = _userManager.GetUserAsync(User).Result.PhoneNumber

                        });*/

            var productsDto  =  products.Select(p => 
                new ProductForListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Location = p.Location,
                    City = _cityRepository.Get(c => c.Id == p.CityId).Name.ToString(),
                    Time = $"{DateTime.Now.DayOfYear - p.CreatedAt.DayOfYear} Day ago",
                    ImagePath = p.Images.First().ImagePath,
                    PhoneNumber = _userManager.GetUserAsync(User).Result.PhoneNumber

                });

            return View(nameof(Filtration), productsDto);
        }




    }
}
