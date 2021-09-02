namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class RotateZoomEffect : IEffects, IDisposable
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private Bitmap bitmap_2;
        private bool bool_0 = true;
        private bool bool_1 = false;
        private float float_0 = 15f;

        public void Dispose()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            if (this.bitmap_1 != null)
            {
                this.bitmap_1.Dispose();
                this.bitmap_1 = null;
            }
            GC.SuppressFinalize(this);
        }

        public Bitmap DoEffect(out Point offset)
        {
            Graphics graphics;
            if (this.bitmap_1 == null)
            {
                if (this.bitmap_2.Width > this.bitmap_2.Height)
                {
                    this.bitmap_0 = new Bitmap(this.bitmap_2.Width, this.bitmap_2.Width);
                    this.bitmap_1 = new Bitmap(this.bitmap_0.Width, this.bitmap_0.Width);
                }
                else
                {
                    this.bitmap_0 = new Bitmap(this.bitmap_2.Height, this.bitmap_2.Height);
                    this.bitmap_1 = new Bitmap(this.bitmap_0.Height, this.bitmap_0.Height);
                }
                using (graphics = Graphics.FromImage(this.bitmap_1))
                {
                    graphics.DrawImage(this.bitmap_2, (int) ((this.bitmap_0.Width - this.bitmap_2.Width) / 2), (int) ((this.bitmap_0.Height - this.bitmap_2.Height) / 2));
                }
            }
            offset = new Point((this.bitmap_2.Width - this.bitmap_1.Width) / 2, (this.bitmap_2.Height - this.bitmap_1.Height) / 2);
            using (graphics = Graphics.FromImage(this.bitmap_0))
            {
                if (!(((this.float_0 > 360f) || !this.bool_0) ? (this.bool_0 || (this.float_0 <= 0f)) : false))
                {
                    this.bool_1 = false;
                    graphics.Clear(Color.Transparent);
                    graphics.TranslateTransform((float) (this.bitmap_0.Width / 2), (float) (this.bitmap_0.Height / 2));
                    graphics.RotateTransform(this.float_0);
                    graphics.ScaleTransform((this.float_0 / 360f) / 1f, (this.float_0 / 360f) / 1f);
                    graphics.TranslateTransform((float) (-this.bitmap_0.Width / 2), (float) (-this.bitmap_0.Height / 2));
                    graphics.DrawImage(this.bitmap_1, 0, 0);
                    graphics.ResetTransform();
                    graphics.Save();
                    if (this.bool_0)
                    {
                        this.float_0 += 15f;
                    }
                    else
                    {
                        this.float_0 -= 15f;
                    }
                }
                else
                {
                    this.bool_1 = true;
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(this.bitmap_1, 0, 0);
                }
            }
            return this.bitmap_0;
        }

        public void Reset()
        {
            if (this.bool_0)
            {
                this.float_0 = 15f;
            }
            else
            {
                this.float_0 = 360f;
            }
            if (this.bitmap_1 != null)
            {
                this.bitmap_1.Dispose();
                this.bitmap_1 = null;
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
        }

        public bool CanDesc
        {
            get
            {
                return true;
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

        public string Name
        {
            get
            {
                return "旋转放大";
            }
        }

        public Bitmap Original
        {
            get
            {
                return this.bitmap_2;
            }
            set
            {
                this.bitmap_2 = value;
            }
        }
    }
}

