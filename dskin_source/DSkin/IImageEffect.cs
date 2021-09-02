namespace DSkin
{
    using System.Drawing;

    public interface IImageEffect
    {
        Bitmap DoImageEffect(Rectangle rect, Bitmap bmp);
    }
}

