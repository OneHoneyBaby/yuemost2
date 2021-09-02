namespace DSkin.ImageEffect
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class GaussianBlur : IImageEffect
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private float float_0;

        public GaussianBlur()
        {
            this.Radius = 10f;
            this.ExpandEdge = false;
        }

        public Bitmap DoImageEffect(Rectangle rect, Bitmap bmp)
        {
            Rectangle rectangle = new Rectangle(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            ImageEffects.GaussianBlur(bmp, ref rectangle, this.Radius, this.ExpandEdge);
            return bmp;
        }

        public bool ExpandEdge
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }

        public float Radius
        {
            [CompilerGenerated]
            get
            {
                return this.float_0;
            }
            [CompilerGenerated]
            set
            {
                this.float_0 = value;
            }
        }
    }
}

