namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;

    public class SingleColor : IImageEffect
    {
        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            ImageEffects.SingleColor(bmp);
            return bmp;
        }
    }
}

