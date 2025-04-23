namespace hive.core.models.PrintReady;

public class DesignerOutput
{
    public List<UsedFont>? used_fonts { get; set; }
    public List<SvgDatum> svg_data { get; set; }
    public List<string> custom_images { get; set; }
}

public class SvgDatum
{
    public string svg { get; set; }
}

public class UsedFont
{
    public string name { get; set; }}

