using DSkin.Common;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class Class8
{
    [DllImport("gdi32.dll")]
    private static extern uint SetPixel(IntPtr intptr_0, int int_0, int int_1, int int_2);
    internal static void smethod_0(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, Color color_2, RoundStyle roundStyle_0, bool bool_0, bool bool_1, LinearGradientMode linearGradientMode_0)
    {
        smethod_1(graphics_0, rectangle_0, color_0, color_1, color_2, roundStyle_0, 8, bool_0, bool_1, linearGradientMode_0);
    }

    internal static void smethod_1(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, Color color_2, RoundStyle roundStyle_0, int int_0, bool bool_0, bool bool_1, LinearGradientMode linearGradientMode_0)
    {
        smethod_2(graphics_0, rectangle_0, color_0, color_1, color_2, roundStyle_0, 8, 0.45f, bool_0, bool_1, linearGradientMode_0);
    }

    internal static void smethod_2(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, Color color_2, RoundStyle roundStyle_0, int int_0, float float_0, bool bool_0, bool bool_1, LinearGradientMode linearGradientMode_0)
    {
        if (bool_0)
        {
            rectangle_0.Width--;
            rectangle_0.Height--;
        }
        if ((rectangle_0.Width != 0) && (rectangle_0.Height != 0))
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(rectangle_0, Color.Transparent, Color.Transparent, linearGradientMode_0))
            {
                Rectangle rectangle;
                SolidBrush brush2;
                RectangleF ef;
                Pen pen;
                Color[] colorArray = new Color[] { smethod_6(color_0, 0, 0x23, 0x18, 9), smethod_6(color_0, 0, 13, 8, 3), color_0, smethod_6(color_0, 0, 0x23, 0x18, 9) };
                ColorBlend blend = new ColorBlend();
                float[] numArray = new float[4];
                numArray[1] = float_0;
                numArray[2] = float_0 + 0.05f;
                numArray[3] = 1f;
                blend.Positions = numArray;
                blend.Colors = colorArray;
                brush.InterpolationColors = blend;
                if (roundStyle_0 != RoundStyle.None)
                {
                    GraphicsPath path;
                    using (path = GraphicsPathHelper.CreatePath(rectangle_0, int_0, roundStyle_0, false))
                    {
                        graphics_0.FillPath(brush, path);
                    }
                    if (color_0.A > 80)
                    {
                        rectangle = rectangle_0;
                        if (linearGradientMode_0 == LinearGradientMode.Vertical)
                        {
                            rectangle.Height = (int) (rectangle.Height * float_0);
                        }
                        else
                        {
                            rectangle.Width = (int) (rectangle_0.Width * float_0);
                        }
                        using (GraphicsPath path2 = GraphicsPathHelper.CreatePath(rectangle, int_0, RoundStyle.Top, false))
                        {
                            using (brush2 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0xff)))
                            {
                                graphics_0.FillPath(brush2, path2);
                            }
                        }
                    }
                    if (bool_1)
                    {
                        ef = rectangle_0;
                        if (linearGradientMode_0 == LinearGradientMode.Vertical)
                        {
                            ef.Y = rectangle_0.Y + (rectangle_0.Height * float_0);
                            ef.Height = (rectangle_0.Height - (rectangle_0.Height * float_0)) * 2f;
                        }
                        else
                        {
                            ef.X = rectangle_0.X + (rectangle_0.Width * float_0);
                            ef.Width = (rectangle_0.Width - (rectangle_0.Width * float_0)) * 2f;
                        }
                        ControlPaintEx.DrawGlass(graphics_0, ef, 170, 0);
                    }
                    if (!bool_0)
                    {
                        return;
                    }
                    using (path = GraphicsPathHelper.CreatePath(rectangle_0, int_0, roundStyle_0, false))
                    {
                        using (pen = new Pen(color_1))
                        {
                            graphics_0.DrawPath(pen, path);
                        }
                    }
                    rectangle_0.Inflate(-1, -1);
                    using (path = GraphicsPathHelper.CreatePath(rectangle_0, int_0, roundStyle_0, false))
                    {
                        using (pen = new Pen(color_2))
                        {
                            graphics_0.DrawPath(pen, path);
                        }
                        return;
                    }
                }
                graphics_0.FillRectangle(brush, rectangle_0);
                if (color_0.A > 80)
                {
                    rectangle = rectangle_0;
                    if (linearGradientMode_0 == LinearGradientMode.Vertical)
                    {
                        rectangle.Height = (int) (rectangle.Height * float_0);
                    }
                    else
                    {
                        rectangle.Width = (int) (rectangle_0.Width * float_0);
                    }
                    using (brush2 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0xff)))
                    {
                        graphics_0.FillRectangle(brush2, rectangle);
                    }
                }
                if (bool_1)
                {
                    ef = rectangle_0;
                    if (linearGradientMode_0 == LinearGradientMode.Vertical)
                    {
                        ef.Y = rectangle_0.Y + (rectangle_0.Height * float_0);
                        ef.Height = (rectangle_0.Height - (rectangle_0.Height * float_0)) * 2f;
                    }
                    else
                    {
                        ef.X = rectangle_0.X + (rectangle_0.Width * float_0);
                        ef.Width = (rectangle_0.Width - (rectangle_0.Width * float_0)) * 2f;
                    }
                    ControlPaintEx.DrawGlass(graphics_0, ef, 200, 0);
                }
                if (bool_0)
                {
                    using (pen = new Pen(color_1))
                    {
                        graphics_0.DrawRectangle(pen, rectangle_0);
                    }
                    rectangle_0.Inflate(-1, -1);
                    using (pen = new Pen(color_2))
                    {
                        graphics_0.DrawRectangle(pen, rectangle_0);
                    }
                }
            }
        }
    }

    internal static void smethod_3(Graphics graphics_0, Rectangle rectangle_0, ArrowDirection arrowDirection_0, Brush brush_0)
    {
        Point[] pointArray2;
        Point point = new Point(rectangle_0.Left + (rectangle_0.Width / 2), rectangle_0.Top + (rectangle_0.Height / 2));
        Point[] points = null;
        switch (arrowDirection_0)
        {
            case ArrowDirection.Left:
                pointArray2 = new Point[] { new Point(point.X + 1, point.Y - 4), new Point(point.X + 1, point.Y + 4), new Point(point.X - 2, point.Y) };
                points = pointArray2;
                break;

            case ArrowDirection.Up:
                pointArray2 = new Point[] { new Point(point.X - 4, point.Y + 1), new Point(point.X + 4, point.Y + 1), new Point(point.X, point.Y - 2) };
                points = pointArray2;
                break;

            case ArrowDirection.Right:
                pointArray2 = new Point[] { new Point(point.X - 2, point.Y - 4), new Point(point.X - 2, point.Y + 4), new Point(point.X + 1, point.Y) };
                points = pointArray2;
                break;

            default:
                pointArray2 = new Point[] { new Point(point.X - 4, point.Y - 1), new Point(point.X + 4, point.Y - 1), new Point(point.X, point.Y + 2) };
                points = pointArray2;
                break;
        }
        graphics_0.FillPolygon(brush_0, points);
    }

    internal static void smethod_4(Graphics graphics_0, Image image_0, Rectangle rectangle_0, float float_0)
    {
        using (ImageAttributes attributes = new ImageAttributes())
        {
            ColorMap map = new ColorMap {
                OldColor = Color.FromArgb(0xff, 0, 0xff, 0),
                NewColor = Color.FromArgb(0, 0, 0, 0)
            };
            ColorMap[] mapArray2 = new ColorMap[] { map };
            attributes.SetRemapTable(mapArray2, ColorAdjustType.Bitmap);
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
            numArray2[3] = float_0;
            numArray[3] = numArray2;
            numArray2 = new float[5];
            numArray2[4] = 1f;
            numArray[4] = numArray2;
            float[][] newColorMatrix = numArray;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics_0.DrawImage(image_0, rectangle_0, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, attributes);
        }
    }

    internal static void smethod_5(Graphics graphics_0, Rectangle rectangle_0, Size size_0, Color color_0)
    {
        int num = ColorTranslator.ToWin32(color_0);
        IntPtr hdc = graphics_0.GetHdc();
        for (int i = rectangle_0.X; i <= rectangle_0.Right; i += size_0.Width)
        {
            for (int j = rectangle_0.Y; j <= rectangle_0.Bottom; j += size_0.Height)
            {
                SetPixel(hdc, i, j, num);
            }
        }
        graphics_0.ReleaseHdc(hdc);
    }

    internal static Color smethod_6(Color color_0, int int_0, int int_1, int int_2, int int_3)
    {
        int a = color_0.A;
        int r = color_0.R;
        int g = color_0.G;
        int b = color_0.B;
        if ((int_0 + a) > 0xff)
        {
            int_0 = 0xff;
        }
        else
        {
            int_0 = Math.Max(0, int_0 + a);
        }
        if ((int_1 + r) > 0xff)
        {
            int_1 = 0xff;
        }
        else
        {
            int_1 = Math.Max(0, int_1 + r);
        }
        if ((int_2 + g) > 0xff)
        {
            int_2 = 0xff;
        }
        else
        {
            int_2 = Math.Max(0, int_2 + g);
        }
        if ((int_3 + b) > 0xff)
        {
            int_3 = 0xff;
        }
        else
        {
            int_3 = Math.Max(0, int_3 + b);
        }
        return Color.FromArgb(int_0, int_1, int_2, int_3);
    }
}

