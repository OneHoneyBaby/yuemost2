namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public sealed class PenAdapter : RPen
    {
        private readonly System.Drawing.Pen pen_0;

        public PenAdapter(System.Drawing.Pen pen)
        {
            this.pen_0 = pen;
        }

        public override RDashStyle DashStyle
        {
            set
            {
                switch (value)
                {
                    case RDashStyle.Solid:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;

                    case RDashStyle.Dash:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        if (this.Width < 2.0)
                        {
                            this.pen_0.DashPattern = new float[] { 4f, 4f };
                        }
                        break;

                    case RDashStyle.Dot:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        break;

                    case RDashStyle.DashDot:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        break;

                    case RDashStyle.DashDotDot:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        break;

                    case RDashStyle.Custom:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        break;

                    default:
                        this.pen_0.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                }
            }
        }

        public System.Drawing.Pen Pen
        {
            get
            {
                return this.pen_0;
            }
        }

        public override double Width
        {
            get
            {
                return (double) this.pen_0.Width;
            }
            set
            {
                this.pen_0.Width = (float) value;
            }
        }
    }
}

