namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiListBox : DuiBaseControl, ISupportInitialize
    {
        private bool bool_27;
        private bool bool_28;
        private bool bool_29;
        private bool bool_30;
        private bool bool_31;
        private bool bool_32;
        private bool bool_33;
        private bool bool_34;
        private bool bool_35;
        private bool bool_36;
        [CompilerGenerated]
        private bool bool_37;
        private DuiBaseControl duiBaseControl_1;
        private DuiBaseControl duiBaseControl_2;
        private DuiScrollBar duiScrollBar_0;
        [CompilerGenerated]
        private static Func<DuiBaseControl, bool> func_0;
        [CompilerGenerated]
        private static Func<DuiBaseControl, bool> func_1;
        private int HprVvjapHo;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private System.Windows.Forms.Orientation orientation_0;
        private SelectionModes selectionModes_0;
        private Size size_0;
        private System.Windows.Forms.Timer timer_0;

        public event EventHandler<DuiControlEventArgs> ItemAdded;

        [Description("列表项目被点击时发生")]
        public event EventHandler<ItemClickEventArgs> ItemClick;

        public event EventHandler<DuiControlEventArgs> ItemRemoved;

        [Category("选择行为"), Description("当项目选中状态改变之后发生")]
        public event EventHandler<DuiControlEventArgs> ItemSelectedChanged;

        public event EventHandler LayoutContented;

        [Description("Value改变时发生")]
        public event EventHandler ValueChanged;

        public DuiListBox()
        {
            EventHandler handler = null;
            EventHandler handler2 = null;
            this.duiBaseControl_1 = new DuiBaseControl();
            this.selectionModes_0 = SelectionModes.None;
            this.bool_27 = true;
            this.bool_28 = true;
            this.duiScrollBar_0 = new DuiScrollBar();
            this.bool_29 = false;
            this.orientation_0 = System.Windows.Forms.Orientation.Vertical;
            this.timer_0 = new System.Windows.Forms.Timer();
            this.bool_30 = false;
            this.int_1 = 0;
            this.bool_31 = false;
            this.size_0 = new Size(100, 100);
            this.bool_32 = false;
            this.bool_33 = true;
            this.bool_34 = true;
            this.int_2 = 20;
            this.int_3 = 0;
            this.bool_35 = true;
            this.HprVvjapHo = 10;
            this.int_4 = 0;
            this.bool_36 = true;
            this.Controls.Add(this.duiBaseControl_1);
            this.duiBaseControl_1.ControlAdded += new EventHandler<DuiControlEventArgs>(this.method_31);
            this.duiBaseControl_1.ControlRemoved += new EventHandler<DuiControlEventArgs>(this.method_30);
            this.duiBaseControl_1.DesignModeCanSelect = false;
            this.duiBaseControl_1.Name = "DuiListBoxInnerContainer";
            this.MouseUpSelect = true;
            this.timer_0.Interval = 15;
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            this.duiScrollBar_0.BitmapCache = true;
            this.duiScrollBar_0.ClientRectangle = new Rectangle(new Point(base.Width - this.ScrollBarWidth, 0), new Size(this.ScrollBarWidth, base.Height));
            this.duiScrollBar_0.Maximum = 0x2710;
            this.duiScrollBar_0.SmallChange = 500;
            this.duiScrollBar_0.LargeChange = 0x3e8;
            this.duiScrollBar_0.parent = this;
            this.duiScrollBar_0.ValueChanged += new EventHandler(this.duiScrollBar_0_ValueChanged);
            handler = new EventHandler(this.method_44);
            this.duiScrollBar_0.VisibleChanged += handler;
            handler2 = new EventHandler(this.method_45);
            this.duiScrollBar_0.MarginChanged += handler2;
            if (this.bool_28)
            {
                this.duiScrollBar_0.Visible = false;
            }
        }

        public void BeginInit()
        {
        }

        protected override void Dispose(bool disposing)
        {
            this.duiScrollBar_0.Dispose();
            base.Dispose(disposing);
        }

        public void DoSmoothScroll(int speed)
        {
            this.int_1 = -speed;
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

        public void LayoutContent()
        {
            this.int_4 = 0;
            if (this.Items.Count > 0)
            {
                int num2;
                int num3;
                DuiBaseControl control;
                int num4;
                int width;
                Rectangle rectangle;
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    width = base.Width;
                    int num5 = 0;
                    if (this.Ulmul)
                    {
                        if (this.bool_32)
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
                                        this.method_42(width, rectangle, list2);
                                        rectangle.Y = rectangle.Bottom;
                                        rectangle.Size = new Size(control.Width + control.Margin.Horizontal, control.Height + control.Margin.Vertical);
                                        list2.Add(control);
                                    }
                                }
                                if ((list2.Count > 0) && (i == (this.Items.Count - 1)))
                                {
                                    this.method_42(width, rectangle, list2);
                                }
                            }
                        }
                        else
                        {
                            num2 = (base.Width - this.ScrollBarWidth) / this.ItemSize.Width;
                            if (num2 == 0)
                            {
                                num2 = 1;
                            }
                            num4 = 0;
                            for (num3 = 0; num3 < this.Items.Count; num3++)
                            {
                                control = this.duiBaseControl_1.Controls[num3];
                                if (control.Visible)
                                {
                                    control.Location = new Point(((num4 % num2) * this.ItemSize.Width) + control.Margin.Left, (((((num4 + num2) / num2) - 1) * this.ItemSize.Height) + num5) + control.Margin.Top);
                                    num4++;
                                }
                            }
                            this.int_4 = (((num4 + num2) - 1) / num2) * this.ItemSize.Height;
                        }
                    }
                    else
                    {
                        num3 = 0;
                        while (num3 < this.Items.Count)
                        {
                            control = this.duiBaseControl_1.Controls[num3];
                            if (control.Visible)
                            {
                                control.Location = new Point(control.Margin.Left, num5 + control.Margin.Top);
                                this.int_4 += control.Height + control.Margin.Vertical;
                                num5 = this.int_4;
                                int num = control.Width + control.Margin.Horizontal;
                                width = (width > num) ? width : num;
                            }
                            num3++;
                        }
                    }
                    this.method_40();
                    if (this.bool_27)
                    {
                        this.method_29();
                        this.duiBaseControl_1.Height = this.int_4;
                    }
                    else
                    {
                        this.duiBaseControl_1.Size = new Size(width, this.int_4);
                    }
                }
                else
                {
                    int num7 = 0;
                    width = base.Height;
                    if (this.Ulmul)
                    {
                        if (this.bool_32)
                        {
                            rectangle = new Rectangle();
                            List<DuiBaseControl> list = new List<DuiBaseControl>();
                            for (num3 = 0; num3 < this.Items.Count; num3++)
                            {
                                control = this.Items[num3];
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
                                        this.method_41(width, rectangle, list);
                                        rectangle.X = rectangle.Right;
                                        rectangle.Size = new Size(control.Width + control.Margin.Horizontal, control.Height + control.Margin.Vertical);
                                        list.Add(control);
                                    }
                                }
                                if ((list.Count > 0) && ((this.Items.Count - 1) == num3))
                                {
                                    this.method_41(width, rectangle, list);
                                }
                            }
                        }
                        else
                        {
                            num2 = (base.Height - this.ScrollBarWidth) / this.ItemSize.Height;
                            if (num2 == 0)
                            {
                                num2 = 1;
                            }
                            num4 = 0;
                            for (num3 = 0; num3 < this.Items.Count; num3++)
                            {
                                control = this.duiBaseControl_1.Controls[num3];
                                if (control.Visible)
                                {
                                    control.Location = new Point((((((num4 + num2) / num2) - 1) * this.ItemSize.Width) + num7) + control.Margin.Left, ((num4 % num2) * this.ItemSize.Height) + control.Margin.Top);
                                    num4++;
                                }
                            }
                            this.int_4 = (((num4 + num2) - 1) / num2) * this.ItemSize.Width;
                        }
                    }
                    else
                    {
                        for (num3 = 0; num3 < this.Items.Count; num3++)
                        {
                            control = this.duiBaseControl_1.Controls[num3];
                            if (control.Visible)
                            {
                                control.Location = new Point(num7 + control.Margin.Left, control.Margin.Top);
                                this.int_4 += control.Width + control.Margin.Horizontal;
                                num7 = this.int_4;
                                int num9 = control.Height + control.Margin.Vertical;
                                width = (width > num9) ? width : num9;
                            }
                        }
                    }
                    if (this.bool_27)
                    {
                        this.method_29();
                        this.duiBaseControl_1.Width = this.int_4;
                    }
                    else
                    {
                        this.duiBaseControl_1.Size = new Size(this.int_4, width);
                    }
                    this.method_40();
                }
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    if (this.int_3 < (base.Width - this.int_4))
                    {
                        this.ListTop = base.Width - this.int_4;
                    }
                }
                else if (this.int_3 < (base.Height - this.int_4))
                {
                    this.ListTop = base.Height - this.int_4;
                }
            }
            else
            {
                if (this.bool_28)
                {
                    this.duiScrollBar_0.Visible = false;
                }
                this.ListTop = 0;
            }
            this.OnLayoutContented(EventArgs.Empty);
            this.Invalidate();
        }

        private void method_29()
        {
            if (this.bool_27)
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    this.duiBaseControl_1.Height = base.Height - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Height + this.duiScrollBar_0.Margin.Bottom) : 0);
                }
                else
                {
                    this.duiBaseControl_1.Width = base.Width - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Width + this.duiScrollBar_0.Margin.Right) : 0);
                }
            }
        }

        private void method_30(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseClick -= new EventHandler<DuiMouseEventArgs>(this.method_39);
            e.Control.MarginChanged -= new EventHandler(this.method_38);
            e.Control.VisibleChanged -= new EventHandler(this.method_37);
            e.Control.SizeChanged -= new EventHandler(this.method_36);
            e.Control.MouseUp -= new EventHandler<DuiMouseEventArgs>(this.method_34);
            e.Control.IsSelectedChanged -= new EventHandler(this.method_33);
            e.Control.MouseDown -= new EventHandler<DuiMouseEventArgs>(this.method_32);
            if (e.Control == this.duiBaseControl_2)
            {
                this.duiBaseControl_2 = null;
            }
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            this.OnItemRemoved(e);
        }

        private void method_31(object sender, DuiControlEventArgs e)
        {
            e.Control.IsMoveParentPaint = false;
            e.Control.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_32);
            e.Control.Dock = DockStyle.None;
            e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            e.Control.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_39);
            e.Control.MouseUp += new EventHandler<DuiMouseEventArgs>(this.method_34);
            e.Control.MarginChanged += new EventHandler(this.method_38);
            e.Control.VisibleChanged += new EventHandler(this.method_37);
            e.Control.SizeChanged += new EventHandler(this.method_36);
            e.Control.IsSelectedChanged += new EventHandler(this.method_33);
            if (!this.bool_27)
            {
                e.Control.LayoutEngine.Parent = this;
            }
            this.OnItemAdded(e);
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_32(object sender, DuiMouseEventArgs e)
        {
            if (!this.MouseUpSelect)
            {
                this.method_35(sender, e);
            }
        }

        private void method_33(object sender, EventArgs e)
        {
            this.OnItemSelectedChanged(new DuiControlEventArgs(sender as DuiBaseControl));
        }

        private void method_34(object sender, DuiMouseEventArgs e)
        {
            if (this.MouseUpSelect)
            {
                this.method_35(sender, e);
            }
        }

        private void method_35(object sender, DuiMouseEventArgs e)
        {
            int num;
            DuiBaseControl control2;
            DuiBaseControl control = sender as DuiBaseControl;
            switch (this.selectionModes_0)
            {
                case SelectionModes.Radio:
                    num = 0;
                    while (num < this.Items.Count)
                    {
                        control2 = this.Items[num];
                        if (control2 != control)
                        {
                            control2.IsSelected = false;
                        }
                        num++;
                    }
                    control.IsSelected = true;
                    this.duiBaseControl_2 = control;
                    break;

                case SelectionModes.MultipleSelection:
                    if ((Control.ModifierKeys != Keys.Control) || (e.Button != MouseButtons.Left))
                    {
                        if (((Control.ModifierKeys == Keys.Shift) && (this.duiBaseControl_2 != null)) && (e.Button == MouseButtons.Left))
                        {
                            int index = this.Items.IndexOf(this.duiBaseControl_2);
                            if (index >= 0)
                            {
                                int num2 = this.Items.IndexOf(control);
                                int num4 = (index > num2) ? index : num2;
                                index = (index > num2) ? num2 : index;
                                num2 = num4;
                                for (num = 0; num < this.Items.Count; num++)
                                {
                                    control2 = this.Items[num];
                                    if ((num >= index) && (num <= num2))
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
                                for (num = 0; num < this.Items.Count; num++)
                                {
                                    control2 = this.Items[num];
                                    if (control2 != control)
                                    {
                                        control2.IsSelected = false;
                                    }
                                }
                                control.IsSelected = true;
                            }
                            this.duiBaseControl_2 = control;
                        }
                        break;
                    }
                    control.IsSelected = !control.IsSelected;
                    break;
            }
        }

        private void method_36(object sender, EventArgs e)
        {
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_37(object sender, EventArgs e)
        {
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_38(object sender, EventArgs e)
        {
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_39(object sender, MouseEventArgs e)
        {
            int index = this.Items.IndexOf(sender as DuiBaseControl);
            if (index > -1)
            {
                this.OnItemClick(new ItemClickEventArgs(index, this.Items[index], e.Button, e.Clicks, e.X, e.Y, e.Delta));
            }
        }

        private void method_40()
        {
            int num2 = (this.orientation_0 == System.Windows.Forms.Orientation.Vertical) ? base.Height : base.Width;
            if ((this.int_4 > num2) && this.ShowScrollBar)
            {
                int num = (int) ((num2 - (this.duiScrollBar_0.ArrowHeight * 2)) * ((1.0 * num2) / ((double) this.int_4)));
                if (num < 20)
                {
                    num = 20;
                }
                this.duiScrollBar_0.Value = (int) (this.Value * 10000.0);
                this.duiScrollBar_0.ScrollBarLenght = num;
                this.duiScrollBar_0.Visible = true;
            }
            else if (this.bool_28)
            {
                this.duiScrollBar_0.Visible = false;
            }
        }

        private void method_41(int int_5, Rectangle rectangle_2, List<DuiBaseControl> list_1)
        {
            int num = 0;
            if (!this.bool_34)
            {
                num = int_5;
            }
            for (int i = 0; i < list_1.Count; i++)
            {
                DuiBaseControl control = list_1[i];
                control.Location = new Point(this.bool_33 ? (rectangle_2.X + control.Margin.Left) : ((rectangle_2.Right - control.Width) - control.Margin.Right), this.bool_34 ? (num + control.Margin.Top) : ((num - control.Height) - control.Margin.Vertical));
                num = this.bool_34 ? ((num + control.Margin.Vertical) + control.Height) : ((num - control.Height) - control.Margin.Vertical);
            }
            this.int_4 = rectangle_2.Right;
            list_1.Clear();
        }

        private void method_42(int int_5, Rectangle rectangle_2, List<DuiBaseControl> list_1)
        {
            int num = 0;
            if (!this.bool_33)
            {
                num = int_5;
            }
            for (int i = 0; i < list_1.Count; i++)
            {
                DuiBaseControl control = list_1[i];
                control.Location = new Point(this.bool_33 ? (num + control.Margin.Left) : ((num - control.Width) - control.Margin.Horizontal), this.bool_34 ? (rectangle_2.Y + control.Margin.Top) : ((rectangle_2.Bottom - control.Margin.Bottom) - control.Height));
                num = this.bool_33 ? ((num + control.Width) + control.Margin.Horizontal) : ((num - control.Width) - control.Margin.Horizontal);
            }
            this.int_4 = rectangle_2.Bottom;
            list_1.Clear();
        }

        private void method_43(int int_5)
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
                        else if ((this.int_3 + int_5) < (base.Height - this.int_4))
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
                    if ((this.int_3 + int_5) > 0)
                    {
                        this.ListTop = 0;
                    }
                    else if ((this.int_3 + int_5) < (base.Width - this.int_4))
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

        [CompilerGenerated]
        private void method_44(object sender, EventArgs e)
        {
            this.method_29();
        }

        [CompilerGenerated]
        private void method_45(object sender, EventArgs e)
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

        protected virtual void OnItemAdded(DuiControlEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnItemRemoved(DuiControlEventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
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
                    if ((index > 0) && (this.duiBaseControl_2 != null))
                    {
                        index--;
                        this.duiBaseControl_2.IsSelected = false;
                        this.duiBaseControl_2 = this.Items[index];
                        this.duiBaseControl_2.IsSelected = true;
                    }
                }
                else if (!(((e.KeyCode != Keys.Down) || (this.Orientation != System.Windows.Forms.Orientation.Vertical)) ? ((e.KeyCode != Keys.Right) || (this.Orientation != System.Windows.Forms.Orientation.Horizontal)) : false))
                {
                    index = this.Items.IndexOf(this.SelectedItem);
                    if ((index < (this.Items.Count - 1)) && (this.duiBaseControl_2 != null))
                    {
                        index++;
                        this.duiBaseControl_2.IsSelected = false;
                        this.duiBaseControl_2 = this.Items[index];
                        this.duiBaseControl_2.IsSelected = true;
                    }
                }
            }
        }

        protected virtual void OnLayoutContented(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            if (this.EnabledMouseWheel)
            {
                base.Focus();
            }
            if (this.duiScrollBar_0.Visible && this.duiScrollBar_0.ClientRectangle.Contains(e.Location))
            {
                this.duiScrollBar_0.TriggerMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X - this.duiScrollBar_0.Left, e.Y - this.duiScrollBar_0.Top, e.Delta));
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            if (this.AutoFocus)
            {
                base.Focus();
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.duiScrollBar_0.Visible)
            {
                this.duiScrollBar_0.TriggerMouseLeave(e);
            }
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
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
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            if (this.bool_35 && this.duiScrollBar_0.IsMouseDown)
            {
                this.duiScrollBar_0.TriggerMouseUp(new MouseEventArgs(e.Button, e.Clicks, e.X - this.duiScrollBar_0.Left, e.Y - this.duiScrollBar_0.Top, e.Delta));
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.bool_36)
            {
                if (this.SmoothScroll)
                {
                    if (e.Delta > 0)
                    {
                        this.int_1 += 10;
                    }
                    else
                    {
                        this.int_1 -= 10;
                    }
                }
                else if (e.Delta > 0)
                {
                    this.method_43(this.int_2);
                }
                else
                {
                    this.method_43(-this.int_2);
                }
            }
            base.OnMouseWheel(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.duiScrollBar_0.Visible)
            {
                e.Graphics.DrawImage(this.duiScrollBar_0.Canvas, this.duiScrollBar_0.Location);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.duiBaseControl_1.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle(this.duiScrollBar_0.Margin.Left, (base.Height - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Bottom, base.Width - this.duiScrollBar_0.Margin.Horizontal, this.ScrollBarWidth);
            }
            else
            {
                this.duiScrollBar_0.ClientRectangle = new Rectangle((base.Width - this.ScrollBarWidth) - this.duiScrollBar_0.Margin.Right, this.duiScrollBar_0.Margin.Top, this.ScrollBarWidth, base.Height - this.duiScrollBar_0.Margin.Vertical);
            }
            base.OnSizeChanged(e);
            this.method_29();
            if (((this.orientation_0 == System.Windows.Forms.Orientation.Horizontal) && (this.int_4 > base.Width)) && ((base.Width - this.duiBaseControl_1.Left) > this.int_4))
            {
                this.duiBaseControl_1.Left = base.Width - this.int_4;
            }
            else if (((this.orientation_0 == System.Windows.Forms.Orientation.Vertical) && (this.int_4 > base.Height)) && ((base.Height - this.duiBaseControl_1.Top) > this.int_4))
            {
                this.duiBaseControl_1.Top = base.Height - this.int_4;
            }
            this.method_40();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
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
            if (this.int_1 > 40)
            {
                this.int_1 = 40;
            }
            if (this.int_1 < -40)
            {
                this.int_1 = -40;
            }
            if (this.int_1 > 1)
            {
                this.int_1--;
            }
            else if (this.int_1 < -1)
            {
                this.int_1++;
            }
            else
            {
                this.int_1 = 0;
            }
            if (this.int_1 != 0)
            {
                this.method_43(this.int_1);
            }
        }

        [DefaultValue(false), Description("鼠标移入自动获取焦点"), Category("DSkin")]
        public bool AutoFocus
        {
            get
            {
                return this.bool_29;
            }
            set
            {
                this.bool_29 = value;
            }
        }

        [Description("自动隐藏滚动条"), DefaultValue(true)]
        public bool AutoHideScrollBar
        {
            get
            {
                return this.bool_28;
            }
            set
            {
                this.bool_28 = value;
            }
        }

        [Description("内部容器自适应尺寸"), DefaultValue(true)]
        public bool ContainerAutoSize
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                this.bool_27 = value;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int ContentOffset
        {
            get
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    return this.duiBaseControl_1.Left;
                }
                return this.duiBaseControl_1.Top;
            }
            set
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    this.duiBaseControl_1.Left = value;
                }
                else
                {
                    this.duiBaseControl_1.Top = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Size ContentSize
        {
            get
            {
                return this.duiBaseControl_1.Size;
            }
            set
            {
                this.duiBaseControl_1.Size = value;
            }
        }

        [Description("启用浮动，多行模式生效（Ulmul为true）,不受ItemSize属性影响"), DefaultValue(false)]
        public bool EnabledFloat
        {
            get
            {
                return this.bool_32;
            }
            set
            {
                this.bool_32 = value;
            }
        }

        [DefaultValue(true), Category("DSkin"), Description("是否启用鼠标滚轮控制")]
        public bool EnabledMouseWheel
        {
            get
            {
                return this.bool_36;
            }
            set
            {
                this.bool_36 = value;
            }
        }

        [Description("是否左浮动，否则为右浮动"), DefaultValue(true)]
        public bool FloatLeft
        {
            get
            {
                return this.bool_33;
            }
            set
            {
                this.bool_33 = value;
            }
        }

        [DefaultValue(true), Description("是否为上浮动，否则为下浮动")]
        public bool FloatTop
        {
            get
            {
                return this.bool_34;
            }
            set
            {
                this.bool_34 = value;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin"), Description("列表项目集合")]
        public DuiControlCollection Items
        {
            get
            {
                return this.duiBaseControl_1.Controls;
            }
        }

        [Description("项目尺寸，只有启用了多行多列才有效果"), Category("DSkin")]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ListTop
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = value;
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                    {
                        if ((this.int_4 < base.Width) || (this.int_3 > 0))
                        {
                            this.int_3 = 0;
                        }
                        else if (this.int_3 < (base.Width - this.int_4))
                        {
                            this.int_3 = base.Width - this.int_4;
                        }
                    }
                    else if ((this.int_4 < base.Height) || (this.int_3 > 0))
                    {
                        this.int_3 = 0;
                    }
                    else if (this.int_3 < (base.Height - this.int_4))
                    {
                        this.int_3 = base.Height - this.int_4;
                    }
                    if (!(!this.duiScrollBar_0.Visible || this.duiScrollBar_0.IsMouseDown))
                    {
                        this.duiScrollBar_0.Value = (int) (this.Value * 10000.0);
                    }
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                    {
                        this.duiBaseControl_1.Top = this.int_3;
                    }
                    else
                    {
                        this.duiBaseControl_1.Left = this.int_3;
                    }
                    this.OnValueChanged(EventArgs.Empty);
                    base.OnPropertyChanged("ListTop");
                }
            }
        }

        [DefaultValue(true), Description("鼠标松开选择还是鼠标按下选择")]
        public bool MouseUpSelect
        {
            [CompilerGenerated]
            get
            {
                return this.bool_37;
            }
            [CompilerGenerated]
            set
            {
                this.bool_37 = value;
            }
        }

        [Category("DSkin"), Description("列表方向")]
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
                        this.duiScrollBar_0.ClientRectangle = new Rectangle(0, base.Height - this.ScrollBarWidth, base.Width, this.ScrollBarWidth);
                    }
                    else
                    {
                        this.duiScrollBar_0.ClientRectangle = new Rectangle(base.Width - this.ScrollBarWidth, 0, this.ScrollBarWidth, base.Height);
                    }
                }
            }
        }

        [Category("DSkin"), Description("滚轮每格滚动的像素值")]
        public int RollSize
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        [Description("滚动条宽度"), Category("DSkin"), DefaultValue(10)]
        public int ScrollBarWidth
        {
            get
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    this.HprVvjapHo = this.duiScrollBar_0.Height;
                }
                else
                {
                    this.HprVvjapHo = this.duiScrollBar_0.Width;
                }
                return this.HprVvjapHo;
            }
            set
            {
                if (this.HprVvjapHo != value)
                {
                    this.HprVvjapHo = value;
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                    {
                        this.duiScrollBar_0.Height = value;
                    }
                    else
                    {
                        this.duiScrollBar_0.Width = value;
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
                if (this.duiBaseControl_2 == null)
                {
                    if (func_0 == null)
                    {
                        func_0 = new Func<DuiBaseControl, bool>(null, (IntPtr) smethod_0);
                    }
                    this.duiBaseControl_2 = this.Items.FirstOrDefault<DuiBaseControl>(func_0);
                }
                return this.duiBaseControl_2;
            }
            set
            {
                if (this.duiBaseControl_2 != value)
                {
                    this.duiBaseControl_2 = value;
                    if (this.duiBaseControl_2 != null)
                    {
                        this.duiBaseControl_2.IsSelected = true;
                    }
                    foreach (DuiBaseControl control in this.Items)
                    {
                        if (control != this.duiBaseControl_2)
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

        [Category("DSkin"), Description("是否显示滚动条")]
        public bool ShowScrollBar
        {
            get
            {
                return this.bool_35;
            }
            set
            {
                if (this.bool_35 != value)
                {
                    this.bool_35 = value;
                    this.Invalidate();
                }
            }
        }

        [Description("是否平滑滚动"), Category("DSkin")]
        public bool SmoothScroll
        {
            get
            {
                return this.bool_30;
            }
            set
            {
                if (this.bool_30 != value)
                {
                    this.bool_30 = value;
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

        [Category("DSkin"), Description("是否启用多行多列")]
        public bool Ulmul
        {
            get
            {
                return this.bool_31;
            }
            set
            {
                if (this.bool_31 != value)
                {
                    this.bool_31 = value;
                    this.LayoutContent();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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
                            return (((double) -this.int_3) / ((double) (this.int_4 - base.Height)));
                        }
                    }
                    else if (this.int_4 > base.Width)
                    {
                        return (((double) -this.int_3) / ((double) (this.int_4 - base.Width)));
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

