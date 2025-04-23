namespace hive_admin_web.Models;

public class Asset
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int? PrintProviderId { get; set; }
    public string ExternalProductId { get; set; }
    public bool? Release { get; set; }
    public string HsCode { get; set; }
    public int? ProductType { get; set; }
    public Payload PrintProvider { get; set; }
    public List<AssetVariant> AssetVariants { get; set; }
    public int? DeployedCount { get; set; }
}

public class Payload
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Zip { get; set; }
    public string ExternalPrintProviderId { get; set; }
    public long? LocationId { get; set; }
    public long? ShippingProfileId { get; set; }
    public long? Selectable { get; set; }
}
