namespace hive_admin_web.Models.PrintReady;

public class GenerateImageResponse
{
    public byte[] PrintFile { get; set; }
    public byte[] ImageFile { get; set; }
    public byte[] ThumbnailFile { get; set; }
}