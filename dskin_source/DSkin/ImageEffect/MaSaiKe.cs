namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class MaSaiKe : IImageEffect
    {
        [CompilerGenerated]
        private int int_0;

        public MaSaiKe()
        {
            this.Size = 10;
        }

        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.MaSaiKe(bmp, this.Size);
            return bmp;
        }

        public int Size
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

