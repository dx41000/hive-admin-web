namespace hive_admin_web.Models
{
    public class ProductVariantView
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        
        public string? Artwork { get; set; }
        public string? ArtworkThumb { get; set; }
        public long? WorkspaceId { get; set; }
        
        public string? DesignerJson { get; set; }
        
        public string? PrintOrder { get; set; }
        public long? ProductVariantId { get; set; }        
        public long? AssetVariantViewId { get; set; }
        
        
        public AssetVariantView? AssetVariantView { get; set; }

        
        
        //Extra 
        public long? ProductId { get; set; }
        public long? AssetId { get; set; }
        public int? ProductType { get; set; }

    }
}
