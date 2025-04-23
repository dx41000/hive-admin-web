using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer;

public class PrintingBox
{
    [JsonProperty("x")]
    public double X;

    [JsonProperty("y")]
    public double Y;

    [JsonProperty("width")]
    public double Width;

    [JsonProperty("height")]
    public double Height;
}