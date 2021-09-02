namespace DSkin.DirectUI
{
    using DSkin;
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [Designer("DSkin.Design.DuiBaseControlDocumentDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null", typeof(IRootDesigner)), DesignTimeVisible(false), Designer("DSkin.Design.DuiBaseControlDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), DesignerSerializer("DSkin.Design.DuiBaseControlCodeDomSerializer,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null", "System.ComponentModel.Design.Serialization.CodeDomSerializer"), ToolboxItem(false)]
    public class DuiBaseControl : Component, IDuiContainer, ILayoutElement, INotifyPropertyChanged
    {
        private AnchorStyles anchorStyles_0 = (AnchorStyles.Left | AnchorStyles.Top);
        internal Bitmap bitmap_0;
        private bool bool_0 = false;
        private bool bool_1 = false;
        private bool bool_10 = false;
        private bool bool_11 = true;
        private bool bool_12 = true;
        private bool bool_13 = false;
        private bool bool_14 = false;
        private bool bool_15 = false;
        private bool bool_16 = false;
        private bool bool_17 = true;
        private bool bool_18 = false;
        private bool bool_19 = false;
        private bool bool_2 = false;
        private bool bool_20 = false;
        private bool bool_21 = false;
        private bool bool_22 = false;
        private bool bool_23 = false;
        private bool bool_24 = true;
        private bool bool_25 = true;
        private bool bool_26 = true;
        private bool bool_3 = false;
        private bool bool_4 = true;
        private bool bool_5 = false;
        private bool bool_6 = true;
        private bool bool_7 = true;
        private bool bool_8 = true;
        private bool bool_9 = true;
        private DSkin.DirectUI.Borders borders_0;
        private Color color_0 = Color.Transparent;
        private Color color_1 = Control.DefaultForeColor;
        [CompilerGenerated]
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_0;
        private System.Windows.Forms.Cursor cursor_0 = Cursors.Default;
        private Dictionary<Action, Action> dictionary_0 = new Dictionary<Action, Action>();
        private DockStyle dockStyle_0 = DockStyle.None;
        private static DSkinToolTip dskinToolTip_0;
        private DuiBackgroundRender duiBackgroundRender_0;
        private DuiBaseControl duiBaseControl_0;
        private DuiControlCollection duiControlCollection_0;
        private DuiLayoutEngine duiLayoutEngine_0;
        private float float_0 = 0f;
        private System.Drawing.Font font_0 = Control.DefaultFont;
        private GraphicsPath graphicsPath_0;
        private IDuiContainer iduiContainer_0;
        private IImageEffect iimageEffect_0;
        private Image image_0;
        private ImageAttributes imageAttributes_0;
        private ImageLayout imageLayout_0 = ImageLayout.Tile;
        private int int_0 = 0;
        private List<DuiBaseControl> list_0 = new List<DuiBaseControl>();
        private object object_0;
        private static readonly object object_1 = new object();
        private static readonly object object_10 = new object();
        private static readonly object object_11 = new object();
        private static readonly object object_12 = new object();
        private static readonly object object_13 = new object();
        private static readonly object object_14 = new object();
        private static readonly object object_15 = new object();
        private static readonly object object_16 = new object();
        private static readonly object object_17 = new object();
        private static readonly object object_18 = new object();
        private static readonly object object_19 = new object();
        private static readonly object object_2 = new object();
        private static readonly object object_20 = new object();
        private static readonly object object_21 = new object();
        private static readonly object object_22 = new object();
        private static readonly object object_23 = new object();
        private static readonly object object_24 = new object();
        private static readonly object object_25 = new object();
        private static readonly object object_26 = new object();
        private static readonly object object_27 = new object();
        private static readonly object object_28 = new object();
        private static readonly object object_29 = new object();
        private static readonly object object_3 = new object();
        private static readonly object object_30 = new object();
        private static readonly object object_31 = new object();
        private static readonly object object_32 = new object();
        private static readonly object object_33 = new object();
        private static readonly object object_34 = new object();
        private static readonly object object_35 = new object();
        private static readonly object object_36 = new object();
        private static readonly object object_37 = new object();
        private static readonly object object_4 = new object();
        private static readonly object object_5 = new object();
        private static readonly object object_6 = new object();
        private static readonly object object_7 = new object();
        private static readonly object object_8 = new object();
        private static readonly object object_9 = new object();
        private Padding padding_0 = Padding.Empty;
        private Point point_0 = new Point();
        private Rectangle rectangle_0 = new Rectangle(0, 0, 100, 100);
        private Rectangle rectangle_1;
        private SizeF sizeF_0 = new SizeF(1f, 1f);
        private SizeF sizeF_1 = new SizeF();
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2;
        private static System.Threading.SynchronizationContext synchronizationContext_0 = System.Threading.SynchronizationContext.Current;

        [Description("接收到任务时发生")]
        public event EventHandler<AcceptTaskEventArgs> AcceptTask
        {
            add
            {
                base.Events.AddHandler(object_37, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_37, value);
            }
        }

        public event EventHandler AnchorChanged
        {
            add
            {
                base.Events.AddHandler(object_31, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_31, value);
            }
        }

        public event EventHandler AutoSizeChanged
        {
            add
            {
                base.Events.AddHandler(object_22, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_22, value);
            }
        }

        public event EventHandler BackgroundImageChanged
        {
            add
            {
                base.Events.AddHandler(object_34, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_34, value);
            }
        }

        public event EventHandler<DuiControlEventArgs> ControlAdded
        {
            add
            {
                base.Events.AddHandler(object_12, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_12, value);
            }
        }

        public event EventHandler<DuiControlEventArgs> ControlRemoved
        {
            add
            {
                base.Events.AddHandler(object_20, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_20, value);
            }
        }

        public event EventHandler DockChanged
        {
            add
            {
                base.Events.AddHandler(object_21, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_21, value);
            }
        }

        public event EventHandler EnabledChanged
        {
            add
            {
                base.Events.AddHandler(object_18, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_18, value);
            }
        }

        public event EventHandler FocusedChanged
        {
            add
            {
                base.Events.AddHandler(object_24, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_24, value);
            }
        }

        public event EventHandler FontChanged
        {
            add
            {
                base.Events.AddHandler(object_19, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_19, value);
            }
        }

        public event EventHandler ForeColorChanged
        {
            add
            {
                base.Events.AddHandler(object_23, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_23, value);
            }
        }

        public event EventHandler<InvalidateEventArgs> Invalidated
        {
            add
            {
                base.Events.AddHandler(object_15, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_15, value);
            }
        }

        public event EventHandler IsSelectedChanged
        {
            add
            {
                base.Events.AddHandler(object_1, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_1, value);
            }
        }

        public event EventHandler<KeyEventArgs> KeyDown
        {
            add
            {
                base.Events.AddHandler(object_25, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_25, value);
            }
        }

        public event EventHandler<KeyPressEventArgs> KeyPress
        {
            add
            {
                base.Events.AddHandler(object_26, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_26, value);
            }
        }

        public event EventHandler<KeyEventArgs> KeyUp
        {
            add
            {
                base.Events.AddHandler(object_27, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_27, value);
            }
        }

        public event EventHandler Layout
        {
            add
            {
                base.Events.AddHandler(object_35, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_35, value);
            }
        }

        public event EventHandler Load
        {
            add
            {
                base.Events.AddHandler(object_36, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_36, value);
            }
        }

        public event EventHandler MarginChanged
        {
            add
            {
                base.Events.AddHandler(object_32, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_32, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<DuiMouseEventArgs> MouseClick
        {
            add
            {
                base.Events.AddHandler(object_8, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_8, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<DuiMouseEventArgs> MouseDoubleClick
        {
            add
            {
                base.Events.AddHandler(object_9, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_9, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<DuiMouseEventArgs> MouseDown
        {
            add
            {
                base.Events.AddHandler(object_6, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_6, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<MouseEventArgs> MouseEnter
        {
            add
            {
                base.Events.AddHandler(object_4, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_4, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler MouseLeave
        {
            add
            {
                base.Events.AddHandler(object_5, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_5, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<DuiMouseEventArgs> MouseMove
        {
            add
            {
                base.Events.AddHandler(object_3, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_3, value);
            }
        }

        [Category("鼠标")]
        public event EventHandler<DuiMouseEventArgs> MouseUp
        {
            add
            {
                base.Events.AddHandler(object_7, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_7, value);
            }
        }

        public event EventHandler<MouseEventArgs> MouseWheel
        {
            add
            {
                base.Events.AddHandler(object_29, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_29, value);
            }
        }

        public event EventHandler Move
        {
            add
            {
                base.Events.AddHandler(object_13, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_13, value);
            }
        }

        public event EventHandler<PaintEventArgs> Paint
        {
            add
            {
                base.Events.AddHandler(object_11, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_11, value);
            }
        }

        public event EventHandler<PaintEventArgs> PaintBackground
        {
            add
            {
                base.Events.AddHandler(object_30, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_30, value);
            }
        }

        public event EventHandler ParentChanged
        {
            add
            {
                base.Events.AddHandler(object_33, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_33, value);
            }
        }

        [Description("背景绘制之后，子控件绘制之前，在Paint事件之前。一般用于继承控件的绘制")]
        public event EventHandler<PaintEventArgs> PrePaint
        {
            add
            {
                base.Events.AddHandler(object_16, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_16, value);
            }
        }

        public event EventHandler<PreviewKeyDownEventArgs> PreviewKeyDown
        {
            add
            {
                base.Events.AddHandler(object_28, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_28, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler SizeChanged
        {
            add
            {
                base.Events.AddHandler(object_14, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_14, value);
            }
        }

        public event EventHandler StartPaint
        {
            add
            {
                base.Events.AddHandler(object_10, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_10, value);
            }
        }

        public event EventHandler TextChanged
        {
            add
            {
                base.Events.AddHandler(object_2, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_2, value);
            }
        }

        public event EventHandler VisibleChanged
        {
            add
            {
                base.Events.AddHandler(object_17, value);
            }
            remove
            {
                base.Events.RemoveHandler(object_17, value);
            }
        }

        public DuiBaseControl()
        {
            if (this.EnableLayoutEngine)
            {
                this.duiLayoutEngine_0 = new DuiLayoutEngine(this);
            }
            this.duiBackgroundRender_0 = new DuiBackgroundRender(this);
            if (synchronizationContext_0 == null)
            {
                synchronizationContext_0 = System.Threading.SynchronizationContext.Current;
                if ((synchronizationContext_0 != null) && !(synchronizationContext_0 is WindowsFormsSynchronizationContext))
                {
                    synchronizationContext_0 = null;
                }
            }
        }

        public void BeginInvoke(MethodInvoker method)
        {
            SendOrPostCallback d = null;
            if (synchronizationContext_0 != null)
            {
                if (d == null)
                {
                    d = s => method();
                }
                synchronizationContext_0.Post(d, null);
            }
        }

        public void BringToFront()
        {
            DuiBaseControl parent = this.parent as DuiBaseControl;
            if (parent != null)
            {
                parent.Controls.method_0().Remove(this);
                parent.Controls.method_0().Add(this);
                this.Invalidate();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.bool_23)
            {
                this.bool_23 = true;
                this.duiBackgroundRender_0.Dispose();
                this.Parent = null;
                int count = this.Controls.Count;
                for (int i = 0; i < count; i++)
                {
                    if (this.Controls.Count > 0)
                    {
                        this.Controls[0].Dispose();
                    }
                }
                this.DisposeCanvas();
                if (this.imageAttributes_0 != null)
                {
                    this.imageAttributes_0.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void DisposeCanvas()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].DisposeCanvas();
            }
        }

        protected virtual void DrawBorders(Graphics g)
        {
            Pen pen;
            int num;
            int num2;
            if (this.Borders.TopPen != null)
            {
                g.DrawLine(this.Borders.TopPen.Pen, 0, (int) (this.Borders.TopPen.Width / 2f), this.Width, (int) (this.Borders.TopPen.Width / 2f));
            }
            else if ((this.Borders.TopColor != Color.Empty) && (this.Borders.TopWidth > 0))
            {
                using (pen = new Pen(this.Borders.TopColor, (float) this.Borders.TopWidth))
                {
                    g.DrawLine(pen, 0, this.Borders.TopWidth / 2, this.Width, this.Borders.TopWidth / 2);
                }
            }
            if (this.Borders.BottomPen != null)
            {
                num2 = this.Height - ((int) ((this.Borders.BottomPen.Width + 1f) / 2f));
                g.DrawLine(this.Borders.BottomPen.Pen, 0, num2, this.Width, num2);
            }
            else if ((this.Borders.BottomColor != Color.Empty) && (this.Borders.BottomWidth > 0))
            {
                using (pen = new Pen(this.Borders.BottomColor, (float) this.Borders.BottomWidth))
                {
                    num2 = this.Height - ((this.Borders.BottomWidth + 1) / 2);
                    g.DrawLine(pen, 0, num2, this.Width, num2);
                }
            }
            if (this.Borders.LeftPen != null)
            {
                g.DrawLine(this.Borders.LeftPen.Pen, (int) (this.Borders.LeftPen.Width / 2f), 0, (int) (this.Borders.LeftPen.Width / 2f), this.Height);
            }
            else if ((this.Borders.LeftColor != Color.Empty) && (this.Borders.LeftWidth > 0))
            {
                using (pen = new Pen(this.Borders.LeftColor, (float) this.Borders.LeftWidth))
                {
                    g.DrawLine(pen, this.Borders.LeftWidth / 2, 0, this.Borders.LeftWidth / 2, this.Height);
                }
            }
            if (this.Borders.RightPen != null)
            {
                num = this.Width - ((int) ((this.Borders.RightPen.Width + 1f) / 2f));
                g.DrawLine(this.Borders.RightPen.Pen, num, 0, num, this.Height);
            }
            if ((this.Borders.RightColor != Color.Empty) && (this.Borders.RightWidth > 0))
            {
                using (pen = new Pen(this.Borders.RightColor, (float) this.Borders.RightWidth))
                {
                    num = this.Width - ((this.Borders.RightWidth + 1) / 2);
                    g.DrawLine(pen, num, 0, num, this.Height);
                }
            }
        }

        public bool Focus()
        {
            if (this.parent is Control)
            {
                ((Control) this.parent).Focus();
                this.Focused = true;
            }
            else if (this.parent is DuiBaseControl)
            {
                foreach (DuiBaseControl control in ((DuiBaseControl) this.parent).Controls)
                {
                    if (control != this)
                    {
                        control.Focused = false;
                    }
                }
                this.Focused = ((DuiBaseControl) this.parent).Focus();
            }
            else
            {
                this.bool_15 = false;
            }
            return this.bool_15;
        }

        public virtual bool HitTest(Point point)
        {
            if (this.Region == null)
            {
                Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
                if (rectangle.Contains(point))
                {
                    return true;
                }
            }
            else if ((this.Region != null) && this.Region.IsVisible(point))
            {
                return true;
            }
            return false;
        }

        public virtual void Invalidate()
        {
            this.Invalidate(new Rectangle(new Point(), this.Size));
        }

        public virtual void Invalidate(Rectangle rect)
        {
            if (!this.bool_18)
            {
                if (this.parent != null)
                {
                    Rectangle rectangle = new Rectangle(new Point(), this.Size);
                    if (!(((rectangle.Contains(rect) || rect.IntersectsWith(rect)) || ((rectangle == rect) || rect.Contains(rectangle))) ? rect.IsEmpty : true))
                    {
                        if (rect.Contains(this.rectangle_1) || (rect == this.rectangle_1))
                        {
                            this.rectangle_1 = rect;
                        }
                        else if (!this.rectangle_1.Contains(rect))
                        {
                            if (this.rectangle_1.IsEmpty)
                            {
                                this.rectangle_1 = rect;
                            }
                            else
                            {
                                int x = (this.rectangle_1.X < rect.X) ? this.rectangle_1.X : rect.X;
                                int y = (this.rectangle_1.Y < rect.Y) ? this.rectangle_1.Y : rect.Y;
                                int width = (((this.rectangle_1.Width + this.rectangle_1.X) - x) > ((rect.Width + rect.X) - x)) ? ((this.rectangle_1.Width + this.rectangle_1.X) - x) : ((rect.Width + rect.X) - x);
                                int height = (((this.rectangle_1.Height + this.rectangle_1.Y) - y) > ((rect.Height + rect.Y) - y)) ? ((this.rectangle_1.Height + this.rectangle_1.Y) - y) : ((rect.Height + rect.Y) - y);
                                Rectangle rectangle3 = new Rectangle(x, y, width, height);
                                this.rectangle_1 = rectangle3;
                            }
                        }
                        this.rectangle_1.Intersect(rectangle);
                        if (!this.rectangle_1.IsEmpty)
                        {
                            if (this.Visible && this.ParentInvalidate)
                            {
                                Rectangle rc = this.rectangle_1;
                                rc.Offset(this.Left, this.Top);
                                if (this.Parent is Control)
                                {
                                    ((Control) this.Parent).Invalidate(rc, false);
                                }
                                else if (this.Parent is DuiBaseControl)
                                {
                                    ((DuiBaseControl) this.Parent).Invalidate(rc);
                                }
                            }
                            this.OnInvalidated(new InvalidateEventArgs(this.rectangle_1));
                        }
                    }
                }
                else
                {
                    this.rectangle_1 = new Rectangle(0, 0, this.Width, this.Height);
                    this.OnInvalidated(new InvalidateEventArgs(this.rectangle_1));
                }
            }
        }

        public void Invoke(MethodInvoker method)
        {
            SendOrPostCallback d = null;
            if (synchronizationContext_0 != null)
            {
                if (d == null)
                {
                    d = s => method();
                }
                synchronizationContext_0.Send(d, null);
            }
        }

        public void ManagedTask(Action action)
        {
            if (!this.dictionary_0.ContainsKey(action))
            {
                this.dictionary_0.Add(action, action);
                IDuiContainer parent = this.parent;
                if (parent != null)
                {
                    parent.InnerDuiControl.Invalidate();
                }
                else
                {
                    this.Invalidate();
                }
            }
        }

        internal Rectangle method_0()
        {
            return this.rectangle_1;
        }

        internal void method_1(Rectangle value)
        {
            this.rectangle_1 = value;
        }

        internal void method_10()
        {
            this.OnLayout(EventArgs.Empty);
        }

        private void method_11(AcceptTaskEventArgs acceptTaskEventArgs_0)
        {
            this.OnAcceptTask(acceptTaskEventArgs_0);
            if (!acceptTaskEventArgs_0.Handled)
            {
                DuiBaseControl parent = this.parent as DuiBaseControl;
                if (parent != null)
                {
                    parent.method_11(acceptTaskEventArgs_0);
                }
            }
            else
            {
                acceptTaskEventArgs_0.object_1 = this;
            }
        }

        internal void method_12(Control control_0)
        {
            <>c__DisplayClass1a classa;
            Control owner = control_0;
            owner.MouseClick += new MouseEventHandler(this.method_13);
            owner.MouseDoubleClick += new MouseEventHandler(this.method_14);
            owner.MouseDown += new MouseEventHandler(this.method_15);
            owner.MouseEnter += new EventHandler(this.method_16);
            owner.MouseLeave += new EventHandler(this.method_17);
            owner.MouseMove += new MouseEventHandler(this.method_18);
            owner.MouseUp += new MouseEventHandler(this.method_19);
            owner.MouseWheel += new MouseEventHandler(this.method_20);
            owner.KeyDown += new KeyEventHandler(this.method_21);
            owner.KeyPress += new KeyPressEventHandler(this.method_22);
            owner.KeyUp += new KeyEventHandler(this.method_23);
            owner.PreviewKeyDown += new PreviewKeyDownEventHandler(this.method_24);
            owner.EnabledChanged += new EventHandler(classa.<BindEvents>b__14);
            owner.SizeChanged += new EventHandler(classa.<BindEvents>b__15);
            owner.VisibleChanged += new EventHandler(this.method_25);
            owner.GotFocus += new EventHandler(this.method_26);
            owner.LostFocus += new EventHandler(this.method_27);
            owner.QueryContinueDrag += new QueryContinueDragEventHandler(this.method_28);
        }

        [CompilerGenerated]
        private void method_13(object sender, MouseEventArgs e)
        {
            this.TriggerMouseClick(e);
        }

        [CompilerGenerated]
        private void method_14(object sender, MouseEventArgs e)
        {
            this.TriggerMouseDoubleClick(e);
        }

        [CompilerGenerated]
        private void method_15(object sender, MouseEventArgs e)
        {
            this.TriggerMouseDown(e);
        }

        [CompilerGenerated]
        private void method_16(object sender, EventArgs e)
        {
            this.TriggerMouseEnter(e);
        }

        [CompilerGenerated]
        private void method_17(object sender, EventArgs e)
        {
            this.TriggerMouseLeave(e);
        }

        [CompilerGenerated]
        private void method_18(object sender, MouseEventArgs e)
        {
            this.TriggerMouseMove(e);
        }

        [CompilerGenerated]
        private void method_19(object sender, MouseEventArgs e)
        {
            this.TriggerMouseUp(e);
        }

        private void method_2(object sender, EventArgs e)
        {
            this.Focused = false;
        }

        [CompilerGenerated]
        private void method_20(object sender, MouseEventArgs e)
        {
            this.method_3(e);
        }

        [CompilerGenerated]
        private void method_21(object sender, KeyEventArgs e)
        {
            this.method_7(e);
        }

        [CompilerGenerated]
        private void method_22(object sender, KeyPressEventArgs e)
        {
            this.method_6(e);
        }

        [CompilerGenerated]
        private void method_23(object sender, KeyEventArgs e)
        {
            this.method_5(e);
        }

        [CompilerGenerated]
        private void method_24(object sender, PreviewKeyDownEventArgs e)
        {
            this.method_4(e);
        }

        [CompilerGenerated]
        private void method_25(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        [CompilerGenerated]
        private void method_26(object sender, EventArgs e)
        {
            this.Focused = true;
        }

        [CompilerGenerated]
        private void method_27(object sender, EventArgs e)
        {
            this.Focused = false;
        }

        [CompilerGenerated]
        private void method_28(object sender, QueryContinueDragEventArgs e)
        {
            if (e.Action != DragAction.Continue)
            {
                Point mousePosition = Control.MousePosition;
                Point locationToScreen = this.LocationToScreen;
                int x = mousePosition.X - locationToScreen.X;
                int y = mousePosition.Y - locationToScreen.Y;
                this.TriggerMouseUp(new MouseEventArgs(MouseButtons.Left, 1, x, y, 0));
            }
        }

        internal void method_3(MouseEventArgs mouseEventArgs_0)
        {
            if (this.bool_10)
            {
                Point locationToControl = this.LocationToControl;
                this.OnMouseWheel(new MouseEventArgs(mouseEventArgs_0.Button, mouseEventArgs_0.Clicks, mouseEventArgs_0.X - locationToControl.X, mouseEventArgs_0.Y - locationToControl.Y, mouseEventArgs_0.Delta));
                foreach (DuiBaseControl control in this.Controls)
                {
                    control.method_3(mouseEventArgs_0);
                }
            }
        }

        internal void method_4(PreviewKeyDownEventArgs previewKeyDownEventArgs_0)
        {
            if (this.Focused)
            {
                this.OnPreviewKeyDown(previewKeyDownEventArgs_0);
                foreach (DuiBaseControl control in this.Controls)
                {
                    control.method_4(previewKeyDownEventArgs_0);
                }
            }
        }

        internal void method_5(KeyEventArgs keyEventArgs_0)
        {
            if (this.Focused)
            {
                this.OnKeyUp(keyEventArgs_0);
                foreach (DuiBaseControl control in this.Controls)
                {
                    control.method_5(keyEventArgs_0);
                }
            }
        }

        internal void method_6(KeyPressEventArgs keyPressEventArgs_0)
        {
            if (this.Focused)
            {
                this.OnKeyPress(keyPressEventArgs_0);
                foreach (DuiBaseControl control in this.Controls)
                {
                    control.method_6(keyPressEventArgs_0);
                }
            }
        }

        internal void method_7(KeyEventArgs keyEventArgs_0)
        {
            if (this.Focused)
            {
                this.OnKeyDown(keyEventArgs_0);
                foreach (DuiBaseControl control in this.Controls)
                {
                    control.method_7(keyEventArgs_0);
                }
            }
        }

        private void method_8()
        {
            this.DisposeCanvas();
            if (this.Width < 1)
            {
                this.Width = 1;
            }
            if (this.Height < 1)
            {
                this.Height = 1;
            }
            this.bitmap_0 = new Bitmap(this.Width, this.Height);
            this.rectangle_1 = new Rectangle(new Point(), this.Size);
        }

        private void method_9()
        {
            if (!this.rectangle_1.IsEmpty)
            {
                if (this.bitmap_0 != null)
                {
                    Rectangle rect = this.rectangle_1;
                    using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                    {
                        this.PaintControl(graphics, this.rectangle_1);
                    }
                    if (this.iimageEffect_0 != null)
                    {
                        Bitmap bitmap = this.iimageEffect_0.DoImageEffect(rect, this.bitmap_0);
                        if (this.bitmap_0 != bitmap)
                        {
                            this.bitmap_0.Dispose();
                            this.bitmap_0 = bitmap;
                        }
                    }
                }
                else
                {
                    this.method_8();
                    this.method_9();
                }
            }
        }

        protected virtual void OnAcceptTask(AcceptTaskEventArgs e)
        {
            EventHandler<AcceptTaskEventArgs> handler = (EventHandler<AcceptTaskEventArgs>) base.Events[object_37];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAnchorChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_31];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAutoSizeChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_22];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnBackgroundImageChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_34];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnControlAdded(DuiControlEventArgs e)
        {
            EventHandler<DuiControlEventArgs> handler = (EventHandler<DuiControlEventArgs>) base.Events[object_12];
            if (handler != null)
            {
                handler(this, e);
            }
            if ((e.Control.Dock != DockStyle.None) && (this.duiLayoutEngine_0 != null))
            {
                this.duiLayoutEngine_0.bool_2 = true;
            }
            if (this.parent != null)
            {
                this.ManagedTask(new Action(this, (IntPtr) this.Invalidate));
            }
        }

        internal virtual void OnControlRemoved(DuiControlEventArgs e)
        {
            EventHandler<DuiControlEventArgs> handler = (EventHandler<DuiControlEventArgs>) base.Events[object_20];
            if (handler != null)
            {
                handler(this, e);
            }
            if (this.parent != null)
            {
                this.ManagedTask(new Action(this, (IntPtr) this.Invalidate));
            }
        }

        protected virtual void OnDockChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_21];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEnabledChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_18];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnFocusedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_24];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnFontChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_19];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnForeColorChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_23];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnInvalidated(InvalidateEventArgs e)
        {
            EventHandler<InvalidateEventArgs> handler = (EventHandler<InvalidateEventArgs>) base.Events[object_15];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnIsSelectedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_1];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            EventHandler<KeyEventArgs> handler = (EventHandler<KeyEventArgs>) base.Events[object_25];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnKeyPress(KeyPressEventArgs e)
        {
            EventHandler<KeyPressEventArgs> handler = (EventHandler<KeyPressEventArgs>) base.Events[object_26];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnKeyUp(KeyEventArgs e)
        {
            EventHandler<KeyEventArgs> handler = (EventHandler<KeyEventArgs>) base.Events[object_27];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLayout(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_35];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLoad(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_36];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMarginChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_32];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseClick(DuiMouseEventArgs e)
        {
            EventHandler<DuiMouseEventArgs> handler = (EventHandler<DuiMouseEventArgs>) base.Events[object_8];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseDoubleClick(DuiMouseEventArgs e)
        {
            EventHandler<DuiMouseEventArgs> handler = (EventHandler<DuiMouseEventArgs>) base.Events[object_9];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseDown(DuiMouseEventArgs e)
        {
            EventHandler<DuiMouseEventArgs> handler = (EventHandler<DuiMouseEventArgs>) base.Events[object_6];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseEnter(MouseEventArgs e)
        {
            EventHandler<MouseEventArgs> handler = (EventHandler<MouseEventArgs>) base.Events[object_4];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseLeave(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_5];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseMove(DuiMouseEventArgs e)
        {
            EventHandler<DuiMouseEventArgs> handler = (EventHandler<DuiMouseEventArgs>) base.Events[object_3];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseUp(DuiMouseEventArgs e)
        {
            EventHandler<DuiMouseEventArgs> handler = (EventHandler<DuiMouseEventArgs>) base.Events[object_7];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMouseWheel(MouseEventArgs e)
        {
            EventHandler<MouseEventArgs> handler = (EventHandler<MouseEventArgs>) base.Events[object_29];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMove(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_13];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPaint(PaintEventArgs e)
        {
            EventHandler<PaintEventArgs> handler = (EventHandler<PaintEventArgs>) base.Events[object_11];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPaintBackground(PaintEventArgs e)
        {
            EventHandler<PaintEventArgs> handler = (EventHandler<PaintEventArgs>) base.Events[object_30];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnParentChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_33];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPrePaint(PaintEventArgs e)
        {
            EventHandler<PaintEventArgs> handler = (EventHandler<PaintEventArgs>) base.Events[object_16];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            EventHandler<PreviewKeyDownEventArgs> handler = (EventHandler<PreviewKeyDownEventArgs>) base.Events[object_28];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.propertyChangedEventHandler_0 != null)
            {
                this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnSizeChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_14];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnStartPaint(EventArgs e)
        {
            if (this.dictionary_0.Count > 0)
            {
                Dictionary<Action, Action> dictionary = new Dictionary<Action, Action>();
                foreach (KeyValuePair<Action, Action> pair in this.dictionary_0)
                {
                    dictionary.Add(pair.Key, pair.Value);
                }
                this.dictionary_0.Clear();
                foreach (KeyValuePair<Action, Action> pair in dictionary)
                {
                    pair.Value.Invoke();
                }
            }
            EventHandler handler = (EventHandler) base.Events[object_10];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_2];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnVisibleChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler) base.Events[object_17];
            if (handler != null)
            {
                handler(this, e);
            }
            if (this.Parent is Control)
            {
                ((Control) this.Parent).Invalidate(this.ClientRectangle);
            }
            if (this.Parent is DuiBaseControl)
            {
                ((DuiBaseControl) this.Parent).Invalidate();
            }
            this.OnInvalidated(new InvalidateEventArgs(new Rectangle(0, 0, this.Width, this.Height)));
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            if (!(this.parent is DuiBaseControl))
            {
                this.OnStartPaint(EventArgs.Empty);
            }
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle rectangle3 = rect;
            rect.Intersect(invalidateRect);
            g.SetClip(rect);
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            if (this.BitmapCache)
            {
                g.Clear(Color.Transparent);
            }
            GraphicsPath path = null;
            if (this.graphicsPath_0 != null)
            {
                path = this.graphicsPath_0;
            }
            else if (this.duiBackgroundRender_0.RenderBorders)
            {
                path = GraphicsPathHelper.CreatePath(new Rectangle(0, 0, this.Width, this.Height), this.duiBackgroundRender_0.Radius, RoundStyle.All, true);
            }
            if (path != null)
            {
                System.Drawing.Region region = new System.Drawing.Region(path);
                region.Intersect(rect);
                g.Clip = region;
            }
            Brush brush = null;
            if (((this.duiBackgroundRender_0.BackgroundBrush == null) && (this.color_0 != Color.Transparent)) && (this.color_0 != Color.Empty))
            {
                brush = new SolidBrush(this.color_0);
            }
            else if (this.duiBackgroundRender_0.BackgroundBrush != null)
            {
                brush = this.duiBackgroundRender_0.BackgroundBrush.Brush;
            }
            if (brush != null)
            {
                if (path != null)
                {
                    g.FillPath(brush, path);
                }
                else
                {
                    g.FillRectangle(brush, rect);
                }
                if (this.duiBackgroundRender_0.BackgroundBrush == null)
                {
                    brush.Dispose();
                    brush = null;
                }
            }
            if (this.image_0 != null)
            {
                Image img = (this.duiBackgroundRender_0.bitmap_0 == null) ? this.image_0 : this.duiBackgroundRender_0.bitmap_0;
                if (this.duiBackgroundRender_0.SudokuDrawBackImage)
                {
                    ControlRender.SudokuDrawImage(g, img, new Rectangle(new Point(), this.Size), this.duiBackgroundRender_0.SudokuPartitionWidth, rect);
                }
                else
                {
                    ControlRender.DrawBackgroundImage(g, this.imageLayout_0, img, new Rectangle(new Point(), this.Size));
                }
            }
            this.OnPaintBackground(new PaintEventArgs(g, rect));
            this.OnPrePaint(new PaintEventArgs(g, rect));
            this.list_0.Clear();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                DuiBaseControl item = this.Controls[i];
                if (item.CanVisible || (this.bool_3 && item.ClientRectangle.IntersectsWith(rect)))
                {
                    this.list_0.Add(item);
                    if (!item.bool_1)
                    {
                        item.bool_1 = true;
                        if ((item.duiLayoutEngine_0 != null) && item.duiLayoutEngine_0.bool_2)
                        {
                            item.duiLayoutEngine_0.bool_2 = false;
                            item.duiLayoutEngine_0.Layout();
                        }
                        item.OnLoad(EventArgs.Empty);
                    }
                    item.OnStartPaint(EventArgs.Empty);
                    if (rect.IntersectsWith(item.ClientRectangle))
                    {
                        GraphicsState gstate = g.Save();
                        if ((item.ImageAttribute != null) || item.BitmapCache)
                        {
                            g.TranslateTransform((float) item.OriginPoint.X, (float) item.OriginPoint.Y);
                            g.ScaleTransform(item.ScaleSize.Width, item.ScaleSize.Height);
                            g.RotateTransform(item.RotationAngle);
                            g.TranslateTransform((float) -item.OriginPoint.X, (float) -item.OriginPoint.Y);
                            g.DrawImage(item.Canvas, item.ClientRectangle, 0, 0, item.Width, item.Height, GraphicsUnit.Pixel, item.ImageAttribute);
                        }
                        else
                        {
                            Rectangle rectangle4 = new Rectangle(item.Location, item.Size);
                            rectangle4.Intersect(rect);
                            rectangle4.Offset(-item.Left, -item.Top);
                            g.TranslateTransform((float) (item.Left + item.OriginPoint.X), (float) (item.Top + item.OriginPoint.Y));
                            g.ScaleTransform(item.ScaleSize.Width, item.ScaleSize.Height);
                            g.RotateTransform(item.RotationAngle);
                            g.TranslateTransform((float) -item.OriginPoint.X, (float) -item.OriginPoint.Y);
                            item.PaintControl(g, rectangle4);
                        }
                        g.Restore(gstate);
                    }
                }
                else if (!(item.Visible && (!item.BitmapCache || rectangle3.IntersectsWith(item.ClientRectangle))))
                {
                    item.DisposeCanvas();
                }
            }
            g.SetClip(rect);
            if (this.bool_11 && rect.IntersectsWith(rectangle3))
            {
                if ((((this.duiBackgroundRender_0.BorderWidth > 0) && this.duiBackgroundRender_0.RenderBorders) && (this.duiBackgroundRender_0.BorderColor != Color.Transparent)) && (path != null))
                {
                    Matrix matrix;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    if (this.duiBackgroundRender_0.BorderPen != null)
                    {
                        if (this.duiBackgroundRender_0.BorderPen.Width > 1f)
                        {
                            matrix = new Matrix();
                            matrix.Translate(this.duiBackgroundRender_0.BorderPen.Width / 2f, this.duiBackgroundRender_0.BorderPen.Width / 2f);
                            matrix.Scale(((this.Width - this.duiBackgroundRender_0.BorderPen.Width) + 1f) / ((float) this.Width), ((this.Height - this.duiBackgroundRender_0.BorderPen.Width) + 1f) / ((float) this.Height));
                            path.Transform(matrix);
                        }
                        g.DrawPath(this.duiBackgroundRender_0.BorderPen.Pen, path);
                    }
                    else
                    {
                        using (Pen pen = new Pen(this.duiBackgroundRender_0.BorderColor, (float) this.duiBackgroundRender_0.BorderWidth))
                        {
                            if (this.duiBackgroundRender_0.BorderWidth > 1)
                            {
                                matrix = new Matrix();
                                matrix.Translate((float) (this.duiBackgroundRender_0.BorderWidth / 2), (float) (this.duiBackgroundRender_0.BorderWidth / 2));
                                matrix.Scale(((float) ((this.Width - this.duiBackgroundRender_0.BorderWidth) + 1)) / ((float) this.Width), ((float) ((this.Height - this.duiBackgroundRender_0.BorderWidth) + 1)) / ((float) this.Height));
                                path.Transform(matrix);
                            }
                            switch (this.duiBackgroundRender_0.BorderType)
                            {
                                case BorderTypes.Solid:
                                    pen.DashStyle = DashStyle.Solid;
                                    break;

                                case BorderTypes.Dash:
                                    pen.DashStyle = DashStyle.Dash;
                                    break;

                                case BorderTypes.DashDot:
                                    pen.DashStyle = DashStyle.DashDot;
                                    break;

                                case BorderTypes.DashDotDot:
                                    pen.DashStyle = DashStyle.DashDotDot;
                                    break;

                                case BorderTypes.Dot:
                                    pen.DashStyle = DashStyle.Dot;
                                    break;
                            }
                            g.DrawPath(pen, path);
                        }
                    }
                }
                this.DrawBorders(g);
            }
            if ((path != null) && (this.graphicsPath_0 == null))
            {
                path.Dispose();
                path = null;
            }
            this.OnPaint(new PaintEventArgs(g, rect));
            if (this.Focused && this.bool_21)
            {
                Rectangle rectangle = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
                if ((rectangle.Width > 0) && (rectangle.Height > 0))
                {
                    ControlPaint.DrawFocusRectangle(g, rectangle);
                }
            }
            this.rectangle_1 = new Rectangle();
        }

        public void PerformLayout()
        {
            if (this.duiLayoutEngine_0 != null)
            {
                this.duiLayoutEngine_0.Layout();
            }
        }

        public void ResetMouseStatus()
        {
            foreach (DuiBaseControl control in this.Controls)
            {
                control.ResetMouseStatus();
            }
            this.bool_13 = false;
            this.bool_10 = false;
            this.bool_19 = false;
        }

        public void ResumeLayout()
        {
            if (this.duiLayoutEngine_0 != null)
            {
                this.duiLayoutEngine_0.IsSuspendLayout = false;
                this.duiLayoutEngine_0.Layout();
            }
        }

        public TaskResult SendTask(string name, object data = null)
        {
            AcceptTaskEventArgs args = new AcceptTaskEventArgs(this, name, data);
            DuiBaseControl parent = this.parent as DuiBaseControl;
            TaskResult result = null;
            if (parent != null)
            {
                parent.method_11(args);
                result = new TaskResult(args.object_1, args.Result);
            }
            return result;
        }

        public void SendToBack()
        {
            DuiBaseControl parent = this.parent as DuiBaseControl;
            if (parent != null)
            {
                parent.Controls.method_0().Remove(this);
                parent.Controls.method_0().Insert(0, this);
                this.Invalidate();
            }
        }

        public void SuspendLayout()
        {
            if (this.duiLayoutEngine_0 != null)
            {
                this.duiLayoutEngine_0.IsSuspendLayout = true;
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.string_2))
            {
                return (base.ToString() + " " + this.string_2);
            }
            return base.ToString();
        }

        public void TriggerLoad()
        {
            this.OnLoad(EventArgs.Empty);
        }

        internal virtual void TriggerMouseClick(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                DuiMouseEventArgs args;
                if (e is DuiMouseEventArgs)
                {
                    args = (DuiMouseEventArgs) e;
                    args.OriginalSource = this;
                }
                else
                {
                    args = new DuiMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, false, this);
                }
                if (this.Controls.Count > 0)
                {
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        DuiBaseControl source = this.Controls[i];
                        Point point = new Point(e.X - source.Left, e.Y - source.Top);
                        if (((source.Visible && !source.Virtualization) && source.HitTest(point)) && source.IsMouseDown)
                        {
                            DuiMouseEventArgs args2 = new DuiMouseEventArgs(e.Button, e.Clicks, e.X - source.Location.X, e.Y - source.Location.Y, e.Delta, false, source);
                            source.TriggerMouseClick(args2);
                            if (!source.MouseEventBubble)
                            {
                                args.Handled = true;
                            }
                            else
                            {
                                args.Handled = args2.Handled;
                            }
                            args.OriginalSource = args2.OriginalSource;
                            break;
                        }
                    }
                }
                if (!args.Handled)
                {
                    this.OnMouseClick(args);
                }
            }
        }

        internal virtual void TriggerMouseDoubleClick(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                DuiMouseEventArgs args;
                if (e is DuiMouseEventArgs)
                {
                    args = (DuiMouseEventArgs) e;
                    args.OriginalSource = this;
                }
                else
                {
                    args = new DuiMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, false, this);
                }
                if (this.Controls.Count > 0)
                {
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        DuiBaseControl source = this.Controls[i];
                        Point point = new Point(e.X - source.Left, e.Y - source.Top);
                        if ((source.Visible && !source.Virtualization) && source.HitTest(point))
                        {
                            DuiMouseEventArgs args2 = new DuiMouseEventArgs(e.Button, e.Clicks, e.X - source.Location.X, e.Y - source.Location.Y, e.Delta, false, source);
                            source.TriggerMouseDoubleClick(args2);
                            if (!source.MouseEventBubble)
                            {
                                args.Handled = true;
                            }
                            else
                            {
                                args.Handled = args2.Handled;
                            }
                            args.OriginalSource = args2.OriginalSource;
                            break;
                        }
                    }
                }
                if (!args.Handled)
                {
                    this.OnMouseDoubleClick(args);
                }
            }
        }

        internal virtual void TriggerMouseDown(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                DuiMouseEventArgs args2;
                this.bool_13 = true;
                if (this.CanFocus)
                {
                    this.Focus();
                }
                if (e is DuiMouseEventArgs)
                {
                    args2 = (DuiMouseEventArgs) e;
                    args2.OriginalSource = this;
                }
                else
                {
                    args2 = new DuiMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, false, this);
                }
                if (this.Controls.Count > 0)
                {
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        DuiBaseControl source = this.Controls[i];
                        Point point = new Point(e.X - source.Left, e.Y - source.Top);
                        if ((source.Visible && !source.Virtualization) && source.HitTest(point))
                        {
                            DuiMouseEventArgs args = new DuiMouseEventArgs(e.Button, e.Clicks, e.X - source.Location.X, e.Y - source.Location.Y, e.Delta, false, source);
                            source.TriggerMouseDown(args);
                            if (!source.MouseEventBubble)
                            {
                                args2.Handled = true;
                            }
                            else
                            {
                                args2.Handled = args.Handled;
                            }
                            args2.OriginalSource = args.OriginalSource;
                            break;
                        }
                    }
                }
                if (!args2.Handled)
                {
                    this.OnMouseDown(args2);
                }
            }
        }

        internal virtual void TriggerMouseEnter(EventArgs e)
        {
            if (this.Enabled)
            {
                if (this.CurrentCursor != this.Cursor)
                {
                    this.CurrentCursor = this.Cursor;
                }
                Control hostControl = this.HostControl;
                this.bool_10 = true;
                if (!(string.IsNullOrEmpty(this.string_0) || (hostControl == null)))
                {
                    DuiToolTip.SetToolTip(hostControl, this.string_0);
                }
                MouseEventArgs args = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
                if (hostControl != null)
                {
                    Point mousePosition = Control.MousePosition;
                    Point locationToScreen = this.LocationToScreen;
                    mousePosition.Offset(-locationToScreen.X, -locationToScreen.Y);
                    args = new MouseEventArgs(MouseButtons.None, 0, mousePosition.X, mousePosition.Y, 0);
                }
                this.OnMouseEnter(args);
            }
        }

        internal virtual void TriggerMouseLeave(EventArgs e)
        {
            this.bool_19 = false;
            this.duiBaseControl_0 = null;
            this.bool_10 = false;
            if (this.Enabled)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].IsMouseEnter)
                    {
                        this.Controls[i].TriggerMouseLeave(EventArgs.Empty);
                    }
                }
                if (!string.IsNullOrEmpty(this.string_0))
                {
                    DuiToolTip.RemoveAll();
                }
                this.OnMouseLeave(e);
            }
        }

        internal virtual void TriggerMouseMove(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                DuiMouseEventArgs args;
                if (e is DuiMouseEventArgs)
                {
                    args = (DuiMouseEventArgs) e;
                    args.OriginalSource = this;
                }
                else
                {
                    args = new DuiMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, false, this);
                }
                this.bool_19 = false;
                this.duiBaseControl_0 = null;
                for (int i = this.list_0.Count - 1; i >= 0; i--)
                {
                    DuiBaseControl source = this.list_0[i];
                    if (source.Visible && !source.Virtualization)
                    {
                        if (!(this.IsMouseDown && source.CanActive))
                        {
                            Point point = new Point(e.X - source.Left, e.Y - source.Top);
                            if (!(source.IsMouseEnter || !source.HitTest(point)))
                            {
                                for (int j = 0; j < this.list_0.Count; j++)
                                {
                                    if ((i != j) && this.list_0[j].IsMouseEnter)
                                    {
                                        this.list_0[j].TriggerMouseLeave(EventArgs.Empty);
                                    }
                                }
                                source.TriggerMouseEnter(EventArgs.Empty);
                                break;
                            }
                            if ((source.IsMouseEnter && !source.HitTest(point)) && (!source.IsMouseDown || !source.CanActive))
                            {
                                source.TriggerMouseLeave(EventArgs.Empty);
                                break;
                            }
                        }
                        if (!((!source.IsMouseDown || !source.CanActive) ? ((!source.IsMouseDown || !source.CanActive) ? !source.IsMouseEnter : true) : false))
                        {
                            this.bool_19 = true;
                            this.duiBaseControl_0 = source;
                            DuiMouseEventArgs args2 = new DuiMouseEventArgs(e.Button, e.Clicks, e.X - source.Location.X, e.Y - source.Location.Y, e.Delta, false, source);
                            source.TriggerMouseMove(args2);
                            if (!source.MouseEventBubble)
                            {
                                args.Handled = true;
                            }
                            else
                            {
                                args.Handled = args2.Handled;
                            }
                            args.OriginalSource = args2.OriginalSource;
                            break;
                        }
                    }
                }
                if (!args.Handled)
                {
                    this.OnMouseMove(args);
                }
                if ((!this.bool_19 && (this.CurrentCursor != this.Cursor)) && this.AutoChangedCursor)
                {
                    this.CurrentCursor = this.Cursor;
                }
            }
        }

        internal virtual void TriggerMouseUp(MouseEventArgs e)
        {
            if (this.Enabled)
            {
                DuiMouseEventArgs args;
                if (e is DuiMouseEventArgs)
                {
                    args = (DuiMouseEventArgs) e;
                    args.OriginalSource = this;
                }
                else
                {
                    args = new DuiMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, false, this);
                }
                this.bool_13 = false;
                if (this.Controls.Count > 0)
                {
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        DuiBaseControl source = this.Controls[i];
                        if (source.IsMouseDown)
                        {
                            DuiMouseEventArgs args2 = new DuiMouseEventArgs(e.Button, e.Clicks, e.X - source.Location.X, e.Y - source.Location.Y, e.Delta, false, source);
                            source.TriggerMouseUp(args2);
                            if (!source.MouseEventBubble)
                            {
                                args.Handled = true;
                            }
                            else
                            {
                                args.Handled = args2.Handled;
                            }
                            args.OriginalSource = args2.OriginalSource;
                            break;
                        }
                    }
                }
                if ((this.ContextMenuStrip != null) && (args.Button == MouseButtons.Right))
                {
                    this.ContextMenuStrip.Show(Control.MousePosition);
                }
                if (!args.Handled)
                {
                    this.OnMouseUp(args);
                }
            }
        }

        [DefaultValue(typeof(AnchorStyles), "Left,Top"), Description("锚点类型（运行时有效）"), Category("布局")]
        public AnchorStyles Anchor
        {
            get
            {
                return this.anchorStyles_0;
            }
            set
            {
                if (this.anchorStyles_0 != value)
                {
                    this.anchorStyles_0 = value;
                    this.OnAnchorChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Anchor");
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool AutoChangedCursor
        {
            get
            {
                return this.bool_7;
            }
            set
            {
                this.bool_7 = value;
            }
        }

        [Browsable(false), Description("控件是否适应内容改变大小"), EditorBrowsable(EditorBrowsableState.Never), Category("行为")]
        public virtual bool AutoSize
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
                    this.DesignModeCanResize = !this.bool_14;
                    this.OnAutoSizeChanged(EventArgs.Empty);
                    this.OnPropertyChanged("AutoSize");
                }
            }
        }

        [Category("外观"), DefaultValue(typeof(Color), "Transparent"), Description("背景色")]
        public virtual Color BackColor
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
                    this.OnPropertyChanged("BackColor");
                }
            }
        }

        [DefaultValue((string) null), Category("外观"), Description("背景图")]
        public Image BackgroundImage
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
                    this.duiBackgroundRender_0.method_0();
                    this.OnBackgroundImageChanged(EventArgs.Empty);
                    this.Invalidate();
                    this.OnPropertyChanged("BackgroundImage");
                }
            }
        }

        [DefaultValue(typeof(ImageLayout), "Tile"), Description("背景图布局"), Category("外观")]
        public virtual ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.imageLayout_0;
            }
            set
            {
                if (this.imageLayout_0 != value)
                {
                    this.imageLayout_0 = value;
                    this.Invalidate();
                    this.OnPropertyChanged("BackgroundImageLayout");
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("特效"), Description("背景渲染")]
        public DuiBackgroundRender BackgroundRender
        {
            get
            {
                return this.duiBackgroundRender_0;
            }
        }

        [Description("启用控件图像缓存"), DefaultValue(false)]
        public bool BitmapCache
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
                if (!value)
                {
                    this.DisposeCanvas();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("外观"), TypeConverter(typeof(BordersPropertyOrderConverter)), Description("边框显示模式")]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                if (this.borders_0 == null)
                {
                    this.borders_0 = new DSkin.DirectUI.Borders(this);
                }
                return this.borders_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool CanActive
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanDraw
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        [Category("行为"), Description("控件是否可以接收焦点"), DefaultValue(false)]
        public virtual bool CanFocus
        {
            get
            {
                return this.bool_16;
            }
            set
            {
                this.bool_16 = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bitmap Canvas
        {
            get
            {
                if (this.bitmap_0 == null)
                {
                    this.method_8();
                }
                this.method_9();
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }

        [Browsable(false)]
        public bool CanVisible
        {
            get
            {
                if (this.bool_3)
                {
                    return true;
                }
                if (this.Visible)
                {
                    Control hostControl = this.HostControl;
                    if ((hostControl != null) && hostControl.Visible)
                    {
                        System.Drawing.Size size = this.Size;
                        if (!(((this.sizeF_1.Width > 0f) || (this.sizeF_1.Height > 0f)) ? (this.duiLayoutEngine_0 == null) : true))
                        {
                            DuiBaseControl parent = this.duiLayoutEngine_0.Parent as DuiBaseControl;
                            if (parent != null)
                            {
                                size = new System.Drawing.Size((this.sizeF_1.Width > 0f) ? ((int) (parent.Width * this.sizeF_1.Width)) : this.Width, (this.sizeF_1.Height > 0f) ? ((int) (parent.Height * this.sizeF_1.Height)) : this.Height);
                            }
                        }
                        Point locationToControl = this.LocationToControl;
                        Rectangle rect = new Rectangle(locationToControl, size);
                        Rectangle rectangle2 = new Rectangle(new Point(), hostControl.Size);
                        if (rectangle2.IntersectsWith(rect))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("控件的工作区域"), Browsable(false)]
        public Rectangle ClientRectangle
        {
            get
            {
                return this.rectangle_0;
            }
            set
            {
                if (this.rectangle_0 != value)
                {
                    bool flag = false;
                    if (this.Size != value.Size)
                    {
                        flag = true;
                        int x = (value.X < this.rectangle_0.X) ? value.X : this.rectangle_0.X;
                        int y = (value.Y < this.rectangle_0.Y) ? value.Y : this.rectangle_0.Y;
                        int width = (((this.rectangle_0.Width + this.rectangle_0.X) - x) > ((value.Width + value.X) - x)) ? ((this.rectangle_0.Width + this.rectangle_0.X) - x) : ((value.Width + value.X) - x);
                        int height = (((this.rectangle_0.Height + this.rectangle_0.Y) - y) > ((value.Height + value.Y) - y)) ? ((this.rectangle_0.Height + this.rectangle_0.Y) - y) : ((value.Height + value.Y) - y);
                        Rectangle rect = new Rectangle(x, y, width, height);
                        this.rectangle_0 = value;
                        this.OnSizeChanged(EventArgs.Empty);
                        this.DisposeCanvas();
                        this.rectangle_1 = new Rectangle(0, 0, value.Width, value.Height);
                        if (this.Parent != null)
                        {
                            if (this.parent is DuiBaseControl)
                            {
                                ((DuiBaseControl) this.parent).Invalidate(rect);
                            }
                            else if (this.parent is Control)
                            {
                                ((Control) this.parent).Invalidate(rect);
                            }
                        }
                    }
                    if (this.Location != value.Location)
                    {
                        Rectangle clientRectangle = this.ClientRectangle;
                        this.rectangle_0 = value;
                        this.OnMove(EventArgs.Empty);
                        if ((this.bool_6 && this.Visible) && (this.Parent != null))
                        {
                            if (this.parent is DuiBaseControl)
                            {
                                if (!flag)
                                {
                                    ((DuiBaseControl) this.parent).Invalidate(clientRectangle);
                                }
                                ((DuiBaseControl) this.parent).Invalidate(this.ClientRectangle);
                            }
                            else if (this.parent is Control)
                            {
                                if (!flag)
                                {
                                    ((Control) this.parent).Invalidate(clientRectangle);
                                }
                                ((Control) this.parent).Invalidate(this.ClientRectangle);
                            }
                        }
                    }
                    this.OnPropertyChanged("ClientRectangle");
                }
            }
        }

        [DefaultValue((string) null)]
        public virtual System.Windows.Forms.ContextMenuStrip ContextMenuStrip
        {
            [CompilerGenerated]
            get
            {
                return this.contextMenuStrip_0;
            }
            [CompilerGenerated]
            set
            {
                this.contextMenuStrip_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("DUI子控件集合"), Category("DUI子控件集合"), MergableProperty(false)]
        public virtual DuiControlCollection Controls
        {
            get
            {
                if (this.duiControlCollection_0 == null)
                {
                    this.duiControlCollection_0 = new DuiControlCollection(this);
                }
                return this.duiControlCollection_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public System.Windows.Forms.Cursor CurrentCursor
        {
            get
            {
                if (this.Parent != null)
                {
                    if (this.Parent is Control)
                    {
                        return ((Control) this.Parent).Cursor;
                    }
                    if (this.Parent is DuiBaseControl)
                    {
                        return ((DuiBaseControl) this.Parent).CurrentCursor;
                    }
                }
                return Cursors.Default;
            }
            set
            {
                if (this.Parent != null)
                {
                    if (this.Parent is Control)
                    {
                        ((Control) this.Parent).Cursor = value;
                    }
                    if (this.Parent is DuiBaseControl)
                    {
                        ((DuiBaseControl) this.Parent).CurrentCursor = value;
                    }
                }
            }
        }

        [Description("获取或设置鼠标位于控件上的鼠标样式"), DefaultValue(typeof(System.Windows.Forms.Cursor), "Default")]
        public virtual System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return this.cursor_0;
            }
            set
            {
                this.cursor_0 = value;
            }
        }

        protected bool DesignMode
        {
            get
            {
                Control hostControl = this.HostControl;
                if ((hostControl != null) && (hostControl.Site != null))
                {
                    return hostControl.Site.DesignMode;
                }
                return base.DesignMode;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Category("设计"), Description("设计模式下是否可以被鼠标移动"), DefaultValue(true)]
        public bool DesignModeCanMove
        {
            get
            {
                return this.bool_25;
            }
            set
            {
                this.bool_25 = value;
            }
        }

        [Description("设计模式下是否可以被调整大小"), EditorBrowsable(EditorBrowsableState.Never), Category("设计"), DefaultValue(true)]
        public bool DesignModeCanResize
        {
            get
            {
                return this.bool_26;
            }
            set
            {
                this.bool_26 = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DefaultValue(true), Category("设计"), Description("设计模式下是否可以被选中")]
        public virtual bool DesignModeCanSelect
        {
            get
            {
                return this.bool_24;
            }
            set
            {
                this.bool_24 = value;
            }
        }

        [DefaultValue(typeof(DockStyle), "None"), Description("控件停靠方式"), Category("布局")]
        public DockStyle Dock
        {
            get
            {
                return this.dockStyle_0;
            }
            set
            {
                if (this.dockStyle_0 != value)
                {
                    this.dockStyle_0 = value;
                    this.OnDockChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Dock");
                }
            }
        }

        [DefaultValue(false), Description("是否绘制禁用效果，如果为true，控件将会设置位图缓存BitmapCache为true")]
        public bool DrawDisabled
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
                    if (!this.bool_9)
                    {
                        this.ImageAttribute = ImageEffects.GrayImageAttributes;
                    }
                    else
                    {
                        this.ImageAttribute = null;
                    }
                    this.OnPropertyChanged("DrawDisabled");
                }
            }
        }

        [Description("是否绘制焦点框"), DefaultValue(false)]
        public bool DrawFocusRectangle
        {
            get
            {
                return this.bool_21;
            }
            set
            {
                this.bool_21 = value;
            }
        }

        DuiBaseControl IDuiContainer.InnerDuiControl
        {
            get
            {
                return this;
            }
        }

        public static DSkinToolTip DuiToolTip
        {
            get
            {
                if (dskinToolTip_0 == null)
                {
                    dskinToolTip_0 = new DSkinToolTip();
                }
                return dskinToolTip_0;
            }
        }

        [Description("是否启用"), DefaultValue(true), Category("行为")]
        public bool Enabled
        {
            get
            {
                return this.bool_9;
            }
            set
            {
                if (this.bool_9 != value)
                {
                    this.bool_9 = value;
                    if (this.bool_0)
                    {
                        if (!this.bool_9)
                        {
                            this.ImageAttribute = ImageEffects.GrayImageAttributes;
                        }
                        else
                        {
                            this.ImageAttribute = null;
                        }
                    }
                    this.OnEnabledChanged(EventArgs.Empty);
                    this.Invalidate();
                    this.OnPropertyChanged("Enabled");
                }
            }
        }

        protected virtual bool EnableLayoutEngine
        {
            get
            {
                return true;
            }
        }

        [Browsable(false)]
        public virtual bool Focused
        {
            get
            {
                return this.bool_15;
            }
            internal set
            {
                if (this.bool_15 != value)
                {
                    this.bool_15 = value;
                    if (!value)
                    {
                        foreach (DuiBaseControl control in this.Controls)
                        {
                            control.Focused = false;
                        }
                    }
                    this.OnFocusedChanged(EventArgs.Empty);
                    this.Invalidate();
                    this.OnPropertyChanged("Focused");
                }
            }
        }

        [Description("字体"), DefaultValue(typeof(System.Drawing.Font), "宋体,9pt"), Category("外观")]
        public virtual System.Drawing.Font Font
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
                    this.OnFontChanged(EventArgs.Empty);
                    this.Invalidate();
                    this.OnPropertyChanged("Font");
                }
            }
        }

        [DefaultValue(typeof(Color), "ControlText"), Description("前景色"), Category("外观")]
        public virtual Color ForeColor
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
                    this.OnForeColorChanged(EventArgs.Empty);
                    this.Invalidate();
                    this.OnPropertyChanged("ForeColor");
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int Height
        {
            get
            {
                return this.rectangle_0.Size.Height;
            }
            set
            {
                if (this.Height != value)
                {
                    this.Size = new System.Drawing.Size(this.Width, value);
                }
            }
        }

        [Browsable(false)]
        public virtual Control HostControl
        {
            get
            {
                if (this.parent is Control)
                {
                    return (Control) this.parent;
                }
                if (this.parent is DuiBaseControl)
                {
                    return ((DuiBaseControl) this.parent).HostControl;
                }
                return null;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ImageAttributes ImageAttribute
        {
            get
            {
                return this.imageAttributes_0;
            }
            set
            {
                if (this.imageAttributes_0 != value)
                {
                    this.imageAttributes_0 = value;
                    if (value != null)
                    {
                        this.bool_5 = true;
                    }
                    this.Invalidate();
                    this.OnPropertyChanged("ImageAttribute");
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                    this.OnPropertyChanged("ImageEffect");
                }
            }
        }

        [DefaultValue(typeof(SizeF), "0,0"), Description("继承父级的尺寸百分比")]
        public SizeF InheritanceSize
        {
            get
            {
                return this.sizeF_1;
            }
            set
            {
                if (this.sizeF_1 != value)
                {
                    this.sizeF_1 = value;
                    if (value.Width < 0f)
                    {
                        this.sizeF_1.Width = 0f;
                    }
                    if (value.Height < 0f)
                    {
                        this.sizeF_1.Height = 0f;
                    }
                    if ((value.Height != 0f) || (value.Width != 0f))
                    {
                        this.AutoSize = false;
                        this.Dock = DockStyle.None;
                        this.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    }
                    this.Invalidate();
                    this.OnPropertyChanged("InheritanceSize");
                }
            }
        }

        [Browsable(false)]
        public bool IsDisposed
        {
            get
            {
                return this.bool_23;
            }
        }

        [Browsable(false)]
        public bool IsMouseDown
        {
            get
            {
                return this.bool_13;
            }
        }

        [Browsable(false)]
        public bool IsMouseEnter
        {
            get
            {
                return this.bool_10;
            }
        }

        [Browsable(false)]
        public bool IsMouseEnterChildControl
        {
            get
            {
                return this.bool_19;
            }
            internal set
            {
                this.bool_19 = value;
            }
        }

        [DefaultValue(true), Description("控件位置改变，父容器是否马上重绘")]
        public bool IsMoveParentPaint
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool IsSelected
        {
            get
            {
                return this.bool_22;
            }
            set
            {
                if (this.bool_22 != value)
                {
                    this.bool_22 = value;
                    this.OnIsSelectedChanged(EventArgs.Empty);
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        [Browsable(false)]
        public virtual DuiLayoutEngine LayoutEngine
        {
            get
            {
                return this.duiLayoutEngine_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int Left
        {
            get
            {
                return this.rectangle_0.Location.X;
            }
            set
            {
                if (this.Left != value)
                {
                    this.Location = new Point(value, this.Top);
                }
            }
        }

        [Browsable(false)]
        public bool Loaded
        {
            get
            {
                return this.bool_1;
            }
        }

        [Description("控件相对于父容器的的坐标位置"), Category("布局")]
        public virtual Point Location
        {
            get
            {
                return this.rectangle_0.Location;
            }
            set
            {
                if (this.Location != value)
                {
                    this.ClientRectangle = new Rectangle(value, this.Size);
                    this.OnPropertyChanged("Location");
                }
            }
        }

        [Description("获取该控件相对于承载DuiControl的Control控件的位置")]
        public Point LocationToControl
        {
            get
            {
                Point locationToControl = new Point();
                DuiBaseControl parent = this.parent as DuiBaseControl;
                if (parent != null)
                {
                    locationToControl = parent.LocationToControl;
                    locationToControl.Offset(this.Location);
                    return locationToControl;
                }
                return this.Location;
            }
        }

        [Description("获取该控件相对于屏幕左上角的位置")]
        public Point LocationToScreen
        {
            get
            {
                Point locationToScreen = new Point();
                if (this.Parent is Control)
                {
                    return ((Control) this.Parent).PointToScreen(this.Location);
                }
                if (this.Parent is DuiBaseControl)
                {
                    locationToScreen = ((DuiBaseControl) this.Parent).LocationToScreen;
                    locationToScreen.Offset(this.Location);
                }
                return locationToScreen;
            }
        }

        [Category("布局"), Description("外边距"), DefaultValue(typeof(Padding), "0,0,0,0")]
        public Padding Margin
        {
            get
            {
                return this.padding_0;
            }
            set
            {
                if (this.padding_0 != value)
                {
                    this.padding_0 = value;
                    this.OnMarginChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Margin");
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl MouseEnterChildControl
        {
            get
            {
                return this.duiBaseControl_0;
            }
        }

        [Category("行为"), Description("鼠标事件冒泡"), DefaultValue(true)]
        public bool MouseEventBubble
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
            }
        }

        [Browsable(false)]
        public virtual string Name
        {
            get
            {
                if (this.Site != null)
                {
                    this.string_2 = this.Site.Name;
                }
                if (this.string_2 == null)
                {
                    this.string_2 = "";
                }
                return this.string_2;
            }
            set
            {
                if (!(string.IsNullOrEmpty(value) || (this.Site == null)))
                {
                    this.Site.Name = value;
                }
                this.string_2 = value;
            }
        }

        [Description("原点"), DefaultValue(typeof(Point), "0,0"), Category("特效")]
        public Point OriginPoint
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
                    this.OnPropertyChanged("OriginPoint");
                }
            }
        }

        internal IDuiContainer parent
        {
            get
            {
                return this.iduiContainer_0;
            }
            set
            {
                this.iduiContainer_0 = value;
            }
        }

        [Description("父容器，如果为(无)，说明该控件没有添加到指定的容器里面，建议将其删除，或者重新设置Parent"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("设计")]
        public virtual IDuiContainer Parent
        {
            get
            {
                if (this.DesignMode)
                {
                    DuiBaseControl parent = this.parent as DuiBaseControl;
                    if (parent != null)
                    {
                        IDuiDesigner designer = parent.parent as IDuiDesigner;
                        if (designer != null)
                        {
                            return designer;
                        }
                    }
                }
                return this.parent;
            }
            set
            {
                if ((this.parent != value) && (value != this))
                {
                    if (this.DesignMode)
                    {
                        IDuiDesigner designer = value as IDuiDesigner;
                        if (designer != null)
                        {
                            value = designer.InnerDuiControl;
                        }
                    }
                    DuiBaseControl parent = this.parent as DuiBaseControl;
                    if (parent != null)
                    {
                        if ((parent.Controls.method_0().Count > 0) && (parent.Controls.method_0()[parent.Controls.Count - 1] == this))
                        {
                            parent.Controls.method_0().RemoveAt(parent.Controls.Count - 1);
                        }
                        else
                        {
                            parent.Controls.method_0().Remove(this);
                        }
                        parent.OnControlRemoved(new DuiControlEventArgs(this));
                    }
                    DuiBaseControl control = value as DuiBaseControl;
                    this.parent = value;
                    if (control != null)
                    {
                        control.Controls.method_0().Add(this);
                        control.OnControlAdded(new DuiControlEventArgs(this));
                    }
                    this.OnParentChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Parent");
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool ParentInvalidate
        {
            get
            {
                return this.bool_12;
            }
            set
            {
                this.bool_12 = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GraphicsPath Region
        {
            get
            {
                return this.graphicsPath_0;
            }
            set
            {
                if (this.graphicsPath_0 != value)
                {
                    this.graphicsPath_0 = value;
                    if (this.graphicsPath_0 != null)
                    {
                        RectangleF bounds = this.graphicsPath_0.GetBounds();
                        this.Size = new System.Drawing.Size((int) bounds.Width, (int) bounds.Height);
                    }
                    this.Invalidate();
                    this.OnPropertyChanged("Region");
                }
            }
        }

        [Description("顺时针旋转，只旋转图像，坐标不旋转"), Category("特效"), DefaultValue((float) 0f)]
        public float RotationAngle
        {
            get
            {
                return this.float_0;
            }
            set
            {
                if (this.float_0 != value)
                {
                    this.float_0 = value;
                    this.Invalidate();
                    this.OnPropertyChanged("RotationAngle");
                }
            }
        }

        [Description("缩放，只缩放图像，不缩放坐标"), DefaultValue(typeof(SizeF), "1,1"), Category("特效")]
        public SizeF ScaleSize
        {
            get
            {
                return this.sizeF_0;
            }
            set
            {
                if (this.sizeF_0 != value)
                {
                    this.sizeF_0 = value;
                    this.Invalidate();
                    this.OnPropertyChanged("ScaleSize");
                }
            }
        }

        [Description("是否显示边框"), DefaultValue(true), Category("外观")]
        public bool ShowBorder
        {
            get
            {
                return this.bool_11;
            }
            set
            {
                if (this.bool_11 != value)
                {
                    this.bool_11 = value;
                    this.Invalidate();
                    this.OnPropertyChanged("ShowBorder");
                }
            }
        }

        [Category("布局"), Description("控件大小")]
        public virtual System.Drawing.Size Size
        {
            get
            {
                return this.rectangle_0.Size;
            }
            set
            {
                if (value.Width < 1)
                {
                    value.Width = 1;
                }
                if (value.Height < 1)
                {
                    value.Height = 1;
                }
                this.ClientRectangle = new Rectangle(this.Location, value);
            }
        }

        [Category("外观"), DefaultValue(false), Description("九宫格方式绘制背景图片")]
        public bool SudokuDrawBackImage
        {
            get
            {
                return this.BackgroundRender.SudokuDrawBackImage;
            }
            set
            {
                this.BackgroundRender.SudokuDrawBackImage = value;
            }
        }

        [DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格图片切割宽度"), Category("外观")]
        public Padding SudokuPartitionWidth
        {
            get
            {
                return this.BackgroundRender.SudokuPartitionWidth;
            }
            set
            {
                this.BackgroundRender.SudokuPartitionWidth = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SuspendInvalidate
        {
            get
            {
                return this.bool_18;
            }
            set
            {
                if (value)
                {
                    this.rectangle_1 = new Rectangle(0, 0, this.Width, this.Height);
                }
                this.bool_18 = value;
            }
        }

        public static System.Threading.SynchronizationContext SynchronizationContext
        {
            get
            {
                return synchronizationContext_0;
            }
        }

        [Description("获取或设置在控件的容器的控件的 Tab 键顺序。"), DefaultValue(0)]
        public int TabIndex
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        [DefaultValue(false), Description(" 获取或设置一个值，该值指示用户能否使用 Tab 键将焦点放到该控件上。需要在DSKinForm上面才有效果")]
        public virtual bool TabStop
        {
            get
            {
                return this.bool_20;
            }
            set
            {
                this.bool_20 = value;
            }
        }

        [TypeConverter(typeof(StringConverter)), DefaultValue((string) null), Description("与控件关联的用户自定义数据")]
        public object Tag
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
            }
        }

        [DefaultValue(""), Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor)), Description("与控件关联的文本")]
        public virtual string Text
        {
            get
            {
                return this.string_1;
            }
            set
            {
                if (this.string_1 != value)
                {
                    this.string_1 = value;
                    this.OnTextChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Text");
                }
            }
        }

        [Description("提示文本"), DefaultValue("")]
        public string ToolTip
        {
            get
            {
                return this.string_0;
            }
            set
            {
                if (this.string_0 != value)
                {
                    this.string_0 = value;
                    this.OnPropertyChanged("ToolTip");
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Top
        {
            get
            {
                return this.rectangle_0.Location.Y;
            }
            set
            {
                if (this.Top != value)
                {
                    this.Location = new Point(this.Left, value);
                }
            }
        }

        [DefaultValue(false), Category("特效"), Description("虚拟化，虚拟化之后，有图像显示，但是不能点击到")]
        public bool Virtualization
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

        [DefaultValue(true), Category("行为"), Description("控件是否可见")]
        public virtual bool Visible
        {
            get
            {
                return this.bool_8;
            }
            set
            {
                if (this.bool_8 != value)
                {
                    this.bool_8 = value;
                    this.OnVisibleChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Visible");
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DuiBaseControl> VisibleControls
        {
            get
            {
                return this.list_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Width
        {
            get
            {
                return this.rectangle_0.Size.Width;
            }
            set
            {
                if (this.Width != value)
                {
                    this.Size = new System.Drawing.Size(value, this.Height);
                }
            }
        }
    }
}

