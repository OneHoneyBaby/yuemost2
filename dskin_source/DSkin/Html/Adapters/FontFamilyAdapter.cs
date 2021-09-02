namespace DSkin.Html.Adapters
{
    using System;
    using System.Drawing;

    public sealed class FontFamilyAdapter : RFontFamily
    {
        private readonly System.Drawing.FontFamily fontFamily_0;

        public FontFamilyAdapter(System.Drawing.FontFamily fontFamily)
        {
            this.fontFamily_0 = fontFamily;
        }

        public System.Drawing.FontFamily FontFamily
        {
            get
            {
                return this.fontFamily_0;
            }
        }

        public override string Name
        {
            get
            {
                return this.fontFamily_0.Name;
            }
        }
    }
}

