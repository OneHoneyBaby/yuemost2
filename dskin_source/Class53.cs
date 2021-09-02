using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core;
using DSkin.Html.Core.Dom;
using System;

internal static class Class53
{
    public static bool smethod_0(RGraphics rgraphics_0, CssBox cssBox_0)
    {
        CssBox containingBlock;
        for (CssBox box = cssBox_0.ContainingBlock; !(box.Overflow == "hidden"); box = containingBlock)
        {
            containingBlock = box.ContainingBlock;
            if (containingBlock == box)
            {
                return false;
            }
        }
        RRect clip = rgraphics_0.GetClip();
        RRect clientRectangle = cssBox_0.ContainingBlock.ClientRectangle;
        clientRectangle.X -= 2.0;
        clientRectangle.Width += 2.0;
        clientRectangle.Offset(cssBox_0.HtmlContainer.ScrollOffset);
        clientRectangle.Intersect(clip);
        rgraphics_0.PushClip(clientRectangle);
        return true;
    }

    public static void smethod_1(RGraphics rgraphics_0, HtmlContainerInt htmlContainerInt_0, RRect rrect_0)
    {
        rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.Left + 3.0, rrect_0.Top + 3.0, 13.0, 14.0);
        RImage loadingImage = htmlContainerInt_0.method_0().GetLoadingImage();
        rgraphics_0.DrawImage(loadingImage, new RRect(rrect_0.Left + 4.0, rrect_0.Top + 4.0, loadingImage.Width, loadingImage.Height));
    }

    public static void smethod_2(RGraphics rgraphics_0, HtmlContainerInt htmlContainerInt_0, RRect rrect_0)
    {
        rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.Left + 2.0, rrect_0.Top + 2.0, 15.0, 15.0);
        RImage loadingFailedImage = htmlContainerInt_0.method_0().GetLoadingFailedImage();
        rgraphics_0.DrawImage(loadingFailedImage, new RRect(rrect_0.Left + 3.0, rrect_0.Top + 3.0, loadingFailedImage.Width, loadingFailedImage.Height));
    }

    public static RGraphicsPath smethod_3(RGraphics rgraphics_0, RRect rrect_0, double double_0, double double_1, double double_2, double double_3)
    {
        RGraphicsPath graphicsPath = rgraphics_0.GetGraphicsPath();
        graphicsPath.Start(rrect_0.Left + double_0, rrect_0.Top);
        graphicsPath.LineTo(rrect_0.Right - double_1, rrect_0.Y);
        if (double_1 > 0.0)
        {
            graphicsPath.ArcTo(rrect_0.Right, rrect_0.Top + double_1, double_1, RGraphicsPath.Corner.TopRight);
        }
        graphicsPath.LineTo(rrect_0.Right, rrect_0.Bottom - double_2);
        if (double_2 > 0.0)
        {
            graphicsPath.ArcTo(rrect_0.Right - double_2, rrect_0.Bottom, double_2, RGraphicsPath.Corner.BottomRight);
        }
        graphicsPath.LineTo(rrect_0.Left + double_3, rrect_0.Bottom);
        if (double_3 > 0.0)
        {
            graphicsPath.ArcTo(rrect_0.Left, rrect_0.Bottom - double_3, double_3, RGraphicsPath.Corner.BottomLeft);
        }
        graphicsPath.LineTo(rrect_0.Left, rrect_0.Top + double_0);
        if (double_0 > 0.0)
        {
            graphicsPath.ArcTo(rrect_0.Left + double_0, rrect_0.Top, double_0, RGraphicsPath.Corner.TopLeft);
        }
        return graphicsPath;
    }

    public static bool XqRamjooQr(RColor rcolor_0)
    {
        return (rcolor_0.A > 0);
    }
}

