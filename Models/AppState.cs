namespace hive_admin_web.Models;

public class AppState
{
    public long StoreId { get; set; } = 1;
    public string? StoreName { get; set; }
    public IList<ProductVariantView> TestProductVariantViews { get; set; } = new List<ProductVariantView>();
}