using DSkin.Controls;
using DSkin.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

[Designer(typeof(ColorBoxDesginer))]
internal class ColorBox : Control
{
    private Bitmap bitmap_0 = Resources.color;
    private Color color_0;
    private Color color_1;
    private Delegate0 delegate0_0;
    private IDisposable idisposable_0 = null;
    private Point point_0;
    private Rectangle rectangle_0;

    public ColorBox()
    {
        this.InitializeComponent();
        this.color_0 = Color.Red;
        this.rectangle_0 = new Rectangle(-100, -100, 14, 14);
        base.SetStyle(ControlStyles.ResizeRedraw, true);
        base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        base.SetStyle(ControlStyles.UserPaint, true);
        base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.idisposable_0 != null))
        {
            this.idisposable_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        base.SuspendLayout();
        base.Name = "ColorBox";
        base.Size = new Size(0xcb, 50);
        base.ResumeLayout(false);
    }

    public Color method_0()
    {
        return this.color_0;
    }

    public void method_1(Delegate0 delegate0_1)
    {
        Delegate0 delegate3;
        Delegate0 delegate2 = this.delegate0_0;
        do
        {
            delegate3 = delegate2;
            Delegate0 delegate4 = (Delegate0) Delegate.Combine(delegate3, delegate0_1);
            delegate2 = Interlocked.CompareExchange<Delegate0>(ref this.delegate0_0, delegate4, delegate3);
        }
        while (delegate2 != delegate3);
    }

    public void method_2(Delegate0 delegate0_1)
    {
        Delegate0 delegate3;
        Delegate0 delegate2 = this.delegate0_0;
        do
        {
            delegate3 = delegate2;
            Delegate0 delegate4 = (Delegate0) Delegate.Remove(delegate3, delegate0_1);
            delegate2 = Interlocked.CompareExchange<Delegate0>(ref this.delegate0_0, delegate4, delegate3);
        }
        while (delegate2 != delegate3);
    }

    protected override void OnClick(EventArgs e)
    {
        Color pixel = this.bitmap_0.GetPixel(this.point_0.X, this.point_0.Y);
        if (((pixel.ToArgb() != Color.FromArgb(0xff, 0xfe, 0xfe, 0xfe).ToArgb()) && (pixel.ToArgb() != Color.FromArgb(0xff, 0x85, 0x8d, 0x97).ToArgb())) && (pixel.ToArgb() != Color.FromArgb(0xff, 110, 0x7e, 0x95).ToArgb()))
        {
            if (this.color_0 != pixel)
            {
                this.color_0 = pixel;
            }
            base.Invalidate();
            this.vmethod_0(new ColorChangedEventArgs(pixel));
        }
        base.OnClick(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        this.rectangle_0.Y = -100;
        this.rectangle_0.X = -100;
        base.Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        this.point_0 = e.Location;
        try
        {
            if (base.ClientRectangle.Contains(this.point_0))
            {
                Color pixel = this.bitmap_0.GetPixel(this.point_0.X, this.point_0.Y);
                if (pixel != this.color_1)
                {
                    if ((((pixel.ToArgb() != Color.FromArgb(0xff, 0xfe, 0xfe, 0xfe).ToArgb()) && (pixel.ToArgb() != Color.FromArgb(0xff, 0x85, 0x8d, 0x97).ToArgb())) && (pixel.ToArgb() != Color.FromArgb(0xff, 110, 0x7e, 0x95).ToArgb())) && (e.X > 0x27))
                    {
                        this.rectangle_0.Y = (e.Y > 0x11) ? 0x11 : 2;
                        this.rectangle_0.X = (((e.X - 0x27) / 15) * 15) + 0x26;
                        base.Invalidate();
                    }
                    else
                    {
                        this.rectangle_0.Y = -100;
                        this.rectangle_0.X = -100;
                        base.Invalidate();
                    }
                }
                this.color_1 = pixel;
            }
        }
        finally
        {
            base.OnMouseMove(e);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.DrawImage(Resources.color, new Rectangle(0, 0, 0xa5, 0x23));
        graphics.DrawRectangle(Pens.SteelBlue, 0, 0, 0xa4, 0x22);
        SolidBrush brush = new SolidBrush(this.color_0);
        graphics.FillRectangle(brush, 9, 5, 0x18, 0x18);
        graphics.DrawRectangle(Pens.DarkCyan, this.rectangle_0);
        base.OnPaint(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        base.SetBoundsCore(x, y, 0xa5, 0x23, specified);
    }

    protected virtual void vmethod_0(ColorChangedEventArgs colorChangedEventArgs_0)
    {
        if (this.delegate0_0 != null)
        {
            this.delegate0_0(this, colorChangedEventArgs_0);
        }
    }

    public delegate void Delegate0(object sender, ColorChangedEventArgs e);
}

