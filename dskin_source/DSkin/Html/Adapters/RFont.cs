namespace DSkin.Html.Adapters
{
    using System;

    public abstract class RFont
    {
        protected RFont()
        {
        }

        public abstract double GetWhitespaceWidth(RGraphics graphics);

        public abstract double Height { get; }

        public abstract double LeftPadding { get; }

        public abstract double Size { get; }

        public abstract double UnderlineOffset { get; }
    }
}

