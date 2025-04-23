namespace hive_admin_web.Models;
public class AssetVariant
{
    public long? Id { get; set; }
    public long? AssetId { get; set; }
    public string Option1 { get; set; }
    public string Option1Type { get; set; }
    public string Option2 { get; set; }
    public string Option2Type { get; set; }
    public string Option3 { get; set; }
    public string Option3Type { get; set; }
    public string ExternalVariantId { get; set; }
    public string ExternalPrintProviderId { get; set; }
    public double? Cost { get; set; }
    public double? Price { get; set; }
    public byte[] BaseArtwork { get; set; }
    public string BaseArtworkThumb { get; set; }
    public List<AssetVariantView>? AssetVariantViews { get; set; }
    public Asset? Asset { get; set; }
}
