namespace hive_admin_web.Models;

public class CreateProduct
{
    public long? AssetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public List<long>? VariantIds { get; set; }
    public List<CreateProductView> CreateProductViews { get; set; }
    public DesignerOutput DesignerOutput { get; set; }
    public List<string> GenerateImageViews { get; set; }
    public string ProductType { get; set; }
}

public class CreateProductView
{
    public string Name { get; set; }
    public string DesignerJson { get; set; }
}

public class DesignerOutput
{
    public List<UsedFont> UsedFonts { get; set; }
    public List<SvgDatum> SvgData { get; set; }
    public List<string> CustomImages { get; set; }
}

public class SvgDatum
{
    public string Svg { get; set; }
}

public class UsedFont
{
    public string Name { get; set; }
}
