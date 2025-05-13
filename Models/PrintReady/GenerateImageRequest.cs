namespace hive_admin_web.Models.PrintReady;


public class GenerateImageRequest
{
    private static AppState _appState;
    public GenerateImageRequest(AppState appState)
    {
        _appState = appState;
    }

    public long WorkspaceId = _appState.WorkspaceId;
    public long StoreId = _appState.StoreId;
    public long ProductVariantId { get; set; }
    public int ProductType { get; set; }
    public List<GenerateImage> GenerateImages { get; set; } = new List<GenerateImage>();
}

public class GenerateImage
{
    public long ProductVariantViewId { get; set; }
    
    public string PrintOrder { get; set; }
}
