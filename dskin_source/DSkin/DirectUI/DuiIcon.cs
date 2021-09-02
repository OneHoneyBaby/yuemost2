namespace DSkin.DirectUI
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;

    public class DuiIcon : DuiLabel
    {
        private float float_1 = 12f;
        private FontAwesomeChars fontAwesomeChars_0 = FontAwesomeChars.none;
        private FontStyle fontStyle_0 = FontStyle.Regular;
        private System.Drawing.GraphicsUnit graphicsUnit_0 = System.Drawing.GraphicsUnit.Point;

        public DuiIcon()
        {
            base.Font = new System.Drawing.Font(FontHelper.FontAwesome, 12f);
            this.Size = new Size(12, 12);
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [DefaultValue(3), Description("尺寸单位"), Category("Icon")]
        public System.Drawing.GraphicsUnit GraphicsUnit
        {
            get
            {
                return this.graphicsUnit_0;
            }
            set
            {
                if (this.graphicsUnit_0 != value)
                {
                    this.graphicsUnit_0 = value;
                    base.Font = new System.Drawing.Font(FontHelper.FontAwesome, this.float_1, this.fontStyle_0, this.graphicsUnit_0);
                    this.Invalidate();
                }
            }
        }

        [Category("Icon"), Description("图标"), Editor("DSkin.Design.FontAwesomeCharsEditor", typeof(UITypeEditor)), DefaultValue(0x20)]
        public FontAwesomeChars Icon
        {
            get
            {
                return this.fontAwesomeChars_0;
            }
            set
            {
                if (this.fontAwesomeChars_0 != value)
                {
                    this.fontAwesomeChars_0 = value;
                    base.Text = ((char) ((ushort) this.fontAwesomeChars_0)).ToString();
                }
            }
        }

        [Category("Icon"), DefaultValue((float) 12f), Description("图标尺寸")]
        public float IconSize
        {
            get
            {
                return this.float_1;
            }
            set
            {
                if (this.float_1 != value)
                {
                    this.float_1 = value;
                    base.Font = new System.Drawing.Font(FontHelper.FontAwesome, this.float_1, this.fontStyle_0, this.graphicsUnit_0);
                }
            }
        }

        [DefaultValue(0), Category("Icon"), Description("图标样式")]
        public FontStyle IconStyle
        {
            get
            {
                return this.fontStyle_0;
            }
            set
            {
                if (this.fontStyle_0 != value)
                {
                    this.fontStyle_0 = value;
                    base.Font = new System.Drawing.Font(FontHelper.FontAwesome, this.float_1, this.fontStyle_0, this.graphicsUnit_0);
                }
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

