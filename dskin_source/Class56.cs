using DSkin.Common;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

internal class Class56
{
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
        using (LinearGradientBrush brush = new LinearGradientBrush(rectangle_0, Color.Transparent, Color.Transparent, linearGradientMode_0))
        {
            Rectangle rectangle;
            SolidBrush brush2;
            RectangleF ef;
            Pen pen;
            Color[] colorArray = new Color[] { smethod_3(color_0, 0, 0x23, 0x18, 9), smethod_3(color_0, 0, 13, 8, 3), color_0, smethod_3(color_0, 0, 0x23, 0x18, 9) };
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

    internal static Color smethod_3(Color color_0, int int_0, int int_1, int int_2, int int_3)
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

