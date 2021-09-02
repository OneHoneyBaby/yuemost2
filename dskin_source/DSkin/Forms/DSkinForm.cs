namespace DSkin.Forms
{
    using DSkin;
    using DSkin.Animations;
    using DSkin.Common;
    using DSkin.Controls;
    using DSkin.DirectUI;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [ComVisible(true)]
    public class DSkinForm : DSkinWindowForm, ILayered, IDuiContainer, IDuiDesigner, ILayeredContainer
    {
        public AnchorStyles Aanhor = AnchorStyles.None;
        [CompilerGenerated]
        private static Action<Graphics> action_0;
        [CompilerGenerated]
        private static Action<Graphics> action_1;
        private DSkin.Animations.Animation animation_0 = new DSkin.Animations.Animation();
        private AnimationTypes animationTypes_0 = AnimationTypes.FadeinFadeoutEffect;
        private Bitmap bitmap_0;
        private bool bool_10 = false;
        private bool bool_11 = true;
        private bool bool_12 = false;
        private bool bool_13 = false;
        private bool bool_14 = true;
        private bool bool_15 = false;
        private bool bool_16 = false;
        private bool bool_17 = true;
        internal bool bool_3 = false;
        private bool bool_4 = false;
        private bool bool_5 = true;
        private bool bool_6 = false;
        private bool bool_7 = true;
        private bool bool_8 = true;
        private bool bool_9 = true;
        private Color color_0 = Color.Transparent;
        private Color color_1 = Color.Black;
        private Color color_2 = Control.DefaultBackColor;
        private Color[] color_3;
        private Color color_4 = Color.Black;
        private Color color_5 = Color.White;
        [CompilerGenerated]
        private static Comparison<DuiBaseControl> comparison_0;
        private DialogResult dialogResult_0 = DialogResult.Cancel;
        private double double_0 = 1.0;
        private double double_1 = 1.0;
        private DSkinForm dskinForm_0;
        private DSkinToolTip dskinToolTip_0 = new DSkinToolTip();
        private DSkinWindowForm dskinWindowForm_0;
        private SystemButton fkgkoKtOmQ;
        private Font font_0 = new Font("宋体", 10f);
        private System.Windows.Forms.FormBorderStyle formBorderStyle_0 = System.Windows.Forms.FormBorderStyle.Sizable;
        private IContainer icontainer_0 = null;
        private IImageEffect iimageEffect_0;
        private ImageAttributes imageAttributes_0 = null;
        private int int_0 = 0;
        private int int_1 = 1;
        private int int_2 = 0;
        private int int_3 = 8;
        private int int_4 = 30;
        private int int_5 = 5;
        private int int_6 = 0;
        private int int_7;
        private MoveModes moveModes_0 = MoveModes.Whole;
        private System.Windows.Forms.Padding padding_0 = new System.Windows.Forms.Padding(4);
        private System.Windows.Forms.Padding padding_1 = new System.Windows.Forms.Padding(0, 4, 0, 0);
        private Point point_0 = new Point();
        private Point point_1 = new Point();
        private Point point_2;
        private Rectangle rectangle_0;
        private Rectangle rectangle_1 = new Rectangle(5, 5, 0x10, 0x10);
        private DSkin.Common.RoundStyle roundStyle_0 = DSkin.Common.RoundStyle.All;
        private ShadowForm shadowForm_0;
        private Size size_1;
        private SystemButton systemButton_0;
        private SystemButton systemButton_1;
        private SystemButton systemButton_2;
        private SystemButtonCollection systemButtonCollection_0;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private TextShowModes textShowModes_0 = TextShowModes.Halo;
        private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();
        private DuiBaseControl VjJkjtMexe = new DuiBaseControl();
        private Color xjekKcFyly = Color.Transparent;

        public event EventHandler<InvalidateEventArgs> LayeredInvalidated;

        public event EventHandler<PaintEventArgs> LayeredPaintBackground;

        [Description("控件重绘时候发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public event EventHandler OpacityChanged;

        [Description("系统按钮点击事件")]
        public event EventHandler<SystemButtonMouseClickEventArgs> SystemButtonMouseClick;

        [Description("切换主题时候发生")]
        public event EventHandler ThemeChanged;

        public DSkinForm()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            if (base.DesignMode)
            {
                base.SetStyle(ControlStyles.ResizeRedraw, true);
            }
            base.UpdateStyles();
            this.VjJkjtMexe.Parent = this;
            this.VjJkjtMexe.ParentInvalidate = false;
            this.VjJkjtMexe.Size = base.Size;
            this.VjJkjtMexe.PrePaint += new EventHandler<PaintEventArgs>(this.method_10);
            this.VjJkjtMexe.PaintBackground += new EventHandler<PaintEventArgs>(this.method_9);
            this.VjJkjtMexe.Paint += new EventHandler<PaintEventArgs>(this.method_11);
            this.VjJkjtMexe.Invalidated += new EventHandler<InvalidateEventArgs>(this.method_18);
            this.InitializeComponent();
            base.Padding = this.DefaultPadding;
        }

        private void animation_0_AnimationStart(object sender, EventArgs e)
        {
            this.bool_15 = true;
            this.size_1 = base.Size;
            this.point_2 = base.Location;
            this.LayeredPaint();
            this.animation_0.Original = this.Canvas;
            DSkinWindowForm form = new DSkinWindowForm {
                Size = base.Size,
                Location = base.Location,
                ShowInTaskbar = false,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            };
            this.dskinWindowForm_0 = form;
            this.dskinWindowForm_0.Show(this);
            if (this.bool_10 && (this.shadowForm_0 != null))
            {
                this.shadowForm_0.method_8();
            }
        }

        protected void CalcDeltaRect()
        {
            if (base.WindowState == FormWindowState.Maximized)
            {
                Rectangle bounds = base.Bounds;
                Rectangle empty = Rectangle.Empty;
                if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
                {
                    empty = Screen.GetBounds(this);
                }
                else
                {
                    empty = Screen.GetWorkingArea(this);
                }
                empty.X -= this.padding_0.Left;
                empty.Y -= this.padding_0.Top;
                empty.Width += this.padding_0.Horizontal;
                empty.Height += this.padding_0.Vertical;
                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;
                if (bounds.Left < empty.Left)
                {
                    x = empty.Left - bounds.Left;
                }
                if (bounds.Top < empty.Top)
                {
                    y = empty.Top - bounds.Top;
                }
                if (bounds.Width > empty.Width)
                {
                    width = bounds.Width - empty.Width;
                }
                if (bounds.Height > empty.Height)
                {
                    height = bounds.Height - empty.Height;
                }
                this.rectangle_0 = new Rectangle(x, y, width, height);
            }
            else
            {
                this.rectangle_0 = Rectangle.Empty;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.dskinWindowForm_0 != null)
            {
                this.dskinWindowForm_0.Dispose();
            }
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            this.timer_0.Dispose();
            this.Animation.Dispose();
            if (this.imageAttributes_0 != null)
            {
                this.imageAttributes_0.Dispose();
                this.imageAttributes_0 = null;
            }
            this.DisposeCanvas();
            base.Dispose(disposing);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void DisposeCanvas()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
        }

        public void DoEffect(Func<bool> action)
        {
            this.DoEffect(15, action);
        }

        public void DoEffect(int interval, Func<bool> action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = interval,
                Enabled = true
            };
            timer.Tick += delegate (object sender, EventArgs e) {
                if (!action.Invoke())
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
        }

        protected virtual void DrawCaption(Graphics g, Rectangle invalidateRect)
        {
            int lightWidth = (this.textShowModes_0 == TextShowModes.Halo) ? this.int_5 : 0;
            int num2 = this.bool_14 ? 20 : 5;
            Rectangle rect = new Rectangle(0, 0, (base.Width - this.point_1.X) - this.int_0, this.CaptionHeight);
            Rectangle rectangle2 = new Rectangle(this.point_1.X + num2, this.point_1.Y + 5, (base.Width - this.point_1.X) - this.int_0, this.int_4);
            if (!invalidateRect.IsEmpty && (((invalidateRect.Contains(rect) || invalidateRect.IntersectsWith(rect)) || (invalidateRect == rect)) || rect.Contains(invalidateRect)))
            {
                if (this.textShowModes_0 != TextShowModes.None)
                {
                    StringFormat format = new StringFormat {
                        Alignment = this.bool_12 ? StringAlignment.Center : StringAlignment.Near,
                        Trimming = StringTrimming.EllipsisCharacter,
                        FormatFlags = StringFormatFlags.NoWrap
                    };
                    using (StringFormat format2 = format)
                    {
                        ImageEffects.DrawLightString(this.Text, g, this.font_0, this.color_4, this.color_5, rectangle2, format2, lightWidth, this.textRenderingHint_0);
                    }
                }
                if (this.bool_14 && (this.Icon != null))
                {
                    g.DrawIcon(this.Icon, this.IconRectangle);
                }
            }
        }

        private void dskinForm_0_ThemeChanged(object sender, EventArgs e)
        {
            if (base.IsDisposed && (this.dskinForm_0 != null))
            {
                this.dskinForm_0.ThemeChanged -= new EventHandler(this.dskinForm_0_ThemeChanged);
                this.dskinForm_0 = null;
            }
            if (this.bool_6)
            {
                this.SetTheme(this.dskinForm_0);
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(DSkinForm));
            base.SuspendLayout();
            this.AllowDrop = true;
            base.AutoScaleMode = AutoScaleMode.None;
            base.ClientSize = new Size(0x11c, 0x106);
            this.DoubleBuffered = true;
            this.Icon = (System.Drawing.Icon) manager.GetObject("$this.Icon");
            base.Name = "DSkinForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DSkinForm";
            base.ResumeLayout(false);
        }

        public void Invalidate()
        {
            this.Invalidate(new Rectangle(0, 0, base.Width, base.Height));
        }

        public void Invalidate(Rectangle rect)
        {
            this.VjJkjtMexe.Invalidate(rect);
        }

        public void LayeredPaint()
        {
            this.LayeredPaint(new Rectangle(0, 0, base.Width, base.Height));
        }

        public virtual void LayeredPaint(Rectangle invalidateRect)
        {
            Action<Graphics> action = null;
            Action<Graphics> action2 = null;
            if ((base.Visible && (base.WindowState != FormWindowState.Minimized)) && !invalidateRect.IsEmpty)
            {
                if (((this.IsLayeredWindowForm && !this.bool_15) && !base.DesignMode) && (this.imageAttributes_0 == null))
                {
                    if (action == null)
                    {
                        action = g => this.method_12(invalidateRect, g);
                    }
                    this.UpdateLayeredWindow(this.double_0, action);
                }
                else
                {
                    if (this.bitmap_0 != null)
                    {
                        Graphics graphics;
                        if (this.imageAttributes_0 != null)
                        {
                            using (graphics = Graphics.FromImage(this.bitmap_0))
                            {
                                this.method_12(invalidateRect, graphics);
                            }
                            if (action2 == null)
                            {
                                action2 = delegate (Graphics g) {
                                    g.SetClip(invalidateRect);
                                    g.Clear(Color.Transparent);
                                    g.DrawImage(this.bitmap_0, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.Width, this.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
                                };
                            }
                            this.UpdateLayeredWindow(this.double_0, action2);
                            return;
                        }
                        using (graphics = Graphics.FromImage(this.bitmap_0))
                        {
                            this.method_12(invalidateRect, graphics);
                            return;
                        }
                    }
                    this.method_15();
                    this.LayeredPaint();
                }
            }
        }

        private void method_10(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (this.color_3 != null)
            {
                ControlRender.DrawGradientColor(g, this.color_3, 90f, new Rectangle(0, 0, base.Width, this.int_4));
            }
        }

        private void method_11(object sender, PaintEventArgs e)
        {
            this.method_14(e.Graphics, e.ClipRectangle);
            if (!string.IsNullOrEmpty(this.Text))
            {
                this.DrawCaption(e.Graphics, e.ClipRectangle);
            }
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                this.method_16(e.Graphics, e.ClipRectangle);
            }
            this.method_13(e.ClipRectangle, e.Graphics);
        }

        private void method_12(Rectangle rectangle_2, Graphics graphics_0)
        {
            graphics_0.SmoothingMode = SmoothingMode.HighSpeed;
            graphics_0.CompositingQuality = CompositingQuality.HighSpeed;
            graphics_0.SetClip(rectangle_2);
            if (!(!this.IsLayeredWindowForm || base.DesignMode))
            {
                graphics_0.Clear(this.color_2);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(this.color_2))
                {
                    graphics_0.FillRectangle(brush, rectangle_2);
                }
            }
            this.PrePaint(graphics_0, rectangle_2);
            this.OnLayeredPaint(new PaintEventArgs(graphics_0, rectangle_2));
        }

        private void method_13(Rectangle rectangle_2, Graphics graphics_0)
        {
            Pen pen;
            GraphicsPath path;
            if ((this.int_1 > 0) && (this.color_0 != Color.Transparent))
            {
                Rectangle rect = new Rectangle(this.int_1, this.int_1, base.Width - (2 * this.int_1), base.Height - (2 * this.int_1));
                if (!((((this.int_6 != 0) || !rectangle_2.IntersectsWith(rect)) || rect.Contains(rectangle_2)) ? (this.int_6 <= 0) : false))
                {
                    using (path = GraphicsPathHelper.CreatePath(new Rectangle(0, 0, base.Width, base.Height), this.int_6, this.RoundStyle, true))
                    {
                        using (pen = new Pen(this.color_0, (float) this.int_1))
                        {
                            graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                            graphics_0.DrawPath(pen, path);
                        }
                    }
                }
            }
            if (this.xjekKcFyly != Color.Transparent)
            {
                using (path = GraphicsPathHelper.CreatePath(new Rectangle(this.int_1, this.int_1, base.Width - (this.int_1 * 2), base.Height - (this.int_1 * 2)), this.int_6, this.RoundStyle, true))
                {
                    using (pen = new Pen(this.xjekKcFyly, 1f))
                    {
                        graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics_0.DrawPath(pen, path);
                    }
                }
            }
        }

        private void method_14(Graphics graphics_0, Rectangle rectangle_2)
        {
            this.int_0 = 0;
            if (this.bool_7 && base.ControlBox)
            {
                this.CloseBox.Location = new Point((base.Width - this.CloseBox.Size.Width) - this.point_0.X, this.point_0.Y);
                if (rectangle_2.IntersectsWith(this.CloseBox.Bounds))
                {
                    this.CloseBox.DrawButton(graphics_0, rectangle_2);
                }
                this.int_0 = (base.Width - this.CloseBox.Location.X) + this.CloseBox.Size.Width;
                if (base.MaximizeBox)
                {
                    this.MaxBox.Location = new Point((((base.Width - this.CloseBox.Size.Width) - this.MinBox.Size.Width) - this.point_0.X) - this.int_2, this.point_0.Y);
                    this.NormalBox.Location = this.MaxBox.Location;
                    if (rectangle_2.IntersectsWith(this.MaxBox.Bounds))
                    {
                        if (base.WindowState == FormWindowState.Normal)
                        {
                            this.MaxBox.Visible = true;
                            this.NormalBox.Visible = false;
                            this.MaxBox.DrawButton(graphics_0, rectangle_2);
                            this.int_0 += this.MaxBox.Size.Width + this.int_2;
                        }
                        else if (base.WindowState == FormWindowState.Maximized)
                        {
                            this.MaxBox.Visible = false;
                            this.NormalBox.Visible = true;
                            this.NormalBox.DrawButton(graphics_0, rectangle_2);
                            this.int_0 += this.NormalBox.Size.Width + this.int_2;
                        }
                    }
                }
                else
                {
                    this.MaxBox.Visible = false;
                    this.NormalBox.Visible = false;
                }
                if (base.MinimizeBox)
                {
                    this.MinBox.Location = new Point(((((base.Width - this.CloseBox.Size.Width) - this.MinBox.Size.Width) - (base.MaximizeBox ? (this.MaxBox.Size.Width + this.int_2) : 0)) - this.point_0.X) - this.int_2, this.point_0.Y);
                    if (rectangle_2.IntersectsWith(this.MinBox.Bounds))
                    {
                        this.MinBox.DrawButton(graphics_0, rectangle_2);
                    }
                    this.int_0 += this.MinBox.Size.Width + this.int_2;
                }
                else
                {
                    this.MinBox.Visible = false;
                }
                int x = (((base.Width - (base.MaximizeBox ? (this.MaxBox.Size.Width + this.int_2) : 0)) - (base.MinimizeBox ? (this.MinBox.Size.Width + this.int_2) : 0)) - this.CloseBox.Size.Width) - this.point_0.X;
                foreach (SystemButton button in this.SystemButtons)
                {
                    if (button.Visible)
                    {
                        this.int_0 += button.Size.Width + this.int_2;
                        x -= button.Size.Width + this.int_2;
                        button.Location = new Point(x, this.point_0.Y);
                        button.DrawButton(graphics_0, rectangle_2);
                    }
                }
            }
        }

        private void method_15()
        {
            int width = base.Width;
            if (base.Width <= 0)
            {
                width = 1;
            }
            int height = base.Height;
            if (base.Height <= 0)
            {
                height = 1;
            }
            this.bitmap_0 = new Bitmap(width, height);
        }

        private void method_16(Graphics graphics_0, Rectangle rectangle_2)
        {
            Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
            for (int i = base.Controls.Count - 1; i >= 0; i--)
            {
                Control control = base.Controls[i];
                ControlRender.smethod_0(control, control.Bounds, graphics_0, rectangle_2, rectangle);
            }
        }

        private void method_17()
        {
            this.Invalidate(new Rectangle(0, 0, base.Width, this.int_4));
        }

        private void method_18(object sender, InvalidateEventArgs e)
        {
            if (!(!base.DesignMode && this.IsLayeredMode))
            {
                base.Invalidate(e.InvalidRect);
            }
            else
            {
                this.OnLayeredInvalidated(e);
            }
        }

        private void method_19(ref Message message_0)
        {
            message_0.Result = (IntPtr) 1;
        }

        private void method_2()
        {
            if (base.Left <= 0)
            {
                this.Aanhor = AnchorStyles.Left;
            }
            else if (base.Left >= (Screen.PrimaryScreen.Bounds.Width - base.Width))
            {
                this.Aanhor = AnchorStyles.Right;
            }
            else if (base.Top <= 0)
            {
                this.Aanhor = AnchorStyles.Top;
            }
            else if ((base.Top + base.Height) >= Screen.PrimaryScreen.Bounds.Height)
            {
                this.Aanhor = AnchorStyles.Bottom;
            }
            else
            {
                this.Aanhor = AnchorStyles.None;
            }
        }

        private void method_20(ref Message message_0)
        {
            Point p = new Point(message_0.LParam.ToInt32());
            p = base.PointToClient(p);
            if (this.IconRectangle.Contains(p) && this.ShowSystemMenu)
            {
                message_0.Result = new IntPtr(3);
            }
            else
            {
                if (this.bool_8 && (base.WindowState == FormWindowState.Normal))
                {
                    if ((p.X < 5) && (p.Y < 5))
                    {
                        message_0.Result = new IntPtr(13);
                        return;
                    }
                    if ((p.X > (base.Width - 5)) && (p.Y < 5))
                    {
                        message_0.Result = new IntPtr(14);
                        return;
                    }
                    if ((p.X < 5) && (p.Y > (base.Height - 5)))
                    {
                        message_0.Result = new IntPtr(0x10);
                        return;
                    }
                    if ((p.X > (base.Width - 5)) && (p.Y > (base.Height - 5)))
                    {
                        message_0.Result = new IntPtr(0x11);
                        return;
                    }
                    if (p.Y < 3)
                    {
                        message_0.Result = new IntPtr(12);
                        return;
                    }
                    if (p.Y > (base.Height - 3))
                    {
                        message_0.Result = new IntPtr(15);
                        return;
                    }
                    if (p.X < 3)
                    {
                        message_0.Result = new IntPtr(10);
                        return;
                    }
                    if (p.X > (base.Width - 3))
                    {
                        message_0.Result = new IntPtr(11);
                        return;
                    }
                }
                message_0.Result = new IntPtr(1);
            }
        }

        private void method_21(ref Message message_0)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                base.WndProc(ref message_0);
            }
            else
            {
                DSkin.NativeMethods.MINMAXINFO structure = (DSkin.NativeMethods.MINMAXINFO) Marshal.PtrToStructure(message_0.LParam, typeof(DSkin.NativeMethods.MINMAXINFO));
                if (this.MaximumSize != Size.Empty)
                {
                    structure.maxTrackSize = this.MaximumSize;
                }
                else
                {
                    Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                    Rectangle rectangle2 = Screen.GetWorkingArea(this);
                    int num = (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) ? 0 : ((Environment.OSVersion.Version.Major < 6) ? 0 : -1);
                    if (workingArea.Equals(rectangle2))
                    {
                        structure.maxPosition = new Point(rectangle2.X, rectangle2.Y);
                    }
                    else
                    {
                        structure.maxPosition = new Point(0, 0);
                    }
                    structure.maxTrackSize = new Size(rectangle2.Width, rectangle2.Height + num);
                }
                if (this.MinimumSize != Size.Empty)
                {
                    structure.minTrackSize = this.MinimumSize;
                }
                else
                {
                    structure.minTrackSize = new Size((((this.int_0 + this.point_0.X) + SystemInformation.SmallIconSize.Width) + (this.BorderPadding.Left * 2)) + 3, this.CaptionHeight);
                }
                Marshal.StructureToPtr(structure, message_0.LParam, false);
            }
        }

        [CompilerGenerated]
        private bool method_22()
        {
            if (this.Opacity > 0.04)
            {
                this.Opacity -= 0.04;
                return true;
            }
            base.Hide();
            base.Close();
            base.DialogResult = this.dialogResult_0;
            return false;
        }

        [CompilerGenerated]
        private void method_23(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                this.bool_16 = false;
            }
        }

        private void method_3()
        {
            if (base.Region != null)
            {
                base.Region.Dispose();
            }
            if ((this.Radius == 0) || (this.RoundStyle == DSkin.Common.RoundStyle.None))
            {
                base.Region = new Region(this.RealClientRect);
            }
            else
            {
                SkinTools.CreateRegion(this, this.RealClientRect, this.Radius, this.RoundStyle);
            }
        }

        private void method_4(object sender, EventArgs e)
        {
            if (!this.bool_16)
            {
                base.FormBorderStyle = this.formBorderStyle_0;
                this.bool_15 = false;
                this.bool_4 = false;
                this.LayeredPaint();
                this.dskinWindowForm_0.Dispose();
                this.dskinWindowForm_0 = null;
                if (this.bool_10 && (this.shadowForm_0 != null))
                {
                    this.shadowForm_0.method_9();
                }
                GC.Collect();
            }
            else
            {
                base.Hide();
                base.Close();
                base.DialogResult = this.dialogResult_0;
            }
        }

        private void method_5(object sender, AnimationEventArgs e)
        {
            if (!e.IsFinal)
            {
                this.dskinWindowForm_0.Size = e.CurrentFrame.Size;
                this.dskinWindowForm_0.Location = new Point(this.point_2.X + e.LocationOffset.X, this.point_2.Y + e.LocationOffset.Y);
                if (base.Visible)
                {
                    if (!this.dskinWindowForm_0.IsDisposed)
                    {
                        this.dskinWindowForm_0.Show();
                        this.dskinWindowForm_0.UpdateLayeredWindow(e.CurrentFrame, this.double_0);
                    }
                }
                else
                {
                    this.dskinWindowForm_0.Hide();
                }
                if (!this.bool_4)
                {
                    if (action_1 == null)
                    {
                        action_1 = new Action<Graphics>(DSkinForm.smethod_2);
                    }
                    this.UpdateLayeredWindow(0.0, action_1);
                    this.bool_4 = true;
                }
            }
        }

        private void method_6(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                this.Invalidate(control.Bounds);
            }
        }

        private void method_7(object sender, InvalidateEventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                Rectangle invalidRect = e.InvalidRect;
                invalidRect.Offset(control.Location);
                this.Invalidate(invalidRect);
            }
        }

        private void method_8(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                this.Invalidate();
            }
        }

        private void method_9(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaintBackground(e);
        }

        public void MoveForm()
        {
            DSkin.NativeMethods.MouseToMoveControl(base.Handle);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            this.VjJkjtMexe.BackgroundImage = this.BackgroundImage;
            base.OnBackgroundImageChanged(e);
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            this.VjJkjtMexe.BackgroundImageLayout = this.BackgroundImageLayout;
            base.OnBackgroundImageLayoutChanged(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!base.DesignMode)
            {
                if (e.Control is ILayeredContainer)
                {
                    ((ILayeredContainer) e.Control).LayeredInvalidated += new EventHandler<InvalidateEventArgs>(this.method_7);
                }
                else
                {
                    e.Control.Invalidated += new InvalidateEventHandler(this.method_7);
                }
                e.Control.Move += new EventHandler(this.method_8);
                e.Control.VisibleChanged += new EventHandler(this.method_6);
            }
            if (this.IsLayeredMode)
            {
                this.Invalidate();
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
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
                    base.Close();
                    base.Dispose();
                    return;
                }
            }
            base.OnCreateControl();
            if (this.bool_6)
            {
                Control control = (base.Owner == null) ? base.Parent : base.Owner;
                DSkinForm f = ((control == null) ? ((DSkinForm) base.ParentForm) : ((DSkinForm) control)) as DSkinForm;
                if (f != null)
                {
                    this.SetTheme(f);
                }
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (this.bool_5)
            {
                string[] data = (string[]) drgevent.Data.GetData(DataFormats.FileDrop);
                if (data != null)
                {
                    FileInfo info = new FileInfo(data[0]);
                    string str = info.Extension.Substring(1);
                    string[] strArray3 = new string[] { "png", "bmp", "jpg", "jpeg", "gif" };
                    if (strArray3.Contains(str.ToLower()))
                    {
                        this.BackgroundImage = Image.FromFile(data[0]);
                    }
                }
            }
            base.OnDragDrop(drgevent);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (this.bool_5)
            {
                drgevent.Effect = DragDropEffects.Link;
            }
            base.OnDragEnter(drgevent);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Func<bool> action = null;
            FormClosingEventHandler handler = null;
            if (!this.bool_16)
            {
                base.OnFormClosing(e);
            }
            if (!e.Cancel)
            {
                if (((!this.bool_16 && this.bool_17) && (this.IsLayeredWindowForm && (this.animation_0.Effect != null))) && (e.CloseReason != CloseReason.FormOwnerClosing))
                {
                    this.bool_15 = true;
                    this.animation_0.Original = this.Canvas;
                    this.animation_0.Asc = !this.animation_0.Asc;
                    this.animation_0.Start();
                    e.Cancel = true;
                    this.dialogResult_0 = base.DialogResult;
                }
                else if (((!this.bool_16 && this.bool_17) && this.IsLayeredWindowForm) && (this.animationTypes_0 == AnimationTypes.FadeinFadeoutEffect))
                {
                    e.Cancel = true;
                    this.dialogResult_0 = base.DialogResult;
                    if (action == null)
                    {
                        action = new Func<bool>(this, (IntPtr) this.method_22);
                    }
                    this.DoEffect(action);
                }
                if ((e.CloseReason == CloseReason.FormOwnerClosing) && (base.Owner != null))
                {
                    if (handler == null)
                    {
                        handler = new FormClosingEventHandler(this.method_23);
                    }
                    base.Owner.FormClosing += handler;
                }
                this.bool_16 = true;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.VjJkjtMexe.Focused = true;
            base.OnGotFocus(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            this.VjJkjtMexe.method_7(e);
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            this.VjJkjtMexe.method_6(e);
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            this.VjJkjtMexe.method_5(e);
            base.OnKeyUp(e);
        }

        protected virtual void OnLayeredInvalidated(InvalidateEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected virtual void OnLayeredPaintBackground(PaintEventArgs e)
        {
            if (this.OvXevPialK != null)
            {
                this.OvXevPialK(this, e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ResizeCore();
            if (!base.DesignMode && this.IsLayeredWindowForm)
            {
                if (!this.bool_17)
                {
                    this.bool_15 = false;
                }
                else
                {
                    if (!(((this.animationTypes_0 == AnimationTypes.Custom) || (this.animationTypes_0 == AnimationTypes.FadeinFadeoutEffect)) ? (this.animation_0.Effect == null) : false))
                    {
                        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    }
                    this.bool_15 = true;
                }
                switch (this.animationTypes_0)
                {
                    case AnimationTypes.ZoomEffect:
                        this.animation_0.Effect = new ZoomEffect();
                        break;

                    case AnimationTypes.GradualCurtainEffect:
                        this.animation_0.Effect = new GradualCurtainEffect();
                        break;

                    case AnimationTypes.FadeinFadeoutEffect:
                        if (this.bool_17)
                        {
                            <>c__DisplayClass7 class2;
                            double old = this.Opacity;
                            this.Opacity = 0.0;
                            this.DoEffect(new Func<bool>(class2, (IntPtr) this.<OnLoad>b__6));
                        }
                        break;

                    case AnimationTypes.RotateZoomEffect:
                        this.animation_0.Effect = new RotateZoomEffect();
                        break;

                    case AnimationTypes.const_4:
                        this.animation_0.Effect = new ThreeDTurn();
                        break;
                }
                this.animation_0.FrameChanged += new EventHandler<AnimationEventArgs>(this.method_5);
                this.animation_0.method_0(new EventHandler(this.method_4));
                this.animation_0.AnimationStart += new EventHandler(this.animation_0_AnimationStart);
            }
            this.LayeredPaint();
            if (!base.DesignMode)
            {
                this.shadowForm_0 = new ShadowForm(this);
            }
            Control control = (base.Owner == null) ? base.Parent : base.Owner;
            this.dskinForm_0 = ((control == null) ? ((DSkinForm) base.ParentForm) : ((DSkinForm) control)) as DSkinForm;
            if (this.dskinForm_0 != null)
            {
                this.dskinForm_0.ThemeChanged += new EventHandler(this.dskinForm_0_ThemeChanged);
            }
            this.bool_3 = true;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            this.method_2();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.VjJkjtMexe.Focused = false;
            base.OnLostFocus(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!this.IsMouseEnterSystemButtons)
            {
                this.VjJkjtMexe.TriggerMouseClick(e);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (!this.IsMouseEnterSystemButtons)
            {
                this.VjJkjtMexe.TriggerMouseDoubleClick(e);
            }
            if ((!this.VjJkjtMexe.IsMouseEnterChildControl && !this.IsMouseEnterSystemButtons) && ((e.Button == MouseButtons.Left) && this.bool_9))
            {
                if (this.moveModes_0 == MoveModes.Whole)
                {
                    base.WindowState = (base.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
                }
                else if ((this.moveModes_0 == MoveModes.Title) && (e.Y <= this.int_4))
                {
                    base.WindowState = (base.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
                }
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool flag;
            base.OnMouseDown(e);
            if (!(flag = this.IsMouseEnterSystemButtons))
            {
                this.VjJkjtMexe.TriggerMouseDown(e);
            }
            if ((((!base.DesignMode && !this.VjJkjtMexe.IsMouseEnterChildControl) && ((e.Button == MouseButtons.Left) && (e.Clicks == 1))) && ((!this.CloseBox.IsMouseEnter && !this.MinBox.IsMouseEnter) && !this.MaxBox.IsMouseEnter)) && !flag)
            {
                if (this.moveModes_0 == MoveModes.Whole)
                {
                    DSkin.NativeMethods.MouseToMoveControl(base.Handle);
                    this.VjJkjtMexe.ResetMouseStatus();
                }
                else if ((this.moveModes_0 == MoveModes.Title) && (e.Y <= this.int_4))
                {
                    DSkin.NativeMethods.MouseToMoveControl(base.Handle);
                    this.VjJkjtMexe.ResetMouseStatus();
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.VjJkjtMexe.TriggerMouseEnter(e);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.VjJkjtMexe.TriggerMouseLeave(e);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!this.IsMouseEnterSystemButtons)
            {
                this.VjJkjtMexe.TriggerMouseMove(e);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            foreach (SystemButton button in this.SystemButtons)
            {
                if (button.Bounds.Contains(e.Location))
                {
                    this.OnSystemButtonMouseClick(new SystemButtonMouseClickEventArgs(button, false));
                }
            }
            if (!this.IsMouseEnterSystemButtons)
            {
                this.VjJkjtMexe.TriggerMouseUp(e);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.VjJkjtMexe.method_3(e);
            base.OnMouseWheel(e);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (this.dskinWindowForm_0 != null)
            {
                this.dskinWindowForm_0.Location = base.Location;
            }
        }

        protected virtual void OnOpacityChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!(!base.DesignMode && this.IsLayeredMode))
            {
                this.method_12(e.ClipRectangle, e.Graphics);
            }
            if (base.DesignMode && (this.color_2 == Color.Transparent))
            {
                using (Pen pen = new Pen(this.ForeColor))
                {
                    pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SetClip(e.ClipRectangle);
            if (base.DesignMode && this.IsLayeredWindowForm)
            {
                if (base.Parent != null)
                {
                    e.Graphics.Clear(base.Parent.BackColor);
                }
            }
            else
            {
                try
                {
                    e.Graphics.Clear(Color.White);
                }
                catch (Exception)
                {
                }
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            this.VjJkjtMexe.method_4(e);
            base.OnPreviewKeyDown(e);
        }

        protected override void OnShown(EventArgs e)
        {
            if (!base.DesignMode && this.IsLayeredWindowForm)
            {
                if ((this.animation_0.Effect != null) && this.bool_17)
                {
                    this.animation_0.Start();
                }
                else
                {
                    this.bool_15 = false;
                    this.LayeredPaint();
                }
                this.timer_0.Interval = 15;
                this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
                this.timer_0.Start();
            }
            base.OnShown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.VjJkjtMexe.Size = base.Size;
            base.OnSizeChanged(e);
            if (base.WindowState != FormWindowState.Minimized)
            {
                if (!(!base.Visible || this.bool_15))
                {
                    this.DisposeCanvas();
                    this.LayeredPaint();
                }
                this.ResizeCore();
            }
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
            this.Invalidate();
        }

        protected virtual void OnSystemButtonMouseClick(SystemButtonMouseClickEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnThemeChanged(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (base.Visible)
            {
                this.Invalidate();
            }
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.method_12(invalidateRect, g);
        }

        protected virtual void PrePaint(Graphics g, Rectangle invalidateRect)
        {
            this.VjJkjtMexe.PaintControl(g, invalidateRect);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                IDuiDesigner activeControl = base.ActiveControl as IDuiDesigner;
                if ((activeControl != null) && (activeControl.DuiControlCollection_0.Count > 0))
                {
                    return smethod_0(activeControl.DuiControlCollection_0);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected virtual void ResizeCore()
        {
            this.CalcDeltaRect();
            this.method_3();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.int_7 != 0)
            {
                try
                {
                    System.Type type = typeof(Form);
                    FieldInfo field = type.GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                    FieldInfo info2 = type.GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                    FieldInfo info3 = type.GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (((field != null) && (info2 != null)) && (info3 != null))
                    {
                        Rectangle rectangle = (Rectangle) info3.GetValue(this);
                        BitVector32.Section section = (BitVector32.Section) field.GetValue(this);
                        BitVector32 vector = (BitVector32) info2.GetValue(this);
                        if (vector[section] == 1)
                        {
                            width = rectangle.Width;
                            height = rectangle.Height;
                        }
                    }
                }
                catch
                {
                }
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            System.Type type = typeof(Control);
            System.Type type2 = typeof(Form);
            FieldInfo field = type.GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo info2 = type.GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo info3 = type2.GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
            FieldInfo info4 = type2.GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);
            if ((((field != null) && (info2 != null)) && (info4 != null)) && (info3 != null))
            {
                base.Size = new Size(x, y);
                field.SetValue(this, x);
                info2.SetValue(this, y);
                BitVector32.Section section = (BitVector32.Section) info3.GetValue(this);
                BitVector32 vector = (BitVector32) info4.GetValue(this);
                vector[section] = 1;
                info4.SetValue(this, vector);
                this.OnClientSizeChanged(EventArgs.Empty);
                vector[section] = 0;
                info4.SetValue(this, vector);
            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        public void SetTheme(DSkinForm f)
        {
            if (!base.IsDisposed)
            {
                this.bool_11 = f.ActiveFocus;
                this.BackColor = f.RealBackColor;
                this.BorderColor = f.BorderColor;
                this.BorderWidth = f.BorderWidth;
                this.BackgroundImage = f.BackgroundImage;
                this.CaptionBackColors = f.CaptionBackColors;
                this.CaptionCenter = f.CaptionCenter;
                this.CaptionColor = f.CaptionColor;
                this.CaptionFont = f.CaptionFont;
                this.CaptionHeight = f.CaptionHeight;
                this.CaptionOffset = f.CaptionOffset;
                this.CaptionShowMode = f.CaptionShowMode;
                this.CaptionTextRender = f.CaptionTextRender;
                this.CloseBox.BorderHoverColor = f.CloseBox.BorderHoverColor;
                this.CloseBox.BorderNormalColor = f.CloseBox.BorderNormalColor;
                this.CloseBox.BorderPressColor = f.CloseBox.BorderPressColor;
                this.CloseBox.BorderWidth = f.CloseBox.BorderWidth;
                this.CloseBox.HoverBackColor = f.CloseBox.HoverBackColor;
                this.CloseBox.HoverColor = f.CloseBox.HoverColor;
                this.CloseBox.HoverImage = f.CloseBox.HoverImage;
                this.CloseBox.Location = f.CloseBox.Location;
                this.CloseBox.Name = f.CloseBox.Name;
                this.CloseBox.NormalBackColor = f.CloseBox.NormalBackColor;
                this.CloseBox.NormalColor = f.CloseBox.NormalColor;
                this.CloseBox.NormalImage = f.CloseBox.NormalImage;
                this.CloseBox.PressBackColor = f.CloseBox.PressBackColor;
                this.CloseBox.PressColor = f.CloseBox.PressColor;
                this.CloseBox.PressImage = f.CloseBox.PressImage;
                this.CloseBox.Radius = f.CloseBox.Radius;
                this.CloseBox.RoundStyle = f.CloseBox.RoundStyle;
                this.CloseBox.Size = f.CloseBox.Size;
                this.CloseBox.ToolTip = f.CloseBox.ToolTip;
                this.DrawIcon = f.DrawIcon;
                base.Boolean_0 = f.Boolean_0;
                this.ForeColor = f.ForeColor;
                this.Font = f.Font;
                this.HaloColor = f.HaloColor;
                this.HaloSize = f.HaloSize;
                this.Icon = f.Icon;
                this.IconRectangle = f.IconRectangle;
                this.ImageAttribute = f.ImageAttribute;
                this.MaxBox.BorderHoverColor = f.MaxBox.BorderHoverColor;
                this.MaxBox.BorderNormalColor = f.MaxBox.BorderNormalColor;
                this.MaxBox.BorderPressColor = f.MaxBox.BorderPressColor;
                this.MaxBox.BorderWidth = f.MaxBox.BorderWidth;
                this.MaxBox.HoverBackColor = f.MaxBox.HoverBackColor;
                this.MaxBox.HoverColor = f.MaxBox.HoverColor;
                this.MaxBox.HoverImage = f.MaxBox.HoverImage;
                this.MaxBox.Location = f.MaxBox.Location;
                this.MaxBox.Name = f.MaxBox.Name;
                this.MaxBox.NormalBackColor = f.MaxBox.NormalBackColor;
                this.MaxBox.NormalColor = f.MaxBox.NormalColor;
                this.MaxBox.NormalImage = f.MaxBox.NormalImage;
                this.MaxBox.PressBackColor = f.MaxBox.PressBackColor;
                this.MaxBox.PressColor = f.MaxBox.PressColor;
                this.MaxBox.PressImage = f.MaxBox.PressImage;
                this.MaxBox.Radius = f.MaxBox.Radius;
                this.MaxBox.RoundStyle = f.MaxBox.RoundStyle;
                this.MaxBox.Size = f.MaxBox.Size;
                this.MaxBox.ToolTip = f.MaxBox.ToolTip;
                this.MinBox.BorderHoverColor = f.MinBox.BorderHoverColor;
                this.MinBox.BorderNormalColor = f.MinBox.BorderNormalColor;
                this.MinBox.BorderPressColor = f.MinBox.BorderPressColor;
                this.MinBox.BorderWidth = f.MinBox.BorderWidth;
                this.MinBox.HoverBackColor = f.MinBox.HoverBackColor;
                this.MinBox.HoverColor = f.MinBox.HoverColor;
                this.MinBox.HoverImage = f.MinBox.HoverImage;
                this.MinBox.Location = f.MinBox.Location;
                this.MinBox.Name = f.MinBox.Name;
                this.MinBox.NormalBackColor = f.MinBox.NormalBackColor;
                this.MinBox.NormalColor = f.MinBox.NormalColor;
                this.MinBox.NormalImage = f.MinBox.NormalImage;
                this.MinBox.PressBackColor = f.MinBox.PressBackColor;
                this.MinBox.PressColor = f.MinBox.PressColor;
                this.MinBox.PressImage = f.MinBox.PressImage;
                this.MinBox.Radius = f.MinBox.Radius;
                this.MinBox.RoundStyle = f.MinBox.RoundStyle;
                this.MinBox.Size = f.MinBox.Size;
                this.MinBox.ToolTip = f.MinBox.ToolTip;
                this.NormalBox.BorderHoverColor = f.NormalBox.BorderHoverColor;
                this.NormalBox.BorderNormalColor = f.NormalBox.BorderNormalColor;
                this.NormalBox.BorderPressColor = f.NormalBox.BorderPressColor;
                this.NormalBox.BorderWidth = f.NormalBox.BorderWidth;
                this.NormalBox.HoverBackColor = f.NormalBox.HoverBackColor;
                this.NormalBox.HoverColor = f.NormalBox.HoverColor;
                this.NormalBox.HoverImage = f.NormalBox.HoverImage;
                this.NormalBox.Location = f.NormalBox.Location;
                this.NormalBox.Name = f.NormalBox.Name;
                this.NormalBox.NormalBackColor = f.NormalBox.NormalBackColor;
                this.NormalBox.NormalColor = f.NormalBox.NormalColor;
                this.NormalBox.NormalImage = f.NormalBox.NormalImage;
                this.NormalBox.PressBackColor = f.NormalBox.PressBackColor;
                this.NormalBox.PressColor = f.NormalBox.PressColor;
                this.NormalBox.PressImage = f.NormalBox.PressImage;
                this.NormalBox.Radius = f.NormalBox.Radius;
                this.NormalBox.RoundStyle = f.NormalBox.RoundStyle;
                this.NormalBox.Size = f.NormalBox.Size;
                this.NormalBox.ToolTip = f.NormalBox.ToolTip;
                this.Radius = f.Radius;
                this.RoundStyle = f.RoundStyle;
                this.ShowShadow = f.ShowShadow;
                this.ShadowColor = f.ShadowColor;
                this.ShadowWidth = f.ShadowWidth;
                this.SystemButtonsGap = f.SystemButtonsGap;
                this.SystemButtonsOffset = f.SystemButtonsOffset;
                this.OnThemeChanged(EventArgs.Empty);
            }
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            return clientSize;
        }

        private static bool smethod_0(DuiControlCollection duiControlCollection_0)
        {
            DuiBaseControl[] array = duiControlCollection_0.method_0().ToArray();
            if (comparison_0 == null)
            {
                comparison_0 = new Comparison<DuiBaseControl>(DSkinForm.smethod_3);
            }
            Array.Sort<DuiBaseControl>(array, comparison_0);
            int num = -1;
            DuiBaseControl control = null;
            for (int i = 0; i < array.Length; i++)
            {
                DuiBaseControl control2 = array[i];
                if (control2.Focused)
                {
                    num = i;
                    if (smethod_0(control2.Controls))
                    {
                        return true;
                    }
                }
                if (!((!control2.CanFocus || !control2.TabStop) ? (control2.Controls.Count <= 0) : false))
                {
                    if (!((((control != null) || !control2.CanFocus) || !control2.TabStop) || control2.Focused))
                    {
                        control = control2;
                    }
                    if ((i > num) && (num > -1))
                    {
                        if (control2.Controls.Count > 0)
                        {
                            bool flag2;
                            if ((!(flag2 = smethod_0(control2.Controls)) && control2.CanFocus) && control2.TabStop)
                            {
                                control2.Focus();
                                return true;
                            }
                            return flag2;
                        }
                        if (control2.CanFocus && control2.TabStop)
                        {
                            control2.Focus();
                            return true;
                        }
                        return false;
                    }
                }
            }
            if ((num == -1) && (control != null))
            {
                control.Focus();
                return true;
            }
            return false;
        }

        [CompilerGenerated]
        private static void smethod_1(object object_0)
        {
        }

        [CompilerGenerated]
        private static void smethod_2(object object_0)
        {
        }

        [CompilerGenerated]
        private static int smethod_3(DuiBaseControl duiBaseControl_0, DuiBaseControl duiBaseControl_1)
        {
            return (duiBaseControl_0.TabIndex - duiBaseControl_1.TabIndex);
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (!((this.bool_15 || !this.IsLayeredWindowForm) || base.IsDisposed) && !this.VjJkjtMexe.method_0().IsEmpty)
            {
                this.LayeredPaint(this.VjJkjtMexe.method_0());
            }
        }

        protected void TrackPopupSysMenu(ref Message m)
        {
            if (m.WParam.ToInt32() == 2)
            {
                this.TrackPopupSysMenu(m.HWnd, new Point(m.LParam.ToInt32()));
            }
        }

        protected void TrackPopupSysMenu(IntPtr hWnd, Point point)
        {
            if (this.bool_13 && (point.Y <= (((base.Top + this.padding_0.Top) + this.rectangle_0.Y) + this.int_4)))
            {
                IntPtr wParam = DSkin.NativeMethods.TrackPopupMenu(DSkin.NativeMethods.GetSystemMenu(hWnd, false), 0x100, point.X, point.Y, 0, hWnd, IntPtr.Zero);
                DSkin.NativeMethods.PostMessage(hWnd, 0x112, wParam, IntPtr.Zero);
            }
        }

        protected virtual void WmNcCalcSize(ref Message m)
        {
            if (base.Opacity != 1.0)
            {
                this.Invalidate();
            }
        }

        protected virtual void WmNcRButtonUp(ref Message m)
        {
            this.TrackPopupSysMenu(ref m);
            base.WndProc(ref m);
        }

        protected virtual void WmWindowPosChanged(ref Message m)
        {
            this.int_7++;
            base.WndProc(ref m);
            this.int_7--;
        }

        protected override void WndProc(ref Message m)
        {
            if (!this.bool_11 && !base.DesignMode)
            {
                if (m.Msg == 0x21)
                {
                    m.Result = new IntPtr(3);
                    return;
                }
                if ((m.Msg == 0x86) && ((((int) m.WParam) & 0xffff) != 0))
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        DSkin.NativeMethods.SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        DSkin.NativeMethods.SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            int msg = m.Msg;
            if (msg <= 0x47)
            {
                if (msg != 0x24)
                {
                    if (msg != 0x47)
                    {
                        goto Label_00EB;
                    }
                    this.WmWindowPosChanged(ref m);
                }
                else
                {
                    this.method_21(ref m);
                }
                return;
            }
            switch (msg)
            {
                case 0x83:
                    this.WmNcCalcSize(ref m);
                    return;

                case 0x84:
                    this.method_20(ref m);
                    return;

                case 0x85:
                    return;

                case 0x86:
                    this.method_19(ref m);
                    return;

                case 0xa5:
                    this.WmNcRButtonUp(ref m);
                    return;

                case 0xae:
                case 0xaf:
                    m.Result = (IntPtr) 1;
                    return;
            }
        Label_00EB:
            base.WndProc(ref m);
        }

        [Description("窗体是否可以获取焦点，如果为False，则窗体弹出不获取焦点,可能会导致Textbox无法输入，可以用来做信息显示类的小窗体"), Category("DSkin")]
        public bool ActiveFocus
        {
            get
            {
                return this.bool_11;
            }
            set
            {
                this.bool_11 = value;
            }
        }

        [Browsable(false)]
        public DSkin.Animations.Animation Animation
        {
            get
            {
                return this.animation_0;
            }
        }

        [Description("窗体启动和关闭特效，在层窗体模式下才有效，如果自定义的话，在Load事件里写this.Animation.Effect = new DSkin.Animations.特效名Effect();"), Category("DSkin"), DefaultValue(2)]
        public AnimationTypes AnimationType
        {
            get
            {
                return this.animationTypes_0;
            }
            set
            {
                this.animationTypes_0 = value;
            }
        }

        [Description("窗体背景色，层窗体模式下支持透明色，普通窗体模式下不要设置透明色，如果有半透明该属性不能获取真正的背景色，需要通过RealBackColor属性获取")]
        public override Color BackColor
        {
            get
            {
                if (base.DesignMode)
                {
                    return this.color_2;
                }
                return base.BackColor;
            }
            set
            {
                this.color_2 = value;
                if (value.A < 0xff)
                {
                    if (value == Color.Transparent)
                    {
                        base.BackColor = Color.White;
                    }
                    else
                    {
                        base.BackColor = Color.FromArgb(0xff, value.R, value.G, value.B);
                    }
                }
                else
                {
                    base.BackColor = value;
                }
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool BitmapCache
        {
            get
            {
                return this.VjJkjtMexe.BitmapCache;
            }
            set
            {
                this.VjJkjtMexe.BitmapCache = value;
            }
        }

        [Category("DSkin"), Description("边框颜色")]
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
                    this.Invalidate();
                }
            }
        }

        protected internal System.Windows.Forms.Padding BorderPadding
        {
            get
            {
                return this.padding_0;
            }
            set
            {
                this.padding_0 = value;
            }
        }

        [Description("边框宽度"), Category("DSkin")]
        public int BorderWidth
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
                    if (this.color_0 != Color.Transparent)
                    {
                        this.Invalidate();
                    }
                }
            }
        }

        [Description("设置或获取窗体是否可以通过鼠标改变大小"), DefaultValue(true), Category("DSkin")]
        public bool CanResize
        {
            get
            {
                return this.bool_8;
            }
            set
            {
                this.bool_8 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), ReadOnly(true)]
        public Bitmap Canvas
        {
            get
            {
                if (this.BitmapCache)
                {
                    return this.VjJkjtMexe.Canvas;
                }
                Rectangle rect = this.VjJkjtMexe.method_0();
                this.LayeredPaint(this.VjJkjtMexe.method_0());
                if (this.iimageEffect_0 != null)
                {
                    Bitmap bitmap = this.iimageEffect_0.DoImageEffect(rect, this.bitmap_0);
                    if (this.bitmap_0 != bitmap)
                    {
                        this.bitmap_0.Dispose();
                        this.bitmap_0 = bitmap;
                    }
                }
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }

        [Description("标题背景色"), Category("标题栏")]
        public Color[] CaptionBackColors
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
                    this.Invalidate(new Rectangle(0, 0, base.Width, this.int_4));
                }
            }
        }

        [Description("标题文字居中"), Category("标题栏")]
        public bool CaptionCenter
        {
            get
            {
                return this.bool_12;
            }
            set
            {
                if (this.bool_12 != value)
                {
                    this.bool_12 = value;
                    this.method_17();
                }
            }
        }

        [Category("标题栏"), Description("标题颜色")]
        public Color CaptionColor
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
                    this.method_17();
                }
            }
        }

        [Description("标题字体"), Category("标题栏")]
        public Font CaptionFont
        {
            get
            {
                return this.font_0;
            }
            set
            {
                if (this.font_0 != value)
                {
                    this.font_0 = value;
                    this.method_17();
                }
            }
        }

        [Description("标题栏高度"), Category("标题栏")]
        public int CaptionHeight
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.int_4 = (value < this.BorderPadding.Left) ? this.BorderPadding.Left : value;
                    this.method_17();
                }
            }
        }

        [Description("标题文字位置偏移"), Category("标题栏")]
        public Point CaptionOffset
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
                    this.method_17();
                }
            }
        }

        [Description("标题显示模式"), Category("标题栏")]
        public TextShowModes CaptionShowMode
        {
            get
            {
                return this.textShowModes_0;
            }
            set
            {
                if (this.textShowModes_0 != value)
                {
                    this.textShowModes_0 = value;
                    this.method_17();
                }
            }
        }

        [Description("标题文本渲染模式"), Category("标题栏")]
        public TextRenderingHint CaptionTextRender
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
                    this.method_17();
                }
            }
        }

        [TypeConverter(typeof(SystemButtonPropertyOrderConverter)), Description("关闭按钮"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin系统按钮")]
        public SystemButton CloseBox
        {
            get
            {
                if (this.systemButton_0 == null)
                {
                    SystemButton button2 = new SystemButton(this) {
                        SystemButtonType = SystemButtonTypes.Close
                    };
                    this.systemButton_0 = button2;
                }
                return this.systemButton_0;
            }
        }

        protected override System.Windows.Forms.Padding DefaultPadding
        {
            get
            {
                return new System.Windows.Forms.Padding(this.BorderPadding.Left, this.BorderPadding.Top + this.CaptionHeight, this.BorderPadding.Right, this.BorderPadding.Bottom);
            }
        }

        [Category("DSkin"), Description("双击窗体最大化")]
        public bool DoubleClickMaximized
        {
            get
            {
                return this.bool_9;
            }
            set
            {
                this.bool_9 = value;
            }
        }

        [Category("DSkin"), Description("拖拽图片改变窗体背景图片"), DefaultValue(true)]
        public bool DragChangeBackImage
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
            }
        }

        [Description("是否在标题栏绘制图标"), Category("标题栏")]
        public bool DrawIcon
        {
            get
            {
                return this.bool_14;
            }
            set
            {
                if (this.bool_14 != value)
                {
                    this.bool_14 = value;
                    this.method_17();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin"), Description("背景渲染")]
        public DSkin.DirectUI.DuiBackgroundRender DuiBackgroundRender
        {
            get
            {
                return this.VjJkjtMexe.BackgroundRender;
            }
        }

        [Description("Dui控件集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin")]
        public virtual DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return this.VjJkjtMexe.Controls;
            }
        }

        [Category("DSkin"), Description("是否启用窗体动画")]
        public bool EnableAnimation
        {
            get
            {
                return this.bool_17;
            }
            set
            {
                this.bool_17 = value;
            }
        }

        public System.Windows.Forms.FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            set
            {
                this.formBorderStyle_0 = value;
                base.FormBorderStyle = value;
            }
        }

        [Category("标题栏"), Description("标题文字光圈颜色")]
        public Color HaloColor
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
                    this.method_17();
                }
            }
        }

        [Description("标题文字光圈大小"), Category("标题栏")]
        public int HaloSize
        {
            get
            {
                return this.int_5;
            }
            set
            {
                if (this.int_5 != value)
                {
                    this.int_5 = value;
                    this.method_17();
                }
            }
        }

        public System.Drawing.Icon Icon
        {
            get
            {
                return base.Icon;
            }
            set
            {
                if (base.Icon != value)
                {
                    if (this.shadowForm_0 != null)
                    {
                        this.shadowForm_0.Icon = value;
                    }
                    base.Icon = value;
                    this.method_17();
                }
            }
        }

        [Description("Icon绘制区域"), Category("标题栏")]
        public Rectangle IconRectangle
        {
            get
            {
                return this.rectangle_1;
            }
            set
            {
                if (this.rectangle_1 != value)
                {
                    this.rectangle_1 = value;
                    this.method_17();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ImageAttributes ImageAttribute
        {
            get
            {
                return this.imageAttributes_0;
            }
            set
            {
                if (this.imageAttributes_0 != value)
                {
                    if (this.imageAttributes_0 != null)
                    {
                        this.imageAttributes_0.Dispose();
                        this.imageAttributes_0 = null;
                    }
                    this.imageAttributes_0 = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IImageEffect ImageEffect
        {
            get
            {
                return this.iimageEffect_0;
            }
            set
            {
                if (this.iimageEffect_0 != value)
                {
                    this.iimageEffect_0 = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("是否继承父级或者所有者窗体主题")]
        public bool InheritTheme
        {
            get
            {
                return this.bool_6;
            }
            set
            {
                this.bool_6 = value;
            }
        }

        [Category("DSkin"), Description("内容边框颜色"), DefaultValue(typeof(Color), "Transparent")]
        public Color InnerBorderColor
        {
            get
            {
                return this.xjekKcFyly;
            }
            set
            {
                if (this.xjekKcFyly != value)
                {
                    this.xjekKcFyly = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl InnerDuiControl
        {
            get
            {
                return this.VjJkjtMexe;
            }
        }

        [Browsable(false)]
        public bool IsLayeredMode
        {
            get
            {
                return DSkinBaseControl.ControlLayeredMode(this);
            }
        }

        protected bool IsMouseEnterSystemButtons
        {
            get
            {
                bool flag = false;
                using (IEnumerator enumerator = this.SystemButtons.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        SystemButton current = (SystemButton) enumerator.Current;
                        if (current.IsMouseEnter)
                        {
                            goto Label_0032;
                        }
                    }
                    goto Label_004A;
                Label_0032:
                    flag = true;
                }
            Label_004A:
                if (this.MaxBox.IsMouseEnter)
                {
                    flag = true;
                }
                if (this.MinBox.IsMouseEnter)
                {
                    flag = true;
                }
                if (this.MaxBox.IsMouseEnter)
                {
                    flag = true;
                }
                if (this.NormalBox.IsMouseEnter)
                {
                    flag = true;
                }
                return flag;
            }
        }

        [Browsable(false)]
        public bool IsPlaying
        {
            get
            {
                return this.bool_15;
            }
        }

        [Description("最大化按钮"), TypeConverter(typeof(SystemButtonPropertyOrderConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin系统按钮")]
        public SystemButton MaxBox
        {
            get
            {
                if (this.fkgkoKtOmQ == null)
                {
                    SystemButton button = new SystemButton(this) {
                        SystemButtonType = SystemButtonTypes.Maximized
                    };
                    this.fkgkoKtOmQ = button;
                }
                return this.fkgkoKtOmQ;
            }
        }

        [Description("最小化按钮"), Category("DSkin系统按钮"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TypeConverter(typeof(SystemButtonPropertyOrderConverter))]
        public SystemButton MinBox
        {
            get
            {
                if (this.systemButton_1 == null)
                {
                    SystemButton button = new SystemButton(this) {
                        SystemButtonType = SystemButtonTypes.Minimized
                    };
                    this.systemButton_1 = button;
                }
                return this.systemButton_1;
            }
        }

        [Description("窗体移动模式，鼠标如何移动窗体"), Category("DSkin")]
        public MoveModes MoveMode
        {
            get
            {
                return this.moveModes_0;
            }
            set
            {
                this.moveModes_0 = value;
            }
        }

        [Description("还原按钮"), TypeConverter(typeof(SystemButtonPropertyOrderConverter)), Category("DSkin系统按钮"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SystemButton NormalBox
        {
            get
            {
                if (this.systemButton_2 == null)
                {
                    SystemButton button = new SystemButton(this) {
                        SystemButtonType = SystemButtonTypes.Normal
                    };
                    this.systemButton_2 = button;
                }
                return this.systemButton_2;
            }
        }

        [DefaultValue(1), Description("设置窗体的不透明度,0-1")]
        public double Opacity
        {
            get
            {
                return this.double_0;
            }
            set
            {
                if (!this.IsLayeredWindowForm)
                {
                    base.Opacity = value;
                }
                if (this.double_0 != value)
                {
                    this.double_0 = value;
                    if (value >= 1.0)
                    {
                        this.double_0 = 1.0;
                    }
                    if (this.double_0 <= 0.0)
                    {
                        this.double_0 = 0.0;
                    }
                    this.double_1 = this.double_0;
                    this.OnOpacityChanged(EventArgs.Empty);
                    if ((this.IsLayeredWindowForm && !base.DesignMode) && base.Created)
                    {
                        if (action_0 == null)
                        {
                            action_0 = new Action<Graphics>(DSkinForm.smethod_1);
                        }
                        this.UpdateLayeredWindow(this.double_0, action_0);
                    }
                }
            }
        }

        [DefaultValue(typeof(System.Windows.Forms.Padding), "0,4,0,0")]
        public System.Windows.Forms.Padding Padding
        {
            get
            {
                return this.padding_1;
            }
            set
            {
                this.padding_1 = value;
                base.Padding = new System.Windows.Forms.Padding(this.BorderPadding.Left + this.padding_1.Left, this.CaptionHeight + this.padding_1.Top, this.BorderPadding.Left + this.padding_1.Right, this.BorderPadding.Left + this.padding_1.Bottom);
            }
        }

        [Category("DSkin"), DefaultValue(0), Description("窗体圆角半径")]
        public int Radius
        {
            get
            {
                return this.int_6;
            }
            set
            {
                if (this.int_6 != value)
                {
                    this.int_6 = value;
                    this.method_3();
                }
            }
        }

        [Browsable(false)]
        public Color RealBackColor
        {
            get
            {
                return this.color_2;
            }
        }

        [Browsable(false)]
        public Rectangle RealClientRect
        {
            get
            {
                if (base.WindowState == FormWindowState.Maximized)
                {
                    return new Rectangle(this.rectangle_0.X, this.rectangle_0.Y, base.Width - this.rectangle_0.Width, base.Height - this.rectangle_0.Height);
                }
                return new Rectangle(Point.Empty, base.Size);
            }
        }

        [Description("设置或获取窗体的圆角样式"), DefaultValue(typeof(DSkin.Common.RoundStyle), "All"), Category("DSkin")]
        public DSkin.Common.RoundStyle RoundStyle
        {
            get
            {
                return this.roundStyle_0;
            }
            set
            {
                if (this.roundStyle_0 != value)
                {
                    this.roundStyle_0 = value;
                    this.method_3();
                }
            }
        }

        [Description("阴影颜色"), Category("DSkin窗体阴影")]
        public Color ShadowColor
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
                    if (this.shadowForm_0 != null)
                    {
                        this.shadowForm_0.method_9();
                    }
                }
            }
        }

        [Description("窗体阴影宽度"), DefaultValue(typeof(int), "8"), Category("DSkin窗体阴影")]
        public int ShadowWidth
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = (value < 1) ? 1 : value;
                }
            }
        }

        [DefaultValue(false), Category("DSkin窗体阴影"), Description("显示窗体阴影")]
        public bool ShowShadow
        {
            get
            {
                return this.bool_10;
            }
            set
            {
                if (this.bool_10 != value)
                {
                    this.bool_10 = value;
                    if (this.shadowForm_0 != null)
                    {
                        if (value)
                        {
                            this.shadowForm_0.method_9();
                        }
                        else
                        {
                            this.shadowForm_0.method_8();
                        }
                    }
                }
            }
        }

        [Category("DSkin系统按钮"), Description("显示系统按钮"), DefaultValue(true)]
        public bool ShowSystemButtons
        {
            get
            {
                return this.bool_7;
            }
            set
            {
                if (this.bool_7 != value)
                {
                    this.bool_7 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), DefaultValue(false), Description("获取或设置窗体是否显示系统菜单")]
        public bool ShowSystemMenu
        {
            get
            {
                return this.bool_13;
            }
            set
            {
                this.bool_13 = value;
            }
        }

        [Description("九宫格方式绘制背景图片"), DefaultValue(false), Category("DSkin")]
        public bool SudokuDrawBackImage
        {
            get
            {
                return this.VjJkjtMexe.SudokuDrawBackImage;
            }
            set
            {
                this.VjJkjtMexe.SudokuDrawBackImage = value;
            }
        }

        [Description("九宫格图片切割宽度"), Category("DSkin"), DefaultValue(5)]
        public System.Windows.Forms.Padding SudokuPartitionWidth
        {
            get
            {
                return this.VjJkjtMexe.SudokuPartitionWidth;
            }
            set
            {
                this.VjJkjtMexe.SudokuPartitionWidth = value;
            }
        }

        [Category("DSkin系统按钮"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(Class61), typeof(UITypeEditor)), Description("自定义系统按钮")]
        public SystemButtonCollection SystemButtons
        {
            get
            {
                if (this.systemButtonCollection_0 == null)
                {
                    this.systemButtonCollection_0 = new SystemButtonCollection(this);
                }
                return this.systemButtonCollection_0;
            }
        }

        [Category("DSkin系统按钮"), DefaultValue(0), Description("系统按钮间距")]
        public int SystemButtonsGap
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
                    this.Invalidate();
                }
            }
        }

        [Description("系统按钮偏移量"), Category("DSkin系统按钮")]
        public Point SystemButtonsOffset
        {
            get
            {
                return this.point_0;
            }
            set
            {
                if (this.point_0 != value)
                {
                    this.point_0 = value;
                    this.Invalidate();
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
                if (base.Text != value)
                {
                    if (this.shadowForm_0 != null)
                    {
                        this.shadowForm_0.Text = value;
                    }
                    base.Text = value;
                    this.method_17();
                }
            }
        }

        [Browsable(false)]
        public DSkinToolTip ToolTip
        {
            get
            {
                return this.dskinToolTip_0;
            }
        }
    }
}

