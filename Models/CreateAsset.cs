using Newtonsoft.Json;

namespace hive_admin_web.Models;

public class CreateAsset
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("hsCode")]
    public string HsCode { get; set; }

    [JsonProperty("release")]
    public bool Release { get; set; }

    [JsonProperty("productType")]
    public string ProductType { get; set; }

    [JsonProperty("optionSetType1")]
    public string? OptionSetType1 { get; set; }

    [JsonProperty("optionSet1")]
    public string? OptionSet1 { get; set; }

    [JsonProperty("optionSet2")]
    public string? OptionSet2 { get; set; }

    [JsonProperty("optionSetType2")]
    public string? OptionSetType2 { get; set; }

    [JsonProperty("optionSet3")]
    public string? OptionSet3 { get; set; }

    [JsonProperty("optionSetType3")]
    public string? OptionSetType3 { get; set; }

    [JsonProperty("views")]
    public string Views { get; set; }
}


