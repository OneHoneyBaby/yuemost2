namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DuiMouseEventArgs : MouseEventArgs
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private DuiBaseControl duiBaseControl_0;

        public DuiMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta, bool handled, DuiBaseControl source) : base(button, clicks, x, y, delta)
        {
            this.Handled = handled;
            this.OriginalSource = source;
        }

        public bool Handled
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }

        public DuiBaseControl OriginalSource
        {
            [CompilerGenerated]
            get
            {
                return this.duiBaseControl_0;
            }
            [CompilerGenerated]
            set
            {
                this.duiBaseControl_0 = value;
            }
        }
    }
}

