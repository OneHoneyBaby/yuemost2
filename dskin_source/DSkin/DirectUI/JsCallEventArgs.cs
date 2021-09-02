namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class JsCallEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IntPtr intptr_0;
        [CompilerGenerated]
        private long long_0;

        public IntPtr IntPtr_0
        {
            [CompilerGenerated]
            get
            {
                return this.intptr_0;
            }
            [CompilerGenerated]
            set
            {
                this.intptr_0 = value;
            }
        }

        public long Result
        {
            [CompilerGenerated]
            get
            {
                return this.long_0;
            }
            [CompilerGenerated]
            set
            {
                this.long_0 = value;
            }
        }
    }
}

