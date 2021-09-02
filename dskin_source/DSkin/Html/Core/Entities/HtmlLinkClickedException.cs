namespace DSkin.Html.Core.Entities
{
    using System;

    public sealed class HtmlLinkClickedException : Exception
    {
        public HtmlLinkClickedException()
        {
        }

        public HtmlLinkClickedException(string message) : base(message)
        {
        }

        public HtmlLinkClickedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

