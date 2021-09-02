namespace DSkin.Html
{
    using DSkin;
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;

    public static class HtmlRender
    {
        public static void AddFontFamily(FontFamily fontFamily)
        {
            ArgChecker.AssertArgNotNull(fontFamily, "fontFamily");
            WinFormsAdapter.Instance.AddFontFamily(new FontFamilyAdapter(fontFamily));
        }

        public static void AddFontFamilyMapping(string fromFamily, string toFamily)
        {
            ArgChecker.AssertArgNotNullOrEmpty(fromFamily, "fromFamily");
            ArgChecker.AssertArgNotNullOrEmpty(toFamily, "toFamily");
            WinFormsAdapter.Instance.AddFontFamilyMapping(fromFamily, toFamily);
        }

        public static SizeF Measure(Graphics g, string html, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return tduawadtRH(g, html, maxWidth, cssData, false, stylesheetLoad, imageLoad);
        }

        public static SizeF MeasureGdiPlus(Graphics g, string html, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return tduawadtRH(g, html, maxWidth, cssData, true, stylesheetLoad, imageLoad);
        }

        public static CssData ParseStyleSheet(string stylesheet, bool combineWithDefault = true)
        {
            return CssData.Parse(WinFormsAdapter.Instance, stylesheet, combineWithDefault);
        }

        public static SizeF Render(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return smethod_1(g, html, location, maxSize, cssData, false, stylesheetLoad, imageLoad);
        }

        public static SizeF Render(Graphics g, string html, float left = 0f, float top = 0f, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return smethod_1(g, html, new PointF(left, top), new SizeF(maxWidth, 0f), cssData, false, stylesheetLoad, imageLoad);
        }

        public static SizeF RenderGdiPlus(Graphics g, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return smethod_1(g, html, location, maxSize, cssData, true, stylesheetLoad, imageLoad);
        }

        public static SizeF RenderGdiPlus(Graphics g, string html, float left = 0f, float top = 0f, float maxWidth = 0f, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(g, "g");
            return smethod_1(g, html, new PointF(left, top), new SizeF(maxWidth, 0f), cssData, true, stylesheetLoad, imageLoad);
        }

        public static void RenderToImage(Image image, string html, PointF location = new PointF(), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(image, "image");
            SizeF maxSize = new SizeF(image.Size.Width - location.X, image.Size.Height - location.Y);
            RenderToImage(image, html, location, maxSize, cssData, stylesheetLoad, imageLoad);
        }

        public static Image RenderToImage(string html, Size size, Color backgroundColor = new Color(), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (backgroundColor == Color.Transparent)
            {
                throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");
            }
            Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            if (!string.IsNullOrEmpty(html))
            {
                IntPtr ptr;
                IntPtr hdc = DSkin.NativeMethods.CreateMemoryHdc(IntPtr.Zero, bitmap.Width, bitmap.Height, out ptr);
                try
                {
                    using (Graphics graphics = Graphics.FromHdc(hdc))
                    {
                        graphics.Clear((backgroundColor != Color.Empty) ? backgroundColor : Color.White);
                        smethod_2(graphics, html, PointF.Empty, (SizeF) size, cssData, true, stylesheetLoad, imageLoad);
                    }
                    smethod_3(hdc, bitmap);
                }
                finally
                {
                    DSkin.NativeMethods.ReleaseMemoryHdc(hdc, ptr);
                }
            }
            return bitmap;
        }

        public static void RenderToImage(Image image, string html, PointF location, SizeF maxSize, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            ArgChecker.AssertArgNotNull(image, "image");
            if (!string.IsNullOrEmpty(html))
            {
                IntPtr ptr;
                IntPtr hdc = DSkin.NativeMethods.CreateMemoryHdc(IntPtr.Zero, image.Width, image.Height, out ptr);
                try
                {
                    using (Graphics graphics = Graphics.FromHdc(hdc))
                    {
                        graphics.DrawImageUnscaled(image, 0, 0);
                        smethod_2(graphics, html, location, maxSize, cssData, false, stylesheetLoad, imageLoad);
                    }
                    smethod_3(hdc, image);
                }
                finally
                {
                    DSkin.NativeMethods.ReleaseMemoryHdc(hdc, ptr);
                }
            }
        }

        public static Image RenderToImage(string html, Size minSize, Size maxSize, Color backgroundColor = new Color(), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (backgroundColor == Color.Transparent)
            {
                throw new ArgumentOutOfRangeException("backgroundColor", "Transparent background in not supported");
            }
            if (string.IsNullOrEmpty(html))
            {
                return new Bitmap(0, 0, PixelFormat.Format32bppArgb);
            }
            using (HtmlContainer container = new HtmlContainer())
            {
                IntPtr ptr;
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;
                if (stylesheetLoad != null)
                {
                    container.StylesheetLoad += stylesheetLoad;
                }
                if (imageLoad != null)
                {
                    container.ImageLoad += imageLoad;
                }
                container.SetHtml(html, cssData);
                Size size = smethod_0(container, minSize, maxSize);
                container.MaxSize = (SizeF) size;
                Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                IntPtr hdc = DSkin.NativeMethods.CreateMemoryHdc(IntPtr.Zero, bitmap.Width, bitmap.Height, out ptr);
                try
                {
                    using (Graphics graphics = Graphics.FromHdc(hdc))
                    {
                        graphics.Clear((backgroundColor != Color.Empty) ? backgroundColor : Color.White);
                        container.PerformPaint(graphics, null);
                    }
                    smethod_3(hdc, bitmap);
                }
                finally
                {
                    DSkin.NativeMethods.ReleaseMemoryHdc(hdc, ptr);
                }
                return bitmap;
            }
        }

        public static Image RenderToImage(string html, int maxWidth = 0, int maxHeight = 0, Color backgroundColor = new Color(), CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            return RenderToImage(html, Size.Empty, new Size(maxWidth, maxHeight), backgroundColor, cssData, stylesheetLoad, imageLoad);
        }

        public static Image RenderToImageGdiPlus(string html, Size size, TextRenderingHint textRenderingHint = 4, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            Bitmap image = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.TextRenderingHint = textRenderingHint;
                smethod_2(graphics, html, PointF.Empty, (SizeF) size, cssData, true, stylesheetLoad, imageLoad);
            }
            return image;
        }

        public static Image RenderToImageGdiPlus(string html, Size minSize, Size maxSize, TextRenderingHint textRenderingHint = 4, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            if (string.IsNullOrEmpty(html))
            {
                return new Bitmap(0, 0, PixelFormat.Format32bppArgb);
            }
            using (HtmlContainer container = new HtmlContainer())
            {
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;
                container.method_2(true);
                if (stylesheetLoad != null)
                {
                    container.StylesheetLoad += stylesheetLoad;
                }
                if (imageLoad != null)
                {
                    container.ImageLoad += imageLoad;
                }
                container.SetHtml(html, cssData);
                Size size = smethod_0(container, minSize, maxSize);
                container.MaxSize = (SizeF) size;
                Bitmap image = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.TextRenderingHint = textRenderingHint;
                    container.PerformPaint(graphics, null);
                }
                return image;
            }
        }

        public static Image RenderToImageGdiPlus(string html, int maxWidth = 0, int maxHeight = 0, TextRenderingHint textRenderingHint = 4, CssData cssData = null, EventHandler<HtmlStylesheetLoadEventArgs> stylesheetLoad = null, EventHandler<HtmlImageLoadEventArgs> imageLoad = null)
        {
            return RenderToImageGdiPlus(html, Size.Empty, new Size(maxWidth, maxHeight), textRenderingHint, cssData, stylesheetLoad, imageLoad);
        }

        private static Size smethod_0(HtmlContainer htmlContainer_0, Size size_0, Size size_1)
        {
            Size size2;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                using (GraphicsAdapter adapter = new GraphicsAdapter(graphics, htmlContainer_0.method_1(), false))
                {
                    RSize s = HtmlRendererUtils.MeasureHtmlByRestrictions(adapter, htmlContainer_0.method_0(), Utils.Convert((SizeF) size_0), Utils.Convert((SizeF) size_1));
                    if ((size_1.Width < 1) && (s.Width > 4096.0))
                    {
                        s.Width = 4096.0;
                    }
                    size2 = Utils.ConvertRound(s);
                }
            }
            return size2;
        }

        private static SizeF smethod_1(Graphics graphics_0, string string_0, PointF pointF_0, SizeF sizeF_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
        {
            Region clip = null;
            if (sizeF_0.Height > 0f)
            {
                clip = graphics_0.Clip;
                graphics_0.SetClip(new RectangleF(pointF_0, sizeF_0));
            }
            SizeF ef = smethod_2(graphics_0, string_0, pointF_0, sizeF_0, cssData_0, bool_0, eventHandler_0, eventHandler_1);
            if (clip != null)
            {
                graphics_0.SetClip(clip, CombineMode.Replace);
            }
            return ef;
        }

        private static SizeF smethod_2(Graphics graphics_0, string string_0, PointF pointF_0, SizeF sizeF_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
        {
            SizeF empty = SizeF.Empty;
            if (string.IsNullOrEmpty(string_0))
            {
                return empty;
            }
            using (HtmlContainer container = new HtmlContainer())
            {
                container.Location = pointF_0;
                container.MaxSize = sizeF_0;
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;
                container.method_2(bool_0);
                if (eventHandler_0 != null)
                {
                    container.StylesheetLoad += eventHandler_0;
                }
                if (eventHandler_1 != null)
                {
                    container.ImageLoad += eventHandler_1;
                }
                container.SetHtml(string_0, cssData_0);
                container.PerformLayout(graphics_0);
                container.PerformPaint(graphics_0, null);
                return container.ActualSize;
            }
        }

        private static void smethod_3(IntPtr intptr_0, Image image_0)
        {
            using (Graphics graphics = Graphics.FromImage(image_0))
            {
                IntPtr hdc = graphics.GetHdc();
                DSkin.NativeMethods.BitBlt(hdc, 0, 0, image_0.Width, image_0.Height, intptr_0, 0, 0, 0xcc0020);
                graphics.ReleaseHdc(hdc);
            }
        }

        private static SizeF tduawadtRH(Graphics graphics_0, string string_0, float float_0, CssData cssData_0, bool bool_0, EventHandler<HtmlStylesheetLoadEventArgs> eventHandler_0, EventHandler<HtmlImageLoadEventArgs> eventHandler_1)
        {
            SizeF empty = SizeF.Empty;
            if (string.IsNullOrEmpty(string_0))
            {
                return empty;
            }
            using (HtmlContainer container = new HtmlContainer())
            {
                container.MaxSize = new SizeF(float_0, 0f);
                container.AvoidAsyncImagesLoading = true;
                container.AvoidImagesLateLoading = true;
                container.method_2(bool_0);
                if (eventHandler_0 != null)
                {
                    container.StylesheetLoad += eventHandler_0;
                }
                if (eventHandler_1 != null)
                {
                    container.ImageLoad += eventHandler_1;
                }
                container.SetHtml(string_0, cssData_0);
                container.PerformLayout(graphics_0);
                return container.ActualSize;
            }
        }
    }
}

