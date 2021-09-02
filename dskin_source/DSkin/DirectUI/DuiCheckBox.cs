namespace DSkin.DirectUI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiCheckBox : DuiBaseControl
    {
        private bool bool_27 = false;
        private bool bool_28 = true;
        private bool bool_29;
        private bool bool_30 = false;
        private System.Windows.Forms.CheckState checkState_0;
        private Color color_2;
        private Color color_3;
        private Color color_4;
        private Color color_5;
        private Color color_6;
        private Color color_7;
        private Color color_8;
        private Color color_9;
        private ContentAlignment contentAlignment_0;
        private ControlStates controlStates_0 = ControlStates.Normal;
        private Color DaaBjdkfaO;
        private Image image_1;
        private Image image_2;
        private Image image_3;
        private Image image_4;
        private Image image_5;
        private Image image_6;
        private Image image_7;
        private Image image_8;
        private Image image_9;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private Point point_1 = new Point();
        private Rectangle rectangle_2;
        private Rectangle rectangle_3;
        private StringFormat stringFormat_0;
        private System.Drawing.Text.TextRenderingHint textRenderingHint_0 = System.Drawing.Text.TextRenderingHint.SystemDefault;

        public event EventHandler CheckedChanged;

        public event EventHandler CheckStateChanged;

        public DuiCheckBox()
        {
            this.AutoSize = true;
            this.contentAlignment_0 = ContentAlignment.MiddleLeft;
            this.int_1 = 2;
            this.int_2 = 14;
            this.int_3 = 3;
            this.int_4 = 3;
            this.color_2 = Color.DodgerBlue;
            this.color_3 = Color.Gray;
            this.color_4 = Color.FromArgb(0x5d, 0x97, 2);
            this.color_5 = Color.Gray;
            this.DaaBjdkfaO = Color.Gray;
            this.color_9 = Color.Silver;
            this.color_6 = this.CheckRectBackColorHighLight = Color.FromArgb(0xf6, 0xef, 0xdb);
            this.CheckRectBackColorPressed = Color.FromArgb(0xef, 0xe2, 0xbc);
            this.method_30();
        }

        protected virtual void ClickToChangeState()
        {
            if (this.AutoCheck)
            {
                if (this.ThreeState)
                {
                    if (this.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    {
                        this.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                    else if (this.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        this.CheckState = System.Windows.Forms.CheckState.Indeterminate;
                    }
                    else
                    {
                        this.CheckState = System.Windows.Forms.CheckState.Unchecked;
                    }
                }
                else if (this.CheckState != System.Windows.Forms.CheckState.Checked)
                {
                    this.CheckState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    this.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.stringFormat_0 != null)
            {
                this.stringFormat_0.Dispose();
                this.stringFormat_0 = null;
            }
            base.Dispose(disposing);
        }

        private StringFormat method_29()
        {
            if (this.stringFormat_0 == null)
            {
                StringFormat format2 = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                this.stringFormat_0 = format2;
            }
            return this.stringFormat_0;
        }

        private void method_30()
        {
            int num;
            int num2;
            this.rectangle_2 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, this.CheckRectWidth, this.CheckRectWidth);
            if (!this.AutoSize)
            {
                switch (this.CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = ((base.Height - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.TopCenter:
                        num = base.Width - (this.InnerPaddingWidth * 2);
                        num2 = ((base.Height - this.InnerPaddingWidth) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.TopRight:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = ((base.Height - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.MiddleLeft:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = base.Height - (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.MiddleCenter:
                        num = base.Width - (this.InnerPaddingWidth * 2);
                        num2 = base.Height - (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.MiddleRight:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = base.Height - (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.BottomLeft:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = ((base.Height - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.BottomCenter:
                        num = base.Width - (this.InnerPaddingWidth * 2);
                        num2 = ((base.Height - this.InnerPaddingWidth) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;

                    case ContentAlignment.BottomRight:
                        num = ((base.Width - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        num2 = ((base.Height - (this.InnerPaddingWidth * 2)) - this.CheckRectWidth) - this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (num > 0) ? num : 1, (num2 > 0) ? num2 : 1);
                        break;
                }
            }
            else
            {
                SizeF ef = new SizeF();
                if (!string.IsNullOrEmpty(this.Text))
                {
                    using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        ef = graphics.MeasureString(this.Text, this.Font);
                        ef.Width++;
                    }
                }
                num = 10;
                num2 = 10;
                switch (this.CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.TopCenter:
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num = ((ef.Width > this.CheckRectWidth) ? ((int) ef.Width) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle((base.Width - ((int) ef.Width)) / 2, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.TopRight:
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, (this.InnerPaddingWidth + this.CheckRectWidth) + this.SpaceBetweenCheckMarkAndText, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.MiddleLeft:
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num2 = ((ef.Height > this.CheckRectWidth) ? ((int) ef.Height) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, this.InnerPaddingWidth, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.MiddleCenter:
                        num = ((ef.Width > this.CheckRectWidth) ? ((int) ef.Width) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        num2 = ((ef.Height > this.CheckRectWidth) ? ((int) ef.Height) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle((base.Width - ((int) ef.Width)) / 2, 0, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.MiddleRight:
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num2 = ((ef.Height > this.CheckRectWidth) ? ((int) ef.Height) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.BottomLeft:
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle((this.CheckRectWidth + this.InnerPaddingWidth) + this.SpaceBetweenCheckMarkAndText, this.InnerPaddingWidth, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.BottomCenter:
                        num = ((ef.Width > this.CheckRectWidth) ? ((int) ef.Width) : this.CheckRectWidth) + (this.InnerPaddingWidth * 2);
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle((base.Width - ((int) ef.Width)) / 2, this.InnerPaddingWidth, (int) ef.Width, (int) ef.Height);
                        break;

                    case ContentAlignment.BottomRight:
                        num = ((((int) ef.Width) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        num2 = ((((int) ef.Height) + this.CheckRectWidth) + (this.InnerPaddingWidth * 2)) + this.SpaceBetweenCheckMarkAndText;
                        this.rectangle_3 = new Rectangle(this.InnerPaddingWidth, this.InnerPaddingWidth, (int) ef.Width, (int) ef.Height);
                        break;
                }
                if (this.bool_27)
                {
                    if ((this.image_4 != null) && (this.image_1 != null))
                    {
                        this.Size = this.image_4.Size;
                    }
                }
                else
                {
                    this.Size = new Size(num, num2);
                }
            }
            int x = 0;
            int y = 0;
            switch (this.CheckAlign)
            {
                case ContentAlignment.TopLeft:
                    y = this.InnerPaddingWidth;
                    x = this.InnerPaddingWidth;
                    break;

                case ContentAlignment.TopCenter:
                    y = this.InnerPaddingWidth;
                    x = (base.Width - this.CheckRectWidth) / 2;
                    break;

                case ContentAlignment.TopRight:
                    y = this.InnerPaddingWidth;
                    x = (base.Width - this.InnerPaddingWidth) - this.CheckRectWidth;
                    break;

                case ContentAlignment.MiddleLeft:
                    x = this.InnerPaddingWidth;
                    y = (base.Height - this.CheckRectWidth) / 2;
                    break;

                case ContentAlignment.MiddleCenter:
                    y = (base.Height - this.CheckRectWidth) / 2;
                    x = (base.Width - this.CheckRectWidth) / 2;
                    break;

                case ContentAlignment.MiddleRight:
                    y = (base.Height - this.CheckRectWidth) / 2;
                    x = (base.Width - this.InnerPaddingWidth) - this.CheckRectWidth;
                    break;

                case ContentAlignment.BottomLeft:
                    y = (base.Height - this.InnerPaddingWidth) - this.CheckRectWidth;
                    x = this.InnerPaddingWidth;
                    break;

                case ContentAlignment.BottomCenter:
                    y = (base.Height - this.InnerPaddingWidth) - this.CheckRectWidth;
                    y = (y < 0) ? 0 : y;
                    x = (base.Width - this.CheckRectWidth) / 2;
                    break;

                case ContentAlignment.BottomRight:
                    y = (base.Height - this.InnerPaddingWidth) - this.CheckRectWidth;
                    x = (base.Width - this.InnerPaddingWidth) - this.CheckRectWidth;
                    break;
            }
            this.rectangle_2.Location = new Point(x, y);
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnDraw(Rectangle checkRect, Graphics g)
        {
            SolidBrush brush;
            Color color;
            Pen pen;
            Color checkRectBackColorDisabled;
            if (!base.Enabled)
            {
                checkRectBackColorDisabled = this.CheckRectBackColorDisabled;
            }
            else
            {
                switch (this.ControlState)
                {
                    case ControlStates.Hover:
                        checkRectBackColorDisabled = this.CheckRectBackColorHighLight;
                        goto Label_0043;

                    case ControlStates.Pressed:
                        checkRectBackColorDisabled = this.CheckRectBackColorPressed;
                        goto Label_0043;
                }
                checkRectBackColorDisabled = this.CheckRectBackColorNormal;
            }
        Label_0043:
            color = base.Enabled ? this.CheckRectColor : this.CheckRectColorDisabled;
            Color color3 = base.Enabled ? this.CheckFlagColor : this.CheckFlagColorDisabled;
            using (brush = new SolidBrush(checkRectBackColorDisabled))
            {
                g.FillRectangle(brush, checkRect);
            }
            using (pen = new Pen(color))
            {
                checkRect.Height--;
                checkRect.Width--;
                g.DrawRectangle(pen, checkRect);
                if ((this.ControlState == ControlStates.Hover) && base.Enabled)
                {
                    using (Pen pen2 = new Pen(Color.FromArgb(40, color)))
                    {
                        pen2.Width = 3f;
                        pen2.Alignment = PenAlignment.Center;
                        g.DrawRectangle(pen2, checkRect);
                    }
                }
                checkRect.Height++;
                checkRect.Width++;
            }
            if (this.CheckState == System.Windows.Forms.CheckState.Indeterminate)
            {
                checkRect.Inflate(-this.InnerRectInflate, -this.InnerRectInflate);
                using (brush = new SolidBrush(color3))
                {
                    g.FillRectangle(brush, checkRect);
                }
            }
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (this.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                checkRect.Inflate(-2, -2);
                checkRect.Height -= 3;
                checkRect.Width--;
                PointF tf = new PointF((float) checkRect.X, checkRect.Y + (((float) checkRect.Height) / 2f));
                PointF tf2 = new PointF(checkRect.X + (((float) checkRect.Width) / 3f), (float) checkRect.Bottom);
                PointF tf3 = new PointF((float) (checkRect.Right + 1), (float) (checkRect.Y - 1));
                using (pen = new Pen(color3))
                {
                    pen.Width = 1.6f;
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    PointF[] points = new PointF[] { tf, tf2, tf3 };
                    g.DrawLines(pen, points);
                    tf2.Y += 1.8f;
                    points = new PointF[] { tf, tf2, tf3 };
                    g.DrawLines(pen, points);
                }
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.method_30();
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.ControlState = ControlStates.Pressed;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.ControlState = ControlStates.Hover;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.ControlState = ControlStates.Normal;
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (base.IsMouseEnter)
            {
                this.ControlState = ControlStates.Hover;
            }
            else
            {
                this.ControlState = ControlStates.Normal;
            }
            if (e.Button == MouseButtons.Left)
            {
                this.ClickToChangeState();
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            Rectangle checkRect = this.rectangle_2;
            Graphics g = e.Graphics;
            if ((this.UncheckedNormal == null) || (this.CheckedNormal == null))
            {
                this.OnDraw(checkRect, g);
                goto Label_01A5;
            }
            Image checkedNormal = this.CheckedNormal;
            switch (this.ControlState)
            {
                case ControlStates.Normal:
                case ControlStates.Focused:
                    switch (this.checkState_0)
                    {
                        case System.Windows.Forms.CheckState.Unchecked:
                            checkedNormal = this.image_1;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Checked:
                            checkedNormal = this.image_4;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Indeterminate:
                            checkedNormal = (this.image_7 == null) ? this.image_4 : this.image_7;
                            goto Label_0171;
                    }
                    break;

                case ControlStates.Hover:
                    switch (this.checkState_0)
                    {
                        case System.Windows.Forms.CheckState.Unchecked:
                            checkedNormal = (this.image_2 == null) ? this.image_1 : this.image_2;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Checked:
                            checkedNormal = (this.image_5 == null) ? this.image_4 : this.image_5;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Indeterminate:
                            checkedNormal = (this.image_8 == null) ? this.image_7 : this.image_8;
                            goto Label_0171;
                    }
                    break;

                case ControlStates.Pressed:
                    switch (this.checkState_0)
                    {
                        case System.Windows.Forms.CheckState.Unchecked:
                            checkedNormal = (this.image_3 == null) ? this.image_1 : this.image_3;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Checked:
                            checkedNormal = (this.image_6 == null) ? this.image_4 : this.image_6;
                            goto Label_0171;

                        case System.Windows.Forms.CheckState.Indeterminate:
                            checkedNormal = (this.image_9 == null) ? this.image_7 : this.image_9;
                            goto Label_0171;
                    }
                    break;
            }
        Label_0171:
            if (this.bool_27)
            {
                g.DrawImage(checkedNormal, 0, 0, checkedNormal.Width, checkedNormal.Height);
            }
            else
            {
                g.DrawImage(checkedNormal, checkRect);
            }
        Label_01A5:
            g.TextRenderingHint = this.TextRenderingHint;
            Color baseColor = base.Enabled ? this.ForeColor : this.TextColorDisabled;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb((baseColor.A == 0xff) ? 0xfe : baseColor.A, baseColor)))
            {
                Rectangle layoutRectangle = new Rectangle(this.rectangle_3.X + this.point_1.X, this.rectangle_3.Y + this.point_1.Y, this.rectangle_3.Width, this.rectangle_3.Height);
                if (this.CheckAlign == ContentAlignment.MiddleCenter)
                {
                    g.DrawString(this.Text, this.Font, brush, layoutRectangle, this.method_29());
                }
                else
                {
                    g.DrawString(this.Text, this.Font, brush, layoutRectangle);
                }
            }
            base.OnPrePaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.method_30();
        }

        [Description("控件适应图片大小，否则图片将缩放以适应控件"), DefaultValue(false)]
        public virtual bool AdaptImage
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
                    this.method_30();
                }
            }
        }

        [Description("点击后自动更改状态"), DefaultValue(true)]
        public bool AutoCheck
        {
            get
            {
                return this.bool_28;
            }
            set
            {
                this.bool_28 = value;
            }
        }

        [DefaultValue(true), Description("自适应内容"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if (base.AutoSize != value)
                {
                    base.AutoSize = value;
                    this.method_30();
                    this.Invalidate();
                }
            }
        }

        [Description("复选框位置")]
        public ContentAlignment CheckAlign
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
                    this.method_30();
                    this.Invalidate();
                }
            }
        }

        [Description("是否被选定")]
        public bool Checked
        {
            get
            {
                return this.bool_29;
            }
            set
            {
                if (value)
                {
                    if (this.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    {
                        this.CheckState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                else if (this.CheckState != System.Windows.Forms.CheckState.Unchecked)
                {
                    this.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
                this.bool_29 = value;
            }
        }

        [DefaultValue((string) null), Description("选定时鼠标移入的图像")]
        public Image CheckedHover
        {
            get
            {
                return this.image_5;
            }
            set
            {
                if (this.image_5 != value)
                {
                    this.image_5 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("选定时的图像"), DefaultValue((string) null)]
        public Image CheckedNormal
        {
            get
            {
                return this.image_4;
            }
            set
            {
                if (this.image_4 != value)
                {
                    this.image_4 = value;
                    this.method_30();
                }
            }
        }

        [Description("选定时鼠标按下的图像"), DefaultValue((string) null)]
        public Image CheckedPressed
        {
            get
            {
                return this.image_6;
            }
            set
            {
                if (this.image_6 != value)
                {
                    this.image_6 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("选中的颜色")]
        public Color CheckFlagColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                if (this.color_4 != value)
                {
                    this.color_4 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("禁用时的选中的颜色")]
        public Color CheckFlagColorDisabled
        {
            get
            {
                return this.color_5;
            }
            set
            {
                if (this.color_5 != value)
                {
                    this.color_5 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("禁用时选择框背景色")]
        public Color CheckRectBackColorDisabled
        {
            get
            {
                return this.color_9;
            }
            set
            {
                if (this.color_9 != value)
                {
                    this.color_9 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("选择框高亮的背景色")]
        public Color CheckRectBackColorHighLight
        {
            get
            {
                return this.color_7;
            }
            set
            {
                if (this.color_7 != value)
                {
                    this.color_7 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("选择框背景颜色")]
        public Color CheckRectBackColorNormal
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
                }
            }
        }

        [Description("选择框按下时候的背景色")]
        public Color CheckRectBackColorPressed
        {
            get
            {
                return this.color_8;
            }
            set
            {
                if (this.color_8 != value)
                {
                    this.color_8 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("选择框边框颜色")]
        public Color CheckRectColor
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

        [Description("禁用时的选择框边框颜色")]
        public Color CheckRectColorDisabled
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

        [Description("获取或设置Check标记的外部方块的宽度，宽度与高度是相等的")]
        public int CheckRectWidth
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
                    this.method_30();
                    this.Invalidate();
                }
            }
        }

        [Description("选定状态")]
        public virtual System.Windows.Forms.CheckState CheckState
        {
            get
            {
                return this.checkState_0;
            }
            set
            {
                if (this.checkState_0 != value)
                {
                    this.checkState_0 = value;
                    if (this.checkState_0 != System.Windows.Forms.CheckState.Unchecked)
                    {
                        if (!this.bool_29)
                        {
                            this.bool_29 = true;
                            this.OnCheckedChanged(EventArgs.Empty);
                        }
                    }
                    else if (this.bool_29)
                    {
                        this.bool_29 = false;
                        this.OnCheckedChanged(EventArgs.Empty);
                    }
                    this.OnCheckStateChanged(EventArgs.Empty);
                    this.Invalidate();
                    base.OnPropertyChanged("CheckState");
                }
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
                    this.Invalidate();
                    base.OnPropertyChanged("ControlState");
                }
            }
        }

        [Description("半选定时鼠标移入的图像"), DefaultValue((string) null)]
        public virtual Image IndeterminateHover
        {
            get
            {
                return this.image_8;
            }
            set
            {
                if (this.image_8 != value)
                {
                    this.image_8 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("半选定时的图像"), DefaultValue((string) null)]
        public virtual Image IndeterminateNormal
        {
            get
            {
                return this.image_7;
            }
            set
            {
                if (this.image_7 != value)
                {
                    this.image_7 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("半选定时鼠标按下的图像"), DefaultValue((string) null)]
        public virtual Image IndeterminatePressed
        {
            get
            {
                return this.image_9;
            }
            set
            {
                if (this.image_9 != value)
                {
                    this.image_9 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("内部填充宽度")]
        public int InnerPaddingWidth
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
                    this.method_30();
                }
            }
        }

        [Description("获取或设置当CheckState==Indeterminate时，内部Rect的缩进量，为正值")]
        public virtual int InnerRectInflate
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
                }
            }
        }

        [Description("选择框和文字的距离")]
        public int SpaceBetweenCheckMarkAndText
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
                    this.Invalidate();
                }
            }
        }

        [Description("显示的文字")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.method_30();
                    this.Invalidate();
                }
            }
        }

        [Description("禁用时的文字颜色")]
        public Color TextColorDisabled
        {
            get
            {
                return this.DaaBjdkfaO;
            }
            set
            {
                this.DaaBjdkfaO = value;
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Description("文本偏移")]
        public Point TextOffset
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
                    base.OnPropertyChanged("TextOffset");
                }
            }
        }

        [Description("文本渲染模式"), DefaultValue(0)]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
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

        [DefaultValue(false), Description("是否是三种状态")]
        public virtual bool ThreeState
        {
            get
            {
                return this.bool_30;
            }
            set
            {
                this.bool_30 = value;
            }
        }

        [DefaultValue((string) null), Description("未选定时鼠标移入的图像")]
        public Image UncheckedHover
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
                    this.Invalidate();
                }
            }
        }

        [Description("未选定时的图像"), DefaultValue((string) null)]
        public Image UncheckedNormal
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
                    this.method_30();
                }
            }
        }

        [Description("未选定时鼠标按下的图像"), DefaultValue((string) null)]
        public Image UncheckedPressed
        {
            get
            {
                return this.image_3;
            }
            set
            {
                if (this.image_3 != value)
                {
                    this.image_3 = value;
                    this.Invalidate();
                }
            }
        }
    }
}

