namespace DSkin.Controls
{
    using DSkin;
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(ToolStrip))]
    public class DSkinToolStrip : ToolStrip, ILayered
    {
        private Bitmap bitmap_0;
        private bool bool_0 = false;
        private IImageEffect iimageEffect_0;
        [CompilerGenerated]
        private ImageAttributes imageAttributes_0;
        private Rectangle rectangle_0;
        private TabControl tabControl_0;
        private ToolStripColorTable toolStripColorTable_0;

        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public DSkinToolStrip()
        {
            this.Init();
            this.toolStripColorTable_0 = new ToolStripColorTable();
            this.PaintRenderer();
        }

        protected override void Dispose(bool disposing)
        {
            this.DisposeCanvas();
            base.Dispose(disposing);
        }

        public void DisposeCanvas()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        public void Invalidate()
        {
            this.rectangle_0 = new Rectangle(0, 0, base.Width, base.Height);
            base.Invalidate();
        }

        private void method_0(object sender, EventArgs e)
        {
            int num;
            ToolStripButton button = (ToolStripButton) sender;
            if (((button.Checked && (this.tabControl_0 != null)) && int.TryParse(Convert.ToString(button.Tag), out num)) && ((num >= 0) && (num <= (this.tabControl_0.TabPages.Count - 1))))
            {
                foreach (object obj2 in this.Items)
                {
                    if (obj2 is ToolStripButton)
                    {
                        ToolStripButton button2 = (ToolStripButton) obj2;
                        button2.Checked = obj2 == button;
                    }
                }
                this.tabControl_0.SelectedIndex = num;
            }
        }

        private void method_1()
        {
            this.DisposeCanvas();
            if (base.Width < 1)
            {
                base.Width = 1;
            }
            if (base.Height < 1)
            {
                base.Height = 1;
            }
            this.bitmap_0 = new Bitmap(base.Width, base.Height);
            this.rectangle_0 = new Rectangle(0, 0, base.Width, base.Height);
        }

        private void method_2()
        {
            if (!this.rectangle_0.IsEmpty)
            {
                if (this.bitmap_0 != null)
                {
                    Rectangle rect = this.rectangle_0;
                    using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                    {
                        this.PaintControl(graphics, this.rectangle_0);
                    }
                    if (this.iimageEffect_0 != null)
                    {
                        Bitmap bitmap = this.iimageEffect_0.DoImageEffect(rect, this.bitmap_0);
                        if (this.bitmap_0 != bitmap)
                        {
                            this.bitmap_0.Dispose();
                            this.bitmap_0 = bitmap;
                        }
                    }
                }
                else
                {
                    this.method_1();
                    this.method_2();
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.tabControl_0 != null)
            {
                if (!base.DesignMode)
                {
                    if (!(this.tabControl_0 is DSkinTabControl) || base.DesignMode)
                    {
                    }
                    this.tabControl_0.ItemSize = new Size(0, 1);
                }
                this.tabControl_0.SelectedIndexChanged += new EventHandler(this.tabControl_0_SelectedIndexChanged);
                this.tabControl_0_SelectedIndexChanged(this.tabControl_0, null);
            }
        }

        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            base.OnItemAdded(e);
            if ((this.tabControl_0 != null) && (e.Item is ToolStripButton))
            {
                ToolStripButton item = (ToolStripButton) e.Item;
                item.CheckedChanged += new EventHandler(this.method_0);
            }
        }

        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            base.OnItemClicked(e);
            if ((this.tabControl_0 != null) && (e.ClickedItem is ToolStripButton))
            {
                int num;
                ToolStripButton clickedItem = (ToolStripButton) e.ClickedItem;
                if (int.TryParse(Convert.ToString(clickedItem.Tag), out num) && ((num >= 0) && (num <= (this.tabControl_0.TabPages.Count - 1))))
                {
                    clickedItem.Checked = true;
                }
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnRendererChanged(EventArgs e)
        {
            if ((base.RenderMode == ToolStripRenderMode.ManagerRenderMode) || (base.RenderMode == ToolStripRenderMode.Professional))
            {
                base.Renderer = new ProfessionalToolStripRendererEx(this.toolStripColorTable_0);
            }
            base.OnRendererChanged(e);
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            if (this.bool_0)
            {
                g.Clear(base.BackColor);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(base.BackColor))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, base.Width, base.Height));
                }
            }
            if (this.BackgroundImage != null)
            {
                ControlRender.DrawBackgroundImage(g, this.BackgroundImageLayout, this.BackgroundImage, new Rectangle(0, 0, base.Width, base.Height));
            }
            base.Renderer.DrawToolStripBackground(new ToolStripRenderEventArgs(g, this));
            base.Renderer.DrawToolStripBorder(new ToolStripRenderEventArgs(g, this));
            ToolStripButton button = base.GetType().GetProperty("Grip", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null) as ToolStripButton;
            using (Bitmap bitmap = new Bitmap(button.Width, button.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    base.Renderer.DrawGrip(new ToolStripGripRenderEventArgs(graphics, this));
                }
                g.DrawImage(bitmap, button.Bounds.Location);
            }
            foreach (ToolStripItem item in this.Items)
            {
                if (!(!item.Visible || (item.GetCurrentParent() is ToolStripOverflow)) && (invalidateRect.IntersectsWith(item.Bounds) || invalidateRect.Contains(item.Bounds)))
                {
                    Rectangle bounds = item.Bounds;
                    bounds.Intersect(invalidateRect);
                    bounds.Offset(-item.Bounds.Left, -item.Bounds.Top);
                    g.TranslateTransform((float) item.Bounds.X, (float) item.Bounds.Y);
                    System.Type type = item.GetType();
                    Region clip = g.Clip;
                    g.SetClip(bounds);
                    type.GetMethod("OnPaint", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Invoke(item, new object[] { new PaintEventArgs(g, bounds) });
                    g.TranslateTransform((float) -item.Bounds.X, (float) -item.Bounds.Y);
                    g.Clip = clip;
                    if (item is ToolStripControlHost)
                    {
                        ToolStripControlHost host = item as ToolStripControlHost;
                        host.Control.DrawToBitmap(g, host.Bounds);
                    }
                }
            }
            if (base.OverflowButton.HasDropDownItems)
            {
                g.TranslateTransform((float) base.OverflowButton.Bounds.X, (float) base.OverflowButton.Bounds.Y);
                base.Renderer.DrawOverflowButtonBackground(new ToolStripItemRenderEventArgs(g, base.OverflowButton));
                g.TranslateTransform((float) -base.OverflowButton.Bounds.X, (float) -base.OverflowButton.Bounds.Y);
            }
            this.OnLayeredPaint(new PaintEventArgs(g, invalidateRect));
            invalidateRect = new Rectangle();
        }

        public void PaintRenderer()
        {
            if (base.RenderMode != ToolStripRenderMode.System)
            {
                base.Renderer = new ProfessionalToolStripRendererEx(this.toolStripColorTable_0);
            }
        }

        private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TabControl control = (TabControl) sender;
                if (control != null)
                {
                    if (control == this.tabControl_0)
                    {
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            int num2;
                            if ((this.Items[i] is ToolStripButton) && int.TryParse(Convert.ToString(this.Items[i].Tag), out num2))
                            {
                                ToolStripButton button = (ToolStripButton) this.Items[i];
                                button.Checked = num2 == control.SelectedIndex;
                            }
                        }
                    }
                    else
                    {
                        control.SelectedIndexChanged -= new EventHandler(this.tabControl_0_SelectedIndexChanged);
                    }
                }
            }
        }

        [Category("DSkin"), Description("箭头颜色")]
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

        [Category("DSkin"), Description("控件圆角大小")]
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

        [Category("Base"), Description("九宫绘画区域")]
        public Rectangle BackRectangle
        {
            get
            {
                return this.toolStripColorTable_0.BackRectangle;
            }
            set
            {
                this.toolStripColorTable_0.BackRectangle = value;
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

        [Description("Base字体颜色"), Category("Base")]
        public Color BaseFore
        {
            get
            {
                return this.toolStripColorTable_0.BaseFore;
            }
            set
            {
                this.toolStripColorTable_0.BaseFore = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem字体是否有辉光效果"), Category("Base")]
        public bool BaseForeAnamorphosis
        {
            get
            {
                return this.toolStripColorTable_0.BaseForeAnamorphosis;
            }
            set
            {
                this.toolStripColorTable_0.BaseForeAnamorphosis = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem辉光字体光圈大小")]
        public int BaseForeAnamorphosisBorder
        {
            get
            {
                return this.toolStripColorTable_0.BaseForeAnamorphosisBorder;
            }
            set
            {
                this.toolStripColorTable_0.BaseForeAnamorphosisBorder = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem辉光字体光圈颜色")]
        public Color BaseForeAnamorphosisColor
        {
            get
            {
                return this.toolStripColorTable_0.BaseForeAnamorphosisColor;
            }
            set
            {
                this.toolStripColorTable_0.BaseForeAnamorphosisColor = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem文本偏移度")]
        public Point BaseForeOffset
        {
            get
            {
                return this.toolStripColorTable_0.BaseForeOffset;
            }
            set
            {
                this.toolStripColorTable_0.BaseForeOffset = value;
                this.PaintRenderer();
            }
        }

        [Description("Base悬浮时字体颜色"), Category("Base")]
        public Color BaseHoverFore
        {
            get
            {
                return this.toolStripColorTable_0.BaseHoverFore;
            }
            set
            {
                this.toolStripColorTable_0.BaseHoverFore = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("颜色绘制BaseItem时，是否启用颜色渐变效果")]
        public bool BaseItemAnamorphosis
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemAnamorphosis;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemAnamorphosis = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem边框颜色"), Category("Base")]
        public Color BaseItemBorder
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemBorder;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemBorder = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem是否显示边框"), Category("Base")]
        public bool BaseItemBorderShow
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemBorderShow;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemBorderShow = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem按下时背景图")]
        public Image BaseItemDown
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemDown;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemDown = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem悬浮时颜色")]
        public Color BaseItemHover
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemHover;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemHover = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem悬浮时背景图"), Category("Base")]
        public Image BaseItemMouse
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemMouse;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemMouse = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("BaseItem默认背景图")]
        public Image BaseItemNorml
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemNorml;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemNorml = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem点击时颜色"), Category("Base")]
        public Color BaseItemPressed
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemPressed;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemPressed = value;
                this.PaintRenderer();
            }
        }

        [Category("Base"), Description("Base圆角大小")]
        public int BaseItemRadius
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemRadius;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemRadius = (value < 1) ? 1 : value;
                this.PaintRenderer();
            }
        }

        [Description("Base圆角样式"), Category("Base")]
        public RoundStyle BaseItemRadiusStyle
        {
            get
            {
                return this.toolStripColorTable_0.BaseItemRadiusStyle;
            }
            set
            {
                this.toolStripColorTable_0.BaseItemRadiusStyle = value;
                this.PaintRenderer();
            }
        }

        [Description("BaseItem分隔符颜色"), Category("Base")]
        public Color BaseItemSplitter
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

        [Description("绑定要操作的TabControl"), Category("DSkin")]
        public TabControl BindTabControl
        {
            get
            {
                return this.tabControl_0;
            }
            set
            {
                this.tabControl_0 = value;
            }
        }

        [DefaultValue(false), Description("位图缓存模式")]
        public bool BitmapCache
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                if (!this.bool_0)
                {
                    this.DisposeCanvas();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Bitmap Canvas
        {
            get
            {
                if (this.bitmap_0 == null)
                {
                    this.method_1();
                }
                this.method_2();
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }

        [Description("弹出菜单分隔符与边框的颜色"), Category("DSkin")]
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

        [Category("DSkin"), Description("控件字体颜色")]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ImageAttributes ImageAttribute
        {
            [CompilerGenerated]
            get
            {
                return this.imageAttributes_0;
            }
            [CompilerGenerated]
            set
            {
                this.imageAttributes_0 = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IImageEffect ImageEffect
        {
            get
            {
                return this.iimageEffect_0;
            }
            set
            {
                if (this.iimageEffect_0 != value)
                {
                    this.iimageEffect_0 = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Item"), Description("Item是否启用渐变")]
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

        [Category("Item"), Description("Item边框颜色")]
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

        [Description("Item是否显示边框"), Category("Item")]
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

        [Description("Item圆角大小"), Category("Item")]
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

        [Description("Item圆角样式"), Category("Item")]
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

        [Category("DSkin"), DefaultValue(typeof(TextRenderingHint), "SystemDefault"), Description("文本渲染模式")]
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

        [Description("菜单标头背景色是否启用渐变"), Category("Title")]
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

        [Description("标题分割线颜色"), Category("Title"), DefaultValue(typeof(Color), "Transparent")]
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

        [Description("菜单标头圆角大小"), Category("Title")]
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

