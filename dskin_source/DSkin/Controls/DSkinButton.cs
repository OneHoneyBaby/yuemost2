namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(Button)), ToolboxItem(true)]
    public class DSkinButton : DSkinLabel, IButtonControl
    {
        private bool bool_0;
        private System.Windows.Forms.DialogResult dialogResult_0;
        private DuiButton duiButton_0;

        public event EventHandler ControlStateChanged;

        public DSkinButton()
        {
            EventHandler handler = null;
            this.dialogResult_0 = System.Windows.Forms.DialogResult.None;
            this.bool_0 = false;
            base.SetStyle(ControlStyles.Selectable, true);
            this.duiButton_0 = (DuiButton) base.InnerDuiControl;
            handler = new EventHandler(this.method_7);
            this.duiButton_0.ControlStateChanged += handler;
            this.AutoSize = false;
            base.Size = new Size(100, 40);
        }

        private void method_6(int int_0, bool bool_1)
        {
            base.AccessibilityNotifyClients(AccessibleEvents.StateChange, -1);
        }

        [CompilerGenerated]
        private void method_7(object sender, EventArgs e)
        {
            this.OnControlStateChanged(EventArgs.Empty);
        }

        public void NotifyDefault(bool value)
        {
            if (this.IsDefault != value)
            {
                this.IsDefault = value;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.DialogResult != System.Windows.Forms.DialogResult.None)
            {
                Form form = base.FindForm();
                if (form != null)
                {
                    form.DialogResult = this.DialogResult;
                }
            }
        }

        protected virtual void OnControlStateChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((this.Focused && ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Space))) && base.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

        public void PerformClick()
        {
            this.OnClick(EventArgs.Empty);
        }

        [Description("控件适应图片大小，否则图片将缩放以适应控件"), Category("DSkin")]
        public virtual bool AdaptImage
        {
            get
            {
                return this.duiButton_0.AdaptImage;
            }
            set
            {
                this.duiButton_0.AdaptImage = value;
            }
        }

        [DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
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

        [Description("底色"), Category("DSkin")]
        public virtual Color BaseColor
        {
            get
            {
                return this.duiButton_0.BaseColor;
            }
            set
            {
                this.duiButton_0.BaseColor = value;
            }
        }

        [Description("按钮边框颜色"), Category("DSkin")]
        public Color ButtonBorderColor
        {
            get
            {
                return this.duiButton_0.ButtonBorderColor;
            }
            set
            {
                this.duiButton_0.ButtonBorderColor = value;
            }
        }

        [Description("自定义按钮边框画笔"), DefaultValue((string) null), Category("自定义笔刷")]
        public DSkinPen ButtonBorderPen
        {
            get
            {
                return this.duiButton_0.ButtonBorderPen;
            }
            set
            {
                this.duiButton_0.ButtonBorderPen = value;
            }
        }

        [Description("按钮边框宽度"), Category("DSkin")]
        public int ButtonBorderWidth
        {
            get
            {
                return this.duiButton_0.ButtonBorderWidth;
            }
            set
            {
                this.duiButton_0.ButtonBorderWidth = value;
            }
        }

        [Category("外观"), Description("按钮样式"), DefaultValue(0)]
        public ButtonStyles ButtonStyle
        {
            get
            {
                return this.duiButton_0.ButtonStyle;
            }
            set
            {
                this.duiButton_0.ButtonStyle = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlStates ControlState
        {
            get
            {
                return this.duiButton_0.ControlState;
            }
            set
            {
                this.duiButton_0.ControlState = value;
            }
        }

        public System.Windows.Forms.DialogResult DialogResult
        {
            get
            {
                return this.dialogResult_0;
            }
            set
            {
                if (Enum.IsDefined(typeof(System.Windows.Forms.DialogResult), value))
                {
                    this.dialogResult_0 = value;
                }
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("九宫格方式绘制按钮图片")]
        public bool DrawButtonSudoku
        {
            get
            {
                return this.duiButton_0.DrawButtonSudoku;
            }
            set
            {
                this.duiButton_0.DrawButtonSudoku = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格绘制按钮切割宽度")]
        public Padding DrawButtonSudokuPadding
        {
            get
            {
                return this.duiButton_0.DrawButtonSudokuPadding;
            }
            set
            {
                this.duiButton_0.DrawButtonSudokuPadding = value;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiButton();
            }
        }

        [Description("自定义填充画笔"), DefaultValue((string) null), Category("自定义笔刷")]
        public DSkinBrush HoverBrush
        {
            get
            {
                return this.duiButton_0.HoverBrush;
            }
            set
            {
                this.duiButton_0.HoverBrush = value;
            }
        }

        [Category("DSkin"), Description("鼠标移入时的颜色")]
        public Color HoverColor
        {
            get
            {
                return this.duiButton_0.HoverColor;
            }
            set
            {
                this.duiButton_0.HoverColor = value;
            }
        }

        [Description("鼠标移入时的按钮图像"), Category("DSkin")]
        public virtual System.Drawing.Image HoverImage
        {
            get
            {
                return this.duiButton_0.HoverImage;
            }
            set
            {
                this.duiButton_0.HoverImage = value;
            }
        }

        [DefaultValue((string) null), Description("显示的图片")]
        public System.Drawing.Image Image
        {
            get
            {
                return this.duiButton_0.Image;
            }
            set
            {
                this.duiButton_0.Image = value;
            }
        }

        [DefaultValue(2), Description("图片对齐方式")]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.duiButton_0.ImageAlign;
            }
            set
            {
                this.duiButton_0.ImageAlign = value;
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Description("图片偏移")]
        public Point ImageOffset
        {
            get
            {
                return this.duiButton_0.ImageOffset;
            }
            set
            {
                this.duiButton_0.ImageOffset = value;
            }
        }

        [Description("图片尺寸"), DefaultValue(typeof(Size), "0,0")]
        public Size ImageSize
        {
            get
            {
                return this.duiButton_0.ImageSize;
            }
            set
            {
                this.duiButton_0.ImageSize = value;
            }
        }

        protected internal bool IsDefault
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.method_6(0x40, value);
                }
            }
        }

        [Description("是否是纯色，如果为True则不绘制渐变遮罩层"), Category("DSkin")]
        public virtual bool IsPureColor
        {
            get
            {
                return this.duiButton_0.IsPureColor;
            }
            set
            {
                this.duiButton_0.IsPureColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool MouseChangeControlState
        {
            get
            {
                return this.duiButton_0.MouseChangeControlState;
            }
            set
            {
                this.duiButton_0.MouseChangeControlState = value;
            }
        }

        [DefaultValue((string) null), Description("自定义填充画笔"), Category("自定义笔刷")]
        public DSkinBrush NormalBrush
        {
            get
            {
                return this.duiButton_0.NormalBrush;
            }
            set
            {
                this.duiButton_0.NormalBrush = value;
            }
        }

        [Category("DSkin"), Description("正常状态下的按钮图像")]
        public virtual System.Drawing.Image NormalImage
        {
            get
            {
                return this.duiButton_0.NormalImage;
            }
            set
            {
                this.duiButton_0.NormalImage = value;
            }
        }

        [Description("鼠标按下时的颜色"), Category("DSkin")]
        public Color PressColor
        {
            get
            {
                return this.duiButton_0.PressColor;
            }
            set
            {
                this.duiButton_0.PressColor = value;
            }
        }

        [Category("自定义笔刷"), Description("自定义填充画笔"), DefaultValue((string) null)]
        public DSkinBrush PressedBrush
        {
            get
            {
                return this.duiButton_0.PressedBrush;
            }
            set
            {
                this.duiButton_0.PressedBrush = value;
            }
        }

        [Category("DSkin"), Description("鼠标按下时的按钮图像")]
        public virtual System.Drawing.Image PressedImage
        {
            get
            {
                return this.duiButton_0.PressedImage;
            }
            set
            {
                this.duiButton_0.PressedImage = value;
            }
        }

        [Description("圆角大小，0以上，包括0"), Category("DSkin")]
        public virtual int Radius
        {
            get
            {
                return this.duiButton_0.Radius;
            }
            set
            {
                this.duiButton_0.Radius = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(DSkin.Common.RoundStyle), "All"), Description("设置或获取圆角样式")]
        public DSkin.Common.RoundStyle RoundStyle
        {
            get
            {
                return this.duiButton_0.RoundStyle;
            }
            set
            {
                this.duiButton_0.RoundStyle = value;
            }
        }

        [Description("显示边框"), Category("DSkin")]
        public virtual bool ShowButtonBorder
        {
            get
            {
                return this.duiButton_0.ShowButtonBorder;
            }
            set
            {
                this.duiButton_0.ShowButtonBorder = value;
            }
        }

        [Category("DSkin"), Description("文字到边框的距离")]
        public virtual int TextPadding
        {
            get
            {
                return this.duiButton_0.TextPadding;
            }
            set
            {
                this.duiButton_0.TextPadding = value;
            }
        }

        [Category("DSkin"), EditorBrowsable(EditorBrowsableState.Never), Description("文字渲染模式"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.duiButton_0.TextRenderMode;
            }
            set
            {
                this.duiButton_0.TextRenderMode = value;
            }
        }
    }
}

