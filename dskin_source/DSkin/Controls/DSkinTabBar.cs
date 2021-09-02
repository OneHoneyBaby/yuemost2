namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Threading;
    using System.Windows.Forms;

    [Description("可以关联TabControl，实现选项卡切换"), Designer("DSkin.Design.DSkinTabBarDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null")]
    public class DSkinTabBar : DSkinBaseControl
    {
        private bool bool_0 = true;
        private bool bool_1 = false;
        private Collection<DuiBaseControl> collection_0;
        private int int_0 = 0;
        private int int_1 = 0;
        private int int_2 = 0;
        private System.Windows.Forms.Orientation orientation_0 = System.Windows.Forms.Orientation.Horizontal;
        private System.Windows.Forms.TabControl tabControl_0;

        public event EventHandler<GEventArgs0> TabControlSelectedIndexChanged;

        public DSkinTabBar()
        {
            base.InnerDuiControl.ControlAdded += new EventHandler<DuiControlEventArgs>(this.method_10);
            base.InnerDuiControl.ControlRemoved += new EventHandler<DuiControlEventArgs>(this.method_6);
        }

        private void DpuWueAtOn(object sender, DuiMouseEventArgs e)
        {
            DSkinTabItem it = sender as DSkinTabItem;
            this.SetSelect(it);
        }

        public void LayoutContent()
        {
            if (this.bool_0)
            {
                int num;
                this.int_1 = 0;
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    int num3 = this.int_2;
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        if (this.Items[num].Visible)
                        {
                            this.Items[num].Location = new Point(num3 + this.Items[num].Margin.Left, this.Items[num].Margin.Top);
                            num3 += this.Items[num].Width + this.Items[num].Margin.Horizontal;
                            this.int_1 += this.Items[num].Width + this.Items[num].Margin.Horizontal;
                        }
                    }
                }
                else
                {
                    int num2 = this.int_2;
                    for (num = 0; num < this.Items.Count; num++)
                    {
                        if (this.Items[num].Visible)
                        {
                            this.Items[num].Location = new Point(this.Items[num].Margin.Left, num2 + this.Items[num].Margin.Top);
                            num2 += this.Items[num].Height + this.Items[num].Margin.Vertical;
                            this.int_1 += this.Items[num].Height + this.Items[num].Margin.Vertical;
                        }
                    }
                }
                if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
                {
                    if (this.int_1 < base.Width)
                    {
                        this.ListTop = 0;
                    }
                    else if ((base.Width - this.int_2) > this.int_1)
                    {
                        this.ListTop = base.Width - this.int_1;
                    }
                }
                else if (this.int_1 < base.Height)
                {
                    this.ListTop = 0;
                }
                else if ((base.Height - this.int_2) > this.int_1)
                {
                    this.ListTop = base.Height - this.int_1;
                }
                this.method_12();
            }
        }

        private void method_10(object sender, DuiControlEventArgs e)
        {
            e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            e.Control.Dock = DockStyle.None;
            e.Control.MouseDown += new EventHandler<DuiMouseEventArgs>(this.DpuWueAtOn);
            e.Control.MarginChanged += new EventHandler(this.method_11);
            e.Control.SizeChanged += new EventHandler(this.method_11);
            DSkinTabItem control = e.Control as DSkinTabItem;
            if (control != null)
            {
                control.DSkinTabBar_0 = this;
            }
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_11(object sender, EventArgs e)
        {
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_12()
        {
            if (this.tabControl_0 != null)
            {
                int selectedIndex = this.tabControl_0.SelectedIndex;
                int num2 = 0;
                int num3 = 0;
                DSkinTabItem item = null;
                foreach (DuiBaseControl control in this.Items)
                {
                    DSkinTabItem item2 = control as DSkinTabItem;
                    if (item2 != null)
                    {
                        if (!(((item2.TabPage != null) || (num2 != selectedIndex)) ? ((item2.TabPage == null) || (item2.TabPage != this.tabControl_0.SelectedTab)) : false))
                        {
                            this.int_0 = num3;
                            item2.Selected = true;
                            item = item2;
                        }
                        else
                        {
                            item2.Selected = false;
                        }
                        num2++;
                    }
                    num3++;
                }
                if (item != null)
                {
                    this.OnTabControlSelectedIndexChanged(new GEventArgs0(item));
                }
            }
        }

        private void method_6(object sender, DuiControlEventArgs e)
        {
            DSkinTabItem control = e.Control as DSkinTabItem;
            if (control != null)
            {
                control.DSkinTabBar_0 = null;
            }
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_7(object sender, CollectionEventArgs<DuiBaseControl> e)
        {
            this.DuiControlCollection_0.Remove(e.Item);
        }

        private void method_8(object sender, CollectionEventArgs<DuiBaseControl> e)
        {
            this.DuiControlCollection_0.Add(e.Item);
        }

        private void method_9(int int_3)
        {
            if (this.Items.Count > 0)
            {
                if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                {
                    if (this.int_1 > base.Height)
                    {
                        if ((this.ListTop + int_3) > 0)
                        {
                            this.ListTop = 0;
                        }
                        else if ((this.int_2 + int_3) < (base.Height - this.int_1))
                        {
                            this.ListTop = base.Height - this.int_1;
                        }
                        else
                        {
                            this.ListTop += int_3;
                        }
                    }
                    else
                    {
                        this.ListTop = 0;
                    }
                }
                else if (this.int_1 > base.Width)
                {
                    if ((this.int_2 + int_3) > 0)
                    {
                        this.ListTop = 0;
                    }
                    else if ((this.int_2 + int_3) < (base.Width - this.int_1))
                    {
                        this.ListTop = base.Width - this.int_1;
                    }
                    else
                    {
                        this.ListTop += int_3;
                    }
                }
                else
                {
                    this.ListTop = 0;
                }
            }
            else
            {
                base.Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.bool_1)
            {
                base.Focus();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.Focus();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int num = 20;
            if (e.Delta > 0)
            {
                this.method_9(num);
            }
            else
            {
                this.method_9(-num);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.orientation_0 == System.Windows.Forms.Orientation.Horizontal)
            {
                if (this.int_1 < base.Width)
                {
                    this.ListTop = 0;
                }
                else if ((base.Width - this.int_2) > this.int_1)
                {
                    this.ListTop = base.Width - this.int_1;
                }
            }
            else if (this.int_1 < base.Height)
            {
                this.ListTop = 0;
            }
            else if ((base.Height - this.int_2) > this.int_1)
            {
                this.ListTop = base.Height - this.int_1;
            }
        }

        protected virtual void OnTabControlSelectedIndexChanged(GEventArgs0 e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        public void SetSelect(DSkinTabItem it)
        {
            if (((it != null) && (it.TabPage != null)) && (this.tabControl_0 != null))
            {
                this.tabControl_0.SelectedTab = it.TabPage;
            }
            else
            {
                int num = 0;
                foreach (DuiBaseControl control in this.Items)
                {
                    DSkinTabItem item = control as DSkinTabItem;
                    if (item != null)
                    {
                        if ((item == it) && (this.tabControl_0 != null))
                        {
                            this.tabControl_0.SelectedIndex = num;
                        }
                        num++;
                    }
                }
            }
        }

        private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.method_12();
        }

        [Category("DSkinTabBar"), DefaultValue(false), Description("鼠标移入自动获取焦点")]
        public bool AutoFoucs
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

        [Browsable(false)]
        public int ContentLength
        {
            get
            {
                return this.int_1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return base.DuiControlCollection_0;
            }
        }

        [Browsable(false)]
        public bool EnabledLayoutContent
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor("DSkin.Design.DSkinTabItemCollectionEditor,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null", typeof(UITypeEditor)), Category("DSkinTabBar"), Description("项目集合，只有DSkinTabItem才会与TabControl内部的TabPage关联")]
        public Collection<DuiBaseControl> Items
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DuiBaseControl>();
                    this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DuiBaseControl>>(this.method_8);
                    this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DuiBaseControl>>(this.method_7);
                }
                return this.collection_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                        if (this.int_1 < base.Width)
                        {
                            this.int_2 = 0;
                        }
                        else if (this.int_2 < (base.Width - this.int_1))
                        {
                            this.int_2 = base.Width - this.int_1;
                        }
                    }
                    else if (this.int_1 < base.Height)
                    {
                        this.int_2 = 0;
                    }
                    else if (this.int_2 < (base.Height - this.int_1))
                    {
                        this.int_2 = base.Height - this.int_1;
                    }
                    this.LayoutContent();
                }
            }
        }

        [Description("方向"), Category("DSkinTabBar")]
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
                    this.LayoutContent();
                    base.Size = new Size(base.Height, base.Width);
                }
            }
        }

        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return this.int_0;
            }
        }

        [DefaultValue((string) null), Description("关联的TabControl"), Category("DSkinTabBar")]
        public System.Windows.Forms.TabControl TabControl
        {
            get
            {
                return this.tabControl_0;
            }
            set
            {
                if (this.tabControl_0 != value)
                {
                    if (this.tabControl_0 != null)
                    {
                        this.tabControl_0.SelectedIndexChanged -= new EventHandler(this.tabControl_0_SelectedIndexChanged);
                    }
                    this.tabControl_0 = value;
                    if (this.tabControl_0 != null)
                    {
                        this.tabControl_0.SelectedIndexChanged += new EventHandler(this.tabControl_0_SelectedIndexChanged);
                        this.method_12();
                    }
                }
            }
        }

        [Category("DSkin"), Description("滚动的百分比（0-1）"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Value
        {
            get
            {
                if (this.Items.Count > 0)
                {
                    if (this.orientation_0 == System.Windows.Forms.Orientation.Vertical)
                    {
                        if (this.int_1 > base.Height)
                        {
                            return (((double) -this.int_2) / ((double) (this.int_1 - base.Height)));
                        }
                    }
                    else if (this.int_1 > base.Width)
                    {
                        return (((double) -this.int_2) / ((double) (this.int_1 - base.Width)));
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
                            if (this.int_1 > base.Height)
                            {
                                this.ListTop = (int) (-(this.int_1 - base.Height) * num);
                            }
                            else
                            {
                                this.ListTop = 0;
                            }
                        }
                        else if (this.int_1 > base.Width)
                        {
                            this.ListTop = (int) (-(this.int_1 - base.Width) * num);
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

