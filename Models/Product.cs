namespace hive_admin_web.Models
{
    public class Product
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductType { get; set; }
        public long WorkspaceId { get; set; }
        public long? ProductId { get; set; }
        public long? ShopifyId { get; set; }
        
        public IList<ProductVariant>? ProductVariants { get; set; }

        public Asset? Asset { get; set; }


        //Summary

        public int OrderCount { get; set; }
        public decimal SaleCount { get; set; }
    }
}
