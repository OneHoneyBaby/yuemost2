namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ProgressBar))]
    public class DSkinProgressBar : DSkinLabel
    {
        private DuiProgressBar duiProgressBar_0;

        [Description("Value改变之后发生")]
        public event EventHandler ValueChanged;

        public DSkinProgressBar()
        {
            this.duiProgressBar_0 = (DuiProgressBar) base.InnerDuiControl;
            this.AutoSize = false;
            this.duiProgressBar_0.ValueChanged += new EventHandler(this.duiProgressBar_0_ValueChanged);
        }

        private void duiProgressBar_0_ValueChanged(object sender, EventArgs e)
        {
            this.OnValueChanged(EventArgs.Empty);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiProgressBar();
            }
        }

        [DefaultValue((string) null), Description("自定义前景进度刷")]
        public DSkinBrush ForeBrush
        {
            get
            {
                return this.duiProgressBar_0.ForeBrush;
            }
            set
            {
                this.duiProgressBar_0.ForeBrush = value;
            }
        }

        [Description("进度条前景色集合"), Category("DSkin")]
        public Color[] ForeColors
        {
            get
            {
                return this.duiProgressBar_0.ForeColors;
            }
            set
            {
                this.duiProgressBar_0.ForeColors = value;
            }
        }

        [Description("前景渐变色角度"), DefaultValue(90), Category("DSkin")]
        public float ForeColorsAngle
        {
            get
            {
                return this.duiProgressBar_0.ForeColorsAngle;
            }
            set
            {
                this.duiProgressBar_0.ForeColorsAngle = value;
            }
        }

        [DefaultValue((string) null), Category("DSkin"), Description("前景图片")]
        public Image ForeImage
        {
            get
            {
                return this.duiProgressBar_0.ForeImage;
            }
            set
            {
                this.duiProgressBar_0.ForeImage = value;
            }
        }

        [Description("前景图片绘制模式"), Category("DSkin"), DefaultValue(typeof(ForeImageDrawModes), "Normal")]
        public ForeImageDrawModes ForeImageDrawMode
        {
            get
            {
                return this.duiProgressBar_0.ForeImageDrawMode;
            }
            set
            {
                this.duiProgressBar_0.ForeImageDrawMode = value;
            }
        }

        [DefaultValue(typeof(Padding), "5,5,5,5"), Description("前景图片九宫格分割宽度"), Category("DSkin")]
        public Padding ForeImagePartitionWidth
        {
            get
            {
                return this.duiProgressBar_0.ForeImagePartitionWidth;
            }
            set
            {
                this.duiProgressBar_0.ForeImagePartitionWidth = value;
            }
        }

        [Description("自定义显示数值格式"), DefaultValue("0'%'")]
        public string Format
        {
            get
            {
                return this.duiProgressBar_0.Format;
            }
            set
            {
                this.duiProgressBar_0.Format = value;
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

        [Description("最大值"), DefaultValue(100), Category("DSkin")]
        public int Maximum
        {
            get
            {
                return this.duiProgressBar_0.Maximum;
            }
            set
            {
                this.duiProgressBar_0.Maximum = value;
            }
        }

        [Category("DSkin"), Description("最小值"), DefaultValue(0)]
        public int Minimum
        {
            get
            {
                return this.duiProgressBar_0.Minimum;
            }
            set
            {
                this.duiProgressBar_0.Minimum = value;
            }
        }

        [Category("DSkin"), DefaultValue(0), Description("当前指示数值")]
        public int Value
        {
            get
            {
                return this.duiProgressBar_0.Value;
            }
            set
            {
                this.duiProgressBar_0.Value = value;
            }
        }
    }
}

