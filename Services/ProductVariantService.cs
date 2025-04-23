using hive_admin_web.Models;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class ProductVariantService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7026"; // Replace with your base API URL

    public ProductVariantService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_baseUrl);
    }

    // Example: Get all products (with pagination)
    public async Task<PagedResponse> GetAllProductVariantsAsync(long productId, int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        var storeId = 1;
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/productvariant/all/{productId}/{storeId}?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var productVariantss = JsonConvert.DeserializeObject<PagedResponse>(content);
        return productVariantss;
    }
    
    public async Task<AssetVariant> GetProductVariantAsync(long productId, string apiVersion = "1.0")
    {
        var storeId = 1;
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/productvariant/{productId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var productVariant = JsonConvert.DeserializeObject<AssetVariant>(content);
        return productVariant;
    }
    
}