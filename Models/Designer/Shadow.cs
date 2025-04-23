using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer;

public class Shadow
{
    [JsonProperty("color")]
    public string Color;

    [JsonProperty("blur")]
    public int Blur;

    [JsonProperty("offsetX")]
    public int OffsetX;

    [JsonProperty("offsetY")]
    public int OffsetY;

    [JsonProperty("affectStroke")]
    public bool AffectStroke;

    [JsonProperty("nonScaling")]
    public bool NonScaling;
}

