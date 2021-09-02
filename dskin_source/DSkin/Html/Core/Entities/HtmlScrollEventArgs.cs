namespace DSkin.Html.Core.Entities
{
    using DSkin.Html.Adapters.Entities;
    using System;

    public sealed class HtmlScrollEventArgs : EventArgs
    {
        private readonly RPoint rpoint_0;

        public HtmlScrollEventArgs(RPoint location)
        {
            this.rpoint_0 = location;
        }

        public override string ToString()
        {
            return string.Format("Location: {0}", this.rpoint_0);
        }

        public double X
        {
            get
            {
                return this.rpoint_0.X;
            }
        }

        public double Y
        {
            get
            {
                return this.rpoint_0.Y;
            }
        }
    }
}

