namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(Label)), ToolboxItem(true), Designer("DSkin.Design.DSkinLabelDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null")]
    public class DSkinLabel : DSkinBaseControl
    {
        private DuiLabel duiLabel_0;

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public event EventHandler AutoSizeChanged
        {
            add
            {
                base.AutoSizeChanged += value;
            }
            remove
            {
                base.AutoSizeChanged -= value;
            }
        }

        public DSkinLabel()
        {
            this.duiLabel_0 = (DuiLabel) base.InnerDuiControl;
            this.AutoSize = true;
        }

        [Description("获取或设置一个值，指示是否要在控件的右边缘显示省略号 (...)"), DefaultValue(false), Category("外观")]
        public virtual bool AutoEllipsis
        {
            get
            {
                return this.duiLabel_0.AutoEllipsis;
            }
            set
            {
                this.duiLabel_0.AutoEllipsis = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), DefaultValue(true)]
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

        protected override ImeMode DefaultImeMode
        {
            get
            {
                return ImeMode.Disable;
            }
        }

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiLabel();
            }
        }

        [DefaultValue(typeof(Color), "Black"), Description("特效颜色"), Category("特效")]
        public Color EffectColor
        {
            get
            {
                return this.duiLabel_0.EffectColor;
            }
            set
            {
                this.duiLabel_0.EffectColor = value;
            }
        }

        [Category("特效"), DefaultValue(5), Description("特效效果值")]
        public int EffectValue
        {
            get
            {
                return this.duiLabel_0.EffectValue;
            }
            set
            {
                this.duiLabel_0.EffectValue = value;
            }
        }

        [DefaultValue(true), Description("是否绘制文字")]
        public virtual bool IsDrawText
        {
            get
            {
                return this.duiLabel_0.IsDrawText;
            }
            set
            {
                this.duiLabel_0.IsDrawText = value;
            }
        }

        [Category("DSkin"), Description("文本对齐方式"), DefaultValue(typeof(ContentAlignment), "TopLeft")]
        public ContentAlignment TextAlign
        {
            get
            {
                return this.duiLabel_0.TextAlign;
            }
            set
            {
                this.duiLabel_0.TextAlign = value;
            }
        }

        [Description("自定义文本刷"), DefaultValue((string) null)]
        public DSkinBrush TextBrush
        {
            get
            {
                return this.duiLabel_0.TextBrush;
            }
            set
            {
                this.duiLabel_0.TextBrush = value;
            }
        }

        [Category("特效"), Description("文字特效"), DefaultValue(0)]
        public TextEffects TextEffect
        {
            get
            {
                return this.duiLabel_0.TextEffect;
            }
            set
            {
                this.duiLabel_0.TextEffect = value;
            }
        }

        [DefaultValue(typeof(Padding), "0,0,0,0"), Category("DSkin"), Description("文字到各个边框的距离")]
        public Padding TextInnerPadding
        {
            get
            {
                return this.duiLabel_0.TextInnerPadding;
            }
            set
            {
                this.duiLabel_0.TextInnerPadding = value;
            }
        }

        [Description("文本渲染模式"), DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Category("DSkin")]
        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.duiLabel_0.TextRenderMode;
            }
            set
            {
                this.duiLabel_0.TextRenderMode = value;
            }
        }
    }
}

