using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal static class Class35
{
    private static readonly RPoint[] rpoint_0 = new RPoint[4];

    public static void smethod_0(RGraphics rgraphics_0, CssBoxProperties cssBoxProperties_0, RRect rrect_0, bool bool_0, bool bool_1)
    {
        if ((rrect_0.Width > 0.0) && (rrect_0.Height > 0.0))
        {
            if (((!string.IsNullOrEmpty(cssBoxProperties_0.BorderTopStyle) && (cssBoxProperties_0.BorderTopStyle != "none")) && (cssBoxProperties_0.BorderTopStyle != "hidden")) && (cssBoxProperties_0.ActualBorderTopWidth > 0.0))
            {
                smethod_2((Enum3) 0, cssBoxProperties_0, rgraphics_0, rrect_0, bool_0, bool_1);
            }
            if (((bool_0 && !string.IsNullOrEmpty(cssBoxProperties_0.BorderLeftStyle)) && ((cssBoxProperties_0.BorderLeftStyle != "none") && (cssBoxProperties_0.BorderLeftStyle != "hidden"))) && (cssBoxProperties_0.ActualBorderLeftWidth > 0.0))
            {
                smethod_2((Enum3) 3, cssBoxProperties_0, rgraphics_0, rrect_0, true, bool_1);
            }
            if (((!string.IsNullOrEmpty(cssBoxProperties_0.BorderBottomStyle) && (cssBoxProperties_0.BorderBottomStyle != "none")) && (cssBoxProperties_0.BorderBottomStyle != "hidden")) && (cssBoxProperties_0.ActualBorderBottomWidth > 0.0))
            {
                smethod_2((Enum3) 2, cssBoxProperties_0, rgraphics_0, rrect_0, bool_0, bool_1);
            }
            if (((bool_1 && !string.IsNullOrEmpty(cssBoxProperties_0.BorderRightStyle)) && ((cssBoxProperties_0.BorderRightStyle != "none") && (cssBoxProperties_0.BorderRightStyle != "hidden"))) && (cssBoxProperties_0.ActualBorderRightWidth > 0.0))
            {
                smethod_2((Enum3) 1, cssBoxProperties_0, rgraphics_0, rrect_0, bool_0, true);
            }
        }
    }

    public static void smethod_1(Enum3 enum3_0, RGraphics rgraphics_0, CssBoxProperties cssBoxProperties_0, RBrush rbrush_0, RRect rrect_0)
    {
        smethod_3(enum3_0, cssBoxProperties_0, rrect_0, true, true);
        rgraphics_0.DrawPolygon(rbrush_0, rpoint_0);
    }

    private static void smethod_2(Enum3 enum3_0, object object_0, RGraphics rgraphics_0, RRect rrect_0, bool bool_0, bool bool_1)
    {
        RPen pen;
        string str = smethod_8(enum3_0, (CssBoxProperties) object_0);
        RColor color = smethod_6(enum3_0, (CssBoxProperties) object_0, str);
        RGraphicsPath path = smethod_4(rgraphics_0, enum3_0, (CssBoxProperties) object_0, rrect_0);
        if (path != null)
        {
            object prevMode = null;
            if (((object_0.HtmlContainer != null) && !object_0.HtmlContainer.AvoidGeometryAntialias) && object_0.IsRounded)
            {
                prevMode = rgraphics_0.SetAntiAliasSmoothingMode();
            }
            pen = smethod_5(rgraphics_0, str, color, smethod_7(enum3_0, (CssBoxProperties) object_0));
            using (path)
            {
                rgraphics_0.DrawPath(pen, path);
            }
            rgraphics_0.ReturnPreviousSmoothingMode(prevMode);
        }
        else if ((str == "inset") || (str == "outset"))
        {
            smethod_3(enum3_0, (CssBoxProperties) object_0, rrect_0, bool_0, bool_1);
            rgraphics_0.DrawPolygon(rgraphics_0.GetSolidBrush(color), rpoint_0);
        }
        else
        {
            pen = smethod_5(rgraphics_0, str, color, smethod_7(enum3_0, (CssBoxProperties) object_0));
            switch (enum3_0)
            {
                case ((Enum3) 0):
                    rgraphics_0.DrawLine(pen, Math.Ceiling(rrect_0.Left), rrect_0.Top + (object_0.ActualBorderTopWidth / 2.0), rrect_0.Right - 1.0, rrect_0.Top + (object_0.ActualBorderTopWidth / 2.0));
                    break;

                case ((Enum3) 1):
                    rgraphics_0.DrawLine(pen, rrect_0.Right - (object_0.ActualBorderRightWidth / 2.0), Math.Ceiling(rrect_0.Top), rrect_0.Right - (object_0.ActualBorderRightWidth / 2.0), Math.Floor(rrect_0.Bottom));
                    break;

                case ((Enum3) 2):
                    rgraphics_0.DrawLine(pen, Math.Ceiling(rrect_0.Left), rrect_0.Bottom - (object_0.ActualBorderBottomWidth / 2.0), rrect_0.Right - 1.0, rrect_0.Bottom - (object_0.ActualBorderBottomWidth / 2.0));
                    break;

                case ((Enum3) 3):
                    rgraphics_0.DrawLine(pen, rrect_0.Left + (object_0.ActualBorderLeftWidth / 2.0), Math.Ceiling(rrect_0.Top), rrect_0.Left + (object_0.ActualBorderLeftWidth / 2.0), Math.Floor(rrect_0.Bottom));
                    break;
            }
        }
    }

    private static void smethod_3(Enum3 enum3_0, CssBoxProperties cssBoxProperties_0, RRect rrect_0, bool bool_0, bool bool_1)
    {
        switch (enum3_0)
        {
            case ((Enum3) 0):
                rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Top);
                rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Top);
                rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Top + cssBoxProperties_0.ActualBorderTopWidth);
                rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Top + cssBoxProperties_0.ActualBorderTopWidth);
                if (bool_1)
                {
                    rpoint_0[2].X -= cssBoxProperties_0.ActualBorderRightWidth;
                }
                if (bool_0)
                {
                    rpoint_0[3].X += cssBoxProperties_0.ActualBorderLeftWidth;
                }
                break;

            case ((Enum3) 1):
                rpoint_0[0] = new RPoint(rrect_0.Right - cssBoxProperties_0.ActualBorderRightWidth, rrect_0.Top + cssBoxProperties_0.ActualBorderTopWidth);
                rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Top);
                rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Bottom);
                rpoint_0[3] = new RPoint(rrect_0.Right - cssBoxProperties_0.ActualBorderRightWidth, rrect_0.Bottom - cssBoxProperties_0.ActualBorderBottomWidth);
                break;

            case ((Enum3) 2):
                rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Bottom - cssBoxProperties_0.ActualBorderBottomWidth);
                rpoint_0[1] = new RPoint(rrect_0.Right, rrect_0.Bottom - cssBoxProperties_0.ActualBorderBottomWidth);
                rpoint_0[2] = new RPoint(rrect_0.Right, rrect_0.Bottom);
                rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Bottom);
                if (bool_0)
                {
                    rpoint_0[0].X += cssBoxProperties_0.ActualBorderLeftWidth;
                }
                if (bool_1)
                {
                    rpoint_0[1].X -= cssBoxProperties_0.ActualBorderRightWidth;
                }
                break;

            case ((Enum3) 3):
                rpoint_0[0] = new RPoint(rrect_0.Left, rrect_0.Top);
                rpoint_0[1] = new RPoint(rrect_0.Left + cssBoxProperties_0.ActualBorderLeftWidth, rrect_0.Top + cssBoxProperties_0.ActualBorderTopWidth);
                rpoint_0[2] = new RPoint(rrect_0.Left + cssBoxProperties_0.ActualBorderLeftWidth, rrect_0.Bottom - cssBoxProperties_0.ActualBorderBottomWidth);
                rpoint_0[3] = new RPoint(rrect_0.Left, rrect_0.Bottom);
                break;
        }
    }

    private static RGraphicsPath smethod_4(RGraphics rgraphics_0, Enum3 enum3_0, CssBoxProperties cssBoxProperties_0, RRect rrect_0)
    {
        RGraphicsPath graphicsPath = null;
        bool flag;
        bool flag2;
        switch (enum3_0)
        {
            case ((Enum3) 0):
                if ((cssBoxProperties_0.ActualCornerNw > 0.0) || (cssBoxProperties_0.ActualCornerNe > 0.0))
                {
                    graphicsPath = rgraphics_0.GetGraphicsPath();
                    graphicsPath.Start(rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0), (rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0)) + cssBoxProperties_0.ActualCornerNw);
                    if (cssBoxProperties_0.ActualCornerNw > 0.0)
                    {
                        graphicsPath.ArcTo((rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0)) + cssBoxProperties_0.ActualCornerNw, rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0), cssBoxProperties_0.ActualCornerNw, RGraphicsPath.Corner.TopLeft);
                    }
                    graphicsPath.LineTo((rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0)) - cssBoxProperties_0.ActualCornerNe, rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0));
                    if (cssBoxProperties_0.ActualCornerNe > 0.0)
                    {
                        graphicsPath.ArcTo(rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0), (rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0)) + cssBoxProperties_0.ActualCornerNe, cssBoxProperties_0.ActualCornerNe, RGraphicsPath.Corner.TopRight);
                    }
                }
                return graphicsPath;

            case ((Enum3) 1):
                if ((cssBoxProperties_0.ActualCornerNe > 0.0) || (cssBoxProperties_0.ActualCornerSe > 0.0))
                {
                    graphicsPath = rgraphics_0.GetGraphicsPath();
                    flag2 = (cssBoxProperties_0.BorderTopStyle == "none") || (cssBoxProperties_0.BorderTopStyle == "hidden");
                    flag = (cssBoxProperties_0.BorderBottomStyle == "none") || (cssBoxProperties_0.BorderBottomStyle == "hidden");
                    graphicsPath.Start((rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0)) - (flag2 ? cssBoxProperties_0.ActualCornerNe : 0.0), (rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0)) + (flag2 ? 0.0 : cssBoxProperties_0.ActualCornerNe));
                    if ((cssBoxProperties_0.ActualCornerNe > 0.0) && flag2)
                    {
                        graphicsPath.ArcTo(rrect_0.Right - (cssBoxProperties_0.ActualBorderLeftWidth / 2.0), (rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0)) + cssBoxProperties_0.ActualCornerNe, cssBoxProperties_0.ActualCornerNe, RGraphicsPath.Corner.TopRight);
                    }
                    graphicsPath.LineTo(rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0), (rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0)) - cssBoxProperties_0.ActualCornerSe);
                    if ((cssBoxProperties_0.ActualCornerSe > 0.0) && flag)
                    {
                        graphicsPath.ArcTo((rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0)) - cssBoxProperties_0.ActualCornerSe, rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0), cssBoxProperties_0.ActualCornerSe, RGraphicsPath.Corner.BottomRight);
                    }
                }
                return graphicsPath;

            case ((Enum3) 2):
                if ((cssBoxProperties_0.ActualCornerSw > 0.0) || (cssBoxProperties_0.ActualCornerSe > 0.0))
                {
                    graphicsPath = rgraphics_0.GetGraphicsPath();
                    graphicsPath.Start(rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0), (rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0)) - cssBoxProperties_0.ActualCornerSe);
                    if (cssBoxProperties_0.ActualCornerSe > 0.0)
                    {
                        graphicsPath.ArcTo((rrect_0.Right - (cssBoxProperties_0.ActualBorderRightWidth / 2.0)) - cssBoxProperties_0.ActualCornerSe, rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0), cssBoxProperties_0.ActualCornerSe, RGraphicsPath.Corner.BottomRight);
                    }
                    graphicsPath.LineTo((rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0)) + cssBoxProperties_0.ActualCornerSw, rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0));
                    if (cssBoxProperties_0.ActualCornerSw > 0.0)
                    {
                        graphicsPath.ArcTo(rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0), (rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0)) - cssBoxProperties_0.ActualCornerSw, cssBoxProperties_0.ActualCornerSw, RGraphicsPath.Corner.BottomLeft);
                    }
                }
                return graphicsPath;

            case ((Enum3) 3):
                if ((cssBoxProperties_0.ActualCornerNw > 0.0) || (cssBoxProperties_0.ActualCornerSw > 0.0))
                {
                    graphicsPath = rgraphics_0.GetGraphicsPath();
                    flag2 = (cssBoxProperties_0.BorderTopStyle == "none") || (cssBoxProperties_0.BorderTopStyle == "hidden");
                    flag = (cssBoxProperties_0.BorderBottomStyle == "none") || (cssBoxProperties_0.BorderBottomStyle == "hidden");
                    graphicsPath.Start((rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0)) + (flag ? cssBoxProperties_0.ActualCornerSw : 0.0), (rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0)) - (flag ? 0.0 : cssBoxProperties_0.ActualCornerSw));
                    if ((cssBoxProperties_0.ActualCornerSw > 0.0) && flag)
                    {
                        graphicsPath.ArcTo(rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0), (rrect_0.Bottom - (cssBoxProperties_0.ActualBorderBottomWidth / 2.0)) - cssBoxProperties_0.ActualCornerSw, cssBoxProperties_0.ActualCornerSw, RGraphicsPath.Corner.BottomLeft);
                    }
                    graphicsPath.LineTo(rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0), (rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0)) + cssBoxProperties_0.ActualCornerNw);
                    if ((cssBoxProperties_0.ActualCornerNw > 0.0) && flag2)
                    {
                        graphicsPath.ArcTo((rrect_0.Left + (cssBoxProperties_0.ActualBorderLeftWidth / 2.0)) + cssBoxProperties_0.ActualCornerNw, rrect_0.Top + (cssBoxProperties_0.ActualBorderTopWidth / 2.0), cssBoxProperties_0.ActualCornerNw, RGraphicsPath.Corner.TopLeft);
                    }
                }
                return graphicsPath;
        }
        return graphicsPath;
    }

    private static RPen smethod_5(RGraphics rgraphics_0, string string_0, RColor rcolor_0, double double_0)
    {
        RPen pen = rgraphics_0.GetPen(rcolor_0);
        pen.Width = double_0;
        string str = string_0;
        if (str != null)
        {
            if (str != "solid")
            {
                if (!(str == "dotted"))
                {
                    if (str == "dashed")
                    {
                        pen.DashStyle = RDashStyle.Dash;
                    }
                    return pen;
                }
                pen.DashStyle = RDashStyle.Dot;
                return pen;
            }
            pen.DashStyle = RDashStyle.Solid;
        }
        return pen;
    }

    private static RColor smethod_6(Enum3 enum3_0, CssBoxProperties cssBoxProperties_0, string string_0)
    {
        switch (enum3_0)
        {
            case ((Enum3) 0):
                return ((string_0 == "inset") ? smethod_9(cssBoxProperties_0.ActualBorderTopColor) : cssBoxProperties_0.ActualBorderTopColor);

            case ((Enum3) 1):
                return ((string_0 == "outset") ? smethod_9(cssBoxProperties_0.ActualBorderRightColor) : cssBoxProperties_0.ActualBorderRightColor);

            case ((Enum3) 2):
                return ((string_0 == "outset") ? smethod_9(cssBoxProperties_0.ActualBorderBottomColor) : cssBoxProperties_0.ActualBorderBottomColor);

            case ((Enum3) 3):
                return ((string_0 == "inset") ? smethod_9(cssBoxProperties_0.ActualBorderLeftColor) : cssBoxProperties_0.ActualBorderLeftColor);
        }
        throw new ArgumentOutOfRangeException("border");
    }

    private static double smethod_7(Enum3 enum3_0, CssBoxProperties cssBoxProperties_0)
    {
        switch (enum3_0)
        {
            case ((Enum3) 0):
                return cssBoxProperties_0.ActualBorderTopWidth;

            case ((Enum3) 1):
                return cssBoxProperties_0.ActualBorderRightWidth;

            case ((Enum3) 2):
                return cssBoxProperties_0.ActualBorderBottomWidth;

            case ((Enum3) 3):
                return cssBoxProperties_0.ActualBorderLeftWidth;
        }
        throw new ArgumentOutOfRangeException("border");
    }

    private static string smethod_8(Enum3 enum3_0, CssBoxProperties cssBoxProperties_0)
    {
        switch (enum3_0)
        {
            case ((Enum3) 0):
                return cssBoxProperties_0.BorderTopStyle;

            case ((Enum3) 1):
                return cssBoxProperties_0.BorderRightStyle;

            case ((Enum3) 2):
                return cssBoxProperties_0.BorderBottomStyle;

            case ((Enum3) 3):
                return cssBoxProperties_0.BorderLeftStyle;
        }
        throw new ArgumentOutOfRangeException("border");
    }

    private static RColor smethod_9(RColor rcolor_0)
    {
        return RColor.FromArgb(rcolor_0.R / 2, rcolor_0.G / 2, rcolor_0.B / 2);
    }
}

