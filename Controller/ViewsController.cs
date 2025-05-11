using hive_admin_web.Models;
using hive_admin_web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace hive_admin_web.Controller;

[ApiController]
[Route("api/[controller]")]
public class ViewsController(AppState appState, IProductariantViewService productariantViewService) : ControllerBase
{
    [HttpGet("{productVariantViewId}")]
    public async Task<string?> GetView(long productVariantViewId)
    {
        if (appState.TestProductVariantViews.Any(x => x.Id == productVariantViewId))
        {
            return appState.TestProductVariantViews.Single(x => x.Id == productVariantViewId).DesignerJson;
        }

        var response = await productariantViewService.GetAsync(productVariantViewId);
        var json = response.Data.Payload.ToString();
        ProductVariantView productVariantView = JsonConvert.DeserializeObject<ProductVariantView>(json);

        return productVariantView.DesignerJson;
    }
}