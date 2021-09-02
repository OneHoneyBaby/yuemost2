namespace DSkin.Html.Adapters.Entities
{
    using DSkin.Html.Core.Dom;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public sealed class RMouseEvent : MouseEventArgs
    {
        private readonly bool bool_0;
        [CompilerGenerated]
        private bool bool_1;
        [CompilerGenerated]
        private CssBox cssBox_0;

        public RMouseEvent(MouseButtons mb, int clicks, int x, int y, int delta, bool handled, CssBox source) : base(mb, clicks, x, y, delta)
        {
            this.bool_0 = (mb & MouseButtons.Left) != MouseButtons.None;
            this.Handled = handled;
            this.OriginalSource = source;
        }

        public bool Handled
        {
            [CompilerGenerated]
            get
            {
                return this.bool_1;
            }
            [CompilerGenerated]
            set
            {
                this.bool_1 = value;
            }
        }

        public bool LeftButton
        {
            get
            {
                return this.bool_0;
            }
        }

        public CssBox OriginalSource
        {
            [CompilerGenerated]
            get
            {
                return this.cssBox_0;
            }
            [CompilerGenerated]
            set
            {
                this.cssBox_0 = value;
            }
        }
    }
}

