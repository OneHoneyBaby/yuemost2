namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public static class GraphicsPathHelper
    {
        public static GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            if ((radius <= 0) || (style == RoundStyle.None))
            {
                if (correction)
                {
                    path.AddRectangle(new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1));
                }
                else
                {
                    path.AddRectangle(rect);
                }
                path.CloseFigure();
                return path;
            }
            int num = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;

                case RoundStyle.TopLeft:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
                    path.AddLine(rect.Right - num, rect.Bottom - num, rect.X, rect.Bottom - num);
                    break;

                case RoundStyle.TopRight:
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddLine(rect.Right - num, rect.Bottom - num, rect.X, rect.Bottom - num);
                    path.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
                    break;

                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddLine(rect.Right - num, rect.Bottom - num, rect.X, rect.Bottom - num);
                    break;

                case RoundStyle.BottomLeft:
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    path.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
                    break;

                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    break;

                case RoundStyle.BottomRight:
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    break;

                case RoundStyle.Right:
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
                    break;

                case RoundStyle.Bottom:
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    break;

                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        public static GraphicsPath CreateTrackBarThumbPath(Rectangle rect, ThumbArrowDirection arrowDirection)
        {
            GraphicsPath path = new GraphicsPath();
            PointF tf = new PointF(rect.X + (((float) rect.Width) / 2f), rect.Y + (((float) rect.Height) / 2f));
            float num = 0f;
            switch (arrowDirection)
            {
                case ThumbArrowDirection.Left:
                case ThumbArrowDirection.Right:
                    num = (((float) rect.Width) / 2f) - 4f;
                    break;

                case ThumbArrowDirection.Up:
                case ThumbArrowDirection.Down:
                    num = (((float) rect.Height) / 2f) - 4f;
                    break;
            }
            switch (arrowDirection)
            {
                case ThumbArrowDirection.None:
                    path.AddRectangle(rect);
                    break;

                case ThumbArrowDirection.Left:
                    path.AddLine((float) rect.X, tf.Y, rect.X + num, (float) rect.Y);
                    path.AddLine(rect.Right, rect.Y, rect.Right, rect.Bottom);
                    path.AddLine(rect.X + num, (float) rect.Bottom, (float) rect.X, tf.Y);
                    break;

                case ThumbArrowDirection.Right:
                    path.AddLine((float) rect.Right, tf.Y, rect.Right - num, (float) rect.Bottom);
                    path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y);
                    path.AddLine(rect.Right - num, (float) rect.Y, (float) rect.Right, tf.Y);
                    break;

                case ThumbArrowDirection.Up:
                    path.AddLine(tf.X, (float) rect.Y, (float) rect.X, rect.Y + num);
                    path.AddLine(rect.X, rect.Bottom, rect.Right, rect.Bottom);
                    path.AddLine((float) rect.Right, rect.Y + num, tf.X, (float) rect.Y);
                    break;

                case ThumbArrowDirection.Down:
                    path.AddLine(tf.X, (float) rect.Bottom, (float) rect.X, rect.Bottom - num);
                    path.AddLine(rect.X, rect.Y, rect.Right, rect.Y);
                    path.AddLine((float) rect.Right, rect.Bottom - num, tf.X, (float) rect.Bottom);
                    break;
            }
            path.CloseFigure();
            return path;
        }
    }
}

