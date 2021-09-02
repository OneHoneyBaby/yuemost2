namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(SplitContainer))]
    public class GClass5 : SplitContainer
    {
        private DSkin.Controls.CollapsePanel collapsePanel_0 = DSkin.Controls.CollapsePanel.Panel1;
        private Color color_0 = Color.FromArgb(0xce, 0xee, 0xff);
        private Color color_1 = Color.FromArgb(0x69, 200, 0xfe);
        private Color color_2 = Color.FromArgb(80, 0x88, 0xe4);
        private Color color_3 = Color.FromArgb(0x15, 0x42, 0x8b);
        private ControlStates controlStates_0;
        private Enum5 enum5_0;
        private Enum6 enum6_0 = ((Enum6) 1);
        private int int_0;
        private int int_1;
        private readonly object object_0 = new object();

        public event EventHandler CollapseClick
        {
            add
            {
                base.Events.AddHandler(this.object_0, value);
            }
            remove
            {
                base.Events.RemoveHandler(this.object_0, value);
            }
        }

        public GClass5()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.int_0 = base.SplitterDistance;
        }

        public void Collapse()
        {
            if ((this.collapsePanel_0 != DSkin.Controls.CollapsePanel.None) && (this.enum6_0 == ((Enum6) 1)))
            {
                this.int_0 = base.SplitterDistance;
                if (this.collapsePanel_0 == DSkin.Controls.CollapsePanel.Panel1)
                {
                    this.int_1 = base.Panel1MinSize;
                    base.Panel1MinSize = 0;
                    base.SplitterDistance = 0;
                }
                else
                {
                    int num = (base.Orientation == Orientation.Horizontal) ? base.Height : base.Width;
                    this.int_1 = base.Panel2MinSize;
                    base.Panel2MinSize = 0;
                    base.SplitterDistance = (num - base.SplitterWidth) - base.Padding.Vertical;
                }
                base.Invalidate(base.SplitterRectangle);
            }
        }

        public void Expand()
        {
            if ((this.collapsePanel_0 != DSkin.Controls.CollapsePanel.None) && (this.enum6_0 == ((Enum6) 0)))
            {
                if (this.collapsePanel_0 == DSkin.Controls.CollapsePanel.Panel1)
                {
                    base.Panel1MinSize = this.int_1;
                }
                else
                {
                    base.Panel2MinSize = this.int_1;
                }
                base.SplitterDistance = this.int_0;
                base.Invalidate(base.SplitterRectangle);
            }
        }

        internal Enum6 method_0()
        {
            return this.enum6_0;
        }

        internal void method_1(Enum6 value)
        {
            if (this.enum6_0 != value)
            {
                switch (value)
                {
                    case ((Enum6) 0):
                        this.Collapse();
                        break;

                    case ((Enum6) 1):
                        this.Expand();
                        break;
                }
                this.enum6_0 = value;
            }
        }

        internal ControlStates method_2()
        {
            return this.controlStates_0;
        }

        internal void method_3(ControlStates value)
        {
            if (this.controlStates_0 != value)
            {
                this.controlStates_0 = value;
                base.Invalidate(this.CollapseRect);
            }
        }

        private void method_4(Cursor cursor_0)
        {
            if (base.Cursor != cursor_0)
            {
                base.Cursor = cursor_0;
            }
        }

        private void method_5(Rectangle rectangle_0, out Rectangle rectangle_1, out Rectangle rectangle_2, out Rectangle rectangle_3)
        {
            int num;
            if (base.Orientation == Orientation.Horizontal)
            {
                num = (rectangle_0.Width - this.DefaultArrowWidth) / 2;
                rectangle_1 = new Rectangle(rectangle_0.X + num, rectangle_0.Y, this.DefaultArrowWidth, rectangle_0.Height);
                rectangle_2 = new Rectangle(rectangle_0.X, rectangle_0.Y + 1, num, rectangle_0.Height - 2);
                rectangle_3 = new Rectangle(rectangle_1.Right, rectangle_0.Y + 1, num, rectangle_0.Height - 2);
            }
            else
            {
                num = (rectangle_0.Height - this.DefaultArrowWidth) / 2;
                rectangle_1 = new Rectangle(rectangle_0.X, rectangle_0.Y + num, rectangle_0.Width, this.DefaultArrowWidth);
                rectangle_2 = new Rectangle(rectangle_0.X + 1, rectangle_0.Y, rectangle_0.Width - 2, num);
                rectangle_3 = new Rectangle(rectangle_0.X + 1, rectangle_1.Bottom, rectangle_0.Width - 2, num);
            }
        }

        protected virtual void OnCollapseClick(EventArgs e)
        {
            if (this.enum6_0 == ((Enum6) 0))
            {
                this.method_1((Enum6) 1);
            }
            else
            {
                this.method_1((Enum6) 0);
            }
            EventHandler handler = base.Events[this.object_0] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnCreateControl()
        {
            if (!base.DesignMode)
            {
                Class13.smethod_5();
            }
            else
            {
                Class13.smethod_2();
                if (!Class13.smethod_0())
                {
                    base.Dispose();
                    return;
                }
            }
            base.OnCreateControl();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            base.Invalidate(base.SplitterRectangle);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Rectangle collapseRect = this.CollapseRect;
            Point location = e.Location;
            if (collapseRect.Contains(location) || ((this.collapsePanel_0 != DSkin.Controls.CollapsePanel.None) && (this.enum6_0 == ((Enum6) 0))))
            {
                this.enum5_0 = (Enum5) 1;
            }
            else
            {
                if (base.SplitterRectangle.Contains(location))
                {
                    this.enum5_0 = (Enum5) 2;
                }
                base.OnMouseDown(e);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.Cursor = Cursors.Default;
            this.method_3(ControlStates.Normal);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                this.enum5_0 = (Enum5) 0;
            }
            Rectangle collapseRect = this.CollapseRect;
            Point location = e.Location;
            if (collapseRect.Contains(location) && (this.enum5_0 != ((Enum5) 2)))
            {
                base.Capture = false;
                this.method_4(Cursors.Hand);
                this.method_3(ControlStates.Hover);
            }
            else
            {
                if (base.SplitterRectangle.Contains(location))
                {
                    this.method_3(ControlStates.Normal);
                    if ((this.enum5_0 == ((Enum5) 1)) || ((this.collapsePanel_0 != DSkin.Controls.CollapsePanel.None) && (this.enum6_0 == ((Enum6) 0))))
                    {
                        base.Capture = false;
                        base.Cursor = Cursors.Default;
                        return;
                    }
                    if ((this.enum5_0 == ((Enum5) 0)) && !base.IsSplitterFixed)
                    {
                        if (base.Orientation == Orientation.Horizontal)
                        {
                            this.method_4(Cursors.HSplit);
                        }
                        else
                        {
                            this.method_4(Cursors.VSplit);
                        }
                        return;
                    }
                }
                this.method_3(ControlStates.Normal);
                if ((this.enum5_0 == ((Enum5) 2)) && !base.IsSplitterFixed)
                {
                    if (base.Orientation == Orientation.Horizontal)
                    {
                        this.method_4(Cursors.HSplit);
                    }
                    else
                    {
                        this.method_4(Cursors.VSplit);
                    }
                    base.OnMouseMove(e);
                }
                else
                {
                    base.Cursor = Cursors.Default;
                    base.OnMouseMove(e);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.Invalidate(base.SplitterRectangle);
            Rectangle collapseRect = this.CollapseRect;
            Point location = e.Location;
            if (((this.enum5_0 == ((Enum5) 1)) && (e.Button == MouseButtons.Left)) && collapseRect.Contains(location))
            {
                this.OnCollapseClick(EventArgs.Empty);
            }
            this.enum5_0 = (Enum5) 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!base.Panel1Collapsed && !base.Panel2Collapsed)
            {
                Graphics graphics = e.Graphics;
                Rectangle splitterRectangle = base.SplitterRectangle;
                if ((splitterRectangle.Width > 0) && (splitterRectangle.Height > 0))
                {
                    bool flag;
                    LinearGradientMode linearGradientMode = (flag = base.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
                    using (LinearGradientBrush brush = new LinearGradientBrush(splitterRectangle, this.LineBack, this.LineBack2, linearGradientMode))
                    {
                        Blend blend = new Blend();
                        float[] numArray = new float[3];
                        numArray[1] = 0.5f;
                        numArray[2] = 1f;
                        blend.Positions = numArray;
                        blend.Factors = new float[] { 0.5f, 1f, 0.5f };
                        brush.Blend = blend;
                        graphics.FillRectangle(brush, splitterRectangle);
                    }
                    if (this.collapsePanel_0 != DSkin.Controls.CollapsePanel.None)
                    {
                        Rectangle rectangle;
                        Rectangle rectangle2;
                        Rectangle rectangle3;
                        this.method_5(this.CollapseRect, out rectangle, out rectangle2, out rectangle3);
                        ArrowDirection left = ArrowDirection.Left;
                        switch (this.collapsePanel_0)
                        {
                            case DSkin.Controls.CollapsePanel.Panel1:
                                if (!flag)
                                {
                                    left = (this.enum6_0 == ((Enum6) 0)) ? ArrowDirection.Right : ArrowDirection.Left;
                                    break;
                                }
                                left = (this.enum6_0 == ((Enum6) 0)) ? ArrowDirection.Down : ArrowDirection.Up;
                                break;

                            case DSkin.Controls.CollapsePanel.Panel2:
                                if (!flag)
                                {
                                    left = (this.enum6_0 == ((Enum6) 0)) ? ArrowDirection.Left : ArrowDirection.Right;
                                    break;
                                }
                                left = (this.enum6_0 == ((Enum6) 0)) ? ArrowDirection.Up : ArrowDirection.Down;
                                break;
                        }
                        Color color = (this.controlStates_0 == ControlStates.Hover) ? this.ArroHoverColor : this.ArroColor;
                        using (new SmoothingModeGraphics(graphics))
                        {
                            Class55.smethod_5(graphics, rectangle2, new Size(3, 3), color);
                            Class55.smethod_5(graphics, rectangle3, new Size(3, 3), color);
                            using (Brush brush2 = new SolidBrush(color))
                            {
                                Class55.smethod_3(graphics, rectangle, left, brush2);
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "80, 136, 228"), Category("Skin"), Description("箭头颜色")]
        public Color ArroColor
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
                    base.Invalidate();
                }
            }
        }

        [Category("Skin"), Description("箭头悬浮时颜色"), DefaultValue(typeof(Color), "21, 66, 139")]
        public Color ArroHoverColor
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
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(DSkin.Controls.CollapsePanel), "1")]
        public DSkin.Controls.CollapsePanel CollapsePanel
        {
            get
            {
                return this.collapsePanel_0;
            }
            set
            {
                if (this.collapsePanel_0 != value)
                {
                    this.Expand();
                    this.collapsePanel_0 = value;
                }
            }
        }

        protected Rectangle CollapseRect
        {
            get
            {
                if (this.collapsePanel_0 == DSkin.Controls.CollapsePanel.None)
                {
                    return Rectangle.Empty;
                }
                Rectangle splitterRectangle = base.SplitterRectangle;
                if (base.Orientation == Orientation.Horizontal)
                {
                    splitterRectangle.X = (base.Width - this.DefaultCollapseWidth) / 2;
                    splitterRectangle.Width = this.DefaultCollapseWidth;
                }
                else
                {
                    splitterRectangle.Y = (base.Height - this.DefaultCollapseWidth) / 2;
                    splitterRectangle.Height = this.DefaultCollapseWidth;
                }
                return splitterRectangle;
            }
        }

        protected virtual int DefaultArrowWidth
        {
            get
            {
                return 0x10;
            }
        }

        protected virtual int DefaultCollapseWidth
        {
            get
            {
                return 80;
            }
        }

        [DefaultValue(typeof(Color), "206, 238, 255"), Description("分割线渐变背景色1"), Category("Skin")]
        public Color LineBack
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_0 = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Skin"), DefaultValue(typeof(Color), "105, 200, 254"), Description("分割线渐变背景色2")]
        public Color LineBack2
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                    base.Invalidate();
                }
            }
        }

        private enum Enum5
        {
        }
    }
}

