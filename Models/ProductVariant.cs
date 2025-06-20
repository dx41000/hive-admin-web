namespace hive_admin_web.Models
{
    public class ProductVariant
    {
        public long? Id { get; set; }
        public long? WorkspaceId { get; set; }

        public long? ProductId { get; set; }
        public byte[] BaseArtwork { get; set; }
        public string BaseArtworkThumb { get; set; }
        public byte[] PrintFile { get; set; }
        public long? ProductVariantId { get; set; }
        
        public string Option1 { get; set; }
        public string Option1Type { get; set; }
        public string Option2 { get; set; }
        public string Option2Type { get; set; }
        public string Option3 { get; set; }
        public string Option3Type { get; set; }
        public Product Product { get; set; }
        public IList<ProductVariantView>? ProductVariantViews { get; set; }
    }
}
