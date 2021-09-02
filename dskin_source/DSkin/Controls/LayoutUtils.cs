namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class LayoutUtils
    {
        public static Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        public static Size FlipSize(Size size)
        {
            int width = size.Width;
            size.Width = size.Height;
            size.Height = width;
            return size;
        }

        public static bool IsEmptyRect(Rectangle rect)
        {
            return ((rect.Width <= 0) || (rect.Height <= 0));
        }

        public static Rectangle RTLTranslate(Rectangle bounds, Rectangle withinBounds)
        {
            bounds.X = withinBounds.Width - bounds.Right;
            return bounds;
        }
    }
}

