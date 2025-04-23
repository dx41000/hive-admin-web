using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer.Image;

public class OriginParams
{
    [JsonProperty("objectCaching")] public bool ObjectCaching;

    [JsonProperty("z")] public int Z;

    [JsonProperty("price")] public int Price;

    [JsonProperty("colors")] public List<string> Colors;

    [JsonProperty("removable")] public bool Removable;

    [JsonProperty("draggable")] public bool Draggable;

    [JsonProperty("rotatable")] public bool Rotatable;

    [JsonProperty("resizable")] public bool Resizable;

    [JsonProperty("copyable")] public bool Copyable;

    [JsonProperty("zChangeable")] public bool ZChangeable;

    [JsonProperty("boundingBox")] public string BoundingBox;

    [JsonProperty("boundingBoxMode")] public string BoundingBoxMode;

    [JsonProperty("autoCenter")] public bool AutoCenter;

    [JsonProperty("replace")] public string Replace;

    [JsonProperty("replaceInAllViews")] public bool ReplaceInAllViews;

    [JsonProperty("autoSelect")] public bool AutoSelect;

    [JsonProperty("topped")] public bool Topped;

    [JsonProperty("colorPrices")] public ColorPrices ColorPrices;

    [JsonProperty("colorLinkGroup")] public bool ColorLinkGroup;

    [JsonProperty("patterns")] public List<object> Patterns;

    [JsonProperty("sku")] public string Sku;

    [JsonProperty("excludeFromExport")] public bool ExcludeFromExport;

    [JsonProperty("showInColorSelection")] public bool ShowInColorSelection;

    [JsonProperty("locked")] public bool Locked;

    [JsonProperty("uniScalingUnlockable")] public bool UniScalingUnlockable;

    [JsonProperty("fixed")] public bool Fixed;

    [JsonProperty("shadowColor")] public string ShadowColor;

    [JsonProperty("shadowBlur")] public int ShadowBlur;

    [JsonProperty("shadowOffsetX")] public int ShadowOffsetX;

    [JsonProperty("shadowOffsetY")] public int ShadowOffsetY;

    [JsonProperty("colorLink3DLayer")] public bool ColorLink3DLayer;

    [JsonProperty("originX")] public string OriginX;

    [JsonProperty("originY")] public string OriginY;

    [JsonProperty("cornerSize")] public int CornerSize;

    [JsonProperty("fill")] public bool Fill;

    [JsonProperty("lockUniScaling")] public bool LockUniScaling;

    [JsonProperty("pattern")] public bool Pattern;

    [JsonProperty("top")] public double Top;

    [JsonProperty("left")] public double Left;

    [JsonProperty("angle")] public int Angle;

    [JsonProperty("flipX")] public bool FlipX;

    [JsonProperty("flipY")] public bool FlipY;

    [JsonProperty("opacity")] public int Opacity;

    [JsonProperty("scaleX")] public int ScaleX;

    [JsonProperty("scaleY")] public int ScaleY;

    [JsonProperty("uploadZone")] public bool UploadZone;

    [JsonProperty("filter")] public object Filter;

    [JsonProperty("colorMode")] public string ColorMode;

    [JsonProperty("scaleMode")] public string ScaleMode;

    [JsonProperty("resizeToW")] public int ResizeToW;

    [JsonProperty("resizeToH")] public int ResizeToH;

    [JsonProperty("advancedEditing")] public bool AdvancedEditing;

    [JsonProperty("uploadZoneMovable")] public bool UploadZoneMovable;

    [JsonProperty("uploadZoneRemovable")] public bool UploadZoneRemovable;

    [JsonProperty("padding")] public int Padding;

    [JsonProperty("minScaleLimit")] public double MinScaleLimit;

    [JsonProperty("minW")] public int MinW;

    [JsonProperty("minH")] public int MinH;

    [JsonProperty("maxW")] public int MaxW;

    [JsonProperty("maxH")] public int MaxH;

    [JsonProperty("minDPI")] public int MinDPI;

    [JsonProperty("maxSize")] public int MaxSize;

    [JsonProperty("isCustom")] public bool IsCustom;

    [JsonProperty("isCustomImage")] public bool IsCustomImage;

    [JsonProperty("_addToUZ")] public object AddToUZ;

    [JsonProperty("_isInitial")] public bool IsInitial;

    [JsonProperty("source")] public string Source;

    [JsonProperty("title")] public string Title;

    [JsonProperty("id")] public string Id;

    [JsonProperty("selectable")] public bool Selectable;

    [JsonProperty("lockRotation")] public bool LockRotation;

    [JsonProperty("hasRotatingPoint")] public bool HasRotatingPoint;

    [JsonProperty("lockScalingX")] public bool LockScalingX;

    [JsonProperty("lockScalingY")] public bool LockScalingY;

    [JsonProperty("lockMovementX")] public bool LockMovementX;

    [JsonProperty("lockMovementY")] public bool LockMovementY;

    [JsonProperty("hasControls")] public bool HasControls;

    [JsonProperty("evented")] public bool Evented;

    [JsonProperty("lockScalingFlip")] public bool LockScalingFlip;
}