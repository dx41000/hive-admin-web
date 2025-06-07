using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IProductService
{
    Task<Product> CopyProductAsync(long productId, string productName, long storeId, string apiVersion = null);
    Task<Product> GetProductAsync(long productId, long storeId, string apiVersion = null);
    Task DeleteProductAsync(long productId, string apiVersion = null);
    Task<Product> CreateProductAsync(long storeId, object productDraft, string apiVersion = null);
    Task<Product> UpdateProductAsync(long storeId, object productDraft, string apiVersion = null);

    Task<PagedResponse> GetAllProductsAsync(int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task Wizard(CreateProduct createProduct,  string apiVersion = null);
    Task Publish(long productId, string apiVersion = null);
}