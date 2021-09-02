namespace DSkin.DirectUI
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class StartPaintEventArgs : EventArgs
    {
        [CompilerGenerated]
        private Rectangle rectangle_0;

        public StartPaintEventArgs(Rectangle InvalidateRect)
        {
            this.InvalidateRect = InvalidateRect;
        }

        public Rectangle InvalidateRect
        {
            [CompilerGenerated]
            get
            {
                return this.rectangle_0;
            }
            [CompilerGenerated]
            set
            {
                this.rectangle_0 = value;
            }
        }
    }
}

