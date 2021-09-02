namespace DSkin.Controls
{
    using System;
    using System.Drawing;

    public class ColorChangedEventArgs : EventArgs
    {
        private System.Drawing.Color color_0;

        public ColorChangedEventArgs(System.Drawing.Color clr)
        {
            this.color_0 = clr;
        }

        public System.Drawing.Color Color
        {
            get
            {
                return this.color_0;
            }
        }
    }
}

