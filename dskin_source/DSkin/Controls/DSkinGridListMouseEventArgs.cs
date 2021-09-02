namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinGridListMouseEventArgs : DSkinGridListEventArgs
    {
        [CompilerGenerated]
        private System.Windows.Forms.MouseEventArgs mouseEventArgs_0;

        public DSkinGridListMouseEventArgs(System.Windows.Forms.MouseEventArgs mouseEventArgs, DSkinGridListRow item, int cellIndex) : base(item)
        {
            this.MouseEventArgs = mouseEventArgs;
            base.CellIndex = cellIndex;
        }

        public System.Windows.Forms.MouseEventArgs MouseEventArgs
        {
            [CompilerGenerated]
            get
            {
                return this.mouseEventArgs_0;
            }
            [CompilerGenerated]
            set
            {
                this.mouseEventArgs_0 = value;
            }
        }
    }
}

