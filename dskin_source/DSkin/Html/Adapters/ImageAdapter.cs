namespace DSkin.Html.Adapters
{
    using System;
    using System.Drawing;

    public sealed class ImageAdapter : RImage
    {
        private readonly System.Drawing.Image image_0;

        public ImageAdapter(System.Drawing.Image image)
        {
            this.image_0 = image;
        }

        public override void Dispose()
        {
            this.image_0.Dispose();
        }

        public override double Height
        {
            get
            {
                return (double) this.image_0.Height;
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.image_0;
            }
        }

        public override double Width
        {
            get
            {
                return (double) this.image_0.Width;
            }
        }
    }
}

