using System.Net.Http.Headers;
using System.Text;
using hive_admin_web.Models;
using hive_admin_web.Services.Interfaces;
using Newtonsoft.Json;

namespace hive_admin_web.Services
{
    public class AssetVariantViewService(IHttpClientFactory httpClientFactory) : IAssetVariantViewService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");


        // Set default headers
        private void SetDefaultHeaders(string apiVersion)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("api-version", apiVersion);
        }

        // GET request for /api/productvariantview/{productVariantViewId}
        public async Task<ApiResponse> GetAssetVariantViewByIdAsync(long assetVariantViewId, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = $"api/assetvariantview/{assetVariantViewId}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error fetching asset variant view: {response.StatusCode}");
            }
        }

        // DELETE request for /api/productvariantview/{productVariantViewId}
        public async Task DeleteAssetVariantViewAsync(long assetVariantViewId, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = $"api/assetvariantview/{assetVariantViewId}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error deleting asset variant view: {response.StatusCode}");
            }
        }

        // GET request for /api/productvariantview/all
        public async Task<PagedResponse> GetAllAssetVariantViewsAsync(int page = 1, int count = 10, string search = null,
            string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = $"api/assetvariantview/all?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PagedResponse>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error fetching asset variant views: {response.StatusCode}");
            }
        }

        public async Task<PagedResponse> GetAllAssetVariantViewsByIdAsync(long productVariantViewId,int page = 1, int count = 10, string search = null,
            string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = $"api/assetvariantview/all/{productVariantViewId}?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PagedResponse>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error fetching asset variant views: {response.StatusCode}");
            }
        }

        // POST request for /api/productvariantview
        public async Task<AssetVariantView> CreateAssetVariantViewAsync(AssetVariantView assetVariantView, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = "api/assetvariantview";
            var content = new StringContent(JsonConvert.SerializeObject(assetVariantView), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetVariantView>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error creating asset variant view: {response.StatusCode}");
            }
        }

        // PUT request for /api/productvariantview
        public async Task<AssetVariantView> UpdateAssetVariantViewAsync(AssetVariantView assetVariantView, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = "api/assetvariantview";
            var content = new StringContent(JsonConvert.SerializeObject(assetVariantView), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetVariantView>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error updating asset variant view: {response.StatusCode}");
            }
        }

        // PUT request for /api/productvariantview/allVariants
        public async Task<AssetVariantView> UpdateAllAssetVariantViewsAsync(AssetVariantView assetVariantView, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var url = "api/assetvariantview/allVariants";
            var content = new StringContent(JsonConvert.SerializeObject(assetVariantView), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AssetVariantView>(jsonResponse);
            }
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error updating asset variant view: {response.StatusCode}");
            }
        }
    }
}
