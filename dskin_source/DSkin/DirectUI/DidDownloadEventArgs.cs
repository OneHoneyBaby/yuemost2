namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class DidDownloadEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IntPtr intptr_0;
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private uint uint_0;

        public IntPtr Data
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

        public uint Size
        {
            [CompilerGenerated]
            get
            {
                return this.uint_0;
            }
            [CompilerGenerated]
            set
            {
                this.uint_0 = value;
            }
        }

        public string Url
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }
    }
}

