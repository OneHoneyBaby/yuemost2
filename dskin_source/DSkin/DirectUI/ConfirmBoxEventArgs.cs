namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class ConfirmBoxEventArgs : EventArgs
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private string string_0;

        public string Message
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

        public bool Yes
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }
    }
}

