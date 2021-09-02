namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class AnimationEventArgs : EventArgs
    {
        private Bitmap bitmap_0;
        private bool bool_0;
        private int int_0;
        [CompilerGenerated]
        private Point point_0;

        public AnimationEventArgs(Bitmap current, int index, bool final, Point offset)
        {
            this.bitmap_0 = current;
            this.int_0 = index;
            this.bool_0 = final;
            this.LocationOffset = offset;
        }

        public Bitmap CurrentFrame
        {
            get
            {
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }

        public int CurrentIndex
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

        public bool IsFinal
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public Point LocationOffset
        {
            [CompilerGenerated]
            get
            {
                return this.point_0;
            }
            [CompilerGenerated]
            set
            {
                this.point_0 = value;
            }
        }
    }
}

