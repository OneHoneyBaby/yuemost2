namespace DSkin.Html.Adapters
{
    using System;

    public abstract class RGraphicsPath : IDisposable
    {
        protected RGraphicsPath()
        {
        }

        public abstract void ArcTo(double x, double y, double size, Corner corner);
        public abstract void Dispose();
        public abstract void LineTo(double x, double y);
        public abstract void Start(double x, double y);

        public enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }
    }
}

