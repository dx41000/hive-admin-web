namespace hive_admin_web.Models.PrintReady;


public class GenerateImageRequest
{
    public long WorkspaceId { get; set; }
    public long StoreId { get; set; }
    public long ProductVariantId { get; set; }
    public int ProductType { get; set; }
    public List<GenerateImage> GenerateImages { get; set; } = new List<GenerateImage>();
}

public class GenerateImage
{
    public long ProductVariantViewId { get; set; }
    
    public string PrintOrder { get; set; }
}
