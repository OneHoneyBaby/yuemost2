namespace DSkin.DirectUI
{
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class DuiLabel : DuiBaseControl
    {
        private bool bool_27 = false;
        private bool bool_28 = true;
        private Color color_2 = Color.Black;
        private ContentAlignment contentAlignment_0 = ContentAlignment.TopLeft;
        private DSkinBrush dskinBrush_0;
        private static Graphics graphics_0;
        private int int_1 = 0;
        private int int_2 = 5;
        private Padding padding_1 = new Padding();
        private System.Drawing.StringFormat stringFormat_0 = new System.Drawing.StringFormat();
        private TextEffects textEffects_0 = TextEffects.None;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;

        public DuiLabel()
        {
            base.Height = 12;
        }

        private void method_29()
        {
            if (this.AutoSize)
            {
                if (!string.IsNullOrEmpty(base.Text))
                {
                    Size size = smethod_0(this.Text, this.Font);
                    size.Width += (this.int_1 * 2) + this.padding_1.Horizontal;
                    size.Height += (this.int_1 * 2) + this.padding_1.Vertical;
                    this.Size = size;
                }
                else
                {
                    this.Size = new Size(2, this.Font.Height);
                }
            }
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            this.method_29();
            base.OnAutoSizeChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            this.method_29();
            base.OnFontChanged(e);
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            if (this.bool_28 && !string.IsNullOrEmpty(base.Text))
            {
                Graphics graphics = e.Graphics;
                graphics.TextRenderingHint = this.textRenderingHint_0;
                Rectangle layoutRectangle = new Rectangle(this.int_1 + this.padding_1.Left, this.int_1 + this.padding_1.Top, ((base.Width + 2) - (this.int_1 * 2)) - this.padding_1.Horizontal, (base.Height - (this.int_1 * 2)) - this.padding_1.Vertical);
                if ((layoutRectangle.Width > 0) && (layoutRectangle.Height > 0))
                {
                    SolidBrush brush;
                    switch (this.textEffects_0)
                    {
                        case TextEffects.Forme:
                            using (brush = new SolidBrush(Color.FromArgb((this.color_2.A == 0xff) ? 0xfe : this.color_2.A, this.color_2)))
                            {
                                for (int i = 0; i < this.int_2; i++)
                                {
                                    layoutRectangle.Offset(1, 1);
                                    graphics.DrawString(this.Text, this.Font, brush, layoutRectangle, this.stringFormat_0);
                                }
                            }
                            layoutRectangle.Offset(-this.int_2, -this.int_2);
                            break;

                        case TextEffects.Shadow:
                            using (brush = new SolidBrush(Color.FromArgb((this.color_2.A == 0xff) ? 0xfe : this.color_2.A, this.color_2)))
                            {
                                layoutRectangle.Offset(this.int_2, this.int_2);
                                graphics.DrawString(this.Text, this.Font, brush, layoutRectangle, this.stringFormat_0);
                            }
                            layoutRectangle.Offset(-this.int_2, -this.int_2);
                            break;

                        case TextEffects.Glow:
                            using (brush = new SolidBrush(Color.FromArgb(20, this.color_2)))
                            {
                                for (int j = 0; j < this.int_2; j++)
                                {
                                    for (int k = 0; k < this.int_2; k++)
                                    {
                                        graphics.DrawString(base.Text, this.Font, brush, new RectangleF((float) ((layoutRectangle.X + j) - (this.int_2 / 2)), (float) ((layoutRectangle.Y + k) - (this.int_2 / 2)), (float) layoutRectangle.Width, (float) layoutRectangle.Height), this.stringFormat_0);
                                    }
                                }
                            }
                            graphics.TextRenderingHint = this.textRenderingHint_0;
                            break;
                    }
                    if (this.textEffects_0 == TextEffects.Path)
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            path.AddString(this.Text, this.Font.FontFamily, (int) this.Font.Style, (graphics.DpiY * this.Font.SizeInPoints) / 72f, layoutRectangle, this.stringFormat_0);
                            if (this.dskinBrush_0 != null)
                            {
                                graphics.FillPath(this.dskinBrush_0.Brush, path);
                            }
                            else
                            {
                                using (brush = new SolidBrush(this.ForeColor.ToColor()))
                                {
                                    graphics.FillPath(brush, path);
                                }
                            }
                            using (Pen pen = new Pen(this.color_2, (float) this.int_2))
                            {
                                graphics.DrawPath(pen, path);
                            }
                            goto Label_0411;
                        }
                    }
                    if (this.dskinBrush_0 != null)
                    {
                        graphics.DrawString(this.Text, this.Font, this.dskinBrush_0.Brush, layoutRectangle, this.stringFormat_0);
                    }
                    else
                    {
                        using (brush = new SolidBrush(this.ForeColor.ToColor()))
                        {
                            graphics.DrawString(this.Text, this.Font, brush, layoutRectangle, this.stringFormat_0);
                        }
                    }
                }
            }
        Label_0411:
            base.OnPrePaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.method_29();
            base.OnTextChanged(e);
            this.Invalidate();
        }

        private static Size smethod_0(string string_3, Font font_1)
        {
            if (graphics_0 == null)
            {
                graphics_0 = Graphics.FromHwnd(IntPtr.Zero);
            }
            SizeF ef = graphics_0.MeasureString(string_3, font_1, new PointF(), System.Drawing.StringFormat.GenericDefault);
            return new Size(((int) ef.Width) + 1, ((int) ef.Height) + 1);
        }

        [Category("外观"), Description("获取或设置一个值，指示是否要在控件的右边缘显示省略号 (...)"), DefaultValue(false)]
        public virtual bool AutoEllipsis
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                if (this.bool_27 != value)
                {
                    this.bool_27 = value;
                    if (value)
                    {
                        this.stringFormat_0.Trimming = StringTrimming.EllipsisCharacter;
                    }
                    else
                    {
                        this.stringFormat_0.Trimming = StringTrimming.None;
                    }
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(false), Browsable(true)]
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

        [DefaultValue(typeof(Color), "Black"), Description("特效颜色"), Category("特效")]
        public Color EffectColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                if (this.color_2 != value)
                {
                    this.color_2 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("特效效果值"), Category("特效"), DefaultValue(5)]
        public int EffectValue
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (this.int_2 != value)
                {
                    this.int_2 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("是否绘制文字"), DefaultValue(true)]
        public virtual bool IsDrawText
        {
            get
            {
                return this.bool_28;
            }
            set
            {
                if (this.bool_28 != value)
                {
                    this.bool_28 = value;
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual System.Drawing.StringFormat StringFormat
        {
            get
            {
                return this.stringFormat_0;
            }
            set
            {
                this.stringFormat_0 = value;
            }
        }

        [Description("文本对齐方式"), Category("外观"), DefaultValue(typeof(ContentAlignment), "TopLeft")]
        public virtual ContentAlignment TextAlign
        {
            get
            {
                return this.contentAlignment_0;
            }
            set
            {
                if (this.contentAlignment_0 != value)
                {
                    this.contentAlignment_0 = value;
                    switch (this.contentAlignment_0)
                    {
                        case ContentAlignment.TopLeft:
                            this.stringFormat_0.LineAlignment = StringAlignment.Near;
                            this.stringFormat_0.Alignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.TopCenter:
                            this.stringFormat_0.LineAlignment = StringAlignment.Near;
                            this.stringFormat_0.Alignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.TopRight:
                            this.stringFormat_0.LineAlignment = StringAlignment.Near;
                            this.stringFormat_0.Alignment = StringAlignment.Far;
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.stringFormat_0.LineAlignment = StringAlignment.Center;
                            this.stringFormat_0.Alignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.stringFormat_0.LineAlignment = StringAlignment.Center;
                            this.stringFormat_0.Alignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.MiddleRight:
                            this.stringFormat_0.LineAlignment = StringAlignment.Center;
                            this.stringFormat_0.Alignment = StringAlignment.Far;
                            break;

                        case ContentAlignment.BottomLeft:
                            this.stringFormat_0.LineAlignment = StringAlignment.Far;
                            this.stringFormat_0.Alignment = StringAlignment.Near;
                            break;

                        case ContentAlignment.BottomCenter:
                            this.stringFormat_0.LineAlignment = StringAlignment.Far;
                            this.stringFormat_0.Alignment = StringAlignment.Center;
                            break;

                        case ContentAlignment.BottomRight:
                            this.stringFormat_0.LineAlignment = StringAlignment.Far;
                            this.stringFormat_0.Alignment = StringAlignment.Far;
                            break;
                    }
                    this.Invalidate();
                }
            }
        }

        [Description("自定义文本刷"), DefaultValue((string) null), Category("特效")]
        public DSkinBrush TextBrush
        {
            get
            {
                return this.dskinBrush_0;
            }
            set
            {
                if (this.dskinBrush_0 != value)
                {
                    this.dskinBrush_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("文字特效"), DefaultValue(0), Category("特效")]
        public TextEffects TextEffect
        {
            get
            {
                return this.textEffects_0;
            }
            set
            {
                if (this.textEffects_0 != value)
                {
                    this.textEffects_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Padding), "0,0,0,0"), Description("文字到各个边框的距离"), Category("外观")]
        public Padding TextInnerPadding
        {
            get
            {
                return this.padding_1;
            }
            set
            {
                if (this.padding_1 != value)
                {
                    this.padding_1 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("文字到边框的距离"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DefaultValue(0), Category("外观")]
        public virtual int TextPadding
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    this.method_29();
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Description("文本渲染模式"), Category("外观")]
        public virtual TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    this.Invalidate();
                }
            }
        }
    }
}

