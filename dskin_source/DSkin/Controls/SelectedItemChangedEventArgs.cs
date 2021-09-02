namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;

    public class SelectedItemChangedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private DSkinDynamicListBoxItem dskinDynamicListBoxItem_0;
        [CompilerGenerated]
        private int int_0;
        [CompilerGenerated]
        private int int_1;

        public SelectedItemChangedEventArgs(DSkinDynamicListBoxItem item, int index, int newIndex)
        {
            this.Item = item;
            this.Index = index;
            this.NewIndex = index;
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

        public DSkinDynamicListBoxItem Item
        {
            [CompilerGenerated]
            get
            {
                return this.dskinDynamicListBoxItem_0;
            }
            [CompilerGenerated]
            set
            {
                this.dskinDynamicListBoxItem_0 = value;
            }
        }

        public int NewIndex
        {
            [CompilerGenerated]
            get
            {
                return this.int_1;
            }
            [CompilerGenerated]
            set
            {
                this.int_1 = value;
            }
        }
    }
}

