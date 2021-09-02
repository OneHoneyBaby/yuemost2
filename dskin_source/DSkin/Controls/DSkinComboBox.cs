namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ComboBox))]
    public class DSkinComboBox : DSkinButton
    {
        private DuiComboBox duiComboBox_0;

        [Description("内部列表控件中的被选中项目索引改变时候发生")]
        public event EventHandler SelectedIndexChanged;

        public DSkinComboBox()
        {
            this.duiComboBox_0 = base.InnerDuiControl as DuiComboBox;
            this.duiComboBox_0.SelectedIndexChanged += new EventHandler(this.duiComboBox_0_SelectedIndexChanged);
            base.Height = 0x19;
        }

        public void AddItem(string item)
        {
            this.duiComboBox_0.AddItem(item);
        }

        public void CloseDropDown()
        {
            this.duiComboBox_0.CloseDropDown();
        }

        private void duiComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnSelectedIndexChanged(EventArgs.Empty);
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        public void ShowDropDown()
        {
            this.duiComboBox_0.ShowDropDown();
        }

        [Category("行为"), Description("选中项目之后自动关闭下拉框"), DefaultValue(true)]
        public bool AutoClose
        {
            get
            {
                return this.duiComboBox_0.AutoClose;
            }
            set
            {
                this.duiComboBox_0.AutoClose = value;
            }
        }

        [Description("是否自动绘制被选中项目"), Category("DSkin")]
        public bool AutoDrawSelecedItem
        {
            get
            {
                return this.duiComboBox_0.AutoDrawSelecedItem;
            }
            set
            {
                this.duiComboBox_0.AutoDrawSelecedItem = value;
            }
        }

        [Description("是否可以编辑"), DefaultValue(false)]
        public bool CanEdit
        {
            get
            {
                return this.duiComboBox_0.CanEdit;
            }
            set
            {
                this.duiComboBox_0.CanEdit = value;
            }
        }

        [DefaultValue(true), Description("下拉框自适应")]
        public bool DropDownAutoSize
        {
            get
            {
                return this.duiComboBox_0.DropDownAutoSize;
            }
            set
            {
                this.duiComboBox_0.DropDownAutoSize = value;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiComboBox();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("内部列表控件")]
        public DSkinListBox InnerListBox
        {
            get
            {
                return this.duiComboBox_0.InnerListBox;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DuiTextBox InnerTextBox
        {
            get
            {
                return this.duiComboBox_0.InnerTextBox;
            }
        }

        [Browsable(false)]
        public bool IsDropDown
        {
            get
            {
                return this.duiComboBox_0.IsDropDown;
            }
        }

        [Category("DSkin"), Description("单列下拉列表项目鼠标移入的背景色")]
        public Color ItemHoverBackColor
        {
            get
            {
                return this.duiComboBox_0.ItemHoverBackColor;
            }
            set
            {
                this.duiComboBox_0.ItemHoverBackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("内部列表项目集合")]
        public DuiControlCollection Items
        {
            get
            {
                return this.duiComboBox_0.Items;
            }
        }

        [Category("行为"), DefaultValue(250), Description("下拉框最大长度")]
        public int MaxLenght
        {
            get
            {
                return this.duiComboBox_0.MaxLenght;
            }
            set
            {
                this.duiComboBox_0.MaxLenght = value;
            }
        }

        [Category("DSkin"), Description("自动绘制项目的左间距")]
        public int PaddingLeft
        {
            get
            {
                return this.duiComboBox_0.PaddingLeft;
            }
            set
            {
                this.duiComboBox_0.PaddingLeft = value;
            }
        }

        [Browsable(false)]
        public DuiBaseControl SelectedDuiControl
        {
            get
            {
                return this.duiComboBox_0.SelectedDuiControl;
            }
        }

        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return this.duiComboBox_0.SelectedIndex;
            }
            set
            {
                this.duiComboBox_0.SelectedIndex = value;
            }
        }

        [Category("DSkin"), Description("显示下拉箭头")]
        public bool ShowArrow
        {
            get
            {
                return this.duiComboBox_0.ShowArrow;
            }
            set
            {
                this.duiComboBox_0.ShowArrow = value;
            }
        }

        [Category("DSkin"), Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor)), Description("字符串转项目，一行一个"), DefaultValue("")]
        public string StringToItems
        {
            get
            {
                return this.duiComboBox_0.StringToItems;
            }
            set
            {
                this.duiComboBox_0.StringToItems = value;
            }
        }

        [Category("下拉框窗口"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DSkinToolStripDropDown ToolStripDropDown
        {
            get
            {
                return this.duiComboBox_0.ToolStripDropDown;
            }
        }
    }
}

