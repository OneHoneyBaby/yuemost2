namespace DSkin.Html.Core.Entities
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class HtmlRenderErrorEventArgs : EventArgs
    {
        private readonly System.Exception exception_0;
        private readonly HtmlRenderErrorType htmlRenderErrorType_0;
        private readonly string string_0;

        public HtmlRenderErrorEventArgs(HtmlRenderErrorType type, string message, System.Exception exception = null)
        {
            this.htmlRenderErrorType_0 = type;
            this.string_0 = message;
            this.exception_0 = exception;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}", this.htmlRenderErrorType_0);
        }

        public System.Exception Exception
        {
            get
            {
                return this.exception_0;
            }
        }

        public string Message
        {
            get
            {
                return this.string_0;
            }
        }

        public HtmlRenderErrorType Type
        {
            get
            {
                return this.htmlRenderErrorType_0;
            }
        }
    }
}

