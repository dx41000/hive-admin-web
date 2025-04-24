namespace hive_admin_web.Services.Interfaces;

public interface IImageDownloaderService
{
    Task<byte[]> ConvertImageUrlToByteArrayAsync(string imageUrl);
}