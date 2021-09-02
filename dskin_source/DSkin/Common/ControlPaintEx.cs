namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public sealed class ControlPaintEx
    {
        private ControlPaintEx()
        {
        }

        public static Rectangle CalculateBackgroundImageRectangle(Rectangle bounds, Image backgroundImage, ImageLayout imageLayout)
        {
            Rectangle rectangle = bounds;
            if (backgroundImage != null)
            {
                switch (imageLayout)
                {
                    case ImageLayout.None:
                        rectangle.Size = backgroundImage.Size;
                        return rectangle;

                    case ImageLayout.Tile:
                        return rectangle;

                    case ImageLayout.Center:
                    {
                        rectangle.Size = backgroundImage.Size;
                        Size size2 = bounds.Size;
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
                        rectangle.Size = bounds.Size;
                        return rectangle;

                    case ImageLayout.Zoom:
                    {
                        Size size = backgroundImage.Size;
                        float num = ((float) bounds.Width) / ((float) size.Width);
                        float num2 = ((float) bounds.Height) / ((float) size.Height);
                        if (num >= num2)
                        {
                            rectangle.Height = bounds.Height;
                            rectangle.Width = (int) ((size.Width * num2) + 0.5);
                            if (bounds.X >= 0)
                            {
                                rectangle.X = (bounds.Width - rectangle.Width) / 2;
                            }
                            return rectangle;
                        }
                        rectangle.Width = bounds.Width;
                        rectangle.Height = (int) ((size.Height * num) + 0.5);
                        if (bounds.Y >= 0)
                        {
                            rectangle.Y = (bounds.Height - rectangle.Height) / 2;
                        }
                        return rectangle;
                    }
                }
            }
            return rectangle;
        }

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
                using (TextureBrush brush = new TextureBrush(backgroundImage, WrapMode.Tile))
                {
                    if (scrollOffset != Point.Empty)
                    {
                        Matrix transform = brush.Transform;
                        transform.Translate((float) scrollOffset.X, (float) scrollOffset.Y);
                        brush.Transform = transform;
                    }
                    g.FillRectangle(brush, clipRect);
                    return;
                }
            }
            Rectangle rect = CalculateBackgroundImageRectangle(bounds, backgroundImage, backgroundImageLayout);
            if ((rightToLeft == RightToLeft.Yes) && (backgroundImageLayout == ImageLayout.None))
            {
                rect.X += clipRect.Width - rect.Width;
            }
            using (SolidBrush brush2 = new SolidBrush(backColor))
            {
                g.FillRectangle(brush2, clipRect);
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
                    Rectangle rectangle3 = new Rectangle(Point.Empty, destRect.Size);
                    g.DrawImage(backgroundImage, destRect, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle rectangle4 = rect;
                    rectangle4.Intersect(clipRect);
                    Rectangle rectangle5 = new Rectangle(new Point(rectangle4.X - rect.X, rectangle4.Y - rect.Y), rectangle4.Size);
                    g.DrawImage(backgroundImage, rectangle4, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, GraphicsUnit.Pixel);
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

        public static void DrawScrollBarArraw(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Color fore, Orientation orientation, ArrowDirection arrowDirection, bool changeColor)
        {
            if (changeColor)
            {
                Color color = begin;
                begin = end;
                end = color;
            }
            LinearGradientMode mode = (orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            rect.Inflate(-1, -1);
            Blend blend = new Blend();
            float[] numArray = new float[3];
            numArray[0] = 1f;
            numArray[1] = 0.5f;
            blend.Factors = numArray;
            numArray = new float[3];
            numArray[1] = 0.5f;
            numArray[2] = 1f;
            blend.Positions = numArray;
            smethod_1(g, rect, begin, end, border, innerBorder, blend, mode, 4, RoundStyle.All, true, true);
            using (SolidBrush brush = new SolidBrush(fore))
            {
                Class8.smethod_3(g, rect, arrowDirection, brush);
            }
        }

        public static void DrawScrollBarSizer(Graphics g, Rectangle rect, Color begin, Color end)
        {
            Blend blend = new Blend();
            float[] numArray = new float[3];
            numArray[0] = 1f;
            numArray[1] = 0.5f;
            blend.Factors = numArray;
            numArray = new float[3];
            numArray[1] = 0.5f;
            numArray[2] = 1f;
            blend.Positions = numArray;
            smethod_0(g, rect, begin, end, begin, begin, blend, LinearGradientMode.Horizontal, true, false);
        }

        public static void DrawScrollBarThumb(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Orientation orientation, bool changeColor)
        {
            bool flag;
            if (changeColor)
            {
                Color color = begin;
                begin = end;
                end = color;
            }
            LinearGradientMode mode = (flag = orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Blend blend = new Blend();
            float[] numArray = new float[3];
            numArray[0] = 1f;
            numArray[1] = 0.5f;
            blend.Factors = numArray;
            numArray = new float[3];
            numArray[1] = 0.5f;
            numArray[2] = 1f;
            blend.Positions = numArray;
            if (flag)
            {
                rect.Inflate(0, -1);
            }
            else
            {
                rect.Inflate(-1, 0);
            }
            smethod_1(g, rect, begin, end, border, innerBorder, blend, mode, 4, RoundStyle.All, true, true);
        }

        public static void DrawScrollBarTrack(Graphics g, Rectangle rect, Color begin, Color end, Orientation orientation)
        {
            LinearGradientMode mode = (orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Blend blend = new Blend();
            float[] numArray = new float[3];
            numArray[0] = 1f;
            numArray[1] = 0.5f;
            blend.Factors = numArray;
            numArray = new float[3];
            numArray[1] = 0.5f;
            numArray[2] = 1f;
            blend.Positions = numArray;
            smethod_0(g, rect, begin, end, begin, begin, blend, mode, true, false);
        }

        internal static void smethod_0(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, Color color_2, Color color_3, Blend blend_0, LinearGradientMode linearGradientMode_0, bool bool_0, bool bool_1)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(rectangle_0, color_0, color_1, linearGradientMode_0))
            {
                brush.Blend = blend_0;
                graphics_0.FillRectangle(brush, rectangle_0);
            }
            if (bool_0)
            {
                ControlPaint.DrawBorder(graphics_0, rectangle_0, color_2, ButtonBorderStyle.Solid);
            }
            if (bool_1)
            {
                rectangle_0.Inflate(-1, -1);
                ControlPaint.DrawBorder(graphics_0, rectangle_0, color_2, ButtonBorderStyle.Solid);
            }
        }

        internal static void smethod_1(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1, Color color_2, Color color_3, Blend blend_0, LinearGradientMode linearGradientMode_0, int int_0, RoundStyle roundStyle_0, bool bool_0, bool bool_1)
        {
            GraphicsPath path;
            Pen pen;
            using (path = GraphicsPathHelper.CreatePath(rectangle_0, int_0, roundStyle_0, true))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rectangle_0, color_0, color_1, linearGradientMode_0))
                {
                    brush.Blend = blend_0;
                    graphics_0.FillPath(brush, path);
                }
                if (bool_0)
                {
                    using (pen = new Pen(color_2))
                    {
                        graphics_0.DrawPath(pen, path);
                    }
                }
            }
            if (bool_1)
            {
                rectangle_0.Inflate(-1, -1);
                using (path = GraphicsPathHelper.CreatePath(rectangle_0, int_0, roundStyle_0, true))
                {
                    using (pen = new Pen(color_3))
                    {
                        graphics_0.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}

