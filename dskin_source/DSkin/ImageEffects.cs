namespace DSkin
{
    using DSkin.Common;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class ImageEffects
    {
        public static unsafe void Blocks(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    byte num5 = (byte) (((numPtr[0] + numPtr[1]) + numPtr[2]) / 3);
                    if (num5 > 0x80)
                    {
                        num5 = 0xff;
                    }
                    else
                    {
                        num5 = 0;
                    }
                    numPtr[0] = num5;
                    numPtr[1] = num5;
                    numPtr[2] = num5;
                    numPtr += 4;
                }
                numPtr += num3;
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static unsafe Bitmap Blocks(Image srcImage)
        {
            int height = srcImage.Height;
            int width = srcImage.Width;
            Bitmap bitmap = new Bitmap(srcImage);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    byte num6 = (byte) (((numPtr[0] + numPtr[1]) + numPtr[2]) / 3);
                    if (num6 > 0x80)
                    {
                        num6 = 0xff;
                    }
                    else
                    {
                        num6 = 0;
                    }
                    numPtr[0] = num6;
                    numPtr[1] = num6;
                    numPtr[2] = num6;
                    numPtr += 4;
                }
                numPtr += num3;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

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
            byte[] buffer2 = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, buffer2, 0, buffer2.Length);
            int index = 0;
            for (int i = 0; i != data.Height; i++)
            {
                index = (i * data.Stride) + 3;
                for (int j = 0; j != data.Width; j++)
                {
                    buffer2[index] = destination[index];
                    index += 4;
                }
            }
            Marshal.Copy(buffer2, 0, data.Scan0, buffer2.Length);
            image.UnlockBits(data);
            return image;
        }

        public static Image BrightnessChange(int percent, Image srcImage)
        {
            float num = 0.006f * percent;
            float[][] numArray = new float[5][];
            float[] numArray2 = new float[5];
            numArray2[0] = 1f;
            numArray[0] = numArray2;
            numArray2 = new float[5];
            numArray2[1] = 1f;
            numArray[1] = numArray2;
            numArray2 = new float[5];
            numArray2[2] = 1f;
            numArray[2] = numArray2;
            numArray2 = new float[5];
            numArray2[3] = 1f;
            numArray[3] = numArray2;
            numArray2 = new float[5];
            numArray2[0] = num;
            numArray2[1] = num;
            numArray2[2] = num;
            numArray2[4] = 1f;
            numArray[4] = numArray2;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            using (ImageAttributes attributes = new ImageAttributes())
            {
                attributes.SetColorMatrix(matrix);
                Bitmap image = new Bitmap(srcImage.Width, srcImage.Height);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    Rectangle destRect = new Rectangle(0, 0, image.Width, image.Height);
                    graphics.DrawImage(srcImage, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return image;
            }
        }

        public static ImageAttributes ChangeOpacity(float opacity)
        {
            float[][] numArray = new float[5][];
            float[] numArray2 = new float[5];
            numArray2[0] = 1f;
            numArray[0] = numArray2;
            numArray2 = new float[5];
            numArray2[1] = 1f;
            numArray[1] = numArray2;
            numArray2 = new float[5];
            numArray2[2] = 1f;
            numArray[2] = numArray2;
            numArray2 = new float[5];
            numArray2[3] = opacity;
            numArray[3] = numArray2;
            numArray2 = new float[5];
            numArray2[4] = 1f;
            numArray[4] = numArray2;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return attributes;
        }

        public static Bitmap ChangeOpacity(Bitmap srcImage, float opacity)
        {
            if (opacity == 1f)
            {
                return new Bitmap(srcImage);
            }
            if (opacity == 0f)
            {
                return new Bitmap(srcImage.Width, srcImage.Height);
            }
            float[][] numArray = new float[5][];
            float[] numArray2 = new float[5];
            numArray2[0] = 1f;
            numArray[0] = numArray2;
            numArray2 = new float[5];
            numArray2[1] = 1f;
            numArray[1] = numArray2;
            numArray2 = new float[5];
            numArray2[2] = 1f;
            numArray[2] = numArray2;
            numArray2 = new float[5];
            numArray2[3] = opacity;
            numArray[3] = numArray2;
            numArray2 = new float[5];
            numArray2[4] = 1f;
            numArray[4] = numArray2;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap image = new Bitmap(srcImage.Width, srcImage.Height);
            Graphics.FromImage(image).DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, imageAttr);
            return image;
        }

        public static void ChangeOpacity(float opacity, ImageAttributes imageAttributes)
        {
            float[][] numArray = new float[5][];
            float[] numArray2 = new float[5];
            numArray2[0] = 1f;
            numArray[0] = numArray2;
            numArray2 = new float[5];
            numArray2[1] = 1f;
            numArray[1] = numArray2;
            numArray2 = new float[5];
            numArray2[2] = 1f;
            numArray[2] = numArray2;
            numArray2 = new float[5];
            numArray2[3] = opacity;
            numArray[3] = numArray2;
            numArray2 = new float[5];
            numArray2[4] = 1f;
            numArray[4] = numArray2;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            imageAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        public static unsafe void ChangeOpacity(Bitmap bitmap, double opacity, Rectangle rect)
        {
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num = bitmapdata.Stride - (rect.Width * 4);
            for (int i = 0; i < rect.Height; i++)
            {
                for (int j = 0; j < rect.Width; j++)
                {
                    numPtr[3] = (byte) (numPtr[3] * opacity);
                    numPtr += 4;
                }
                numPtr += num;
            }
            bitmap.UnlockBits(bitmapdata);
        }

        public static void DrawLightString(string text, Graphics g, Font font, Color light, Color color, Rectangle rect, StringFormat sf, int lightWidth)
        {
            if (!string.IsNullOrEmpty(text))
            {
                GraphicsUnit pageUnit = g.PageUnit;
                SmoothingMode smoothingMode = g.SmoothingMode;
                InterpolationMode interpolationMode = g.InterpolationMode;
                using (GraphicsPath path = new GraphicsPath())
                {
                    g.PageUnit = GraphicsUnit.Point;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    path.AddString(text, font.FontFamily, (int) font.Style, font.SizeInPoints, rect, sf);
                    if (lightWidth > 0)
                    {
                        using (Bitmap bitmap = new Bitmap(rect.Width / lightWidth, rect.Height / lightWidth))
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                Matrix matrix = new Matrix(1f / ((float) lightWidth), 0f, 0f, 1f / ((float) lightWidth), -1f / ((float) lightWidth), -1f / ((float) lightWidth));
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.Transform = matrix;
                                using (Pen pen = new Pen(light, (float) lightWidth))
                                {
                                    graphics.DrawPath(pen, path);
                                }
                            }
                            g.DrawImage(bitmap, new Rectangle(1, 0, rect.Width, rect.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
                        }
                    }
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        if (lightWidth > 0)
                        {
                            g.FillPath(brush, path);
                        }
                        else
                        {
                            g.DrawString(text, font, brush, rect, sf);
                        }
                    }
                    g.PageUnit = pageUnit;
                    g.SmoothingMode = smoothingMode;
                    g.InterpolationMode = interpolationMode;
                }
            }
        }

        public static void DrawLightString(string text, Graphics g, Font font, Color color, Color light, Rectangle rect, StringFormat sf, int lightWidth, TextRenderingHint textRender)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SolidBrush brush;
                TextRenderingHint textRenderingHint = g.TextRenderingHint;
                g.TextRenderingHint = textRender;
                using (brush = new SolidBrush(Color.FromArgb(20, light)))
                {
                    for (int i = 0; i < lightWidth; i++)
                    {
                        for (int j = 0; j < lightWidth; j++)
                        {
                            g.DrawString(text, font, brush, new RectangleF((float) ((rect.X + i) - (lightWidth / 2)), (float) ((rect.Y + j) - (lightWidth / 2)), (float) rect.Width, (float) rect.Height), sf);
                        }
                    }
                }
                using (brush = new SolidBrush(Color.FromArgb((color.A == 0xff) ? 0xfe : color.A, color)))
                {
                    g.DrawString(text, font, brush, rect, sf);
                }
                g.TextRenderingHint = textRenderingHint;
            }
        }

        public static unsafe Bitmap FrostedEffect(Bitmap srcBmp, int minRadius, int maxRadius, int samples)
        {
            int width = srcBmp.Width;
            int height = srcBmp.Height;
            Bitmap bitmap = new Bitmap(width, height, srcBmp.PixelFormat);
            BitmapData bitmapdata = srcBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, srcBmp.PixelFormat);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            int num3 = Image.GetPixelFormatSize(srcBmp.PixelFormat) / 8;
            bool flag = Image.IsAlphaPixelFormat(srcBmp.PixelFormat);
            int num1 = bitmapdata.Stride - (bitmapdata.Width * num3);
            Random random = new Random();
            Color[] colorArray = new Color[samples];
            byte* numPtr = (byte*) bitmapdata.Scan0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < samples; k++)
                    {
                        double num6 = random.Next(minRadius, maxRadius);
                        double a = (random.NextDouble() * 3.1415926535897931) * 2.0;
                        Math.Sin(a);
                        int num8 = i + ((int) (Math.Sin(a) * num6));
                        int num10 = j + ((int) (Math.Cos(a) * num6));
                        num8 = (num8 < 0) ? 0 : ((num8 > (height - 1)) ? (height - 1) : num8);
                        num10 = (num10 < 0) ? 0 : ((num10 > width) ? width : num10);
                        byte* numPtr3 = (numPtr + (num8 * bitmapdata.Stride)) + (num10 * num3);
                        if (flag)
                        {
                            colorArray[k] = Color.FromArgb(numPtr3[3], numPtr3[2], numPtr3[1], numPtr3[0]);
                        }
                        else
                        {
                            colorArray[k] = Color.FromArgb(numPtr3[2], numPtr3[1], numPtr3[0]);
                        }
                    }
                    Color color = smethod_0(colorArray);
                    byte* numPtr2 = (byte*) ((((void*) data2.Scan0) + (bitmapdata.Stride * i)) + (j * num3));
                    numPtr2[0] = color.B;
                    numPtr2[1] = color.G;
                    numPtr2[2] = color.R;
                    if (flag)
                    {
                        numPtr2[3] = color.A;
                    }
                }
            }
            srcBmp.UnlockBits(bitmapdata);
            bitmap.UnlockBits(data2);
            return bitmap;
        }

        public static Bitmap GaussianBlur(Bitmap bmp, int amount)
        {
            return GaussianBlur(bmp, amount, new Rectangle(0, 0, bmp.Width, bmp.Height));
        }

        public static unsafe Bitmap GaussianBlur(Bitmap bmp, int amount, Rectangle rect)
        {
            Bitmap originBitmap = new Bitmap(bmp.Width, bmp.Height);
            int[] numArray = smethod_1(amount);
            int length = numArray.Length;
            if ((rect.Height >= 1) && (rect.Width >= 1))
            {
                using (RawBitmap bitmap3 = new RawBitmap(bmp))
                {
                    using (RawBitmap bitmap2 = new RawBitmap(originBitmap))
                    {
                        for (int i = rect.Top; i < rect.Bottom; i++)
                        {
                            int num11;
                            int num13;
                            int num14;
                            int num15;
                            int num16;
                            int num17;
                            int num21;
                            byte* numPtr8;
                            int num22;
                            long* numPtr2 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long* numPtr3 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long* numPtr4 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long* numPtr5 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long* numPtr6 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long* numPtr7 = (long*) stackalloc byte[(((IntPtr) length) * 8)];
                            long num4 = 0L;
                            long num3 = 0L;
                            long num6 = 0L;
                            long num7 = 0L;
                            long num8 = 0L;
                            long num9 = 0L;
                            byte* numPtr = bitmap2[rect.Left, i];
                            int index = 0;
                            while (index < length)
                            {
                                num13 = (rect.Left + index) - amount;
                                numPtr2[index] = 0L;
                                numPtr3[index] = 0L;
                                numPtr4[index] = 0L;
                                numPtr5[index] = 0L;
                                numPtr6[index] = 0L;
                                numPtr7[index] = 0L;
                                if ((num13 >= 0) && (num13 < bitmap3.Width))
                                {
                                    num11 = 0;
                                    while (num11 < length)
                                    {
                                        num21 = (i + num11) - amount;
                                        if ((num21 >= 0) && (num21 < bitmap3.Height))
                                        {
                                            numPtr8 = bitmap3[num13, num21];
                                            num22 = numArray[num11];
                                            long* numPtr1 = numPtr2 + index;
                                            numPtr1[0] += num22;
                                            num22 *= numPtr8[3] + (numPtr8[3] >> 7);
                                            long* numPtr9 = numPtr3 + index;
                                            numPtr9[0] += num22;
                                            num22 = num22 >> 8;
                                            long* numPtr10 = numPtr4 + index;
                                            numPtr10[0] += num22 * numPtr8[3];
                                            long* numPtr11 = numPtr5 + index;
                                            numPtr11[0] += num22 * numPtr8[0];
                                            long* numPtr12 = numPtr6 + index;
                                            numPtr12[0] += num22 * numPtr8[1];
                                            long* numPtr13 = numPtr7 + index;
                                            numPtr13[0] += num22 * numPtr8[2];
                                        }
                                        num11++;
                                    }
                                    int num19 = numArray[index];
                                    num4 += num19 * numPtr2[index];
                                    num3 += num19 * numPtr3[index];
                                    num6 += num19 * numPtr4[index];
                                    num7 += num19 * numPtr5[index];
                                    num8 += num19 * numPtr6[index];
                                    num9 += num19 * numPtr7[index];
                                }
                                index++;
                            }
                            num3 = num3 >> 8;
                            if ((num4 == 0L) || (num3 == 0L))
                            {
                                numPtr[0] = 0;
                                numPtr[1] = 0;
                                numPtr[2] = 0;
                                numPtr[3] = 0;
                            }
                            else
                            {
                                num14 = (int) (num6 / num4);
                                num15 = (int) (num7 / num3);
                                num16 = (int) (num8 / num3);
                                num17 = (int) (num9 / num3);
                                numPtr[0] = (byte) num15;
                                numPtr[1] = (byte) num16;
                                numPtr[2] = (byte) num17;
                                numPtr[3] = (byte) num14;
                            }
                            numPtr += 4;
                            for (int j = rect.Left + 1; j < rect.Right; j++)
                            {
                                for (int k = 0; k < (length - 1); k++)
                                {
                                    numPtr2[k] = numPtr2[k + 1];
                                    numPtr3[k] = numPtr3[k + 1];
                                    numPtr4[k] = numPtr4[k + 1];
                                    numPtr5[k] = numPtr5[k + 1];
                                    numPtr6[k] = numPtr6[k + 1];
                                    numPtr7[k] = numPtr7[k + 1];
                                }
                                num4 = 0L;
                                num3 = 0L;
                                num6 = 0L;
                                num7 = 0L;
                                num8 = 0L;
                                num9 = 0L;
                                index = 0;
                                while (index < (length - 1))
                                {
                                    long num12 = numArray[index];
                                    num4 += num12 * numPtr2[index];
                                    num3 += num12 * numPtr3[index];
                                    num6 += num12 * numPtr4[index];
                                    num7 += num12 * numPtr5[index];
                                    num8 += num12 * numPtr6[index];
                                    num9 += num12 * numPtr7[index];
                                    index++;
                                }
                                index = length - 1;
                                numPtr2[index] = 0L;
                                numPtr3[index] = 0L;
                                numPtr4[index] = 0L;
                                numPtr5[index] = 0L;
                                numPtr6[index] = 0L;
                                numPtr7[index] = 0L;
                                num13 = (j + index) - amount;
                                if ((num13 >= 0) && (num13 < bitmap3.Width))
                                {
                                    for (num11 = 0; num11 < length; num11++)
                                    {
                                        num21 = (i + num11) - amount;
                                        if ((num21 >= 0) && (num21 < bitmap3.Height))
                                        {
                                            numPtr8 = bitmap3[num13, num21];
                                            num22 = numArray[num11];
                                            long* numPtr14 = numPtr2 + index;
                                            numPtr14[0] += num22;
                                            num22 *= numPtr8[3] + (numPtr8[3] >> 7);
                                            long* numPtr15 = numPtr3 + index;
                                            numPtr15[0] += num22;
                                            num22 = num22 >> 8;
                                            long* numPtr16 = numPtr4 + index;
                                            numPtr16[0] = (long) (((ulong) numPtr16[0]) + (num22 * numPtr8[3]));
                                            long* numPtr17 = numPtr5 + index;
                                            numPtr17[0] = (long) (((ulong) numPtr17[0]) + (num22 * numPtr8[0]));
                                            long* numPtr18 = numPtr6 + index;
                                            numPtr18[0] = (long) (((ulong) numPtr18[0]) + (num22 * numPtr8[1]));
                                            long* numPtr19 = numPtr7 + index;
                                            numPtr19[0] = (long) (((ulong) numPtr19[0]) + (num22 * numPtr8[2]));
                                        }
                                    }
                                    int num20 = numArray[index];
                                    num4 += num20 * numPtr2[index];
                                    num3 += num20 * numPtr3[index];
                                    num6 += num20 * numPtr4[index];
                                    num7 += num20 * numPtr5[index];
                                    num8 += num20 * numPtr6[index];
                                    num9 += num20 * numPtr7[index];
                                }
                                num3 = num3 >> 8;
                                if ((num4 == 0L) || (num3 == 0L))
                                {
                                    numPtr[0] = 0;
                                    numPtr[1] = 0;
                                    numPtr[2] = 0;
                                    numPtr[3] = 0;
                                }
                                else
                                {
                                    num14 = (int) (num6 / num4);
                                    num15 = (int) (num7 / num3);
                                    num16 = (int) (num8 / num3);
                                    num17 = (int) (num9 / num3);
                                    numPtr[0] = (byte) num15;
                                    numPtr[1] = (byte) num16;
                                    numPtr[2] = (byte) num17;
                                    numPtr[3] = (byte) num14;
                                }
                                numPtr += 4;
                            }
                        }
                    }
                }
            }
            return originBitmap;
        }

        public static void GaussianBlur(Bitmap Bmp, ref Rectangle Rect, float Radius = 10f, bool ExpandEdge = false)
        {
            DSkin.NativeMethods.BlurParameters parameters;
            IntPtr ptr2;
            if ((Radius < 0f) || (Radius > 255f))
            {
                throw new ArgumentOutOfRangeException("半径必须在[0,255]范围内");
            }
            parameters.Radius = Radius;
            parameters.ExpandEdges = ExpandEdge;
            if (DSkin.NativeMethods.GdipCreateEffect(DSkin.NativeMethods.BlurEffectGuid, out ptr2) != 0)
            {
                throw new ExternalException("不支持的GDI+版本，必须为GDI+1.1及以上版本，且操作系统要求为Win Vista及之后版本.");
            }
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(parameters));
            Marshal.StructureToPtr(parameters, ptr, true);
            DSkin.NativeMethods.GdipSetEffectParameters(ptr2, ptr, (uint) Marshal.SizeOf(parameters));
            DSkin.NativeMethods.GdipBitmapApplyEffect(NativeHandle(Bmp), ptr2, ref Rect, false, IntPtr.Zero, 0);
            DSkin.NativeMethods.GdipDeleteEffect(ptr2);
            Marshal.FreeHGlobal(ptr);
        }

        public static TResult GetPrivateField<TResult>(object obj, string fieldName)
        {
            if (obj == null)
            {
                return default(TResult);
            }
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new InvalidOperationException(string.Format("Instance field '{0}' could not be located in object of type '{1}'.", fieldName, obj.GetType().FullName));
            }
            return (TResult) field.GetValue(obj);
        }

        public static unsafe Image GradualAlpha(Image srcImage, Rectangle rect, int direction)
        {
            Bitmap bitmap = new Bitmap(srcImage);
            double num = 1.0;
            BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num2 = bitmapdata.Stride - (rect.Width * 4);
            for (int i = 0; i < rect.Height; i++)
            {
                if (direction == 0)
                {
                    num = (1.0 * i) / ((double) (rect.Height - 1));
                }
                else if (direction == 1)
                {
                    num = 1.0 - ((1.0 * i) / ((double) (rect.Height - 1)));
                }
                for (int j = 0; j < rect.Width; j++)
                {
                    if (direction == 2)
                    {
                        num = (1.0 * j) / ((double) (rect.Width - 1));
                    }
                    else if (direction == 3)
                    {
                        num = 1.0 - ((1.0 * j) / ((double) (rect.Width - 1)));
                    }
                    numPtr[3] = (byte) (numPtr[3] * num);
                    numPtr += 4;
                }
                numPtr += num2;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static unsafe void GradualAlpha(Rectangle rect, int direction, Bitmap srcImage)
        {
            double num = 1.0;
            BitmapData bitmapdata = srcImage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num2 = bitmapdata.Stride - (rect.Width * 4);
            for (int i = 0; i < rect.Height; i++)
            {
                if (direction == 0)
                {
                    num = (1.0 * i) / ((double) (rect.Height - 1));
                }
                else if (direction == 1)
                {
                    num = 1.0 - ((1.0 * i) / ((double) (rect.Height - 1)));
                }
                for (int j = 0; j < rect.Width; j++)
                {
                    if (direction == 2)
                    {
                        num = (1.0 * j) / ((double) (rect.Width - 1));
                    }
                    else if (direction == 3)
                    {
                        num = 1.0 - ((1.0 * j) / ((double) (rect.Width - 1)));
                    }
                    numPtr[3] = (byte) (numPtr[3] * num);
                    numPtr += 4;
                }
                numPtr += num2;
            }
            srcImage.UnlockBits(bitmapdata);
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration, Rectangle rc, bool auto)
        {
            Bitmap image = null;
            StringFormat format = new StringFormat {
                Trimming = auto ? StringTrimming.EllipsisWord : StringTrimming.None,
                LineAlignment = StringAlignment.Center
            };
            using (Graphics.FromHwnd(IntPtr.Zero))
            {
                using (Bitmap bitmap2 = new Bitmap(rc.Width, rc.Height))
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
                                image = new Bitmap(bitmap2.Width, bitmap2.Height);
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

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration, Rectangle rc, StringFormat sf, TextRenderingHint textRender)
        {
            Bitmap image = null;
            using (Bitmap bitmap2 = new Bitmap(rc.Width, rc.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap2))
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                    {
                        using (SolidBrush brush2 = new SolidBrush(ColorFore))
                        {
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                            graphics.DrawString(Str, F, brush, rc, sf);
                            image = new Bitmap(bitmap2.Width, bitmap2.Height);
                            using (Graphics graphics2 = Graphics.FromImage(image))
                            {
                                if (ColorBack != Color.Transparent)
                                {
                                    graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                    graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                    graphics2.TextRenderingHint = textRender;
                                    for (int i = 0; i <= BlurConsideration; i++)
                                    {
                                        for (int j = 0; j <= BlurConsideration; j++)
                                        {
                                            graphics2.DrawImageUnscaled(bitmap2, i, j);
                                        }
                                    }
                                }
                                graphics2.DrawString(Str, F, brush2, new Rectangle(new Point(Convert.ToInt32((int) (BlurConsideration / 2)) + rc.X, Convert.ToInt32((int) (BlurConsideration / 2)) + rc.Y), rc.Size), sf);
                            }
                            return image;
                        }
                    }
                }
            }
        }

        public static unsafe Bitmap KiContrast(Image srcImage, int degree)
        {
            int height = srcImage.Height;
            int width = srcImage.Width;
            Bitmap bitmap = new Bitmap(srcImage);
            if (degree < -100)
            {
                degree = -100;
            }
            if (degree > 100)
            {
                degree = 100;
            }
            try
            {
                double num3 = 0.0;
                double num4 = (100.0 + degree) / 100.0;
                num4 *= num4;
                BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* numPtr = (byte*) bitmapdata.Scan0;
                int num5 = bitmapdata.Stride - (width * 3);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            num3 = ((((((double) numPtr[k]) / 255.0) - 0.5) * num4) + 0.5) * 255.0;
                            if (num3 < 0.0)
                            {
                                num3 = 0.0;
                            }
                            if (num3 > 255.0)
                            {
                                num3 = 255.0;
                            }
                            numPtr[k] = (byte) num3;
                        }
                        numPtr += 3;
                    }
                    numPtr += num5;
                }
                bitmap.UnlockBits(bitmapdata);
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        public static unsafe void MaSaiKe(Bitmap bmp, int val)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0xff;
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i % val) == 0)
                    {
                        if ((j % val) == 0)
                        {
                            num6 = numPtr[3];
                            num3 = numPtr[2];
                            num4 = numPtr[1];
                            num5 = numPtr[0];
                        }
                        else
                        {
                            numPtr[0] = (byte) num5;
                            numPtr[1] = (byte) num4;
                            numPtr[2] = (byte) num3;
                            numPtr[3] = (byte) num6;
                        }
                    }
                    else
                    {
                        byte* numPtr2 = numPtr - bitmapdata.Stride;
                        numPtr[0] = numPtr2[0];
                        numPtr[1] = numPtr2[1];
                        numPtr[2] = numPtr2[2];
                        numPtr[3] = numPtr2[3];
                    }
                    numPtr += 4;
                }
                numPtr += bitmapdata.Stride - (width * 4);
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static unsafe Image MaSaiKe(Image m_PreImage, int val)
        {
            Bitmap bitmap = new Bitmap(m_PreImage);
            int width = bitmap.Width;
            int height = bitmap.Height;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0xff;
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i % val) == 0)
                    {
                        if ((j % val) == 0)
                        {
                            num6 = numPtr[3];
                            num3 = numPtr[2];
                            num4 = numPtr[1];
                            num5 = numPtr[0];
                        }
                        else
                        {
                            numPtr[0] = (byte) num5;
                            numPtr[1] = (byte) num4;
                            numPtr[2] = (byte) num3;
                            numPtr[3] = (byte) num6;
                        }
                    }
                    else
                    {
                        byte* numPtr2 = numPtr - bitmapdata.Stride;
                        numPtr[0] = numPtr2[0];
                        numPtr[1] = numPtr2[1];
                        numPtr[2] = numPtr2[2];
                        numPtr[3] = numPtr2[3];
                    }
                    numPtr += 4;
                }
                numPtr += bitmapdata.Stride - (width * 4);
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static IntPtr NativeHandle(Bitmap Bmp)
        {
            return GetPrivateField<IntPtr>(Bmp, "nativeImage");
        }

        public static unsafe void NegativeImage(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        numPtr[k] = (byte) (0xff - numPtr[k]);
                    }
                    numPtr += 4;
                }
                numPtr += num3;
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static unsafe Image NegativeImage(Image srcImage)
        {
            int height = srcImage.Height;
            int width = srcImage.Width;
            Bitmap bitmap = new Bitmap(srcImage);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        numPtr[k] = (byte) (0xff - numPtr[k]);
                    }
                    numPtr += 4;
                }
                numPtr += num3;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static unsafe void Relief(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 3);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num5 = 0;
                    int num6 = 0;
                    int num7 = 0;
                    if ((j < (width - 1)) && (i < (height - 1)))
                    {
                        num5 = Math.Abs((int) ((numPtr[0] - numPtr[3 * (width + 1)]) + 0x80));
                        num6 = Math.Abs((int) ((numPtr[1] - numPtr[(3 * (width + 1)) + 1]) + 0x80));
                        num7 = Math.Abs((int) ((numPtr[2] - numPtr[(3 * (width + 1)) + 2]) + 0x80));
                    }
                    else
                    {
                        num5 = 0x80;
                        num6 = 0x80;
                        num7 = 0x80;
                    }
                    if (num5 > 0xff)
                    {
                        num5 = 0xff;
                    }
                    if (num5 < 0)
                    {
                        num5 = 0;
                    }
                    if (num6 > 0xff)
                    {
                        num6 = 0xff;
                    }
                    if (num6 < 0)
                    {
                        num6 = 0;
                    }
                    if (num7 > 0xff)
                    {
                        num7 = 0xff;
                    }
                    if (num7 < 0)
                    {
                        num7 = 0;
                    }
                    numPtr[0] = (byte) num5;
                    numPtr[1] = (byte) num6;
                    numPtr[2] = (byte) num7;
                    numPtr += 3;
                }
                numPtr += num3;
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static unsafe Bitmap Relief(Image srcImage)
        {
            int height = srcImage.Height;
            int width = srcImage.Width;
            Bitmap bitmap = new Bitmap(srcImage);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num3 = bitmapdata.Stride - (width * 3);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num6 = 0;
                    int num5 = 0;
                    int num7 = 0;
                    if ((j < (width - 1)) && (i < (height - 1)))
                    {
                        num6 = Math.Abs((int) ((numPtr[0] - numPtr[3 * (width + 1)]) + 0x80));
                        num5 = Math.Abs((int) ((numPtr[1] - numPtr[(3 * (width + 1)) + 1]) + 0x80));
                        num7 = Math.Abs((int) ((numPtr[2] - numPtr[(3 * (width + 1)) + 2]) + 0x80));
                    }
                    else
                    {
                        num6 = 0x80;
                        num5 = 0x80;
                        num7 = 0x80;
                    }
                    if (num6 > 0xff)
                    {
                        num6 = 0xff;
                    }
                    if (num6 < 0)
                    {
                        num6 = 0;
                    }
                    if (num5 > 0xff)
                    {
                        num5 = 0xff;
                    }
                    if (num5 < 0)
                    {
                        num5 = 0;
                    }
                    if (num7 > 0xff)
                    {
                        num7 = 0xff;
                    }
                    if (num7 < 0)
                    {
                        num7 = 0;
                    }
                    numPtr[0] = (byte) num6;
                    numPtr[1] = (byte) num5;
                    numPtr[2] = (byte) num7;
                    numPtr += 3;
                }
                numPtr += num3;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static Image RotateImage(Image srcImage, float angle, Point center)
        {
            Bitmap bitmap;
            Bitmap bitmap2;
            Graphics graphics;
            if (srcImage.Width > srcImage.Height)
            {
                bitmap = new Bitmap(srcImage.Width, srcImage.Width);
                bitmap2 = new Bitmap(srcImage.Width, srcImage.Width);
            }
            else
            {
                bitmap = new Bitmap(srcImage.Height, srcImage.Height);
                bitmap2 = new Bitmap(srcImage.Height, srcImage.Height);
            }
            using (graphics = Graphics.FromImage(bitmap2))
            {
                graphics.DrawImage(srcImage, (int) ((bitmap.Width - srcImage.Width) / 2), (int) ((bitmap.Height - srcImage.Height) / 2));
            }
            using (graphics = Graphics.FromImage(bitmap))
            {
                graphics.TranslateTransform((float) center.X, (float) center.Y);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform((float) -center.X, (float) -center.Y);
                graphics.DrawImage(bitmap2, 0, 0);
                graphics.ResetTransform();
                graphics.Save();
            }
            bitmap2.Dispose();
            return bitmap;
        }

        public static unsafe void SingleColor(Bitmap bmp)
        {
            int height = bmp.Height;
            int width = bmp.Width;
            int num3 = 0;
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num4 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    num3 = (((int) (0.7 * numPtr[0])) + ((int) (0.2 * numPtr[1]))) + ((int) (0.1 * numPtr[2]));
                    num3 = Math.Min(0xff, num3);
                    numPtr[0] = (byte) num3;
                    numPtr[1] = (byte) num3;
                    numPtr[2] = (byte) num3;
                    numPtr += 4;
                }
                numPtr += num4;
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static unsafe Bitmap SingleColor(Image srcImage)
        {
            int height = srcImage.Height;
            int width = srcImage.Width;
            Bitmap bitmap = new Bitmap(srcImage);
            int num3 = 0;
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* numPtr = (byte*) bitmapdata.Scan0;
            int num4 = bitmapdata.Stride - (width * 4);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    num3 = (((int) (0.7 * numPtr[0])) + ((int) (0.2 * numPtr[1]))) + ((int) (0.1 * numPtr[2]));
                    num3 = Math.Min(0xff, num3);
                    numPtr[0] = (byte) num3;
                    numPtr[1] = (byte) num3;
                    numPtr[2] = (byte) num3;
                    numPtr += 4;
                }
                numPtr += num4;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        private static Color smethod_0(object object_0)
        {
            if (object_0.Length <= 0)
            {
                return Color.Transparent;
            }
            ulong num = 0L;
            ulong num3 = 0L;
            ulong num4 = 0L;
            ulong num5 = 0L;
            int index = 0;
            int length = object_0.Length;
            while (index < length)
            {
                num += object_0[index].A;
                num3 += object_0[index].A * object_0[index].R;
                num4 += object_0[index].G * object_0[index].A;
                num5 += object_0[index].B * object_0[index].A;
                index++;
            }
            if (num == 0L)
            {
                return Color.Transparent;
            }
            num3 /= num;
            num4 /= num;
            num5 /= num;
            num /= (long) object_0.Length;
            return Color.FromArgb((int) num, (int) num3, (int) num4, (int) num5);
        }

        private static int[] smethod_1(int int_0)
        {
            int num = 1 + (int_0 * 2);
            int[] numArray = new int[num];
            for (int i = 0; i <= int_0; i++)
            {
                numArray[i] = 0x10 * (i + 1);
                numArray[(numArray.Length - i) - 1] = numArray[i];
            }
            return numArray;
        }

        public static unsafe Bitmap TrapezoidTransformation(Bitmap src, double compressH, double compressW, bool isLeft, bool isCenter)
        {
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height))
            {
                int num4;
                int num6;
                Bitmap bitmap2 = new Bitmap(rect.Width, rect.Height);
                BitmapData bitmapdata = src.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                BitmapData data2 = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                BitmapData data3 = bitmap2.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                int num = 0;
                byte* numPtr = (byte*) bitmapdata.Scan0;
                byte* numPtr2 = (byte*) data2.Scan0;
                byte* numPtr3 = (byte*) data3.Scan0;
                int stride = bitmapdata.Stride;
                double num3 = (((1.0 - compressH) * rect.Height) / 2.0) / ((double) rect.Width);
                for (num4 = 0; num4 < rect.Height; num4++)
                {
                    num6 = 0;
                    while (num6 < rect.Width)
                    {
                        double num7 = 0.0;
                        double num8 = 0.0;
                        if (isLeft && (num4 >= (num3 * (rect.Width - num6))))
                        {
                            num7 = rect.Height - ((2.0 * num3) * (rect.Width - num6));
                            num8 = num4 - (num3 * (rect.Width - num6));
                        }
                        else if (!(isLeft || (num4 < (num3 * num6))))
                        {
                            num7 = rect.Height - ((2.0 * num3) * num6);
                            num8 = num4 - (num3 * num6);
                        }
                        double num10 = (1.0 * num8) / num7;
                        int num5 = (int) (rect.Height * num10);
                        if ((num5 < rect.Height) && (num5 > -1))
                        {
                            byte* numPtr4 = (numPtr + (num5 * stride)) + (num6 * 4);
                            numPtr2[0] = numPtr4[0];
                            numPtr2[1] = numPtr4[1];
                            numPtr2[2] = numPtr4[2];
                            numPtr2[3] = numPtr4[3];
                        }
                        numPtr2 += 4;
                        num6++;
                    }
                }
                numPtr2 = (byte*) data2.Scan0;
                if (isCenter)
                {
                    num = (int) ((rect.Width - (compressW * rect.Width)) / 2.0);
                }
                for (num4 = 0; num4 < rect.Height; num4++)
                {
                    for (num6 = 0; num6 < rect.Width; num6++)
                    {
                        int num9 = (int) ((1.0 * num6) / compressW);
                        if ((num9 > -1) && (num9 < rect.Width))
                        {
                            byte* numPtr5 = (numPtr2 + (num9 * 4)) + (stride * num4);
                            byte* numPtr6 = numPtr3 + (num * 4);
                            numPtr6[0] = numPtr5[0];
                            numPtr6[1] = numPtr5[1];
                            numPtr6[2] = numPtr5[2];
                            numPtr6[3] = numPtr5[3];
                        }
                        numPtr3 += 4;
                    }
                }
                src.UnlockBits(bitmapdata);
                bitmap.UnlockBits(data2);
                bitmap2.UnlockBits(data3);
                return bitmap2;
            }
        }

        public static ImageAttributes GrayImageAttributes
        {
            get
            {
                ImageAttributes attributes = new ImageAttributes();
                float[][] newColorMatrix = new float[5][];
                newColorMatrix[0] = new float[] { 0.3f, 0.3f, 0.3f, 0f, 0f };
                newColorMatrix[1] = new float[] { 0.59f, 0.59f, 0.59f, 0f, 0f };
                newColorMatrix[2] = new float[] { 0.11f, 0.11f, 0.11f, 0f, 0f };
                float[] numArray2 = new float[5];
                numArray2[3] = 1f;
                newColorMatrix[3] = numArray2;
                numArray2 = new float[5];
                numArray2[4] = 1f;
                newColorMatrix[4] = numArray2;
                ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                attributes.SetColorMatrix(matrix);
                return attributes;
            }
        }
    }
}

