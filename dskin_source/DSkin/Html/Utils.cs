namespace DSkin.Html
{
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public static class Utils
    {
        public static PointF[] Convert(RPoint[] points)
        {
            PointF[] tfArray = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                tfArray[i] = Convert(points[i]);
            }
            return tfArray;
        }

        public static Color Convert(RColor c)
        {
            return Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        public static PointF Convert(RPoint p)
        {
            return new PointF((float) p.X, (float) p.Y);
        }

        public static RectangleF Convert(RRect r)
        {
            return new RectangleF((float) r.X, (float) r.Y, (float) r.Width, (float) r.Height);
        }

        public static SizeF Convert(RSize s)
        {
            return new SizeF((float) s.Width, (float) s.Height);
        }

        public static RColor Convert(Color c)
        {
            return RColor.FromArgb(c.A, c.R, c.G, c.B);
        }

        public static RPoint Convert(PointF p)
        {
            return new RPoint((double) p.X, (double) p.Y);
        }

        public static RRect Convert(RectangleF r)
        {
            return new RRect((double) r.X, (double) r.Y, (double) r.Width, (double) r.Height);
        }

        public static RSize Convert(SizeF s)
        {
            return new RSize((double) s.Width, (double) s.Height);
        }

        public static Point ConvertRound(RPoint p)
        {
            return new Point((int) Math.Round(p.X), (int) Math.Round(p.Y));
        }

        public static Rectangle ConvertRound(RRect r)
        {
            return new Rectangle((int) Math.Round(r.X), (int) Math.Round(r.Y), (int) Math.Round(r.Width), (int) Math.Round(r.Height));
        }

        public static Size ConvertRound(RSize s)
        {
            return new Size((int) Math.Round(s.Width), (int) Math.Round(s.Height));
        }

        public static Graphics CreateGraphics(Control control)
        {
            return control.CreateGraphics();
        }
    }
}

