using E_USED.Models.Entity.Product;

namespace E_USED.Repository.Interfaces
{
    public interface IProductServices
    {
        public ICollection<ProductImage> StoreImages(ICollection<IFormFile> Images, int ProductId);
    }
}
