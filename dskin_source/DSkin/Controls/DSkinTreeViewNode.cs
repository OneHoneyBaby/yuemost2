namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class DSkinTreeViewNode : IDisposable, ITreeViewNode
    {
        private bool bool_0 = true;
        private bool bool_1 = false;
        private bool bool_2 = true;
        private bool bool_3 = false;
        private bool bool_4 = false;
        private bool bool_5 = true;
        private bool bool_6 = true;
        private bool bool_7 = false;
        private bool bool_8 = true;
        private System.Windows.Forms.CheckState checkState_0 = System.Windows.Forms.CheckState.Unchecked;
        private Collection<DSkinTreeViewNode> collection_0;
        private Color color_0 = SystemColors.ControlText;
        private Color color_1 = Color.FromArgb(0xe5, 0xf3, 0xfb);
        private Color color_2 = Color.FromArgb(0x26, 160, 0xda);
        private DuiBaseControl duiBaseControl_0;
        private System.Drawing.Font font_0 = Control.DefaultFont;
        private static Image image_0 = Resources.dWbbvkixjkY();
        private static Image image_1 = Resources.smethod_10();
        private Image image_10 = null;
        private Image image_11 = null;
        private Image image_12 = null;
        private Image image_13 = null;
        private Image image_14 = null;
        private Image image_15 = null;
        private Image image_16 = null;
        private Image image_17;
        private Image image_18;
        private static Image image_2 = Resources.middle;
        private Image image_3;
        private Image image_4;
        private Image image_5;
        private Image image_6;
        private Image image_7;
        private Image image_8;
        private Image image_9;
        private int int_0 = 20;
        private ITreeViewNode itreeViewNode_0;
        private object object_0;
        private Size size_0 = new Size(20, 20);
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private System.Type type_0;

        public event EventHandler CheckStateChanged;

        public event EventHandler ItemCreated;

        public event EventHandler NodesOpenOrClose;

        public event EventHandler SelectedChanged;

        public void Close()
        {
            this.NodesOpened = false;
        }

        public void DestroyItem()
        {
            this.NodesOpened = false;
            if (this.duiBaseControl_0 != null)
            {
                this.duiBaseControl_0.Controls.Clear();
                this.duiBaseControl_0.Dispose();
                this.duiBaseControl_0 = null;
            }
            foreach (DSkinTreeViewNode node in this.Nodes)
            {
                node.DestroyItem();
            }
            this.bool_4 = false;
        }

        public void Dispose()
        {
            if (this.itreeViewNode_0 != null)
            {
                this.itreeViewNode_0.Nodes.Remove(this);
                this.itreeViewNode_0 = null;
            }
            if (this.duiBaseControl_0 != null)
            {
                this.duiBaseControl_0.Dispose();
                this.duiBaseControl_0 = null;
            }
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                this.Nodes[0].Dispose();
            }
        }

        private void duiBaseControl_0_StartPaint(object sender, EventArgs e)
        {
            this.method_3();
        }

        private void duiBaseControl_0_VisibleChanged(object sender, EventArgs e)
        {
            if (this.duiBaseControl_0.Visible && this.NodesOpened)
            {
                foreach (DSkinTreeViewNode node in this.Nodes)
                {
                    node.Item.Visible = true;
                }
            }
            else
            {
                foreach (DSkinTreeViewNode node in this.Nodes)
                {
                    node.Item.Visible = false;
                }
            }
        }

        internal bool method_0()
        {
            return this.bool_0;
        }

        internal void method_1(bool value)
        {
            this.bool_0 = value;
        }

        [CompilerGenerated]
        private void method_10(object sender, MouseEventArgs e)
        {
            if (!(this.bool_7 || (this.duiBaseControl_0 == null)))
            {
                this.duiBaseControl_0.BackColor = this.color_1;
                this.duiBaseControl_0.Borders.AllColor = this.ItemBorderColorHover;
            }
        }

        [CompilerGenerated]
        private void method_11(object sender, EventArgs e)
        {
            if (!(this.bool_7 || (this.duiBaseControl_0 == null)))
            {
                this.duiBaseControl_0.BackColor = Color.Transparent;
                this.duiBaseControl_0.Borders.AllColor = Color.Transparent;
            }
        }

        internal void method_2(object sender, EventArgs e)
        {
            if (this.duiBaseControl_0 != null)
            {
                DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                if (box != null)
                {
                    this.CheckState = box.CheckState;
                }
            }
        }

        private void method_3()
        {
            if (this.duiBaseControl_0 != null)
            {
                if (this.type_0 != null)
                {
                    if (this.duiBaseControl_0.Controls.Count > 0)
                    {
                        DSkinTreeViewNodeTemplate template = this.duiBaseControl_0.Controls[0] as DSkinTreeViewNodeTemplate;
                        if ((template != null) && template.AutoOffset)
                        {
                            template.Left = this.method_4();
                        }
                    }
                }
                else
                {
                    DuiBaseControl control2 = this.duiBaseControl_0.Controls["openClose"];
                    if (control2 != null)
                    {
                        control2.Visible = this.Nodes.Count > 0;
                        control2.Location = new Point(this.method_4(), (this.duiBaseControl_0.Height - control2.Height) / 2);
                        int x = control2.Width + control2.Left;
                        for (int i = 1; i < this.duiBaseControl_0.Controls.Count; i++)
                        {
                            DuiBaseControl control = this.duiBaseControl_0.Controls[i];
                            if (control.Visible)
                            {
                                control.Location = new Point(x, (this.duiBaseControl_0.Height - control.Height) / 2);
                                x += control.Width;
                            }
                        }
                    }
                }
            }
        }

        internal int method_4()
        {
            if (this.itreeViewNode_0 is DSkinTreeViewNode)
            {
                return (((DSkinTreeViewNode) this.itreeViewNode_0).method_4() + 15);
            }
            if (this.itreeViewNode_0 is DSkinTreeView)
            {
                return ((DSkinTreeView) this.itreeViewNode_0).HorizontalScrollValue;
            }
            return 0;
        }

        private void method_5(DSkinTreeViewNode dskinTreeViewNode_0)
        {
            DSkinTreeViewNode parentNode = dskinTreeViewNode_0.ParentNode as DSkinTreeViewNode;
            if (parentNode != null)
            {
                this.method_5(parentNode);
                parentNode.NodesOpened = true;
            }
        }

        private void method_6(object sender, CollectionEventArgs<DSkinTreeViewNode> e)
        {
            this.NodesOpened = false;
            e.Item.ParentNode = this;
            e.Item.NodesOpenOrClose += new EventHandler(this.method_8);
            e.Item.DestroyItem();
            this.IsLoadNodes = false;
            e.Item.method_2(this, EventArgs.Empty);
        }

        private void method_7(object sender, CollectionEventArgs<DSkinTreeViewNode> e)
        {
            e.Item.NodesOpenOrClose -= new EventHandler(this.method_8);
            this.IsLoadNodes = false;
            this.NodesOpened = false;
            e.Item.DestroyItem();
            if (this.Nodes.Count > 1)
            {
                bool flag = true;
                for (int i = 1; i < this.Nodes.Count; i++)
                {
                    if (this.Nodes[i].CheckState != this.Nodes[0].CheckState)
                    {
                        flag = false;
                        this.CheckState = System.Windows.Forms.CheckState.Indeterminate;
                        break;
                    }
                }
                if (flag)
                {
                    this.CheckState = this.Nodes[0].CheckState;
                }
            }
            e.Item.ParentNode = null;
        }

        private void method_8(object sender, EventArgs e)
        {
            this.OnNodesOpenOrClose(sender, e);
        }

        [CompilerGenerated]
        private void method_9(object sender, EventArgs e)
        {
            this.NodesOpened = ((DuiCheckBox) sender).Checked;
        }

        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            IEnumerator enumerator;
            DSkinTreeViewNode current;
            if (this.checkState_0 != System.Windows.Forms.CheckState.Indeterminate)
            {
                using (enumerator = this.Nodes.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = (DSkinTreeViewNode) enumerator.Current;
                        current.method_1(false);
                        current.CheckState = this.checkState_0;
                        current.method_1(true);
                    }
                }
            }
            if (!this.bool_0)
            {
                goto Label_0130;
            }
            if (!(this.itreeViewNode_0 is DSkinTreeViewNode))
            {
                goto Label_00FE;
            }
            DSkinTreeViewNode node2 = this.itreeViewNode_0 as DSkinTreeViewNode;
            bool flag = true;
            using (enumerator = this.itreeViewNode_0.Nodes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    current = (DSkinTreeViewNode) enumerator.Current;
                    if (current.CheckState != this.CheckState)
                    {
                        goto Label_00CA;
                    }
                }
                goto Label_00EC;
            Label_00CA:
                flag = false;
                node2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            }
        Label_00EC:
            if (flag)
            {
                node2.CheckState = this.CheckState;
            }
        Label_00FE:
            if ((this.itreeViewNode_0 is DSkinTreeViewNode) && (this.CheckState == System.Windows.Forms.CheckState.Indeterminate))
            {
                ((DSkinTreeViewNode) this.itreeViewNode_0).CheckState = System.Windows.Forms.CheckState.Indeterminate;
            }
        Label_0130:
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnItemCreated(EventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnNodesOpenOrClose(object sender, EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(sender, e);
            }
        }

        public void Open()
        {
            this.method_5(this);
            this.NodesOpened = true;
        }

        [DefaultValue(true)]
        public bool CanSelect
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

        [DefaultValue((string) null)]
        public Image CheckBoxCheckedHover
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedHover = value;
                        }
                    }
                }
            }
        }

        public Image CheckBoxCheckedNormal
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedNormal = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxCheckedPressed
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedPressed = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxIndeterminateHover
        {
            get
            {
                return this.image_17;
            }
            set
            {
                if (this.image_17 != value)
                {
                    this.image_17 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.IndeterminateHover = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxIndeterminateNormal
        {
            get
            {
                return this.image_16;
            }
            set
            {
                if (this.image_16 != value)
                {
                    this.image_16 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.IndeterminateNormal = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxIndeterminatePressed
        {
            get
            {
                return this.image_18;
            }
            set
            {
                if (this.image_18 != value)
                {
                    this.image_18 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.IndeterminatePressed = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxUncheckedHover
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedHover = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxUncheckedNormal
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedNormal = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CheckBoxUncheckedPressed
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedPressed = value;
                        }
                    }
                }
            }
        }

        public virtual System.Windows.Forms.CheckState CheckState
        {
            get
            {
                return this.checkState_0;
            }
            set
            {
                if (this.checkState_0 != value)
                {
                    this.checkState_0 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckState = value;
                        }
                    }
                    this.OnCheckStateChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CloseHover
        {
            get
            {
                return this.image_8;
            }
            set
            {
                if (value != this.image_8)
                {
                    this.image_8 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedHover = (value == null) ? image_1 : value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image CloseNormal
        {
            get
            {
                return this.image_7;
            }
            set
            {
                if (value != this.image_7)
                {
                    this.image_7 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedNormal = (value == null) ? image_1 : value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image ClosePressed
        {
            get
            {
                return this.image_9;
            }
            set
            {
                if (value != this.image_9)
                {
                    this.image_9 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.UncheckedPressed = (value == null) ? image_1 : value;
                        }
                    }
                }
            }
        }

        public System.Drawing.Font Font
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiLabel label = this.duiBaseControl_0.Controls["text"] as DuiLabel;
                        if (label != null)
                        {
                            label.Font = value;
                            if (this.type_0 == null)
                            {
                                this.duiBaseControl_0.Height = label.Font.Height + 10;
                            }
                        }
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "ControlText")]
        public Color ForeColor
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiLabel label = this.duiBaseControl_0.Controls["text"] as DuiLabel;
                        if (label != null)
                        {
                            label.ForeColor = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image Icon
        {
            get
            {
                return this.image_3;
            }
            set
            {
                if (this.image_3 != value)
                {
                    this.image_3 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiPictureBox box = (DuiPictureBox) this.duiBaseControl_0.Controls["picBox"];
                        if (box != null)
                        {
                            box.Image = (value == null) ? image_2 : value;
                        }
                    }
                }
            }
        }

        [DefaultValue(typeof(Size), "20,20")]
        public Size IconSize
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiBaseControl control = this.duiBaseControl_0.Controls["picBox"];
                        if (control != null)
                        {
                            control.Size = value;
                        }
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool IsCustom
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsFirstLoad
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLoadNodes
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
                    if (!value)
                    {
                        foreach (DSkinTreeViewNode node in this.Nodes)
                        {
                            node.DestroyItem();
                        }
                    }
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl Item
        {
            get
            {
                EventHandler handler = null;
                EventHandler<MouseEventArgs> handler2 = null;
                EventHandler handler3 = null;
                if (this.duiBaseControl_0 == null)
                {
                    if (this.type_0 == null)
                    {
                        DuiCheckBox box3 = new DuiCheckBox {
                            CheckedNormal = (this.image_4 == null) ? image_0 : this.image_4,
                            CheckedHover = (this.image_5 == null) ? image_0 : this.image_5,
                            CheckedPressed = (this.image_6 == null) ? image_0 : this.image_6,
                            UncheckedNormal = (this.image_7 == null) ? image_1 : this.image_7,
                            UncheckedHover = (this.image_8 == null) ? image_1 : this.image_8,
                            UncheckedPressed = (this.image_9 == null) ? image_1 : this.image_9,
                            Visible = false,
                            CheckRectWidth = this.int_0,
                            Name = "openClose"
                        };
                        if (handler == null)
                        {
                            handler = new EventHandler(this.method_9);
                        }
                        box3.CheckedChanged += handler;
                        DuiCheckBox box4 = new DuiCheckBox {
                            InnerPaddingWidth = 1,
                            CheckedNormal = this.image_13,
                            CheckedHover = this.image_14,
                            CheckedPressed = this.image_15,
                            UncheckedNormal = this.image_10,
                            UncheckedHover = this.image_11,
                            UncheckedPressed = this.image_12,
                            IndeterminateNormal = this.image_16,
                            IndeterminateHover = this.image_17,
                            IndeterminatePressed = this.image_18,
                            CheckState = this.checkState_0,
                            Visible = this.bool_5,
                            Name = "checkBox"
                        };
                        box4.CheckStateChanged += new EventHandler(this.method_2);
                        DuiPictureBox box2 = new DuiPictureBox {
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = this.size_0,
                            Image = (this.image_3 == null) ? image_2 : this.image_3,
                            Visible = this.bool_6,
                            Name = "picBox"
                        };
                        DuiLabel text = new DuiLabel {
                            AutoSize = true,
                            Text = this.string_1,
                            Font = this.font_0,
                            ForeColor = this.color_0,
                            TextRenderMode = this.textRenderingHint_0,
                            Name = "text"
                        };
                        text.TextChanged += delegate (object sender, EventArgs e) {
                            if (this.duiBaseControl_0 != null)
                            {
                                this.duiBaseControl_0.ToolTip = text.Text;
                            }
                        };
                        DuiBaseControl control = new DuiBaseControl {
                            Height = text.Font.Height + 8
                        };
                        this.duiBaseControl_0 = control;
                        this.duiBaseControl_0.Controls.Add(box3);
                        this.duiBaseControl_0.Controls.Add(box4);
                        this.duiBaseControl_0.Controls.Add(box2);
                        this.duiBaseControl_0.Controls.Add(text);
                    }
                    else
                    {
                        this.duiBaseControl_0 = new DuiBaseControl();
                        DSkinTreeViewNodeTemplate template = (DSkinTreeViewNodeTemplate) Activator.CreateInstance(this.type_0);
                        template.Node = this;
                        this.duiBaseControl_0.Controls.Add(template);
                        this.duiBaseControl_0.Height = template.Height;
                    }
                    this.duiBaseControl_0.ToolTip = this.string_1;
                    this.duiBaseControl_0.Margin = new Padding(0, 0, 0, 1);
                    this.duiBaseControl_0.InheritanceSize = new SizeF(1f, 0f);
                    this.duiBaseControl_0.VisibleChanged += new EventHandler(this.duiBaseControl_0_VisibleChanged);
                    this.duiBaseControl_0.StartPaint += new EventHandler(this.duiBaseControl_0_StartPaint);
                    if (handler2 == null)
                    {
                        handler2 = new EventHandler<MouseEventArgs>(this.method_10);
                    }
                    this.duiBaseControl_0.MouseEnter += handler2;
                    if (handler3 == null)
                    {
                        handler3 = new EventHandler(this.method_11);
                    }
                    this.duiBaseControl_0.MouseLeave += handler3;
                    this.duiBaseControl_0.Tag = this;
                    this.OnItemCreated(EventArgs.Empty);
                }
                return this.duiBaseControl_0;
            }
        }

        [DefaultValue(typeof(Color), "229, 243, 251")]
        public Color ItemBackColorHover
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

        [DefaultValue(typeof(Color), "38, 160, 218")]
        public Color ItemBorderColorHover
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

        [Browsable(false)]
        public int Level
        {
            get
            {
                DSkinTreeViewNode node = this.itreeViewNode_0 as DSkinTreeViewNode;
                if (node != null)
                {
                    return (node.Level + 1);
                }
                return 0;
            }
        }

        [Category("设计")]
        public string Name
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        [Description("子节点"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<DSkinTreeViewNode> Nodes
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DSkinTreeViewNode>();
                    this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinTreeViewNode>>(this.method_6);
                    this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinTreeViewNode>>(this.method_7);
                }
                return this.collection_0;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NodesOpened
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
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.Checked = value;
                        }
                    }
                    this.OnNodesOpenOrClose(this, EventArgs.Empty);
                }
            }
        }

        [DefaultValue(20)]
        public int OpenCloseButtonWidth
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckRectWidth = value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image OpenHover
        {
            get
            {
                return this.image_5;
            }
            set
            {
                if (value != this.image_5)
                {
                    this.image_5 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedHover = (value == null) ? image_0 : value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image OpenNormal
        {
            get
            {
                return this.image_4;
            }
            set
            {
                if (value != this.image_4)
                {
                    this.image_4 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedNormal = (value == null) ? image_0 : value;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null)]
        public Image OpenPressed
        {
            get
            {
                return this.image_6;
            }
            set
            {
                if (value != this.image_6)
                {
                    this.image_6 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["openClose"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.CheckedPressed = (value == null) ? image_0 : value;
                        }
                    }
                }
            }
        }

        [Browsable(false)]
        public ITreeViewNode ParentNode
        {
            get
            {
                return this.itreeViewNode_0;
            }
            internal set
            {
                this.itreeViewNode_0 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Selected
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
                    if (this.eventHandler_3 != null)
                    {
                        this.eventHandler_3(this, EventArgs.Empty);
                    }
                }
            }
        }

        [DefaultValue(true)]
        public bool ShowCheckBox
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                if (this.bool_5 != value)
                {
                    this.bool_5 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiCheckBox box = this.duiBaseControl_0.Controls["checkBox"] as DuiCheckBox;
                        if (box != null)
                        {
                            box.Visible = value;
                        }
                    }
                    if (this.NodesOpened)
                    {
                        foreach (DSkinTreeViewNode node in this.Nodes)
                        {
                            node.ShowCheckBox = this.bool_5;
                        }
                    }
                }
            }
        }

        [DefaultValue(true)]
        public bool ShowIcon
        {
            get
            {
                return this.bool_6;
            }
            set
            {
                if (this.bool_6 != value)
                {
                    this.bool_6 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiBaseControl control = this.duiBaseControl_0.Controls["picBox"];
                        if (control != null)
                        {
                            control.Visible = value;
                        }
                    }
                    if (this.NodesOpened)
                    {
                        foreach (DSkinTreeViewNode node in this.Nodes)
                        {
                            node.ShowIcon = this.bool_6;
                        }
                    }
                }
            }
        }

        [DefaultValue((string) null), Description("与控件关联的用户自定义数据"), TypeConverter(typeof(StringConverter))]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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

        [DefaultValue("")]
        public string Text
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
                    if (this.duiBaseControl_0 != null)
                    {
                        this.duiBaseControl_0.ToolTip = value;
                        DuiLabel label = this.duiBaseControl_0.Controls["text"] as DuiLabel;
                        if (label != null)
                        {
                            label.Text = value;
                        }
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
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DuiLabel label = this.duiBaseControl_0.Controls["text"] as DuiLabel;
                        if (label != null)
                        {
                            label.TextRenderMode = value;
                        }
                    }
                }
            }
        }
    }
}

