namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [Designer("DSkin.Design.DSkinPictureBoxDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), ToolboxItem(true), ToolboxBitmap(typeof(PictureBox))]
    public class DSkinPictureBox : DSkinBaseControl
    {
        private DuiPictureBox duiPictureBox_0;

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler FontChanged
        {
            add
            {
                base.FontChanged += value;
            }
            remove
            {
                base.FontChanged -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ForeColorChanged
        {
            add
            {
                base.ForeColorChanged += value;
            }
            remove
            {
                base.ForeColorChanged -= value;
            }
        }

        [Description("当前帧改变之后发生")]
        public event EventHandler FrameChanged;

        public DSkinPictureBox()
        {
            EventHandler handler = null;
            this.duiPictureBox_0 = (DuiPictureBox) base.InnerDuiControl;
            handler = new EventHandler(this.method_6);
            this.duiPictureBox_0.FrameChanged += handler;
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            this.OnFrameChanged(EventArgs.Empty);
        }

        protected virtual void OnFrameChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        public void Play()
        {
            this.duiPictureBox_0.Play();
        }

        public void Stop()
        {
            this.duiPictureBox_0.Stop();
        }

        [Browsable(false)]
        public int CurrentFrame
        {
            get
            {
                return this.duiPictureBox_0.CurrentFrame;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiPictureBox();
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Category("DSkin"), Description("图片，支持Gif播放")]
        public System.Drawing.Image Image
        {
            get
            {
                return this.duiPictureBox_0.Image;
            }
            set
            {
                this.duiPictureBox_0.Image = value;
            }
        }

        [Category("DSkin"), Description("图片集")]
        public System.Drawing.Image[] Images
        {
            get
            {
                return this.duiPictureBox_0.Images;
            }
            set
            {
                this.duiPictureBox_0.Images = value;
            }
        }

        [DefaultValue(40), Category("DSkin"), Description("多张图片播放定时器的时间间隔")]
        public int Interval
        {
            get
            {
                return this.duiPictureBox_0.Interval;
            }
            set
            {
                this.duiPictureBox_0.Interval = value;
            }
        }

        [DefaultValue(typeof(PictureBoxSizeMode), "Normal"), Description("处理图像和控件大小"), Category("DSkin")]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return this.duiPictureBox_0.SizeMode;
            }
            set
            {
                this.duiPictureBox_0.SizeMode = value;
            }
        }
    }
}

