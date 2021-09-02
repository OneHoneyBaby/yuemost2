using DSkin;
using DSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

internal class Class15 : NativeWindow
{
    private bool bool_0 = false;
    private bool bool_1 = false;
    private Color color_0 = Color.Black;
    private Color color_1 = Color.Gray;
    private Color color_2 = Color.White;
    private Color color_3 = Color.Black;
    private object object_0;

    public Class15(DSkinTabControl dskinTabControl_0)
    {
        this.object_0 = dskinTabControl_0;
        base.AssignHandle(dskinTabControl_0.intptr_0);
    }

    public Color method_0()
    {
        return this.color_0;
    }

    public void method_1(Color color_4)
    {
        this.color_0 = color_4;
    }

    public void method_10(Graphics graphics_0)
    {
        if (base.Handle != IntPtr.Zero)
        {
            Rectangle rectangle2 = this.method_8();
            Rectangle rect = new Rectangle(new Point(), new Size(rectangle2.Width - 1, rectangle2.Height - 1));
            using (Brush brush2 = new SolidBrush(this.color_2))
            {
                graphics_0.FillRectangle(brush2, rect);
            }
            using (Pen pen = new Pen(this.color_3))
            {
                graphics_0.DrawRectangle(pen, rect);
                graphics_0.DrawLine(Pens.Black, new Point(rect.Width / 2, 0), new Point(rect.Width / 2, rect.Height));
            }
            using (SolidBrush brush = new SolidBrush(this.color_0))
            {
                using (SolidBrush brush3 = new SolidBrush(this.color_1))
                {
                    Point[] points = new Point[] { new Point(6, rect.Height / 2), new Point(13, 3), new Point(13, rect.Height - 3) };
                    graphics_0.FillPolygon(this.bool_0 ? brush3 : brush, points);
                    points = new Point[] { new Point(rect.Width - 13, 3), new Point(rect.Width - 13, rect.Height - 3), new Point(rect.Width - 6, rect.Height / 2) };
                    graphics_0.FillPolygon(this.bool_1 ? brush3 : brush, points);
                }
            }
        }
    }

    public Color method_2()
    {
        return this.color_1;
    }

    public void method_3(Color color_4)
    {
        this.color_1 = color_4;
    }

    public Color method_4()
    {
        return this.color_2;
    }

    public void method_5(Color color_4)
    {
        this.color_2 = color_4;
    }

    public Color method_6()
    {
        return this.color_3;
    }

    public void method_7(Color color_4)
    {
        this.color_3 = color_4;
    }

    public Rectangle method_8()
    {
        Rectangle rectangle = new Rectangle();
        if (base.Handle != IntPtr.Zero)
        {
            Rectangle rectangle2 = this.method_9();
            Point point2 = this.object_0.PointToScreen(new Point());
            rectangle = new Rectangle(rectangle2.Left - point2.X, rectangle2.Top - point2.Y, rectangle2.Width, rectangle2.Height);
        }
        return rectangle;
    }

    public Rectangle method_9()
    {
        DSkin.RECT lpRect = new DSkin.RECT();
        DSkin.NativeMethods.GetWindowRect(base.Handle, ref lpRect);
        return lpRect.Rect;
    }

    protected override void WndProc(ref Message m)
    {
        if (((m.Msg == 15) && (m.HWnd == base.Handle)) && !this.object_0.IsLayeredMode)
        {
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                this.method_10(graphics);
            }
        }
        if ((m.Msg == 0x201) && (m.HWnd == base.Handle))
        {
            if (this.object_0.Site == null)
            {
                Rectangle rectangle = this.method_9();
                rectangle.Width /= 2;
                if (rectangle.Contains(Control.MousePosition))
                {
                    this.bool_0 = true;
                }
                else
                {
                    this.bool_1 = true;
                }
                this.object_0.Invalidate();
            }
        }
        else if (((m.Msg == 0x202) && (m.HWnd == base.Handle)) && (this.object_0.Site == null))
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.object_0.Invalidate(this.method_8());
        }
        base.WndProc(ref m);
    }
}

