using hive_admin_web.Models;
using hive_admin_web.Models.PrintReady;

namespace hive_admin_web.Services.Interfaces;

public interface IProductariantViewService
{
    Task<PagedResponse> GetAllProductVariantViewsByIdAsync(long productVariantViewId,int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0");

    Task<ProductVariantView> UpdateProductVariantViewAsync(
        ProductVariantView productVariantView, string apiVersion = "1.0");

    Task<ProductVariantView> CopyDesign(
        ProductVariantView productVariantView, string apiVersion = "1.0");

    Task<ApiResponse> GetPrintFile(GenerateImageRequest generateImageRequest,
        string apiVersion = "1.0");
    
    Task DeleteProductVariantViewAsync(long productVariantViewId, string apiVersion = null);
}