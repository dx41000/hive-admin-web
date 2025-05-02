using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IAssetService
{
    Task<Asset> GetAssetByIdAsync(long assetId, string apiVersion = null);

    Task<PagedResponse> GetAllAssetsAsync(int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<Asset> CreateOrUpdateAssetAsync(Asset asset, string apiVersion = null);
    Task DeleteAssetByIdAsync(long assetId, string apiVersion = null);
    Task<HttpResponseMessage> CreateAssetAsync(CreateAsset createAsset, string apiVersion);
}