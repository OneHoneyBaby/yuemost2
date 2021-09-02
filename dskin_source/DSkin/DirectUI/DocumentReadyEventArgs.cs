namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class DocumentReadyEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IntPtr intptr_0;
        [CompilerGenerated]
        private IntPtr intptr_1;
        [CompilerGenerated]
        private object object_0;
        [CompilerGenerated]
        private string string_0;

        public IntPtr FrameJSState
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

        public object FrameObject
        {
            [CompilerGenerated]
            get
            {
                return this.object_0;
            }
            [CompilerGenerated]
            set
            {
                this.object_0 = value;
            }
        }

        public IntPtr MainFrameJSState
        {
            [CompilerGenerated]
            get
            {
                return this.intptr_1;
            }
            [CompilerGenerated]
            set
            {
                this.intptr_1 = value;
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

