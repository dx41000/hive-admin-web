using System.Net.Http.Headers;
using hive_admin_web.Models;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class AssetVariantService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://localhost:7026"; // Replace with your base API URL

    public AssetVariantService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_baseUrl);
    }

    // Set default headers
    private void SetDefaultHeaders(string apiVersion)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("api-version", apiVersion);
    }

    // DELETE request for /api/productvariant/{productVariantId}
    public async Task DeleteProductVariantAsync(long assetVariantId, string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url = $"{_baseUrl}/api/assetvariant/{assetVariantId}";

        HttpResponseMessage response = await _httpClient.DeleteAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error deleting product variant: {response.StatusCode}");
        }
    }

    // GET request for /api/productvariant/all
    public async Task<PagedResponse> GetAllAssetVariantsAsync(int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url =
            $"{_baseUrl}/api/assetvariant/all?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PagedResponse>(jsonResponse);
        }
        else
        {
            throw new Exception($"Error fetching product variants: {response.StatusCode}");
        }
    }

    public async Task<PagedResponse> GetAllAssetVariantsByIdAsync(long assetId, int page = 1, int count = 10, string search = null,
        string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url =
            $"{_baseUrl}/api/assetvariant/all/{assetId}?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PagedResponse>(jsonResponse);
        }
        else
        {
            throw new Exception($"Error fetching product variants: {response.StatusCode}");
        }
    }
    
    
    // GET request for /api/productvariant/all
    public async Task<ApiResponse> GetAssetVariantByIdAsync(long assetVariantId, string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url =
            $"{_baseUrl}/api/assetvariant/{assetVariantId}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
        }
        else
        {
            throw new Exception($"Error fetching product variants: {response.StatusCode}");
        }
    }
    
    // POST request for /api/productvariant
    public async Task<AssetVariant> CreateAssetVariantAsync(AssetVariant assetVariant,
        string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url = $"{_baseUrl}/api/assetvariant";
        var content = new StringContent(JsonConvert.SerializeObject(assetVariant), System.Text.Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AssetVariant>(jsonResponse);
        }
        else
        {
            throw new Exception($"Error creating product variant: {response.StatusCode}");
        }
    }

    // PUT request for /api/productvariant
    public async Task<AssetVariant> UpdateAssetVariantAsync(AssetVariant assetVariant,
        string apiVersion = "1.0")
    {
        SetDefaultHeaders(apiVersion);

        var url = $"{_baseUrl}/api/assetvariant";
        var content = new StringContent(JsonConvert.SerializeObject(assetVariant), System.Text.Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await _httpClient.PutAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AssetVariant>(jsonResponse);
        }
        else
        {
            throw new Exception($"Error updating product variant: {response.StatusCode}");
        }
    }

}