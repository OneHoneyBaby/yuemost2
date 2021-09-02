namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class KeywordsStyle
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private bool bool_1;
        [CompilerGenerated]
        private System.Drawing.Color color_0;
        [CompilerGenerated]
        private System.Drawing.Font font_0;
        [CompilerGenerated]
        private string string_0;

        public System.Drawing.Color Color
        {
            [CompilerGenerated]
            get
            {
                return this.color_0;
            }
            [CompilerGenerated]
            set
            {
                this.color_0 = value;
            }
        }

        [DefaultValue((string) null)]
        public System.Drawing.Font Font
        {
            [CompilerGenerated]
            get
            {
                return this.font_0;
            }
            [CompilerGenerated]
            set
            {
                this.font_0 = value;
            }
        }

        [DefaultValue(false)]
        public bool IgnoreCase
        {
            [CompilerGenerated]
            get
            {
                return this.bool_1;
            }
            [CompilerGenerated]
            set
            {
                this.bool_1 = value;
            }
        }

        [DefaultValue(false)]
        public bool IsRegex
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }

        public string Keywords
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return this.Keywords;
            }
        }
    }
}

