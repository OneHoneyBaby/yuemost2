namespace DSkin.Common
{
    using DSkin;
    using DSkin.Controls;
    using DSkin.Imaging;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class SkinTools
    {
        public static Bitmap BothAlpha(Bitmap p_Bitmap, bool p_CentralTransparent, bool p_Crossdirection)
        {
            Bitmap image = new Bitmap(p_Bitmap.Width, p_Bitmap.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(p_Bitmap, new Rectangle(0, 0, p_Bitmap.Width, p_Bitmap.Height));
            graphics.Dispose();
            Bitmap bitmap2 = new Bitmap(image.Width, image.Height);
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            Point point = new Point(0, 0);
            Point point2 = new Point(bitmap2.Width, 0);
            Point point3 = new Point(bitmap2.Width, bitmap2.Height / 2);
            Point point4 = new Point(0, bitmap2.Height / 2);
            if (p_Crossdirection)
            {
                point = new Point(0, 0);
                point2 = new Point(bitmap2.Width / 2, 0);
                point3 = new Point(bitmap2.Width / 2, bitmap2.Height);
                point4 = new Point(0, bitmap2.Height);
            }
            Point[] points = new Point[] { point, point2, point3, point4 };
            PathGradientBrush brush = new PathGradientBrush(points, WrapMode.TileFlipY) {
                CenterPoint = new PointF(0f, 0f),
                FocusScales = new PointF((float) (bitmap2.Width / 2), 0f),
                CenterColor = Color.FromArgb(0, 0xff, 0xff, 0xff)
            };
            Color[] colorArray = new Color[] { Color.FromArgb(0xff, 0xff, 0xff, 0xff) };
            brush.SurroundColors = colorArray;
            if (p_Crossdirection)
            {
                brush.FocusScales = new PointF(0f, (float) bitmap2.Height);
                brush.WrapMode = WrapMode.TileFlipX;
            }
            if (p_CentralTransparent)
            {
                brush.CenterColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
                colorArray = new Color[] { Color.FromArgb(0, 0xff, 0xff, 0xff) };
                brush.SurroundColors = colorArray;
            }
            graphics2.FillRectangle(brush, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
            graphics2.Dispose();
            BitmapData bitmapdata = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, bitmap2.PixelFormat);
            byte[] destination = new byte[bitmapdata.Stride * bitmapdata.Height];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
            bitmap2.UnlockBits(bitmapdata);
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            byte[] buffer = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
            int index = 0;
            for (int i = 0; i != data.Height; i++)
            {
                index = (i * data.Stride) + 3;
                for (int j = 0; j != data.Width; j++)
                {
                    buffer[index] = destination[index];
                    index += 4;
                }
            }
            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
            image.UnlockBits(data);
            return image;
        }

        public static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap, int Alpha)
        {
            FastBitmap bitmap2 = new FastBitmap(bitmap);
            bitmap2.Lock();
            GraphicsPath path = new GraphicsPath();
            int x = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                x = 0;
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (bitmap2.GetPixel(j, i).A < Alpha)
                    {
                        continue;
                    }
                    x = j;
                    int num4 = j;
                    num4 = x;
                    while (num4 < bitmap.Width)
                    {
                        if (bitmap2.GetPixel(num4, i).A < Alpha)
                        {
                            break;
                        }
                        num4++;
                    }
                    path.AddRectangle(new Rectangle(x, i, num4 - x, 1));
                    j = num4;
                }
            }
            bitmap2.Unlock();
            return path;
        }

        public static bool ColorSlantsDarkOrBright(Color c)
        {
            HSL hsl = ColorConverterEx.smethod_0(c);
            return ((hsl.Luminance < 0.15) || ((hsl.Luminance < 0.35) || ((hsl.Luminance < 0.85) && false)));
        }

        public static void CreateControlRegion(Control control, Bitmap bitmap, int Alpha)
        {
            if ((control != null) && (bitmap != null))
            {
                GraphicsPath path;
                control.Width = bitmap.Width;
                control.Height = bitmap.Height;
                if (control is Form)
                {
                    Form form = (Form) control;
                    form.Width = control.Width;
                    form.Height = control.Height;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackgroundImage = bitmap;
                    Bitmap image = new Bitmap(bitmap.Width, bitmap.Height);
                    Graphics graphics = Graphics.FromImage(image);
                    foreach (Control control2 in form.Controls)
                    {
                        graphics.FillRectangle(new SolidBrush(form.BackColor), new Rectangle(control2.Location, control2.Size));
                    }
                    graphics.DrawImage(bitmap, 0, 0);
                    path = CalculateControlGraphicsPath(image, Alpha);
                    form.Region = new Region(path);
                    GC.Collect();
                }
                else if (control is DSkinButton)
                {
                    DSkinButton button = (DSkinButton) control;
                    path = CalculateControlGraphicsPath(bitmap, Alpha);
                    button.Region = new Region(path);
                }
            }
        }

        public static void CreateRegion(Control control, Rectangle bounds)
        {
            CreateRegion(control, bounds, 8, RoundStyle.All);
        }

        public static void CreateRegion(Control ctrl, int RgnRadius)
        {
            int hRgn = DSkin.NativeMethods.CreateRoundRectRgn(0, 0, ctrl.ClientRectangle.Width + 1, ctrl.ClientRectangle.Height + 1, RgnRadius, RgnRadius);
            DSkin.NativeMethods.SetWindowRgn(ctrl.Handle, hRgn, true);
        }

        public static void CreateRegion(IntPtr hWnd, int radius, RoundStyle roundStyle, bool redraw)
        {
            DSkin.RECT lpRect = new DSkin.RECT();
            DSkin.NativeMethods.GetWindowRect(hWnd, ref lpRect);
            Rectangle rect = new Rectangle(Point.Empty, lpRect.Size);
            if (roundStyle != RoundStyle.None)
            {
                using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, radius, roundStyle, true))
                {
                    using (Region region = new Region(path))
                    {
                        path.Widen(Pens.White);
                        region.Union(path);
                        IntPtr windowDC = DSkin.NativeMethods.GetWindowDC(hWnd);
                        try
                        {
                            using (Graphics graphics = Graphics.FromHdc(windowDC))
                            {
                                DSkin.NativeMethods.SetWindowRgn(hWnd, region.GetHrgn(graphics), redraw);
                            }
                        }
                        finally
                        {
                            DSkin.NativeMethods.ReleaseDC(hWnd, windowDC);
                        }
                    }
                    return;
                }
            }
            IntPtr hRgn = DSkin.NativeMethods.CreateRectRgn(0, 0, rect.Width, rect.Height);
            DSkin.NativeMethods.SetWindowRgn(hWnd, hRgn, redraw);
        }

        public static void CreateRegion(Control control, Rectangle bounds, int radius, RoundStyle roundStyle)
        {
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(bounds, radius, roundStyle, true))
            {
                Region region = new Region(path);
                path.Widen(Pens.White);
                region.Union(path);
                control.Region = region;
            }
        }

        public static void CursorClick(int x, int y)
        {
            DSkin.NativeMethods.mouse_event(2, (x * 0x10000) / 0x400, (y * 0x10000) / 0x300, 0, 0);
            DSkin.NativeMethods.mouse_event(4, (x * 0x10000) / 0x400, (y * 0x10000) / 0x300, 0, 0);
        }

        public static Bitmap GaryImg(Bitmap b)
        {
            if ((b.Width != 0) || (b.Height != 0))
            {
                return null;
            }
            Bitmap bitmap = b.Clone(new Rectangle(0, 0, b.Width, b.Height), PixelFormat.Format24bppRgb);
            b.Dispose();
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] destination = new byte[bitmap.Height * bitmapdata.Stride];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
            int num2 = 0;
            int width = bitmap.Width;
            while (num2 < width)
            {
                int num = 0;
                int height = bitmap.Height;
                while (num < height)
                {
                    byte num3;
                    destination[((num * bitmapdata.Stride) + (num2 * 3)) + 2] = num3 = smethod_1(destination[(num * bitmapdata.Stride) + (num2 * 3)], destination[((num * bitmapdata.Stride) + (num2 * 3)) + 1], destination[((num * bitmapdata.Stride) + (num2 * 3)) + 2]);
                    destination[(num * bitmapdata.Stride) + (num2 * 3)] = destination[((num * bitmapdata.Stride) + (num2 * 3)) + 1] = num3;
                    num++;
                }
                num2++;
            }
            Marshal.Copy(destination, 0, bitmapdata.Scan0, destination.Length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static Color GetImageAverageColor(Image back)
        {
            return BitmapHelper.GetImageAverageColor(back);
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration)
        {
            Bitmap image = null;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int) ef.Width, (int) ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, (float) 0f, (float) 0f);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                    graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                    graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                    for (int i = 0; i <= BlurConsideration; i++)
                                    {
                                        for (int j = 0; j <= BlurConsideration; j++)
                                        {
                                            graphics3.DrawImageUnscaled(bitmap2, i, j);
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, (float) (BlurConsideration / 2), (float) (BlurConsideration / 2));
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration, Rectangle rc, bool auto)
        {
            Bitmap image = null;
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap) {
                Trimming = auto ? StringTrimming.EllipsisWord : StringTrimming.None
            };
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int) ef.Width, (int) ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, rc, format);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    if (ColorBack != Color.Transparent)
                                    {
                                        graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                        graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                        graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                        for (int i = 0; i <= BlurConsideration; i++)
                                        {
                                            for (int j = 0; j <= BlurConsideration; j++)
                                            {
                                                graphics3.DrawImageUnscaled(bitmap2, i, j);
                                            }
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, new Rectangle(new Point(Convert.ToInt32((int) (BlurConsideration / 2)), Convert.ToInt32((int) (BlurConsideration / 2))), rc.Size), format);
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

        public static Bitmap ResizeBitmap(Bitmap b, int dstWidth, int dstHeight)
        {
            Bitmap image = new Bitmap(dstWidth, dstHeight);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.Bilinear;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(b, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, b.Width, b.Height), GraphicsUnit.Pixel);
            graphics.Save();
            graphics.Dispose();
            return image;
        }

        private static void smethod_0(Control control_0, double double_0)
        {
            byte num = (byte) (double_0 * 255.0);
            int windowLong = (int) DSkin.NativeMethods.GetWindowLong(control_0.Handle, -20);
            byte bAlpha = num;
            int num4 = windowLong;
            if (bAlpha != 0xff)
            {
                num4 |= 0x80000;
            }
            if ((num4 != windowLong) || ((num4 & 0x80000) != 0))
            {
                if (num4 != windowLong)
                {
                    DSkin.NativeMethods.SetWindowLong(control_0.Handle, -20, new IntPtr(num4));
                }
                if ((num4 & 0x80000) != 0)
                {
                    DSkin.NativeMethods.SetLayeredWindowAttributes(control_0.Handle, 0, bAlpha, 2);
                }
            }
            GC.KeepAlive(control_0);
        }

        private static byte smethod_1(byte byte_0, byte byte_1, byte byte_2)
        {
            return (byte) (((byte_2 + byte_1) + byte_0) / 3);
        }
    }
}

