namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Drawing.Drawing2D;

    public sealed class GraphicsPathAdapter : RGraphicsPath
    {
        private readonly System.Drawing.Drawing2D.GraphicsPath graphicsPath_0 = new System.Drawing.Drawing2D.GraphicsPath();
        private RPoint rpoint_0;

        public override void ArcTo(double x, double y, double size, RGraphicsPath.Corner corner)
        {
            float num2 = (float) (Math.Min(x, this.rpoint_0.X) - (((corner == RGraphicsPath.Corner.TopRight) || (corner == RGraphicsPath.Corner.BottomRight)) ? size : 0.0));
            float num = (float) (Math.Min(y, this.rpoint_0.Y) - (((corner == RGraphicsPath.Corner.BottomLeft) || (corner == RGraphicsPath.Corner.BottomRight)) ? size : 0.0));
            this.graphicsPath_0.AddArc(num2, num, ((float) size) * 2f, ((float) size) * 2f, (float) smethod_0(corner), 90f);
            this.rpoint_0 = new RPoint(x, y);
        }

        public override void Dispose()
        {
            this.graphicsPath_0.Dispose();
        }

        public override void LineTo(double x, double y)
        {
            this.graphicsPath_0.AddLine((float) this.rpoint_0.X, (float) this.rpoint_0.Y, (float) x, (float) y);
            this.rpoint_0 = new RPoint(x, y);
        }

        private static int smethod_0(RGraphicsPath.Corner corner_0)
        {
            switch (corner_0)
            {
                case RGraphicsPath.Corner.TopLeft:
                    return 180;

                case RGraphicsPath.Corner.TopRight:
                    return 270;

                case RGraphicsPath.Corner.BottomLeft:
                    return 90;

                case RGraphicsPath.Corner.BottomRight:
                    return 0;
            }
            throw new ArgumentOutOfRangeException("corner");
        }

        public override void Start(double x, double y)
        {
            this.rpoint_0 = new RPoint(x, y);
        }

        public System.Drawing.Drawing2D.GraphicsPath GraphicsPath
        {
            get
            {
                return this.graphicsPath_0;
            }
        }
    }
}

