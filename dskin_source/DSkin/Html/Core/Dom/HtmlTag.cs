namespace DSkin.Html.Core.Dom
{
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class HtmlTag
    {
        private readonly bool bool_0;
        private Dictionary<string, string> dictionary_0;
        private readonly string string_0;

        public HtmlTag(string name, bool isSingle, Dictionary<string, string> attributes = null)
        {
            ArgChecker.AssertArgNotNullOrEmpty(name, "name");
            this.string_0 = name;
            this.bool_0 = isSingle;
            this.dictionary_0 = attributes;
        }

        public bool HasAttribute(string attribute)
        {
            return ((this.dictionary_0 != null) && this.dictionary_0.ContainsKey(attribute));
        }

        public bool HasAttributes()
        {
            return ((this.dictionary_0 != null) && (this.dictionary_0.Count > 0));
        }

        public override string ToString()
        {
            return string.Format("<{0}>", this.string_0);
        }

        public string TryGetAttribute(string attribute, string defaultValue = null)
        {
            return (((this.dictionary_0 == null) || !this.dictionary_0.ContainsKey(attribute)) ? defaultValue : this.dictionary_0[attribute]);
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return this.dictionary_0;
            }
            internal set
            {
                this.dictionary_0 = value;
            }
        }

        public bool IsSingle
        {
            get
            {
                return this.bool_0;
            }
        }

        public string Name
        {
            get
            {
                return this.string_0;
            }
        }
    }
}

