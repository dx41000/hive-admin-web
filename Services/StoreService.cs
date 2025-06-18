using System.Text;
using hive_admin_web.Models;
using hive_admin_web.Services.Interfaces;
using Newtonsoft.Json;

namespace hive_admin_web.Services;

public class StoreService(IHttpClientFactory httpClientFactory) : IStoreService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");
    
    public async Task<IList<Store>> GetStoresAsync(string apiVersion = null)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/store/all/1");

        if (!string.IsNullOrEmpty(apiVersion))
            requestMessage.Headers.Add("api-version", apiVersion);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
        var json = apiResponse.Data.Payload.ToString();
        var stores = JsonConvert.DeserializeObject<List<Store>>(json);
        return stores;
    }
}