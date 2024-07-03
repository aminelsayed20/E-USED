using E_USED.Models.Entity.Product;
using E_USED.Repository.Interfaces;

namespace E_USED.Repository.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public ICollection<ProductImage> StoreImages(ICollection<IFormFile> ImagesDto, int ProductId)
        {
            if (ImagesDto != null && ImagesDto.Any())
            {
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "productImages"); // Adjust upload path as needed
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                var Images = new List<ProductImage>();
                foreach (var image in ImagesDto)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(uploads, fileName);
                    var newProductImage = new ProductImage(filePath, ProductId);

                    /// for saving new file of img on server
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(fileStream);
                    fileStream.Dispose();

                    Images.Add(newProductImage);
                }
                return Images;
            }
            return [];
        }

        
    }
}
