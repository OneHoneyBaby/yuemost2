namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [Designer(typeof(ScrollableControlDesigner))]
    public class DSkinTabPage : TabPage
    {
        private bool bool_0 = true;
        private bool bool_1 = true;
        private Image image_0 = null;
        private Rectangle rectangle_0 = new Rectangle();

        public DSkinTabPage()
        {
            this.Init();
            this.BackColor = Color.Transparent;
            base.UseVisualStyleBackColor = false;
            this.Dock = DockStyle.Fill;
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ContainerControl, true);
        }

        [Description("是否显示关闭按钮"), Category("DSkin"), DefaultValue(true)]
        public bool CloseButtonVisble
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                    if (base.Parent != null)
                    {
                        base.Parent.Invalidate();
                    }
                }
            }
        }

        [Browsable(true), DefaultValue(true), Category("DSkin")]
        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        [Description("图片绘制区域"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Rectangle ImageRectangle
        {
            get
            {
                return this.rectangle_0;
            }
            set
            {
                if (this.rectangle_0 != value)
                {
                    this.rectangle_0 = value;
                    if (base.Parent != null)
                    {
                        base.Parent.Invalidate();
                    }
                }
            }
        }

        [Description("是否能选中当前项"), DefaultValue(typeof(bool), "true"), Category("DSkin")]
        public bool IsSelectTab
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

        [Description("当前Tab选项卡图标"), Category("DSkin")]
        public Image TabItemImage
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
                    if (base.Parent != null)
                    {
                        base.Parent.Invalidate();
                    }
                }
            }
        }
    }
}

