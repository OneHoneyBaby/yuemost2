namespace DSkin.DirectUI
{
    using DSkin.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    public class Borders
    {
        private Color color_0 = Color.Empty;
        private Color color_1 = Color.Empty;
        private Color color_2 = Color.Empty;
        private Color color_3 = Color.Empty;
        private Color color_4 = Color.Empty;
        private DSkinPen dskinPen_0;
        private DSkinPen dskinPen_1;
        private DSkinPen dskinPen_2;
        private DSkinPen dskinPen_3;
        private DuiBaseControl duiBaseControl_0;
        private int int_0 = 1;
        private int int_1 = 1;
        private int int_2 = 1;
        private int int_3 = 1;
        private int int_4 = 1;

        public Borders(DuiBaseControl owner)
        {
            this.duiBaseControl_0 = owner;
        }

        public override string ToString()
        {
            return "DuiControl边框显示模式";
        }

        [DefaultValue(typeof(Color), ""), Description("所有边框颜色")]
        public Color AllColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                if (this.color_4 != value)
                {
                    this.color_4 = value;
                    this.color_2 = value;
                    this.color_0 = value;
                    this.color_3 = value;
                    this.color_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("所有边框宽度"), DefaultValue(1)]
        public int AllWidth
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.int_4 = value;
                    this.int_2 = value;
                    this.int_0 = value;
                    this.int_3 = value;
                    this.int_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), ""), Description("下边框颜色")]
        public Color BottomColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                if (this.color_1 != value)
                {
                    this.color_4 = Color.Empty;
                    this.color_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("下边框笔刷"), DefaultValue((string) null)]
        public DSkinPen BottomPen
        {
            get
            {
                return this.dskinPen_1;
            }
            set
            {
                if (this.dskinPen_1 != value)
                {
                    this.dskinPen_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("下边框宽度"), DefaultValue(1)]
        public int BottomWidth
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), ""), Description("左边框颜色")]
        public Color LeftColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                if (this.color_2 != value)
                {
                    this.color_4 = Color.Empty;
                    this.color_2 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Description("左边框笔刷")]
        public DSkinPen LeftPen
        {
            get
            {
                return this.dskinPen_2;
            }
            set
            {
                if (this.dskinPen_2 != value)
                {
                    this.dskinPen_2 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("左边框宽度"), DefaultValue(1)]
        public int LeftWidth
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (this.int_2 != value)
                {
                    this.int_2 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), ""), Description("右边框颜色")]
        public Color RightColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                if (this.color_3 != value)
                {
                    this.color_4 = Color.Empty;
                    this.color_3 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Description("右边框笔刷")]
        public DSkinPen RightPen
        {
            get
            {
                return this.dskinPen_3;
            }
            set
            {
                if (this.dskinPen_3 != value)
                {
                    this.dskinPen_3 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("右边框宽度"), DefaultValue(1)]
        public int RightWidth
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), ""), Description("上边框颜色")]
        public Color TopColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_4 = Color.Empty;
                    this.color_0 = value;
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [Description("上边框笔刷"), DefaultValue((string) null)]
        public DSkinPen TopPen
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
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }

        [DefaultValue(1), Description("上边框宽度")]
        public int TopWidth
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
                    this.duiBaseControl_0.Invalidate();
                }
            }
        }
    }
}

