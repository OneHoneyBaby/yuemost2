namespace DSkin.Html.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public sealed class HtmlLinkClickedEventArgs : EventArgs
    {
        private bool bool_0;
        private readonly Dictionary<string, string> dictionary_0;
        private readonly string string_0;

        public HtmlLinkClickedEventArgs(string link, Dictionary<string, string> attributes)
        {
            this.string_0 = link;
            this.dictionary_0 = attributes;
        }

        public override string ToString()
        {
            return string.Format("Link: {0}, Handled: {1}", this.string_0, this.bool_0);
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

        public string Link
        {
            get
            {
                return this.string_0;
            }
        }
    }
}

