using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal static class Class49
{
    private static readonly RColor rcolor_0 = RColor.FromArgb(0xa9, 0x33, 0x99, 0xff);

    public static RColor smethod_0()
    {
        return rcolor_0;
    }

    public static double smethod_1(RGraphics rgraphics_0, CssBoxProperties cssBoxProperties_0)
    {
        double whitespaceWidth = cssBoxProperties_0.ActualFont.GetWhitespaceWidth(rgraphics_0);
        if (!(string.IsNullOrEmpty(cssBoxProperties_0.WordSpacing) || (cssBoxProperties_0.WordSpacing == "normal")))
        {
            whitespaceWidth += Class43.smethod_4(cssBoxProperties_0.WordSpacing, 0.0, cssBoxProperties_0, true);
        }
        return whitespaceWidth;
    }

    public static string smethod_2(CssBoxProperties cssBoxProperties_0, string string_0)
    {
        switch (string_0)
        {
            case "border-bottom-width":
                return cssBoxProperties_0.BorderBottomWidth;

            case "border-left-width":
                return cssBoxProperties_0.BorderLeftWidth;

            case "border-right-width":
                return cssBoxProperties_0.BorderRightWidth;

            case "border-top-width":
                return cssBoxProperties_0.BorderTopWidth;

            case "border-bottom-style":
                return cssBoxProperties_0.BorderBottomStyle;

            case "border-left-style":
                return cssBoxProperties_0.BorderLeftStyle;

            case "border-right-style":
                return cssBoxProperties_0.BorderRightStyle;

            case "border-top-style":
                return cssBoxProperties_0.BorderTopStyle;

            case "border-bottom-color":
                return cssBoxProperties_0.BorderBottomColor;

            case "border-left-color":
                return cssBoxProperties_0.BorderLeftColor;

            case "border-right-color":
                return cssBoxProperties_0.BorderRightColor;

            case "border-top-color":
                return cssBoxProperties_0.BorderTopColor;

            case "border-spacing":
                return cssBoxProperties_0.BorderSpacing;

            case "border-collapse":
                return cssBoxProperties_0.BorderCollapse;

            case "corner-radius":
                return cssBoxProperties_0.CornerRadius;

            case "corner-nw-radius":
                return cssBoxProperties_0.CornerNwRadius;

            case "corner-ne-radius":
                return cssBoxProperties_0.CornerNeRadius;

            case "corner-se-radius":
                return cssBoxProperties_0.CornerSeRadius;

            case "corner-sw-radius":
                return cssBoxProperties_0.CornerSwRadius;

            case "margin-bottom":
                return cssBoxProperties_0.MarginBottom;

            case "margin-left":
                return cssBoxProperties_0.MarginLeft;

            case "margin-right":
                return cssBoxProperties_0.MarginRight;

            case "margin-top":
                return cssBoxProperties_0.MarginTop;

            case "padding-bottom":
                return cssBoxProperties_0.PaddingBottom;

            case "padding-left":
                return cssBoxProperties_0.PaddingLeft;

            case "padding-right":
                return cssBoxProperties_0.PaddingRight;

            case "padding-top":
                return cssBoxProperties_0.PaddingTop;

            case "left":
                return cssBoxProperties_0.Left;

            case "top":
                return cssBoxProperties_0.Top;

            case "width":
                return cssBoxProperties_0.Width;

            case "max-width":
                return cssBoxProperties_0.MaxWidth;

            case "height":
                return cssBoxProperties_0.Height;

            case "background-color":
                return cssBoxProperties_0.BackgroundColor;

            case "background-image":
                return cssBoxProperties_0.BackgroundImage;

            case "background-position":
                return cssBoxProperties_0.BackgroundPosition;

            case "background-repeat":
                return cssBoxProperties_0.BackgroundRepeat;

            case "background-gradient":
                return cssBoxProperties_0.BackgroundGradient;

            case "background-gradient-angle":
                return cssBoxProperties_0.BackgroundGradientAngle;

            case "color":
                return cssBoxProperties_0.Color;

            case "display":
                return cssBoxProperties_0.Display;

            case "direction":
                return cssBoxProperties_0.Direction;

            case "empty-cells":
                return cssBoxProperties_0.EmptyCells;

            case "float":
                return cssBoxProperties_0.Float;

            case "position":
                return cssBoxProperties_0.Position;

            case "line-height":
                return cssBoxProperties_0.LineHeight;

            case "vertical-align":
                return cssBoxProperties_0.VerticalAlign;

            case "text-indent":
                return cssBoxProperties_0.TextIndent;

            case "text-align":
                return cssBoxProperties_0.TextAlign;

            case "text-decoration":
                return cssBoxProperties_0.TextDecoration;

            case "white-space":
                return cssBoxProperties_0.WhiteSpace;

            case "word-break":
                return cssBoxProperties_0.WordBreak;

            case "visibility":
                return cssBoxProperties_0.Visibility;

            case "word-spacing":
                return cssBoxProperties_0.WordSpacing;

            case "font-family":
                return cssBoxProperties_0.FontFamily;

            case "font-size":
                return cssBoxProperties_0.FontSize;

            case "font-style":
                return cssBoxProperties_0.FontStyle;

            case "font-variant":
                return cssBoxProperties_0.FontVariant;

            case "font-weight":
                return cssBoxProperties_0.FontWeight;

            case "list-style":
                return cssBoxProperties_0.ListStyle;

            case "list-style-position":
                return cssBoxProperties_0.ListStylePosition;

            case "list-style-image":
                return cssBoxProperties_0.ListStyleImage;

            case "list-style-type":
                return cssBoxProperties_0.ListStyleType;

            case "overflow":
                return cssBoxProperties_0.Overflow;
        }
        return null;
    }

    public static void smethod_3(CssBoxProperties cssBoxProperties_0, string string_0, string string_1)
    {
        switch (string_0)
        {
            case "border-bottom-width":
                cssBoxProperties_0.BorderBottomWidth = string_1;
                break;

            case "border-left-width":
                cssBoxProperties_0.BorderLeftWidth = string_1;
                break;

            case "border-right-width":
                cssBoxProperties_0.BorderRightWidth = string_1;
                break;

            case "border-top-width":
                cssBoxProperties_0.BorderTopWidth = string_1;
                break;

            case "border-bottom-style":
                cssBoxProperties_0.BorderBottomStyle = string_1;
                break;

            case "border-left-style":
                cssBoxProperties_0.BorderLeftStyle = string_1;
                break;

            case "border-right-style":
                cssBoxProperties_0.BorderRightStyle = string_1;
                break;

            case "border-top-style":
                cssBoxProperties_0.BorderTopStyle = string_1;
                break;

            case "border-bottom-color":
                cssBoxProperties_0.BorderBottomColor = string_1;
                break;

            case "border-left-color":
                cssBoxProperties_0.BorderLeftColor = string_1;
                break;

            case "border-right-color":
                cssBoxProperties_0.BorderRightColor = string_1;
                break;

            case "border-top-color":
                cssBoxProperties_0.BorderTopColor = string_1;
                break;

            case "border-spacing":
                cssBoxProperties_0.BorderSpacing = string_1;
                break;

            case "border-collapse":
                cssBoxProperties_0.BorderCollapse = string_1;
                break;

            case "corner-radius":
                cssBoxProperties_0.CornerRadius = string_1;
                break;

            case "corner-nw-radius":
                cssBoxProperties_0.CornerNwRadius = string_1;
                break;

            case "corner-ne-radius":
                cssBoxProperties_0.CornerNeRadius = string_1;
                break;

            case "corner-se-radius":
                cssBoxProperties_0.CornerSeRadius = string_1;
                break;

            case "corner-sw-radius":
                cssBoxProperties_0.CornerSwRadius = string_1;
                break;

            case "margin-bottom":
                cssBoxProperties_0.MarginBottom = string_1;
                break;

            case "margin-left":
                cssBoxProperties_0.MarginLeft = string_1;
                break;

            case "margin-right":
                cssBoxProperties_0.MarginRight = string_1;
                break;

            case "margin-top":
                cssBoxProperties_0.MarginTop = string_1;
                break;

            case "padding-bottom":
                cssBoxProperties_0.PaddingBottom = string_1;
                break;

            case "padding-left":
                cssBoxProperties_0.PaddingLeft = string_1;
                break;

            case "padding-right":
                cssBoxProperties_0.PaddingRight = string_1;
                break;

            case "padding-top":
                cssBoxProperties_0.PaddingTop = string_1;
                break;

            case "left":
                cssBoxProperties_0.Left = string_1;
                break;

            case "top":
                cssBoxProperties_0.Top = string_1;
                break;

            case "width":
                cssBoxProperties_0.Width = string_1;
                break;

            case "max-width":
                cssBoxProperties_0.MaxWidth = string_1;
                break;

            case "height":
                cssBoxProperties_0.Height = string_1;
                break;

            case "background-color":
                cssBoxProperties_0.BackgroundColor = string_1;
                break;

            case "background-image":
                cssBoxProperties_0.BackgroundImage = string_1;
                break;

            case "background-position":
                cssBoxProperties_0.BackgroundPosition = string_1;
                break;

            case "background-repeat":
                cssBoxProperties_0.BackgroundRepeat = string_1;
                break;

            case "background-gradient":
                cssBoxProperties_0.BackgroundGradient = string_1;
                break;

            case "background-gradient-angle":
                cssBoxProperties_0.BackgroundGradientAngle = string_1;
                break;

            case "color":
                cssBoxProperties_0.Color = string_1;
                break;

            case "display":
                cssBoxProperties_0.Display = string_1;
                break;

            case "direction":
                cssBoxProperties_0.Direction = string_1;
                break;

            case "empty-cells":
                cssBoxProperties_0.EmptyCells = string_1;
                break;

            case "float":
                cssBoxProperties_0.Float = string_1;
                break;

            case "position":
                cssBoxProperties_0.Position = string_1;
                break;

            case "line-height":
                cssBoxProperties_0.LineHeight = string_1;
                break;

            case "vertical-align":
                cssBoxProperties_0.VerticalAlign = string_1;
                break;

            case "text-indent":
                cssBoxProperties_0.TextIndent = string_1;
                break;

            case "text-align":
                cssBoxProperties_0.TextAlign = string_1;
                break;

            case "text-decoration":
                cssBoxProperties_0.TextDecoration = string_1;
                break;

            case "white-space":
                cssBoxProperties_0.WhiteSpace = string_1;
                break;

            case "word-break":
                cssBoxProperties_0.WordBreak = string_1;
                break;

            case "visibility":
                cssBoxProperties_0.Visibility = string_1;
                break;

            case "word-spacing":
                cssBoxProperties_0.WordSpacing = string_1;
                break;

            case "font-family":
                cssBoxProperties_0.FontFamily = string_1;
                break;

            case "font-size":
                cssBoxProperties_0.FontSize = string_1;
                break;

            case "font-style":
                cssBoxProperties_0.FontStyle = string_1;
                break;

            case "font-variant":
                cssBoxProperties_0.FontVariant = string_1;
                break;

            case "font-weight":
                cssBoxProperties_0.FontWeight = string_1;
                break;

            case "list-style":
                cssBoxProperties_0.ListStyle = string_1;
                break;

            case "list-style-position":
                cssBoxProperties_0.ListStylePosition = string_1;
                break;

            case "list-style-image":
                cssBoxProperties_0.ListStyleImage = string_1;
                break;

            case "list-style-type":
                cssBoxProperties_0.ListStyleType = string_1;
                break;

            case "overflow":
                cssBoxProperties_0.Overflow = string_1;
                break;
        }
    }
}

