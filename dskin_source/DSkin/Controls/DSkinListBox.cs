namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ListBox)), Designer("DSkin.Design.DSkinListBoxDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), Description("强大的自定义列表，支持水平和垂直滚动")]
    public class DSkinListBox : Control, ILayered, IDuiContainer, ISupportInitialize
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_10;
        [CompilerGenerated]
        private bool bool_11;
        private bool bool_2;
        private bool bool_3;
        private bool bool_4;
        private bool bool_5;
        private bool bool_6;
        private bool bool_7;
        private bool bool_8;
        private bool bool_9;
        private DuiBaseControl duiBaseControl_0;
        private DuiBaseControl duiBaseControl_1;
        private DuiBaseControl duiBaseControl_2;
        private DuiScrollBar duiScrollBar_0;
        [CompilerGenerated]
        private static Func<DuiBaseControl, bool> func_0;
        [CompilerGenerated]
        private static Func<DuiBaseControl, bool> func_1;
        private IEnumerable ienumerable_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private object object_0;
        private System.Windows.Forms.Orientation orientation_0;
        private SelectionModes selectionModes_0;
        private Size size_0;
        private string string_0;
        private System.Windows.Forms.Timer timer_0;
        private System.Type type_0;

        [Description("接收到内部虚拟控件发送的任务时发生")]
        public event EventHandler<AcceptTaskEventArgs> AcceptTask;

        public event EventHandler DataSourceChanged;

        public event EventHandler<DuiControlEventArgs> ItemAdded;

        [Description("列表项目被点击时发生")]
        public event EventHandler<ItemClickEventArgs> ItemClick;

        public event EventHandler<DuiControlEventArgs> ItemRemoved;

        [Description("当项目选中状态改变之后发生"), Category("选择行为")]
        public event EventHandler<DuiControlEventArgs> ItemSelectedChanged;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public event EventHandler LayoutContented;

        [Description("Value改变时发生")]
        public event EventHandler ValueChanged;

        public DSkinListBox()
        {
            EventHandler handler = null;
            EventHandler handler2 = null;
            EventHandler<AcceptTaskEventArgs> handler3 = null;
            this.selectionModes_0 = SelectionModes.None;
            this.string_0 = string.Empty;
            this.bool_0 = true;
            this.bool_1 = true;
            this.duiScrollBar_0 = new DuiScrollBar();
            this.duiBaseControl_2 = new DuiBaseControl();
            this.bool_2 = false;
            this.orientation_0 = System.Windows.Forms.Orientation.Vertical;
            this.timer_0 = new System.Windows.Forms.Timer();
            this.bool_3 = false;
            this.int_0 = 0;
            this.bool_4 = false;
            this.bool_5 = false;
            this.bool_6 = true;
            this.bool_7 = true;
            this.size_0 = new Size(100, 100);
            this.int_1 = 20;
            this.int_2 = 0;
            this.bool_8 = true;
            this.int_3 = 10;
            this.int_4 = 0;
            this.bool_9 = true;
            this.bool_10 = true;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.Selectable, false);
            this.MouseUpSelect = true;
            this.BackColor = Color.Transparent;
            this.InnerDuiControl.Parent = this;
            this.InnerDuiControl.Paint += new EventHandler<PaintEventArgs>(this.method_16);
            this.duiBaseControl_1.PrePaint += new EventHandler<PaintEventArgs>(this.method_0);
            this.duiBaseControl_1.Controls.Add(this.duiBaseControl_2);
            this.duiBaseControl_2.ControlAdded += new EventHandler<DuiControlEventArgs>(this.method_3);
            this.duiBaseControl_2.ControlRemoved += new EventHandler<DuiControlEventArgs>(this.method_2);
            this.timer_0.Interval = 15;
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            this.duiScrollBar_0.BitmapCache = true;
            this.duiScrollBar_0.ClientRectangle = new Rectangle(new Point(base.Width - this.ScrollBarWidth, 0), new Size(this.ScrollBarWidth, base.Height));
            this.duiScrollBar_0.Maximum = 0x2710;
            this.duiScrollBar_0.SmallChange = 500;
            this.duiScrollBar_0.LargeChange = 0x3e8;
            this.duiScrollBar_0.parent = this.InnerDuiControl;
            this.duiScrollBar_0.ValueChanged += new EventHandler(this.duiScrollBar_0_ValueChanged);
            handler = new EventHandler(this.method_17);
            this.duiScrollBar_0.VisibleChanged += handler;
            handler2 = new EventHandler(this.method_18);
            this.duiScrollBar_0.MarginChanged += handler2;
            if (this.bool_1)
            {
                this.duiScrollBar_0.Visible = false;
            }
            if (handler3 == null)
            {
                handler3 = new EventHandler<AcceptTaskEventArgs>(this.method_19);
            }
            this.InnerDuiControl.AcceptTask += handler3;
        }

        public void BeginInit()
        {
        }

        public void DataBind()
        {
            if (this.object_0 != null)
            {
                DataSet set = this.object_0 as DataSet;
                if (!(string.IsNullOrEmpty(this.string_0) || (set == null)))
                {
                    this.ienumerable_0 = ((IListSource) set.Tables[this.string_0]).GetList();
                }
                else
                {
                    IListSource source = this.object_0 as IListSource;
                    if (source != null)
                    {
                        this.ienumerable_0 = source.GetList();
                    }
                    else
                    {
                        this.ienumerable_0 = this.object_0 as IEnumerable;
                    }
                }
            }
            if ((this.type_0 != null) && (this.ienumerable_0 != null))
            {
                this.bool_10 = false;
                this.Items.Clear();
                foreach (object obj2 in this.ienumerable_0)
                {
                    DSkinListItemTemplate control = (DSkinListItemTemplate) Activator.CreateInstance(this.type_0);
                    control.object_38 = obj2;
                    this.Items.Add(control);
                }
                this.bool_10 = true;
            }
            this.LayoutContent();
        }

        protected override void Dispose(bool disposing)
        {
            this.duiScrollBar_0.Dispose();
            this.InnerDuiControl.Dispose();
            this.timer_0.Dispose();
            base.Dispose(disposing);
        }

        public void DisposeCanvas()
        {
            this.InnerDuiControl.DisposeCanvas();
        }

        public void DoSmoothScroll(int speed)
        {
            this.int_0 = -speed;
        }

        private void duiScrollBar_0_ValueChanged(object sender, EventArgs e)
        {
            if (this.duiScrollBar_0.IsMouseDown)
            {
                this.Value = (1.0 * this.duiScrollBar_0.Value) / 10000.0;
            }
        }

        public void EndInit()
        {
            this.LayoutContent();
        }

        public static object GetItemData(object item, string dataField)
        {
            try
            {
                System.Type type;
                if (!(!(item is IDataRecord) || string.IsNullOrEmpty(dataField)))
                {
                    return ((IDataRecord) item)[dataField];
                }
                if (!(!(item is DataRowView) || string.IsNullOrEmpty(dataField)))
                {
                    return ((DataRowView) item)[dataField];
                }
                if ((!(type = item.GetType()).IsValueType && !(item is string)) && !string.IsNullOrEmpty(dataField))
                {
                    PropertyInfo property = type.GetProperty(dataField);
                    if (property != null)
                    {
                        return property.GetValue(item, null);
                    }
                    return null;
                }
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Invalidate()
        {
            this.InnerDuiControl.Invalidate();
        }

        public void LayeredPaint()
        {
            base.Invalidate();
        }

        public void LayoutContent()
        {
            this.int_4 = 0;
            if (this.Items.Count > 0)
            {
                int num;
                int num2;
                int num3;
                int width;
                DuiBaseControl control;
                Rectangle rectangle;
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    width = base.Width;
                    int num5 = 0;
                    if (this.Ulmul)
                    {
                        if (this.bool_5)
                        {
                            rectangle = new Rectangle();
                            List<DuiBaseControl> list2 = new List<DuiBaseControl>();
                            for (int i = 0; i < this.Items.Count; i++)
                            {
                                control = this.Items[i];
                                if (control.Visible)
                                {
                                    rectangle.Width = (rectangle.Width + control.Width) + control.Margin.Horizontal;
                                    if ((rectangle.Width < width) || (list2.Count == 0))
                                    {
                                        list2.Add(control);
                                        rectangle.Height = (rectangle.Height > (control.Height + control.Margin.Vertical)) ? rectangle.Height : (control.Height + control.Margin.Vertical);
                                    }
                                    else
                                    {
                                        this.method_14(width, rectangle, list2);
                                        rectangle.Y = rectangle.Bottom;
                                        rectangle.Size = new Size(control.Width + control.Margin.Horizontal, control.Height + control.Margin.Vertical);
                                        list2.Add(control);
                                    }
                                }
                                if ((list2.Count > 0) && (i == (this.Items.Count - 1)))
                                {
                                    this.method_14(width, rectangle, list2);
                                }
                            }
                        }
                        else
                        {
                            num3 = (base.Width - this.ScrollBarWidth) / this.ItemSize.Width;
                            if (num3 == 0)
                            {
                                num3 = 1;
                            }
                            num = 0;
                            for (num2 = 0; num2 < this.Items.Count; num2++)
                            {
                                control = this.duiBaseControl_2.Controls[num2];
                                if (control.Visible)
                                {
                                    control.Location = new Point(((num % num3) * this.ItemSize.Width) + control.Margin.Left, (((((num + num3) / num3) - 1) * this.ItemSize.Height) + num5) + control.Margin.Top);
                                    num++;
                                }
                            }
                            this.int_4 = (((num + num3) - 1) / num3) * this.ItemSize.Height;
                        }
                    }
                    else
                    {
                        num2 = 0;
                        while (num2 < this.Items.Count)
                        {
                            control = this.duiBaseControl_2.Controls[num2];
                            if (control.Visible)
                            {
                                control.Location = new Point(control.Margin.Left, num5 + control.Margin.Top);
                                this.int_4 += control.Height + control.Margin.Vertical;
                                num5 = this.int_4;
                                int num6 = control.Width + control.Margin.Horizontal;
                                width = (width > num6) ? width : num6;
                            }
                            num2++;
                        }
                    }
                    this.method_12();
                    if (this.bool_0)
                    {
                        this.method_1();
                        this.duiBaseControl_2.Height = this.int_4;
                    }
                    else
                    {
                        this.duiBaseControl_2.Size = new Size(width, this.int_4);
                    }
                }
                else
                {
                    int num8 = 0;
                    width = base.Height;
                    if (this.Ulmul)
                    {
                        if (this.bool_5)
                        {
                            rectangle = new Rectangle();
                            List<DuiBaseControl> list = new List<DuiBaseControl>();
                            for (num2 = 0; num2 < this.Items.Count; num2++)
                            {
                                control = this.Items[num2];
                                if (control.Visible)
                                {
                                    rectangle.Height = (rectangle.Height + control.Height) + control.Margin.Vertical;
                                    if ((rectangle.Height < width) || (list.Count == 0))
                                    {
                                        list.Add(control);
                                        rectangle.Width = (rectangle.Width > (control.Width + control.Margin.Horizontal)) ? rectangle.Width : (control.Width + control.Margin.Horizontal);
                                    }
                                    else
                                    {
                                        this.method_13(width, rectangle, list);
                                        rectangle.X = rectangle.Right;
                                        rectangle.Size = new Size(control.Width + control.Margin.Horizontal, control.Height + control.Margin.Vertical);
                                        list.Add(control);
                                    }
                                }
                                if ((list.Count > 0) && ((this.Items.Count - 1) == num2))
                                {
                                    this.method_13(width, rectangle, list);
                                }
                            }
                        }
                        else
                        {
                            num3 = (base.Height - this.ScrollBarWidth) / this.ItemSize.Height;
                            if (num3 == 0)
                            {
                                num3 = 1;
                            }
                            num = 0;
                            for (num2 = 0; num2 < this.Items.Count; num2++)
                            {
                                control = this.duiBaseControl_2.Controls[num2];
                                if (control.Visible)
                                {
                                    control.Location = new Point((((((num + num3) / num3) - 1) * this.ItemSize.Width) + num8) + control.Margin.Left, ((num % num3) * this.ItemSize.Height) + control.Margin.Top);
                                    num++;
                                }
                            }
                            this.int_4 = (((num + num3) - 1) / num3) * this.ItemSize.Width;
                        }
                    }
                    else
                    {
                        for (num2 = 0; num2 < this.Items.Count; num2++)
                        {
                            control = this.duiBaseControl_2.Controls[num2];
                            if (control.Visible)
                            {
                                control.Location = new Point(num8 + control.Margin.Left, control.Margin.Top);
                                this.int_4 += control.Width + control.Margin.Horizontal;
                                num8 = this.int_4;
                                int num7 = control.Height + control.Margin.Vertical;
                                width = (width > num7) ? width : num7;
                            }
                        }
                    }
                    if (this.bool_0)
                    {
                        this.method_1();
                        this.duiBaseControl_2.Width = this.int_4;
                    }
                    else
                    {
                        this.duiBaseControl_2.Size = new Size(this.int_4, width);
                    }
                    this.method_12();
                }
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    if (this.int_2 < (base.Width - this.int_4))
                    {
                        this.ListTop = base.Width - this.int_4;
                    }
                }
                else if (this.int_2 < (base.Height - this.int_4))
                {
                    this.ListTop = base.Height - this.int_4;
                }
            }
            else
            {
                if (this.bool_1)
                {
                    this.duiScrollBar_0.Visible = false;
                }
                this.ListTop = 0;
            }
            this.OnLayoutContented(EventArgs.Empty);
            this.Invalidate();
        }

        private void method_0(object sender, PaintEventArgs e)
        {
            this.OnLayeredPaint(new PaintEventArgs(e.Graphics, this.InnerDuiControl.ClientRectangle));
        }

        private void method_1()
        {
            if (this.bool_0)
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    this.duiBaseControl_2.Height = base.Height - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Height + this.duiScrollBar_0.Margin.Bottom) : 0);
                }
                else
                {
                    this.duiBaseControl_2.Width = base.Width - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Width + this.duiScrollBar_0.Margin.Right) : 0);
                }
            }
        }

        private void method_10(object sender, EventArgs e)
        {
            this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_11(object sender, MouseEventArgs e)
        {
            int index = this.Items.IndexOf(sender as DuiBaseControl);
            if (index > -1)
            {
                this.OnItemClick(new ItemClickEventArgs(index, this.Items[index], e.Button, e.Clicks, e.X, e.Y, e.Delta));
            }
        }

        private void method_12()
        {
            int num = (this.orientation_0 == System.Windows.Forms.Orientation.Vertical) ? base.Height : base.Width;
            if ((this.int_4 > num) && this.ShowScrollBar)
            {
                int num2 = (int) ((num - (this.duiScrollBar_0.ArrowHeight * 2)) * ((1.0 * num) / ((double) this.int_4)));
                if (num2 < 20)
                {
                    num2 = 20;
                }
                this.duiScrollBar_0.Value = (int) (this.Value * 10000.0);
                this.duiScrollBar_0.ScrollBarLenght = num2;
                this.duiScrollBar_0.Visible = true;
            }
            else if (this.bool_1)
            {
                this.duiScrollBar_0.Visible = false;
            }
        }

        private void method_13(int int_5, Rectangle rectangle_0, List<DuiBaseControl> list_0)
        {
            int num = 0;
            if (!this.bool_7)
            {
                num = int_5;
            }
            for (int i = 0; i < list_0.Count; i++)
            {
                DuiBaseControl control = list_0[i];
                control.Location = new Point(this.bool_6 ? (rectangle_0.X + control.Margin.Left) : ((rectangle_0.Right - control.Width) - control.Margin.Right), this.bool_7 ? (num + control.Margin.Top) : ((num - control.Height) - control.Margin.Vertical));
                num = this.bool_7 ? ((num + control.Margin.Vertical) + control.Height) : ((num - control.Height) - control.Margin.Vertical);
            }
            this.int_4 = rectangle_0.Right;
            list_0.Clear();
        }

        private void method_14(int int_5, Rectangle rectangle_0, List<DuiBaseControl> list_0)
        {
            int num = 0;
            if (!this.bool_6)
            {
                num = int_5;
            }
            for (int i = 0; i < list_0.Count; i++)
            {
                DuiBaseControl control = list_0[i];
                control.Location = new Point(this.bool_6 ? (num + control.Margin.Left) : ((num - control.Width) - control.Margin.Horizontal), this.bool_7 ? (rectangle_0.Y + control.Margin.Top) : ((rectangle_0.Bottom - control.Margin.Bottom) - control.Height));
                num = this.bool_6 ? ((num + control.Width) + control.Margin.Horizontal) : ((num - control.Width) - control.Margin.Horizontal);
            }
            this.int_4 = rectangle_0.Bottom;
            list_0.Clear();
        }

        private void method_15(int int_5)
        {
            if (this.Items.Count > 0)
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    if (this.int_4 > base.Height)
                    {
                        if ((this.ListTop + int_5) > 0)
                        {
                            this.ListTop = 0;
                        }
                        else if ((this.int_2 + int_5) < (base.Height - this.int_4))
                        {
                            this.ListTop = base.Height - this.int_4;
                        }
                        else
                        {
                            this.ListTop += int_5;
                        }
                    }
                    else
                    {
                        this.ListTop = 0;
                    }
                }
                else if (this.int_4 > base.Width)
                {
                    if ((this.int_2 + int_5) > 0)
                    {
                        this.ListTop = 0;
                    }
                    else if ((this.int_2 + int_5) < (base.Width - this.int_4))
                    {
                        this.ListTop = base.Width - this.int_4;
                    }
                    else
                    {
                        this.ListTop += int_5;
                    }
                }
                else
                {
                    this.ListTop = 0;
                }
            }
            else
            {
                this.Invalidate();
            }
        }

        private void method_16(object sender, PaintEventArgs e)
        {
            if (this.duiScrollBar_0.Visible)
            {
                e.Graphics.DrawImage(this.duiScrollBar_0.Canvas, this.duiScrollBar_0.Location);
            }
        }

        [CompilerGenerated]
        private void method_17(object sender, EventArgs e)
        {
            this.method_1();
        }

        [CompilerGenerated]
        private void method_18(object sender, EventArgs e)
        {
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle(this.duiScrollBar_0.Margin.Left, (base.Height - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Bottom, base.Width - this.duiScrollBar_0.Margin.Horizontal, this.ScrollBarWidth);
            }
            else
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.ScrollBarWidth, base.Height - this.duiScrollBar_0.Margin.Vertical);
            }
        }

        [CompilerGenerated]
        private void method_19(object sender, AcceptTaskEventArgs e)
        {
            this.OnAcceptTask(e);
            if (e.Handled)
            {
                e.object_1 = this;
            }
        }

        private void method_2(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseClick -= new EventHandler<DuiMouseEventArgs>(this.method_11);
            e.Control.MarginChanged -= new EventHandler(this.method_10);
            e.Control.VisibleChanged -= new EventHandler(this.method_9);
            e.Control.SizeChanged -= new EventHandler(this.method_8);
            e.Control.MouseUp -= new EventHandler<DuiMouseEventArgs>(this.method_6);
            e.Control.MouseDown -= new EventHandler<DuiMouseEventArgs>(this.method_5);
            e.Control.IsSelectedChanged -= new EventHandler(this.method_4);
            if (e.Control == this.duiBaseControl_0)
            {
                this.duiBaseControl_0 = null;
            }
            if (this.bool_10)
            {
                this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
            this.OnItemRemoved(e);
        }

        private void method_3(object sender, DuiControlEventArgs e)
        {
            e.Control.IsMoveParentPaint = false;
            e.Control.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_5);
            e.Control.Dock = DockStyle.None;
            e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            e.Control.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_11);
            e.Control.MouseUp += new EventHandler<DuiMouseEventArgs>(this.method_6);
            e.Control.MarginChanged += new EventHandler(this.method_10);
            e.Control.VisibleChanged += new EventHandler(this.method_9);
            e.Control.SizeChanged += new EventHandler(this.method_8);
            e.Control.IsSelectedChanged += new EventHandler(this.method_4);
            if (!this.bool_0)
            {
                e.Control.LayoutEngine.Parent = this.duiBaseControl_1;
            }
            if (this.bool_10)
            {
                this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
            this.OnItemAdded(e);
        }

        private void method_4(object sender, EventArgs e)
        {
            this.OnItemSelectedChanged(new DuiControlEventArgs(sender as DuiBaseControl));
        }

        private void method_5(object sender, DuiMouseEventArgs e)
        {
            if (!this.MouseUpSelect)
            {
                this.method_7(sender, e);
            }
        }

        private void method_6(object sender, DuiMouseEventArgs e)
        {
            if (this.MouseUpSelect)
            {
                this.method_7(sender, e);
            }
        }

        private void method_7(object sender, DuiMouseEventArgs e)
        {
            int num4;
            DuiBaseControl control2;
            DuiBaseControl control = sender as DuiBaseControl;
            switch (this.selectionModes_0)
            {
                case SelectionModes.Radio:
                    num4 = 0;
                    while (num4 < this.Items.Count)
                    {
                        control2 = this.Items[num4];
                        if (control2 != control)
                        {
                            control2.IsSelected = false;
                        }
                        num4++;
                    }
                    control.IsSelected = true;
                    this.duiBaseControl_0 = control;
                    break;

                case SelectionModes.MultipleSelection:
                    if ((Control.ModifierKeys != Keys.Control) || (e.Button != MouseButtons.Left))
                    {
                        if (((Control.ModifierKeys == Keys.Shift) && (this.duiBaseControl_0 != null)) && (e.Button == MouseButtons.Left))
                        {
                            int index = this.Items.IndexOf(this.duiBaseControl_0);
                            if (index >= 0)
                            {
                                int num = this.Items.IndexOf(control);
                                int num3 = (index > num) ? index : num;
                                index = (index > num) ? num : index;
                                num = num3;
                                for (num4 = 0; num4 < this.Items.Count; num4++)
                                {
                                    control2 = this.Items[num4];
                                    if ((num4 >= index) && (num4 <= num))
                                    {
                                        control2.IsSelected = true;
                                    }
                                    else
                                    {
                                        control2.IsSelected = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!control.IsSelected || (e.Button == MouseButtons.Left))
                            {
                                for (num4 = 0; num4 < this.Items.Count; num4++)
                                {
                                    control2 = this.Items[num4];
                                    if (control2 != control)
                                    {
                                        control2.IsSelected = false;
                                    }
                                }
                                control.IsSelected = true;
                            }
                            this.duiBaseControl_0 = control;
                        }
                        break;
                    }
                    control.IsSelected = !control.IsSelected;
                    break;
            }
        }

        private void method_8(object sender, EventArgs e)
        {
            this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_9(object sender, EventArgs e)
        {
            this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        protected virtual void OnAcceptTask(AcceptTaskEventArgs e)
        {
            if (this.eventHandler_8 != null)
            {
                this.eventHandler_8(this, e);
            }
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
        }

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.InnerDuiControl.Focused = true;
        }

        protected virtual void OnItemAdded(DuiControlEventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnItemRemoved(DuiControlEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnItemSelectedChanged(DuiControlEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.duiBaseControl_1.method_7(e);
            if ((this.selectionModes_0 == SelectionModes.MultipleSelection) && (e.Control && (e.KeyCode == Keys.A)))
            {
                foreach (DuiBaseControl control in this.Items)
                {
                    control.IsSelected = true;
                }
            }
            if (this.selectionModes_0 == SelectionModes.Radio)
            {
                int index;
                if (!(((e.KeyCode != Keys.Up) || (this.Orientation != System.Windows.Forms.Orientation.Vertical)) ? ((e.KeyCode != Keys.Left) || (this.Orientation != System.Windows.Forms.Orientation.Horizontal)) : false))
                {
                    index = this.Items.IndexOf(this.SelectedItem);
                    if ((index > 0) && (this.duiBaseControl_0 != null))
                    {
                        index--;
                        this.duiBaseControl_0.IsSelected = false;
                        this.duiBaseControl_0 = this.Items[index];
                        this.duiBaseControl_0.IsSelected = true;
                    }
                }
                else if (!(((e.KeyCode != Keys.Down) || (this.Orientation != System.Windows.Forms.Orientation.Vertical)) ? ((e.KeyCode != Keys.Right) || (this.Orientation != System.Windows.Forms.Orientation.Horizontal)) : false))
                {
                    index = this.Items.IndexOf(this.SelectedItem);
                    if ((index < (this.Items.Count - 1)) && (this.duiBaseControl_0 != null))
                    {
                        index++;
                        this.duiBaseControl_0.IsSelected = false;
                        this.duiBaseControl_0 = this.Items[index];
                        this.duiBaseControl_0.IsSelected = true;
                    }
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.duiBaseControl_1.method_6(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.duiBaseControl_1.method_5(e);
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnLayoutContented(EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.InnerDuiControl.Focused = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.duiScrollBar_0.IsMouseEnter)
            {
                this.InnerDuiControl.TriggerMouseClick(e);
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (!this.duiScrollBar_0.IsMouseEnter)
            {
                this.InnerDuiControl.TriggerMouseDoubleClick(e);
            }
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.EnabledMouseWheel)
            {
                base.Focus();
            }
            if (this.duiScrollBar_0.Visible && this.duiScrollBar_0.ClientRectangle.Contains(e.Location))
            {
                this.duiScrollBar_0.TriggerMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X - this.duiScrollBar_0.Left, e.Y - this.duiScrollBar_0.Top, e.Delta));
            }
            if (!this.duiScrollBar_0.IsMouseEnter)
            {
                this.InnerDuiControl.TriggerMouseDown(e);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.AutoFocus)
            {
                base.Focus();
            }
            this.InnerDuiControl.TriggerMouseEnter(e);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.duiScrollBar_0.Visible)
            {
                this.duiScrollBar_0.TriggerMouseLeave(e);
            }
            this.InnerDuiControl.TriggerMouseLeave(e);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.duiScrollBar_0.Visible)
            {
                if (this.duiScrollBar_0.ClientRectangle.Contains(e.Location) || this.duiScrollBar_0.IsMouseDown)
                {
                    if (!this.duiScrollBar_0.IsMouseEnter)
                    {
                        this.duiScrollBar_0.TriggerMouseEnter(EventArgs.Empty);
                    }
                    this.duiScrollBar_0.TriggerMouseMove(new MouseEventArgs(e.Button, e.Clicks, e.X - this.duiScrollBar_0.Left, e.Y - this.duiScrollBar_0.Top, e.Delta));
                }
                else if (this.duiScrollBar_0.IsMouseEnter)
                {
                    this.duiScrollBar_0.TriggerMouseLeave(EventArgs.Empty);
                }
            }
            if (!(this.duiScrollBar_0.IsMouseDown || this.duiScrollBar_0.IsMouseEnter))
            {
                this.InnerDuiControl.TriggerMouseMove(e);
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!this.duiScrollBar_0.IsMouseDown)
            {
                this.InnerDuiControl.TriggerMouseUp(e);
            }
            if (this.bool_8 && this.duiScrollBar_0.IsMouseDown)
            {
                this.duiScrollBar_0.TriggerMouseUp(new MouseEventArgs(e.Button, e.Clicks, e.X - this.duiScrollBar_0.Left, e.Y - this.duiScrollBar_0.Top, e.Delta));
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.bool_9)
            {
                if (this.SmoothScroll)
                {
                    if (e.Delta > 0)
                    {
                        this.int_0 += 10;
                    }
                    else
                    {
                        this.int_0 -= 10;
                    }
                }
                else if (e.Delta > 0)
                {
                    this.method_15(this.int_1);
                }
                else
                {
                    this.method_15(-this.int_1);
                }
            }
            base.OnMouseWheel(e);
            this.duiBaseControl_1.method_3(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.BitmapCache)
            {
                e.Graphics.DrawImage(this.InnerDuiControl.Canvas, 0, 0);
            }
            else
            {
                this.PaintControl(e.Graphics, e.ClipRectangle);
            }
            base.OnPaint(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            this.duiBaseControl_1.method_4(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.InnerDuiControl.Size = base.Size;
            this.duiBaseControl_2.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle(this.duiScrollBar_0.Margin.Left, (base.Height - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Bottom, base.Width - this.duiScrollBar_0.Margin.Horizontal, this.ScrollBarWidth);
            }
            else
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.ScrollBarWidth, base.Height - this.duiScrollBar_0.Margin.Vertical);
            }
            base.OnSizeChanged(e);
            this.method_1();
            if (((this.orientation_0 == System.Windows.Forms.Orientation.Horizontal) && (this.int_4 > base.Width)) && ((base.Width - this.duiBaseControl_2.Left) > this.int_4))
            {
                this.duiBaseControl_2.Left = base.Width - this.int_4;
            }
            else if (((this.orientation_0 == System.Windows.Forms.Orientation.Vertical) && (this.int_4 > base.Height)) && ((base.Height - this.duiBaseControl_2.Top) > this.int_4))
            {
                this.duiBaseControl_2.Top = base.Height - this.int_4;
            }
            this.method_12();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        [CompilerGenerated]
        private static bool smethod_0(DuiBaseControl duiBaseControl_3)
        {
            return duiBaseControl_3.IsSelected;
        }

        [CompilerGenerated]
        private static bool smethod_1(DuiBaseControl duiBaseControl_3)
        {
            return duiBaseControl_3.IsSelected;
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (this.int_0 > 40)
            {
                this.int_0 = 40;
            }
            if (this.int_0 < -40)
            {
                this.int_0 = -40;
            }
            if (this.int_0 > 1)
            {
                this.int_0--;
            }
            else if (this.int_0 < -1)
            {
                this.int_0++;
            }
            else
            {
                this.int_0 = 0;
            }
            if (this.int_0 != 0)
            {
                this.method_15(this.int_0);
            }
        }

        [Description("鼠标移入自动获取焦点"), DefaultValue(false), Category("DSkin")]
        public bool AutoFocus
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

        [Description("自动隐藏滚动条"), DefaultValue(true)]
        public bool AutoHideScrollBar
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

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = this.InnerDuiControl.BackColor = value;
            }
        }

        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = this.InnerDuiControl.BackgroundImage = value;
            }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = this.InnerDuiControl.BackgroundImageLayout = value;
            }
        }

        [Category("DSkin"), Description("位图缓存，位图缓存不适合大尺寸的控件"), DefaultValue(false)]
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

        [Category("DSkin"), Description("控件边框"), TypeConverter(typeof(BordersPropertyOrderConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DSkin.DirectUI.Borders Borders
        {
            get
            {
                return this.InnerDuiControl.Borders;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Bitmap Canvas
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

        [Description("内部容器自适应尺寸"), DefaultValue(true)]
        public bool ContainerAutoSize
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        [Browsable(false)]
        public int ContentLength
        {
            get
            {
                return this.int_4;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ContentOffset
        {
            get
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    return this.duiBaseControl_2.Left;
                }
                return this.duiBaseControl_2.Top;
            }
            set
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    this.duiBaseControl_2.Left = value;
                }
                else
                {
                    this.duiBaseControl_2.Top = value;
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size ContentSize
        {
            get
            {
                return this.duiBaseControl_2.Size;
            }
            set
            {
                this.duiBaseControl_2.Size = value;
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

        [Editor("System.Windows.Forms.Design.DataMemberListEditor", typeof(UITypeEditor)), Category("数据"), DefaultValue(""), Description("获取或设置数据源显示其数据的列表或表的名称")]
        public string DataMember
        {
            get
            {
                return this.string_0;
            }
            set
            {
                if (value != this.string_0)
                {
                    this.string_0 = value;
                }
            }
        }

        [AttributeProvider(typeof(IListSource)), Category("数据"), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get
            {
                return this.object_0;
            }
            set
            {
                if (this.object_0 != value)
                {
                    if ((value != null) && (!(value is IEnumerable) && !(value is IListSource)))
                    {
                        throw new ArgumentException("数据源必须为IEnumerable或者IListSource");
                    }
                    if (value == null)
                    {
                        this.ienumerable_0 = null;
                    }
                    this.object_0 = value;
                    this.OnDataSourceChanged(EventArgs.Empty);
                    if (!base.DesignMode)
                    {
                        this.DataBind();
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin"), Description("背景渲染")]
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

        [Description("启用浮动，多行模式生效（Ulmul为true）,不受ItemSize属性影响"), DefaultValue(false)]
        public bool EnabledFloat
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

        [Category("DSkin"), Description("是否启用鼠标滚轮控制"), DefaultValue(true)]
        public bool EnabledMouseWheel
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

        [Description("是否左浮动，否则为右浮动"), DefaultValue(true)]
        public bool FloatLeft
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

        [DefaultValue(true), Description("是否为上浮动，否则为下浮动")]
        public bool FloatTop
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

        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = this.InnerDuiControl.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = this.InnerDuiControl.ForeColor = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(false)]
        public DuiBaseControl InnerDuiControl
        {
            get
            {
                if (this.duiBaseControl_1 == null)
                {
                    this.duiBaseControl_1 = this.DuiControl;
                }
                return this.duiBaseControl_1;
            }
        }

        [Browsable(false)]
        public DuiScrollBar InnerScrollBar
        {
            get
            {
                return this.duiScrollBar_0;
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

        [Description("列表项目集合"), Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiControlCollection Items
        {
            get
            {
                return this.duiBaseControl_2.Controls;
            }
        }

        [Description("项目尺寸，只有启用了多行多列才有效果"), Category("DSkin"), DefaultValue(typeof(Size), "100,100")]
        public Size ItemSize
        {
            get
            {
                return this.size_0;
            }
            set
            {
                this.size_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int ListTop
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
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                    {
                        if ((this.int_4 < base.Width) || (this.int_2 > 0))
                        {
                            this.int_2 = 0;
                        }
                        else if (this.int_2 < (base.Width - this.int_4))
                        {
                            this.int_2 = base.Width - this.int_4;
                        }
                    }
                    else if ((this.int_4 < base.Height) || (this.int_2 > 0))
                    {
                        this.int_2 = 0;
                    }
                    else if (this.int_2 < (base.Height - this.int_4))
                    {
                        this.int_2 = base.Height - this.int_4;
                    }
                    if (!(!this.duiScrollBar_0.Visible || this.duiScrollBar_0.IsMouseDown))
                    {
                        this.duiScrollBar_0.Value = (int) (this.Value * 10000.0);
                    }
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                    {
                        this.duiBaseControl_2.Top = this.int_2;
                    }
                    else
                    {
                        this.duiBaseControl_2.Left = this.int_2;
                    }
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(true), Description("鼠标松开选择还是鼠标按下选择")]
        public bool MouseUpSelect
        {
            [CompilerGenerated]
            get
            {
                return this.bool_11;
            }
            [CompilerGenerated]
            set
            {
                this.bool_11 = value;
            }
        }

        [Category("DSkin"), Description("列表方向"), DefaultValue(1)]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.orientation_0;
            }
            set
            {
                if (this.orientation_0 != value)
                {
                    this.orientation_0 = value;
                    this.duiScrollBar_0.Orientation = value;
                    if (value == System.Windows.Forms.Orientation.Horizontal)
                    {
                        this.duiScrollBar_0.ClientRectangle = new Rectangle(this.duiScrollBar_0.Margin.Left, (base.Height - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Bottom, base.Width - this.duiScrollBar_0.Margin.Horizontal, this.ScrollBarWidth);
                    }
                    else
                    {
                        this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.ScrollBarWidth, base.Height - this.duiScrollBar_0.Margin.Vertical);
                    }
                }
            }
        }

        [Category("DSkin"), Description("滚轮每格滚动的像素值"), DefaultValue(20)]
        public int RollSize
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        [Category("DSkin"), DefaultValue(10), Description("滚动条宽度")]
        public int ScrollBarWidth
        {
            get
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    this.int_3 = this.duiScrollBar_0.Height;
                }
                else
                {
                    this.int_3 = this.duiScrollBar_0.Width;
                }
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = value;
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                    {
                        this.duiScrollBar_0.ClientRectangle = new Rectangle(this.duiScrollBar_0.Margin.Left, (base.Height - this.int_3) - this.duiScrollBar_0.Margin.Bottom, base.Width - this.duiScrollBar_0.Margin.Horizontal, this.int_3);
                    }
                    else
                    {
                        this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.int_3) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.int_3, base.Height - this.duiScrollBar_0.Margin.Vertical);
                    }
                    this.Invalidate();
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DuiBaseControl SelectedItem
        {
            get
            {
                if ((this.duiBaseControl_0 == null) || !this.duiBaseControl_0.IsSelected)
                {
                    if (func_0 == null)
                    {
                        func_0 = new Func<DuiBaseControl, bool>(null, (IntPtr) smethod_0);
                    }
                    this.duiBaseControl_0 = this.Items.FirstOrDefault<DuiBaseControl>(func_0);
                }
                return this.duiBaseControl_0;
            }
            set
            {
                if (this.duiBaseControl_0 != value)
                {
                    this.duiBaseControl_0 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        this.duiBaseControl_0.IsSelected = true;
                    }
                    foreach (DuiBaseControl control in this.Items)
                    {
                        if (control != this.duiBaseControl_0)
                        {
                            control.IsSelected = false;
                        }
                    }
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl[] SelectedItems
        {
            get
            {
                if (func_1 == null)
                {
                    func_1 = new Func<DuiBaseControl, bool>(null, (IntPtr) smethod_1);
                }
                return this.Items.Where<DuiBaseControl>(func_1).ToArray<DuiBaseControl>();
            }
        }

        [Description("项目选择模式"), DefaultValue(0)]
        public SelectionModes SelectionMode
        {
            get
            {
                return this.selectionModes_0;
            }
            set
            {
                this.selectionModes_0 = value;
            }
        }

        [Description("是否显示滚动条"), Category("DSkin"), DefaultValue(true)]
        public bool ShowScrollBar
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
                    this.Invalidate();
                }
            }
        }

        [Description("是否平滑滚动"), Category("DSkin"), DefaultValue(false)]
        public bool SmoothScroll
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                if (this.bool_3 != value)
                {
                    this.bool_3 = value;
                    if (value)
                    {
                        this.timer_0.Start();
                    }
                    else
                    {
                        this.timer_0.Stop();
                    }
                }
            }
        }

        [DefaultValue(false), Description("九宫格方式绘制背景图片"), Category("DSkin")]
        public bool SudokuDrawBackImage
        {
            get
            {
                return this.InnerDuiControl.SudokuDrawBackImage;
            }
            set
            {
                this.InnerDuiControl.SudokuDrawBackImage = value;
            }
        }

        [DefaultValue(typeof(Padding), "5,5,5,5"), Description("九宫格图片切割宽度"), Category("DSkin")]
        public Padding SudokuPartitionWidth
        {
            get
            {
                return this.InnerDuiControl.SudokuPartitionWidth;
            }
            set
            {
                this.InnerDuiControl.SudokuPartitionWidth = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Type Template
        {
            get
            {
                return this.type_0;
            }
            set
            {
                this.type_0 = value;
            }
        }

        [Description("是否启用多行多列"), Category("DSkin"), DefaultValue(false)]
        public bool Ulmul
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                if (this.bool_4 != value)
                {
                    this.bool_4 = value;
                    this.LayoutContent();
                }
            }
        }

        [Category("DSkin"), Description("滚动的百分比（0-1）")]
        public double Value
        {
            get
            {
                if (this.Items.Count > 0)
                {
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                    {
                        if (this.int_4 > base.Height)
                        {
                            return (((double) -this.int_2) / ((double) (this.int_4 - base.Height)));
                        }
                    }
                    else if (this.int_4 > base.Width)
                    {
                        return (((double) -this.int_2) / ((double) (this.int_4 - base.Width)));
                    }
                }
                return 0.0;
            }
            set
            {
                if (this.Value != value)
                {
                    double num;
                    if (value < 0.0)
                    {
                        num = 0.0;
                    }
                    else if (value > 1.0)
                    {
                        num = 1.0;
                    }
                    else
                    {
                        num = value;
                    }
                    if (this.Items.Count > 0)
                    {
                        if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                        {
                            if (this.int_4 > base.Height)
                            {
                                this.ListTop = (int) (-(this.int_4 - base.Height) * num);
                            }
                            else
                            {
                                this.ListTop = 0;
                            }
                        }
                        else if (this.int_4 > base.Width)
                        {
                            this.ListTop = (int) (-(this.int_4 - base.Width) * num);
                        }
                        else
                        {
                            this.ListTop = 0;
                        }
                    }
                }
            }
        }
    }
}

