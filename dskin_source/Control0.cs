using DSkin;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class Control0 : Control
{
    private Bitmap bitmap_0;
    private bool bool_0;
    private bool bool_1;
    private bool bool_10;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private bool bool_5;
    private bool bool_6;
    private bool bool_7;
    private bool bool_8;
    private bool bool_9;
    private Color color_0;
    private Color color_1;
    private Container container_0 = null;
    private Image image_0;
    private int int_0;
    private Pen pen_0;
    private Point point_0;
    private Point point_1;
    private Point point_2;
    private Rectangle rectangle_0;
    private Rectangle[] rectangle_1;
    private Rectangle rectangle_2;
    private Size size_0;
    private SolidBrush solidBrush_0;

    public Control0()
    {
        this.method_12();
        this.method_0();
        this.ForeColor = Color.White;
        this.BackColor = Color.Black;
        this.Dock = DockStyle.Fill;
        base.SetStyle(ControlStyles.ResizeRedraw, true);
        base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        base.SetStyle(ControlStyles.UserPaint, true);
        base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.container_0 != null))
        {
            this.container_0.Dispose();
        }
        base.Dispose(disposing);
    }

    ~Control0()
    {
        this.pen_0.Dispose();
        this.solidBrush_0.Dispose();
        this.bitmap_0.Dispose();
        this.image_0.Dispose();
    }

    private void method_0()
    {
        this.color_0 = Color.Yellow;
        this.color_1 = Color.Cyan;
        this.size_0 = new Size(15, 15);
        this.int_0 = 7;
        this.bool_0 = true;
        this.bool_1 = true;
        this.bool_2 = true;
        this.bool_3 = true;
        this.bool_7 = true;
        this.pen_0 = new Pen(this.color_1, 1f);
        this.solidBrush_0 = new SolidBrush(this.color_0);
        this.rectangle_0 = new Rectangle();
        this.method_5();
        this.rectangle_1 = new Rectangle[8];
        for (int i = 0; i < 8; i++)
        {
            this.rectangle_1[i] = new Rectangle(-10, -10, 5, 5);
        }
    }

    public void method_1()
    {
        this.pen_0.Dispose();
        this.solidBrush_0.Dispose();
        if (this.image_0 != null)
        {
            this.bitmap_0.Dispose();
            this.image_0.Dispose();
            this.image_0 = null;
        }
    }

    public void method_10(int int_1, int int_2)
    {
        if ((this.point_1.X != int_1) || (this.point_1.Y != int_2))
        {
            this.point_1.X = int_1;
            this.point_1.Y = int_2;
            this.bool_8 = true;
            base.Invalidate();
        }
    }

    public Bitmap method_11()
    {
        if (this.image_0 != null)
        {
            Bitmap image = new Bitmap(this.rectangle_0.Width + 1, this.rectangle_0.Height + 1);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawImage(this.image_0, -this.rectangle_0.X, -this.rectangle_0.Y);
            }
            return image;
        }
        return null;
    }

    private void method_12()
    {
        this.container_0 = new Container();
    }

    private Bitmap method_2(Bitmap bitmap_1, int int_1)
    {
        Bitmap bitmap = new Bitmap(bitmap_1.Width * int_1, bitmap_1.Height * int_1, PixelFormat.Format32bppArgb);
        BitmapData bitmapdata = bitmap_1.LockBits(new Rectangle(0, 0, bitmap_1.Width, bitmap_1.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        byte[] destination = new byte[bitmapdata.Height * bitmapdata.Stride];
        Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
        byte[] buffer2 = new byte[data2.Height * data2.Stride];
        Marshal.Copy(data2.Scan0, buffer2, 0, buffer2.Length);
        int num = 0;
        int height = bitmap_1.Height;
        while (num < height)
        {
            int num4 = 0;
            int width = bitmap_1.Width;
            while (num4 < width)
            {
                for (int i = 0; i < int_1; i++)
                {
                    for (int j = 0; j < int_1; j++)
                    {
                        buffer2[(((num4 * int_1) + j) * 4) + (((num * int_1) + i) * data2.Stride)] = destination[(num4 * 4) + (num * bitmapdata.Stride)];
                        buffer2[((((num4 * int_1) + j) * 4) + (((num * int_1) + i) * data2.Stride)) + 1] = destination[((num4 * 4) + (num * bitmapdata.Stride)) + 1];
                        buffer2[((((num4 * int_1) + j) * 4) + (((num * int_1) + i) * data2.Stride)) + 2] = destination[((num4 * 4) + (num * bitmapdata.Stride)) + 2];
                        buffer2[((((num4 * int_1) + j) * 4) + (((num * int_1) + i) * data2.Stride)) + 3] = destination[((num4 * 4) + (num * bitmapdata.Stride)) + 3];
                    }
                }
                num4++;
            }
            num++;
        }
        Marshal.Copy(buffer2, 0, data2.Scan0, buffer2.Length);
        bitmap_1.UnlockBits(bitmapdata);
        bitmap.UnlockBits(data2);
        return bitmap;
    }

    private void method_3(Point point_3)
    {
        if (this.rectangle_1[0].Contains(point_3) || this.rectangle_1[7].Contains(point_3))
        {
            this.Cursor = Cursors.SizeNWSE;
        }
        else if (this.rectangle_1[1].Contains(point_3) || this.rectangle_1[6].Contains(point_3))
        {
            this.Cursor = Cursors.SizeNS;
        }
        else if (this.rectangle_1[2].Contains(point_3) || this.rectangle_1[5].Contains(point_3))
        {
            this.Cursor = Cursors.SizeNESW;
        }
        else if (this.rectangle_1[3].Contains(point_3) || this.rectangle_1[4].Contains(point_3))
        {
            this.Cursor = Cursors.SizeWE;
        }
        else if (this.rectangle_0.Contains(point_3))
        {
            this.Cursor = Cursors.SizeAll;
        }
        else
        {
            this.Cursor = Cursors.Default;
        }
    }

    private void method_4()
    {
        if (this.image_0 != null)
        {
            this.bitmap_0 = new Bitmap(this.image_0);
            using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(0x7d, 0, 0, 0));
                graphics.FillRectangle(brush, 0, 0, this.bitmap_0.Width, this.bitmap_0.Height);
                brush.Dispose();
            }
        }
    }

    public void method_5()
    {
        this.bool_4 = false;
        this.rectangle_0.Y = -100;
        this.rectangle_0.X = -100;
        this.rectangle_0.Height = 0;
        this.rectangle_0.Width = 0;
        this.Cursor = Cursors.Default;
        base.Invalidate();
    }

    public void method_6(Rectangle rectangle_3)
    {
        rectangle_3.Intersect(this.DisplayRectangle);
        if (!rectangle_3.IsEmpty)
        {
            rectangle_3.Width--;
            rectangle_3.Height--;
            if (!(this.rectangle_0 == rectangle_3))
            {
                this.rectangle_0 = rectangle_3;
                base.Invalidate();
            }
        }
    }

    public void method_7(Point point_3, Size size_1)
    {
        Rectangle rectangle = new Rectangle(point_3, size_1);
        rectangle.Intersect(this.DisplayRectangle);
        if (!rectangle.IsEmpty)
        {
            rectangle.Width--;
            rectangle.Height--;
            if (!(this.rectangle_0 == rectangle))
            {
                this.rectangle_0 = rectangle;
                base.Invalidate();
            }
        }
    }

    public void method_8(int int_1, int int_2, int int_3, int int_4)
    {
        Rectangle rectangle = new Rectangle(int_1, int_2, int_3, int_4);
        rectangle.Intersect(this.DisplayRectangle);
        if (!rectangle.IsEmpty)
        {
            rectangle.Width--;
            rectangle.Height--;
            if (!(this.rectangle_0 == rectangle))
            {
                this.rectangle_0 = rectangle;
                base.Invalidate();
            }
        }
    }

    public void method_9(Point point_3)
    {
        if (!(this.point_1 == point_3))
        {
            this.point_1 = point_3;
            this.bool_8 = true;
            base.Invalidate();
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (e.KeyChar == 'w')
        {
            DSkin.NativeMethods.SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y - 1);
        }
        else if (e.KeyChar == 's')
        {
            DSkin.NativeMethods.SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y + 1);
        }
        else if (e.KeyChar == 'a')
        {
            DSkin.NativeMethods.SetCursorPos(Control.MousePosition.X - 1, Control.MousePosition.Y);
        }
        else if (e.KeyChar == 'd')
        {
            DSkin.NativeMethods.SetCursorPos(Control.MousePosition.X + 1, Control.MousePosition.Y);
        }
        base.OnKeyPress(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if ((e.Button == MouseButtons.Left) && (!this.Boolean_4 || (this.Cursor != Cursors.Default)))
        {
            this.rectangle_2 = this.DisplayRectangle;
            if ((this.image_0 != null) && this.bool_1)
            {
                if ((e.X > this.image_0.Width) || (e.Y > this.image_0.Height))
                {
                    return;
                }
                this.rectangle_2.Intersect(new Rectangle(0, 0, this.image_0.Width, this.image_0.Height));
            }
            Cursor.Clip = base.RectangleToScreen(this.rectangle_2);
            this.bool_5 = true;
            this.point_0 = e.Location;
        }
        base.Focus();
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        this.bool_8 = false;
        base.Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        this.point_1 = e.Location;
        this.bool_8 = true;
        if (this.bool_4 && this.bool_7)
        {
            this.method_3(e.Location);
            if (this.bool_5 && this.bool_0)
            {
                if (this.rectangle_1[0].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.X = this.rectangle_0.Right;
                    this.point_0.Y = this.rectangle_0.Bottom;
                }
                else if (this.rectangle_1[1].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.Y = this.rectangle_0.Bottom;
                    this.bool_10 = true;
                }
                else if (this.rectangle_1[2].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.X = this.rectangle_0.X;
                    this.point_0.Y = this.rectangle_0.Bottom;
                }
                else if (this.rectangle_1[3].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.X = this.rectangle_0.Right;
                    this.bool_9 = true;
                }
                else if (this.rectangle_1[4].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.X = this.rectangle_0.X;
                    this.bool_9 = true;
                }
                else if (this.rectangle_1[5].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.X = this.rectangle_0.Right;
                    this.point_0.Y = this.rectangle_0.Y;
                }
                else if (this.rectangle_1[6].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0.Y = this.rectangle_0.Y;
                    this.bool_10 = true;
                }
                else if (this.rectangle_1[7].Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.point_0 = this.rectangle_0.Location;
                }
                else if (this.rectangle_0.Contains(e.Location))
                {
                    this.bool_4 = false;
                    this.bool_6 = true;
                }
            }
            base.OnMouseMove(e);
        }
        else
        {
            if (this.bool_5)
            {
                if (this.bool_6)
                {
                    Point location = this.rectangle_0.Location;
                    this.rectangle_0.X = (this.point_2.X + e.X) - this.point_0.X;
                    this.rectangle_0.Y = (this.point_2.Y + e.Y) - this.point_0.Y;
                    if (this.rectangle_0.X < 0)
                    {
                        this.rectangle_0.X = 0;
                    }
                    if (this.rectangle_0.Y < 0)
                    {
                        this.rectangle_0.Y = 0;
                    }
                    if (this.rectangle_0.Right > this.rectangle_2.Width)
                    {
                        this.rectangle_0.X = (this.rectangle_2.Width - this.rectangle_0.Width) - 1;
                    }
                    if (this.rectangle_0.Bottom > this.rectangle_2.Height)
                    {
                        this.rectangle_0.Y = (this.rectangle_2.Height - this.rectangle_0.Height) - 1;
                    }
                    if (base.Location == location)
                    {
                        return;
                    }
                }
                else if ((Math.Abs((int) (e.X - this.point_0.X)) > 1) || (Math.Abs((int) (e.Y - this.point_0.Y)) > 1))
                {
                    if (!this.bool_10)
                    {
                        this.rectangle_0.X = ((this.point_0.X - e.X) < 0) ? this.point_0.X : e.X;
                        this.rectangle_0.Width = Math.Abs((int) (this.point_0.X - e.X));
                    }
                    if (!this.bool_9)
                    {
                        this.rectangle_0.Y = ((this.point_0.Y - e.Y) < 0) ? this.point_0.Y : e.Y;
                        this.rectangle_0.Height = Math.Abs((int) (this.point_0.Y - e.Y));
                    }
                }
                base.Invalidate();
            }
            if ((((this.image_0 != null) && !this.bool_4) && !this.bool_6) && this.bool_2)
            {
                base.Invalidate();
            }
            base.OnMouseMove(e);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if ((this.rectangle_0.Width >= 4) && (this.rectangle_0.Height >= 4))
            {
                this.bool_4 = true;
            }
            else
            {
                this.method_5();
            }
            this.bool_10 = false;
            this.bool_9 = false;
            this.bool_6 = false;
            this.bool_5 = false;
            this.point_2 = this.rectangle_0.Location;
            Cursor.Clip = new Rectangle();
        }
        else if (e.Button == MouseButtons.Right)
        {
            this.method_5();
        }
        base.Invalidate();
        base.OnMouseUp(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        if (this.image_0 != null)
        {
            graphics.DrawImage(this.bitmap_0, 0, 0);
            graphics.DrawImage(this.image_0, this.rectangle_0, this.rectangle_0, GraphicsUnit.Pixel);
        }
        base.OnPaint(e);
        this.vmethod_0(graphics);
        if ((((this.image_0 != null) && !this.bool_4) && (!this.bool_6 && this.bool_8)) && this.bool_2)
        {
            this.vmethod_1(e.Graphics);
        }
    }

    protected virtual void vmethod_0(Graphics graphics_0)
    {
        string text = string.Concat(new object[] { "X:", this.rectangle_0.X, " Y:", this.rectangle_0.Y, " W:", this.rectangle_0.Width + 1, " H:", this.rectangle_0.Height + 1 });
        Size size = TextRenderer.MeasureText(text, this.Font);
        int x = this.rectangle_0.X;
        int y = (this.rectangle_0.Y - size.Height) - 5;
        if (!this.rectangle_2.IsEmpty && ((x + size.Width) >= this.rectangle_2.Right))
        {
            x -= size.Width;
        }
        if (y <= 0)
        {
            y += size.Height + 10;
        }
        this.solidBrush_0.Color = Color.FromArgb(0x7d, 0, 0, 0);
        graphics_0.FillRectangle(this.solidBrush_0, x, y, size.Width, size.Height);
        this.solidBrush_0.Color = this.ForeColor;
        graphics_0.DrawString(text, this.Font, this.solidBrush_0, (float) x, (float) y);
        if (!this.bool_0)
        {
            this.pen_0.Width = 3f;
            this.pen_0.Color = this.color_1;
            graphics_0.DrawRectangle(this.pen_0, this.rectangle_0);
        }
        else
        {
            int num4;
            this.rectangle_1[2].Y = num4 = this.rectangle_0.Y - 2;
            this.rectangle_1[0].Y = this.rectangle_1[1].Y = num4;
            this.rectangle_1[7].Y = num4 = this.rectangle_0.Bottom - 2;
            this.rectangle_1[5].Y = this.rectangle_1[6].Y = num4;
            this.rectangle_1[5].X = num4 = this.rectangle_0.X - 2;
            this.rectangle_1[0].X = this.rectangle_1[3].X = num4;
            this.rectangle_1[7].X = num4 = this.rectangle_0.Right - 2;
            this.rectangle_1[2].X = this.rectangle_1[4].X = num4;
            this.rectangle_1[3].Y = this.rectangle_1[4].Y = (this.rectangle_0.Y + (this.rectangle_0.Height / 2)) - 2;
            this.rectangle_1[1].X = this.rectangle_1[6].X = (this.rectangle_0.X + (this.rectangle_0.Width / 2)) - 2;
            this.pen_0.Width = 1f;
            this.pen_0.Color = this.color_1;
            graphics_0.DrawRectangle(this.pen_0, this.rectangle_0);
            this.solidBrush_0.Color = this.color_0;
            foreach (Rectangle rectangle in this.rectangle_1)
            {
                graphics_0.FillRectangle(this.solidBrush_0, rectangle);
            }
            if ((this.rectangle_0.Width <= 10) || (this.rectangle_0.Height <= 10))
            {
                graphics_0.DrawRectangle(this.pen_0, this.rectangle_0);
            }
        }
    }

    protected virtual void vmethod_1(Graphics graphics_0)
    {
        int x = this.point_1.X + 20;
        int y = this.point_1.Y + 20;
        int width = (this.size_0.Width * this.int_0) + 8;
        int height = ((this.size_0.Width * this.int_0) + 12) + (this.Font.Height * 3);
        if (!this.rectangle_2.IsEmpty)
        {
            if ((x + width) >= this.rectangle_2.Right)
            {
                x -= width + 30;
            }
            if ((y + height) >= this.rectangle_2.Bottom)
            {
                y -= height + 30;
            }
        }
        else
        {
            if ((x + width) >= base.ClientRectangle.Width)
            {
                x -= width + 30;
            }
            if ((y + height) >= base.ClientRectangle.Height)
            {
                y -= height + 30;
            }
        }
        Rectangle rect = new Rectangle(x + 2, y + 2, width - 4, (this.size_0.Width * this.int_0) + 4);
        this.solidBrush_0.Color = Color.FromArgb(200, 0, 0, 0);
        graphics_0.FillRectangle(this.solidBrush_0, x, y, width, height);
        this.pen_0.Width = 2f;
        this.pen_0.Color = Color.White;
        graphics_0.DrawRectangle(this.pen_0, rect);
        using (Bitmap bitmap = new Bitmap(this.size_0.Width, this.size_0.Height, PixelFormat.Format32bppArgb))
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SetClip(new Rectangle(0, 0, this.size_0.Width, this.size_0.Height));
                graphics.DrawImage(this.image_0, -(this.point_1.X - (this.size_0.Width / 2)), -(this.point_1.Y - (this.size_0.Height / 2)));
            }
            using (Bitmap bitmap2 = this.method_2(bitmap, this.int_0))
            {
                graphics_0.DrawImage(bitmap2, (int) (x + 4), (int) (y + 4));
            }
        }
        this.pen_0.Width = this.int_0 - 2;
        this.pen_0.Color = Color.FromArgb(0x7d, 0, 0xff, 0xff);
        int num6 = x + ((width + (((this.size_0.Width % 2) == 0) ? this.int_0 : 0)) / 2);
        int num5 = (y + 2) + ((rect.Height + (((this.Size_0.Height % 2) == 0) ? this.int_0 : 0)) / 2);
        graphics_0.DrawLine(this.pen_0, num6, y + 4, num6, rect.Bottom - 2);
        graphics_0.DrawLine(this.pen_0, x + 4, num5, (x + width) - 4, num5);
        this.solidBrush_0.Color = this.ForeColor;
        Color black = Color.Black;
        if ((((this.point_1.X >= 0) && (this.point_1.Y >= 0)) && (this.point_1.X < this.image_0.Width)) && (this.point_1.Y < this.image_0.Height))
        {
            black = ((Bitmap) this.image_0).GetPixel(this.point_1.X, this.point_1.Y);
        }
        graphics_0.DrawString(string.Concat(new object[] { "Size: ", this.rectangle_0.Width + 1, " x ", this.rectangle_0.Height + 1 }), this.Font, this.solidBrush_0, (float) (x + 2), (float) (rect.Bottom + 2));
        graphics_0.DrawString(string.Concat(new object[] { black.A, ",", black.R, ",", black.G, ",", black.B }), this.Font, this.solidBrush_0, (float) (x + 2), (float) ((rect.Bottom + 2) + this.Font.Height));
        graphics_0.DrawString("0x" + black.A.ToString("X").PadLeft(2, '0') + black.R.ToString("X").PadLeft(2, '0') + black.G.ToString("X").PadLeft(2, '0') + black.B.ToString("X").PadLeft(2, '0'), this.Font, this.solidBrush_0, (float) (x + 2), (float) ((rect.Bottom + 2) + (this.Font.Height * 2)));
        this.solidBrush_0.Color = black;
        graphics_0.FillRectangle(this.solidBrush_0, ((x + width) - 2) - this.Font.Height, ((y + height) - 2) - this.Font.Height, this.Font.Height, this.Font.Height);
        graphics_0.DrawRectangle(Pens.Cyan, ((x + width) - 2) - this.Font.Height, ((y + height) - 2) - this.Font.Height, this.Font.Height, this.Font.Height);
        graphics_0.FillRectangle(this.solidBrush_0, num6 - (this.int_0 / 2), num5 - (this.int_0 / 2), this.int_0, this.int_0);
        graphics_0.DrawRectangle(Pens.Cyan, (int) (num6 - (this.int_0 / 2)), (int) (num5 - (this.int_0 / 2)), (int) (this.int_0 - 1), (int) (this.int_0 - 1));
    }

    [DefaultValue(true), Category("Custom"), Description("获取或设置是否绘制操作框点")]
    public bool Boolean_0
    {
        get
        {
            return this.bool_0;
        }
        set
        {
            if (value != this.bool_0)
            {
                this.bool_0 = value;
                base.Invalidate();
            }
        }
    }

    [DefaultValue(true), Category("Custom"), Description("获取或设置是否限制鼠标操作区域")]
    public bool Boolean_1
    {
        get
        {
            return this.bool_1;
        }
        set
        {
            this.bool_1 = value;
        }
    }

    [DefaultValue(true), Description("获取或设置是否绘制信息展示"), Category("Custom")]
    public bool Boolean_2
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            this.bool_2 = value;
        }
    }

    [Description("获取或设置是否根据图像大小自动调整控件尺寸"), Category("Custom"), DefaultValue(true)]
    public bool Boolean_3
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            if (value && (this.image_0 != null))
            {
                base.Width = this.image_0.Width;
                base.Height = this.image_0.Height;
            }
            this.bool_3 = value;
        }
    }

    [Browsable(false)]
    public bool Boolean_4
    {
        get
        {
            return this.bool_4;
        }
    }

    [Browsable(false)]
    public bool Boolean_5
    {
        get
        {
            return this.bool_5;
        }
    }

    [Browsable(false)]
    public bool Boolean_6
    {
        get
        {
            return this.bool_6;
        }
    }

    [Browsable(false)]
    public bool Boolean_7
    {
        get
        {
            return this.bool_7;
        }
        set
        {
            this.bool_7 = value;
            if (!this.bool_7)
            {
                this.Cursor = Cursors.Default;
            }
        }
    }

    [Category("Custom"), DefaultValue(typeof(Color), "Yellow"), Description("获取或设置操作框点的颜色")]
    public Color Color_0
    {
        get
        {
            return this.color_0;
        }
        set
        {
            this.color_0 = value;
        }
    }

    [Category("Custom"), Description("获取或设置操作框线条的颜色"), DefaultValue(typeof(Color), "Cyan")]
    public Color Color_1
    {
        get
        {
            return this.color_1;
        }
        set
        {
            this.color_1 = value;
        }
    }

    [Category("Custom"), Description("获取或设置用于被操作的图像")]
    public Image Image_0
    {
        get
        {
            return this.image_0;
        }
        set
        {
            this.image_0 = value;
            this.method_4();
        }
    }

    [Category("Custom"), Description("获取或设置图像放大的倍数"), DefaultValue(7)]
    public int Int32_0
    {
        get
        {
            return this.int_0;
        }
        set
        {
            this.int_0 = value;
            if (this.int_0 < 3)
            {
                this.int_0 = 3;
            }
            if (this.int_0 > 10)
            {
                this.int_0 = 10;
            }
        }
    }

    [Browsable(false)]
    public Rectangle Rectangle_0
    {
        get
        {
            Rectangle rectangle = this.rectangle_0;
            rectangle.Width++;
            rectangle.Height++;
            return rectangle;
        }
    }

    [DefaultValue(typeof(Size), "15,15"), Description("获取或设置放大图像的原图大小尺寸"), Category("Custom")]
    public Size Size_0
    {
        get
        {
            return this.size_0;
        }
        set
        {
            this.size_0 = value;
            if (this.size_0.Width < 5)
            {
                this.size_0.Width = 5;
            }
            if (this.size_0.Width > 20)
            {
                this.size_0.Width = 20;
            }
            if (this.size_0.Height < 5)
            {
                this.size_0.Height = 5;
            }
            if (this.size_0.Height > 20)
            {
                this.size_0.Height = 20;
            }
        }
    }
}

