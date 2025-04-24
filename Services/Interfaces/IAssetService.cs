using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IAssetService
{
    Task<Asset> GetProductByIdAsync(long assetId, string apiVersion = null);

    Task<PagedResponse> GetAllProductsAsync(int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<Asset> CreateOrUpdateProductAsync(Asset asset, string apiVersion = null);
    Task DeleteProductByIdAsync(long assetId, string apiVersion = null);
    Task<HttpResponseMessage> CreateProductAsync(CreateAsset createAsset, string apiVersion);
}