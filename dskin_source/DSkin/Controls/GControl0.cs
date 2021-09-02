namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [Designer("DSkin.Design.DSkinDynamicListBoxDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null"), Description("动态列表，支持用鼠标拖拽调整顺序，以及绑定TabControl")]
    public class GControl0 : DSkinBaseControl
    {
        [CompilerGenerated]
        private static Action<bool> aauvYdrmn1;
        [CompilerGenerated]
        private static Action<bool> action_0;
        [CompilerGenerated]
        private static Action<bool> action_1;
        [CompilerGenerated]
        private static Action<bool> action_2;
        [CompilerGenerated]
        private static Action<bool> action_3;
        [CompilerGenerated]
        private static Action<bool> action_4;
        private bool bool_0;
        private Collection<DSkinDynamicListBoxItem> collection_0;
        private DSkinDynamicListBoxItem dskinDynamicListBoxItem_0;
        private DSkinTabControl dskinTabControl_0;
        private DuiBaseControl duiBaseControl_1;
        private DuiScrollBar duiScrollBar_0;
        private DuiScrollBar duiScrollBar_1;
        private int int_0;
        private int int_1;
        private int int_2;
        private System.Windows.Forms.Orientation orientation_0;

        public event EventHandler<ItemClickEventArgs> ItemClick;

        [Description("选项卡选中下标改变时触发"), Category("选项卡选中改变事件")]
        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;

        public GControl0()
        {
            EventHandler handler = null;
            MouseEventHandler handler2 = null;
            DuiBaseControl control = new DuiBaseControl {
                Dock = DockStyle.Fill
            };
            this.duiBaseControl_1 = control;
            this.bool_0 = true;
            this.int_0 = 20;
            this.int_1 = 0;
            this.int_2 = 0;
            this.duiScrollBar_0 = null;
            this.duiScrollBar_1 = null;
            this.orientation_0 = System.Windows.Forms.Orientation.Vertical;
            this.dskinDynamicListBoxItem_0 = null;
            handler = new EventHandler(this.method_11);
            base.SizeChanged += handler;
            this.DuiControlCollection_0.Add(this.duiBaseControl_1);
            this.DuiControlCollection_0.Add(this.VerticalScrollBar);
            this.DuiControlCollection_0.Add(this.HorizontalScrollBar);
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            handler2 = new MouseEventHandler(this.method_12);
            base.MouseWheel += handler2;
        }

        public DSkinDynamicListBoxItem FindItemFroNewPageIndex(int index)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].NewTabPageIndex == index)
                {
                    return this.Items[i];
                }
            }
            return null;
        }

        public DSkinDynamicListBoxItem FindMoveItemToItem(DSkinDynamicListBoxItem item)
        {
            Rectangle clientRectangle = item.ClientRectangle;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (item != this.Items[i])
                {
                    Rectangle rectangle2 = this.Items[i].ClientRectangle;
                    rectangle2.Intersect(clientRectangle);
                    if (((rectangle2.Width * rectangle2.Height) * 1.0) >= (((clientRectangle.Width * clientRectangle.Height) * 3.0) / 5.0))
                    {
                        return this.Items[i];
                    }
                }
            }
            return null;
        }

        public int GetHeight(int index)
        {
            int num = 0;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].NewTabPageIndex < index)
                {
                    num += this.Items[i].Height;
                }
            }
            return num;
        }

        public int GetPageIndex(DSkinDynamicListBoxItem item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetWidth(int index)
        {
            int num = 0;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].NewTabPageIndex < index)
                {
                    num += this.Items[i].Width;
                }
            }
            return (num + this.OffsetLeft);
        }

        public void ItemToBooton(DSkinDynamicListBoxItem item)
        {
            if ((item != null) && (item.NewTabPageIndex < (this.Items.Count - 1)))
            {
                this.ItemToItemChanged(item, this.FindItemFroNewPageIndex(this.Items.Count - 1));
            }
        }

        public void ItemToItemChanged(DSkinDynamicListBoxItem item1, DSkinDynamicListBoxItem item2)
        {
            if ((item1 != null) && (item2 != null))
            {
                int num;
                int newTabPageIndex;
                int top;
                if (item1.NewTabPageIndex > item2.NewTabPageIndex)
                {
                    top = item2.Top;
                    newTabPageIndex = item2.NewTabPageIndex;
                    if (action_1 == null)
                    {
                        action_1 = new Action<bool>(GControl0.smethod_2);
                    }
                    item1.DoEffect<DSkinDynamicListBoxItem>(item1.Top, top, 120, "Top", action_1);
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        if ((this.Items[num].NewTabPageIndex < item1.NewTabPageIndex) && (this.Items[num].NewTabPageIndex >= item2.NewTabPageIndex))
                        {
                            this.Items[num].ChangedMove = true;
                            this.Items[num].MoveToPoint = this.Items[num].Top + item1.Height;
                            if (action_2 == null)
                            {
                                action_2 = new Action<bool>(GControl0.smethod_3);
                            }
                            this.Items[num].DoEffect<DSkinDynamicListBoxItem>(this.Items[num].Top, this.Items[num].MoveToPoint, 120, "Top", action_2);
                            DSkinDynamicListBoxItem local1 = this.Items[num];
                            local1.NewTabPageIndex++;
                        }
                    }
                    item1.NewTabPageIndex = newTabPageIndex;
                }
                else if (item1.NewTabPageIndex < item2.NewTabPageIndex)
                {
                    top = item2.Top;
                    newTabPageIndex = item2.NewTabPageIndex;
                    if (action_3 == null)
                    {
                        action_3 = new Action<bool>(GControl0.smethod_4);
                    }
                    item1.DoEffect<DSkinDynamicListBoxItem>(item1.Top, top, 120, "Top", action_3);
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        if ((this.Items[num].NewTabPageIndex > item1.NewTabPageIndex) && (this.Items[num].NewTabPageIndex <= item2.NewTabPageIndex))
                        {
                            this.Items[num].ChangedMove = true;
                            this.Items[num].MoveToPoint = this.Items[num].Top - item1.Height;
                            if (action_4 == null)
                            {
                                action_4 = new Action<bool>(GControl0.smethod_5);
                            }
                            this.Items[num].DoEffect<DSkinDynamicListBoxItem>(this.Items[num].Top, this.Items[num].MoveToPoint, 120, "Top", action_4);
                            DSkinDynamicListBoxItem local2 = this.Items[num];
                            local2.NewTabPageIndex--;
                        }
                    }
                    item1.NewTabPageIndex = newTabPageIndex;
                }
                base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
        }

        public void ItemToTop(DSkinDynamicListBoxItem item)
        {
            if ((item != null) && (item.NewTabPageIndex > 0))
            {
                this.ItemToItemChanged(item, this.FindItemFroNewPageIndex(0));
            }
        }

        public void LayoutContent()
        {
            this.method_9();
        }

        private void method_10(DSkinDynamicListBoxItem dskinDynamicListBoxItem_1)
        {
            if (dskinDynamicListBoxItem_1 == null)
            {
                this.OnSelectedItemChanged(new SelectedItemChangedEventArgs(null, -1, -1));
            }
            else
            {
                this.OnSelectedItemChanged(new SelectedItemChangedEventArgs(dskinDynamicListBoxItem_1, this.GetPageIndex(dskinDynamicListBoxItem_1), dskinDynamicListBoxItem_1.NewTabPageIndex));
            }
        }

        [CompilerGenerated]
        private void method_11(object sender, EventArgs e)
        {
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        [CompilerGenerated]
        private void method_12(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
                {
                    if (this.VerticalScrollBar.Visible)
                    {
                        DuiScrollBar verticalScrollBar = this.VerticalScrollBar;
                        verticalScrollBar.Value -= this.int_0;
                    }
                }
                else if ((this.Orientation == System.Windows.Forms.Orientation.Horizontal) && this.HorizontalScrollBar.Visible)
                {
                    DuiScrollBar horizontalScrollBar = this.HorizontalScrollBar;
                    horizontalScrollBar.Value -= this.int_0;
                }
            }
            else if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                if (this.VerticalScrollBar.Visible)
                {
                    DuiScrollBar bar3 = this.VerticalScrollBar;
                    bar3.Value += this.int_0;
                }
            }
            else if ((this.Orientation == System.Windows.Forms.Orientation.Horizontal) && this.HorizontalScrollBar.Visible)
            {
                DuiScrollBar bar4 = this.HorizontalScrollBar;
                bar4.Value += this.int_0;
            }
        }

        [CompilerGenerated]
        private void method_13(object sender, EventArgs e)
        {
            this.OffsetTop = 0;
            this.duiScrollBar_0.Value = 0;
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        [CompilerGenerated]
        private void method_14(object sender, EventArgs e)
        {
            this.OffsetTop = -this.duiScrollBar_0.Value;
        }

        [CompilerGenerated]
        private void method_15(object sender, EventArgs e)
        {
            this.OffsetLeft = 0;
            this.duiScrollBar_1.Value = 0;
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        [CompilerGenerated]
        private void method_16(object sender, EventArgs e)
        {
            this.OffsetLeft = -this.duiScrollBar_1.Value;
        }

        private void method_6(object sender, CollectionEventArgs<DSkinDynamicListBoxItem> e)
        {
            e.Item.MouseEventBubble = false;
            e.Item.NewTabPageIndex = this.Items.Count - 1;
            DSkinDynamicListBoxItem item = this.FindItemFroNewPageIndex(e.Item.NewTabPageIndex - 1);
            if (item != null)
            {
                e.Item.Top = item.Top + item.Height;
            }
            else
            {
                e.Item.Top = 0;
            }
            this.duiBaseControl_1.Controls.Add(e.Item);
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            e.Item.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_8);
        }

        private void method_7(object sender, CollectionEventArgs<DSkinDynamicListBoxItem> e)
        {
            e.Item.MouseClick -= new EventHandler<DuiMouseEventArgs>(this.method_8);
            this.duiBaseControl_1.Controls.Remove(e.Item);
            if (this.dskinDynamicListBoxItem_0 == e.Item)
            {
                this.dskinDynamicListBoxItem_0 = null;
            }
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_8(object sender, DuiMouseEventArgs e)
        {
            DSkinDynamicListBoxItem control = sender as DSkinDynamicListBoxItem;
            this.OnItemClick(new ItemClickEventArgs(this.Items.IndexOf(control), control, e.Button, e.Clicks, e.X, e.Y, e.Delta));
        }

        private void method_9()
        {
            int num;
            DSkinDynamicListBoxItem item;
            if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                int num2 = base.Width - ((!this.VerticalScrollBar.Visible || this.bool_0) ? 0 : this.VerticalScrollBar.Width);
                int num3 = 0;
                for (num = 0; num < this.Items.Count; num++)
                {
                    item = this.Items[num];
                    item.SuspendInvalidate = true;
                    item.Width = num2 - item.Margin.Horizontal;
                    item.Location = new Point(item.Margin.Left, this.OffsetTop + this.GetHeight(item.NewTabPageIndex));
                    item.SuspendInvalidate = false;
                    num3 += item.Height;
                }
            }
            else if (this.Orientation == System.Windows.Forms.Orientation.Horizontal)
            {
                int num4 = base.Height - ((!this.HorizontalScrollBar.Visible || this.bool_0) ? 0 : this.HorizontalScrollBar.Height);
                int num5 = 0;
                for (num = 0; num < this.Items.Count; num++)
                {
                    item = this.Items[num];
                    item.SuspendInvalidate = true;
                    item.Height = num4 - item.Margin.Vertical;
                    item.Location = new Point(this.OffsetLeft + this.GetWidth(item.NewTabPageIndex), item.Margin.Top);
                    item.SuspendInvalidate = false;
                    num5 += item.Width;
                }
            }
            this.SetScrollBarInfo();
            base.Invalidate();
        }

        protected virtual void OnItemClick(ItemClickEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        public void RemoveItem(DSkinDynamicListBoxItem item)
        {
            if (this.TabControl != null)
            {
                this.TabControl.TabPages.RemoveAt(this.GetPageIndex(item));
            }
            if (this.SelectedItem == item)
            {
                this.SelectedItem = null;
            }
            item.Visible = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].NewTabPageIndex > item.NewTabPageIndex)
                {
                    if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
                    {
                        this.Items[i].MoveToPoint = this.Items[i].Top - item.Height;
                        if (action_0 == null)
                        {
                            action_0 = new Action<bool>(GControl0.smethod_0);
                        }
                        this.Items[i].DoEffect<DSkinDynamicListBoxItem>(this.Items[i].Top, this.Items[i].MoveToPoint, 120, "Top", action_0);
                    }
                    else if (this.Orientation == System.Windows.Forms.Orientation.Horizontal)
                    {
                        this.Items[i].MoveToPoint = this.Items[i].Left - item.Width;
                        if (aauvYdrmn1 == null)
                        {
                            aauvYdrmn1 = new Action<bool>(GControl0.smethod_1);
                        }
                        this.Items[i].DoEffect<DSkinDynamicListBoxItem>(this.Items[i].Left, this.Items[i].MoveToPoint, 120, "Left", aauvYdrmn1);
                    }
                    DSkinDynamicListBoxItem local1 = this.Items[i];
                    local1.NewTabPageIndex--;
                }
                this.Items[i].ChangedMove = true;
            }
            this.Items.Remove(item);
            this.SetScrollBarInfo();
        }

        public void SetScrollBarInfo()
        {
            int num3;
            int height = this.GetHeight(this.Items.Count);
            int width = this.GetWidth(this.Items.Count);
            if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
            {
                this.VerticalScrollBar.Maximum = height - base.Height;
                this.VerticalScrollBar.Minimum = 0;
                num3 = ((int) (((1.0 * base.Height) / (1.0 * height)) * this.VerticalScrollBar.Height)) - (this.VerticalScrollBar.ArrowHeight * 2);
                this.VerticalScrollBar.ScrollBarLenght = (num3 < 15) ? 15 : num3;
                width = 0;
            }
            else if (this.Orientation == System.Windows.Forms.Orientation.Horizontal)
            {
                this.HorizontalScrollBar.Maximum = width - base.Width;
                this.HorizontalScrollBar.Minimum = 0;
                num3 = ((int) (((1.0 * base.Width) / (1.0 * width)) * this.HorizontalScrollBar.Width)) - (this.HorizontalScrollBar.ArrowHeight * 2);
                this.HorizontalScrollBar.ScrollBarLenght = (num3 < 15) ? 15 : num3;
                height = 0;
            }
            this.VerticalScrollBar.Visible = height > base.Height;
            this.HorizontalScrollBar.Visible = width > base.Width;
        }

        public void SetTabControlSelectedIndex(DSkinDynamicListBoxItem item)
        {
            if (!base.DesignMode && (this.TabControl != null))
            {
                int pageIndex = this.GetPageIndex(item);
                if ((pageIndex >= -1) && (pageIndex < this.TabControl.TabPages.Count))
                {
                    this.TabControl.SelectedIndex = pageIndex;
                }
            }
        }

        [CompilerGenerated]
        private static void smethod_0(bool bool_1)
        {
        }

        [CompilerGenerated]
        private static void smethod_1(bool bool_1)
        {
        }

        [CompilerGenerated]
        private static void smethod_2(bool bool_1)
        {
        }

        [CompilerGenerated]
        private static void smethod_3(bool bool_1)
        {
        }

        [CompilerGenerated]
        private static void smethod_4(bool bool_1)
        {
        }

        [CompilerGenerated]
        private static void smethod_5(bool bool_1)
        {
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return base.DuiControlCollection_0;
            }
        }

        [Description("内部横向滚动条")]
        public DuiScrollBar HorizontalScrollBar
        {
            get
            {
                EventHandler handler = null;
                EventHandler handler2 = null;
                if (this.duiScrollBar_1 == null)
                {
                    this.duiScrollBar_1 = new DuiScrollBar();
                    this.duiScrollBar_1.Fillet = true;
                    this.duiScrollBar_1.MouseEventBubble = true;
                    this.duiScrollBar_1.Orientation = System.Windows.Forms.Orientation.Horizontal;
                    this.duiScrollBar_1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                    this.duiScrollBar_1.Width = base.Width;
                    this.duiScrollBar_1.Height = 0x10;
                    this.duiScrollBar_1.Location = new Point(0, base.Height - this.duiScrollBar_1.Height);
                    this.duiScrollBar_1.BackColor = Color.Transparent;
                    this.duiScrollBar_1.ShowArrow = false;
                    this.duiScrollBar_1.Visible = false;
                    this.duiScrollBar_1.ScrollBarNormalColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
                    this.duiScrollBar_1.ScrollBarHoverColor = Color.FromArgb(180, 0xff, 0xff, 0xff);
                    this.duiScrollBar_1.ScrollBarPressColor = Color.FromArgb(150, 0xff, 0xff, 0xff);
                    if (handler == null)
                    {
                        handler = new EventHandler(this.method_15);
                    }
                    this.duiScrollBar_1.VisibleChanged += handler;
                    if (handler2 == null)
                    {
                        handler2 = new EventHandler(this.method_16);
                    }
                    this.duiScrollBar_1.ValueChanged += handler2;
                }
                return this.duiScrollBar_1;
            }
        }

        [DefaultValue(true), Description("滚动条是否可以盖住内容")]
        public bool IsScrollBarCoverContent
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin"), Description("标签项集合")]
        public Collection<DSkinDynamicListBoxItem> Items
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DSkinDynamicListBoxItem>();
                    this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinDynamicListBoxItem>>(this.method_6);
                    this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinDynamicListBoxItem>>(this.method_7);
                }
                return this.collection_0;
            }
        }

        [DefaultValue(0), Description("移动滚动条左侧偏移值")]
        public int OffsetLeft
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
                    base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
                }
            }
        }

        [Description("移动滚动条顶部偏移值"), DefaultValue(0)]
        public int OffsetTop
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
                    base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
                }
            }
        }

        [DefaultValue(1), Description("布局方向")]
        public System.Windows.Forms.Orientation Orientation
        {
            get
            {
                return this.orientation_0;
            }
            set
            {
                int num;
                this.orientation_0 = value;
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        this.Items[num].Width = base.Width;
                    }
                }
                else if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        this.Items[num].Width = 100;
                    }
                }
                base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
        }

        [Category("DSkin"), Description("滚轮每格滚动的像素值"), DefaultValue(20)]
        public int RollSize
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

        [Description("当前选中的标签")]
        public DSkinDynamicListBoxItem SelectedItem
        {
            get
            {
                return this.dskinDynamicListBoxItem_0;
            }
            set
            {
                if (value != this.dskinDynamicListBoxItem_0)
                {
                    this.method_10(value);
                }
                this.dskinDynamicListBoxItem_0 = value;
                if (this.dskinDynamicListBoxItem_0 != null)
                {
                    this.dskinDynamicListBoxItem_0.BringToFront();
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i] != this.dskinDynamicListBoxItem_0)
                        {
                            this.Items[i].IsSelected = false;
                        }
                    }
                    this.SetTabControlSelectedIndex(this.dskinDynamicListBoxItem_0);
                }
            }
        }

        [Description("绑定的DSkinTabControl控件")]
        public DSkinTabControl TabControl
        {
            get
            {
                return this.dskinTabControl_0;
            }
            set
            {
                this.dskinTabControl_0 = value;
            }
        }

        [Description("内部纵向滚动条")]
        public DuiScrollBar VerticalScrollBar
        {
            get
            {
                EventHandler handler = null;
                EventHandler handler2 = null;
                if ((this.duiScrollBar_0 == null) || this.duiScrollBar_0.IsDisposed)
                {
                    this.duiScrollBar_0 = new DuiScrollBar();
                    this.duiScrollBar_0.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
                    this.duiScrollBar_0.Height = base.Height;
                    this.duiScrollBar_0.Width = 0x10;
                    this.duiScrollBar_0.Location = new Point(base.Width - this.duiScrollBar_0.Width, 0);
                    this.duiScrollBar_0.Fillet = true;
                    this.duiScrollBar_0.MouseEventBubble = true;
                    this.duiScrollBar_0.BackColor = Color.Transparent;
                    this.duiScrollBar_0.ShowArrow = false;
                    this.duiScrollBar_0.Visible = false;
                    this.duiScrollBar_0.Orientation = System.Windows.Forms.Orientation.Vertical;
                    this.duiScrollBar_0.ScrollBarNormalColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
                    this.duiScrollBar_0.ScrollBarHoverColor = Color.FromArgb(180, 0xff, 0xff, 0xff);
                    this.duiScrollBar_0.ScrollBarPressColor = Color.FromArgb(150, 0xff, 0xff, 0xff);
                    if (handler == null)
                    {
                        handler = new EventHandler(this.method_13);
                    }
                    this.duiScrollBar_0.VisibleChanged += handler;
                    if (handler2 == null)
                    {
                        handler2 = new EventHandler(this.method_14);
                    }
                    this.duiScrollBar_0.ValueChanged += handler2;
                }
                return this.duiScrollBar_0;
            }
        }
    }
}

