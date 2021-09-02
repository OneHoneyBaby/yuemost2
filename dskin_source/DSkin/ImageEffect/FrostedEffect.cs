namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;

    public class FrostedEffect : IImageEffect
    {
        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            return ImageEffects.FrostedEffect(bmp, 3, 8, 15);
        }
    }
}

