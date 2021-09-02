namespace DSkin.Html.Core.Entities
{
    using DSkin.Html.Core;
    using System;
    using System.Collections.Generic;

    public sealed class HtmlStylesheetLoadEventArgs : EventArgs
    {
        private CssData cssData_0;
        private readonly Dictionary<string, string> dictionary_0;
        private readonly string string_0;
        private string string_1;
        private string string_2;

        internal HtmlStylesheetLoadEventArgs(string src, Dictionary<string, string> attributes)
        {
            this.string_0 = src;
            this.dictionary_0 = attributes;
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return this.dictionary_0;
            }
        }

        public string SetSrc
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        public string SetStyleSheet
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        public CssData SetStyleSheetData
        {
            get
            {
                return this.cssData_0;
            }
            set
            {
                this.cssData_0 = value;
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

