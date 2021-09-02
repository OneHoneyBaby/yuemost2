namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(TreeView)), Designer("DSkin.Design.DSkinTreeViewDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null")]
    public class DSkinTreeView : DSkinBaseControl, ISupportInitialize, ITreeViewNode
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private bool bool_4;
        private Collection<DSkinTreeViewNode> collection_0;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private Color color_3;
        private Color color_4;
        private DSkinTreeViewNode dskinTreeViewNode_0;
        private DSkinTreeViewNode dskinTreeViewNode_1;
        private DuiListBox duiListBox_0 = new DuiListBox();
        private DuiScrollBar duiScrollBar_0;
        private Image image_0;
        private Image image_1;
        private Image image_10;
        private Image image_11;
        private Image image_12;
        private Image image_13;
        private Image image_14;
        private Image image_15;
        private Image image_2;
        private Image image_3;
        private Image image_4;
        private Image image_5;
        private Image image_6;
        private Image image_7;
        private Image image_8;
        private Image image_9;
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private Size size_0;
        private TextRenderingHint textRenderingHint_0;

        [Description("拖拽节点结束之后发生")]
        public event EventHandler<DSkinTreeViewDragEndedEventArgs> DragEnded;

        [Description("开始拖拽节点时发生")]
        public event EventHandler<DSkinTreeViewEventArgs> DragStarted;

        public event EventHandler<DSkinTreeViewEventArgs> ItemCreated;

        public event EventHandler<DSkinTreeViewEventArgs> NodeCheckStateChanged;

        public event EventHandler<DSkinTreeViewNodeClickEventArgs> NodeClick;

        public event EventHandler SelectedNodeChanged;

        public DSkinTreeView()
        {
            DuiScrollBar bar = new DuiScrollBar {
                Orientation = Orientation.Horizontal,
                Visible = false,
                Height = 12
            };
            this.duiScrollBar_0 = bar;
            this.bool_0 = false;
            this.int_0 = 0;
            this.bool_1 = false;
            this.int_1 = 0;
            this.int_2 = 0;
            this.bool_2 = true;
            this.bool_3 = true;
            this.size_0 = new Size(20, 20);
            this.textRenderingHint_0 = TextRenderingHint.SystemDefault;
            this.int_3 = 20;
            this.image_0 = null;
            this.image_1 = null;
            this.image_2 = null;
            this.image_3 = null;
            this.image_4 = null;
            this.image_5 = null;
            this.image_6 = null;
            this.color_0 = Color.FromArgb(0xe5, 0xf3, 0xfb);
            this.color_1 = Color.FromArgb(0x26, 160, 0xda);
            this.color_2 = Color.FromArgb(0xcb, 0xe8, 0xff);
            this.color_3 = Color.FromArgb(0x26, 160, 0xda);
            this.color_4 = Color.FromArgb(0xe5, 0xf3, 0xfb);
            this.bool_4 = false;
            base.InnerDuiControl.Controls.Add(this.duiListBox_0);
            this.duiListBox_0.ClientRectangle = new Rectangle(0, 0, base.Width, base.Height);
            this.duiListBox_0.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.duiListBox_0.InnerScrollBar.Margin = new Padding(1);
            this.duiListBox_0.ItemAdded += new EventHandler<DuiControlEventArgs>(this.method_8);
            this.duiListBox_0.ItemRemoved += new EventHandler<DuiControlEventArgs>(this.method_7);
            this.duiListBox_0.LayoutContented += new EventHandler(this.rAoizcevjc);
            this.duiListBox_0.Paint += new EventHandler<PaintEventArgs>(this.method_6);
            this.duiScrollBar_0.Margin = new Padding(this.duiScrollBar_0.Margin.Left, this.duiScrollBar_0.Margin.Top, this.duiListBox_0.InnerScrollBar.Margin.Right + this.duiListBox_0.InnerScrollBar.Width, this.duiScrollBar_0.Margin.Bottom);
            this.duiScrollBar_0.Dock = DockStyle.Bottom;
            this.duiScrollBar_0.VisibleChanged += new EventHandler(this.duiScrollBar_0_VisibleChanged);
            base.InnerDuiControl.Controls.Add(this.duiScrollBar_0);
            this.duiScrollBar_0.ValueChanged += new EventHandler(this.duiScrollBar_0_ValueChanged);
            this.Nodes.ItemAdded += new EventHandler<CollectionEventArgs<DSkinTreeViewNode>>(this.method_14);
            this.Nodes.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinTreeViewNode>>(this.method_13);
        }

        public void BeginInit()
        {
        }

        public void CollapseAll()
        {
            foreach (DSkinTreeViewNode node in this.Nodes)
            {
                node.NodesOpened = false;
            }
        }

        private void duiScrollBar_0_ValueChanged(object sender, EventArgs e)
        {
            this.HorizontalScrollValue = -this.duiScrollBar_0.Value;
        }

        private void duiScrollBar_0_VisibleChanged(object sender, EventArgs e)
        {
            this.duiListBox_0.Height = this.duiScrollBar_0.Visible ? ((base.Height - this.duiScrollBar_0.Height) - this.duiScrollBar_0.Margin.Bottom) : base.Height;
        }

        public void EndInit()
        {
            foreach (DSkinTreeViewNode node in this.Nodes)
            {
                node.IsFirstLoad = true;
                this.method_16(node);
            }
            this.duiListBox_0.LayoutContent();
        }

        public void ExpandAll()
        {
            foreach (DSkinTreeViewNode node in this.Nodes)
            {
                this.method_18(node);
            }
        }

        public void LayoutContent()
        {
            this.duiListBox_0.LayoutContent();
        }

        private void method_10(object sender, DuiMouseEventArgs e)
        {
            DSkinTreeViewNode tag = (DSkinTreeViewNode) ((DuiBaseControl) sender).Tag;
            if (tag.CanSelect)
            {
                this.SelectedNode = tag;
            }
            this.int_0 = Cursor.Position.Y;
            this.bool_1 = false;
        }

        private void method_11(object sender, DuiMouseEventArgs e)
        {
            this.int_1 = Cursor.Position.Y;
            if ((Math.Abs((int) (this.int_1 - this.int_0)) > 5) && (((e.Button == MouseButtons.Left) && !this.bool_1) && this.bool_4))
            {
                Bitmap canvas = ((DuiBaseControl) sender).Canvas;
                Bitmap image = new Bitmap(canvas.Width * 2, canvas.Height * 2);
                Graphics.FromImage(image).DrawImage(canvas, canvas.Width, canvas.Height);
                Cursor cursor = new Cursor(image.GetHicon());
                Cursor.Current = cursor;
                this.bool_1 = true;
                this.OnDragStarted(new DSkinTreeViewEventArgs(this.dskinTreeViewNode_1));
            }
        }

        private bool method_12(DSkinTreeViewNode dskinTreeViewNode_2, DSkinTreeViewNode dskinTreeViewNode_3)
        {
            foreach (DSkinTreeViewNode node in dskinTreeViewNode_2.Nodes)
            {
                if ((node == dskinTreeViewNode_3) || this.method_12(node, dskinTreeViewNode_3))
                {
                    return true;
                }
            }
            return false;
        }

        private void method_13(object sender, CollectionEventArgs<DSkinTreeViewNode> e)
        {
            e.Item.NodesOpenOrClose -= new EventHandler(this.PwhIeRbgeu);
            e.Item.ParentNode = null;
            e.Item.DestroyItem();
            this.duiListBox_0.Items.Remove(e.Item.Item);
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_14(object sender, CollectionEventArgs<DSkinTreeViewNode> e)
        {
            DSkinTreeViewNode item = e.Item;
            item.ParentNode = this;
            item.NodesOpenOrClose += new EventHandler(this.PwhIeRbgeu);
            this.method_16(item);
            this.duiListBox_0.Items.Insert(e.Index, e.Item.Item);
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void method_15(object sender, EventArgs e)
        {
            this.OnNodeCheckStateChanged(new DSkinTreeViewEventArgs((DSkinTreeViewNode) sender));
        }

        private void method_16(DSkinTreeViewNode dskinTreeViewNode_2)
        {
            if (dskinTreeViewNode_2.IsFirstLoad)
            {
                if (!dskinTreeViewNode_2.IsCustom)
                {
                    dskinTreeViewNode_2.ShowCheckBox = this.bool_2;
                    dskinTreeViewNode_2.ShowIcon = this.bool_3;
                    dskinTreeViewNode_2.Font = this.Font;
                    dskinTreeViewNode_2.ForeColor = this.ForeColor;
                    dskinTreeViewNode_2.TextRenderMode = this.textRenderingHint_0;
                    dskinTreeViewNode_2.IconSize = this.size_0;
                    dskinTreeViewNode_2.OpenNormal = this.image_1;
                    dskinTreeViewNode_2.OpenHover = this.image_2;
                    dskinTreeViewNode_2.OpenPressed = this.image_3;
                    dskinTreeViewNode_2.CloseNormal = this.image_4;
                    dskinTreeViewNode_2.CloseHover = this.image_5;
                    dskinTreeViewNode_2.ClosePressed = this.image_6;
                    dskinTreeViewNode_2.ItemBackColorHover = this.color_0;
                    dskinTreeViewNode_2.ItemBorderColorHover = this.color_1;
                    dskinTreeViewNode_2.CheckBoxCheckedHover = this.image_11;
                    dskinTreeViewNode_2.CheckBoxCheckedNormal = this.image_10;
                    dskinTreeViewNode_2.CheckBoxCheckedPressed = this.image_12;
                    dskinTreeViewNode_2.CheckBoxIndeterminateHover = this.image_14;
                    dskinTreeViewNode_2.CheckBoxIndeterminateNormal = this.image_13;
                    dskinTreeViewNode_2.CheckBoxIndeterminatePressed = this.image_15;
                    dskinTreeViewNode_2.CheckBoxUncheckedHover = this.image_8;
                    dskinTreeViewNode_2.CheckBoxUncheckedNormal = this.image_7;
                    dskinTreeViewNode_2.CheckBoxUncheckedPressed = this.image_9;
                    if (this.image_0 != null)
                    {
                        dskinTreeViewNode_2.Icon = this.image_0;
                    }
                }
                dskinTreeViewNode_2.CheckStateChanged -= new EventHandler(this.method_15);
                dskinTreeViewNode_2.CheckStateChanged += new EventHandler(this.method_15);
                dskinTreeViewNode_2.IsFirstLoad = false;
            }
        }

        private void method_17(object sender, EventArgs e)
        {
            this.OnItemCreated(new DSkinTreeViewEventArgs((DSkinTreeViewNode) sender));
        }

        private void method_18(DSkinTreeViewNode dskinTreeViewNode_2)
        {
            if (dskinTreeViewNode_2.Nodes.Count > 0)
            {
                dskinTreeViewNode_2.NodesOpened = true;
                foreach (DSkinTreeViewNode node in dskinTreeViewNode_2.Nodes)
                {
                    this.method_18(node);
                }
            }
        }

        private void method_19(DSkinTreeViewNode dskinTreeViewNode_2)
        {
            DSkinTreeViewNode parentNode = dskinTreeViewNode_2.ParentNode as DSkinTreeViewNode;
            if (parentNode != null)
            {
                this.method_19(parentNode);
                parentNode.NodesOpened = true;
            }
        }

        private IEnumerable<DSkinTreeViewNode> method_20(ITreeViewNode itreeViewNode_0)
        {
            IEnumerator enumerator = itreeViewNode_0.Nodes.GetEnumerator();
        Label_0090:
            if (enumerator.MoveNext())
            {
            }
            DSkinTreeViewNode current = (DSkinTreeViewNode) enumerator.Current;
            yield return current;
            IEnumerator<DSkinTreeViewNode> iteratorVariable4 = this.method_20(current).GetEnumerator();
        Label_PostSwitchInIterator:;
            if (iteratorVariable4.MoveNext())
            {
                DSkinTreeViewNode iteratorVariable1 = iteratorVariable4.Current;
                yield return iteratorVariable1;
                goto Label_PostSwitchInIterator;
            }
            goto Label_0090;
        }

        [CompilerGenerated]
        private void method_21()
        {
            int num2 = this.duiListBox_0.InnerScrollBar.Visible ? ((base.Width - this.duiListBox_0.InnerScrollBar.Width) - this.duiListBox_0.InnerScrollBar.Margin.Right) : base.Width;
            int num3 = num2;
            foreach (DuiBaseControl control in this.duiListBox_0.Items)
            {
                if (control.Visible)
                {
                    int num4 = 0;
                    foreach (DuiBaseControl control2 in control.Controls)
                    {
                        int num5 = control2.Width + control2.Left;
                        num4 = (num4 > num5) ? num4 : num5;
                    }
                    num4 -= this.int_2;
                    num2 = (num2 > num4) ? num2 : num4;
                }
            }
            if (num2 > num3)
            {
                this.duiScrollBar_0.Maximum = num2 - num3;
                int num = (int) ((this.duiScrollBar_0.Width - (this.duiScrollBar_0.ArrowHeight * 2)) * ((1.0 * num3) / ((double) num2)));
                if (num < 20)
                {
                    num = 20;
                }
                this.duiScrollBar_0.ScrollBarLenght = num;
                this.duiScrollBar_0.Visible = true;
            }
            else
            {
                this.duiScrollBar_0.Value = 0;
                this.duiScrollBar_0.Visible = false;
            }
        }

        private void method_6(object sender, PaintEventArgs e)
        {
            MethodInvoker method = null;
            if (this.bool_0)
            {
                if (method == null)
                {
                    method = new MethodInvoker(this.method_21);
                }
                base.BeginInvoke(method);
            }
            this.bool_0 = false;
        }

        private void method_7(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseClick -= new EventHandler<DuiMouseEventArgs>(this.method_9);
            e.Control.MouseMove -= new EventHandler<DuiMouseEventArgs>(this.method_11);
            e.Control.MouseDown -= new EventHandler<DuiMouseEventArgs>(this.method_10);
        }

        private void method_8(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseClick += new EventHandler<DuiMouseEventArgs>(this.method_9);
            e.Control.MouseMove += new EventHandler<DuiMouseEventArgs>(this.method_11);
            e.Control.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_10);
        }

        private void method_9(object sender, DuiMouseEventArgs e)
        {
            this.OnNodeClick(new DSkinTreeViewNodeClickEventArgs((DSkinTreeViewNode) ((DuiBaseControl) sender).Tag, e));
        }

        protected virtual void OnDragEnded(DSkinTreeViewDragEndedEventArgs e)
        {
            if (this.eventHandler_7 != null)
            {
                this.eventHandler_7(this, e);
            }
        }

        protected virtual void OnDragStarted(DSkinTreeViewEventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected virtual void OnItemCreated(DSkinTreeViewEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!(((this.dskinTreeViewNode_1 != null) && (e.Button == MouseButtons.Left)) && this.bool_4))
            {
                this.dskinTreeViewNode_0 = null;
            }
            else
            {
                Point location = e.Location;
                location.Offset(-this.duiListBox_0.Controls[0].Left, -this.duiListBox_0.Controls[0].Top);
                foreach (DuiBaseControl control in this.duiListBox_0.Controls[0].VisibleControls)
                {
                    if (control.ClientRectangle.Contains(location))
                    {
                        this.dskinTreeViewNode_0 = (DSkinTreeViewNode) control.Tag;
                        if (control != this.dskinTreeViewNode_1.Item)
                        {
                            control.BackColor = this.color_4;
                        }
                    }
                    else if (control != this.dskinTreeViewNode_1.Item)
                    {
                        control.BackColor = Color.Transparent;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if ((((this.bool_1 && (this.dskinTreeViewNode_0 != null)) && ((this.dskinTreeViewNode_1 != null) && (this.dskinTreeViewNode_1 != this.dskinTreeViewNode_0))) && !this.method_12(this.dskinTreeViewNode_1, this.dskinTreeViewNode_0)) && (this.dskinTreeViewNode_1.ParentNode != this.dskinTreeViewNode_0))
            {
                this.dskinTreeViewNode_1.ParentNode.Nodes.Remove(this.dskinTreeViewNode_1);
                this.dskinTreeViewNode_0.Nodes.Add(this.dskinTreeViewNode_1);
                this.OnDragEnded(new DSkinTreeViewDragEndedEventArgs(this.dskinTreeViewNode_1, this.dskinTreeViewNode_0));
                this.dskinTreeViewNode_0 = null;
                this.LayoutContent();
            }
            this.bool_1 = false;
        }

        protected virtual void OnNodeCheckStateChanged(DSkinTreeViewEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnNodeClick(DSkinTreeViewNodeClickEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnSelectedNodeChanged(EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        private void PwhIeRbgeu(object sender, EventArgs e)
        {
            DSkinTreeViewNode node = sender as DSkinTreeViewNode;
            int index = this.duiListBox_0.Items.IndexOf(node.Item);
            if ((!node.IsLoadNodes && node.NodesOpened) && (index > -1))
            {
                node.IsLoadNodes = true;
                foreach (DSkinTreeViewNode node2 in node.Nodes)
                {
                    node2.ItemCreated -= new EventHandler(this.method_17);
                    node2.ItemCreated += new EventHandler(this.method_17);
                    this.method_16(node2);
                    node2.Item.Visible = node.NodesOpened;
                    this.duiListBox_0.Items.Insert(++index, node2.Item);
                }
            }
            else
            {
                foreach (DSkinTreeViewNode node2 in node.Nodes)
                {
                    if (node.NodesOpened)
                    {
                        node2.Item.Visible = true;
                        this.method_16(node2);
                    }
                    else
                    {
                        node2.Item.Visible = false;
                    }
                }
            }
            base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
        }

        private void rAoizcevjc(object sender, EventArgs e)
        {
            this.bool_0 = true;
        }

        public IEnumerable<DSkinTreeViewNode> AllNodes
        {
            get
            {
                return this.method_20(this);
            }
        }

        [Description("选定时鼠标移入的图像"), DefaultValue((string) null)]
        public Image CheckBoxCheckedHover
        {
            get
            {
                return this.image_11;
            }
            set
            {
                if (this.image_11 != value)
                {
                    this.image_11 = value;
                }
            }
        }

        [DefaultValue((string) null), Description("选定时的图像")]
        public Image CheckBoxCheckedNormal
        {
            get
            {
                return this.image_10;
            }
            set
            {
                if (this.image_10 != value)
                {
                    this.image_10 = value;
                }
            }
        }

        [Description("选定时鼠标按下的图像"), DefaultValue((string) null)]
        public Image CheckBoxCheckedPressed
        {
            get
            {
                return this.image_12;
            }
            set
            {
                if (this.image_12 != value)
                {
                    this.image_12 = value;
                }
            }
        }

        [Description("半选定时鼠标移入的图像"), DefaultValue((string) null)]
        public Image CheckBoxIndeterminateHover
        {
            get
            {
                return this.image_14;
            }
            set
            {
                if (this.image_14 != value)
                {
                    this.image_14 = value;
                }
            }
        }

        [Description("半选定时的图像"), DefaultValue((string) null)]
        public Image CheckBoxIndeterminateNormal
        {
            get
            {
                return this.image_13;
            }
            set
            {
                if (this.image_13 != value)
                {
                    this.image_13 = value;
                }
            }
        }

        [DefaultValue((string) null), Description("半选定时鼠标按下的图像")]
        public Image CheckBoxIndeterminatePressed
        {
            get
            {
                return this.image_15;
            }
            set
            {
                if (this.image_15 != value)
                {
                    this.image_15 = value;
                }
            }
        }

        [Description("未选定时鼠标移入的图像"), DefaultValue((string) null)]
        public Image CheckBoxUncheckedHover
        {
            get
            {
                return this.image_8;
            }
            set
            {
                if (this.image_8 != value)
                {
                    this.image_8 = value;
                }
            }
        }

        [DefaultValue((string) null), Description("未选定时的图像")]
        public Image CheckBoxUncheckedNormal
        {
            get
            {
                return this.image_7;
            }
            set
            {
                if (this.image_7 != value)
                {
                    this.image_7 = value;
                }
            }
        }

        [Description("未选定时鼠标按下的图像"), DefaultValue((string) null)]
        public Image CheckBoxUncheckedPressed
        {
            get
            {
                return this.image_9;
            }
            set
            {
                if (this.image_9 != value)
                {
                    this.image_9 = value;
                }
            }
        }

        [Category("节点开关按钮"), DefaultValue((string) null), Description("关闭图标")]
        public Image CloseHover
        {
            get
            {
                return this.image_5;
            }
            set
            {
                this.image_5 = value;
            }
        }

        [DefaultValue((string) null), Description("关闭图标"), Category("节点开关按钮")]
        public Image CloseNormal
        {
            get
            {
                return this.image_4;
            }
            set
            {
                this.image_4 = value;
            }
        }

        [Description("关闭图标"), DefaultValue((string) null), Category("节点开关按钮")]
        public Image ClosePressed
        {
            get
            {
                return this.image_6;
            }
            set
            {
                this.image_6 = value;
            }
        }

        [Category("DSkin"), DefaultValue(typeof(Color), "229, 243, 251"), Description("鼠标拖拽进入的项目背景色")]
        public Color DragEnterItemBackColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
            }
        }

        [Description("启用鼠标拖拽"), DefaultValue(false), Category("DSkin")]
        public bool EnabledDrag
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiScrollBar HorizontalScrollBar
        {
            get
            {
                return this.duiScrollBar_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HorizontalScrollValue
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
                    base.Invalidate();
                }
            }
        }

        [Category("DSkin"), DefaultValue((string) null), Description("图标")]
        public Image Icon
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
            }
        }

        [Description("图标尺寸"), DefaultValue(typeof(Size), "20,20"), Category("DSkin")]
        public Size IconSize
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

        [Browsable(false)]
        public DuiListBox InnerListBox
        {
            get
            {
                return this.duiListBox_0;
            }
        }

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("内部滚动条")]
        public DuiScrollBar InnerScrollBar
        {
            get
            {
                return this.duiListBox_0.InnerScrollBar;
            }
        }

        [Description("项目鼠标移入背景色"), Category("DSkin"), DefaultValue(typeof(Color), "229, 243, 251")]
        public Color ItemBackColorHover
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

        [DefaultValue(typeof(Color), "38, 160, 218"), Category("DSkin"), Description("项目鼠标移入边框颜色")]
        public Color ItemBorderColorHover
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

        [DefaultValue(typeof(Color), "203, 232, 255"), Description("被选中的项目背景色"), Category("DSkin")]
        public Color ItemSelectedBackColor
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

        [Description("被选中的项目边框颜色"), Category("DSkin"), DefaultValue(typeof(Color), "38, 160, 218")]
        public Color ItemSelectedBorderColor
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

        [Description("子节点"), Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<DSkinTreeViewNode> Nodes
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DSkinTreeViewNode>();
                }
                return this.collection_0;
            }
        }

        [DefaultValue(20), Category("DSkin"), Description("打开关闭按钮的尺寸")]
        public int OpenCloseButtonWidth
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        [DefaultValue((string) null), Category("节点开关按钮"), Description("展开图标")]
        public Image OpenHover
        {
            get
            {
                return this.image_2;
            }
            set
            {
                this.image_2 = value;
            }
        }

        [DefaultValue((string) null), Category("节点开关按钮"), Description("展开图标")]
        public Image OpenNormal
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

        [DefaultValue((string) null), Category("节点开关按钮"), Description("展开图标")]
        public Image OpenPressed
        {
            get
            {
                return this.image_3;
            }
            set
            {
                this.image_3 = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DSkinTreeViewNode SelectedNode
        {
            get
            {
                return this.dskinTreeViewNode_1;
            }
            set
            {
                if (this.dskinTreeViewNode_1 != value)
                {
                    this.method_19(value);
                    if (this.dskinTreeViewNode_1 != null)
                    {
                        this.dskinTreeViewNode_1.Selected = false;
                        this.dskinTreeViewNode_1.Item.BackColor = Color.Transparent;
                        this.dskinTreeViewNode_1.Item.Borders.AllColor = Color.Transparent;
                    }
                    this.dskinTreeViewNode_1 = value;
                    if (this.dskinTreeViewNode_1 != null)
                    {
                        this.dskinTreeViewNode_1.Selected = true;
                        this.dskinTreeViewNode_1.Item.BackColor = this.color_2;
                        this.dskinTreeViewNode_1.Item.Borders.AllColor = this.color_3;
                        if (!this.InnerListBox.IsMouseDown)
                        {
                            int num = this.InnerListBox.Items.IndexOf(this.dskinTreeViewNode_1.Item) + 1;
                            this.InnerListBox.Value = (1.0 * num) / ((double) this.InnerListBox.Items.Count);
                        }
                    }
                    this.OnSelectedNodeChanged(EventArgs.Empty);
                }
            }
        }

        [Category("DSkin"), Description("显示复选框"), DefaultValue(true)]
        public bool ShowCheckBox
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                if (this.bool_2 != value)
                {
                    this.bool_2 = value;
                    foreach (DSkinTreeViewNode node in this.Nodes)
                    {
                        node.ShowCheckBox = this.bool_2;
                    }
                }
            }
        }

        [DefaultValue(true), Description("显示图标"), Category("DSkin")]
        public bool ShowIcon
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
                    foreach (DSkinTreeViewNode node in this.Nodes)
                    {
                        node.ShowIcon = this.bool_3;
                    }
                }
            }
        }

        [DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Description("文本渲染模式")]
        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                this.textRenderingHint_0 = value;
            }
        }

    }
}

