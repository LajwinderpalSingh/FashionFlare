using FashionFlare.Models;

namespace FashionFlare.EntityFramework
{
    public interface IProductRepository
    {
        Task<List<Product>> FetchProducts();
        Task RemoveProduct(int productId);
        Task<List<Product>> FetchByProd(string name);
        Task InsertProducts(Product product);
        Task<Product> FetchById(int id);
        Task ModifyProduct(Product product);
        Task<IList<Product>> FetchByCategoryId(int id);
    }
}
