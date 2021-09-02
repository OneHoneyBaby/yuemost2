namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class GradualAlpha : IImageEffect
    {
        [CompilerGenerated]
        private int int_0;

        public GradualAlpha()
        {
            this.Direction = 0;
        }

        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.GradualAlpha(new Rectangle(0, 0, bmp.Width, bmp.Height), this.Direction, bmp);
            return bmp;
        }

        public int Direction
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

