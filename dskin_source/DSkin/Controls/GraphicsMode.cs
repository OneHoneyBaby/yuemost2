namespace DSkin.Controls
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class GraphicsMode : IDisposable
    {
        private Graphics graphics_0;
        private SmoothingMode smoothingMode_0;

        public GraphicsMode(Graphics g, SmoothingMode mode)
        {
            this.graphics_0 = g;
            this.smoothingMode_0 = this.graphics_0.SmoothingMode;
            this.graphics_0.SmoothingMode = mode;
        }

        public void Dispose()
        {
            this.graphics_0.SmoothingMode = this.smoothingMode_0;
        }
    }
}

