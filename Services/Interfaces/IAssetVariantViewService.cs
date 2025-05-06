using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IAssetVariantViewService
{
    Task<ApiResponse> GetAssetVariantViewByIdAsync(long assetVariantViewId, string apiVersion = "1.0");
    Task DeleteAssetVariantViewAsync(long assetVariantViewId, string apiVersion = "1.0");

    Task<PagedResponse> GetAllAssetVariantViewsAsync(int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<PagedResponse> GetAllAssetVariantViewsByIdAsync(long productVariantViewId,int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<AssetVariantView> CreateAssetVariantViewAsync(AssetVariantView assetVariantView, string apiVersion = "1.0");
    Task<AssetVariantView> UpdateAssetVariantViewAsync(AssetVariantView assetVariantView, string apiVersion = "1.0");
    Task<AssetVariantView>  UpdateAllAssetVariantViewsAsync(AssetVariantView assetVariantView, string apiVersion = "1.0");
}