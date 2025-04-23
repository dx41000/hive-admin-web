using Newtonsoft.Json;

namespace hive_admin_web.Models.Designer;

public class ClipPath
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("version")]
        public string Version;

        [JsonProperty("originX")]
        public string OriginX;

        [JsonProperty("originY")]
        public string OriginY;

        [JsonProperty("left")]
        public double Left;

        [JsonProperty("top")]
        public double Top;

        [JsonProperty("width")]
        public double Width;

        [JsonProperty("height")]
        public double Height;

        [JsonProperty("fill")]
        public string Fill;

        [JsonProperty("stroke")]
        public object Stroke;

        [JsonProperty("strokeWidth")]
        public int StrokeWidth;

        [JsonProperty("strokeDashArray")]
        public object StrokeDashArray;

        [JsonProperty("strokeLineCap")]
        public string StrokeLineCap;

        [JsonProperty("strokeDashOffset")]
        public int StrokeDashOffset;

        [JsonProperty("strokeLineJoin")]
        public string StrokeLineJoin;

        [JsonProperty("strokeUniform")]
        public bool StrokeUniform;

        [JsonProperty("strokeMiterLimit")]
        public int StrokeMiterLimit;

        [JsonProperty("scaleX")]
        public int ScaleX;

        [JsonProperty("scaleY")]
        public int ScaleY;

        [JsonProperty("angle")]
        public int Angle;

        [JsonProperty("flipX")]
        public bool FlipX;

        [JsonProperty("flipY")]
        public bool FlipY;

        [JsonProperty("opacity")]
        public int Opacity;

        [JsonProperty("shadow")]
        public object Shadow;

        [JsonProperty("visible")]
        public bool Visible;

        [JsonProperty("backgroundColor")]
        public string BackgroundColor;

        [JsonProperty("fillRule")]
        public string FillRule;

        [JsonProperty("paintFirst")]
        public string PaintFirst;

        [JsonProperty("globalCompositeOperation")]
        public string GlobalCompositeOperation;

        [JsonProperty("skewX")]
        public int SkewX;

        [JsonProperty("skewY")]
        public int SkewY;

        [JsonProperty("rx")]
        public int Rx;

        [JsonProperty("ry")]
        public int Ry;

        [JsonProperty("inverted")]
        public bool Inverted;

        [JsonProperty("absolutePositioned")]
        public bool AbsolutePositioned;
    }