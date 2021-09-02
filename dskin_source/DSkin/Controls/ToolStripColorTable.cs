namespace DSkin.Controls
{
    using DSkin.Common;
    using System;
    using System.Drawing;
    using System.Drawing.Text;

    public class ToolStripColorTable
    {
        private bool bool_0 = true;
        private bool bool_1 = true;
        private bool bool_2 = true;
        private bool bool_3 = true;
        private bool bool_4 = true;
        private bool bool_5 = false;
        private bool bool_6 = true;
        private Color color_0 = Color.FromArgb(0x69, 200, 0xfe);
        private Color color_1 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_10 = Color.Black;
        private Color color_11 = Color.White;
        private Color color_12 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_13 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_14 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_15 = Color.White;
        private Color color_16 = Color.Transparent;
        private Color color_2 = Color.White;
        private Color color_3 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_4 = Color.FromArgb(60, 0x94, 0xd4);
        private Color color_5 = Color.Black;
        private Color color_6 = Color.FromArgb(0xc5, 0xc5, 0xc5);
        private Color color_7 = Color.FromArgb(0xd1, 0xe4, 0xec);
        private Color color_8 = Color.White;
        private Color color_9 = Color.Black;
        private Image image_0 = Resources.smethod_3();
        private Image image_1 = Resources.smethod_2();
        private Image image_2 = null;
        private int int_0 = 4;
        private int int_1 = 4;
        private int int_2 = 4;
        private int int_3 = 4;
        private int int_4 = 4;
        private Point point_0 = new Point(0, 0);
        private Rectangle rectangle_0 = new Rectangle(10, 10, 10, 10);
        private RoundStyle roundStyle_0 = RoundStyle.All;
        private RoundStyle roundStyle_1 = RoundStyle.All;
        private RoundStyle roundStyle_2 = RoundStyle.All;
        private RoundStyle roundStyle_3 = RoundStyle.All;
        private TextRenderingHint textRenderingHint_0 = TextRenderingHint.SystemDefault;
        private Color WwGiQfojvf = Color.FromArgb(60, 0x94, 0xd4);

        public Color Arrow
        {
            get
            {
                return this.color_9;
            }
            set
            {
                this.color_9 = value;
            }
        }

        public Color Back
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        public int BackRadius
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        public Rectangle BackRectangle
        {
            get
            {
                return this.rectangle_0;
            }
            set
            {
                this.rectangle_0 = value;
            }
        }

        public Color Base
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        public Color BaseFore
        {
            get
            {
                return this.color_10;
            }
            set
            {
                this.color_10 = value;
            }
        }

        public bool BaseForeAnamorphosis
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
            }
        }

        public int BaseForeAnamorphosisBorder
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public Color BaseForeAnamorphosisColor
        {
            get
            {
                return this.color_15;
            }
            set
            {
                this.color_15 = value;
            }
        }

        public Point BaseForeOffset
        {
            get
            {
                return this.point_0;
            }
            set
            {
                this.point_0 = value;
            }
        }

        public Color BaseHoverFore
        {
            get
            {
                return this.color_11;
            }
            set
            {
                this.color_11 = value;
            }
        }

        public bool BaseItemAnamorphosis
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
            }
        }

        public Color BaseItemBorder
        {
            get
            {
                return this.color_12;
            }
            set
            {
                this.color_12 = value;
            }
        }

        public bool BaseItemBorderShow
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        public Image BaseItemDown
        {
            get
            {
                return this.image_1;
            }
            set
            {
                this.image_1 = value;
            }
        }

        public Color BaseItemHover
        {
            get
            {
                return this.color_13;
            }
            set
            {
                this.color_13 = value;
            }
        }

        public Image BaseItemMouse
        {
            get
            {
                return this.image_0;
            }
            set
            {
                this.image_0 = value;
            }
        }

        public Image BaseItemNorml
        {
            get
            {
                return this.image_2;
            }
            set
            {
                this.image_2 = value;
            }
        }

        public Color BaseItemPressed
        {
            get
            {
                return this.WwGiQfojvf;
            }
            set
            {
                this.WwGiQfojvf = value;
            }
        }

        public int BaseItemRadius
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public RoundStyle BaseItemRadiusStyle
        {
            get
            {
                return this.roundStyle_3;
            }
            set
            {
                this.roundStyle_3 = value;
            }
        }

        public Color BaseItemSplitter
        {
            get
            {
                return this.color_14;
            }
            set
            {
                this.color_14 = value;
            }
        }

        public Color DropDownImageSeparator
        {
            get
            {
                return this.color_6;
            }
            set
            {
                this.color_6 = value;
            }
        }

        public Color Fore
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
            }
        }

        public Color HoverFore
        {
            get
            {
                return this.color_8;
            }
            set
            {
                this.color_8 = value;
            }
        }

        public bool ItemAnamorphosis
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

        public Color ItemBorder
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        public bool ItemBorderShow
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        public Color ItemHover
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
            }
        }

        public Color ItemPressed
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
            }
        }

        public int ItemRadius
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public RoundStyle ItemRadiusStyle
        {
            get
            {
                return this.roundStyle_2;
            }
            set
            {
                this.roundStyle_2 = value;
            }
        }

        public RoundStyle RadiusStyle
        {
            get
            {
                return this.roundStyle_0;
            }
            set
            {
                this.roundStyle_0 = value;
            }
        }

        public bool SkinAllColor
        {
            get
            {
                return this.bool_6;
            }
            set
            {
                this.bool_6 = value;
            }
        }

        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                this.textRenderingHint_0 = value;
            }
        }

        public bool TitleAnamorphosis
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

        public Color TitleColor
        {
            get
            {
                return this.color_7;
            }
            set
            {
                this.color_7 = value;
            }
        }

        public Color TitleLineColor
        {
            get
            {
                return this.color_16;
            }
            set
            {
                this.color_16 = value;
            }
        }

        public int TitleRadius
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }

        public RoundStyle TitleRadiusStyle
        {
            get
            {
                return this.roundStyle_1;
            }
            set
            {
                this.roundStyle_1 = value;
            }
        }
    }
}

