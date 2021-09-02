namespace DSkin.Common
{
    using DSkin;
    using DSkin.Controls;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class ControlRender
    {
        public static void DrawBackgroundImage(Graphics g, ImageLayout layout, Image backgroundImage, Rectangle clientRectangle)
        {
            int width = clientRectangle.Width + 1;
            int height = clientRectangle.Height + 1;
            Region clip = g.Clip;
            using (Region region2 = new Region(clientRectangle))
            {
                Size size;
                float num3;
                region2.Intersect(clip);
                g.Clip = region2;
                switch (layout)
                {
                    case ImageLayout.None:
                        g.DrawImage(backgroundImage, new Rectangle(clientRectangle.X, clientRectangle.Y, backgroundImage.Width, backgroundImage.Height));
                        goto Label_01D2;

                    case ImageLayout.Tile:
                    {
                        using (TextureBrush brush = new TextureBrush(backgroundImage))
                        {
                            brush.WrapMode = WrapMode.Tile;
                            g.FillRectangle(brush, new Rectangle(clientRectangle.X, clientRectangle.Y, width - 1, height - 1));
                            goto Label_01D2;
                        }
                    }
                    case ImageLayout.Center:
                        g.DrawImage(backgroundImage, new Rectangle(((width - backgroundImage.Width) / 2) + clientRectangle.X, ((height - backgroundImage.Height) / 2) + clientRectangle.Y, backgroundImage.Width, backgroundImage.Height));
                        goto Label_01D2;

                    case ImageLayout.Stretch:
                        g.DrawImage(backgroundImage, new Rectangle(clientRectangle.X, clientRectangle.Y, width, height));
                        goto Label_01D2;

                    case ImageLayout.Zoom:
                    {
                        size = backgroundImage.Size;
                        num3 = Math.Min((float) (((float) width) / ((float) size.Width)), (float) (((float) height) / ((float) size.Height)));
                        if (Math.Round((double) (((float) width) / ((float) size.Width)), 2) != Math.Round((double) num3, 2))
                        {
                            break;
                        }
                        int num4 = (int) (size.Height * num3);
                        g.DrawImage(backgroundImage, new Rectangle(clientRectangle.X, ((height - num4) / 2) + clientRectangle.Y, width, num4));
                        goto Label_01D2;
                    }
                    default:
                        goto Label_01D2;
                }
                int num5 = (int) (size.Width * num3);
                g.DrawImage(backgroundImage, new Rectangle(((width - num5) / 2) + clientRectangle.X, clientRectangle.Y, num5, height));
            Label_01D2:
                g.Clip = clip;
            }
        }

        public static void DrawGradientColor(Graphics g, Color[] colors, float angle, Rectangle rect)
        {
            if ((colors != null) && (colors.Length != 0))
            {
                if (colors.Length == 1)
                {
                    using (SolidBrush brush = new SolidBrush(colors[0]))
                    {
                        g.FillRectangle(brush, rect);
                        return;
                    }
                }
                using (LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.Black, Color.Black, angle))
                {
                    ColorBlend blend = new ColorBlend {
                        Positions = new float[colors.Length]
                    };
                    blend.Positions[0] = 0f;
                    blend.Positions[colors.Length - 1] = 1f;
                    float num = 1f / ((float) (colors.Length - 1));
                    for (int i = 1; i < (colors.Length - 1); i++)
                    {
                        blend.Positions[i] = blend.Positions[i - 1] + num;
                    }
                    blend.Colors = colors;
                    brush2.InterpolationColors = blend;
                    g.FillRectangle(brush2, rect);
                }
            }
        }

        public static void DrawToBitmap(this Control control, Graphics g)
        {
            IntPtr hdc = g.GetHdc();
            if ((control is AxHost) || (control is WebBrowserBase))
            {
                IntPtr zero = IntPtr.Zero;
                IntPtr pUnk = IntPtr.Zero;
                if (control is AxHost)
                {
                    pUnk = Marshal.GetIUnknownForObject((control as AxHost).GetOcx());
                }
                else
                {
                    pUnk = Marshal.GetIUnknownForObject((control as WebBrowserBase).ActiveXInstance);
                }
                Marshal.QueryInterface(pUnk, ref DSkin.NativeMethods.IID_IViewObject, out zero);
                Marshal.Release(pUnk);
                Rectangle lprcBounds = new Rectangle(0, 0, control.Width, control.Height);
                DSkin.NativeMethods.OleDraw(zero, 1, hdc, ref lprcBounds);
                Marshal.Release(zero);
            }
            else
            {
                DSkin.NativeMethods.SendMessage(new HandleRef(control, control.Handle), 0x317, hdc, (IntPtr) 30);
            }
            g.ReleaseHdc(hdc);
        }

        public static void DrawToBitmap(this Control control, Graphics g, Rectangle targetBounds)
        {
            control.DrawToBitmap(g, targetBounds, Color.Empty);
        }

        public static void DrawToBitmap(this Control control, Graphics g, Rectangle targetBounds, Color transparencyKey)
        {
            using (Bitmap bitmap = new Bitmap(targetBounds.Width, targetBounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    IntPtr hdc = graphics.GetHdc();
                    if ((control is AxHost) || (control is WebBrowserBase))
                    {
                        IntPtr zero = IntPtr.Zero;
                        IntPtr pUnk = IntPtr.Zero;
                        if (control is AxHost)
                        {
                            pUnk = Marshal.GetIUnknownForObject((control as AxHost).GetOcx());
                        }
                        else
                        {
                            pUnk = Marshal.GetIUnknownForObject((control as WebBrowserBase).ActiveXInstance);
                        }
                        Marshal.QueryInterface(pUnk, ref DSkin.NativeMethods.IID_IViewObject, out zero);
                        Marshal.Release(pUnk);
                        Rectangle lprcBounds = new Rectangle(0, 0, targetBounds.Width, targetBounds.Height);
                        DSkin.NativeMethods.OleDraw(zero, 1, hdc, ref lprcBounds);
                        Marshal.Release(zero);
                    }
                    else
                    {
                        DSkin.NativeMethods.SendMessage(new HandleRef(control, control.Handle), 0x317, hdc, (IntPtr) 30);
                    }
                    graphics.ReleaseHdc(hdc);
                    if ((transparencyKey != Color.Empty) && (transparencyKey != Color.Transparent))
                    {
                        bitmap.MakeTransparent(transparencyKey);
                    }
                    g.DrawImage(bitmap, targetBounds.Location);
                }
            }
        }

        internal static void smethod_0(object object_0, Rectangle rectangle_0, Graphics graphics_0, Rectangle rectangle_1, Rectangle rectangle_2)
        {
            if (object_0.Visible && rectangle_1.IntersectsWith(rectangle_0))
            {
                if (object_0 is ILayered)
                {
                    ILayered layered = object_0 as ILayered;
                    if (layered.BitmapCache)
                    {
                        if (layered.ImageAttribute != null)
                        {
                            graphics_0.DrawImage(layered.Canvas, rectangle_0, 0, 0, rectangle_0.Width, rectangle_0.Height, GraphicsUnit.Pixel, layered.ImageAttribute);
                        }
                        else
                        {
                            graphics_0.DrawImage(layered.Canvas, rectangle_0);
                        }
                    }
                    else
                    {
                        SmoothingMode smoothingMode = graphics_0.SmoothingMode;
                        TextRenderingHint textRenderingHint = graphics_0.TextRenderingHint;
                        Region clip = graphics_0.Clip;
                        Rectangle invalidateRect = new Rectangle(rectangle_0.Location, rectangle_0.Size);
                        invalidateRect.Intersect(rectangle_1);
                        invalidateRect.Offset(-rectangle_0.Left, -rectangle_0.Top);
                        graphics_0.TranslateTransform((float) rectangle_0.Left, (float) rectangle_0.Top);
                        layered.PaintControl(graphics_0, invalidateRect);
                        graphics_0.TranslateTransform((float) -rectangle_0.Left, (float) -rectangle_0.Top);
                        graphics_0.Clip = clip;
                        graphics_0.TextRenderingHint = textRenderingHint;
                        graphics_0.SmoothingMode = smoothingMode;
                    }
                }
                else if ((rectangle_0.Width > 0) && (rectangle_0.Height > 0))
                {
                    if (object_0 is ControlHost)
                    {
                        ((Control) object_0).DrawToBitmap(graphics_0, rectangle_0, ((ControlHost) object_0).TransparencyKey);
                    }
                    else
                    {
                        ((Control) object_0).DrawToBitmap(graphics_0, rectangle_0);
                    }
                }
            }
            else if ((object_0 is ILayered) && (!object_0.Visible || !rectangle_2.IntersectsWith(rectangle_0)))
            {
                (object_0 as ILayered).DisposeCanvas();
            }
        }

        internal static void smethod_1(Control control_0, InvalidateEventHandler invalidateEventHandler_0)
        {
            EventHandler<InvalidateEventArgs> handler = null;
            <>c__DisplayClass2 class2;
            InvalidateEventHandler handler = invalidateEventHandler_0;
            Class9 class3 = new Class9(control_0);
            handler = new EventHandler<InvalidateEventArgs>(class2.<HookControl>b__0);
            class3.method_1(handler);
        }

        public static void SudokuDrawImage(Graphics g, Image img, Rectangle rect, int width)
        {
            g.DrawImage(img, new Rectangle(rect.X, rect.Y, width, width), new Rectangle(0, 0, width, width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - width, rect.Y, width, width), new Rectangle(img.Width - width, 0, width, width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X, rect.Bottom - width, width, width), new Rectangle(0, img.Height - width, width, width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - width, rect.Bottom - width, width, width), new Rectangle(img.Width - width, img.Height - width, width, width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X, rect.Y + width, width, rect.Height - (width * 2)), new Rectangle(0, width, width, img.Height - (width * 2)), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X + width, rect.Y, rect.Width - (width * 2), width), new Rectangle(width, 0, img.Width - (width * 2), width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - width, rect.Y + width, width, rect.Height - (width * 2)), new Rectangle(img.Width - width, width, width, img.Height - (width * 2)), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X + width, rect.Bottom - width, rect.Width - (width * 2), width), new Rectangle(width, img.Height - width, img.Width - (width * 2), width), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X + width, rect.Y + width, rect.Width - (width * 2), rect.Height - (width * 2)), new Rectangle(width, width, img.Width - (width * 2), img.Height - (width * 2)), GraphicsUnit.Pixel);
        }

        public static void SudokuDrawImage(Graphics g, Image img, Rectangle rect, Padding padding, Rectangle invalidateRect)
        {
            SudokuDrawImage(g, img, rect, padding, invalidateRect, true);
        }

        public static void SudokuDrawImage(Graphics g, Image img, Rectangle rect, Padding padding, Rectangle invalidateRect, bool drawCenter)
        {
            if (invalidateRect.IntersectsWith(new Rectangle(rect.X, rect.Y, padding.Left, padding.Top)))
            {
                g.DrawImage(img, new Rectangle(rect.X, rect.Y, padding.Left, padding.Top), new Rectangle(0, 0, padding.Left, padding.Top), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.Right - padding.Right, rect.Y, padding.Right, padding.Top)))
            {
                g.DrawImage(img, new Rectangle(rect.Right - padding.Right, rect.Y, padding.Right, padding.Top), new Rectangle(img.Width - padding.Right, 0, padding.Right, padding.Top), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.X, rect.Bottom - padding.Bottom, padding.Left, padding.Bottom)))
            {
                g.DrawImage(img, new Rectangle(rect.X, rect.Bottom - padding.Bottom, padding.Left, padding.Bottom), new Rectangle(0, img.Height - padding.Bottom, padding.Left, padding.Bottom), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.Right - padding.Right, rect.Bottom - padding.Bottom, padding.Right, padding.Bottom)))
            {
                g.DrawImage(img, new Rectangle(rect.Right - padding.Right, rect.Bottom - padding.Bottom, padding.Right, padding.Bottom), new Rectangle(img.Width - padding.Right, img.Height - padding.Bottom, padding.Right, padding.Bottom), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.X, rect.Y + padding.Top, padding.Left, rect.Height - padding.Vertical)))
            {
                g.DrawImage(img, new Rectangle(rect.X, rect.Y + padding.Top, padding.Left, rect.Height - padding.Vertical), new Rectangle(0, padding.Top, padding.Left, img.Height - padding.Vertical), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.X + padding.Left, rect.Y, rect.Width - padding.Horizontal, padding.Top)))
            {
                g.DrawImage(img, new Rectangle(rect.X + padding.Left, rect.Y, rect.Width - padding.Horizontal, padding.Top), new Rectangle(padding.Left, 0, img.Width - padding.Horizontal, padding.Top), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.Right - padding.Right, rect.Y + padding.Top, padding.Right, rect.Height - padding.Vertical)))
            {
                g.DrawImage(img, new Rectangle(rect.Right - padding.Right, rect.Y + padding.Top, padding.Right, rect.Height - padding.Vertical), new Rectangle(img.Width - padding.Right, padding.Top, padding.Right, img.Height - padding.Vertical), GraphicsUnit.Pixel);
            }
            if (invalidateRect.IntersectsWith(new Rectangle(rect.X + padding.Left, rect.Bottom - padding.Bottom, rect.Width - padding.Horizontal, padding.Bottom)))
            {
                g.DrawImage(img, new Rectangle(rect.X + padding.Left, rect.Bottom - padding.Bottom, rect.Width - padding.Horizontal, padding.Bottom), new Rectangle(padding.Left, img.Height - padding.Bottom, img.Width - padding.Horizontal, padding.Bottom), GraphicsUnit.Pixel);
            }
            if (drawCenter && invalidateRect.IntersectsWith(new Rectangle(rect.X + padding.Left, rect.Y + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical)))
            {
                g.DrawImage(img, new Rectangle(rect.X + padding.Left, rect.Y + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical), new Rectangle(padding.Left, padding.Top, img.Width - padding.Horizontal, img.Height - padding.Vertical), GraphicsUnit.Pixel);
            }
        }

        public static Color ToColor(this Color color)
        {
            return Color.FromArgb((color.A == 0xff) ? 0xfe : color.A, color.R, color.G, color.B);
        }
    }
}

