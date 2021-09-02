namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [Designer("DSkin.Design.DSkinTabControlDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), ToolboxItem(true), ToolboxBitmap(typeof(TabControl))]
    public class DSkinTabControl : TabControl, ILayered, IDuiContainer, ILayeredContainer
    {
        private bool bool_0 = false;
        private bool bool_1;
        private Class15 class15_0;
        private Color color_0 = Color.Black;
        private Color color_1 = Color.Gray;
        private Color color_10;
        private Color color_2 = Color.White;
        private Color color_3 = Color.Black;
        private Color[] color_4;
        private Color[] color_5;
        private Color[] color_6;
        private Color color_7;
        private Color color_8;
        private Color color_9;
        private ContentAlignment contentAlignment_0;
        private DuiBaseControl duiBaseControl_0;
        private ePageImagePosition ePageImagePosition_0;
        private GClass3 gclass3_0;
        private Image image_0;
        private Image image_1;
        private Image image_2;
        private int int_0 = -1;
        private int int_1 = -1;
        private int int_2;
        private int int_3;
        private int int_4;
        internal IntPtr intptr_0 = IntPtr.Zero;
        private List<Control> list_0 = new List<Control>();
        private Point point_0;
        private Point point_1;
        private Rectangle rectangle_0;
        private Size size_0;
        private StringFormat stringFormat_0;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;

        public event EventHandler<InvalidateEventArgs> LayeredInvalidated;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public event EventHandler<DSkinPageRemovedEventArgs> PageRemoved;

        public DSkinTabControl()
        {
            Color[] colorArray = new Color[] { Color.FromArgb(100, Color.Gray), Color.FromArgb(100, Color.White) };
            this.color_4 = colorArray;
            colorArray = new Color[] { Color.Transparent, Color.FromArgb(100, Color.White) };
            this.color_5 = colorArray;
            colorArray = new Color[] { Color.FromArgb(100, Color.White), Color.FromArgb(200, Color.White) };
            this.color_6 = colorArray;
            this.rectangle_0 = new Rectangle();
            this.size_0 = new Size(20, 20);
            this.ePageImagePosition_0 = ePageImagePosition.Left;
            this.contentAlignment_0 = ContentAlignment.MiddleCenter;
            this.int_2 = 4;
            this.point_0 = new Point(0, 0);
            this.color_7 = Color.Black;
            this.color_8 = Color.Black;
            this.color_9 = Color.Black;
            this.bool_1 = false;
            this.point_1 = new Point();
            StringFormat format = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
            this.stringFormat_0 = format;
            this.int_3 = -1;
            this.color_10 = Color.Transparent;
            this.int_4 = 1;
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.UpdateStyles();
            base.SizeMode = TabSizeMode.Fixed;
            this.BackColor = Color.Transparent;
            this.InnerDuiControl.Parent = this;
            this.InnerDuiControl.ParentInvalidate = false;
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_4);
            this.InnerDuiControl.Invalidated += new EventHandler<InvalidateEventArgs>(this.method_0);
        }

        protected override void Dispose(bool disposing)
        {
            this.InnerDuiControl.Dispose();
            base.Dispose(disposing);
        }

        public virtual void DisposeCanvas()
        {
            this.InnerDuiControl.DisposeCanvas();
        }

        public Rectangle GetTabRectClient(int index)
        {
            Rectangle tabRect = base.GetTabRect(index);
            int x = (base.Alignment == TabAlignment.Right) ? 1 : -2;
            int y = (base.Alignment == TabAlignment.Bottom) ? 1 : -2;
            tabRect.Offset(x, y);
            return tabRect;
        }

        public void Invalidate()
        {
            this.InnerDuiControl.Invalidate();
        }

        public void Invalidate(Rectangle rect)
        {
            this.InnerDuiControl.Invalidate(rect);
        }

        private void method_0(object sender, InvalidateEventArgs e)
        {
            this.OnLayeredInvalidated(e);
            if (!(base.DesignMode || this.IsLayeredMode))
            {
                base.Invalidate(e.InvalidRect);
            }
        }

        private int method_1()
        {
            return this.int_1;
        }

        private void method_10(object sender, ControlEventArgs e)
        {
            this.method_12(((Control) sender).Controls);
        }

        private void method_11()
        {
            if (!base.DesignMode)
            {
                this.intptr_0 = DSkin.NativeMethods.FindWindowExA(base.Handle, IntPtr.Zero, "msctls_updown32", null);
            }
        }

        private void method_12(Control.ControlCollection controlCollection_0)
        {
            if (!base.DesignMode)
            {
                foreach (Control control in controlCollection_0)
                {
                    if (this.list_0.IndexOf(control) < 0)
                    {
                        this.list_0.Add(control);
                        if (control is ILayeredContainer)
                        {
                            ((ILayeredContainer) control).LayeredInvalidated += new EventHandler<InvalidateEventArgs>(this.method_7);
                        }
                        else
                        {
                            control.Invalidated += new InvalidateEventHandler(this.method_7);
                        }
                        control.Move += new EventHandler(this.method_9);
                        control.VisibleChanged += new EventHandler(this.method_8);
                    }
                }
            }
        }

        private void method_13(Control.ControlCollection controlCollection_0)
        {
            if (!base.DesignMode)
            {
                foreach (Control control in controlCollection_0)
                {
                    this.list_0.Remove(control);
                    if (control is ILayeredContainer)
                    {
                        ((ILayeredContainer) control).LayeredInvalidated -= new EventHandler<InvalidateEventArgs>(this.method_7);
                    }
                    else
                    {
                        control.Invalidated -= new InvalidateEventHandler(this.method_7);
                    }
                    control.Move -= new EventHandler(this.method_9);
                    control.VisibleChanged -= new EventHandler(this.method_8);
                }
            }
        }

        private Rectangle method_14()
        {
            Rectangle rectangle = new Rectangle();
            switch (base.Alignment)
            {
                case TabAlignment.Top:
                    return new Rectangle(0, 0, base.Width, base.ItemSize.Height);

                case TabAlignment.Bottom:
                    return new Rectangle(0, base.Height - base.ItemSize.Height, base.Width, base.ItemSize.Height);

                case TabAlignment.Left:
                    return new Rectangle(0, 0, base.ItemSize.Height, base.Height);

                case TabAlignment.Right:
                    return new Rectangle(base.Width - base.ItemSize.Height, 0, base.ItemSize.Height, base.Height);
            }
            return rectangle;
        }

        private void method_2(int value)
        {
            if (this.int_1 != value)
            {
                this.int_1 = value;
                if (this.int_1 != -1)
                {
                    this.Invalidate(this.GetTabRectClient(this.int_1));
                }
                else
                {
                    this.Invalidate(this.method_14());
                }
            }
        }

        internal Class15 method_3()
        {
            if (this.class15_0 == null)
            {
                this.class15_0 = new Class15(this);
            }
            return this.class15_0;
        }

        private void method_4(object sender, PaintEventArgs e)
        {
            TabPage selectedTab;
            int num;
            SolidBrush brush;
            Graphics g = e.Graphics;
            g.SetClip(e.ClipRectangle);
            if ((base.ItemSize.Width > 1) && (base.ItemSize.Height > 1))
            {
                for (num = 0; num < base.TabCount; num++)
                {
                    Rectangle rectangle4;
                    Rectangle rectangle7;
                    Rectangle tabRectClient = this.GetTabRectClient(num);
                    selectedTab = this.TabPages[num];
                    Rectangle tabRect = base.GetTabRect(num);
                    if (!tabRectClient.IntersectsWith(e.ClipRectangle))
                    {
                        continue;
                    }
                    Image image = this.image_2;
                    if (this.image_2 != null)
                    {
                        image = (this.SelectedIndex == num) ? this.image_2 : this.image_0;
                    }
                    if (((this.image_1 != null) && (this.int_3 == num)) && (num != this.SelectedIndex))
                    {
                        image = this.image_1;
                    }
                    Color pageNormlTxtColor = this.PageNormlTxtColor;
                    bool flag2 = false;
                    bool flag3 = false;
                    if (image != null)
                    {
                        g.DrawImage(image, tabRectClient);
                    }
                    else if (this.SelectedIndex == num)
                    {
                        ControlRender.DrawGradientColor(g, this.SelectedBackColors, 90f, tabRectClient);
                    }
                    else if (this.int_3 != num)
                    {
                        ControlRender.DrawGradientColor(g, this.NormalBackColors, 90f, tabRectClient);
                    }
                    else
                    {
                        ControlRender.DrawGradientColor(g, this.HoverBackColors, 90f, tabRectClient);
                    }
                    if (num != (base.TabCount - 1))
                    {
                        using (Pen pen = new Pen(this.color_10, (float) this.int_4))
                        {
                            switch (base.Alignment)
                            {
                                case TabAlignment.Top:
                                    g.DrawLine(pen, new Point(tabRectClient.Right, tabRectClient.Top), new Point(tabRectClient.Right, tabRectClient.Bottom));
                                    goto Label_025F;

                                case TabAlignment.Bottom:
                                    g.DrawLine(pen, new Point(tabRectClient.Right, tabRectClient.Top), new Point(tabRectClient.Right, tabRectClient.Bottom));
                                    goto Label_025F;

                                case TabAlignment.Left:
                                    g.DrawLine(pen, new Point(tabRectClient.X, tabRectClient.Bottom), new Point(tabRectClient.Right, tabRectClient.Bottom));
                                    goto Label_025F;

                                case TabAlignment.Right:
                                    g.DrawLine(pen, new Point(tabRectClient.X, tabRectClient.Bottom), new Point(tabRectClient.Right, tabRectClient.Bottom));
                                    goto Label_025F;
                            }
                        }
                    }
                Label_025F:
                    if (this.SelectedIndex == num)
                    {
                        flag2 = true;
                        pageNormlTxtColor = this.PageDownTxtColor;
                    }
                    else if (this.int_3 == num)
                    {
                        flag3 = true;
                        pageNormlTxtColor = this.PageHoverTxtColor;
                    }
                    Image tabItemImage = null;
                    if (selectedTab is DSkinTabPage)
                    {
                        DSkinTabPage page2 = (DSkinTabPage) selectedTab;
                        if (page2.TabItemImage != null)
                        {
                            tabItemImage = page2.TabItemImage;
                        }
                    }
                    if (tabItemImage == null)
                    {
                        if (selectedTab.ImageIndex != -1)
                        {
                            if (base.ImageList != null)
                            {
                                tabItemImage = base.ImageList.Images[selectedTab.ImageIndex];
                            }
                        }
                        else if ((selectedTab.ImageKey != null) && (base.ImageList != null))
                        {
                            tabItemImage = base.ImageList.Images[selectedTab.ImageKey];
                        }
                    }
                    this.method_5(selectedTab, tabRect, out rectangle7, out rectangle4, tabItemImage);
                    rectangle7.X += this.ImgTxtOffset.X;
                    rectangle7.Y += this.ImgTxtOffset.Y;
                    rectangle4.X += this.ImgTxtOffset.X + this.point_1.X;
                    rectangle4.Y += this.ImgTxtOffset.Y + this.point_1.Y;
                    this.MqlKbxlSu4(g, selectedTab, rectangle7, flag2, flag3, tabItemImage);
                    g.TextRenderingHint = this.textRenderingHint_0;
                    using (brush = new SolidBrush(Color.FromArgb((pageNormlTxtColor.A == 0xff) ? 0xfe : pageNormlTxtColor.A, pageNormlTxtColor)))
                    {
                        Rectangle layoutRectangle = rectangle4;
                        g.TextRenderingHint = this.textRenderingHint_0;
                        g.DrawString(selectedTab.Text, selectedTab.Font, brush, layoutRectangle, this.stringFormat_0);
                    }
                    if (this.bool_0)
                    {
                        bool closeButtonVisble = true;
                        if (selectedTab is DSkinTabPage)
                        {
                            closeButtonVisble = (selectedTab as DSkinTabPage).CloseButtonVisble;
                        }
                        if (closeButtonVisble)
                        {
                            Rectangle rect = new Rectangle(((tabRectClient.Right - this.CloseButton.LocationOffset.X) - this.gclass3_0.Size.Width) - 1, tabRectClient.Top + this.gclass3_0.LocationOffset.Y, this.gclass3_0.Size.Width, this.gclass3_0.Size.Height);
                            ControlStates normal = ControlStates.Normal;
                            if (this.int_1 == num)
                            {
                                normal = ControlStates.Hover;
                            }
                            if (this.int_0 == num)
                            {
                                normal = ControlStates.Pressed;
                            }
                            this.CloseButton.DrawButton(g, rect, normal);
                        }
                    }
                }
            }
            if ((!base.DesignMode && this.IsLayeredMode) && (base.SelectedTab != null))
            {
                selectedTab = base.SelectedTab;
                Control.ControlCollection controls = base.SelectedTab.Controls;
                if (base.SelectedTab.BackColor != Color.Transparent)
                {
                    using (brush = new SolidBrush(base.SelectedTab.BackColor))
                    {
                        g.FillRectangle(brush, base.SelectedTab.Bounds);
                    }
                }
                if (selectedTab.BackgroundImage != null)
                {
                    ControlRender.DrawBackgroundImage(g, selectedTab.BackgroundImageLayout, selectedTab.BackgroundImage, selectedTab.Bounds);
                }
                for (num = controls.Count - 1; num >= 0; num--)
                {
                    Control control = controls[num];
                    Rectangle bounds = control.Bounds;
                    bounds.Offset(base.SelectedTab.Location);
                    ControlRender.smethod_0(control, bounds, g, e.ClipRectangle, base.SelectedTab.Bounds);
                }
            }
            if ((base.ItemSize.Width > 1) && (base.ItemSize.Height > 1))
            {
                this.method_6(g, e.ClipRectangle);
            }
            this.OnLayeredPaint(e);
        }

        private void method_5(TabPage tabPage_0, Rectangle rectangle_1, out Rectangle rectangle_2, out Rectangle rectangle_3, Image image_3)
        {
            Size size2;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(tabPage_0.Text, tabPage_0.Font);
                size2 = new Size((int) ef.Width, (int) ef.Height);
            }
            int num = (tabPage_0.Text.Length == 0) ? 0 : this.ImgTxtSpace;
            rectangle_2 = Rectangle.Empty;
            rectangle_3 = Rectangle.Empty;
            if (image_3 == null)
            {
                rectangle_3 = rectangle_1;
            }
            else
            {
                switch (this.PageImagePosition)
                {
                    case ePageImagePosition.Left:
                        if (((this.PageTextAlign != ContentAlignment.BottomLeft) && (this.PageTextAlign != ContentAlignment.MiddleLeft)) && (this.PageTextAlign != ContentAlignment.TopLeft))
                        {
                            if (((this.PageTextAlign == ContentAlignment.BottomCenter) || (this.PageTextAlign == ContentAlignment.MiddleCenter)) || (this.PageTextAlign == ContentAlignment.TopCenter))
                            {
                                rectangle_2 = new Rectangle(rectangle_1.X + ((rectangle_1.Width - ((this.ImgSize.Width + size2.Width) + num)) / 2), rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                                rectangle_3 = new Rectangle(rectangle_2.Right + num, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), ((rectangle_1.Width - this.ImgSize.Width) - (rectangle_2.X - rectangle_1.X)) - num, size2.Height);
                            }
                            else
                            {
                                rectangle_2 = new Rectangle(((rectangle_1.X + rectangle_1.Width) - (size2.Width + num)) - this.ImgSize.Width, rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                                rectangle_3 = new Rectangle(rectangle_2.Right + num, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), size2.Width, size2.Height);
                            }
                            break;
                        }
                        rectangle_2 = new Rectangle(rectangle_1.X, rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                        rectangle_3 = new Rectangle(rectangle_2.Right + num, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), ((rectangle_1.Width - this.ImgSize.Width) - (rectangle_2.X - rectangle_1.X)) - num, size2.Height);
                        break;

                    case ePageImagePosition.Right:
                        if (((this.PageTextAlign != ContentAlignment.BottomLeft) && (this.PageTextAlign != ContentAlignment.MiddleLeft)) && (this.PageTextAlign != ContentAlignment.TopLeft))
                        {
                            if (((this.PageTextAlign == ContentAlignment.BottomCenter) || (this.PageTextAlign == ContentAlignment.MiddleCenter)) || (this.PageTextAlign == ContentAlignment.TopCenter))
                            {
                                rectangle_2 = new Rectangle((rectangle_1.X + ((rectangle_1.Width - ((this.ImgSize.Width + size2.Width) + num)) / 2)) + (size2.Width + num), rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                                rectangle_3 = new Rectangle((rectangle_2.X - size2.Width) - num, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), size2.Width, size2.Height);
                            }
                            else
                            {
                                rectangle_2 = new Rectangle((rectangle_1.X + rectangle_1.Width) - this.ImgSize.Width, rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                                rectangle_3 = new Rectangle((rectangle_2.X - size2.Width) - num, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), size2.Width, size2.Height);
                            }
                            break;
                        }
                        rectangle_2 = new Rectangle((rectangle_1.X + size2.Width) + num, rectangle_1.Y + ((rectangle_1.Height - this.ImgSize.Height) / 2), this.ImgSize.Width, this.ImgSize.Height);
                        rectangle_3 = new Rectangle(rectangle_1.X, rectangle_1.Y + ((rectangle_1.Height - size2.Height) / 2), size2.Width, size2.Height);
                        break;

                    case ePageImagePosition.Top:
                        rectangle_2 = new Rectangle(rectangle_1.X + ((rectangle_1.Width - this.ImgSize.Width) / 2), rectangle_1.Y + ((rectangle_1.Height - ((this.ImgSize.Height + size2.Height) + num)) / 2), this.ImgSize.Width, this.ImgSize.Height);
                        rectangle_3 = new Rectangle(rectangle_1.X, rectangle_2.Bottom + num, rectangle_1.Width, rectangle_1.Height - ((rectangle_2.Bottom + num) - rectangle_1.Top));
                        break;

                    case ePageImagePosition.Bottom:
                        rectangle_2 = new Rectangle(rectangle_1.X + ((rectangle_1.Width - this.ImgSize.Width) / 2), (rectangle_1.Y + ((rectangle_1.Height - ((this.ImgSize.Height + size2.Height) + num)) / 2)) + (size2.Height + num), this.ImgSize.Width, this.ImgSize.Height);
                        rectangle_3 = new Rectangle(rectangle_1.X, rectangle_1.Y, rectangle_1.Width, (rectangle_2.Y - rectangle_1.Y) - num);
                        break;
                }
            }
        }

        private void method_6(Graphics graphics_0, Rectangle rectangle_1)
        {
            if ((this.intptr_0 != IntPtr.Zero) && !((!rectangle_1.IntersectsWith(this.method_3().method_8()) || ((base.ItemSize.Width * base.TabCount) <= base.Width)) || base.Multiline))
            {
                this.class15_0.method_1(this.color_0);
                this.class15_0.method_3(this.color_1);
                this.class15_0.method_5(this.color_2);
                this.class15_0.method_7(this.color_3);
                Point location = this.method_3().method_8().Location;
                graphics_0.TranslateTransform((float) location.X, (float) location.Y);
                this.method_3().method_10(graphics_0);
                graphics_0.TranslateTransform((float) -location.X, (float) -location.Y);
            }
        }

        private void method_7(object sender, InvalidateEventArgs e)
        {
            Control control = sender as Control;
            if (((!base.IsDisposed && base.IsHandleCreated) && (this.IsLayeredMode && !base.DesignMode)) && control.Visible)
            {
                Rectangle rect = new Rectangle();
                if (((!base.IsDisposed && base.IsHandleCreated) && (!base.Disposing && (base.SelectedTab != null))) && base.SelectedTab.Controls.Contains(sender as Control))
                {
                    rect = e.InvalidRect;
                    rect.Offset(control.Location);
                    rect.Offset(base.SelectedTab.Location);
                }
                if (!rect.IsEmpty)
                {
                    this.Invalidate(rect);
                }
            }
        }

        private void method_8(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                Control control = sender as Control;
                Rectangle bounds = control.Bounds;
                bounds.Offset(base.SelectedTab.Location);
                this.Invalidate(bounds);
            }
        }

        private void method_9(object sender, EventArgs e)
        {
            if (!(!this.IsLayeredMode || base.DesignMode))
            {
                this.Invalidate();
            }
        }

        private void MqlKbxlSu4(Graphics graphics_0, TabPage tabPage_0, Rectangle rectangle_1, bool bool_2, bool bool_3, Image image_3)
        {
            if (image_3 != null)
            {
                if (this.IcoStateSwitch)
                {
                    Rectangle rectangle;
                    int width = image_3.Width / 3;
                    int height = image_3.Height;
                    if (bool_2)
                    {
                        rectangle = new Rectangle(2 * width, 0, width, height);
                    }
                    else if (bool_3)
                    {
                        rectangle = new Rectangle(width, 0, width, height);
                    }
                    else
                    {
                        rectangle = new Rectangle(0, 0, width, height);
                    }
                    graphics_0.DrawImage(image_3, rectangle_1, rectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    graphics_0.DrawImage(image_3, rectangle_1);
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.ControlAdded += new ControlEventHandler(this.method_10);
            this.method_12(e.Control.Controls);
            this.method_11();
            this.Invalidate();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            Control.ControlCollection controls = e.Control.Controls;
            this.method_13(controls);
            this.method_11();
            this.Invalidate();
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
            this.method_11();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.duiBaseControl_0.method_7(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.duiBaseControl_0.method_6(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.duiBaseControl_0.method_5(e);
        }

        protected virtual void OnLayeredInvalidated(InvalidateEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            this.InnerDuiControl.TriggerMouseClick(e);
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            this.InnerDuiControl.TriggerMouseDoubleClick(e);
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.InnerDuiControl.TriggerMouseDown(e);
            base.OnMouseDown(e);
            if ((this.bool_0 && !base.DesignMode) && (this.int_1 != -1))
            {
                this.int_0 = this.method_1();
                this.Invalidate(this.GetTabRectClient(this.int_1));
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.InnerDuiControl.TriggerMouseEnter(e);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.InnerDuiControl.TriggerMouseLeave(e);
            base.OnMouseLeave(e);
            this.method_2(-1);
            if (this.int_3 != -1)
            {
                this.int_3 = -1;
                Rectangle rect = this.method_14();
                this.Invalidate(rect);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.InnerDuiControl.TriggerMouseMove(e);
            for (int i = 0; i < base.TabCount; i++)
            {
                Rectangle tabRectClient = this.GetTabRectClient(i);
                if (tabRectClient.Contains(e.Location) && (this.int_3 != i))
                {
                    this.int_3 = i;
                    Rectangle rect = this.method_14();
                    this.Invalidate(rect);
                }
                Rectangle rectangle = new Rectangle(((tabRectClient.Right - this.CloseButton.LocationOffset.X) - this.gclass3_0.Size.Width) - 1, tabRectClient.Top + this.gclass3_0.LocationOffset.Y, this.gclass3_0.Size.Width, this.gclass3_0.Size.Height);
                if (rectangle.Contains(e.Location))
                {
                    this.method_2(i);
                    return;
                }
            }
            this.method_2(-1);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.InnerDuiControl.TriggerMouseUp(e);
            base.OnMouseUp(e);
            if (this.bool_0 && !base.DesignMode)
            {
                this.int_0 = -1;
                if (this.method_1() != -1)
                {
                    TabPage page = this.TabPages[this.method_1()];
                    bool closeButtonVisble = true;
                    if (page is DSkinTabPage)
                    {
                        closeButtonVisble = (page as DSkinTabPage).CloseButtonVisble;
                    }
                    if ((page != null) && closeButtonVisble)
                    {
                        DSkinPageRemovedEventArgs args = new DSkinPageRemovedEventArgs(page);
                        this.OnPageRemoved(args);
                        if (args.Handled)
                        {
                            return;
                        }
                        this.TabPages.Remove(page);
                    }
                    this.int_1 = -1;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            this.duiBaseControl_0.method_3(e);
        }

        protected virtual void OnPageRemoved(DSkinPageRemovedEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (base.DesignMode || !this.IsLayeredMode)
            {
                if (this.BitmapCache)
                {
                    Graphics graphics = e.Graphics;
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.SetClip(e.ClipRectangle);
                    graphics.DrawImage(this.Canvas, 0, 0);
                }
                else
                {
                    this.PaintControl(e.Graphics, e.ClipRectangle);
                }
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            this.duiBaseControl_0.method_4(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (base.SelectedTab != null)
            {
                Control.ControlCollection controls = base.SelectedTab.Controls;
                this.method_13(controls);
                this.method_12(controls);
            }
            base.OnSelectedIndexChanged(e);
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.InnerDuiControl.Size = base.Size;
            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Invalidate();
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get
            {
                return this.InnerDuiControl.BackColor;
            }
            set
            {
                if (this.InnerDuiControl.BackColor != value)
                {
                    this.InnerDuiControl.BackColor = value;
                    base.Invalidate();
                }
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Image BackgroundImage
        {
            get
            {
                return this.InnerDuiControl.BackgroundImage;
            }
            set
            {
                this.InnerDuiControl.BackgroundImage = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.InnerDuiControl.BackgroundImageLayout;
            }
            set
            {
                this.InnerDuiControl.BackgroundImageLayout = value;
            }
        }

        [Category("DSkin"), Description("位图缓存，位图缓存不适合大尺寸的控件")]
        public bool BitmapCache
        {
            get
            {
                return this.InnerDuiControl.BitmapCache;
            }
            set
            {
                this.InnerDuiControl.BitmapCache = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), TypeConverter(typeof(BordersPropertyOrderConverter)), Category("DSkin"), Description("控件边框")]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                return this.InnerDuiControl.Borders;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Bitmap Canvas
        {
            get
            {
                return this.InnerDuiControl.Canvas;
            }
            set
            {
                this.InnerDuiControl.Canvas = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("关闭按钮")]
        public GClass3 CloseButton
        {
            get
            {
                if (this.gclass3_0 == null)
                {
                    this.gclass3_0 = new GClass3(this);
                }
                return this.gclass3_0;
            }
        }

        public System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return this.InnerDuiControl.Cursor;
            }
            set
            {
                base.Cursor = this.InnerDuiControl.Cursor = value;
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle displayRectangle = base.DisplayRectangle;
                return new Rectangle(displayRectangle.Left - 4, displayRectangle.Top - 4, displayRectangle.Width + 8, displayRectangle.Height + 8);
            }
        }

        [DefaultValue(typeof(Color), "Transparent"), Description("分割线颜色")]
        public Color DividingLineColor
        {
            get
            {
                return this.color_10;
            }
            set
            {
                this.color_10 = value;
                this.Invalidate();
            }
        }

        [Description("分割线宽度"), DefaultValue(1)]
        public int DividingLineWidth
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
                this.Invalidate();
            }
        }

        [Category("DSkin"), Description("背景渲染"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DSkin.DirectUI.DuiBackgroundRender DuiBackgroundRender
        {
            get
            {
                return this.InnerDuiControl.BackgroundRender;
            }
        }

        protected virtual DuiBaseControl DuiControl
        {
            get
            {
                return new DuiBaseControl();
            }
        }

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("DirectUI控件集合")]
        public DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return this.InnerDuiControl.Controls;
            }
        }

        [Category("DSkin"), DefaultValue(false), Description("是否启用关闭按钮")]
        public bool EnabledCloseButton
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
                    this.Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override System.Drawing.Font Font
        {
            get
            {
                return this.InnerDuiControl.Font;
            }
            set
            {
                this.InnerDuiControl.Font = base.Font = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor
        {
            get
            {
                return this.InnerDuiControl.ForeColor;
            }
            set
            {
                this.InnerDuiControl.ForeColor = base.ForeColor = value;
            }
        }

        [Category("DSkin"), Description("鼠标移入选项卡的渐变背景色")]
        public Color[] HoverBackColors
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
            }
        }

        [DefaultValue(false), Description("是否开启Tab图标三效状态切换"), Category("DSkin")]
        public bool IcoStateSwitch
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
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ImageAttributes ImageAttribute
        {
            get
            {
                return this.InnerDuiControl.ImageAttribute;
            }
            set
            {
                this.InnerDuiControl.ImageAttribute = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IImageEffect ImageEffect
        {
            get
            {
                return this.InnerDuiControl.ImageEffect;
            }
            set
            {
                this.InnerDuiControl.ImageEffect = value;
            }
        }

        [DefaultValue(typeof(Rectangle), "0,0,0,0"), Category("DSkin"), Description("图片绘制区域")]
        public Rectangle ImageRectangle
        {
            get
            {
                return this.rectangle_0;
            }
            set
            {
                if (this.rectangle_0 != value)
                {
                    this.rectangle_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Page"), Description("选项卡上图标的大小"), DefaultValue(typeof(Size), "20,20")]
        public Size ImgSize
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
                    this.Invalidate();
                }
            }
        }

        [Category("Page"), DefaultValue(typeof(Point), "0,0"), Description("Page图标文本整体偏移。")]
        public Point ImgTxtOffset
        {
            get
            {
                return this.point_0;
            }
            set
            {
                this.point_0 = value;
                this.Invalidate();
            }
        }

        [DefaultValue(4), Description("选项卡文本与图标之间的间隙"), Category("Page")]
        public int ImgTxtSpace
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public DuiBaseControl InnerDuiControl
        {
            get
            {
                if (this.duiBaseControl_0 == null)
                {
                    this.duiBaseControl_0 = this.DuiControl;
                }
                return this.duiBaseControl_0;
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

        [Description("项目背景图片"), Category("DSkin")]
        public Image ItemBackgroundImage
        {
            get
            {
                return this.image_0;
            }
            set
            {
                if (this.image_0 != value)
                {
                    this.image_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("鼠标移入时项目背景图片"), Category("DSkin")]
        public Image ItemBackgroundImageHover
        {
            get
            {
                return this.image_1;
            }
            set
            {
                this.image_1 = value;
            }
        }

        [Description("被选中的项目背景图片"), Category("DSkin")]
        public Image ItemBackgroundImageSelected
        {
            get
            {
                return this.image_2;
            }
            set
            {
                if (this.image_2 != value)
                {
                    this.image_2 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), Description("正常状态下的选项卡渐变背景色")]
        public Color[] NormalBackColors
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
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "0,0,0"), Description("Page标签按下时字体色"), Category("PageTxt")]
        public Color PageDownTxtColor
        {
            get
            {
                return this.color_9;
            }
            set
            {
                if (this.color_9 != value)
                {
                    this.color_9 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("Page标签悬浮时字体色"), DefaultValue(typeof(Color), "0,0,0"), Category("PageTxt")]
        public Color PageHoverTxtColor
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
                    this.Invalidate();
                }
            }
        }

        [Category("Page"), DefaultValue(typeof(ePageImagePosition), "Overlay"), Description("指定选项卡上图像与文本的对齐方式")]
        public ePageImagePosition PageImagePosition
        {
            get
            {
                return this.ePageImagePosition_0;
            }
            set
            {
                this.ePageImagePosition_0 = value;
                this.Invalidate();
            }
        }

        [Description("Page标签默认时字体色"), DefaultValue(typeof(Color), "0,0,0"), Category("PageTxt")]
        public Color PageNormlTxtColor
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
                    this.Invalidate();
                }
            }
        }

        [Category("Page"), Description("将在选项卡标签上显示的文本的对齐方式"), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment PageTextAlign
        {
            get
            {
                return this.contentAlignment_0;
            }
            set
            {
                this.contentAlignment_0 = value;
                switch (this.contentAlignment_0)
                {
                    case ContentAlignment.TopLeft:
                        this.stringFormat_0.LineAlignment = StringAlignment.Near;
                        this.stringFormat_0.Alignment = StringAlignment.Near;
                        break;

                    case ContentAlignment.TopCenter:
                        this.stringFormat_0.LineAlignment = StringAlignment.Near;
                        this.stringFormat_0.Alignment = StringAlignment.Center;
                        break;

                    case ContentAlignment.TopRight:
                        this.stringFormat_0.LineAlignment = StringAlignment.Near;
                        this.stringFormat_0.Alignment = StringAlignment.Far;
                        break;

                    case ContentAlignment.MiddleLeft:
                        this.stringFormat_0.LineAlignment = StringAlignment.Center;
                        this.stringFormat_0.Alignment = StringAlignment.Near;
                        break;

                    case ContentAlignment.MiddleCenter:
                        this.stringFormat_0.LineAlignment = StringAlignment.Center;
                        this.stringFormat_0.Alignment = StringAlignment.Center;
                        break;

                    case ContentAlignment.MiddleRight:
                        this.stringFormat_0.LineAlignment = StringAlignment.Center;
                        this.stringFormat_0.Alignment = StringAlignment.Far;
                        break;

                    case ContentAlignment.BottomLeft:
                        this.stringFormat_0.LineAlignment = StringAlignment.Far;
                        this.stringFormat_0.Alignment = StringAlignment.Near;
                        break;

                    case ContentAlignment.BottomCenter:
                        this.stringFormat_0.LineAlignment = StringAlignment.Far;
                        this.stringFormat_0.Alignment = StringAlignment.Center;
                        break;

                    case ContentAlignment.BottomRight:
                        this.stringFormat_0.LineAlignment = StringAlignment.Far;
                        this.stringFormat_0.Alignment = StringAlignment.Far;
                        break;
                }
                this.Invalidate(this.method_14());
            }
        }

        [Category("DSkin"), Description("被选中的选项卡渐变背景色")]
        public Color[] SelectedBackColors
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
                    this.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return base.SelectedIndex;
            }
            set
            {
                base.SelectedIndex = value;
            }
        }

        [Description("tabPage集合"), Editor(typeof(DSkinTabPageCollectionEditor), typeof(UITypeEditor))]
        public TabControl.TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Description("文本偏移"), Category("PageTxt")]
        public Point TextOffset
        {
            get
            {
                return this.point_1;
            }
            set
            {
                this.point_1 = value;
            }
        }

        [Category("DSkin"), Description("文本渲染模式"), DefaultValue(typeof(TextRenderingHint), "SystemDefault")]
        public TextRenderingHint TextRenderMode
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
                    this.Invalidate();
                }
            }
        }

        [Category("DSkin"), Description("选项卡切换按钮箭头颜色")]
        public Color UpdownBtnArrowNormalColor
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
                }
            }
        }

        [Description("选项卡切换按钮箭头颜色"), Category("DSkin")]
        public Color UpdownBtnArrowPressColor
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

        [Category("DSkin"), Description("选项卡切换按钮背景颜色")]
        public Color UpdownBtnBackColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        [Category("DSkin"), Description("选项卡切换按钮边框颜色")]
        public Color UpdownBtnBorderColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
            }
        }
    }
}

