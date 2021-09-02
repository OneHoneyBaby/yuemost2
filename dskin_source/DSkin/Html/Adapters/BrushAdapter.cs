namespace DSkin.Html.Adapters
{
    using System;
    using System.Drawing;

    public sealed class BrushAdapter : RBrush
    {
        private readonly bool bool_0;
        private readonly System.Drawing.Brush brush_0;

        public BrushAdapter(System.Drawing.Brush brush, bool dispose)
        {
            this.brush_0 = brush;
            this.bool_0 = dispose;
        }

        public override void Dispose()
        {
            if (this.bool_0)
            {
                this.brush_0.Dispose();
            }
        }

        public System.Drawing.Brush Brush
        {
            get
            {
                return this.brush_0;
            }
        }
    }
}

