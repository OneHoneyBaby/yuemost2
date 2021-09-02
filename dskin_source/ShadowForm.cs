using DSkin;
using DSkin.Common;
using DSkin.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class ShadowForm : DSkinWindowForm
{
    private bool bool_3 = false;
    private bool bool_4 = true;
    private double double_0 = 1.0;
    private FormWindowState formWindowState_0;
    private int int_0 = 0;
    private object object_0;
    private object object_1;
    private RoundStyle roundStyle_0 = RoundStyle.All;

    public ShadowForm(DSkinForm dskinForm_0)
    {
        this.InitializeComponent();
        this.object_0 = dskinForm_0;
        base.Owner = dskinForm_0;
        dskinForm_0.Shown += new EventHandler(this.method_6);
        dskinForm_0.SizeChanged += new EventHandler(this.method_3);
        dskinForm_0.VisibleChanged += new EventHandler(this.method_2);
        dskinForm_0.LocationChanged += new EventHandler(this.method_4);
        dskinForm_0.FormClosed += new FormClosedEventHandler(this.method_5);
        dskinForm_0.OpacityChanged += new EventHandler(this.lytLjrJgUd);
        this.formWindowState_0 = dskinForm_0.WindowState;
        base.TopMost = dskinForm_0.TopMost;
        base.Icon = dskinForm_0.Icon;
        this.method_10();
    }

    protected override void Dispose(bool disposing)
    {
        if (this.object_1 != null)
        {
            this.object_1.Dispose();
            this.object_1 = null;
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        base.SuspendLayout();
        base.ClientSize = new Size(0x11c, 0x106);
        base.ControlBox = false;
        base.FormBorderStyle = FormBorderStyle.None;
        base.Name = "ShadowForm";
        base.ShowIcon = false;
        base.ShowInTaskbar = false;
        base.StartPosition = FormStartPosition.Manual;
        base.ResumeLayout(false);
    }

    private void lytLjrJgUd(object sender, EventArgs e)
    {
        if (!((!this.object_0.Visible || !this.object_0.ShowShadow) || this.bool_4))
        {
            this.double_0 = this.object_0.Opacity;
            this.method_7();
        }
    }

    private void method_10()
    {
        DSkin.NativeMethods.GetWindowLong(base.Handle, -20);
        DSkin.NativeMethods.SetWindowLong(base.Handle, -20, 0x80020);
    }

    private void method_11(Graphics graphics_0)
    {
        GraphicsPath path;
        if (((this.object_1 == null) || (this.roundStyle_0 != this.object_0.RoundStyle)) || (this.int_0 != this.object_0.Radius))
        {
            this.roundStyle_0 = this.object_0.RoundStyle;
            this.int_0 = this.object_0.Radius;
            if (this.object_1 != null)
            {
                this.object_1.Dispose();
                this.object_1 = null;
            }
            int width = ((this.object_0.ShadowWidth + this.object_0.Radius) * 2) + 15;
            int num2 = 0x10;
            using (Bitmap bitmap = new Bitmap(width, width))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (path = GraphicsPathHelper.CreatePath(new Rectangle(this.object_0.ShadowWidth, this.object_0.ShadowWidth, (this.object_0.Radius * 2) + num2, (this.object_0.Radius * 2) + num2), this.object_0.Radius, this.object_0.RoundStyle, true))
                    {
                        using (SolidBrush brush = new SolidBrush(this.object_0.ShadowColor))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            graphics.FillPath(brush, path);
                            using (Pen pen = new Pen(brush, 2f))
                            {
                                graphics.DrawPath(pen, path);
                            }
                        }
                        this.object_1 = ImageEffects.GaussianBlur(bitmap, this.object_0.ShadowWidth);
                    }
                }
            }
        }
        ControlRender.SudokuDrawImage(graphics_0, (Image) this.object_1, new Rectangle(0, 0, base.Width, base.Height), new Padding(this.object_0.ShadowWidth + this.object_0.Radius), new Rectangle(0, 0, base.Width, base.Height), false);
        using (path = GraphicsPathHelper.CreatePath(this.object_0.RealClientRect, this.int_0, this.roundStyle_0, true))
        {
            graphics_0.TranslateTransform((float) this.object_0.ShadowWidth, (float) this.object_0.ShadowWidth);
            graphics_0.SetClip(path);
            graphics_0.Clear(Color.Transparent);
        }
    }

    [CompilerGenerated]
    private void method_12(Graphics graphics_0)
    {
        graphics_0.Clear(Color.Transparent);
        this.method_11(graphics_0);
    }

    [CompilerGenerated]
    private void method_13()
    {
        this.object_0.Focus();
    }

    private void method_2(object sender, EventArgs e)
    {
        if (!this.bool_4)
        {
            if (this.object_0.Visible && this.object_0.ShowShadow)
            {
                this.double_0 = this.object_0.Opacity;
            }
            else
            {
                this.double_0 = 0.0;
            }
            this.method_7();
            if (this.object_0.ShowShadow)
            {
                base.SendToBack();
                this.object_0.BringToFront();
            }
        }
    }

    private void method_3(object sender, EventArgs e)
    {
        if (((this.formWindowState_0 == FormWindowState.Minimized) && (this.object_0.WindowState == FormWindowState.Normal)) && (((this.object_0.FormBorderStyle != FormBorderStyle.None) && (this.object_0.FormBorderStyle != FormBorderStyle.FixedToolWindow)) && (this.object_0.FormBorderStyle != FormBorderStyle.SizableToolWindow)))
        {
            <>c__DisplayClass3 class2;
            EventHandler handler = null;
            Timer timer = new Timer {
                Interval = 300,
                Enabled = true
            };
            handler = new EventHandler(class2.<owner_SizeChanged>b__1);
            timer.Tick += handler;
        }
        else
        {
            if (this.object_0.WindowState == FormWindowState.Minimized)
            {
                this.double_0 = 0.0;
                base.Owner = null;
            }
            else
            {
                base.Owner = (Form) this.object_0;
                this.object_0.BringToFront();
                this.double_0 = this.object_0.Opacity;
            }
            this.method_7();
        }
        this.formWindowState_0 = this.object_0.WindowState;
    }

    private void method_4(object sender, EventArgs e)
    {
        base.Location = new Point(this.object_0.Left - this.object_0.ShadowWidth, this.object_0.Top - this.object_0.ShadowWidth);
    }

    private void method_5(object sender, EventArgs e)
    {
        if (!this.bool_3)
        {
            this.bool_3 = true;
            base.Close();
        }
    }

    private void method_6(object sender, EventArgs e)
    {
        this.double_0 = this.object_0.Opacity;
        if (((this.object_0.FormBorderStyle != FormBorderStyle.None) && (this.object_0.FormBorderStyle != FormBorderStyle.FixedToolWindow)) && (this.object_0.FormBorderStyle != FormBorderStyle.SizableToolWindow))
        {
            <>c__DisplayClass7 class2;
            Timer timer = new Timer {
                Interval = 300,
                Enabled = true
            };
            timer.Tick += new EventHandler(class2.<owner_Shown>b__6);
        }
        else
        {
            this.method_7();
            this.bool_4 = false;
        }
        this.object_0.TopMost = this.object_0.TopMost;
    }

    private void method_7()
    {
        Action<Graphics> action = null;
        MethodInvoker method = null;
        if (!base.DesignMode && !this.object_0.IsPlaying)
        {
            if (((this.object_0.ShowShadow && (this.object_0.WindowState != FormWindowState.Maximized)) && !base.IsDisposed) && this.object_0.Visible)
            {
                if (base.TopMost != this.object_0.TopMost)
                {
                    base.TopMost = this.object_0.TopMost;
                }
                base.Location = new Point(this.object_0.Left - this.object_0.ShadowWidth, this.object_0.Top - this.object_0.ShadowWidth);
                base.Size = new Size(this.object_0.Width + (this.object_0.ShadowWidth * 2), this.object_0.Height + (this.object_0.ShadowWidth * 2));
                base.Show();
                if (action == null)
                {
                    action = new Action<Graphics>(this.method_12);
                }
                this.UpdateLayeredWindow(this.double_0, action);
                if (this.Focused)
                {
                    if (method == null)
                    {
                        method = new MethodInvoker(this.method_13);
                    }
                    base.BeginInvoke(method);
                }
            }
            else
            {
                this.method_8();
            }
        }
    }

    public void method_8()
    {
        if (!base.IsDisposed)
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            {
                this.double_0 = 0.0;
                this.UpdateLayeredWindow(bitmap);
            }
            base.Hide();
        }
    }

    public void method_9()
    {
        this.double_0 = 1.0;
        this.method_7();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (!((e.CloseReason == CloseReason.FormOwnerClosing) || this.bool_3))
        {
            this.bool_3 = true;
            this.object_0.Close();
        }
        base.OnFormClosing(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (((this.object_0 != null) && !this.object_0.IsDisposed) && (base.Size != new Size(this.object_0.Width + (this.object_0.ShadowWidth * 2), this.object_0.Height + (this.object_0.ShadowWidth * 2))))
        {
            base.Size = new Size(this.object_0.Width + (this.object_0.ShadowWidth * 2), this.object_0.Height + (this.object_0.ShadowWidth * 2));
            base.Owner = (Form) this.object_0;
        }
    }
}

