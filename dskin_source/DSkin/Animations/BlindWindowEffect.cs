namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;

    public class BlindWindowEffect : IEffects, IDisposable
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private bool bool_0;
        private bool bool_1 = false;
        private float float_0 = 50f;
        private int int_0 = 0;

        public void Dispose()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            GC.SuppressFinalize(this);
        }

        public Bitmap DoEffect(out Point offset)
        {
            offset = new Point();
            if ((this.bitmap_0 == null) || (this.bitmap_0.Size != this.bitmap_1.Size))
            {
                this.bitmap_0 = new Bitmap(this.bitmap_1.Width, this.bitmap_1.Height);
            }
            using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
            {
                if (this.int_0 == 0)
                {
                    graphics.Clear(Color.Transparent);
                }
                if (this.int_0 < this.float_0)
                {
                    this.bool_1 = false;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        using (TextureBrush brush = new TextureBrush(this.bitmap_1))
                        {
                            RectangleF ef;
                            int num;
                            if (this.bool_0)
                            {
                                for (num = 0; num < Math.Ceiling((double) (((float) this.bitmap_0.Height) / this.float_0)); num++)
                                {
                                    ef = new RectangleF(0f, (this.float_0 * num) + this.int_0, (float) this.bitmap_0.Width, 1f);
                                    path.AddRectangle(ef);
                                }
                            }
                            else
                            {
                                for (num = 0; num < Math.Ceiling((double) (((float) this.bitmap_0.Height) / this.float_0)); num++)
                                {
                                    ef = new RectangleF(0f, (this.float_0 * num) + this.int_0, (float) this.bitmap_0.Width, 1f);
                                    path.AddRectangle(ef);
                                }
                            }
                            graphics.FillPath(brush, path);
                        }
                    }
                    this.int_0++;
                }
                else
                {
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(this.bitmap_1, 0, 0);
                    this.bool_1 = true;
                }
            }
            return this.bitmap_0;
        }

        public void Reset()
        {
            this.int_0 = 0;
        }

        public bool CanDesc
        {
            get
            {
                return false;
            }
        }

        public bool IsAsc
        {
            get
            {
                return this.IsAsc;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public bool IsFinal
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public float LineHeight
        {
            get
            {
                return this.float_0;
            }
            set
            {
                this.float_0 = value;
            }
        }

        public string Name
        {
            get
            {
                return "百叶窗";
            }
        }

        public Bitmap Original
        {
            get
            {
                return this.bitmap_1;
            }
            set
            {
                this.bitmap_1 = value;
            }
        }
    }
}

