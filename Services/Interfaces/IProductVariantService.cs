using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IProductVariantService
{
    Task<PagedResponse> GetAllProductVariantsAsync(long productId, int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<AssetVariant> GetProductVariantAsync(long productId, string apiVersion = "1.0");

    Task DeleteProductVariantAsync(long productVariantId, string apiVersion = null);
}