namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ItemClickEventArgs : MouseEventArgs
    {
        [CompilerGenerated]
        private DuiBaseControl duiBaseControl_0;
        [CompilerGenerated]
        private int int_0;

        public ItemClickEventArgs(int index, DuiBaseControl control, MouseButtons mb, int clicks, int x, int y, int delta) : base(mb, clicks, x, y, delta)
        {
            this.Index = index;
            this.Control = control;
        }

        public DuiBaseControl Control
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

        public int Index
        {
            [CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }
    }
}

