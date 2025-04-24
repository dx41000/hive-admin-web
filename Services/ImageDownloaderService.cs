using hive_admin_web.Services.Interfaces;

namespace hive_admin_web.Services;

public class ImageDownloaderService(IHttpClientFactory httpClientFactory) : IImageDownloaderService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");

    public async Task<byte[]> ConvertImageUrlToByteArrayAsync(string imageUrl)
    {
        // Send a GET request to the image URL
        HttpResponseMessage response = await _httpClient.GetAsync(imageUrl);

        // Ensure the request was successful
        response.EnsureSuccessStatusCode();

        // Read the image content as a byte array
        byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

        return imageBytes;
    }

}
