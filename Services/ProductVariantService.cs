using hive_admin_web.Models;
using hive_admin_web.Services.Interfaces;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class ProductVariantService(IHttpClientFactory httpClientFactory, AppState appState) : IProductVariantService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");
    
    // Example: Get all products (with pagination)
    public async Task<PagedResponse> GetAllProductVariantsAsync(long productId, int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        var storeId = appState.StoreId;
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
        var storeId = appState.StoreId;
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/productvariant/{productId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var productVariant = JsonConvert.DeserializeObject<AssetVariant>(content);
        return productVariant;
    }
    
    public async Task DeleteProductVariantAsync(long productVariantId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"/api/productVariant/{productVariantId}/{appState.StoreId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }

}