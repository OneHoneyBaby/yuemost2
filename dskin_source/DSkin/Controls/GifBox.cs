namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class GifBox : Control
    {
        private bool bool_0 = false;
        private Color color_0 = Color.Transparent;
        private EventHandler eventHandler_0;
        private System.Drawing.Image image_0;
        private Rectangle rectangle_0;

        public GifBox()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.CacheText | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.Opaque, false);
            this.Cursor = Cursors.Arrow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this.eventHandler_0 = null;
                this.bool_0 = false;
                if (this.image_0 != null)
                {
                    this.image_0 = null;
                }
            }
        }

        private bool IhnMamddrC()
        {
            return this.bool_0;
        }

        private Rectangle method_0()
        {
            if ((this.rectangle_0 == Rectangle.Empty) && (this.image_0 != null))
            {
                if ((this.Image.Width <= base.Width) && (this.Image.Height <= base.Height))
                {
                    this.rectangle_0.X = (base.Width - this.image_0.Width) / 2;
                    this.rectangle_0.Y = (base.Height - this.image_0.Height) / 2;
                    this.rectangle_0.Width = this.image_0.Width;
                    this.rectangle_0.Height = this.image_0.Height;
                }
                else if (this.Image.Width > base.Width)
                {
                    int height = (base.Width * this.image_0.Height) / this.image_0.Width;
                    this.rectangle_0 = new Rectangle(0, 0, base.Width, height);
                }
                else
                {
                    int width = (base.Height * this.image_0.Width) / this.image_0.Height;
                    this.rectangle_0 = new Rectangle(0, 0, width, base.Height);
                }
            }
            return this.rectangle_0;
        }

        private EventHandler method_1()
        {
            if (this.eventHandler_0 == null)
            {
                this.eventHandler_0 = new EventHandler(this.method_6);
            }
            return this.eventHandler_0;
        }

        private void method_2()
        {
            if (this.IhnMamddrC())
            {
                ImageAnimator.Animate(this.image_0, this.method_1());
            }
        }

        private void method_3()
        {
            if (this.IhnMamddrC())
            {
                ImageAnimator.StopAnimate(this.image_0, this.method_1());
            }
        }

        private void method_4()
        {
            if (this.IhnMamddrC())
            {
                ImageAnimator.UpdateFrames(this.image_0);
            }
        }

        private void method_5()
        {
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            base.Invalidate(this.method_0());
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            this.method_3();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.image_0 != null)
            {
                this.method_4();
                e.Graphics.DrawImage(this.image_0, this.method_0(), 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel);
            }
            ControlPaint.DrawBorder(e.Graphics, base.ClientRectangle, this.color_0, ButtonBorderStyle.Solid);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.rectangle_0 = Rectangle.Empty;
            base.OnSizeChanged(e);
        }

        public Color BorderColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.method_3();
                this.image_0 = value;
                this.rectangle_0 = Rectangle.Empty;
                if (value != null)
                {
                    this.bool_0 = ImageAnimator.CanAnimate(this.image_0);
                }
                else
                {
                    this.bool_0 = false;
                }
                base.Invalidate(this.method_0());
                if (!base.DesignMode)
                {
                    this.method_2();
                }
            }
        }
    }
}

