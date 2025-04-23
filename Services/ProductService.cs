using System.Text;
using hive_admin_web.Models;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7026"; // Replace with your base API URL

    public ProductService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_baseUrl);
    }

    public async Task<Product> CopyProductAsync(long productId, string productName, long storeId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/product/copy/{productId}/{productName}/{storeId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content);
        return product;
    }

    public async Task<Product> GetProductAsync(long productId, long storeId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/product/{productId}/{storeId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content);
        return product;
    }

    public async Task DeleteProducttAsync(long productId, long storeId, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"/api/product/{productId}/{storeId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProductAsync(long productId, long storeId)
    {
        string url = $"/api/product/{productId}/{storeId}";
        await _httpClient.DeleteAsync(url);
    }


    public async Task<Product> CreateProductAsync(long storeId, object productDraft, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/product/{storeId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content);
        return product;
    }

    public async Task<Product> UpdateProductAsync(long storeId, object productDraft, string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"/api/productDraft/{storeId}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var product = JsonConvert.DeserializeObject<Product>(content);
        return product;
    }

    // Example: Get all products (with pagination)
    public async Task<PagedResponse> GetAllProductsAsync(int page, int count, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        var storeId = 1;
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/product/all/{storeId}?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var productVariantss = JsonConvert.DeserializeObject<PagedResponse>(content);
        return productVariantss;
    }

    public async Task Wizard(CreateProduct createProduct,  string apiVersion = null)
    {
        var storeId = 1;

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/product/wizard/{storeId}")
        {
            Content = new StringContent(JsonConvert.SerializeObject(createProduct), Encoding.UTF8, "application/json")
        };

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }
}