namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;

    public class DSkinIcon : DSkinLabel
    {
        private DuiIcon duiIcon_0;

        public DSkinIcon()
        {
            this.duiIcon_0 = (DuiIcon) base.InnerDuiControl;
            this.AutoSize = true;
            this.Icon = FontAwesomeChars.icon_star;
        }

        [DefaultValue(true)]
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

        protected override DuiBaseControl DuiControl
        {
            get
            {
                return new DuiIcon();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [DefaultValue(3), Category("Icon"), Description("尺寸单位")]
        public System.Drawing.GraphicsUnit GraphicsUnit
        {
            get
            {
                return this.duiIcon_0.GraphicsUnit;
            }
            set
            {
                this.duiIcon_0.GraphicsUnit = value;
            }
        }

        [Category("Icon"), Description("图标"), DefaultValue(0x20), Editor("DSkin.Design.FontAwesomeCharsEditor", typeof(UITypeEditor))]
        public FontAwesomeChars Icon
        {
            get
            {
                return this.duiIcon_0.Icon;
            }
            set
            {
                this.duiIcon_0.Icon = value;
            }
        }

        [DefaultValue((float) 12f), Description("图标尺寸"), Category("Icon")]
        public float IconSize
        {
            get
            {
                return this.duiIcon_0.IconSize;
            }
            set
            {
                this.duiIcon_0.IconSize = value;
            }
        }

        [Category("Icon"), Description("图标样式"), DefaultValue(0)]
        public FontStyle IconStyle
        {
            get
            {
                return this.duiIcon_0.IconStyle;
            }
            set
            {
                this.duiIcon_0.IconStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}

