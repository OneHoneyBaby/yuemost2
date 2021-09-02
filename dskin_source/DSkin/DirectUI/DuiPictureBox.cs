namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiPictureBox : DuiBaseControl
    {
        private bool bool_27 = true;
        private bool bool_28 = false;
        private bool bool_29 = false;
        private System.Drawing.Image[] image_1;
        private int int_1 = 40;
        private int int_2 = 0;
        private int int_3;
        private PictureBoxSizeMode pictureBoxSizeMode_0 = PictureBoxSizeMode.Normal;
        private System.Windows.Forms.Timer timer_0;

        [Description("当前帧改变之后发生")]
        public event EventHandler FrameChanged;

        public event EventHandler SizeModeChanged;

        protected override void Dispose(bool disposing)
        {
            if (this.image_1 != null)
            {
                this.Stop();
            }
            base.Dispose(disposing);
        }

        private void method_29()
        {
            if ((this.Image != null) && (this.pictureBoxSizeMode_0 == PictureBoxSizeMode.AutoSize))
            {
                this.Size = this.Image.Size;
            }
        }

        private void method_30(object sender, EventArgs e)
        {
            MethodInvoker method = null;
            if (this.Visible && !base.IsDisposed)
            {
                if (this.int_2 > (this.int_3 - 2))
                {
                    this.int_2 = 0;
                }
                else
                {
                    this.int_2++;
                }
                if (method == null)
                {
                    method = new MethodInvoker(this.method_31);
                }
                base.BeginInvoke(method);
            }
        }

        [CompilerGenerated]
        private void method_31()
        {
            this.OnFrameChanged(EventArgs.Empty);
            this.Invalidate();
        }

        protected virtual void OnFrameChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            if ((this.image_1 != null) && (this.image_1.Length > 0))
            {
                System.Drawing.Image image = this.bool_28 ? this.image_1[this.int_2] : this.image_1[0];
                if (image != null)
                {
                    switch (this.pictureBoxSizeMode_0)
                    {
                        case PictureBoxSizeMode.Normal:
                            e.Graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                            break;

                        case PictureBoxSizeMode.StretchImage:
                            e.Graphics.DrawImage(image, new Rectangle(0, 0, base.Width, base.Height));
                            break;

                        case PictureBoxSizeMode.AutoSize:
                            e.Graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                            break;

                        case PictureBoxSizeMode.CenterImage:
                            e.Graphics.DrawImage(image, new Rectangle((base.Width - image.Width) / 2, (base.Height - image.Height) / 2, image.Width, image.Height));
                            break;

                        case PictureBoxSizeMode.Zoom:
                        {
                            Size size = image.Size;
                            float num = Math.Min((float) (((float) base.ClientRectangle.Width) / ((float) size.Width)), (float) (((float) base.ClientRectangle.Height) / ((float) size.Height)));
                            if (Math.Round((double) (((float) base.ClientRectangle.Width) / ((float) size.Width)), 2) != Math.Round((double) num, 2))
                            {
                                int width = (int) (size.Width * num);
                                e.Graphics.DrawImage(image, new Rectangle((base.Width - width) / 2, 0, width, base.Height));
                                break;
                            }
                            int height = (int) (size.Height * num);
                            e.Graphics.DrawImage(image, new Rectangle(0, (base.Height - height) / 2, base.Width, height));
                            break;
                        }
                    }
                    if (!this.bool_28)
                    {
                        ImageAnimator.UpdateFrames(this.Image);
                    }
                }
            }
            base.OnPrePaint(e);
        }

        protected virtual void OnSizeModeChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        public void Play()
        {
            if (!base.DesignMode && ((this.image_1 != null) && (this.image_1[0] != null)))
            {
                if (this.bool_28)
                {
                    if (this.timer_0 == null)
                    {
                        this.timer_0 = new System.Windows.Forms.Timer();
                        this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
                        this.timer_0.Interval = this.int_1;
                    }
                    this.timer_0.Start();
                }
                else if (this.bool_29 = ImageAnimator.CanAnimate(this.Image))
                {
                    ImageAnimator.Animate(this.Image, new EventHandler(this.method_30));
                }
            }
        }

        public void Stop()
        {
            ImageAnimator.StopAnimate(this.Image, new EventHandler(this.method_30));
            if (this.timer_0 != null)
            {
                this.timer_0.Stop();
                this.timer_0.Dispose();
                this.timer_0 = null;
            }
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (this.image_1 != null)
            {
                this.method_30(this, EventArgs.Empty);
            }
        }

        [Description("是否自动播放"), DefaultValue(true)]
        public bool AutoPlay
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                this.bool_27 = value;
            }
        }

        [Browsable(false)]
        public int CurrentFrame
        {
            get
            {
                return this.int_2;
            }
        }

        [Description("图片，支持Gif播放"), DefaultValue((string) null)]
        public System.Drawing.Image Image
        {
            get
            {
                if ((this.image_1 != null) && (this.image_1.Length > 0))
                {
                    return this.image_1[0];
                }
                return null;
            }
            set
            {
                this.bool_28 = false;
                this.int_2 = 0;
                this.Images = new System.Drawing.Image[] { value };
            }
        }

        public System.Drawing.Image[] Images
        {
            get
            {
                return this.image_1;
            }
            set
            {
                if (this.image_1 != value)
                {
                    this.Stop();
                    this.image_1 = value;
                    this.int_2 = 0;
                    this.method_29();
                    if ((this.image_1 != null) && (this.image_1.Length > 1))
                    {
                        this.bool_28 = true;
                        this.int_3 = this.image_1.Length;
                    }
                    else
                    {
                        this.bool_28 = false;
                    }
                    if (this.bool_27)
                    {
                        this.Play();
                    }
                    this.Invalidate();
                    base.OnPropertyChanged("Images");
                }
            }
        }

        [Description("多张图片播放定时器的时间间隔"), DefaultValue(40)]
        public int Interval
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
                if (this.timer_0 != null)
                {
                    this.timer_0.Interval = this.int_1;
                }
            }
        }

        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return this.pictureBoxSizeMode_0;
            }
            set
            {
                if (this.pictureBoxSizeMode_0 != value)
                {
                    this.pictureBoxSizeMode_0 = value;
                    this.method_29();
                    this.OnSizeModeChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("SizeMode");
                }
            }
        }
    }
}

