namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    [ToolboxItem(true), Description("让父容器控件（窗体或者容器控件）可以拖拽调整大小")]
    public class DSkinDragBar : DSkinButton
    {
        private bool bool_1 = true;
        private DragBarPositions dragBarPositions_0 = DragBarPositions.RightBottom;

        public DSkinDragBar()
        {
            base.Cursor = Cursors.SizeNWSE;
            this.method_8();
            ((DuiButton) base.InnerDuiControl).method_31(false);
            ((DuiButton) base.InnerDuiControl).PrePaint += new EventHandler<PaintEventArgs>(this.juHphrpxhH);
        }

        private void juHphrpxhH(object sender, PaintEventArgs e)
        {
            if (this.DrawDragBar)
            {
                Graphics graphics = e.Graphics;
                using (Pen pen = new Pen(this.ForeColor))
                {
                    switch (this.dragBarPositions_0)
                    {
                        case DragBarPositions.LeftTop:
                            graphics.DrawLine(pen, new Point(base.Width, 0), new Point(0, base.Height));
                            graphics.DrawLine(pen, new Point((base.Width * 2) / 3, 0), new Point(0, (base.Height * 2) / 3));
                            graphics.DrawLine(pen, new Point(base.Width / 3, 0), new Point(0, base.Height / 3));
                            return;

                        case DragBarPositions.LeftBottom:
                            graphics.DrawLine(pen, new Point(0, 0), new Point(base.Width, base.Height));
                            graphics.DrawLine(pen, new Point(0, base.Height / 3), new Point((base.Width * 2) / 3, base.Height));
                            graphics.DrawLine(pen, new Point(0, (base.Height * 2) / 3), new Point(base.Width / 3, base.Height));
                            return;

                        case DragBarPositions.RightTop:
                            graphics.DrawLine(pen, new Point(0, 0), new Point(base.Width, base.Height));
                            graphics.DrawLine(pen, new Point(base.Width / 3, 0), new Point(base.Width, (base.Height * 2) / 3));
                            graphics.DrawLine(pen, new Point((base.Width * 2) / 3, 0), new Point(base.Width, base.Height / 3));
                            return;

                        case DragBarPositions.RightBottom:
                            graphics.DrawLine(pen, new Point(base.Width, 0), new Point(0, base.Height));
                            graphics.DrawLine(pen, new Point(base.Width, base.Height / 3), new Point(base.Width / 3, base.Height));
                            graphics.DrawLine(pen, new Point(base.Width, (base.Height * 2) / 3), new Point((base.Width * 2) / 3, base.Height));
                            return;

                        case DragBarPositions.Top:
                            graphics.DrawLine(pen, new Point(0, base.Height / 2), new Point(base.Width, base.Height / 2));
                            return;

                        case DragBarPositions.Bottom:
                            graphics.DrawLine(pen, new Point(0, base.Height / 2), new Point(base.Width, base.Height / 2));
                            return;

                        case DragBarPositions.Left:
                            graphics.DrawLine(pen, new Point(base.Width / 2, 0), new Point(base.Width / 2, base.Height));
                            return;

                        case DragBarPositions.Right:
                            graphics.DrawLine(pen, new Point(base.Width / 2, 0), new Point(base.Width / 2, base.Height));
                            return;
                    }
                }
            }
        }

        private void method_8()
        {
            switch (this.dragBarPositions_0)
            {
                case DragBarPositions.LeftTop:
                    base.Cursor = Cursors.SizeNWSE;
                    this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    break;

                case DragBarPositions.LeftBottom:
                    base.Cursor = Cursors.SizeNESW;
                    this.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    break;

                case DragBarPositions.RightTop:
                    base.Cursor = Cursors.SizeNESW;
                    this.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    break;

                case DragBarPositions.RightBottom:
                    base.Cursor = Cursors.SizeNWSE;
                    this.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                    break;

                case DragBarPositions.Top:
                    base.Cursor = Cursors.SizeNS;
                    this.Dock = DockStyle.Top;
                    break;

                case DragBarPositions.Bottom:
                    base.Cursor = Cursors.SizeNS;
                    this.Dock = DockStyle.Bottom;
                    break;

                case DragBarPositions.Left:
                    base.Cursor = Cursors.SizeWE;
                    this.Dock = DockStyle.Left;
                    break;

                case DragBarPositions.Right:
                    base.Cursor = Cursors.SizeWE;
                    this.Dock = DockStyle.Right;
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((base.Parent != null) && (e.Button == MouseButtons.Left))
            {
                DSkin.NativeMethods.ReleaseCapture();
                switch (this.dragBarPositions_0)
                {
                    case DragBarPositions.LeftTop:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf004, 0);
                        break;

                    case DragBarPositions.LeftBottom:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf007, 0);
                        break;

                    case DragBarPositions.RightTop:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf005, 0);
                        break;

                    case DragBarPositions.RightBottom:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf008, 0);
                        break;

                    case DragBarPositions.Top:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf003, 0);
                        break;

                    case DragBarPositions.Bottom:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf006, 0);
                        break;

                    case DragBarPositions.Left:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf001, 0);
                        break;

                    case DragBarPositions.Right:
                        DSkin.NativeMethods.SendMessage(base.Parent.Handle, 0x112, 0xf002, 0);
                        break;
                }
            }
            base.OnMouseDown(e);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BaseColor
        {
            get
            {
                return base.BaseColor;
            }
            set
            {
                base.BaseColor = value;
            }
        }

        [Description("控件定位，窗体拉伸方向"), Category("DSkin")]
        public DragBarPositions DragBarPosition
        {
            get
            {
                return this.dragBarPositions_0;
            }
            set
            {
                if (this.dragBarPositions_0 != value)
                {
                    this.dragBarPositions_0 = value;
                    this.method_8();
                    base.Invalidate();
                }
            }
        }

        [Description("是否绘制控件"), Category("DSkin")]
        public bool DrawDragBar
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsPureColor
        {
            get
            {
                return base.IsPureColor;
            }
            set
            {
                base.IsPureColor = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override int Radius
        {
            get
            {
                return base.Radius;
            }
            set
            {
                base.Radius = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool ShowButtonBorder
        {
            get
            {
                return base.ShowButtonBorder;
            }
            set
            {
                base.ShowButtonBorder = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return base.TextRenderingHint;
            }
            set
            {
                base.TextRenderingHint = value;
            }
        }
    }
}

