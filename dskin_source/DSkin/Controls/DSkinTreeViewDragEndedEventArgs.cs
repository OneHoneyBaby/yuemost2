namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;

    public class DSkinTreeViewDragEndedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private DSkinTreeViewNode dskinTreeViewNode_0;
        [CompilerGenerated]
        private DSkinTreeViewNode dskinTreeViewNode_1;

        public DSkinTreeViewDragEndedEventArgs(DSkinTreeViewNode select, DSkinTreeViewNode target)
        {
            this.Select = select;
            this.Target = target;
        }

        public DSkinTreeViewNode Select
        {
            [CompilerGenerated]
            get
            {
                return this.dskinTreeViewNode_1;
            }
            [CompilerGenerated]
            set
            {
                this.dskinTreeViewNode_1 = value;
            }
        }

        public DSkinTreeViewNode Target
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

