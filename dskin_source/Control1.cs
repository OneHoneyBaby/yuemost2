using DSkin.Controls;
using DSkin.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

[Designer(typeof(ToolButtonDesigner))]
internal class Control1 : Control
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private Container container_0 = null;
    private Image image_0;

    public Control1()
    {
        this.method_6();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.container_0 != null))
        {
            this.container_0.Dispose();
        }
        base.Dispose(disposing);
    }

    public Image method_0()
    {
        return this.image_0;
    }

    public void method_1(Image image_1)
    {
        this.image_0 = image_1;
        base.Invalidate();
    }

    public bool method_2()
    {
        return this.bool_0;
    }

    public void method_3(bool bool_4)
    {
        this.bool_0 = bool_4;
        if (!this.bool_0)
        {
            this.bool_1 = false;
        }
    }

    public bool method_4()
    {
        return this.bool_1;
    }

    public void method_5(bool bool_4)
    {
        this.bool_1 = bool_4;
        if (this.bool_1)
        {
            this.bool_0 = true;
        }
    }

    private void method_6()
    {
        this.container_0 = new Container();
    }

    protected override void OnClick(EventArgs e)
    {
        if (this.bool_0)
        {
            if (this.bool_2)
            {
                if (!this.bool_1)
                {
                    this.bool_2 = false;
                    base.Invalidate();
                }
            }
            else
            {
                this.bool_2 = true;
                base.Invalidate();
                int num = 0;
                int count = base.Parent.Controls.Count;
                while (num < count)
                {
                    if (((base.Parent.Controls[num] is Control1) && (base.Parent.Controls[num] != this)) && ((Control1) base.Parent.Controls[num]).bool_2)
                    {
                        ((Control1) base.Parent.Controls[num]).IsSelected = false;
                    }
                    num++;
                }
            }
        }
        base.Focus();
        base.OnClick(e);
    }

    protected override void OnDoubleClick(EventArgs e)
    {
        this.OnClick(e);
        base.OnDoubleClick(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        this.bool_3 = true;
        base.Invalidate();
        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        this.bool_3 = false;
        base.Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        if (this.bool_3)
        {
            graphics.FillRectangle(Brushes.LightBlue, base.ClientRectangle);
            graphics.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
        }
        if (this.image_0 == null)
        {
            graphics.DrawImage(Resources.none, new Rectangle(2, 2, 0x11, 0x11));
        }
        else
        {
            graphics.DrawImage(this.image_0, new Rectangle(2, 2, 0x11, 0x11));
        }
        graphics.DrawString(this.Text, this.Font, Brushes.Black, 21f, (float) ((base.Height - this.Font.Height) / 2));
        if (this.bool_2)
        {
            graphics.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
        }
        base.OnPaint(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        base.SetBoundsCore(x, y, TextRenderer.MeasureText(this.Text, this.Font).Width + 0x15, 0x15, specified);
    }

    public bool IsSelected
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            if (value != this.bool_2)
            {
                this.bool_2 = value;
                base.Invalidate();
            }
        }
    }

    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            base.Text = value;
            Size size = TextRenderer.MeasureText(this.Text, this.Font);
            base.Width = size.Width + 0x15;
        }
    }
}

