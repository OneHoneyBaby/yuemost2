namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinTreeViewNodeClickEventArgs : DSkinTreeViewEventArgs
    {
        [CompilerGenerated]
        private System.Windows.Forms.MouseEventArgs mouseEventArgs_0;

        public DSkinTreeViewNodeClickEventArgs(DSkinTreeViewNode item, System.Windows.Forms.MouseEventArgs e) : base(item)
        {
            this.MouseEventArgs = e;
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

