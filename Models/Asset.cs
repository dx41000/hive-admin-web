namespace hive_admin_web.Models;

public class Asset
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? PrintProviderId { get; set; }
    public string ExternalProductId { get; set; }
    public bool? Release { get; set; }
    public int ImageSource { get; set; }
    public List<AssetVariant> AssetVariants { get; set; }
    public int? DeployedCount { get; set; }
}