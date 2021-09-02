namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ComboBox))]
    public class DCSkinComboBox : ComboBox
    {
        private bool bool_0;
        private Class57 class57_0;
        private Color color_0 = Color.FromArgb(0x3e, 0x97, 0xd8);
        private Color color_1 = Color.FromArgb(0x33, 0x89, 0xc9);
        private Color color_2 = Color.White;
        private Color color_3 = Color.CornflowerBlue;
        private Color color_4 = Color.White;
        private Color color_5 = Color.FromArgb(0x7f, 0x7f, 0x7f);
        private Color color_6 = Color.FromArgb(0x33, 0xa1, 0xe0);
        private Color color_7 = Color.FromArgb(0x33, 0xa1, 0xe0);
        private Color color_8 = Color.FromArgb(0x13, 0x58, 0x80);
        private ControlStates controlStates_0;
        private IntPtr intptr_0;
        private string string_0 = string.Empty;

        public DCSkinComboBox()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            base.DrawMode = DrawMode.OwnerDrawFixed;
        }

        internal ControlStates method_0()
        {
            return this.controlStates_0;
        }

        internal void method_1(ControlStates value)
        {
            if (this.controlStates_0 != value)
            {
                this.controlStates_0 = value;
                base.Invalidate(this.method_2());
            }
        }

        private void method_10(Graphics graphics_0, Rectangle rectangle_0, ControlStates controlStates_1)
        {
            Color controlDark;
            Color color = Color.FromArgb(160, 250, 250, 250);
            Color color4 = base.Enabled ? this.color_7 : SystemColors.ControlDarkDark;
            Color color2 = base.Enabled ? this.color_8 : SystemColors.ControlDarkDark;
            Rectangle rectangle = rectangle_0;
            if (base.Enabled)
            {
                switch (controlStates_1)
                {
                    case ControlStates.Hover:
                        controlDark = Class7.smethod_5(this.color_6, 0, -33, -22, -13);
                        goto Label_00A1;

                    case ControlStates.Pressed:
                        controlDark = Class7.smethod_5(this.color_6, 0, -65, -47, -25);
                        goto Label_00A1;
                }
                controlDark = this.color_6;
            }
            else
            {
                controlDark = SystemColors.ControlDark;
            }
        Label_00A1:
            rectangle.Inflate(-1, -1);
            this.method_11(graphics_0, rectangle, controlDark, color4, color, color2, RoundStyle.None, true, false, ArrowDirection.Down, LinearGradientMode.Vertical);
        }

        internal void method_11(Graphics graphics_0, Rectangle rectangle_0, Color color_9, Color color_10, Color color_11, Color color_12, RoundStyle roundStyle_0, bool bool_1, bool bool_2, ArrowDirection arrowDirection_0, LinearGradientMode linearGradientMode_0)
        {
            Class7.smethod_2(graphics_0, rectangle_0, color_9, color_10, color_11, roundStyle_0, 0, 0.45f, bool_1, bool_2, linearGradientMode_0);
            using (SolidBrush brush = new SolidBrush(color_12))
            {
                this.method_12(graphics_0, rectangle_0, arrowDirection_0, brush);
            }
        }

        internal void method_12(Graphics graphics_0, Rectangle rectangle_0, ArrowDirection arrowDirection_0, Brush brush_0)
        {
            Point[] pointArray2;
            Point point = new Point(rectangle_0.Left + (rectangle_0.Width / 2), rectangle_0.Top + (rectangle_0.Height / 2));
            Point[] points = null;
            switch (arrowDirection_0)
            {
                case ArrowDirection.Left:
                    pointArray2 = new Point[] { new Point(point.X + 2, point.Y - 3), new Point(point.X + 2, point.Y + 3), new Point(point.X - 1, point.Y) };
                    points = pointArray2;
                    break;

                case ArrowDirection.Up:
                    pointArray2 = new Point[] { new Point(point.X - 3, point.Y + 2), new Point(point.X + 3, point.Y + 2), new Point(point.X, point.Y - 2) };
                    points = pointArray2;
                    break;

                case ArrowDirection.Right:
                    pointArray2 = new Point[] { new Point(point.X - 2, point.Y - 3), new Point(point.X - 2, point.Y + 3), new Point(point.X + 1, point.Y) };
                    points = pointArray2;
                    break;

                default:
                    pointArray2 = new Point[] { new Point(point.X - 2, point.Y - 1), new Point(point.X + 3, point.Y - 1), new Point(point.X, point.Y + 2) };
                    points = pointArray2;
                    break;
            }
            graphics_0.FillPolygon(brush_0, points);
        }

        private DSkin.NativeMethods.ComboBoxInfo method_13()
        {
            DSkin.NativeMethods.ComboBoxInfo info;
            info = new DSkin.NativeMethods.ComboBoxInfo {
                cbSize = Marshal.SizeOf(info)
            };
            DSkin.NativeMethods.GetComboBoxInfo(base.Handle, ref info);
            return info;
        }

        private bool method_14()
        {
            return (this.method_13().stateButton == DSkin.NativeMethods.ComboBoxButtonState.STATE_SYSTEM_PRESSED);
        }

        private Rectangle method_15()
        {
            return this.method_13().rcButton.Rect;
        }

        internal Rectangle method_2()
        {
            return this.method_15();
        }

        internal bool method_3()
        {
            return (base.IsHandleCreated && this.method_14());
        }

        internal IntPtr method_4()
        {
            return this.intptr_0;
        }

        internal Rectangle method_5()
        {
            if (base.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                Rectangle rectangle = new Rectangle(3, 3, (base.Width - this.method_2().Width) - 6, base.Height - 6);
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    rectangle.X += this.method_2().Right;
                }
                return rectangle;
            }
            if (base.IsHandleCreated && (this.method_4() != IntPtr.Zero))
            {
                DSkin.RECT lpRect = new DSkin.RECT();
                DSkin.NativeMethods.GetWindowRect(this.method_4(), ref lpRect);
                return base.RectangleToClient(lpRect.Rect);
            }
            return Rectangle.Empty;
        }

        private void method_6(ref Message message_0)
        {
            if (base.DropDownStyle == ComboBoxStyle.Simple)
            {
                base.WndProc(ref message_0);
            }
            else if (base.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if (!this.bool_0)
                {
                    DSkin.PAINTSTRUCT ps = new DSkin.PAINTSTRUCT();
                    this.bool_0 = true;
                    DSkin.NativeMethods.BeginPaint(message_0.HWnd, ref ps);
                    this.method_7(ref message_0);
                    DSkin.NativeMethods.EndPaint(message_0.HWnd, ref ps);
                    this.bool_0 = false;
                    message_0.Result = (IntPtr) 1;
                }
                else
                {
                    base.WndProc(ref message_0);
                }
            }
            else
            {
                base.WndProc(ref message_0);
                this.method_7(ref message_0);
            }
        }

        private void method_7(ref Message message_0)
        {
            Rectangle rectangle = new Rectangle(Point.Empty, base.Size);
            Rectangle rectangle2 = this.method_2();
            ControlStates states = this.method_3() ? ControlStates.Pressed : this.method_0();
            using (Graphics graphics = Graphics.FromHwnd(message_0.HWnd))
            {
                this.method_9(graphics, rectangle, rectangle2);
                this.method_10(graphics, this.method_2(), states);
                this.method_8(graphics, rectangle);
            }
        }

        private void method_8(Graphics graphics_0, Rectangle rectangle_0)
        {
            Color color = base.Enabled ? this.color_7 : SystemColors.ControlDarkDark;
            using (Pen pen = new Pen(color))
            {
                rectangle_0.Width--;
                rectangle_0.Height--;
                graphics_0.DrawRectangle(pen, rectangle_0);
            }
        }

        private void method_9(Graphics graphics_0, Rectangle rectangle_0, Rectangle rectangle_1)
        {
            Color color = base.Enabled ? base.BackColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(color))
            {
                rectangle_1.Inflate(-1, -1);
                rectangle_0.Inflate(-1, -1);
                using (Region region = new Region(rectangle_0))
                {
                    region.Exclude(rectangle_1);
                    region.Exclude(this.method_5());
                    graphics_0.FillRegion(brush, region);
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            DSkin.NativeMethods.ComboBoxInfo info = this.method_13();
            this.intptr_0 = info.hwndEdit;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index != -1)
            {
                Graphics graphics = e.Graphics;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                {
                    LinearGradientBrush brush2 = new LinearGradientBrush(e.Bounds, this.MouseColor, this.color_1, LinearGradientMode.Vertical);
                    Rectangle rect = new Rectangle(1, e.Bounds.Y + 1, e.Bounds.Width - 3, e.Bounds.Height - 3);
                    graphics.FillRectangle(brush2, rect);
                    Pen pen = new Pen(this.ItemBorderColor);
                    graphics.DrawRectangle(pen, rect);
                }
                else
                {
                    SolidBrush brush = new SolidBrush(this.DropBackColor);
                    graphics.FillRectangle(brush, e.Bounds);
                }
                string itemText = base.GetItemText(base.Items[e.Index]);
                Color color = ((e.State & DrawItemState.Selected) != DrawItemState.None) ? this.ItemHoverForeColor : this.ForeColor;
                StringFormat format = new StringFormat {
                    LineAlignment = StringAlignment.Center
                };
                graphics.DrawString(itemText, this.Font, new SolidBrush(color), e.Bounds, format);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            DSkin.NativeMethods.ComboBoxInfo info;
            base.OnHandleCreated(e);
            info = new DSkin.NativeMethods.ComboBoxInfo {
                cbSize = Marshal.SizeOf(info)
            };
            DSkin.NativeMethods.GetComboBoxInfo(base.Handle, ref info);
            this.intptr_0 = info.hwndEdit;
            if (base.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                this.class57_0 = new Class57(this);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (this.class57_0 != null)
            {
                this.class57_0.Dispose();
                this.class57_0 = null;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Point pt = base.PointToClient(Cursor.Position);
            if (this.method_2().Contains(pt))
            {
                this.method_1(ControlStates.Hover);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.method_1(ControlStates.Normal);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            if (this.method_2().Contains(location))
            {
                this.method_1(ControlStates.Hover);
            }
            else
            {
                this.method_1(ControlStates.Normal);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.method_1(ControlStates.Normal);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 15)
            {
                base.WndProc(ref m);
            }
            else
            {
                this.method_6(ref m);
            }
        }

        [DefaultValue(typeof(Color), "19, 88, 128"), Category("Base"), Description("箭头颜色")]
        public Color ArrowColor
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
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "51, 161, 224"), Category("Base"), Description("下拉按钮背景色")]
        public Color BaseColor
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
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "51, 161, 224"), Description("边框颜色"), Category("Base")]
        public Color BorderColor
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
                    base.Invalidate();
                }
            }
        }

        [Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "White"), Description("下拉框背景色")]
        public Color DropBackColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
                base.Invalidate();
            }
        }

        [Description("项被选中时的边框颜色"), Category("DropDown"), DefaultValue(typeof(Color), "CornflowerBlue"), Browsable(true)]
        public Color ItemBorderColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
                base.Invalidate();
            }
        }

        [Description("项被选中时的字体颜色"), Category("DropDown"), DefaultValue(typeof(Color), "White"), Browsable(true)]
        public Color ItemHoverForeColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
                base.Invalidate();
            }
        }

        [Browsable(true), DefaultValue(typeof(Color), "62, 151, 216"), Category("DropDown"), Description("项被选中后的高亮度颜色")]
        public Color MouseColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("DropDown"), Description("项被选中后的渐变颜色"), DefaultValue(typeof(Color), "51, 137, 201")]
        public Color MouseGradientColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "127, 127, 127"), Category("Skin"), Description("水印的颜色")]
        public Color WaterColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
                base.Invalidate();
            }
        }

        [Description("水印文字"), Category("Skin")]
        public string WaterText
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                base.Invalidate();
            }
        }

        private class Class57 : NativeWindow, IDisposable
        {
            private object object_0;

            public Class57(DCSkinComboBox dcskinComboBox_0)
            {
                this.object_0 = dcskinComboBox_0;
                base.AssignHandle(this.object_0.method_4());
            }

            public void Dispose()
            {
                this.ReleaseHandle();
                this.object_0 = null;
            }

            [DllImport("user32.dll")]
            private static extern IntPtr GetDC(IntPtr intptr_0);
            [DllImport("user32.dll")]
            private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 15)
                {
                    IntPtr hWnd = m.HWnd;
                    IntPtr dC = GetDC(hWnd);
                    if (dC != IntPtr.Zero)
                    {
                        try
                        {
                            using (Graphics graphics = Graphics.FromHdc(dC))
                            {
                                if (((this.object_0.Text.Length == 0) && !this.object_0.Focused) && !string.IsNullOrEmpty(this.object_0.WaterText))
                                {
                                    TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                                    if (this.object_0.RightToLeft == RightToLeft.Yes)
                                    {
                                        flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                                    }
                                    TextRenderer.DrawText(graphics, this.object_0.WaterText, new Font("微软雅黑", 8.5f), new Rectangle(0, 0, this.object_0.method_5().Width, this.object_0.method_5().Height), this.object_0.WaterColor, flags);
                                }
                            }
                        }
                        finally
                        {
                            ReleaseDC(hWnd, dC);
                        }
                    }
                }
            }
        }
    }
}

