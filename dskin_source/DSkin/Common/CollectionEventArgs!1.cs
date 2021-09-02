namespace DSkin.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class CollectionEventArgs<T> : EventArgs
    {
        [CompilerGenerated]
        private T gparam_0;
        [CompilerGenerated]
        private int int_0;

        public CollectionEventArgs(T item, int index)
        {
            this.Item = item;
            this.Index = index;
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

        public T Item
        {
            [CompilerGenerated]
            get
            {
                return this.gparam_0;
            }
            [CompilerGenerated]
            set
            {
                this.gparam_0 = value;
            }
        }
    }
}

