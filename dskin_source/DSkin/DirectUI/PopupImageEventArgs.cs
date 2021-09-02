namespace DSkin.DirectUI
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class PopupImageEventArgs : EventArgs
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private System.Drawing.Image image_0;
        [CompilerGenerated]
        private int int_0;

        public bool Handled
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

        public System.Drawing.Image Image
        {
            [CompilerGenerated]
            get
            {
                return this.image_0;
            }
            [CompilerGenerated]
            set
            {
                this.image_0 = value;
            }
        }

        public int Position
        {
            [CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }
    }
}

