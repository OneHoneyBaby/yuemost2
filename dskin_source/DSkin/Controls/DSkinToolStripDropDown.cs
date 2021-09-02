namespace DSkin.Controls
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxItem(false), ToolboxBitmap(typeof(ToolStripDropDown))]
    public class DSkinToolStripDropDown : ToolStripDropDown
    {
        private bool bool_0 = true;
        private Color color_0 = Color.DarkGray;
        private Color color_1 = Color.FromArgb(0x7d, 0x7d, 0x7d);
        private ResizeGridLocation resizeGridLocation_0 = ResizeGridLocation.BottomRight;
        private Size size_0 = new Size(0x10, 0x10);

        public DSkinToolStripDropDown()
        {
            base.ResizeRedraw = true;
            this.DoubleBuffered = true;
            base.MinimumSize = new Size(0x12, 0x12);
        }

        private Rectangle method_0()
        {
            if (this.Resizable)
            {
                Size resizeGridSize = this.ResizeGridSize;
                switch (this.WhereIsResizeGrid)
                {
                    case ResizeGridLocation.TopLeft:
                        return new Rectangle(new Point(1, 1), resizeGridSize);

                    case ResizeGridLocation.TopRight:
                        return new Rectangle(new Point((base.Width - resizeGridSize.Width) - 1, 1), resizeGridSize);

                    case ResizeGridLocation.BottomLeft:
                        return new Rectangle(new Point(1, (base.Height - resizeGridSize.Height) - 1), resizeGridSize);

                    case ResizeGridLocation.BottomRight:
                        return new Rectangle((base.Width - resizeGridSize.Width) - 1, (base.Height - resizeGridSize.Height) - 1, resizeGridSize.Width, resizeGridSize.Height);
                }
            }
            return Rectangle.Empty;
        }

        private bool method_1(ref Message message_0)
        {
            int num = message_0.LParam.ToInt32();
            int x = DSkin.NativeMethods.LOWORD(num);
            int y = DSkin.NativeMethods.HIWORD(num);
            Point pt = base.PointToClient(new Point(x, y));
            if (!this.method_0().Contains(pt))
            {
                return false;
            }
            switch (this.WhereIsResizeGrid)
            {
                case ResizeGridLocation.TopLeft:
                    message_0.Result = new IntPtr(13);
                    break;

                case ResizeGridLocation.TopRight:
                    message_0.Result = new IntPtr(14);
                    break;

                case ResizeGridLocation.BottomLeft:
                    message_0.Result = new IntPtr(0x10);
                    break;

                case ResizeGridLocation.BottomRight:
                    message_0.Result = new IntPtr(0x11);
                    break;
            }
            return true;
        }

        private bool method_2(ref Message message_0)
        {
            DSkin.NativeMethods.MINMAXINFO structure = (DSkin.NativeMethods.MINMAXINFO) Marshal.PtrToStructure(message_0.LParam, typeof(DSkin.NativeMethods.MINMAXINFO));
            if (!this.MaximumSize.IsEmpty)
            {
                structure.maxTrackSize = this.MaximumSize;
            }
            if (!this.MinimumSize.IsEmpty)
            {
                structure.minTrackSize = this.MinimumSize;
            }
            Marshal.StructureToPtr(structure, message_0.LParam, false);
            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Resizable)
            {
                int num;
                int num2;
                Point[] pointArray;
                Point[] pointArray2;
                Graphics graphics = e.Graphics;
                switch (this.WhereIsResizeGrid)
                {
                    case ResizeGridLocation.TopLeft:
                        num = this.method_0().Left + 1;
                        num2 = this.method_0().Top + 1;
                        pointArray = new Point[] { new Point(num + 1, num2 + 1), new Point(num + 1, num2 + 5), new Point(num + 1, num2 + 9), new Point(num + 5, num2 + 1), new Point(num + 5, num2 + 5), new Point(num + 9, num2 + 1) };
                        pointArray2 = pointArray;
                        break;

                    case ResizeGridLocation.TopRight:
                        num = this.method_0().Right - 12;
                        num2 = this.method_0().Top + 1;
                        pointArray = new Point[] { new Point(num + 1, num2 + 1), new Point(num + 5, num2 + 1), new Point(num + 5, num2 + 5), new Point(num + 9, num2 + 1), new Point(num + 9, num2 + 5), new Point(num + 9, num2 + 9) };
                        pointArray2 = pointArray;
                        break;

                    case ResizeGridLocation.BottomLeft:
                        num = this.method_0().Left + 1;
                        num2 = this.method_0().Bottom - 12;
                        pointArray = new Point[] { new Point(num + 1, num2 + 1), new Point(num + 1, num2 + 5), new Point(num + 1, num2 + 9), new Point(num + 5, num2 + 5), new Point(num + 5, num2 + 9), new Point(num + 9, num2 + 9) };
                        pointArray2 = pointArray;
                        break;

                    default:
                        num = this.method_0().Right - 12;
                        num2 = this.method_0().Bottom - 12;
                        pointArray = new Point[] { new Point(num + 9, num2 + 1), new Point(num + 9, num2 + 5), new Point(num + 9, num2 + 9), new Point(num + 5, num2 + 5), new Point(num + 5, num2 + 9), new Point(num + 1, num2 + 9) };
                        pointArray2 = pointArray;
                        break;
                }
                using (Pen pen = new Pen(this.ResizeGridColor))
                {
                    for (int i = 0; i < pointArray2.Length; i++)
                    {
                        graphics.DrawLine(pen, pointArray2[i].X, pointArray2[i].Y - 1, pointArray2[i].X, pointArray2[i].Y + 1);
                        graphics.DrawLine(pen, pointArray2[i].X - 1, pointArray2[i].Y, pointArray2[i].X + 1, pointArray2[i].Y);
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (!this.Resizable || (((m.Msg != 0x84) || !this.method_1(ref m)) && ((m.Msg != 0x24) || !this.method_2(ref m))))
            {
                base.WndProc(ref m);
            }
        }

        public Color BorderColor
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

        public bool Resizable
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                }
            }
        }

        public Color ResizeGridColor
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
                }
            }
        }

        public Size ResizeGridSize
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
                }
            }
        }

        public ResizeGridLocation WhereIsResizeGrid
        {
            get
            {
                return this.resizeGridLocation_0;
            }
            set
            {
                if (this.resizeGridLocation_0 != value)
                {
                    this.resizeGridLocation_0 = value;
                }
            }
        }
    }
}

