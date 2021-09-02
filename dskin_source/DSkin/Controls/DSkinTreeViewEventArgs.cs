namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;

    public class DSkinTreeViewEventArgs : EventArgs
    {
        [CompilerGenerated]
        private DSkinTreeViewNode dskinTreeViewNode_0;

        public DSkinTreeViewEventArgs(DSkinTreeViewNode item)
        {
            this.Item = item;
        }

        public DSkinTreeViewNode Item
        {
            [CompilerGenerated]
            get
            {
                return this.dskinTreeViewNode_0;
            }
            [CompilerGenerated]
            set
            {
                this.dskinTreeViewNode_0 = value;
            }
        }
    }
}

