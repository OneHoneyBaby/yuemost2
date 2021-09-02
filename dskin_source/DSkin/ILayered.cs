namespace DSkin
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public interface ILayered
    {
        event EventHandler<PaintEventArgs> LayeredPaintEvent;

        void DisposeCanvas();
        void PaintControl(Graphics g, Rectangle invalidateRect);

        bool BitmapCache { get; set; }

        Bitmap Canvas { get; set; }

        ImageAttributes ImageAttribute { get; set; }

        IImageEffect ImageEffect { get; set; }
    }
}

