using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using System;

internal static class Class34
{
    public static void smethod_0(RGraphics rgraphics_0, CssBoxProperties cssBoxProperties_0, Class40 class40_0, RRect rrect_0)
    {
        RSize size = new RSize((class40_0.Rectangle == RRect.Empty) ? class40_0.Image.Width : class40_0.Rectangle.Width, (class40_0.Rectangle == RRect.Empty) ? class40_0.Image.Height : class40_0.Rectangle.Height);
        RPoint location = smethod_1(cssBoxProperties_0.BackgroundPosition, rrect_0, size);
        RRect srcRect = (class40_0.Rectangle == RRect.Empty) ? new RRect(0.0, 0.0, size.Width, size.Height) : new RRect(class40_0.Rectangle.Left, class40_0.Rectangle.Top, size.Width, size.Height);
        RRect destRect = new RRect(location, size);
        RRect rect = rrect_0;
        rect.Intersect(rgraphics_0.GetClip());
        rgraphics_0.PushClip(rect);
        string backgroundRepeat = cssBoxProperties_0.BackgroundRepeat;
        switch (backgroundRepeat)
        {
            case null:
                break;

            case "no-repeat":
                rgraphics_0.DrawImage(class40_0.Image, destRect, srcRect);
                goto Label_0168;

            default:
                if (!(backgroundRepeat == "repeat-x"))
                {
                    if (!(backgroundRepeat == "repeat-y"))
                    {
                        break;
                    }
                    smethod_3(rgraphics_0, class40_0, rrect_0, srcRect, destRect, size);
                }
                else
                {
                    smethod_2(rgraphics_0, class40_0, rrect_0, srcRect, destRect, size);
                }
                goto Label_0168;
        }
        smethod_4(rgraphics_0, class40_0, rrect_0, srcRect, destRect, size);
    Label_0168:
        rgraphics_0.PopClip();
    }

    private static RPoint smethod_1(string string_0, RRect rrect_0, RSize rsize_0)
    {
        double left = rrect_0.Left;
        if (string_0.IndexOf("left", StringComparison.OrdinalIgnoreCase) > -1)
        {
            left = rrect_0.Left + 0.5;
        }
        else if (string_0.IndexOf("right", StringComparison.OrdinalIgnoreCase) > -1)
        {
            left = rrect_0.Right - rsize_0.Width;
        }
        else if (string_0.IndexOf("0", StringComparison.OrdinalIgnoreCase) < 0)
        {
            left = (rrect_0.Left + ((rrect_0.Width - rsize_0.Width) / 2.0)) + 0.5;
        }
        double top = rrect_0.Top;
        if (string_0.IndexOf("top", StringComparison.OrdinalIgnoreCase) > -1)
        {
            top = rrect_0.Top;
        }
        else if (string_0.IndexOf("bottom", StringComparison.OrdinalIgnoreCase) > -1)
        {
            top = rrect_0.Bottom - rsize_0.Height;
        }
        else if (string_0.IndexOf("0", StringComparison.OrdinalIgnoreCase) < 0)
        {
            top = (rrect_0.Top + ((rrect_0.Height - rsize_0.Height) / 2.0)) + 0.5;
        }
        return new RPoint(left, top);
    }

    private static void smethod_2(RGraphics rgraphics_0, Class40 class40_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
    {
        while (rrect_2.X > rrect_0.X)
        {
            rrect_2.X -= rsize_0.Width;
        }
        using (RBrush brush = rgraphics_0.GetTextureBrush(class40_0.Image, rrect_1, rrect_2.Location))
        {
            rgraphics_0.DrawRectangle(brush, rrect_0.X, rrect_2.Y, rrect_0.Width, rrect_1.Height);
        }
    }

    private static void smethod_3(RGraphics rgraphics_0, Class40 class40_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
    {
        while (rrect_2.Y > rrect_0.Y)
        {
            rrect_2.Y -= rsize_0.Height;
        }
        using (RBrush brush = rgraphics_0.GetTextureBrush(class40_0.Image, rrect_1, rrect_2.Location))
        {
            rgraphics_0.DrawRectangle(brush, rrect_2.X, rrect_0.Y, rrect_1.Width, rrect_0.Height);
        }
    }

    private static void smethod_4(RGraphics rgraphics_0, Class40 class40_0, RRect rrect_0, RRect rrect_1, RRect rrect_2, RSize rsize_0)
    {
        while (rrect_2.X > rrect_0.X)
        {
            rrect_2.X -= rsize_0.Width;
        }
        while (rrect_2.Y > rrect_0.Y)
        {
            rrect_2.Y -= rsize_0.Height;
        }
        using (RBrush brush = rgraphics_0.GetTextureBrush(class40_0.Image, rrect_1, rrect_2.Location))
        {
            rgraphics_0.DrawRectangle(brush, rrect_0.X, rrect_0.Y, rrect_0.Width, rrect_0.Height);
        }
    }
}

