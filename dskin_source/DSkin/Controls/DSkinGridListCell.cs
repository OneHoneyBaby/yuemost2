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

    public class DSkinGridListCell : IDisposable
    {
        private Color color_0;
        private ControlType controlType_0;
        private System.Windows.Forms.DockStyle dockStyle_0;
        internal DSkin.Controls.DSkinGridListRow dskinGridListRow_0;
        private DuiBaseControl duiBaseControl_0;
        private System.Drawing.Font font_0;
        private Image image_0;
        private ImageLayout imageLayout_0;
        private object object_0;
        private object object_1;
        private Size size_0;
        private string string_0;
        private System.Type type_0;

        public event EventHandler ValueChanged;

        public DSkinGridListCell()
        {
            this.font_0 = new System.Drawing.Font("微软雅黑", 9f);
            this.color_0 = Color.Black;
            this.imageLayout_0 = ImageLayout.Tile;
            this.string_0 = "";
            this.object_0 = null;
            this.size_0 = new Size(20, 20);
            this.dockStyle_0 = System.Windows.Forms.DockStyle.Fill;
            this.object_1 = null;
            this.controlType_0 = ControlType.DuiLabel;
        }

        public DSkinGridListCell(object value, System.Type template)
        {
            this.font_0 = new System.Drawing.Font("微软雅黑", 9f);
            this.color_0 = Color.Black;
            this.imageLayout_0 = ImageLayout.Tile;
            this.string_0 = "";
            this.object_0 = null;
            this.size_0 = new Size(20, 20);
            this.dockStyle_0 = System.Windows.Forms.DockStyle.Fill;
            this.object_1 = null;
            this.controlType_0 = ControlType.DuiLabel;
            this.Value = value;
            this.type_0 = template;
        }

        public DSkinGridListCell(object value, System.Type template, Color foreColor, System.Drawing.Font font)
        {
            this.font_0 = new System.Drawing.Font("微软雅黑", 9f);
            this.color_0 = Color.Black;
            this.imageLayout_0 = ImageLayout.Tile;
            this.string_0 = "";
            this.object_0 = null;
            this.size_0 = new Size(20, 20);
            this.dockStyle_0 = System.Windows.Forms.DockStyle.Fill;
            this.object_1 = null;
            this.controlType_0 = ControlType.DuiLabel;
            this.ForeColor = foreColor;
            this.Value = value;
            this.Font = font;
            this.type_0 = template;
        }

        public void DestroyItem()
        {
            if (this.duiBaseControl_0 != null)
            {
                this.duiBaseControl_0.Dispose();
                this.duiBaseControl_0 = null;
            }
        }

        public void Dispose()
        {
            this.DestroyItem();
            GC.SuppressFinalize(this);
        }

        ~DSkinGridListCell()
        {
            this.Dispose();
        }

        private void method_0()
        {
            if (this.duiBaseControl_0 != null)
            {
                this.duiBaseControl_0.Font = this.font_0;
                this.duiBaseControl_0.Text = this.string_0;
                if (this.duiBaseControl_0 is DuiCheckBox)
                {
                    this.duiBaseControl_0.ForeColor = Color.Transparent;
                }
                else
                {
                    this.duiBaseControl_0.ForeColor = this.color_0;
                }
                this.duiBaseControl_0.BackgroundImage = this.image_0;
                this.duiBaseControl_0.BackgroundImageLayout = this.imageLayout_0;
            }
        }

        [CompilerGenerated]
        private void method_1(object sender, EventArgs e)
        {
            if (this.controlType_0 == ControlType.DuiTextBox)
            {
                this.string_0 = this.duiBaseControl_0.Text;
                this.Value = this.string_0;
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

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
                    this.method_0();
                }
            }
        }

        public ImageLayout BackgroundImageLayout
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
                    this.method_0();
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl CellControl
        {
            get
            {
                EventHandler handler = null;
                if (this.duiBaseControl_0 == null)
                {
                    if (this.type_0 != null)
                    {
                        DSkinGridListCellTemplate template = (DSkinGridListCellTemplate) Activator.CreateInstance(this.type_0);
                        template.dskinGridListCell_0 = this;
                        template.Value = this.object_0;
                        this.duiBaseControl_0 = template;
                    }
                    else
                    {
                        DuiCheckBox check;
                        DuiRadioButton radio;
                        switch (this.controlType_0)
                        {
                            case ControlType.DuiTextBox:
                            {
                                DuiTextBox box3 = new DuiTextBox {
                                    Height = this.Font.Height
                                };
                                if (handler == null)
                                {
                                    handler = new EventHandler(this.method_1);
                                }
                                box3.TextChanged += handler;
                                this.duiBaseControl_0 = box3;
                                break;
                            }
                            case ControlType.DuiLabel:
                            {
                                DuiLabel label = new DuiLabel {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    AutoEllipsis = true
                                };
                                this.duiBaseControl_0 = label;
                                break;
                            }
                            case ControlType.DuiButton:
                            {
                                DuiButton button = new DuiButton {
                                    AutoEllipsis = true,
                                    Radius = 0,
                                    AdaptImage = false
                                };
                                this.duiBaseControl_0 = button;
                                break;
                            }
                            case ControlType.DuiPictureBox:
                            {
                                DuiPictureBox box = new DuiPictureBox {
                                    SizeMode = PictureBoxSizeMode.StretchImage
                                };
                                if (this.object_0 != null)
                                {
                                    box.Image = (Image) this.object_0;
                                }
                                this.duiBaseControl_0 = box;
                                this.duiBaseControl_0.Size = this.ContentSize;
                                break;
                            }
                            case ControlType.DuiCheckBox:
                                check = new DuiCheckBox {
                                    AutoSize = false
                                };
                                if (this.object_0 != null)
                                {
                                    check.Checked = this.object_0.ToBool();
                                }
                                check.CheckedChanged += delegate (object sender, EventArgs e) {
                                    if (this.controlType_0 == ControlType.DuiCheckBox)
                                    {
                                        this.Value = check.Checked;
                                    }
                                };
                                this.duiBaseControl_0 = check;
                                break;

                            case ControlType.DuiRadioButton:
                                radio = new DuiRadioButton {
                                    AutoSize = false
                                };
                                if (this.object_0 != null)
                                {
                                    radio.Checked = (bool) this.object_0;
                                }
                                radio.CheckedChanged += delegate (object sender, EventArgs e) {
                                    if (this.controlType_0 == ControlType.DuiRadioButton)
                                    {
                                        this.Value = radio.Checked;
                                    }
                                };
                                this.duiBaseControl_0 = radio;
                                break;

                            case ControlType.DuiComboBox:
                            {
                                DuiComboBox box5 = new DuiComboBox {
                                    AutoDrawSelecedItem = false
                                };
                                this.duiBaseControl_0 = box5;
                                break;
                            }
                        }
                        this.duiBaseControl_0.BackColor = Color.Transparent;
                    }
                    this.method_0();
                }
                return this.duiBaseControl_0;
            }
        }

        public Size ContentSize
        {
            get
            {
                if ((this.controlType_0 != ControlType.DuiPictureBox) && (this.duiBaseControl_0 != null))
                {
                    return this.duiBaseControl_0.Size;
                }
                return this.size_0;
            }
            set
            {
                if ((this.controlType_0 == ControlType.DuiPictureBox) && (this.duiBaseControl_0 != null))
                {
                    this.duiBaseControl_0.Size = this.size_0;
                }
                this.size_0 = value;
            }
        }

        [Description("虚拟控件布局排列样式"), Category("公共属性")]
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

        public DSkin.Controls.DSkinGridListRow DSkinGridListRow
        {
            get
            {
                return this.dskinGridListRow_0;
            }
        }

        [Description("控件项目的字体"), Category("公共属性")]
        public System.Drawing.Font Font
        {
            get
            {
                return this.font_0;
            }
            set
            {
                this.font_0 = value;
                this.method_0();
            }
        }

        [Description("前景色"), Category("公共属性")]
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
                    this.method_0();
                }
            }
        }

        [Category("SubItem项的Dui控件项目"), Description("SubItem项的控件项目类型")]
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
                    this.DestroyItem();
                }
            }
        }

        [Category("公共属性"), Description("自定义数据结构"), TypeConverter(typeof(StringConverter))]
        public object Tag
        {
            get
            {
                return this.object_1;
            }
            set
            {
                this.object_1 = value;
            }
        }

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

        [Description("控件项目的Text"), Category("公共属性")]
        public string Text
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                this.method_0();
            }
        }

        [TypeConverter(typeof(StringConverter))]
        public object Value
        {
            get
            {
                return this.object_0;
            }
            set
            {
                if (this.object_0 != value)
                {
                    this.object_0 = value;
                    if (value is Image)
                    {
                        this.ItemType = ControlType.DuiPictureBox;
                    }
                    else
                    {
                        this.string_0 = (value == null) ? string.Empty : value.ToString();
                    }
                    if (this.duiBaseControl_0 != null)
                    {
                        this.duiBaseControl_0.Text = this.string_0;
                        if (this.type_0 != null)
                        {
                            DSkinGridListCellTemplate template = this.duiBaseControl_0 as DSkinGridListCellTemplate;
                            if (template != null)
                            {
                                template.Value = value;
                            }
                        }
                        switch (this.controlType_0)
                        {
                            case ControlType.DuiPictureBox:
                                ((DuiPictureBox) this.duiBaseControl_0).Image = (Image) value;
                                break;

                            case ControlType.DuiCheckBox:
                                ((DuiCheckBox) this.duiBaseControl_0).Checked = (bool) value;
                                break;

                            case ControlType.DuiRadioButton:
                                ((DuiRadioButton) this.duiBaseControl_0).Checked = (bool) value;
                                break;
                        }
                    }
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }
    }
}

