namespace hive_admin_web.Models.PrintReady;


public class GenerateImageRequest
{
    public long ProductVariantDraftId { get; set; }
    public int ProductType { get; set; }
    public List<GenerateImage> GenerateImages { get; set; }
}

public class GenerateImage
{
    public long ProductVariantViewDraftId { get; set; }
}
