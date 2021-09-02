namespace DSkin.Html.Core.Dom
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Collections.Generic;

    public sealed class CssLineBox
    {
        private readonly CssBox cssBox_0;
        private readonly Dictionary<CssBox, RRect> dictionary_0 = new Dictionary<CssBox, RRect>();
        private readonly List<CssRect> list_0 = new List<CssRect>();
        private readonly List<CssBox> list_1 = new List<CssBox>();

        public CssLineBox(CssBox ownerBox)
        {
            this.cssBox_0 = ownerBox;
            this.cssBox_0.LineBoxes.Add(this);
        }

        public bool IsLastSelectedWord(CssRect word)
        {
            for (int i = 0; i < (this.list_0.Count - 1); i++)
            {
                if (this.list_0[i] == word)
                {
                    return !this.list_0[i + 1].Selected;
                }
            }
            return true;
        }

        internal void method_0(CssRect cssRect_0)
        {
            if (!this.Words.Contains(cssRect_0))
            {
                this.Words.Add(cssRect_0);
            }
            if (!this.RelatedBoxes.Contains(cssRect_0.OwnerBox))
            {
                this.RelatedBoxes.Add(cssRect_0.OwnerBox);
            }
        }

        internal List<CssRect> method_1(CssBox cssBox_1)
        {
            List<CssRect> list = new List<CssRect>();
            foreach (CssRect rect in this.Words)
            {
                if (rect.OwnerBox.Equals(cssBox_1))
                {
                    list.Add(rect);
                }
            }
            return list;
        }

        internal void method_2(CssBox cssBox_1, double double_0, double double_1, double double_2, double double_3)
        {
            double num = cssBox_1.ActualBorderLeftWidth + cssBox_1.ActualPaddingLeft;
            double num2 = cssBox_1.ActualBorderRightWidth + cssBox_1.ActualPaddingRight;
            double num3 = cssBox_1.ActualBorderTopWidth + cssBox_1.ActualPaddingTop;
            double num4 = cssBox_1.ActualBorderBottomWidth + cssBox_1.ActualPaddingTop;
            if (!(((cssBox_1.FirstHostingLineBox == null) || !cssBox_1.FirstHostingLineBox.Equals(this)) ? !cssBox_1.IsImage : false))
            {
                double_0 -= num;
            }
            if (!(((cssBox_1.LastHostingLineBox == null) || !cssBox_1.LastHostingLineBox.Equals(this)) ? !cssBox_1.IsImage : false))
            {
                double_2 += num2;
            }
            if (!cssBox_1.IsImage)
            {
                double_1 -= num3;
                double_3 += num4;
            }
            if (!this.Rectangles.ContainsKey(cssBox_1))
            {
                this.Rectangles.Add(cssBox_1, RRect.FromLTRB(double_0, double_1, double_2, double_3));
            }
            else
            {
                RRect rect = this.Rectangles[cssBox_1];
                double left = Math.Min(rect.X, double_0);
                double top = Math.Min(rect.Y, double_1);
                double right = Math.Max(rect.Right, double_2);
                this.Rectangles[cssBox_1] = RRect.FromLTRB(left, top, right, Math.Max(rect.Bottom, double_3));
            }
            if ((cssBox_1.ParentBox != null) && cssBox_1.ParentBox.IsInline)
            {
                this.method_2(cssBox_1.ParentBox, double_0, double_1, double_2, double_3);
            }
        }

        internal void method_3()
        {
            foreach (CssBox box in this.Rectangles.Keys)
            {
                box.Rectangles.Add(this, this.Rectangles[box]);
            }
        }

        internal void method_4(RGraphics rgraphics_0, CssBox cssBox_1, double double_0)
        {
            List<CssRect> list = this.method_1(cssBox_1);
            if (this.Rectangles.ContainsKey(cssBox_1))
            {
                RRect rect2 = this.Rectangles[cssBox_1];
                double num2 = 0.0;
                if (list.Count > 0)
                {
                    num2 = list[0].Top - rect2.Top;
                }
                else
                {
                    CssRect rect = cssBox_1.method_2(cssBox_1, this);
                    if (rect != null)
                    {
                        num2 = rect.Top - rect2.Top;
                    }
                }
                double num = double_0;
                if (((cssBox_1.ParentBox != null) && cssBox_1.ParentBox.Rectangles.ContainsKey(this)) && (rect2.Height < cssBox_1.ParentBox.Rectangles[this].Height))
                {
                    double y = num - num2;
                    RRect rect3 = new RRect(rect2.X, y, rect2.Width, rect2.Height);
                    this.Rectangles[cssBox_1] = rect3;
                    cssBox_1.method_12(this, num2);
                }
                foreach (CssRect rect5 in list)
                {
                    if (!rect5.IsImage)
                    {
                        rect5.Top = num;
                    }
                }
            }
        }

        public override string ToString()
        {
            string[] strArray = new string[this.Words.Count];
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = this.Words[i].Text;
            }
            return string.Join(" ", strArray);
        }

        public double LineBottom
        {
            get
            {
                double num = 0.0;
                foreach (KeyValuePair<CssBox, RRect> pair in this.dictionary_0)
                {
                    num = Math.Max(num, pair.Value.Bottom);
                }
                return num;
            }
        }

        public double LineHeight
        {
            get
            {
                double num = 0.0;
                foreach (KeyValuePair<CssBox, RRect> pair in this.dictionary_0)
                {
                    num = Math.Max(num, pair.Value.Height);
                }
                return num;
            }
        }

        public CssBox OwnerBox
        {
            get
            {
                return this.cssBox_0;
            }
        }

        public Dictionary<CssBox, RRect> Rectangles
        {
            get
            {
                return this.dictionary_0;
            }
        }

        public List<CssBox> RelatedBoxes
        {
            get
            {
                return this.list_1;
            }
        }

        public List<CssRect> Words
        {
            get
            {
                return this.list_0;
            }
        }
    }
}

