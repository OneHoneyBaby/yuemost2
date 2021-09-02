namespace DSkin.Html.Core.Entities
{
    using DSkin.Html.Core.Utils;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CssBlockSelectorItem
    {
        private readonly string string_0;
        private readonly bool bool_0;
        public CssBlockSelectorItem(string @class, bool directParent)
        {
            ArgChecker.AssertArgNotNullOrEmpty(@class, "@class");
            this.string_0 = @class;
            this.bool_0 = directParent;
        }

        public string Class
        {
            get
            {
                return this.string_0;
            }
        }
        public bool DirectParent
        {
            get
            {
                return this.bool_0;
            }
        }
        public override string ToString()
        {
            return (this.string_0 + (this.bool_0 ? " > " : string.Empty));
        }
    }
}

