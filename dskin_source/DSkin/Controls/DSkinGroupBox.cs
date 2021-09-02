namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(GroupBox))]
    public class DSkinGroupBox : DSkinPanel
    {
        private Color color_0 = Color.Black;
        private Color color_1 = Color.Black;
        private DSkinPen dskinPen_0;
        private int int_0 = 10;
        private System.Drawing.Text.TextRenderingHint textRenderingHint_0 = System.Drawing.Text.TextRenderingHint.SystemDefault;

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            Pen pen;
            int num = this.Font.Height / 2;
            base.OnLayeredPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = this.textRenderingHint_0;
            if (this.dskinPen_0 != null)
            {
                pen = this.BorderPen.Pen;
            }
            else
            {
                pen = new Pen(this.color_1, 1f);
            }
            int width = base.Width;
            int height = base.Height;
            graphics.DrawLine(pen, (int) (this.int_0 / 2), (int) (height - 1), (int) (width - (this.int_0 / 2)), (int) (height - 1));
            graphics.DrawLine(pen, 0, height - (this.int_0 / 2), 0, (this.int_0 / 2) + num);
            graphics.DrawLine(pen, (int) (width - 1), (int) (height - (this.int_0 / 2)), (int) (width - 1), (int) ((this.int_0 / 2) + num));
            graphics.DrawLine(pen, this.int_0 / 2, num, (this.int_0 / 2) + 5, num);
            graphics.DrawLine(pen, graphics.MeasureString(this.Text, this.Font).Width + (this.int_0 / 2), (float) num, (float) (width - (this.int_0 / 2)), (float) num);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb((this.ForeColor.A == 0xff) ? 0xfe : this.ForeColor.A, this.ForeColor)))
            {
                graphics.DrawString(this.Text, this.Font, brush, (float) ((this.int_0 / 2) + 5), 0f);
            }
            if (this.int_0 > 0)
            {
                graphics.DrawArc(pen, new Rectangle(0, num, this.int_0, this.int_0), 180f, 90f);
                graphics.DrawArc(pen, new Rectangle((width - this.int_0) - 1, num, this.int_0, this.int_0), 270f, 90f);
                graphics.DrawArc(pen, new Rectangle(0, (height - this.int_0) - 1, this.int_0, this.int_0), 90f, 90f);
                graphics.DrawArc(pen, new Rectangle((width - this.int_0) - 1, (height - this.int_0) - 1, this.int_0, this.int_0), 0f, 90f);
            }
            if (this.dskinPen_0 == null)
            {
                pen.Dispose();
            }
        }

        [Description("边框颜色"), DefaultValue(typeof(Color), "Black"), Category("DSkin")]
        public Color BorderColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_1 = value;
                    base.Invalidate();
                }
            }
        }

        [Description("边框画笔"), Category("DSkin"), DefaultValue((string) null)]
        public DSkinPen BorderPen
        {
            get
            {
                return this.dskinPen_0;
            }
            set
            {
                if (this.dskinPen_0 != value)
                {
                    this.dskinPen_0 = value;
                    base.Invalidate();
                }
            }
        }

        [Description("圆角大小，0以上，包括0"), Category("DSkin"), DefaultValue(10)]
        public virtual int Radius
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    base.Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
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

        [Category("DSkin"), Description("文字渲染模式"), DefaultValue(0)]
        public virtual System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    base.Invalidate();
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TxtColor
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
                    this.ForeColor = value;
                }
            }
        }
    }
}

