namespace hive_admin_web.Models.PrintReady;


public class GenerateImageRequest
{
    public long ProductVariantId { get; set; }
    public int ProductType { get; set; }
    public List<GenerateImage> GenerateImages { get; set; }
}

public class GenerateImage
{
    public long ProductVariantViewId { get; set; }
}
