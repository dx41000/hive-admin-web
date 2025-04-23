namespace hive_admin_web.Models;

public class AssetVariantView
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public double? ScaleX { get; set; }
    public double? ScaleY { get; set; }
    public int? CanvasWidth { get; set; }
    public int? CanvasHeight { get; set; }
    public int? PrintBoxWidth { get; set; }
    public int? PrintBoxHeight { get; set; }
    public int? PrintBoxTop { get; set; }
    public int? PrintBoxLeft { get; set; }
    public int? OutputWidth { get; set; }
    public int? OutputHeight { get; set; }
    public int? BaseArtworkTop { get; set; }
    public int? BaseArtworkLeft { get; set; }
    public int? Order { get; set; }
    public string DesignerJson { get; set; }
    public string ThumbnailUrl { get; set; }
    public long? AssetVariantId { get; set; }
    public byte[]? PrintFile {get; set;}
    public AssetVariant? AssetVariant { get; set; }
}
