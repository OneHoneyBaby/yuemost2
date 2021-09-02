namespace DSkin.DirectUI
{
    using DSkin.Common;
    using System;

    public class TextLine : Collection<ILayoutElement>
    {
        private int int_0;

        public int Height
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }
    }
}

