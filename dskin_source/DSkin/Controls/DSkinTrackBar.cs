namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(TrackBar)), ToolboxItem(true)]
    public class DSkinTrackBar : DSkinBaseControl
    {
        private DuiTrackBar duiTrackBar_0;

        [Description("value改变之后发生")]
        public event EventHandler ValueChanged;

        public DSkinTrackBar()
        {
            this.duiTrackBar_0 = (DuiTrackBar) base.InnerDuiControl;
            this.duiTrackBar_0.ValueChanged += new EventHandler(this.duiTrackBar_0_ValueChanged);
        }

        private void duiTrackBar_0_ValueChanged(object sender, EventArgs e)
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
                return new DuiTrackBar();
            }
        }

        [Category("外观"), DefaultValue((string) null), Description("上层图片")]
        public Image ForeImage
        {
            get
            {
                return this.duiTrackBar_0.ForeImage;
            }
            set
            {
                this.duiTrackBar_0.ForeImage = value;
            }
        }

        [Category("外观"), DefaultValue(typeof(ForeImageDrawModes), "Normal"), Description("前景图片绘制模式")]
        public ForeImageDrawModes ForeImageDrawMode
        {
            get
            {
                return this.duiTrackBar_0.ForeImageDrawMode;
            }
            set
            {
                this.duiTrackBar_0.ForeImageDrawMode = value;
            }
        }

        [Description("前景图片九宫格分割宽度"), DefaultValue(typeof(Padding), "5,5,5,5"), Category("外观")]
        public Padding ForeImagePartitionWidth
        {
            get
            {
                return this.duiTrackBar_0.ForeImagePartitionWidth;
            }
            set
            {
                this.duiTrackBar_0.ForeImagePartitionWidth = value;
            }
        }

        [Description("主线两端到边框的距离"), Category("DSkinTrackBar")]
        public int InnerPadding
        {
            get
            {
                return this.duiTrackBar_0.InnerPadding;
            }
            set
            {
                this.duiTrackBar_0.InnerPadding = value;
            }
        }

        [Description("指示按钮是否为椭圆"), Category("DSkinTrackBar")]
        public bool IsEllipsePointButton
        {
            get
            {
                return this.duiTrackBar_0.IsEllipsePointButton;
            }
            set
            {
                this.duiTrackBar_0.IsEllipsePointButton = value;
            }
        }

        [Category("DSkinTrackBar"), Description("主线边框颜色")]
        public Color MainLineBorderColor
        {
            get
            {
                return this.duiTrackBar_0.MainLineBorderColor;
            }
            set
            {
                this.duiTrackBar_0.MainLineBorderColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Pen MainLineBorderPen
        {
            get
            {
                return this.duiTrackBar_0.MainLineBorderPen;
            }
            set
            {
                this.duiTrackBar_0.MainLineBorderPen = value;
            }
        }

        [Category("DSkinTrackBar"), Description("主线边框宽度")]
        public int MainLineBorderWidth
        {
            get
            {
                return this.duiTrackBar_0.MainLineBorderWidth;
            }
            set
            {
                this.duiTrackBar_0.MainLineBorderWidth = value;
            }
        }

        [Description("自定义主线填充刷")]
        public DSkinBrush MainLineBrushDown
        {
            get
            {
                return this.duiTrackBar_0.MainLineBrushDown;
            }
            set
            {
                this.duiTrackBar_0.MainLineBrushDown = value;
            }
        }

        [Description("自定义主线填充刷")]
        public DSkinBrush MainLineBrushUp
        {
            get
            {
                return this.duiTrackBar_0.MainLineBrushUp;
            }
            set
            {
                this.duiTrackBar_0.MainLineBrushUp = value;
            }
        }

        [Description("主线填充颜色"), Category("DSkinTrackBar")]
        public Color MainLineColorDown
        {
            get
            {
                return this.duiTrackBar_0.MainLineColorDown;
            }
            set
            {
                this.duiTrackBar_0.MainLineColorDown = value;
            }
        }

        [Description("主线填充颜色"), Category("DSkinTrackBar")]
        public Color MainLineColorUp
        {
            get
            {
                return this.duiTrackBar_0.MainLineColorUp;
            }
            set
            {
                this.duiTrackBar_0.MainLineColorUp = value;
            }
        }

        [Category("DSkinTrackBar"), Description("主线宽度")]
        public int MainLineWidth
        {
            get
            {
                return this.duiTrackBar_0.MainLineWidth;
            }
            set
            {
                this.duiTrackBar_0.MainLineWidth = value;
            }
        }

        [Category("DSkinTrackBar"), Description("最大值")]
        public int Maximum
        {
            get
            {
                return this.duiTrackBar_0.Maximum;
            }
            set
            {
                this.duiTrackBar_0.Maximum = value;
            }
        }

        [Description("最小值"), Category("DSkinTrackBar")]
        public int Minimum
        {
            get
            {
                return this.duiTrackBar_0.Minimum;
            }
            set
            {
                this.duiTrackBar_0.Minimum = value;
            }
        }

        [Category("DSkinTrackBar"), Description("控件方向")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.duiTrackBar_0.Orientation;
            }
            set
            {
                this.duiTrackBar_0.Orientation = value;
            }
        }

        [Description("指示按钮边框颜色"), Category("DSkinTrackBar")]
        public Color PointButtonBorderColor
        {
            get
            {
                return this.duiTrackBar_0.PointButtonBorderColor;
            }
            set
            {
                this.duiTrackBar_0.PointButtonBorderColor = value;
            }
        }

        [Category("DSkinTrackBar"), Description("指示按钮边框宽度")]
        public int PointButtonBorderWidth
        {
            get
            {
                return this.duiTrackBar_0.PointButtonBorderWidth;
            }
            set
            {
                this.duiTrackBar_0.PointButtonBorderWidth = value;
            }
        }

        [Category("DSkinTrackBar"), Description("指示按钮填充颜色")]
        public Color PointButtonHoverColor
        {
            get
            {
                return this.duiTrackBar_0.PointButtonHoverColor;
            }
            set
            {
                this.duiTrackBar_0.PointButtonHoverColor = value;
            }
        }

        [Description("指示按钮图片"), Category("DSkinTrackBar")]
        public Image PointButtonHoverImage
        {
            get
            {
                return this.duiTrackBar_0.PointButtonHoverImage;
            }
            set
            {
                this.duiTrackBar_0.PointButtonHoverImage = value;
            }
        }

        [Category("DSkinTrackBar"), Description("指示按钮填充颜色")]
        public Color PointButtonNormalColor
        {
            get
            {
                return this.duiTrackBar_0.PointButtonNormalColor;
            }
            set
            {
                this.duiTrackBar_0.PointButtonNormalColor = value;
            }
        }

        [Description("指示按钮图片"), Category("DSkinTrackBar")]
        public Image PointButtonNormalImage
        {
            get
            {
                return this.duiTrackBar_0.PointButtonNormalImage;
            }
            set
            {
                this.duiTrackBar_0.PointButtonNormalImage = value;
            }
        }

        [Description("指示按钮填充颜色"), Category("DSkinTrackBar")]
        public Color PointButtonPressColor
        {
            get
            {
                return this.duiTrackBar_0.PointButtonPressColor;
            }
            set
            {
                this.duiTrackBar_0.PointButtonPressColor = value;
            }
        }

        [Description("指示按钮图片"), Category("DSkinTrackBar")]
        public Image PointButtonPressImage
        {
            get
            {
                return this.duiTrackBar_0.PointButtonPressImage;
            }
            set
            {
                this.duiTrackBar_0.PointButtonPressImage = value;
            }
        }

        [Category("DSkinTrackBar"), Description("指示按钮大小")]
        public Size PointButtonSize
        {
            get
            {
                return this.duiTrackBar_0.PointButtonSize;
            }
            set
            {
                this.duiTrackBar_0.PointButtonSize = value;
            }
        }

        [Category("DSkinTrackBar"), Description("当前指示数值")]
        public int Value
        {
            get
            {
                return this.duiTrackBar_0.Value;
            }
            set
            {
                this.duiTrackBar_0.Value = value;
            }
        }
    }
}

