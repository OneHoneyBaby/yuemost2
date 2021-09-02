namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class GClass2
    {
        private bool bool_0 = true;
        private ControlType controlType_0 = ControlType.DuiLabel;
        private System.Windows.Forms.DockStyle dockStyle_0 = System.Windows.Forms.DockStyle.Fill;
        private DuiLabel duiLabel_0;
        private static Font font_0 = new Font("宋体", 6f);
        private int int_0 = 0;
        private int int_1 = 20;
        private int int_2 = 0;
        private OrderModes orderModes_0 = OrderModes.None;
        private string string_0 = string.Empty;
        private System.Type type_0;

        public GClass2()
        {
            this.Name = "Column";
            this.Width = 80;
        }

        [CompilerGenerated]
        private void method_0(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.orderModes_0 != OrderModes.None)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, this.duiLabel_0.ForeColor)))
                {
                    if (this.orderModes_0 == OrderModes.Ascending)
                    {
                        graphics.DrawString("▲", font_0, brush, (PointF) new Point(this.duiLabel_0.Width - 12, (this.duiLabel_0.Height - font_0.Height) / 2));
                    }
                    else if (this.orderModes_0 == OrderModes.Descending)
                    {
                        graphics.DrawString("▼", font_0, brush, (PointF) new Point(this.duiLabel_0.Width - 12, (this.duiLabel_0.Height - font_0.Height) / 2));
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Type CellTemplate
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

        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter"), Editor("System.Windows.Forms.Design.DataGridViewColumnDataPropertyNameEditor", typeof(UITypeEditor)), DefaultValue("")]
        public string DataPropertyName
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

        [DefaultValue(5), Category("公共属性"), Description("虚拟控件布局排列样式")]
        public System.Windows.Forms.DockStyle DockStyle
        {
            get
            {
                return this.dockStyle_0;
            }
            set
            {
                this.dockStyle_0 = value;
            }
        }

        [DefaultValue(true)]
        public bool EnabledOrder
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

        [DefaultValue(0), Description("列项标识")]
        public int Id
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiLabel Item
        {
            get
            {
                EventHandler<PaintEventArgs> handler = null;
                if ((this.duiLabel_0 == null) || this.duiLabel_0.IsDisposed)
                {
                    DuiLabel label2 = new DuiLabel {
                        AutoSize = false,
                        Font = new Font("微软雅黑", 9f),
                        TextAlign = ContentAlignment.MiddleCenter,
                        InheritanceSize = new SizeF(0f, 1f),
                        Tag = this
                    };
                    this.duiLabel_0 = label2;
                    if (handler == null)
                    {
                        handler = new EventHandler<PaintEventArgs>(this.method_0);
                    }
                    this.duiLabel_0.PrePaint += handler;
                }
                return this.duiLabel_0;
            }
        }

        [DefaultValue(1), Category("SubItem项的Dui控件项目"), Description("SubItem项的控件项目类型")]
        public ControlType ItemType
        {
            get
            {
                return this.controlType_0;
            }
            set
            {
                if (this.controlType_0 != value)
                {
                    this.controlType_0 = value;
                }
            }
        }

        [DefaultValue(0)]
        public int MaxWidth
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

        [DefaultValue(20)]
        public int MinWidth
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

        [Description("列名称")]
        public string Name
        {
            get
            {
                return this.Item.Text;
            }
            set
            {
                this.Item.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderModes OrderMode
        {
            get
            {
                return this.orderModes_0;
            }
            set
            {
                this.orderModes_0 = value;
            }
        }

        public bool Visble
        {
            get
            {
                return this.Item.Visible;
            }
            set
            {
                this.Item.Visible = value;
            }
        }

        [Description("列宽度")]
        public int Width
        {
            get
            {
                return this.Item.Width;
            }
            set
            {
                this.Item.Width = value;
            }
        }
    }
}

