namespace DSkin.Html.Core.Entities
{
    using System;

    public sealed class HtmlRefreshEventArgs : EventArgs
    {
        private readonly bool bool_0;

        public HtmlRefreshEventArgs(bool layout)
        {
            this.bool_0 = layout;
        }

        public override string ToString()
        {
            return string.Format("Layout: {0}", this.bool_0);
        }

        public bool Layout
        {
            get
            {
                return this.bool_0;
            }
        }
    }
}

