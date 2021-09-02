namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;

    public class NegativeImage : IImageEffect
    {
        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.NegativeImage(bmp);
            return bmp;
        }
    }
}

