namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ScrollBar))]
    public class DSkinScrollBar : DSkinBaseControl
    {
        private DuiScrollBar duiScrollBar_0;

        [Description("Value改变之后发生")]
        public event EventHandler ValueChanged;

        public DSkinScrollBar()
        {
            EventHandler handler = null;
            this.duiScrollBar_0 = (DuiScrollBar) base.InnerDuiControl;
            handler = new EventHandler(this.method_6);
            this.duiScrollBar_0.ValueChanged += handler;
            this.BackColor = Color.FromArgb(200, Color.White);
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
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

        [Category("DSkinScrollBar"), Description("箭头范围高度")]
        public int ArrowHeight
        {
            get
            {
                return this.duiScrollBar_0.ArrowHeight;
            }
            set
            {
                this.duiScrollBar_0.ArrowHeight = value;
            }
        }

        [Description("鼠标移入箭头的颜色"), Category("DSkinScrollBar")]
        public Color ArrowHoverColor
        {
            get
            {
                return this.duiScrollBar_0.ArrowHoverColor;
            }
            set
            {
                this.duiScrollBar_0.ArrowHoverColor = value;
            }
        }

        [Description("箭头颜色"), Category("DSkinScrollBar")]
        public Color ArrowNormalColor
        {
            get
            {
                return this.duiScrollBar_0.ArrowNormalColor;
            }
            set
            {
                this.duiScrollBar_0.ArrowNormalColor = value;
            }
        }

        [Description("鼠标按下箭头的颜色"), Category("DSkinScrollBar")]
        public Color ArrowPressColor
        {
            get
            {
                return this.duiScrollBar_0.ArrowPressColor;
            }
            set
            {
                this.duiScrollBar_0.ArrowPressColor = value;
            }
        }

        [Description("箭头和滚动框空白距离"), Category("DSkinScrollBar")]
        public int ArrowScrollBarGap
        {
            get
            {
                return this.duiScrollBar_0.ArrowScrollBarGap;
            }
            set
            {
                this.duiScrollBar_0.ArrowScrollBarGap = value;
            }
        }

        [DefaultValue(typeof(Color), "200,255,255,255")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiScrollBar();
            }
        }

        [Category("DSkinScrollBar"), Description("圆角"), DefaultValue(false)]
        public bool Fillet
        {
            get
            {
                return this.duiScrollBar_0.Fillet;
            }
            set
            {
                this.duiScrollBar_0.Fillet = value;
            }
        }

        [Category("DSkinScrollBar"), Description("当用户点击滚动条或者按Page Up PageDown 键时，滚动框位置变动的幅度")]
        public int LargeChange
        {
            get
            {
                return this.duiScrollBar_0.LargeChange;
            }
            set
            {
                this.duiScrollBar_0.LargeChange = value;
            }
        }

        [Category("DSkinScrollBar"), Description("可滚动的上限值")]
        public int Maximum
        {
            get
            {
                return this.duiScrollBar_0.Maximum;
            }
            set
            {
                this.duiScrollBar_0.Maximum = value;
            }
        }

        [Category("DSkinScrollBar"), Description("可滚动的下限值")]
        public int Minimum
        {
            get
            {
                return this.duiScrollBar_0.Minimum;
            }
            set
            {
                this.duiScrollBar_0.Minimum = value;
            }
        }

        [Description("滚动条方向"), Category("DSkinScrollBar")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.duiScrollBar_0.Orientation;
            }
            set
            {
                this.duiScrollBar_0.Orientation = value;
            }
        }

        [Description("鼠标移入时候滚动框的颜色"), Category("DSkinScrollBar")]
        public Color ScrollBarHoverColor
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarHoverColor;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarHoverColor = value;
            }
        }

        [Category("DSkinScrollBar"), Description("滚动框图片")]
        public Image ScrollBarHoverImage
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarHoverImage;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarHoverImage = value;
            }
        }

        [Category("DSkinScrollBar"), Description("中间滚动框长度")]
        public int ScrollBarLenght
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarLenght;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarLenght = value;
            }
        }

        [Description("滚动框颜色"), Category("DSkinScrollBar")]
        public Color ScrollBarNormalColor
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarNormalColor;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarNormalColor = value;
            }
        }

        [Category("DSkinScrollBar"), Description("滚动框图片")]
        public Image ScrollBarNormalImage
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarNormalImage;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarNormalImage = value;
            }
        }

        [Description("滚动条内边距"), Category("DSkinScrollBar")]
        public int ScrollBarPadding
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarPadding;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarPadding = value;
            }
        }

        [Description("滚动框九宫格图片切割宽度"), Category("DSkinScrollBar")]
        public Padding ScrollBarPartitionWidth
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarPartitionWidth;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarPartitionWidth = value;
            }
        }

        [Description("鼠标按下时候滚动框的颜色"), Category("DSkinScrollBar")]
        public Color ScrollBarPressColor
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarPressColor;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarPressColor = value;
            }
        }

        [Category("DSkinScrollBar"), Description("滚动框图片")]
        public Image ScrollBarPressImage
        {
            get
            {
                return this.duiScrollBar_0.ScrollBarPressImage;
            }
            set
            {
                this.duiScrollBar_0.ScrollBarPressImage = value;
            }
        }

        [Description("显示箭头"), Category("DSkinScrollBar")]
        public bool ShowArrow
        {
            get
            {
                return this.duiScrollBar_0.ShowArrow;
            }
            set
            {
                this.duiScrollBar_0.ShowArrow = value;
            }
        }

        [Description("当用户点击滚动箭头或按箭头键时，滚动框位置变动的幅度"), Category("DSkinScrollBar")]
        public int SmallChange
        {
            get
            {
                return this.duiScrollBar_0.SmallChange;
            }
            set
            {
                this.duiScrollBar_0.SmallChange = value;
            }
        }

        [Category("DSkinScrollBar"), Description("滚动框位置标示的值")]
        public int Value
        {
            get
            {
                return this.duiScrollBar_0.Value;
            }
            set
            {
                this.duiScrollBar_0.Value = value;
            }
        }
    }
}

