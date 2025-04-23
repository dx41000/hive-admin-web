// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using hive_admin_web.Models.Designer;
using hive_admin_web.Models.Designer.Text;
using Newtonsoft.Json;

public class DesignerElementText
{
    [JsonProperty("id")] public long Id;
    
    [JsonProperty("type")] public string Type;
    
    [JsonProperty("_initialText")] public string InitialText;

    [JsonProperty("_optionsSet")] public bool OptionsSet;

    [JsonProperty("_printingBox")] public PrintingBox PrintingBox;

    [JsonProperty("angle")] public int Angle;

    [JsonProperty("autoCenter")] public bool AutoCenter;

    [JsonProperty("autoSelect")] public bool AutoSelect;

    [JsonProperty("boundingBox")] public dynamic BoundingBox;

    [JsonProperty("boundingBoxMode")] public string BoundingBoxMode;

    [JsonProperty("charSpacing")] public int CharSpacing;

    [JsonProperty("chargeAfterEditing")] public bool ChargeAfterEditing;

    [JsonProperty("colorLink3DLayer")] public bool ColorLink3DLayer;

    [JsonProperty("colorLinkGroup")] public bool ColorLinkGroup;

    [JsonProperty("colorPrices")] public ColorPrices ColorPrices;

    [JsonProperty("colors")] public bool Colors;

    [JsonProperty("copyable")] public bool Copyable;

    [JsonProperty("cornerSize")] public int CornerSize;

    [JsonProperty("curvable")] public bool Curvable;

    [JsonProperty("curveRadius")] public int CurveRadius;

    [JsonProperty("curveReverse")] public bool CurveReverse;

    [JsonProperty("curved")] public bool Curved;

    [JsonProperty("direction")] public string Direction;

    [JsonProperty("draggable")] public bool Draggable;

    [JsonProperty("editable")] public bool Editable;

    [JsonProperty("evented")] public bool Evented;

    [JsonProperty("excludeFromExport")] public bool ExcludeFromExport;

    [JsonProperty("fill")] public string Fill;

    [JsonProperty("fixed")] public bool Fixed;

    [JsonProperty("flipX")] public bool FlipX;

    [JsonProperty("flipY")] public bool FlipY;

    [JsonProperty("fontFamily")] public string FontFamily;

    [JsonProperty("fontSize")] public int FontSize;

    [JsonProperty("fontStyle")] public string FontStyle;

    [JsonProperty("fontWeight")] public string FontWeight;

    [JsonProperty("height")] public double Height;

    [JsonProperty("isCustom")] public bool IsCustom;

    [JsonProperty("isEditable")] public bool IsEditable;

    [JsonProperty("left")] public double Left;

    [JsonProperty("letterSpacing")] public int LetterSpacing;

    [JsonProperty("lineHeight")] public int LineHeight;

    [JsonProperty("lockUniScaling")] public bool LockUniScaling;

    [JsonProperty("locked")] public bool Locked;

    [JsonProperty("maxCurveRadius")] public int MaxCurveRadius;

    [JsonProperty("maxFontSize")] public int MaxFontSize;

    [JsonProperty("maxLength")] public int MaxLength;

    [JsonProperty("maxLines")] public int MaxLines;

    [JsonProperty("minFontSize")] public int MinFontSize;

    [JsonProperty("neonText")] public bool NeonText;

    [JsonProperty("numberPlaceholder")] public bool NumberPlaceholder;

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

    [JsonProperty("rotatable")] public bool Rotatable;

    [JsonProperty("scaleX")] public int ScaleX;

    [JsonProperty("scaleY")] public int ScaleY;

    [JsonProperty("shadowBlur")] public int ShadowBlur;

    [JsonProperty("shadowColor")] public string ShadowColor;

    [JsonProperty("shadowOffsetX")] public int ShadowOffsetX;

    [JsonProperty("shadowOffsetY")] public int ShadowOffsetY;

    [JsonProperty("showInColorSelection")] public bool ShowInColorSelection;

    [JsonProperty("sku")] public string Sku;

    [JsonProperty("stroke")] public object Stroke;

    [JsonProperty("strokeColors")] public List<object> StrokeColors;

    [JsonProperty("strokeWidth")] public int StrokeWidth;

    [JsonProperty("text")] public string Text;

    [JsonProperty("textAlign")] public string TextAlign;

    [JsonProperty("textBox")] public bool TextBox;

    [JsonProperty("textDecoration")] public string TextDecoration;

    [JsonProperty("textLinkGroup")] public string TextLinkGroup;

    [JsonProperty("textPlaceholder")] public bool TextPlaceholder;

    [JsonProperty("textTransform")] public string TextTransform;

    [JsonProperty("top")] public double Top;

    [JsonProperty("topped")] public bool Topped;

    [JsonProperty("uniScalingUnlockable")] public bool UniScalingUnlockable;

    [JsonProperty("width")] public double Width;

    [JsonProperty("widthFontSize")] public int WidthFontSize;

    [JsonProperty("z")] public int Z;

    [JsonProperty("zChangeable")] public bool ZChangeable;
}
