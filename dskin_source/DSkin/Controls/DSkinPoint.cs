namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class DSkinPoint
    {
        [CompilerGenerated]
        private int int_0;
        [CompilerGenerated]
        private int int_1;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                return (this.X.ToString() + "," + this.Y);
            }
        }

        [Browsable(false)]
        public System.Drawing.Point Point
        {
            get
            {
                return new System.Drawing.Point(this.X, this.Y);
            }
        }

        public int X
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

        public int Y
        {
            [CompilerGenerated]
            get
            {
                return this.int_1;
            }
            [CompilerGenerated]
            set
            {
                this.int_1 = value;
            }
        }
    }
}

