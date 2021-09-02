namespace DSkin.DirectUI
{
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiProgressBar : DuiLabel
    {
        private Color[] color_3 = new Color[] { Color.FromArgb(200, 200, 200) };
        private DSkinBrush dskinBrush_1;
        private float float_1 = 90f;
        private ForeImageDrawModes foreImageDrawModes_0 = ForeImageDrawModes.Normal;
        private Image image_1;
        private int int_3 = 100;
        private int int_4 = 0;
        private int int_5 = 0;
        private Padding padding_2 = new Padding(5);
        private string string_3 = "0'%'";

        [Description("Value改变之后发生")]
        public event EventHandler ValueChanged;

        public DuiProgressBar()
        {
            this.Size = new Size(100, 20);
            this.IsDrawText = false;
            this.AutoSize = false;
        }

        protected override void Dispose(bool disposing)
        {
            ImageAnimator.StopAnimate(this.image_1, new EventHandler(this.method_30));
            base.Dispose(disposing);
        }

        private void method_30(object sender, EventArgs e)
        {
            MethodInvoker method = null;
            if ((this.Visible && !base.IsDisposed) && (this.image_1 != null))
            {
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
            this.Invalidate();
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = (int) (((1.0 * (this.int_5 - this.int_4)) / ((double) (this.int_3 - this.int_4))) * base.Width);
            if (width > 0)
            {
                if (this.dskinBrush_1 != null)
                {
                    g.FillRectangle(this.dskinBrush_1.Brush, new Rectangle(0, 0, width, base.Height));
                }
                else if (this.image_1 == null)
                {
                    ControlRender.DrawGradientColor(g, this.color_3, this.float_1, new Rectangle(0, 0, width, base.Height));
                }
                else
                {
                    switch (this.foreImageDrawModes_0)
                    {
                        case ForeImageDrawModes.Stretch:
                            g.DrawImage(this.image_1, new Rectangle(0, 0, width, base.Height));
                            break;

                        case ForeImageDrawModes.Sudoku:
                            width = ((int) (((1.0 * (this.int_5 - this.int_4)) / ((double) (this.int_3 - this.int_4))) * (base.Width - this.padding_2.Horizontal))) + this.padding_2.Horizontal;
                            ControlRender.SudokuDrawImage(g, this.image_1, new Rectangle(0, 0, width, base.Height), this.padding_2, e.ClipRectangle);
                            break;

                        case ForeImageDrawModes.Normal:
                            g.DrawImage(this.image_1, new Rectangle(0, 0, width, base.Height), new Rectangle(0, 0, width, base.Height), GraphicsUnit.Pixel);
                            break;

                        case ForeImageDrawModes.Tile:
                        {
                            using (TextureBrush brush = new TextureBrush(this.image_1, WrapMode.Tile))
                            {
                                g.FillRectangle(brush, new Rectangle(0, 0, width, base.Height));
                                break;
                            }
                        }
                        case ForeImageDrawModes.Translate:
                            g.DrawImage(this.image_1, new Rectangle(0, 0, width, base.Height), new Rectangle(this.image_1.Width - width, 0, width, base.Height), GraphicsUnit.Pixel);
                            break;
                    }
                    ImageAnimator.UpdateFrames(this.image_1);
                }
            }
            base.OnPrePaint(e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        [DefaultValue(false)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [Description("自定义前景进度刷"), DefaultValue((string) null)]
        public DSkinBrush ForeBrush
        {
            get
            {
                return this.dskinBrush_1;
            }
            set
            {
                if (this.dskinBrush_1 != value)
                {
                    this.dskinBrush_1 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("滚动条前景色"), Category("DuiProgressBar")]
        public Color[] ForeColors
        {
            get
            {
                return this.color_3;
            }
            set
            {
                if (this.color_3 != value)
                {
                    this.color_3 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DuiProgressBar"), Description("前景渐变色角度"), DefaultValue(90)]
        public float ForeColorsAngle
        {
            get
            {
                return this.float_1;
            }
            set
            {
                if (this.float_1 != value)
                {
                    this.float_1 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DuiProgressBar"), Description("前景图片"), DefaultValue((string) null)]
        public Image ForeImage
        {
            get
            {
                return this.image_1;
            }
            set
            {
                if (this.image_1 != value)
                {
                    this.image_1 = value;
                    if (!(((this.image_1 == null) || !ImageAnimator.CanAnimate(this.image_1)) || base.DesignMode))
                    {
                        ImageAnimator.Animate(this.image_1, new EventHandler(this.method_30));
                    }
                    this.Invalidate();
                }
            }
        }

        [Description("前景图片绘制模式"), DefaultValue(typeof(ForeImageDrawModes), "Normal"), Category("外观")]
        public ForeImageDrawModes ForeImageDrawMode
        {
            get
            {
                return this.foreImageDrawModes_0;
            }
            set
            {
                if (this.foreImageDrawModes_0 != value)
                {
                    this.foreImageDrawModes_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Padding), "5,5,5,5"), Description("前景图片九宫格分割宽度"), Category("DuiProgressBar")]
        public Padding ForeImagePartitionWidth
        {
            get
            {
                return this.padding_2;
            }
            set
            {
                if (this.padding_2 != value)
                {
                    this.padding_2 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue("0'%'"), Description("自定义显示数值格式")]
        public string Format
        {
            get
            {
                return this.string_3;
            }
            set
            {
                if (this.string_3 != value)
                {
                    this.string_3 = value;
                    this.Text = this.int_5.ToString(this.string_3);
                }
            }
        }

        [DefaultValue(false)]
        public override bool IsDrawText
        {
            get
            {
                return base.IsDrawText;
            }
            set
            {
                base.IsDrawText = value;
            }
        }

        [Category("DuiProgressBar"), DefaultValue(100), Description("最大值")]
        public int Maximum
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = value;
                    base.OnPropertyChanged("Maximum");
                }
            }
        }

        [DefaultValue(0), Description("最小值"), Category("DuiProgressBar")]
        public int Minimum
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.int_4 = value;
                    base.OnPropertyChanged("Minimum");
                }
            }
        }

        [Category("DuiProgressBar"), DefaultValue(0), Description("当前指示数值")]
        public int Value
        {
            get
            {
                return this.int_5;
            }
            set
            {
                if (this.int_5 != value)
                {
                    this.int_5 = value;
                    if (value > this.int_3)
                    {
                        this.int_5 = this.int_3;
                    }
                    if (value < this.int_4)
                    {
                        this.int_5 = this.int_4;
                    }
                    this.Text = value.ToString(this.string_3);
                    this.OnValueChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("Value");
                }
            }
        }
    }
}

