namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class ConsoleMessageEventArgs : EventArgs
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private uint uint_0;
        [CompilerGenerated]
        private DSkin.DirectUI.wkeMessageLevel wkeMessageLevel_0;
        [CompilerGenerated]
        private DSkin.DirectUI.wkeMessageSource wkeMessageSource_0;
        [CompilerGenerated]
        private DSkin.DirectUI.wkeMessageType wkeMessageType_0;

        public DSkin.DirectUI.wkeMessageLevel Level
        {
            [CompilerGenerated]
            get
            {
                return this.wkeMessageLevel_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeMessageLevel_0 = value;
            }
        }

        public uint LineNumber
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

        public DSkin.DirectUI.wkeMessageSource Source
        {
            [CompilerGenerated]
            get
            {
                return this.wkeMessageSource_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeMessageSource_0 = value;
            }
        }

        public DSkin.DirectUI.wkeMessageType Type
        {
            [CompilerGenerated]
            get
            {
                return this.wkeMessageType_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeMessageType_0 = value;
            }
        }

        public string Url
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
    }
}

