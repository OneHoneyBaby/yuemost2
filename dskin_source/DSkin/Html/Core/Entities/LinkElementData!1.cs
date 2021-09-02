namespace DSkin.Html.Core.Entities
{
    using System;

    public sealed class LinkElementData<T>
    {
        private readonly T gparam_0;
        private readonly string string_0;
        private readonly string string_1;

        public LinkElementData(string id, string href, T rectangle)
        {
            this.string_0 = id;
            this.string_1 = href;
            this.gparam_0 = rectangle;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Href: {1}, Rectangle: {2}", this.string_0, this.string_1, this.gparam_0);
        }

        public string AnchorId
        {
            get
            {
                return ((!this.IsAnchor || (this.string_1.Length <= 1)) ? string.Empty : this.string_1.Substring(1));
            }
        }

        public string Href
        {
            get
            {
                return this.string_1;
            }
        }

        public string Id
        {
            get
            {
                return this.string_0;
            }
        }

        public bool IsAnchor
        {
            get
            {
                return ((this.string_1.Length > 0) && (this.string_1[0] == '#'));
            }
        }

        public T Rectangle
        {
            get
            {
                return this.gparam_0;
            }
        }
    }
}

