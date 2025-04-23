using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer;

public class GeneralProperties
{    
    [JsonProperty("maxFontSize")]
    public int? MaxFontSize { get; set; }
    [JsonProperty("minFontSize")]
    public int? MinFontSize { get; set; }
    [JsonProperty("widthFontSize")]
    public int? WidthFontSize { get; set; }
    [JsonProperty("width")]
    public double? Width { get; set; }
    [JsonProperty("maxLength")]
    public int? MaxLength { get; set; }
    [JsonProperty("zChangeable")]
    public bool? ZChangeable { get; set; }
    [JsonProperty("copyable")]
    public bool? Copyable  { get; set; }
    [JsonProperty("rotatable")]
    public bool? Rotatable { get; set; }
    [JsonProperty("draggable")]
    public bool? Draggable { get; set; }
    [JsonProperty("removable")]
    public bool? Removable { get; set; }
    [JsonProperty("resizable")]
    public bool? Resizable { get; set; }
    [JsonProperty("editable")]
    public bool? Editable { get; set; }
    [JsonProperty("excludeFromExport")]
    public bool? ExcludeFromExport { get; set; }
    [JsonProperty("locked")]
    public bool? Locked { get; set; }
}


public class GeneralProperties2
{    
    [JsonProperty("draggable")]
    public bool? Draggable { get; set; }
}
