namespace DSkin.Html.Core.Entities
{
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;

    public sealed class HtmlImageLoadEventArgs : EventArgs
    {
        private bool bool_0;
        private readonly Dictionary<string, string> dictionary_0;
        private readonly HtmlImageLoadCallback htmlImageLoadCallback_0;
        private readonly string string_0;

        internal HtmlImageLoadEventArgs(string src, Dictionary<string, string> attributes, HtmlImageLoadCallback callback)
        {
            this.string_0 = src;
            this.dictionary_0 = attributes;
            this.htmlImageLoadCallback_0 = callback;
        }

        public void Callback()
        {
            this.bool_0 = true;
            this.htmlImageLoadCallback_0(null, null, new RRect());
        }

        public void Callback(object image)
        {
            ArgChecker.AssertArgNotNull(image, "image");
            this.bool_0 = true;
            this.htmlImageLoadCallback_0(null, image, RRect.Empty);
        }

        public void Callback(string path)
        {
            ArgChecker.AssertArgNotNullOrEmpty(path, "path");
            this.bool_0 = true;
            this.htmlImageLoadCallback_0(path, null, RRect.Empty);
        }

        public void Callback(object image, double x, double y, double width, double height)
        {
            ArgChecker.AssertArgNotNull(image, "image");
            this.bool_0 = true;
            this.htmlImageLoadCallback_0(null, image, new RRect(x, y, width, height));
        }

        public void Callback(string path, double x, double y, double width, double height)
        {
            ArgChecker.AssertArgNotNullOrEmpty(path, "path");
            this.bool_0 = true;
            this.htmlImageLoadCallback_0(path, null, new RRect(x, y, width, height));
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return this.dictionary_0;
            }
        }

        public bool Handled
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public string Src
        {
            get
            {
                return this.string_0;
            }
        }
    }
}

