namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class SmoothingModeGraphics : IDisposable
    {
        private Graphics graphics_0;
        private SmoothingMode smoothingMode_0;

        public SmoothingModeGraphics(Graphics graphics) : this(graphics, SmoothingMode.AntiAlias)
        {
        }

        public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
        {
            this.graphics_0 = graphics;
            this.smoothingMode_0 = graphics.SmoothingMode;
            graphics.SmoothingMode = newMode;
        }

        public void Dispose()
        {
            this.graphics_0.SmoothingMode = this.smoothingMode_0;
        }
    }
}

