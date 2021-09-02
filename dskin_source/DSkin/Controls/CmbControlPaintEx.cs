namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public sealed class CmbControlPaintEx
    {
        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect)
        {
            DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, Point.Empty, RightToLeft.No);
        }

        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset)
        {
            DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, scrollOffset, RightToLeft.No);
        }

        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset, RightToLeft rightToLeft)
        {
            if (g == null)
            {
                throw new ArgumentNullException("g");
            }
            if (backgroundImageLayout == ImageLayout.Tile)
            {
                using (TextureBrush brush2 = new TextureBrush(backgroundImage, WrapMode.Tile))
                {
                    if (scrollOffset != Point.Empty)
                    {
                        Matrix transform = brush2.Transform;
                        transform.Translate((float) scrollOffset.X, (float) scrollOffset.Y);
                        brush2.Transform = transform;
                    }
                    g.FillRectangle(brush2, clipRect);
                    return;
                }
            }
            Rectangle rect = smethod_0(bounds, backgroundImage, backgroundImageLayout);
            if ((rightToLeft == RightToLeft.Yes) && (backgroundImageLayout == ImageLayout.None))
            {
                rect.X += clipRect.Width - rect.Width;
            }
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, clipRect);
            }
            if (!clipRect.Contains(rect))
            {
                if ((backgroundImageLayout == ImageLayout.Stretch) || (backgroundImageLayout == ImageLayout.Zoom))
                {
                    rect.Intersect(clipRect);
                    g.DrawImage(backgroundImage, rect);
                }
                else if (backgroundImageLayout == ImageLayout.None)
                {
                    rect.Offset(clipRect.Location);
                    Rectangle destRect = rect;
                    destRect.Intersect(clipRect);
                    Rectangle rectangle5 = new Rectangle(Point.Empty, destRect.Size);
                    g.DrawImage(backgroundImage, destRect, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle rectangle2 = rect;
                    rectangle2.Intersect(clipRect);
                    Rectangle rectangle3 = new Rectangle(new Point(rectangle2.X - rect.X, rectangle2.Y - rect.Y), rectangle2.Size);
                    g.DrawImage(backgroundImage, rectangle2, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
                }
            }
            else
            {
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                g.DrawImage(backgroundImage, rect, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttr);
                imageAttr.Dispose();
            }
        }

        public static void DrawCheckedFlag(Graphics graphics, Rectangle rect, Color color)
        {
            PointF[] points = new PointF[] { new PointF(rect.X + (((float) rect.Width) / 4.5f), rect.Y + (((float) rect.Height) / 2.5f)), new PointF(rect.X + (((float) rect.Width) / 2.5f), rect.Bottom - (((float) rect.Height) / 3f)), new PointF(rect.Right - (((float) rect.Width) / 4f), rect.Y + (((float) rect.Height) / 4.5f)) };
            using (Pen pen = new Pen(color, 2f))
            {
                graphics.DrawLines(pen, points);
            }
        }

        public static void DrawGlass(Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
        {
            DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
        }

        public static void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(glassRect.X + (glassRect.Width / 2f), glassRect.Y + (glassRect.Height / 2f));
                    g.FillPath(brush, path);
                }
            }
        }

        internal static Rectangle smethod_0(Rectangle rectangle_0, Image image_0, ImageLayout imageLayout_0)
        {
            Rectangle rectangle = rectangle_0;
            if (image_0 != null)
            {
                switch (imageLayout_0)
                {
                    case ImageLayout.None:
                        rectangle.Size = image_0.Size;
                        return rectangle;

                    case ImageLayout.Tile:
                        return rectangle;

                    case ImageLayout.Center:
                    {
                        rectangle.Size = image_0.Size;
                        Size size2 = rectangle_0.Size;
                        if (size2.Width > rectangle.Width)
                        {
                            rectangle.X = (size2.Width - rectangle.Width) / 2;
                        }
                        if (size2.Height > rectangle.Height)
                        {
                            rectangle.Y = (size2.Height - rectangle.Height) / 2;
                        }
                        return rectangle;
                    }
                    case ImageLayout.Stretch:
                        rectangle.Size = rectangle_0.Size;
                        return rectangle;

                    case ImageLayout.Zoom:
                    {
                        Size size = image_0.Size;
                        float num = ((float) rectangle_0.Width) / ((float) size.Width);
                        float num2 = ((float) rectangle_0.Height) / ((float) size.Height);
                        if (num >= num2)
                        {
                            rectangle.Height = rectangle_0.Height;
                            rectangle.Width = (int) ((size.Width * num2) + 0.5);
                            if (rectangle_0.X >= 0)
                            {
                                rectangle.X = (rectangle_0.Width - rectangle.Width) / 2;
                            }
                            return rectangle;
                        }
                        rectangle.Width = rectangle_0.Width;
                        rectangle.Height = (int) ((size.Height * num) + 0.5);
                        if (rectangle_0.Y >= 0)
                        {
                            rectangle.Y = (rectangle_0.Height - rectangle.Height) / 2;
                        }
                        return rectangle;
                    }
                }
            }
            return rectangle;
        }
    }
}

