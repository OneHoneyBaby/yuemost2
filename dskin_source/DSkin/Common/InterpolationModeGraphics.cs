namespace DSkin.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class InterpolationModeGraphics : IDisposable
    {
        private Graphics graphics_0;
        private InterpolationMode interpolationMode_0;

        public InterpolationModeGraphics(Graphics graphics) : this(graphics, InterpolationMode.HighQualityBicubic)
        {
        }

        public InterpolationModeGraphics(Graphics graphics, InterpolationMode newMode)
        {
            this.graphics_0 = graphics;
            this.interpolationMode_0 = graphics.InterpolationMode;
            graphics.InterpolationMode = newMode;
        }

        public void Dispose()
        {
            this.graphics_0.InterpolationMode = this.interpolationMode_0;
        }
    }
}

