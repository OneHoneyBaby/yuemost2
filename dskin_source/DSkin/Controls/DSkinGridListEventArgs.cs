namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;

    public class DSkinGridListEventArgs : EventArgs
    {
        [CompilerGenerated]
        private DSkinGridListRow dskinGridListRow_0;
        [CompilerGenerated]
        private int int_0;

        public DSkinGridListEventArgs(DSkinGridListRow item)
        {
            this.Item = item;
            this.CellIndex = -1;
        }

        public int CellIndex
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

        public DSkinGridListRow Item
        {
            [CompilerGenerated]
            get
            {
                return this.dskinGridListRow_0;
            }
            [CompilerGenerated]
            set
            {
                this.dskinGridListRow_0 = value;
            }
        }
    }
}

