namespace DSkin.Html.Adapters
{
    using DSkin;
    using DSkin.Html;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;

    public sealed class GraphicsAdapter : RGraphics
    {
        private readonly bool bool_0;
        private readonly bool bool_1;
        private bool bool_2;
        private static readonly CharacterRange[] characterRange_0 = new CharacterRange[1];
        private readonly Graphics graphics_0;
        private static readonly int[] int_0 = new int[1];
        private static readonly int[] int_1 = new int[0x3e8];
        private IntPtr intptr_0;
        private static readonly StringFormat stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
        private static readonly StringFormat stringFormat_1;

        static GraphicsAdapter()
        {
            stringFormat_0.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.MeasureTrailingSpaces;
            stringFormat_1 = new StringFormat(StringFormat.GenericTypographic);
        }

        public GraphicsAdapter(Graphics g, bool useGdiPlusTextRendering, bool releaseGraphics = false) : base(WinFormsAdapter.Instance, Utils.Convert(g.ClipBounds))
        {
            ArgChecker.AssertArgNotNull(g, "g");
            this.graphics_0 = g;
            this.bool_1 = releaseGraphics;
            this.bool_0 = useGdiPlusTextRendering;
        }

        public override void Dispose()
        {
            this.method_0();
            if (this.bool_1)
            {
                this.graphics_0.Dispose();
            }
            if (this.bool_0 && this.bool_2)
            {
                stringFormat_1.FormatFlags ^= StringFormatFlags.DirectionRightToLeft;
            }
        }

        public override void DrawImage(RImage image, RRect destRect)
        {
            this.method_0();
            this.graphics_0.DrawImage(((ImageAdapter) image).Image, Utils.Convert(destRect));
        }

        public override void DrawImage(RImage image, RRect destRect, RRect srcRect)
        {
            this.method_0();
            this.graphics_0.DrawImage(((ImageAdapter) image).Image, Utils.Convert(destRect), Utils.Convert(srcRect), GraphicsUnit.Pixel);
        }

        public override void DrawLine(RPen pen, double x1, double y1, double x2, double y2)
        {
            this.method_0();
            this.graphics_0.DrawLine(((PenAdapter) pen).Pen, (float) x1, (float) y1, (float) x2, (float) y2);
        }

        public override void DrawPath(RBrush brush, RGraphicsPath path)
        {
            this.method_0();
            this.graphics_0.FillPath(((BrushAdapter) brush).Brush, ((GraphicsPathAdapter) path).GraphicsPath);
        }

        public override void DrawPath(RPen pen, RGraphicsPath path)
        {
            this.graphics_0.DrawPath(((PenAdapter) pen).Pen, ((GraphicsPathAdapter) path).GraphicsPath);
        }

        public override void DrawPolygon(RBrush brush, RPoint[] points)
        {
            if ((points != null) && (points.Length > 0))
            {
                this.method_0();
                this.graphics_0.FillPolygon(((BrushAdapter) brush).Brush, Utils.Convert(points));
            }
        }

        public override void DrawRectangle(RBrush brush, double x, double y, double width, double height)
        {
            this.method_0();
            this.graphics_0.FillRectangle(((BrushAdapter) brush).Brush, (float) x, (float) y, (float) width, (float) height);
        }

        public override void DrawRectangle(RPen pen, double x, double y, double width, double height)
        {
            this.method_0();
            this.graphics_0.DrawRectangle(((PenAdapter) pen).Pen, (float) x, (float) y, (float) width, (float) height);
        }

        public override void DrawString(string str, RFont font, RColor color, RPoint point, RSize size, bool rtl)
        {
            if (this.bool_0)
            {
                this.method_0();
                this.method_5(rtl);
                Brush brush = ((BrushAdapter) base._adapter.GetSolidBrush(color)).Brush;
                this.graphics_0.DrawString(str, ((FontAdapter) font).Font, brush, (float) ((int) (Math.Round(point.X) + (rtl ? size.Width : 0.0))), (float) ((int) Math.Round(point.Y)), stringFormat_1);
            }
            else
            {
                Point point2 = Utils.ConvertRound(point);
                Color color2 = Utils.Convert(color);
                if (color.A == 0xff)
                {
                    this.method_2(font);
                    this.method_3(color2);
                    this.method_4(rtl);
                    DSkin.NativeMethods.TextOutW(this.intptr_0, point2.X, point2.Y, str, str.Length);
                }
                else
                {
                    this.method_1();
                    this.method_4(rtl);
                    smethod_0(this.intptr_0, str, (FontAdapter) font, point2, Utils.ConvertRound(size), color2);
                }
            }
        }

        public override RGraphicsPath GetGraphicsPath()
        {
            return new GraphicsPathAdapter();
        }

        public override RBrush GetTextureBrush(RImage image, RRect dstRect, RPoint translateTransformLocation)
        {
            TextureBrush brush = new TextureBrush(((ImageAdapter) image).Image, Utils.Convert(dstRect));
            brush.TranslateTransform((float) translateTransformLocation.X, (float) translateTransformLocation.Y);
            return new BrushAdapter(brush, true);
        }

        public override RSize MeasureString(string str, RFont font)
        {
            if (this.bool_0)
            {
                this.method_0();
                FontAdapter adapter = (FontAdapter) font;
                Font font2 = adapter.Font;
                characterRange_0[0] = new CharacterRange(0, str.Length);
                stringFormat_0.SetMeasurableCharacterRanges(characterRange_0);
                SizeF s = this.graphics_0.MeasureCharacterRanges(str, font2, RectangleF.Empty, stringFormat_0)[0].GetBounds(this.graphics_0).Size;
                if (font.Height < 0.0)
                {
                    int height = font2.Height;
                    float num2 = (font2.Size * font2.FontFamily.GetCellDescent(font2.Style)) / ((float) font2.FontFamily.GetEmHeight(font2.Style));
                    adapter.method_0(height, (int) Math.Round((double) ((height - num2) + 0.5f)));
                }
                return Utils.Convert(s);
            }
            this.method_2(font);
            Size size = new Size();
            DSkin.NativeMethods.GetTextExtentPoint32W(this.intptr_0, str, str.Length, ref size);
            if (font.Height < 0.0)
            {
                DSkin.NativeMethods.TextMetric metric;
                DSkin.NativeMethods.GetTextMetrics(this.intptr_0, out metric);
                ((FontAdapter) font).method_0(size.Height, ((metric.tmHeight - metric.tmDescent) + metric.tmUnderlined) + 1);
            }
            return Utils.Convert((SizeF) size);
        }

        public override void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth)
        {
            charFit = 0;
            charFitWidth = 0.0;
            if (this.bool_0)
            {
                this.method_0();
                this.MeasureString(str, font);
                for (int i = 1; i <= str.Length; i++)
                {
                    RSize size = this.MeasureString(str.Substring(0, i), font);
                    if (size.Width >= maxWidth)
                    {
                        break;
                    }
                    charFit = i;
                    charFitWidth = size.Width;
                }
            }
            else
            {
                this.method_2(font);
                Size size2 = new Size();
                DSkin.NativeMethods.GetTextExtentExPointW(this.intptr_0, str, str.Length, (int) Math.Round(maxWidth), int_0, int_1, ref size2);
                charFit = int_0[0];
                charFitWidth = (charFit > 0) ? ((double) int_1[charFit - 1]) : ((double) 0);
            }
        }

        private void method_0()
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                DSkin.NativeMethods.SelectClipRgn(this.intptr_0, IntPtr.Zero);
                this.graphics_0.ReleaseHdc(this.intptr_0);
                this.intptr_0 = IntPtr.Zero;
            }
        }

        private void method_1()
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                IntPtr hrgn = this.graphics_0.Clip.GetHrgn(this.graphics_0);
                this.intptr_0 = this.graphics_0.GetHdc();
                this.bool_2 = false;
                DSkin.NativeMethods.SetBkMode(this.intptr_0, 1);
                DSkin.NativeMethods.SelectClipRgn(this.intptr_0, hrgn);
                DSkin.NativeMethods.DeleteObject(hrgn);
            }
        }

        private void method_2(RFont rfont_0)
        {
            this.method_1();
            DSkin.NativeMethods.SelectObject(this.intptr_0, ((FontAdapter) rfont_0).HFont);
        }

        private void method_3(Color color_0)
        {
            this.method_1();
            int crColor = (((color_0.B & 0xff) << 0x10) | ((color_0.G & 0xff) << 8)) | color_0.R;
            DSkin.NativeMethods.SetTextColor(this.intptr_0, crColor);
        }

        private void method_4(bool bool_3)
        {
            if (this.bool_2)
            {
                if (!bool_3)
                {
                    DSkin.NativeMethods.SetTextAlign(this.intptr_0, 0);
                }
            }
            else if (bool_3)
            {
                DSkin.NativeMethods.SetTextAlign(this.intptr_0, 0x100);
            }
            this.bool_2 = bool_3;
        }

        private void method_5(bool bool_3)
        {
            if (this.bool_2)
            {
                if (!bool_3)
                {
                    stringFormat_1.FormatFlags ^= StringFormatFlags.DirectionRightToLeft;
                }
            }
            else if (bool_3)
            {
                stringFormat_1.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            this.bool_2 = bool_3;
        }

        public override void PopClip()
        {
            this.method_0();
            base._clipStack.Pop();
            this.graphics_0.SetClip(Utils.Convert(base._clipStack.Peek()), CombineMode.Replace);
        }

        public override void PushClip(RRect rect)
        {
            this.method_0();
            base._clipStack.Push(rect);
            this.graphics_0.SetClip(Utils.Convert(rect), CombineMode.Replace);
        }

        public override void PushClipExclude(RRect rect)
        {
            this.method_0();
            base._clipStack.Push(base._clipStack.Peek());
            this.graphics_0.SetClip(Utils.Convert(rect), CombineMode.Exclude);
        }

        public override void ReturnPreviousSmoothingMode(object prevMode)
        {
            if (prevMode != null)
            {
                this.method_0();
                this.graphics_0.SmoothingMode = (SmoothingMode) prevMode;
            }
        }

        public override object SetAntiAliasSmoothingMode()
        {
            this.method_0();
            SmoothingMode smoothingMode = this.graphics_0.SmoothingMode;
            this.graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
            return smoothingMode;
        }

        private static void smethod_0(IntPtr intptr_1, string string_0, FontAdapter fontAdapter_0, Point point_0, Size size_0, Color color_0)
        {
            IntPtr ptr;
            IntPtr hDestDC = DSkin.NativeMethods.CreateMemoryHdc(intptr_1, size_0.Width, size_0.Height, out ptr);
            try
            {
                DSkin.NativeMethods.BitBlt(hDestDC, 0, 0, size_0.Width, size_0.Height, intptr_1, point_0.X, point_0.Y, 0xcc0020);
                DSkin.NativeMethods.SelectObject(hDestDC, fontAdapter_0.HFont);
                DSkin.NativeMethods.SetTextColor(hDestDC, (((color_0.B & 0xff) << 0x10) | ((color_0.G & 0xff) << 8)) | color_0.R);
                DSkin.NativeMethods.TextOutW(hDestDC, 0, 0, string_0, string_0.Length);
                DSkin.NativeMethods.GdiAlphaBlend(intptr_1, point_0.X, point_0.Y, size_0.Width, size_0.Height, hDestDC, 0, 0, size_0.Width, size_0.Height, new DSkin.NativeMethods.BLENDFUNCTION(color_0.A));
            }
            finally
            {
                DSkin.NativeMethods.ReleaseMemoryHdc(hDestDC, ptr);
            }
        }
    }
}

