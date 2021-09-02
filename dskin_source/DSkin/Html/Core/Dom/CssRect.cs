namespace DSkin.Html.Core.Dom
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Handlers;
    using System;

    public abstract class CssRect
    {
        private readonly CssBox cssBox_0;
        private RRect rrect_0;
        private SelectionHandler selectionHandler_0;

        protected CssRect(CssBox owner)
        {
            this.cssBox_0 = owner;
        }

        internal double method_0()
        {
            return ((this.OwnerBox != null) ? this.OwnerBox.ActualFont.LeftPadding : 0.0);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} char{2})", this.Text.Replace(' ', '-').Replace("\n", @"\n"), this.Text.Length, (this.Text.Length != 1) ? "s" : string.Empty);
        }

        public double ActualWordSpacing
        {
            get
            {
                return ((this.OwnerBox != null) ? ((this.HasSpaceAfter ? this.OwnerBox.ActualWordSpacing : 0.0) + (this.IsImage ? this.OwnerBox.ActualWordSpacing : 0.0)) : 0.0);
            }
        }

        public double Bottom
        {
            get
            {
                return this.Rectangle.Bottom;
            }
            set
            {
                this.Height = value - this.Top;
            }
        }

        public double FullWidth
        {
            get
            {
                return (this.rrect_0.Width + this.ActualWordSpacing);
            }
        }

        public virtual bool HasSpaceAfter
        {
            get
            {
                return false;
            }
        }

        public virtual bool HasSpaceBefore
        {
            get
            {
                return false;
            }
        }

        public double Height
        {
            get
            {
                return this.rrect_0.Height;
            }
            set
            {
                this.rrect_0.Height = value;
            }
        }

        public virtual RImage Image
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public virtual bool IsImage
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsLineBreak
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsSpaces
        {
            get
            {
                return true;
            }
        }

        public double Left
        {
            get
            {
                return this.rrect_0.X;
            }
            set
            {
                this.rrect_0.X = value;
            }
        }

        public CssBox OwnerBox
        {
            get
            {
                return this.cssBox_0;
            }
        }

        public RRect Rectangle
        {
            get
            {
                return this.rrect_0;
            }
            set
            {
                this.rrect_0 = value;
            }
        }

        public double Right
        {
            get
            {
                return this.Rectangle.Right;
            }
            set
            {
                this.Width = value - this.Left;
            }
        }

        public bool Selected
        {
            get
            {
                return (this.selectionHandler_0 != null);
            }
        }

        public int SelectedEndIndexOffset
        {
            get
            {
                return ((this.selectionHandler_0 != null) ? this.selectionHandler_0.GetSelectedEndIndexOffset(this) : -1);
            }
        }

        public double SelectedEndOffset
        {
            get
            {
                return ((this.selectionHandler_0 != null) ? this.selectionHandler_0.GetSelectedEndOffset(this) : -1.0);
            }
        }

        public int SelectedStartIndex
        {
            get
            {
                return ((this.selectionHandler_0 != null) ? this.selectionHandler_0.GetSelectingStartIndex(this) : -1);
            }
        }

        public double SelectedStartOffset
        {
            get
            {
                return ((this.selectionHandler_0 != null) ? this.selectionHandler_0.GetSelectedStartOffset(this) : -1.0);
            }
        }

        public SelectionHandler Selection
        {
            get
            {
                return this.selectionHandler_0;
            }
            set
            {
                this.selectionHandler_0 = value;
            }
        }

        public virtual string Text
        {
            get
            {
                return null;
            }
        }

        public double Top
        {
            get
            {
                return this.rrect_0.Y;
            }
            set
            {
                this.rrect_0.Y = value;
            }
        }

        public double Width
        {
            get
            {
                return this.rrect_0.Width;
            }
            set
            {
                this.rrect_0.Width = value;
            }
        }
    }
}

