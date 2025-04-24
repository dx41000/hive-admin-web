using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IAssetVariantService
{
    Task DeleteProductVariantAsync(long assetVariantId, string apiVersion = "1.0");

    Task<PagedResponse> GetAllAssetVariantsAsync(int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<PagedResponse> GetAllAssetVariantsByIdAsync(long assetId, int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<ApiResponse> GetAssetVariantByIdAsync(long assetVariantId, string apiVersion = "1.0");

    Task<AssetVariant> CreateAssetVariantAsync(AssetVariant assetVariant,
        string apiVersion = "1.0");

    Task<AssetVariant> UpdateAssetVariantAsync(AssetVariant assetVariant,
        string apiVersion = "1.0");
}