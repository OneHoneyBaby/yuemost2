﻿namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;

    public static class BitmapHelper
    {
        public static Bitmap CutImage(this Image image, Rectangle rect)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
            }
            return bitmap;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.UnmanagedCode)]
        public static unsafe Color GetImageAverageColor(Image image)
        {
            Color color;
            using (Bitmap bitmap = new Bitmap(image))
            {
                int width = bitmap.Width;
                int height = bitmap.Height;
                Rectangle rect = new Rectangle(0, 0, width, height);
                try
                {
                    BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    byte* numPtr = (byte*) bitmapdata.Scan0;
                    int num3 = bitmapdata.Stride - (bitmapdata.Width * 4);
                    int num4 = width * height;
                    int num5 = 0;
                    int red = 0;
                    int green = 0;
                    int blue = 0;
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            numPtr++;
                            blue += numPtr[0];
                            numPtr++;
                            green += numPtr[0];
                            numPtr++;
                            red += numPtr[0];
                            numPtr++;
                            num5 += numPtr[0];
                        }
                        numPtr += num3;
                    }
                    bitmap.UnlockBits(bitmapdata);
                    num5 /= num4;
                    red /= num4;
                    green /= num4;
                    blue /= num4;
                    color = Color.FromArgb(0xff, red, green, blue);
                }
                catch
                {
                    color = Color.FromArgb(0x7f, 0x7f, 0x7f);
                }
            }
            return color;
        }
    }
}

