namespace DSkin.Imaging
{
    using System;
    using System.Drawing;

    public sealed class ColorConverterEx
    {
        private static readonly int[] int_0 = new int[] { 0x84d, 0x1bf2, 0x2d1, 0x2710 };
        private static readonly int[] int_1 = new int[] { 500, 0x1a3, 0x51, 0x3e8 };
        private static readonly int[] int_2 = new int[] { 0x12b, 0x24b, 0x72, 0x3e8 };

        private ColorConverterEx()
        {
        }

        public static RGB HslToRgb(HSL hsl)
        {
            RGB rgb = new RGB();
            HslToRgb(hsl, rgb);
            return rgb;
        }

        public static void HslToRgb(HSL hsl, RGB rgb)
        {
            if (hsl.Saturation == 0.0)
            {
                rgb.R = rgb.G = rgb.B = (byte) (hsl.Luminance * 255.0);
            }
            else
            {
                double num3 = ((double) hsl.Hue) / 360.0;
                double num = (hsl.Luminance < 0.5) ? (hsl.Luminance * (1.0 + hsl.Saturation)) : ((hsl.Luminance + hsl.Saturation) - (hsl.Luminance * hsl.Saturation));
                double num2 = (2.0 * hsl.Luminance) - num;
                rgb.R = (byte) (255.0 * smethod_2(num2, num, num3 + 0.33333333333333331));
                rgb.G = (byte) (255.0 * smethod_2(num2, num, num3));
                rgb.B = (byte) (255.0 * smethod_2(num2, num, num3 - 0.33333333333333331));
            }
        }

        public static RGB RgbToGray(RGB source)
        {
            RGB dest = new RGB();
            RgbToGray(source, dest);
            return dest;
        }

        public static RGB RgbToGray(RGB source, GrayscaleStyle style)
        {
            RGB dest = new RGB();
            RgbToGray(source, dest, style);
            return dest;
        }

        public static void RgbToGray(RGB source, RGB dest)
        {
            RgbToGray(source, dest, GrayscaleStyle.BT907);
        }

        public static void RgbToGray(RGB source, RGB dest, GrayscaleStyle style)
        {
            byte num = 0x7f;
            switch (style)
            {
                case GrayscaleStyle.BT907:
                    num = smethod_3(source, int_0);
                    break;

                case GrayscaleStyle.RMY:
                    num = smethod_3(source, int_1);
                    break;

                case GrayscaleStyle.Y:
                    num = smethod_3(source, int_2);
                    break;
            }
            dest.R = dest.G = dest.B = num;
        }

        public static HSL RgbToHsl(RGB rgb)
        {
            HSL hsl = new HSL();
            RgbToHsl(rgb, hsl);
            return hsl;
        }

        public static void RgbToHsl(RGB rgb, HSL hsl)
        {
            double num = ((double) rgb.R) / 255.0;
            double num2 = ((double) rgb.G) / 255.0;
            double num3 = ((double) rgb.G) / 255.0;
            double num4 = Math.Min(Math.Min(num, num2), num3);
            double num5 = Math.Max(Math.Max(num, num2), num3);
            double num6 = num5 - num4;
            hsl.Luminance = (num5 + num4) / 2.0;
            if (num6 == 0.0)
            {
                hsl.Hue = 0;
                hsl.Saturation = 0.0;
            }
            else
            {
                double num9;
                hsl.Saturation = (hsl.Luminance < 0.5) ? (num6 / (num5 + num4)) : (num6 / ((2.0 - num5) - num4));
                double num7 = (((num5 - num) / 6.0) + (num6 / 2.0)) / num6;
                double num10 = (((num5 - num2) / 6.0) + (num6 / 2.0)) / num6;
                double num8 = (((num5 - num3) / 6.0) + (num6 / 2.0)) / num6;
                if (num == num5)
                {
                    num9 = num8 - num10;
                }
                else if (num2 == num5)
                {
                    num9 = (0.33333333333333331 + num7) - num8;
                }
                else
                {
                    num9 = (0.66666666666666663 + num10) - num7;
                }
                if (num9 < 0.0)
                {
                    num9++;
                }
                if (num9 > 1.0)
                {
                    num9--;
                }
                hsl.Hue = (int) (num9 * 360.0);
            }
        }

        public static HSL smethod_0(Color color)
        {
            int num12;
            double num13;
            double num = ((double) color.R) / 255.0;
            double num2 = ((double) color.G) / 255.0;
            double num3 = ((double) color.B) / 255.0;
            double num4 = Math.Min(Math.Min(num, num2), num3);
            double num5 = Math.Max(Math.Max(num, num2), num3);
            double num6 = num5 - num4;
            double luminance = (num5 + num4) / 2.0;
            if (num6 == 0.0)
            {
                num12 = 0;
                num13 = 0.0;
            }
            else
            {
                double num8;
                num13 = (luminance < 0.5) ? (num6 / (num5 + num4)) : (num6 / ((2.0 - num5) - num4));
                double num11 = (((num5 - num) / 6.0) + (num6 / 2.0)) / num6;
                double num10 = (((num5 - num2) / 6.0) + (num6 / 2.0)) / num6;
                double num9 = (((num5 - num3) / 6.0) + (num6 / 2.0)) / num6;
                if (num == num5)
                {
                    num8 = num9 - num10;
                }
                else if (num2 == num5)
                {
                    num8 = (0.33333333333333331 + num11) - num9;
                }
                else
                {
                    num8 = (0.66666666666666663 + num10) - num11;
                }
                if (num8 < 0.0)
                {
                    num8++;
                }
                if (num8 > 1.0)
                {
                    num8--;
                }
                num12 = (int) (num8 * 360.0);
            }
            return new HSL(num12, num13, luminance);
        }

        public static Color smethod_1(HSL hsl)
        {
            byte num4;
            byte num5;
            byte num6;
            if (hsl.Saturation == 0.0)
            {
                num4 = num5 = num6 = (byte) (hsl.Luminance * 255.0);
            }
            else
            {
                double num3 = ((double) hsl.Hue) / 360.0;
                double num = (hsl.Luminance < 0.5) ? (hsl.Luminance * (1.0 + hsl.Saturation)) : ((hsl.Luminance + hsl.Saturation) - (hsl.Luminance * hsl.Saturation));
                double num2 = (2.0 * hsl.Luminance) - num;
                num4 = (byte) (255.0 * smethod_2(num2, num, num3 + 0.33333333333333331));
                num5 = (byte) (255.0 * smethod_2(num2, num, num3));
                num6 = (byte) (255.0 * smethod_2(num2, num, num3 - 0.33333333333333331));
            }
            return Color.FromArgb(num4, num5, num6);
        }

        private static double smethod_2(double double_0, double double_1, double double_2)
        {
            if (double_2 < 0.0)
            {
                double_2++;
            }
            if (double_2 > 1.0)
            {
                double_2--;
            }
            if ((6.0 * double_2) < 1.0)
            {
                return (double_0 + (((double_1 - double_0) * 6.0) * double_2));
            }
            if ((2.0 * double_2) < 1.0)
            {
                return double_1;
            }
            if ((3.0 * double_2) < 2.0)
            {
                return (double_0 + (((double_1 - double_0) * (0.66666666666666663 - double_2)) * 6.0));
            }
            return double_0;
        }

        private static byte smethod_3(RGB rgb_0, object object_0)
        {
            return (byte) ((((rgb_0.R * object_0[0]) + (rgb_0.G * object_0[1])) + (rgb_0.B * object_0[2])) / object_0[3]);
        }
    }
}

