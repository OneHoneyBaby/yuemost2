namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class LoadingFinishEventArgs : EventArgs
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private DSkin.DirectUI.wkeLoadingResult wkeLoadingResult_0;

        public string FailedReason
        {
            [CompilerGenerated]
            get
            {
                return this.string_1;
            }
            [CompilerGenerated]
            set
            {
                this.string_1 = value;
            }
        }

        public DSkin.DirectUI.wkeLoadingResult LoadingResult
        {
            [CompilerGenerated]
            get
            {
                return this.wkeLoadingResult_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeLoadingResult_0 = value;
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

