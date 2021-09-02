namespace DSkin.Html.Adapters
{
    using System;

    public abstract class RImage : IDisposable
    {
        protected RImage()
        {
        }

        public abstract void Dispose();

        public abstract double Height { get; }

        public abstract double Width { get; }
    }
}

