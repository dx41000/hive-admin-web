using System.Text;
using hive_admin_web.Models;
using hive_admin_web.Services.Interfaces;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class AssetService(IHttpClientFactory httpClientFactory) : IAssetService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");

    // Example: Get product by ID
    public async Task<Asset> GetProductByIdAsync(long assetId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/asset/{assetId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var asset = JsonConvert.DeserializeObject<Asset>(content);
        return asset;
    }

    // Example: Get all products (with pagination)
    public async Task<PagedResponse> GetAllProductsAsync(int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/asset/all?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var assets = JsonConvert.DeserializeObject<PagedResponse>(content);
        return assets;
    }

    // Example: Create or update a product
    public async Task<Asset> CreateOrUpdateProductAsync(Asset asset, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/asset")
        {
            Content = new StringContent(JsonConvert.SerializeObject(asset), System.Text.Encoding.UTF8, "application/json")
        };

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var createdAsset = JsonConvert.DeserializeObject<Asset>(content);
        return createdAsset;
    }

    // Example: Delete a product by ID
    public async Task DeleteProductByIdAsync(long assetId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"/api/asset/{assetId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }

    public async Task<HttpResponseMessage> CreateProductAsync(CreateAsset createAsset, string apiVersion)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/asset/wizard")
        {
            Content = new StringContent(JsonConvert.SerializeObject(createAsset), Encoding.UTF8, "application/json")
        };

        // Adding the api-version header
        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        return response;
    }
}