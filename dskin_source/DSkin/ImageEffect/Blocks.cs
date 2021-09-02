namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;

    public class Blocks : IImageEffect
    {
        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.Blocks(bmp);
            return bmp;
        }
    }
}

