using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer.Text;


public class OriginParams
{
    [JsonProperty("type")] public string Type;

    [JsonProperty("version")] public string Version;

    [JsonProperty("originX")] public string OriginX;

    [JsonProperty("originY")] public string OriginY;

    [JsonProperty("left")] public double Left;

    [JsonProperty("top")] public double Top;

    [JsonProperty("width")] public double Width;

    [JsonProperty("height")] public double Height;

    [JsonProperty("fill")] public string Fill;

    [JsonProperty("stroke")] public object Stroke;

    [JsonProperty("strokeWidth")] public int StrokeWidth;

    [JsonProperty("strokeDashArray")] public object StrokeDashArray;

    [JsonProperty("strokeLineCap")] public string StrokeLineCap;

    [JsonProperty("strokeDashOffset")] public int StrokeDashOffset;

    [JsonProperty("strokeLineJoin")] public string StrokeLineJoin;

    [JsonProperty("strokeUniform")] public bool StrokeUniform;

    [JsonProperty("strokeMiterLimit")] public int StrokeMiterLimit;

    [JsonProperty("scaleX")] public int ScaleX;

    [JsonProperty("scaleY")] public int ScaleY;

    [JsonProperty("angle")] public int Angle;

    [JsonProperty("flipX")] public bool FlipX;

    [JsonProperty("flipY")] public bool FlipY;

    [JsonProperty("opacity")] public int Opacity;

    [JsonProperty("shadow")] public Shadow Shadow;

    [JsonProperty("visible")] public bool Visible;

    [JsonProperty("backgroundColor")] public string BackgroundColor;

    [JsonProperty("fillRule")] public string FillRule;

    [JsonProperty("paintFirst")] public string PaintFirst;

    [JsonProperty("globalCompositeOperation")]
    public string GlobalCompositeOperation;

    [JsonProperty("skewX")] public int SkewX;

    [JsonProperty("skewY")] public int SkewY;

    [JsonProperty("fontFamily")] public string FontFamily;

    [JsonProperty("fontWeight")] public string FontWeight;

    [JsonProperty("fontSize")] public int FontSize;

    [JsonProperty("text")] public string Text;

    [JsonProperty("underline")] public bool Underline;

    [JsonProperty("overline")] public bool Overline;

    [JsonProperty("linethrough")] public bool Linethrough;

    [JsonProperty("textAlign")] public string TextAlign;

    [JsonProperty("fontStyle")] public string FontStyle;

    [JsonProperty("lineHeight")] public int LineHeight;

    [JsonProperty("textBackgroundColor")] public string TextBackgroundColor;

    [JsonProperty("charSpacing")] public int CharSpacing;

    [JsonProperty("styles")] public List<object> Styles;

    [JsonProperty("direction")] public string Direction;

    [JsonProperty("path")] public object Path;

    [JsonProperty("pathStartOffset")] public int PathStartOffset;

    [JsonProperty("pathSide")] public string PathSide;

    [JsonProperty("pathAlign")] public string PathAlign;

    [JsonProperty("objectCaching")] public bool ObjectCaching;

    [JsonProperty("z")] public int Z;

    [JsonProperty("price")] public int Price;

    [JsonProperty("colors")] public bool Colors;

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

    [JsonProperty("cornerSize")] public int CornerSize;

    [JsonProperty("lockUniScaling")] public bool LockUniScaling;

    [JsonProperty("pattern")] public bool Pattern;

    [JsonProperty("maxLength")] public int MaxLength;

    [JsonProperty("curved")] public bool Curved;

    [JsonProperty("curvable")] public bool Curvable;

    [JsonProperty("curveRadius")] public int CurveRadius;

    [JsonProperty("maxCurveRadius")] public int MaxCurveRadius;

    [JsonProperty("curveReverse")] public bool CurveReverse;

    [JsonProperty("maxLines")] public int MaxLines;

    [JsonProperty("textBox")] public bool TextBox;

    [JsonProperty("textPlaceholder")] public bool TextPlaceholder;

    [JsonProperty("numberPlaceholder")] public bool NumberPlaceholder;

    [JsonProperty("letterSpacing")] public int LetterSpacing;

    [JsonProperty("chargeAfterEditing")] public bool ChargeAfterEditing;

    [JsonProperty("minFontSize")] public int MinFontSize;

    [JsonProperty("textTransform")] public string TextTransform;

    [JsonProperty("widthFontSize")] public int WidthFontSize;

    [JsonProperty("maxFontSize")] public int MaxFontSize;

    [JsonProperty("textLinkGroup")] public string TextLinkGroup;

    [JsonProperty("strokeColors")] public List<object> StrokeColors;

    [JsonProperty("neonText")] public bool NeonText;

    [JsonProperty("editable")] public bool Editable;

    [JsonProperty("textDecoration")] public string TextDecoration;

    [JsonProperty("padding")] public int Padding;

    [JsonProperty("isCustom")] public bool IsCustom;

    [JsonProperty("_addToUZ")] public object AddToUZ;

    [JsonProperty("_calcWidth")] public bool CalcWidth;

    [JsonProperty("_isInitial")] public bool IsInitial;
}