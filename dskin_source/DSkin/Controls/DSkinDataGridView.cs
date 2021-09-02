namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(DataGridView))]
    public class DSkinDataGridView : DataGridView
    {
        private bool bool_0 = true;
        private bool bool_1 = false;
        private bool bool_2 = true;
        private Color color_0 = Color.FromArgb(0x53, 0xc4, 0xf2);
        private Color color_1 = Color.White;
        private Color color_2 = Color.FromArgb(0xc5, 0xeb, 0xfc);
        private Color color_3 = Color.Blue;
        private Color color_4;
        private cScrollBar cScrollBar_0;
        private cScrollBar cScrollBar_1;
        private IContainer icontainer_0 = null;
        private Image image_0;
        private Rectangle rectangle_0 = new Rectangle(10, 10, 10, 10);

        public DSkinDataGridView()
        {
            this.method_1();
            this.Init();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Init()
        {
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.Selectable, true);
            base.UpdateStyles();
            base.EnableHeadersVisualStyles = false;
            base.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xf7, 0xf6, 0xef);
            base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            base.ColumnHeadersHeight = 0x1a;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            base.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnForeColor = SystemColors.WindowText;
            this.ColumnSelectBackColor = SystemColors.Highlight;
            this.ColumnSelectForeColor = SystemColors.HighlightText;
            base.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.DefaultCellBackColor = SystemColors.Window;
            base.RowHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            base.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            base.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0x3b, 0xbc, 240);
            base.DefaultCellStyle.SelectionForeColor = Color.White;
            base.DefaultCellStyle.BackColor = Color.White;
            base.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SkinGridColor = SystemColors.GradientActiveCaption;
            base.BackgroundColor = SystemColors.Window;
            base.BorderStyle = BorderStyle.Fixed3D;
            this.AlternatingCellBackColor = Color.FromArgb(0xe7, 0xf6, 0xfd);
        }

        private void method_0()
        {
            System.Type type = typeof(DataGridView);
            FieldInfo field = type.GetField("vertScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                ScrollBar bar = field.GetValue(this) as ScrollBar;
                if (bar != null)
                {
                    this.cScrollBar_0 = new cScrollBar(bar.Handle, Orientation.Vertical, (Bitmap) ScrollBarDrawImage.ScrollVertThumb.Clone(), (Bitmap) ScrollBarDrawImage.ScrollVertShaft.Clone(), (Bitmap) ScrollBarDrawImage.ScrollVertArrow.Clone(), (Bitmap) ScrollBarDrawImage.Fader.Clone());
                    field = type.GetField("horizScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (field != null)
                    {
                        bar = field.GetValue(this) as ScrollBar;
                        if (bar != null)
                        {
                            this.cScrollBar_1 = new cScrollBar(bar.Handle, Orientation.Horizontal, (Bitmap) ScrollBarDrawImage.ScrollHorzThumb.Clone(), (Bitmap) ScrollBarDrawImage.ScrollHorzShaft.Clone(), (Bitmap) ScrollBarDrawImage.ScrollHorzArrow.Clone(), (Bitmap) ScrollBarDrawImage.Fader.Clone());
                        }
                    }
                }
            }
        }

        private void method_1()
        {
            this.icontainer_0 = new Container();
        }

        [CompilerGenerated]
        private void method_2()
        {
            if (!(base.DesignMode || !this.bool_0))
            {
                this.method_0();
            }
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            if ((e.RowIndex > -1) && (base.Rows.Count > e.RowIndex))
            {
                this.color_4 = base.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            if ((e.RowIndex > -1) && (base.Rows.Count > e.RowIndex))
            {
                base.Rows[e.RowIndex].DefaultCellStyle.BackColor = this.color_4;
            }
        }

        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseMove(e);
            if ((e.RowIndex > -1) && (base.Rows.Count > e.RowIndex))
            {
                base.Rows[e.RowIndex].DefaultCellStyle.BackColor = this.MouseCellBackColor;
            }
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex != -1) && (e.ColumnIndex != -1))
            {
                goto Label_0101;
            }
            if (this.TitleBack == null)
            {
                using (Brush brush = new LinearGradientBrush(e.CellBounds, this.TitleBackColorBegin, this.TitleBackColorEnd, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                    goto Label_00EC;
                }
            }
            if (this.TitlePalace)
            {
                ImageDrawRect.DrawRect(e.Graphics, (Bitmap) this.TitleBack, e.CellBounds, Rectangle.FromLTRB(this.TitleBackRectangle.X, this.TitleBackRectangle.Y, this.TitleBackRectangle.Width, this.TitleBackRectangle.Height), 1, 1);
            }
            else
            {
                e.Graphics.DrawImage((Bitmap) this.TitleBack, e.CellBounds);
            }
        Label_00EC:
            e.Paint(e.ClipBounds, DataGridViewPaintParts.SelectionBackground | DataGridViewPaintParts.Focus | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.Border);
            e.Handled = true;
        Label_0101:
            base.OnCellPainting(e);
        }

        protected override void OnCreateControl()
        {
            if (!base.DesignMode)
            {
                Class13.smethod_5();
            }
            else
            {
                Class13.smethod_2();
                if (!Class13.smethod_0())
                {
                    base.Dispose();
                    return;
                }
            }
            base.OnCreateControl();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            base.BeginInvoke(new MethodInvoker(this.method_2));
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (!base.DesignMode)
            {
                if (this.cScrollBar_0 != null)
                {
                    this.cScrollBar_0.Dispose();
                }
                if (this.cScrollBar_1 != null)
                {
                    this.cScrollBar_1.Dispose();
                }
            }
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if (this.LineNumber)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                Rectangle bounds = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, base.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), base.RowHeadersDefaultCellStyle.Font, bounds, this.LineNumberForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }

        [Description("奇数行颜色"), Category("Cell"), DefaultValue(typeof(Color), "231, 246, 253")]
        public Color AlternatingCellBackColor
        {
            get
            {
                return base.AlternatingRowsDefaultCellStyle.BackColor;
            }
            set
            {
                base.AlternatingRowsDefaultCellStyle.BackColor = value;
                base.Invalidate();
            }
        }

        [Category("Column"), Description("行单元格中文本的字体")]
        public System.Drawing.Font ColumnFont
        {
            get
            {
                return base.RowsDefaultCellStyle.Font;
            }
            set
            {
                base.RowsDefaultCellStyle.Font = value;
                base.Invalidate();
            }
        }

        [Description("行单元格字体颜色"), DefaultValue(typeof(Color), "WindowText"), Category("Column")]
        public Color ColumnForeColor
        {
            get
            {
                return base.RowsDefaultCellStyle.ForeColor;
            }
            set
            {
                base.RowsDefaultCellStyle.ForeColor = value;
                base.Invalidate();
            }
        }

        [Description("行单元格被选中时的背景颜色"), DefaultValue(typeof(Color), "Highlight"), Category("Column")]
        public Color ColumnSelectBackColor
        {
            get
            {
                return base.RowsDefaultCellStyle.SelectionBackColor;
            }
            set
            {
                base.RowsDefaultCellStyle.SelectionBackColor = value;
                base.Invalidate();
            }
        }

        [Description("行单元格被选中时的字体颜色"), Category("Column"), DefaultValue(typeof(Color), "WindowText")]
        public Color ColumnSelectForeColor
        {
            get
            {
                return base.RowsDefaultCellStyle.SelectionForeColor;
            }
            set
            {
                base.RowsDefaultCellStyle.SelectionForeColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White"), Category("Cell"), Description("默认行颜色")]
        public Color DefaultCellBackColor
        {
            get
            {
                return base.DefaultCellStyle.BackColor;
            }
            set
            {
                base.DefaultCellStyle.BackColor = value;
                base.Invalidate();
            }
        }

        [Category("DSKin"), DefaultValue(true), Description("是否启用滚动条美化")]
        public bool EnabledScrollbarBeautify
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

        [Category("Skin"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Description("用于显示控件中文本的字体。")]
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

        [Description("标题行单元格中文本的字体"), Category("Title")]
        public System.Drawing.Font HeadFont
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.Font;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.Font = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "WindowText"), Description("标题行单元格字体颜色"), Category("Title")]
        public Color HeadForeColor
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.ForeColor;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.ForeColor = value;
                base.Invalidate();
            }
        }

        [Category("Title"), Description("标题行单元格被选中时的背景颜色"), DefaultValue(typeof(Color), "Highlight")]
        public Color HeadSelectBackColor
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.SelectionBackColor;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.SelectionBackColor = value;
                base.Invalidate();
            }
        }

        [Category("Title"), Description("标题行单元格被选中时的字体颜色"), DefaultValue(typeof(Color), "WindowText")]
        public Color HeadSelectForeColor
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.SelectionForeColor;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.SelectionForeColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(bool), "true"), Description("是否显示行号"), Category("LineNumber")]
        public bool LineNumber
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Blue"), Description("行号字体颜色"), Category("LineNumber")]
        public Color LineNumberForeColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
                base.Invalidate();
            }
        }

        [Description("悬浮行颜色"), Category("Cell"), DefaultValue(typeof(Color), "197, 235, 252")]
        public Color MouseCellBackColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
                base.Invalidate();
            }
        }

        [Category("Skin"), Description("网格线的颜色"), DefaultValue(typeof(Color), "GradientActiveCaption")]
        public Color SkinGridColor
        {
            get
            {
                return base.GridColor;
            }
            set
            {
                base.GridColor = value;
                base.Invalidate();
            }
        }

        [Description("标题背景"), Category("Title")]
        public Image TitleBack
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
                    base.Invalidate();
                }
            }
        }

        [Description("标题行渐变背景色"), DefaultValue(typeof(Color), "Title"), Category("Title")]
        public Color TitleBackColorBegin
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Title"), Description("标题行背景色"), Category("Title")]
        public Color TitleBackColorEnd
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
            }
        }

        [Category("Title"), Description("标题背景九宫绘画区域"), DefaultValue(typeof(Rectangle), "10,10,10,10")]
        public Rectangle TitleBackRectangle
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
                }
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(bool), "false"), Description("标题背景是否开启九宫绘图"), Category("Title")]
        public bool TitlePalace
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    base.Invalidate();
                }
            }
        }
    }
}

