namespace hive_admin_web.Models
{
    public class ProductVariant
    {
        public long? Id { get; set; }
        public long? WorkspaceId { get; set; }

        public long? ProductId { get; set; }

        public decimal? Price { get; set; }
        public string? BaseArtwork { get; set; }
        public string? BaseArtworkThumb { get; set; }
        public long? ProductVariantId { get; set; }

        public IList<ProductVariantView>? ProductVariantViews { get; set; }

        public AssetVariant AssetVariant { get; set; }
    }
}
