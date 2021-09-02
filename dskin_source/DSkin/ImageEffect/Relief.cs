namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;

    public class Relief : IImageEffect
    {
        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.Relief(bmp);
            return bmp;
        }
    }
}

