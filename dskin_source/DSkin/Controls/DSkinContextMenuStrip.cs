namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ContextMenuStrip))]
    public class DSkinContextMenuStrip : ContextMenuStrip
    {
        private ToolStripColorTable toolStripColorTable_0;

        public DSkinContextMenuStrip()
        {
            this.Init();
            this.toolStripColorTable_0 = new ToolStripColorTable();
            this.PaintRenderer();
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        protected override void OnRendererChanged(EventArgs e)
        {
            if ((base.RenderMode == ToolStripRenderMode.ManagerRenderMode) || (base.RenderMode == ToolStripRenderMode.Professional))
            {
                base.Renderer = new ProfessionalToolStripRendererEx(this.toolStripColorTable_0);
            }
            base.OnRendererChanged(e);
        }

        public void PaintRenderer()
        {
            if (base.RenderMode != ToolStripRenderMode.System)
            {
                base.Renderer = new ProfessionalToolStripRendererEx(this.toolStripColorTable_0);
            }
        }

        [Description("箭头颜色"), Category("DSkin")]
        public Color Arrow
        {
            get
            {
                return this.toolStripColorTable_0.Arrow;
            }
            set
            {
                this.toolStripColorTable_0.Arrow = value;
                this.PaintRenderer();
            }
        }

        [Description("控件背景色"), Category("DSkin")]
        public Color Back
        {
            get
            {
                return this.toolStripColorTable_0.Back;
            }
            set
            {
                this.toolStripColorTable_0.Back = value;
                this.PaintRenderer();
            }
        }

        [Description("控件圆角大小"), Category("DSkin")]
        public int BackRadius
        {
            get
            {
                return this.toolStripColorTable_0.BackRadius;
            }
            set
            {
                this.toolStripColorTable_0.BackRadius = (value < 1) ? 1 : value;
                this.PaintRenderer();
            }
        }

        [Description("Base背景颜色"), Category("Base")]
        public Color Base
        {
            get
            {
                return this.toolStripColorTable_0.Base;
            }
            set
            {
                this.toolStripColorTable_0.Base = value;
                this.PaintRenderer();
            }
        }

        [Category("DSkin"), Description("弹出菜单分隔符与边框的颜色")]
        public Color DropDownImageSeparator
        {
            get
            {
                return this.toolStripColorTable_0.DropDownImageSeparator;
            }
            set
            {
                this.toolStripColorTable_0.DropDownImageSeparator = value;
                this.PaintRenderer();
            }
        }

        [Description("控件字体颜色"), Category("DSkin")]
        public Color Fore
        {
            get
            {
                return this.toolStripColorTable_0.Fore;
            }
            set
            {
                this.toolStripColorTable_0.Fore = value;
                this.PaintRenderer();
            }
        }

        [Category("DSkin"), Description("控件悬浮时字体颜色")]
        public Color HoverFore
        {
            get
            {
                return this.toolStripColorTable_0.HoverFore;
            }
            set
            {
                this.toolStripColorTable_0.HoverFore = value;
                this.PaintRenderer();
            }
        }

        [Description("Item是否启用渐变"), Category("Item")]
        public bool ItemAnamorphosis
        {
            get
            {
                return this.toolStripColorTable_0.ItemAnamorphosis;
            }
            set
            {
                this.toolStripColorTable_0.ItemAnamorphosis = value;
                this.PaintRenderer();
            }
        }

        [Description("Item边框颜色"), Category("Item")]
        public Color ItemBorder
        {
            get
            {
                return this.toolStripColorTable_0.ItemBorder;
            }
            set
            {
                this.toolStripColorTable_0.ItemBorder = value;
                this.PaintRenderer();
            }
        }

        [Description("Item背景色是否启用渐变"), Category("Item")]
        public bool ItemBorderShow
        {
            get
            {
                return this.toolStripColorTable_0.ItemBorderShow;
            }
            set
            {
                this.toolStripColorTable_0.ItemBorderShow = value;
                this.PaintRenderer();
            }
        }

        [Category("Item"), Description("Item悬浮时背景色")]
        public Color ItemHover
        {
            get
            {
                return this.toolStripColorTable_0.ItemHover;
            }
            set
            {
                this.toolStripColorTable_0.ItemHover = value;
                this.PaintRenderer();
            }
        }

        [Description("Item按下时背景色"), Category("Item")]
        public Color ItemPressed
        {
            get
            {
                return this.toolStripColorTable_0.ItemPressed;
            }
            set
            {
                this.toolStripColorTable_0.ItemPressed = value;
                this.PaintRenderer();
            }
        }

        [Category("Item"), Description("Item圆角大小")]
        public int ItemRadius
        {
            get
            {
                return this.toolStripColorTable_0.ItemRadius;
            }
            set
            {
                this.toolStripColorTable_0.ItemRadius = (value < 1) ? 1 : value;
                this.PaintRenderer();
            }
        }

        [Category("Item"), Description("Item圆角样式")]
        public RoundStyle ItemRadiusStyle
        {
            get
            {
                return this.toolStripColorTable_0.ItemRadiusStyle;
            }
            set
            {
                this.toolStripColorTable_0.ItemRadiusStyle = value;
                this.PaintRenderer();
            }
        }

        [Category("Item"), Description("Item分隔符颜色")]
        public Color ItemSplitter
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemSplitter;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemSplitter = value;
                this.PaintRenderer();
            }
        }

        [Category("DSkin"), Description("控件圆角样式")]
        public RoundStyle RadiusStyle
        {
            get
            {
                return this.toolStripColorTable_0.RadiusStyle;
            }
            set
            {
                this.toolStripColorTable_0.RadiusStyle = value;
                this.PaintRenderer();
            }
        }

        [Description("字体颜色是否统一变换"), Category("DSkin")]
        public bool SkinAllColor
        {
            get
            {
                return this.toolStripColorTable_0.SkinAllColor;
            }
            set
            {
                this.toolStripColorTable_0.SkinAllColor = value;
                this.PaintRenderer();
            }
        }

        [DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Category("DSkin"), Description("文本渲染模式")]
        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.toolStripColorTable_0.TextRenderMode;
            }
            set
            {
                this.toolStripColorTable_0.TextRenderMode = value;
                this.PaintRenderer();
            }
        }

        [Category("Title"), Description("菜单标头背景色是否启用渐变")]
        public bool TitleAnamorphosis
        {
            get
            {
                return this.toolStripColorTable_0.TitleAnamorphosis;
            }
            set
            {
                this.toolStripColorTable_0.TitleAnamorphosis = value;
                this.PaintRenderer();
            }
        }

        [Description("菜单标头背景色"), Category("Title")]
        public Color TitleColor
        {
            get
            {
                return this.toolStripColorTable_0.TitleColor;
            }
            set
            {
                this.toolStripColorTable_0.TitleColor = value;
                this.PaintRenderer();
            }
        }

        [Category("Title"), Description("标题分割线颜色"), DefaultValue(typeof(Color), "Transparent")]
        public Color TitleLineColor
        {
            get
            {
                return this.toolStripColorTable_0.TitleLineColor;
            }
            set
            {
                if (this.toolStripColorTable_0.TitleLineColor != value)
                {
                    this.toolStripColorTable_0.TitleLineColor = value;
                    this.PaintRenderer();
                }
            }
        }

        [Category("Title"), Description("菜单标头圆角大小")]
        public int TitleRadius
        {
            get
            {
                return this.toolStripColorTable_0.TitleRadius;
            }
            set
            {
                this.toolStripColorTable_0.TitleRadius = (value < 1) ? 1 : value;
                this.PaintRenderer();
            }
        }

        [Description("菜单标头圆角样式"), Category("Title")]
        public RoundStyle TitleRadiusStyle
        {
            get
            {
                return this.toolStripColorTable_0.TitleRadiusStyle;
            }
            set
            {
                this.toolStripColorTable_0.TitleRadiusStyle = value;
                this.PaintRenderer();
            }
        }
    }
}

