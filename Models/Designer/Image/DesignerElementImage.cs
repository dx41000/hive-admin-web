
using hive_admin_web.Models.Designer;
using hive_admin_web.Models.Designer.Image;
using Newtonsoft.Json;

public class DesignerElementImage
{
    [JsonProperty("id")] public long Id;
    
    [JsonProperty("type")] public string Type;
    
    [JsonProperty("_optionsSet")] public bool OptionsSet;

    [JsonProperty("advancedEditing")] public bool AdvancedEditing;

    [JsonProperty("angle")] public int Angle;

    [JsonProperty("autoCenter")] public bool AutoCenter;

    [JsonProperty("autoSelect")] public bool AutoSelect;

    [JsonProperty("boundingBox")] public string BoundingBox;

    [JsonProperty("boundingBoxMode")] public string BoundingBoxMode;

    [JsonProperty("colorLink3DLayer")] public bool ColorLink3DLayer;

    [JsonProperty("colorLinkGroup")] public bool ColorLinkGroup;

    [JsonProperty("colorMode")] public string ColorMode;

    [JsonProperty("colorPrices")] public ColorPrices ColorPrices;

    // [JsonProperty("colors")] public List<string> Colors;

    [JsonProperty("copyable")] public bool Copyable;

    [JsonProperty("cornerSize")] public int CornerSize;

    [JsonProperty("draggable")] public bool Draggable;

    [JsonProperty("evented")] public bool Evented;

    [JsonProperty("excludeFromExport")] public bool ExcludeFromExport;

    [JsonProperty("fill")] public bool Fill;

    [JsonProperty("filter")] public object Filter;

    [JsonProperty("fixed")] public bool Fixed;

    [JsonProperty("flipX")] public bool FlipX;

    [JsonProperty("flipY")] public bool FlipY;

    [JsonProperty("height")] public int Height;

    [JsonProperty("isCustom")] public bool IsCustom;

    [JsonProperty("isCustomImage")] public bool IsCustomImage;

    [JsonProperty("isEditable")] public bool IsEditable;

    [JsonProperty("left")] public double Left;

    [JsonProperty("lockUniScaling")] public bool LockUniScaling;

    [JsonProperty("locked")] public bool Locked;

    [JsonProperty("minScaleLimit")] public double MinScaleLimit;

    [JsonProperty("objectCaching")] public bool ObjectCaching;

    [JsonProperty("opacity")] public int Opacity;

    [JsonProperty("originParams")] public OriginParams? OriginParams;

    [JsonProperty("originX")] public string OriginX;

    [JsonProperty("originY")] public string OriginY;

    [JsonProperty("padding")] public int Padding;

    [JsonProperty("patterns")] public List<object> Patterns;

    [JsonProperty("price")] public int Price;

    [JsonProperty("removable")] public bool Removable;

    [JsonProperty("replace")] public string Replace;

    [JsonProperty("replaceInAllViews")] public bool ReplaceInAllViews;

    [JsonProperty("resizable")] public bool Resizable;

    [JsonProperty("resizeToH")] public int ResizeToH;

    [JsonProperty("resizeToW")] public int ResizeToW;

    [JsonProperty("rotatable")] public bool Rotatable;

    [JsonProperty("scaleMode")] public string ScaleMode;

    [JsonProperty("scaleX")] public int ScaleX;

    [JsonProperty("scaleY")] public int ScaleY;

    [JsonProperty("shadowBlur")] public int ShadowBlur;

    [JsonProperty("shadowColor")] public string ShadowColor;

    [JsonProperty("shadowOffsetX")] public int ShadowOffsetX;

    [JsonProperty("shadowOffsetY")] public int ShadowOffsetY;

    [JsonProperty("showInColorSelection")] public bool ShowInColorSelection;

    [JsonProperty("sku")] public string Sku;

    [JsonProperty("top")] public double Top;

    [JsonProperty("topped")] public bool Topped;

    [JsonProperty("uniScalingUnlockable")] public bool UniScalingUnlockable;

    [JsonProperty("uploadZone")] public bool UploadZone;

    [JsonProperty("uploadZoneMovable")] public bool UploadZoneMovable;

    [JsonProperty("uploadZoneRemovable")] public bool UploadZoneRemovable;

    [JsonProperty("width")] public double Width;

    [JsonProperty("z")] public int Z;

    [JsonProperty("zChangeable")] public bool ZChangeable;
}

