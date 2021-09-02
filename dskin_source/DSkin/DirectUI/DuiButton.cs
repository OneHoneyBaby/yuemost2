namespace DSkin.DirectUI
{
    using DSkin;
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiButton : DuiLabel
    {
        private bool bool_29 = false;
        private bool bool_30 = true;
        private bool bool_31 = true;
        private bool bool_32 = false;
        private bool bool_33 = true;
        private bool bool_34 = true;
        private ButtonStyles buttonStyles_0 = ButtonStyles.Default;
        private Color color_3 = Color.FromArgb(0x85, 0xba, 0xe9);
        private Color color_4 = Color.Empty;
        private Color color_5 = Color.Empty;
        private Color color_6 = Color.Gray;
        private ContentAlignment contentAlignment_1 = ContentAlignment.TopCenter;
        private ControlStates controlStates_0 = ControlStates.Normal;
        private DSkinBrush dskinBrush_1;
        private DSkinBrush dskinBrush_2;
        private DSkinBrush dskinBrush_3;
        private DSkinPen dskinPen_0;
        private System.Drawing.Image image_1;
        private System.Drawing.Image image_2;
        private System.Drawing.Image image_3;
        private System.Drawing.Image image_4;
        private int int_3 = 10;
        private int int_4 = 1;
        private Padding padding_2 = new Padding(5);
        private Point point_1 = new Point();
        private DSkin.Common.RoundStyle roundStyle_0 = DSkin.Common.RoundStyle.All;
        private Size size_0 = new Size();

        public event EventHandler ControlStateChanged;

        public DuiButton()
        {
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(100, 50);
            base.AutoSize = false;
            base.CanFocus = true;
            this.TabStop = true;
        }

        protected virtual void DrawButton(Graphics g, Rectangle invalidateRect)
        {
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(new Rectangle(0, 0, base.Width, base.Height), this.int_3, this.roundStyle_0, true))
            {
                SolidBrush brush;
                Color color2;
                Color color3;
                GraphicsPath path2;
                Pen pen;
                Color color = this.color_3;
                if (this.dskinBrush_1 == null)
                {
                    goto Label_00E6;
                }
                switch (this.controlStates_0)
                {
                    case ControlStates.Normal:
                    case ControlStates.Focused:
                        g.FillPath(this.dskinBrush_1.Brush, path);
                        goto Label_01E1;

                    case ControlStates.Hover:
                        if (this.dskinBrush_2 == null)
                        {
                            break;
                        }
                        g.FillPath(this.dskinBrush_2.Brush, path);
                        goto Label_01E1;

                    case ControlStates.Pressed:
                        if (this.dskinBrush_3 == null)
                        {
                            goto Label_00B8;
                        }
                        g.FillPath(this.dskinBrush_3.Brush, path);
                        goto Label_01E1;

                    default:
                        goto Label_01E1;
                }
                g.FillPath(this.dskinBrush_1.Brush, path);
                goto Label_01E1;
            Label_00B8:
                g.FillPath(this.dskinBrush_1.Brush, path);
                goto Label_01E1;
            Label_00E6:
                switch (this.controlStates_0)
                {
                    case ControlStates.Normal:
                    case ControlStates.Focused:
                        color = this.color_3;
                        goto Label_016E;

                    case ControlStates.Hover:
                        if (!(this.color_4 != Color.Empty))
                        {
                            break;
                        }
                        color = this.color_4;
                        goto Label_016E;

                    case ControlStates.Pressed:
                        if (!(this.color_5 != Color.Empty))
                        {
                            goto Label_0154;
                        }
                        color = this.color_5;
                        goto Label_016E;

                    default:
                        goto Label_016E;
                }
                color = smethod_1(this.color_3, 0.1f);
                goto Label_016E;
            Label_0154:
                color = smethod_1(this.color_3, -0.1f);
            Label_016E:
                if ((color != Color.Empty) && (color != Color.Transparent))
                {
                    using (brush = new SolidBrush(color))
                    {
                        if (this.bool_32 && (this.int_3 == 0))
                        {
                            g.FillRectangle(brush, new Rectangle(0, 0, base.Width, base.Height));
                        }
                        else
                        {
                            g.FillPath(brush, path);
                        }
                    }
                }
            Label_01E1:
                if (!this.bool_32)
                {
                    switch (this.buttonStyles_0)
                    {
                        case ButtonStyles.Default:
                            color2 = Color.FromArgb(160, 210, 210, 210);
                            color3 = Color.FromArgb(120, 220, 220, 220);
                            switch (this.controlStates_0)
                            {
                                case ControlStates.Normal:
                                case ControlStates.Focused:
                                    goto Label_02CB;

                                case ControlStates.Hover:
                                    goto Label_0261;

                                case ControlStates.Pressed:
                                    goto Label_0296;
                            }
                            goto Label_02FE;

                        case ButtonStyles.Style1:
                            goto Label_0339;

                        case ButtonStyles.Style2:
                            goto Label_045D;
                    }
                }
                goto Label_052D;
            Label_0261:
                color2 = Color.FromArgb(160, 220, 220, 220);
                color3 = Color.FromArgb(120, 230, 230, 230);
                goto Label_02FE;
            Label_0296:
                color2 = Color.FromArgb(160, 190, 190, 200);
                color3 = Color.FromArgb(120, 200, 200, 200);
                goto Label_02FE;
            Label_02CB:
                color2 = Color.FromArgb(160, 210, 210, 210);
                color3 = Color.FromArgb(120, 220, 220, 220);
            Label_02FE:
                using (LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), color2, color3))
                {
                    g.FillPath(brush2, path);
                    goto Label_052D;
                }
            Label_0339:
                using (path2 = GraphicsPathHelper.CreatePath(new Rectangle(this.int_4, this.int_4, base.Width - (this.int_4 * 2), base.Height - (this.int_4 * 2)), this.int_3, this.roundStyle_0, true))
                {
                    using (Region region = new Region(path2))
                    {
                        GraphicsState gstate = g.Save();
                        region.Intersect(invalidateRect);
                        g.SetClip(region, CombineMode.Intersect);
                        using (brush = new SolidBrush(Color.FromArgb(80, Color.White)))
                        {
                            g.FillRectangle(brush, new Rectangle(0, 0, base.Width, base.Height / 3));
                        }
                        ControlPaintEx.DrawGlass(g, new RectangleF(0f, (float) (base.Height / 3), (float) base.Width, (float) (base.Height + ((base.Height / 3) * 2))), (this.controlStates_0 == ControlStates.Hover) ? 220 : 170, 0);
                        g.Restore(gstate);
                    }
                    g.DrawPath(Pens.White, path2);
                    goto Label_052D;
                }
            Label_045D:
                using (LinearGradientBrush brush3 = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), smethod_1(color, 0.3f), smethod_1(color, -0.3f)))
                {
                    g.FillPath(brush3, path);
                    using (path2 = GraphicsPathHelper.CreatePath(new Rectangle(this.int_4, this.int_4, base.Width - (this.int_4 * 2), base.Height - (this.int_4 * 2)), this.int_3, this.roundStyle_0, true))
                    {
                        using (pen = new Pen(smethod_1(this.color_3, 0.5f)))
                        {
                            g.DrawPath(pen, path2);
                        }
                    }
                }
            Label_052D:
                if (this.bool_31 && (this.roundStyle_0 != DSkin.Common.RoundStyle.None))
                {
                    if (this.dskinPen_0 == null)
                    {
                        if (this.int_4 <= 0)
                        {
                            return;
                        }
                        using (pen = new Pen(this.color_6, (float) this.int_4))
                        {
                            g.DrawPath(pen, path);
                            return;
                        }
                    }
                    g.DrawPath(this.dskinPen_0.Pen, path);
                }
            }
        }

        internal bool method_30()
        {
            return this.bool_33;
        }

        internal void method_31(bool value)
        {
            this.bool_33 = value;
        }

        private void method_32()
        {
            if (((this.image_2 != null) && this.bool_30) && (this.Size != this.image_2.Size))
            {
                this.Size = this.image_2.Size;
            }
        }

        protected virtual void OnControlStateChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);
            if (base.Dock != DockStyle.None)
            {
                this.bool_30 = false;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!((e.KeyCode != Keys.Enter) || e.Handled))
            {
                this.OnMouseDown(new DuiMouseEventArgs(MouseButtons.Left, 1, 0, 0, 0, true, this));
                e.Handled = true;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (!((e.KeyCode != Keys.Enter) || e.Handled))
            {
                this.OnMouseClick(new DuiMouseEventArgs(MouseButtons.Left, 1, 0, 0, 0, true, this));
                this.OnMouseUp(new DuiMouseEventArgs(MouseButtons.Left, 1, 0, 0, 0, true, this));
                e.Handled = true;
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.MouseChangeControlState && (e.Button == MouseButtons.Left))
            {
                this.ControlState = ControlStates.Pressed;
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.MouseChangeControlState)
            {
                this.ControlState = ControlStates.Hover;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.MouseChangeControlState)
            {
                this.ControlState = ControlStates.Normal;
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.MouseChangeControlState)
            {
                if (base.IsMouseEnter)
                {
                    this.ControlState = ControlStates.Hover;
                }
                else
                {
                    this.ControlState = ControlStates.Normal;
                }
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (this.image_2 == null)
            {
                if (this.bool_33)
                {
                    this.DrawButton(g, e.ClipRectangle);
                }
            }
            else
            {
                System.Drawing.Image img = this.image_2;
                switch (this.controlStates_0)
                {
                    case ControlStates.Normal:
                        img = this.image_2;
                        break;

                    case ControlStates.Hover:
                        if (this.image_3 == null)
                        {
                            this.image_3 = ImageEffects.BrightnessChange(20, this.image_2);
                        }
                        img = this.image_3;
                        break;

                    case ControlStates.Pressed:
                        if (this.image_4 == null)
                        {
                            this.image_4 = ImageEffects.BrightnessChange(-20, this.image_2);
                        }
                        img = this.image_4;
                        break;
                }
                if (this.bool_29)
                {
                    ControlRender.SudokuDrawImage(g, img, new Rectangle(new Point(), this.Size), this.padding_2, e.ClipRectangle);
                }
                else
                {
                    g.DrawImage(img, new Rectangle(new Point(), this.Size));
                }
            }
            base.OnPrePaint(e);
            if (this.image_1 != null)
            {
                Size size = this.image_1.Size;
                if ((this.size_0.Width > 0) && (this.size_0.Height > 0))
                {
                    size = this.size_0;
                }
                Point location = this.point_1;
                switch (this.contentAlignment_1)
                {
                    case ContentAlignment.TopLeft:
                        location = new Point(0, 0);
                        break;

                    case ContentAlignment.TopCenter:
                        location = new Point((base.Width - size.Width) / 2, 0);
                        break;

                    case ContentAlignment.TopRight:
                        location = new Point(base.Width - size.Width, 0);
                        break;

                    case ContentAlignment.MiddleLeft:
                        location = new Point(0, (base.Height - size.Height) / 2);
                        break;

                    case ContentAlignment.MiddleCenter:
                        location = new Point((base.Width - size.Width) / 2, (base.Height - size.Height) / 2);
                        break;

                    case ContentAlignment.MiddleRight:
                        location = new Point(base.Width - size.Width, (base.Height - size.Height) / 2);
                        break;

                    case ContentAlignment.BottomLeft:
                        location = new Point(0, base.Height - size.Height);
                        break;

                    case ContentAlignment.BottomCenter:
                        location = new Point((base.Width - size.Width) / 2, base.Height - size.Height);
                        break;

                    case ContentAlignment.BottomRight:
                        location = new Point(base.Width - size.Width, base.Height - size.Height);
                        break;
                }
                location.Offset(this.point_1);
                g.DrawImage(this.image_1, new Rectangle(location, size));
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
            base.OnPreviewKeyDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.method_32();
            base.OnSizeChanged(e);
        }

        private static Color smethod_1(Color color_7, float float_1)
        {
            float r = color_7.R;
            float g = color_7.G;
            float b = color_7.B;
            if (float_1 < 0f)
            {
                float_1 = 1f + float_1;
                r *= float_1;
                g *= float_1;
                b *= float_1;
            }
            else
            {
                r = ((255f - r) * float_1) + r;
                g = ((255f - g) * float_1) + g;
                b = ((255f - b) * float_1) + b;
            }
            if (r < 0f)
            {
                r = 0f;
            }
            if (r > 255f)
            {
                r = 255f;
            }
            if (g < 0f)
            {
                g = 0f;
            }
            if (g > 255f)
            {
                g = 255f;
            }
            if (b < 0f)
            {
                b = 0f;
            }
            if (b > 255f)
            {
                b = 255f;
            }
            return Color.FromArgb(color_7.A, (int) r, (int) g, (int) b);
        }

        [DefaultValue(true), Category("外观"), Description("控件适应图片大小，否则图片将缩放以适应控件")]
        public virtual bool AdaptImage
        {
            get
            {
                return this.bool_30;
            }
            set
            {
                if (this.bool_30 != value)
                {
                    this.bool_30 = value;
                    if (value)
                    {
                        base.Dock = DockStyle.None;
                    }
                    this.Invalidate();
                    base.OnPropertyChanged("AdaptImage");
                }
            }
        }

        [DefaultValue(typeof(Color), "133, 186, 233"), Description("底色"), Category("外观")]
        public virtual Color BaseColor
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
                    base.OnPropertyChanged("BaseColor");
                }
            }
        }

        [Category("外观"), DefaultValue(typeof(Color), "Gray"), Description("按钮边框颜色")]
        public Color ButtonBorderColor
        {
            get
            {
                return this.color_6;
            }
            set
            {
                if (this.color_6 != value)
                {
                    this.color_6 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ButtonBorderColor");
                }
            }
        }

        [DefaultValue((string) null), Description("自定义按钮边框画笔")]
        public DSkinPen ButtonBorderPen
        {
            get
            {
                return this.dskinPen_0;
            }
            set
            {
                if (this.dskinPen_0 != value)
                {
                    this.dskinPen_0 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ButtonBorderPen");
                }
            }
        }

        [DefaultValue(1), Category("外观"), Description("按钮边框宽度")]
        public int ButtonBorderWidth
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
                    if (this.int_4 < 0)
                    {
                        this.int_4 = 0;
                    }
                    this.Invalidate();
                    base.OnPropertyChanged("ButtonBorderWidth");
                }
            }
        }

        [Description("按钮样式"), DefaultValue(0), Category("外观")]
        public ButtonStyles ButtonStyle
        {
            get
            {
                return this.buttonStyles_0;
            }
            set
            {
                if (this.buttonStyles_0 != value)
                {
                    this.buttonStyles_0 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ButtonStyle");
                }
            }
        }

        [DefaultValue(true)]
        public override bool CanFocus
        {
            get
            {
                return base.CanFocus;
            }
            set
            {
                base.CanFocus = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ControlStates ControlState
        {
            get
            {
                return this.controlStates_0;
            }
            set
            {
                if (this.controlStates_0 != value)
                {
                    this.controlStates_0 = value;
                    if (value == ControlStates.Focused)
                    {
                        base.Focus();
                    }
                    this.OnControlStateChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("ControlState");
                }
            }
        }

        [Category("外观"), Description("九宫格方式绘制按钮图片"), DefaultValue(false)]
        public bool DrawButtonSudoku
        {
            get
            {
                return this.bool_29;
            }
            set
            {
                if (this.bool_29 != value)
                {
                    this.bool_29 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("DrawButtonSudoku");
                }
            }
        }

        [Category("外观"), DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格绘制按钮切割宽度")]
        public Padding DrawButtonSudokuPadding
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
                    base.OnPropertyChanged("DrawButtonSudokuPadding");
                }
            }
        }

        [DefaultValue((string) null), Description("自定义填充画笔")]
        public DSkinBrush HoverBrush
        {
            get
            {
                return this.dskinBrush_2;
            }
            set
            {
                this.dskinBrush_2 = value;
            }
        }

        [Description("鼠标移入时的颜色"), Category("外观")]
        public Color HoverColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
            }
        }

        [Category("外观"), Description("鼠标移入时的按钮图像"), DefaultValue((string) null)]
        public virtual System.Drawing.Image HoverImage
        {
            get
            {
                return this.image_3;
            }
            set
            {
                this.image_3 = value;
            }
        }

        [Description("显示的图片"), DefaultValue((string) null)]
        public System.Drawing.Image Image
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
                    this.Invalidate();
                    base.OnPropertyChanged("Image");
                }
            }
        }

        [Description("图片对齐方式"), DefaultValue(2)]
        public ContentAlignment ImageAlign
        {
            get
            {
                return this.contentAlignment_1;
            }
            set
            {
                if (this.contentAlignment_1 != value)
                {
                    this.contentAlignment_1 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ImageAlign");
                }
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Description("图片偏移")]
        public Point ImageOffset
        {
            get
            {
                return this.point_1;
            }
            set
            {
                if (this.point_1 != value)
                {
                    this.point_1 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ImageOffset");
                }
            }
        }

        [DefaultValue(typeof(Size), "0,0"), Description("图片尺寸")]
        public Size ImageSize
        {
            get
            {
                return this.size_0;
            }
            set
            {
                if (this.size_0 != value)
                {
                    this.size_0 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("ImageSize");
                }
            }
        }

        [Description("是否是纯色，如果为True则不绘制特效遮罩层"), DefaultValue(false), Category("外观")]
        public virtual bool IsPureColor
        {
            get
            {
                return this.bool_32;
            }
            set
            {
                if (this.bool_32 != value)
                {
                    this.bool_32 = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool MouseChangeControlState
        {
            get
            {
                return this.bool_34;
            }
            set
            {
                this.bool_34 = value;
            }
        }

        [DefaultValue((string) null), Description("自定义填充画笔")]
        public DSkinBrush NormalBrush
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
                    base.OnPropertyChanged("NormalBrush");
                }
            }
        }

        [DefaultValue((string) null), Category("外观"), Description("正常状态下的按钮图像")]
        public virtual System.Drawing.Image NormalImage
        {
            get
            {
                return this.image_2;
            }
            set
            {
                if (this.image_2 != value)
                {
                    this.image_2 = value;
                    this.method_32();
                    this.Invalidate();
                    base.OnPropertyChanged("NormalImage");
                }
            }
        }

        [Category("外观"), Description("鼠标按下时的颜色")]
        public Color PressColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
            }
        }

        [DefaultValue((string) null), Description("自定义填充画笔")]
        public DSkinBrush PressedBrush
        {
            get
            {
                return this.dskinBrush_3;
            }
            set
            {
                this.dskinBrush_3 = value;
            }
        }

        [Description("鼠标按下时的按钮图像"), DefaultValue((string) null), Category("外观")]
        public virtual System.Drawing.Image PressedImage
        {
            get
            {
                return this.image_4;
            }
            set
            {
                this.image_4 = value;
            }
        }

        [Category("外观"), Description("圆角大小"), DefaultValue(10)]
        public virtual int Radius
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
                    this.Invalidate();
                    base.OnPropertyChanged("Radius");
                }
            }
        }

        [Category("外观"), Description("设置或获取圆角样式"), DefaultValue(typeof(DSkin.Common.RoundStyle), "All")]
        public DSkin.Common.RoundStyle RoundStyle
        {
            get
            {
                return this.roundStyle_0;
            }
            set
            {
                if (this.roundStyle_0 != value)
                {
                    this.roundStyle_0 = value;
                    this.Invalidate();
                    base.OnPropertyChanged("RoundStyle");
                }
            }
        }

        [DefaultValue(true), Description("显示按钮边框"), Category("外观")]
        public virtual bool ShowButtonBorder
        {
            get
            {
                return this.bool_31;
            }
            set
            {
                if (this.bool_31 != value)
                {
                    this.bool_31 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(true)]
        public override bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }
    }
}

