using System.Net.Http.Headers;
using System.Text;
using hive_admin_web.Models;
using hive_admin_web.Models.PrintReady;
using hive_admin_web.Services.Interfaces;
using Newtonsoft.Json;

namespace hive_admin_web.Services
{
    public class ProductariantViewService(IHttpClientFactory httpClientFactory, AppState appState) : IProductariantViewService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HiveCore");


        // Set default headers
        private void SetDefaultHeaders(string apiVersion)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("api-version", apiVersion);
        }

        public async Task<PagedResponse> GetAllProductVariantViewsByIdAsync(long productVariantViewId,int page = 1, int count = 10, string search = null,
            string orderColumn = null, string orderDir = "asc", string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var storeId = appState.StoreId;
            var url = $"api/productvariantview/all/{productVariantViewId}/{storeId}?page={page}&count={count}&search={search}&orderColumn={orderColumn}&orderDir={orderDir}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PagedResponse>(jsonResponse);
            }
            else
            {
                throw new Exception($"Error fetching product variant views: {response.StatusCode}");
            }
        }
        
        // PUT request for /api/productvariantview
        public async Task<ProductVariantView> UpdateProductVariantViewAsync(
            ProductVariantView productVariantView, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var storeId = appState.StoreId;
            
            var url = $"api/productvariantview/{storeId}";
            var content = new StringContent(JsonConvert.SerializeObject(productVariantView), Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductVariantView>(jsonResponse);
            }
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error updating product variant view: {response.StatusCode}");
            }

        }
        
        public async Task<ProductVariantView> CopyDesign(
            ProductVariantView productVariantView, string apiVersion = "1.0")
        {
            SetDefaultHeaders(apiVersion);

            var storeId = appState.StoreId;
            
            var url = $"api/productvariantview/copydesign/{storeId}";
            var content = new StringContent(JsonConvert.SerializeObject(productVariantView), Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductVariantView>(jsonResponse);
            }
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error updating product variant view: {response.StatusCode}");
            }

        }

        public async Task<ApiResponse> GetPrintFile(GenerateImageRequest generateImageRequest,
            string apiVersion = "1.0")
        {
            
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/printready/GenerateImage/")
            {
                Content = new StringContent(JsonConvert.SerializeObject(generateImageRequest),
                    System.Text.Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrEmpty(apiVersion))
                requestMessage.Headers.Add("api-version", apiVersion);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse>(content);
        }
        
        public async Task DeleteProductVariantViewAsync(long productVariantViewId, string apiVersion = null)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"/api/productVariantView/{productVariantViewId}/{appState.StoreId}");

            if (!string.IsNullOrEmpty(apiVersion))
                requestMessage.Headers.Add("api-version", apiVersion);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
        }

    }
}
