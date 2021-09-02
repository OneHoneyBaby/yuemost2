namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(CheckBox))]
    public class DSkinCheckBox : DSkinBaseControl
    {
        private DuiCheckBox duiCheckBox_0;

        [Description("选中状态改变事件")]
        public event EventHandler CheckedChanged;

        public event EventHandler CheckStateChanged;

        public DSkinCheckBox()
        {
            this.duiCheckBox_0 = (DuiCheckBox) base.InnerDuiControl;
            this.duiCheckBox_0.CheckedChanged += new EventHandler(this.duiCheckBox_0_CheckedChanged);
            this.duiCheckBox_0.CheckStateChanged += new EventHandler(this.IdZeYtauxV);
        }

        private void duiCheckBox_0_CheckedChanged(object sender, EventArgs e)
        {
            this.OnCheckedChanged(EventArgs.Empty);
        }

        private void IdZeYtauxV(object sender, EventArgs e)
        {
            this.OnCheckStateChanged(EventArgs.Empty);
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("控件适应图片大小，否则图片将缩放以适应控件")]
        public virtual bool AdaptImage
        {
            get
            {
                return this.duiCheckBox_0.AdaptImage;
            }
            set
            {
                this.duiCheckBox_0.AdaptImage = value;
            }
        }

        [DefaultValue(true), Description("点击后自动更改状态"), Category("DSkin")]
        public bool AutoCheck
        {
            get
            {
                return this.duiCheckBox_0.AutoCheck;
            }
            set
            {
                this.duiCheckBox_0.AutoCheck = value;
            }
        }

        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [Description("复选框位置"), Category("DSkin")]
        public ContentAlignment CheckAlign
        {
            get
            {
                return this.duiCheckBox_0.CheckAlign;
            }
            set
            {
                this.duiCheckBox_0.CheckAlign = value;
            }
        }

        [Description("是否被选定"), Category("DSkin")]
        public bool Checked
        {
            get
            {
                return this.duiCheckBox_0.Checked;
            }
            set
            {
                this.duiCheckBox_0.Checked = value;
            }
        }

        [Description("选定时鼠标移入的图像"), Category("DSkin"), DefaultValue((string) null)]
        public Image CheckedHover
        {
            get
            {
                return this.duiCheckBox_0.CheckedHover;
            }
            set
            {
                this.duiCheckBox_0.CheckedHover = value;
            }
        }

        [Description("选定时的图像"), DefaultValue((string) null), Category("DSkin")]
        public Image CheckedNormal
        {
            get
            {
                return this.duiCheckBox_0.CheckedNormal;
            }
            set
            {
                this.duiCheckBox_0.CheckedNormal = value;
            }
        }

        [DefaultValue((string) null), Description("选定时鼠标按下的图像"), Category("DSkin")]
        public Image CheckedPressed
        {
            get
            {
                return this.duiCheckBox_0.CheckedPressed;
            }
            set
            {
                this.duiCheckBox_0.CheckedPressed = value;
            }
        }

        [Category("DSkin"), Description("选中的颜色")]
        public Color CheckFlagColor
        {
            get
            {
                return this.duiCheckBox_0.CheckFlagColor;
            }
            set
            {
                this.duiCheckBox_0.CheckFlagColor = value;
            }
        }

        [Description("禁用时的选中的颜色"), Category("DSkin")]
        public Color CheckFlagColorDisabled
        {
            get
            {
                return this.duiCheckBox_0.CheckFlagColorDisabled;
            }
            set
            {
                this.duiCheckBox_0.CheckFlagColorDisabled = value;
            }
        }

        [Category("DSkin"), Description("禁用时选择框背景色")]
        public Color CheckRectBackColorDisabled
        {
            get
            {
                return this.duiCheckBox_0.CheckRectBackColorDisabled;
            }
            set
            {
                this.duiCheckBox_0.CheckRectBackColorDisabled = value;
            }
        }

        [Category("DSkin"), Description("选择框高亮的背景色")]
        public Color CheckRectBackColorHighLight
        {
            get
            {
                return this.duiCheckBox_0.CheckRectBackColorHighLight;
            }
            set
            {
                this.duiCheckBox_0.CheckRectBackColorHighLight = value;
            }
        }

        [Category("DSkin"), Description("选择框背景颜色")]
        public Color CheckRectBackColorNormal
        {
            get
            {
                return this.duiCheckBox_0.CheckRectBackColorNormal;
            }
            set
            {
                this.duiCheckBox_0.CheckRectBackColorNormal = value;
            }
        }

        [Category("DSkin"), Description("选择框按下时候的背景色")]
        public Color CheckRectBackColorPressed
        {
            get
            {
                return this.duiCheckBox_0.CheckRectBackColorPressed;
            }
            set
            {
                this.duiCheckBox_0.CheckRectBackColorPressed = value;
            }
        }

        [Description("选择框边框颜色"), Category("DSkin")]
        public Color CheckRectColor
        {
            get
            {
                return this.duiCheckBox_0.CheckRectColor;
            }
            set
            {
                this.duiCheckBox_0.CheckRectColor = value;
            }
        }

        [Category("DSkin"), Description("禁用时的选择框边框颜色")]
        public Color CheckRectColorDisabled
        {
            get
            {
                return this.duiCheckBox_0.CheckRectColorDisabled;
            }
            set
            {
                this.duiCheckBox_0.CheckRectColorDisabled = value;
            }
        }

        [Category("DSkin"), Description("获取或设置Check标记的外部方块的宽度，宽度与高度是相等的")]
        public int CheckRectWidth
        {
            get
            {
                return this.duiCheckBox_0.CheckRectWidth;
            }
            set
            {
                this.duiCheckBox_0.CheckRectWidth = value;
            }
        }

        [Category("DSkin"), Description("选定状态")]
        public virtual System.Windows.Forms.CheckState CheckState
        {
            get
            {
                return this.duiCheckBox_0.CheckState;
            }
            set
            {
                this.duiCheckBox_0.CheckState = value;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiCheckBox();
            }
        }

        [Description("半选定时鼠标移入的图像"), DefaultValue((string) null), Category("DSkin")]
        public virtual Image IndeterminateHover
        {
            get
            {
                return this.duiCheckBox_0.IndeterminateHover;
            }
            set
            {
                this.duiCheckBox_0.IndeterminateHover = value;
            }
        }

        [Category("DSkin"), DefaultValue((string) null), Description("半选定时的图像")]
        public virtual Image IndeterminateNormal
        {
            get
            {
                return this.duiCheckBox_0.IndeterminateNormal;
            }
            set
            {
                this.duiCheckBox_0.IndeterminateNormal = value;
            }
        }

        [DefaultValue((string) null), Category("DSkin"), Description("半选定时鼠标按下的图像")]
        public virtual Image IndeterminatePressed
        {
            get
            {
                return this.duiCheckBox_0.IndeterminatePressed;
            }
            set
            {
                this.duiCheckBox_0.IndeterminatePressed = value;
            }
        }

        [Description("内部填充宽度"), Category("DSkin")]
        public int InnerPaddingWidth
        {
            get
            {
                return this.duiCheckBox_0.InnerPaddingWidth;
            }
            set
            {
                this.duiCheckBox_0.InnerPaddingWidth = value;
            }
        }

        [Category("DSkin"), Description("获取或设置当CheckState==Indeterminate时，内部Rect的缩进量，为正值")]
        public virtual int InnerRectInflate
        {
            get
            {
                return this.duiCheckBox_0.InnerRectInflate;
            }
            set
            {
                this.duiCheckBox_0.InnerRectInflate = value;
            }
        }

        [Category("DSkin"), Description("选择框和文字的距离")]
        public int SpaceBetweenCheckMarkAndText
        {
            get
            {
                return this.duiCheckBox_0.SpaceBetweenCheckMarkAndText;
            }
            set
            {
                this.duiCheckBox_0.SpaceBetweenCheckMarkAndText = value;
            }
        }

        [Description("显示的文字"), Category("DSkin")]
        public override string Text
        {
            get
            {
                return this.duiCheckBox_0.Text;
            }
            set
            {
                base.Text = this.duiCheckBox_0.Text = value;
            }
        }

        [Category("DSkin"), Description("禁用时的文字颜色")]
        public Color TextColorDisabled
        {
            get
            {
                return this.duiCheckBox_0.TextColorDisabled;
            }
            set
            {
                this.duiCheckBox_0.TextColorDisabled = value;
            }
        }

        [DefaultValue(typeof(Point), "0,0"), Category("DSkin"), Description("文本偏移")]
        public Point TextOffset
        {
            get
            {
                return this.duiCheckBox_0.TextOffset;
            }
            set
            {
                this.duiCheckBox_0.TextOffset = value;
            }
        }

        [Category("DSkin"), Description("文本呈现质量")]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.duiCheckBox_0.TextRenderingHint;
            }
            set
            {
                this.duiCheckBox_0.TextRenderingHint = value;
            }
        }

        [Description("是否是三种状态"), Category("DSkin"), DefaultValue(false)]
        public virtual bool ThreeState
        {
            get
            {
                return this.duiCheckBox_0.ThreeState;
            }
            set
            {
                this.duiCheckBox_0.ThreeState = value;
            }
        }

        [Category("DSkin"), Description("未选定时鼠标移入的图像"), DefaultValue((string) null)]
        public Image UncheckedHover
        {
            get
            {
                return this.duiCheckBox_0.UncheckedHover;
            }
            set
            {
                this.duiCheckBox_0.UncheckedHover = value;
            }
        }

        [Description("未选定时的图像"), Category("DSkin"), DefaultValue((string) null)]
        public Image UncheckedNormal
        {
            get
            {
                return this.duiCheckBox_0.UncheckedNormal;
            }
            set
            {
                this.duiCheckBox_0.UncheckedNormal = value;
            }
        }

        [Category("DSkin"), Description("未选定时鼠标按下的图像"), DefaultValue((string) null)]
        public Image UncheckedPressed
        {
            get
            {
                return this.duiCheckBox_0.UncheckedPressed;
            }
            set
            {
                this.duiCheckBox_0.UncheckedPressed = value;
            }
        }
    }
}

